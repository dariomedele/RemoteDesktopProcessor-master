'Option Strict On
Option Explicit On

Imports System.Math
Imports System.Text
Imports System.Threading
Imports System.Deployment
Imports System.Deployment.Application
Imports System.IO

Imports System.Data.SqlClient
Imports XanLib
Imports Microsoft.Win32
Imports System.Configuration
Imports System.Environment




Public Class Form1
    'Version and application title
    Dim tempFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\ERStemp\"
    Dim Apptitle As String = "ERS Remote Document Processor"
    Dim Version As Integer = 0
    Dim SubVersion As Integer = 7
    Dim VersionStr As String = CStr(Version) & "." & CStr(SubVersion)

    'Structures
    Structure DirectoryMetadata ' recordset for each pdf folder
        Dim DirectoryName As String
        Dim Foldername As String
        Dim PDFFileCount As Integer
    End Structure
    Dim InputMeta() As DirectoryMetadata 'Meta data for each pdf input folder

    'File locations and names
#If 0 Then
    Public InputDirectory As String = "C:\Users\Richard\Documents\My Box Files(rmay@envirofuel.ca) - Copy???\" 'the folder where all the pdf input folders are kept
    Public OutputDirectory As String = "C:\Users\Richard\Documents\My Box Files(rmay@envirofuel.ca) - CopyFinal\" 'the folder where all the output folders are kept
    Public ArchiveDirectory As String = "C:\Users\Richard\Documents\My Box Files(rmay@envirofuel.ca) - CopyArchive\" 'the folder where all the archive files are kept
#Else
    Public InputDirectory As String = Environment.SpecialFolder.Personal.ToString & "\My Box Files\" 'the folder where all the pdf input folders are kept"
    Public ftpDirectory As String = "\\ERS-SERVER04\ers-share\FTP\Scan Group Folder - read only please\" 'the ftp folder where all the pdf input folders are kept"
    Public OutputDirectory As String = "\\ERS-SERVER04\ers-share\Remote Documents - read only please\" 'the folder where all the output folders are kept
    Public ArchiveDirectory As String = "\\ERS-SERVER04\ers-share\Remote Documents - read only please\Archive\" 'the folder where all the archive files are kept
    Public DuplicateDirectory As String = "\\ERS-SERVER04\ers-share\Remote Documents - read only please\Duplicates\" 'the folder where all the archive files are kept

#End If

    Dim FolderTag As String = "ERS SCAN" 'every pdf input folder will have this string in its name
    Dim folderlist As String()
    Dim currentfolder As String 'current folder being processed
    Public selectedfile As String 'the file currently in the pdf display window
    Public destinationfile As String 'the full filenamefor the destination file i.e. in the repository
    Dim currentfilelist As String(,) = New String(1, 250) {} 'names of files in currentfolder, both full path and display name
    Dim processedfilelist As String(,) = New String(1, 250) {} 'names of processed files from this session (and others that may be added), both full path and display name
    Dim processedfilelistlast As Integer = -1 'points to last valid entry in array -1 means the array is empty
    Enum nametype
        full = 0
        display = 1
    End Enum

    'File Metadata                    {True, False, False, False, True, True, True},
    Dim FilePrefix() As String = New String() {"SO", "BOL", "CDS", "DSD", "FLHA", " Fuel", "M", "Log", "Time", "Drop", "TC", "TS", "VehInsp", "WO", "Oth"}
    Dim Metatagstring() As String = New String() {"d=", "t=", "dr=", "", "c=", "so=", "de=", "sh="}
    Dim Metacontent(,) As Boolean = New Boolean(,) {{False, True, True, True, True, True, True, True, True, True, True, True, True, True, True},
                                                    {False, True, False, True, False, True, True, True, True, False, True, True, True, False, True},
                                                    {False, False, False, False, False, True, True, True, True, True, False, False, True, False, True},
                                                    {True, True, False, False, False, False, False, False, False, False, False, True, False, False, True},
                                                    {False, False, False, True, False, False, False, False, False, False, False, False, False, True, True},
                                                    {False, False, False, True, False, False, False, False, False, False, False, False, False, True, True},
                                                    {False, False, False, False, True, False, False, False, False, False, False, False, False, False, True},
                                                    {False, False, True, False, False, False, False, False, False, False, False, False, False, False, False}}

    Dim documenttype As Integer = 0 'type of document currently in the window

    Enum meta
        TDate = 0
        Truck = 1
        Driver = 2
        Number = 3
        Customer = 4
        SalesOrder = 5
        Description = 6
        Shipto = 7
    End Enum
    Dim Metaarray() As String

    'controls 
    Dim maxfoldercontrols As Integer = 13 'maximum number of input folders
    Dim foldernumber As Integer 'current folder control number
    Dim filenumber As Integer = 0 ' index in current folder list
    Dim DocCboBox() As String = New String() {"Sales Order", "BOL", "CDS", "DSD", "FLHA", "Fuel Receipts", "Manifest", "Mileage Log", "Time Sheet", "Trailer Drop", "Transfer-Cardlock", "Transfer-SmartTruck", "Vehicle Inspection", "Work Order", "Other"}
    Dim metalabels() As String = New String() {"Date", "Truck", "Driver", "Ticket Number", "Customer", "SalesOrder", "Description", "Ship To"}

    'Misc
    Dim neverprinted As Boolean = True 'a toggle that creates a print dialogue on 1st printing, but suppresses it thereafter 
    Dim currentfilewasprocessed As Boolean 'indicates that current file was previously processed and is now being corrected in some way

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Come here to initialize the application

        'scratchpad
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim foldersfound As Boolean = False

        'get version information and display it
        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            VersionStr = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Else
            VersionStr = "debug"
        End If
        VersionStr = "V " & VersionStr
        Me.Lblversion.Text = VersionStr

        ReDim folderlist(maxfoldercontrols) 'set folder name array to maximum number of folders
        ReDim InputMeta(maxfoldercontrols) 'Meta data for each pdf input folder

        'now get settings
        loadsettings()

        'check that the input, output and archive folders exist or get ones that do

        While Not foldersfound
            foldersfound = My.Computer.FileSystem.DirectoryExists(InputDirectory) And
                My.Computer.FileSystem.DirectoryExists(OutputDirectory) And
                My.Computer.FileSystem.DirectoryExists(ArchiveDirectory)
            If Not foldersfound Then getfolders()
        End While

        'folders found, so save them
        My.Settings.Save()

        'now initialize the working data and controls
        '1st count pdf documents in pdf folders.  If we can't find any folders ask the user for a new directory or if they want to quit
        'if found the setup() routine will also set up the folder buttons

        While SetupFolders() = 0
            'if there are no folders we need a new input folder
            Dim folderBrowserDialog1 As New FolderBrowserDialog

            ' Set the Help text description for the FolderBrowserDialog. 
            folderBrowserDialog1.Description = "I can't find any ERS SCAN folders, please select a new folder or create a scan folder"

            ' Allow the user to create New folders via the FolderBrowserDialog. 
            folderBrowserDialog1.ShowNewFolderButton = True

            ' Default to the My Documents folder. 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal

            'now get the folder names
            Dim result As DialogResult = folderBrowserDialog1.ShowDialog()
            InputDirectory = folderBrowserDialog1.SelectedPath & "\"
            My.Settings.inputpath = InputDirectory
            My.Settings.Save()
        End While

        'populate the file list combobox
        Dim Lbox As ListBox = Controls("lbxInputFiles")
        foldernumber = 0
        currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Lbox)

        'show the first file if there is one
        If Lbox.Items.Count > 0 Then
            Lbox.SelectedIndex = 0
            selectedfile = currentfilelist(nametype.full, 0)
            Dim tempFile As String = GetTempFileLocation(selectedfile)
            PDFViewWindow.src = tempFile
        End If

        'populate the document combobox
        Dim cboBox As ComboBox = Me.Gbx_metadata.Controls("CBoxDocuments")
        cboBox.Items.AddRange(DocCboBox)
        cboBox.SelectedIndex = 0

        'populate the meta field labels
        Dim Lbl As Label
        For j = 0 To UBound(metalabels)
            Lbl = Me.Gbx_metadata.Controls("LblMeta" & CStr(j + 1))
            Lbl.Text = metalabels(j)
        Next

        'format the date box and initialize the dates
        Dim dtp As DateTimePicker = Me.Gbx_metadata.Controls("DtpMetadata")
        dtp.CustomFormat = "MMM d"
        dtp.Value = Date.Today.AddDays(-1)
        UpdateTimeMeta(dtp.Value)

        ' set the version in the window
        Me.Text = Apptitle & " " & VersionStr

        'PDFViewWindow.src = "C:\Users\Richard\Documents\Magic Briefcase\ERS\Smarttruck project\Sales Completeness\Sales completeness PC203.pdf"

    End Sub

    ' display a list of files and populate the listbox.  Return the list in a structured array.
    Private Function PopulateFileList(ByVal Directory As String, ByVal lBox As ListBox) As String(,)
        Dim filename As String
        Dim initialfilelist() As String
        Dim formattedfilelist(1, 100) As String
        Dim MaxFiles As Integer = 100 'this is the maximum number of files in the listbox
        Dim i As Integer = 0

        'get the file names, format the display names

        initialfilelist = My.Computer.FileSystem.GetFiles(Directory, FileIO.SearchOption.SearchTopLevelOnly, "*.pdf").ToArray
        If initialfilelist.Length > MaxFiles Then 'if there are more than MaxFiles files then truncate the list.  As the list is reduced more files can be added
            ReDim Preserve initialfilelist(MaxFiles - 1)
            Debug.Print("listbox limit reached on " & Directory)
        End If
        Array.Sort(initialfilelist)
        For Each filename In initialfilelist
            formattedfilelist(nametype.full, i) = filename
            formattedfilelist(nametype.display, i) = Mid(filename, InStrRev(filename, "\") + 1)
            initialfilelist(i) = formattedfilelist(nametype.display, i)
            i += 1
        Next

        i -= 1
        ReDim Preserve initialfilelist(i)
        ReDim Preserve formattedfilelist(1, i)

        lBox.Items.Clear()
        lBox.Items.AddRange(initialfilelist)

        PopulateFileList = formattedfilelist
    End Function
    ' a folder button is clicked.  highlight that button and transfer its filenames into the input file listbox
    Private Sub btnFolder1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder1.Click, btnFolder2.Click, btnFolder3.Click, btnFolder4.Click, btnFolder5.Click, btnFolder6.Click, btnFolder7.Click, btnFolder8.Click, btnFolder9.Click, btnFolder10.Click, btnFolder11.Click, btnFolder12.Click, btnFolder13.Click
        'scratchpad
        Dim i As Integer = 0
        Dim j As Integer = 0

        ' Grey the controls
        Dim ctl As Control
        For j = 1 To maxfoldercontrols
            ctl = Me.Gbx_folders.Controls("btnFolder" & CStr(j))
            ctl.BackColor = SystemColors.Control
        Next

        'set the button number
        Dim b As Button = CType(sender, Button)
        foldernumber = Val(Strings.Right(b.Name, Len(b.Name) - Len("btnFolder"))) - 1

        Dim Lbox As ListBox = Controls("lbxInputFiles")
        Lbox.Items.Clear()
        currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Lbox)
        ctl = Me.Gbx_folders.Controls("btnFolder" & CStr(foldernumber + 1))
        ctl.BackColor = Color.FromName("LightGreen")

        'show the first file if there is one
        If Lbox.Items.Count > 0 Then
            Lbox.SelectedIndex = 0
            selectedfile = currentfilelist(nametype.full, 0)

            PDFViewWindow.src = GetTempFileLocation(selectedfile)
        Else
            With PDFViewWindow
                .src = ""
            End With
            Me.LblFileName.Text = "" 'blank the file name
        End If

    End Sub

    Private Sub lbxInputFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxInputFiles.SelectedIndexChanged
        Dim index As Integer = lbxInputFiles.SelectedIndex

        'first filter out the spurious events due to changing lists as files around
        'If Control.MouseButtons = 0 Then Return

        'see if we're coming from a processed file and if so, do some swapping
        If currentfilewasprocessed Then
            'set the flag
            currentfilewasprocessed = False
            'reload the files from the active folder
            currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Me.lbxInputFiles)

        End If

        'turn off the selector on the output side (could put inside wasprocessed loop but no need)
        'TODO - fix this
#If 0 Then
        For i As Integer = 0 To lbxOutputFiles.Items.Count - 1
            lbxOutputFiles.SetSelected(i, False)
        Next i
#Else
        'for Now just put the filename in the title
        Me.LblFileName.Text = currentfilelist(nametype.display, index)
#End If
        selectedfile = currentfilelist(nametype.full, index)

        Dim tempFile As String = GetTempFileLocation(selectedfile)

        PDFViewWindow.src = tempFile '  selectedfile
        'todo view properties

        PDFViewWindow.setPageMode("none")
        'return focus to the document metadata
        ReturnFocus()

    End Sub
    Private Function GetTempFileLocation(ByVal fileName As String) As String

        If Not Directory.Exists(tempFolder) Then
            Directory.CreateDirectory(tempFolder)
        End If
        Dim tempFile = tempFolder & Path.GetFileName(fileName)
        If Path.GetDirectoryName(fileName) <> "" Then
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(tempFolder)
                If Path.GetFileName(foundFile) <> Path.GetFileName(fileName) Then
                    My.Computer.FileSystem.DeleteFile(foundFile)
                End If
            Next

            If Not File.Exists(tempFile) Then
                My.Computer.FileSystem.CopyFile(fileName, tempFile, True)
            End If
        End If

        Return tempFile


    End Function
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'come here if print button clicked
        If neverprinted Then
            PDFViewWindow.printWithDialog()
            neverprinted = False
        Else
            PDFViewWindow.printAll()
        End If
    End Sub

    Private Sub CBoxDocuments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBoxDocuments.SelectedIndexChanged
        'have made a change in document type.  update the metadata controls
        Dim Cbox As ComboBox = Me.Gbx_metadata.Controls("CBoxDocuments")
        Dim Lbl As Label
        Dim Tbox As TextBox
        Dim Dtp As DateTimePicker = Me.Gbx_metadata.Controls("DtpMetadata")

        documenttype = CBoxDocuments.SelectedIndex

        For j = UBound(metalabels) To 0 Step -1
            Lbl = Me.Gbx_metadata.Controls("LblMeta" & CStr(j + 1))
            Tbox = Me.Gbx_metadata.Controls("TbxMeta" & CStr(j + 1))
            'Debug.Print("index = {0}, label = {1}, setting = {2}", documenttype, Lbl.Text, Metacontent(j, documenttype))
            If Metacontent(j, documenttype) Then
                Lbl.ForeColor = SystemColors.ControlText
                Tbox.Enabled = True
                Tbox.Focus()
            Else
                Lbl.ForeColor = SystemColors.GrayText
                Tbox.Enabled = False
            End If
        Next
        Dtp.Enabled = Metacontent(meta.TDate, documenttype)

    End Sub
    Private Sub ReturnFocus()
        'return focus back to the first meta data box
        Dim Cbox As ComboBox = Me.Gbx_metadata.Controls("CBoxDocuments")
        Dim Tbox As TextBox
        Dim Dtp As DateTimePicker = Me.Gbx_metadata.Controls("DtpMetadata")

        ' let's make sure Cbox can be focussed upon
        If Cbox.SelectedIndex < 0 Then Return
        'now set the focus
        For j = UBound(metalabels) To 0 Step -1
            Tbox = Me.Gbx_metadata.Controls("TbxMeta" & CStr(j + 1))
            If Metacontent(j, CBoxDocuments.SelectedIndex) Then
                Tbox.Select()
                Tbox.Focus()
            End If
        Next
        Me.Refresh()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveProcessedfile()
    End Sub
    Private Function SetupFolders() As Integer
        'come here to look for pdf files, set the folder buttons and populate inputmeta.  Return the count of folders found
        Dim DirectoryList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim ftpDirectoryList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim Directory As String
        ReDim InputMeta(100) 'Meta data for each pdf input folder.  this is a silly large number which gets redimmed

        'scratchpad
        'Dim i As Integer = 0
        Dim j As Integer = 0
        Dim label As String
        Dim numbuttons As Integer = 0 'number of folder buttons (and folders)
        Dim buttonwidth As Integer = 0 'width of folder button

        'Look for pdf folders and populate the controls in the window
        'assemble the main directory name, folder label and count pdf documents in pdf folders.   TODO for now just use a string, but in the future search for the Box folder
        DirectoryList = My.Computer.FileSystem.GetDirectories(InputDirectory, FileIO.SearchOption.SearchAllSubDirectories)
        'add the ftp directory
        ftpDirectoryList = (My.Computer.FileSystem.GetDirectories(ftpDirectory, FileIO.SearchOption.SearchAllSubDirectories))

        For Each Directory In DirectoryList
            If InStr(Directory, FolderTag) > 0 Then
                InputMeta(numbuttons).DirectoryName = Directory
                InputMeta(numbuttons).Foldername = Mid(Directory, InStr(Directory, FolderTag) + Len(FolderTag) + 1)
                InputMeta(numbuttons).PDFFileCount = My.Computer.FileSystem.GetFiles(Directory, FileIO.SearchOption.SearchTopLevelOnly, "*.pdf").Count

                numbuttons += 1 'point to next Meta

            End If
        Next

        For Each Directory In ftpDirectoryList
            If InStr(Directory, FolderTag) > 0 Then
                InputMeta(numbuttons).DirectoryName = Directory
                InputMeta(numbuttons).Foldername = Mid(Directory, InStr(Directory, FolderTag) + Len(FolderTag) + 1)
                InputMeta(numbuttons).PDFFileCount = My.Computer.FileSystem.GetFiles(Directory, FileIO.SearchOption.SearchTopLevelOnly, "*.pdf").Count

                numbuttons += 1 'point to next Meta

            End If
        Next

        ReDim Preserve InputMeta(numbuttons - 1)

        'Send an alert if there are more folders than buttons
        If numbuttons > maxfoldercontrols Then MsgBox("There are more folders than we have space for.  Please remove any unused folders.  For now we'll use the first " + maxfoldercontrols.ToString + " folders")

        'Next populate the folder controls
        Dim ctl As Control
        For j = 1 To maxfoldercontrols
            ctl = Me.Gbx_folders.Controls("btnFolder" & CStr(j))
            If j <= numbuttons Then
                label = InputMeta(j - 1).Foldername
                label = label & " (" & CStr(InputMeta(j - 1).PDFFileCount) & ")"
                'Debug.Print(label)
                ctl.Visible = True
                ctl.Text = label
                buttonwidth = ctl.Width + 6 'save the button width + spacing
                If Len(label) > 12 Then ctl.Font = New Font(ctl.Font.FontFamily, 7.0F, FontStyle.Regular)
                If Len(label) > 15 Then ctl.Font = New Font(ctl.Font.FontFamily, 6.5F, FontStyle.Regular)
            Else
                ctl.Visible = False
            End If
        Next

        'Finally resize the Groupbox.  The default width is tied to the number of buttons but if it's longer than maxcontrols, it's clamped at that value
        j = numbuttons '
        If numbuttons > maxfoldercontrols Then j = maxfoldercontrols
        Me.Gbx_folders.Width = Me.Gbx_folders.Left + (j * buttonwidth) + 8

        Return numbuttons 'the number of buttons is the number of folders found

    End Function

    Private Sub DtpMetadata_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpMetadata.ValueChanged
        'the date has been changed.  update the date metafield
        UpdateTimeMeta(DtpMetadata.Value)
    End Sub
    Private Sub UpdateTimeMeta(ByVal time As Date)
        'come here to update the time meta field
        Dim Tbox As TextBox = Me.Gbx_metadata.Controls("TbxMeta" & CStr(meta.TDate + 1))
        Tbox.Text = time.ToString("MMM-dd-yyyy")
    End Sub
    Function MakeFileNameFriendly(ByVal nameStr As String) As String
        'clean out illegal characters in a filename
        Dim replaceChar As Char
        Dim strIndex As Integer
        Dim i As Integer
        replaceChar = CChar("-")
        Dim ForbiddenFilenameChars As String = "\/:*?<>|"

        If Not nameStr Is Nothing Then
            For i = 0 To nameStr.Length - 1
                strIndex = ForbiddenFilenameChars.IndexOf(nameStr(i))
                If (strIndex >= 0) Then
                    nameStr = nameStr.Replace(ForbiddenFilenameChars(strIndex), replaceChar)
                End If
            Next
        End If
        Return nameStr
    End Function

    Private Sub lbxOutputFiles_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbxOutputFiles.MouseMove
        Dim MousePositionInClientCoords As Point = New Point(e.X, e.Y)
        Dim indexUnderTheMouse As Integer = Me.lbxOutputFiles.IndexFromPoint(MousePositionInClientCoords)

        Static oldindex As Integer
        If oldindex = indexUnderTheMouse Then Return 'debounce changes to stop shimmering
        oldindex = indexUnderTheMouse

        If indexUnderTheMouse > -1 Then
            Dim s As String = Me.lbxOutputFiles.Items(indexUnderTheMouse).ToString
            Dim g As Graphics = Me.lbxOutputFiles.CreateGraphics
            'Debug.Print("index {0:0} measure string {1:0.0} width {2:0.0}", indexUnderTheMouse, g.MeasureString(s, Me.lbxOutputFiles.Font).Width, Me.lbxOutputFiles.ClientRectangle.Width)
            If g.MeasureString(s, Me.lbxOutputFiles.Font).Width > Me.lbxOutputFiles.ClientRectangle.Width Then
                Me.ToolTip1.SetToolTip(Me.lbxOutputFiles, s)
            Else
                Me.ToolTip1.SetToolTip(Me.lbxOutputFiles, "")
            End If
            g.Dispose()
        End If
    End Sub
    Private Sub lbxinputFiles_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbxInputFiles.MouseMove
        Dim MousePositionInClientCoords As Point = New Point(e.X, e.Y)
        Dim indexUnderTheMouse As Integer = Me.lbxInputFiles.IndexFromPoint(MousePositionInClientCoords)

        Static oldindex As Integer
        If oldindex = indexUnderTheMouse Then Return 'debounce changes to stop shimmering
        oldindex = indexUnderTheMouse

        If indexUnderTheMouse > -1 Then
            Dim s As String = Me.lbxInputFiles.Items(indexUnderTheMouse).ToString
            Dim g As Graphics = Me.lbxInputFiles.CreateGraphics
            'Debug.Print("index {0:0} measure string {1:0.0} width {2:0.0}", indexUnderTheMouse, g.MeasureString(s, Me.lbxInputFiles.Font).Width, Me.lbxOutputFiles.ClientRectangle.Width)
            If g.MeasureString(s, Me.lbxInputFiles.Font).Width > Me.lbxInputFiles.ClientRectangle.Width Then
                Me.ToolTip1.SetToolTip(Me.lbxInputFiles, s)
            Else
                Me.ToolTip1.SetToolTip(Me.lbxInputFiles, "")
            End If
            g.Dispose()
        End If
    End Sub


    Private Sub TbxMeta_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TbxMeta2.KeyUp, TbxMeta6.KeyDown, TbxMeta5.KeyDown, TbxMeta4.KeyDown, TbxMeta3.KeyUp, DtpMetadata.KeyDown, TbxMeta7.KeyDown
        'if we get a <CR> process the file
        If e.KeyCode = Keys.Enter Then SaveProcessedfile()
    End Sub
    Private Sub SaveProcessedfile()
        'Come here to save processed file.  save a copy and move the renamed file to the document
        Dim tempfilename As String = Nothing
        Dim tempfolderdirectory As String
        Dim tempfilelist(50) As String
        Dim shortfilename As String
        Dim storefilepath As String
        Dim Tbox As TextBox
        Dim i As Integer
        Dim result As DialogResult

        Dim ofi As FileInfo 'store file information for logging
        Dim pfi As FileInfo
        'GET THE ORIGINAL LOCATION TO DELETE THIS FILE. 
        Dim index As Integer = lbxInputFiles.SelectedIndex
        currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Me.lbxInputFiles)
        Dim originalLocation As String = currentfilelist(nametype.full, index)


        'grab the original file information for logging
        selectedfile = GetTempFileLocation(selectedfile)

        ofi = My.Computer.FileSystem.GetFileInfo(selectedfile)

        Dim MyDocIndex As New DocIndexer.MyIndex(Metatagstring, metalabels, FilePrefix, My.Settings.ERSCon)

        'Next compose the new filename
        tempfilename = FilePrefix(documenttype)
        For i = 0 To UBound(Metatagstring)
            Tbox = Me.Gbx_metadata.Controls("TbxMeta" & CStr(i + 1))
            If Metacontent(i, documenttype) Then
                tempfilename = tempfilename & " " & Metatagstring(i) & Tbox.Text
                MyDocIndex.AddTag(Metatagstring(i), Tbox.Text)
            End If

            'Debug.Print("document = {0}, label = {1}, setting = {2}", documenttype, Metatagstring(i), Metacontent(i, documenttype))
        Next

        tempfilename = MakeFileNameFriendly(tempfilename + ".pdf") 'append filetype and clean out any illegal characters

        'Next do the file operations
        shortfilename = Mid(selectedfile, InStrRev(selectedfile, "\"))  'get the filename
        storefilepath = OutputDirectory & DocCboBox(documenttype) & "\" 'generate the stored file directory path

        destinationfile = storefilepath & tempfilename

        Try
            ' copy the file to the archive folder, checking to see if it exists first
            If Not currentfilewasprocessed Then 'only archive incoming files, not reworked ones

                tempfolderdirectory = ArchiveDirectory & InputMeta(foldernumber).Foldername 'the archive folder ties back to the incoming folder

                'if a file with this name exists in the archive, append a sequence and file it anyway
                If My.Computer.FileSystem.FileExists(tempfolderdirectory & shortfilename) Then shortfilename = resequence(shortfilename)
                My.Computer.FileSystem.CopyFile(selectedfile, tempfolderdirectory & shortfilename, True)
                'now log the move
                pfi = My.Computer.FileSystem.GetFileInfo(tempfolderdirectory & shortfilename)
                If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then 'only log when deployed
                    LogFileProcessed(ofi, pfi)
                End If
                ' index this file
                MyDocIndex.IndexDoc(My.User.Name, pfi.FullName, True)

                End If

                'now move the file into the processed folder, checking that the directory exists and whether the file itself exists

                If Not My.Computer.FileSystem.DirectoryExists(storefilepath) Then My.Computer.FileSystem.CreateDirectory(storefilepath)

            destinationfile = storefilepath & tempfilename
            If Not My.Computer.FileSystem.FileExists(destinationfile) Or currentfilewasprocessed Then
                ' if this was a processed file, the move automatically erases the old one
                My.Computer.FileSystem.MoveFile(selectedfile, destinationfile)

                'Temp file was moved , now delete original file. 
                If My.Computer.FileSystem.FileExists(originalLocation) Then
                    My.Computer.FileSystem.DeleteFile(originalLocation)
                End If
                'now log the move

                pfi = My.Computer.FileSystem.GetFileInfo(destinationfile)
                If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then 'only log when deployed
                    LogFileProcessed(ofi, pfi)
                End If
                MyDocIndex.IndexDoc(My.User.Name, pfi.FullName, True)
                Else
                    'we have a duplicate.  put up a dialog box so the user can choose what to do.  Result is the answer to the question: overwrite the existing file?  If no, then move to duplicates
                    result = Dialog2.ShowDialog()

                If result = System.Windows.Forms.DialogResult.Cancel Then Return
                If result = System.Windows.Forms.DialogResult.Yes Then
                    My.Computer.FileSystem.MoveFile(selectedfile, destinationfile, True)
                    'now log the move
                    pfi = My.Computer.FileSystem.GetFileInfo(destinationfile)
                    If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then 'only log when deployed
                        LogFileProcessed(ofi, pfi)
                    End If
                End If

                    If result = System.Windows.Forms.DialogResult.No Then movetoduplicates()
            End If

            'MsgBox("Processing complete.  Original file saved as " & tempfilename)
        Catch ex As Exception
            MsgBox("Error occurred while saving files.  Message: " & vbCrLf & ex.Message)
        End Try

        'now update the file lists
        updatefilelists(storefilepath, tempfilename)

    End Sub

    Private Sub lbxOutputFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxOutputFiles.SelectedIndexChanged
        'come here if a file is to be reprocessed
        'Dim tempfilelist As String(,)
        'Dim maxlength As Integer
        Dim i As Integer = 0

        'first filter out the spurious events due to changing lists as files around
        'If Control.MouseButtons = 0 Then
        ' Return
        'End If

        filenumber = lbxOutputFiles.SelectedIndex 'record the file position
        currentfilewasprocessed = True 'set the flag

        'change currentfilelist to processedfilelist
        ReDim currentfilelist(1, 99) 'start with a clean currentfilelist
        For i = 0 To processedfilelistlast
            For j As Integer = 0 To 1
                currentfilelist(j, i) = processedfilelist(j, i) 'if there's a file in processedfile, then move it all over
            Next
        Next


#If 0 Then
        'turn off the selector on the input side TODO: fix this
        For i = 0 To Me.lbxInputFiles.Items.Count - 1
            Me.lbxInputFiles.SetSelected(i, False)
        Next i
#Else
        'for Now just put the filename in the title
        Me.LblFileName.Text = currentfilelist(nametype.display, filenumber)
#End If
        'put the file in the viewer window
        selectedfile = currentfilelist(nametype.full, filenumber)
        PDFViewWindow.src = GetTempFileLocation(selectedfile) ' selectedfile

        'TODO: next:I dont' know

        'move the filenames into a single dimensional array to put back into LbxOutput
        Me.lbxOutputFiles.Items.Clear()
    End Sub
    Private Sub updatefilelists(ByVal storefilepath As String, ByVal tempfilename As String)
        'after processing or adding files, update the relevant filelist
        Dim tempfoldername As String
        'Dim tempindex As Integer
        Dim i As Integer
        'Last, update the file windows and arrays
        If currentfilewasprocessed Then
            processedfilelist(nametype.full, filenumber) = storefilepath & tempfilename
            processedfilelist(nametype.display, filenumber) = tempfilename
            currentfilelist = processedfilelist

            For i = 0 To processedfilelistlast
                Me.lbxOutputFiles.Items.Add(processedfilelist(nametype.display, i))
                Debug.Print(processedfilelist(nametype.display, i))
            Next

        Else
            processedfilelistlast += 1 'increment the last item pointer
            processedfilelist(nametype.full, processedfilelistlast) = storefilepath & tempfilename
            processedfilelist(nametype.display, processedfilelistlast) = tempfilename
            Me.lbxOutputFiles.Items.Add(tempfilename)

            'Before returning refresh the input file window and update the buttons
            tempfoldername = InputMeta(foldernumber).DirectoryName  'keep the current foldername as the foldernumber could change with the update
            SetupFolders()
            restorefolderandnextfile(tempfoldername)


        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFiles.Click
        'come here to add previously processed files for processing

        Dim openFileDialog1 As New OpenFileDialog()
        Dim tempfullfilename As String
        Dim tempfilename As String
        Dim storefilepath As String

        openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.InitialDirectory = OutputDirectory

        If openFileDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Return 'failed import.  just go back to the window

        tempfullfilename = openFileDialog1.FileName
        tempfilename = Mid(tempfullfilename, InStrRev(tempfullfilename, "\") + 1)
        storefilepath = Mid(tempfullfilename, 1, InStrRev(tempfullfilename, "\"))

        'now add the file to the processed file list at the bottom
        currentfilewasprocessed = True
        processedfilelistlast += 1
        ' should this be foldernumber?
        filenumber = Me.lbxOutputFiles.Items.Count
        updatefilelists(storefilepath, tempfilename)

    End Sub
    Shared Sub Main()
        'the core routine
        While CBool(1)
            Debug.Print("*")
            System.Threading.Thread.Sleep(250)
        End While
    End Sub

    Sub Form1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar >= ChrW(48) And e.KeyChar <= ChrW(57) Then
            Debug.Print(("Form.KeyPress: '" + e.KeyChar.ToString() + "' pressed."))

            Select Case e.KeyChar
                Case ChrW(49), ChrW(52), ChrW(55)
                    MessageBox.Show(("Form.KeyPress: '" +
                        e.KeyChar.ToString() + "' consumed."))
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub loadsettings()
        'come here to load settings for the applications

        'folderpaths.  if they're empty then go with the default above
        If My.Computer.FileSystem.DirectoryExists(My.Settings.archivepath) Then
            ArchiveDirectory = My.Settings.archivepath
        End If
        If My.Computer.FileSystem.DirectoryExists(My.Settings.inputpath) Then
            InputDirectory = My.Settings.inputpath
        End If
        If My.Computer.FileSystem.DirectoryExists(My.Settings.outputpath) Then
            OutputDirectory = My.Settings.outputpath
        End If
        If My.Computer.FileSystem.DirectoryExists(My.Settings.duplicatepath) Then
            DuplicateDirectory = My.Settings.duplicatepath
        End If

    End Sub
    Private Sub saveallsettings()
        'come here to save all settings
        My.Settings.Save()
    End Sub
    Private Sub savesetting(ByVal settingname As String, ByVal value As Object)
        'come here to save a changed setting 
    End Sub

    Private Sub ERSLogo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ERSLogo.DoubleClick
        'doubleclicking the ERS logo will bring up the config dialogue.  After gathering the folder config information, check for files and reconfig the buttons
        Dim foldersfound As Boolean = False
        While Not foldersfound
            getfolders()
            'check for documents and set up the buttons
            If SetupFolders() = 0 Then
                Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical
                If MsgBox("No document found. Do you wish to continue?  (If Yes, either add folders and restart or re-choose the input directory)", style, "No documents found!") = MsgBoxResult.Yes Then
                    foldersfound = True
                End If
            Else
                foldersfound = True
            End If
        End While
    End Sub
    Private Sub getfolders()
        'check that the input, output and archive folders are valid.  Prompt for new ones if not, and save them
        Dim foldersfound As Boolean = False
        Dim result As DialogResult
        While Not foldersfound
            result = Dialog1.ShowDialog() 'prompt for file
            foldersfound = My.Computer.FileSystem.DirectoryExists(InputDirectory) And
                My.Computer.FileSystem.DirectoryExists(OutputDirectory) And
                My.Computer.FileSystem.DirectoryExists(ArchiveDirectory)
        End While

        If (result = DialogResult.OK) Then
            My.Settings.archivepath = ArchiveDirectory
            My.Settings.inputpath = InputDirectory
            My.Settings.outputpath = OutputDirectory
            My.Settings.duplicatepath = DuplicateDirectory
            My.Settings.Save()
        End If

        If result = DialogResult.Cancel Then System.Windows.Forms.Application.Exit() 'quit if the user decides not to record file names
    End Sub

    Private Sub TbxMeta4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbxMeta4.TextChanged

    End Sub

    Private Sub BtnDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDuplicate.Click
        'this file is a duplicate 
        Dim tempfoldername As String
        Dim i As Integer

        'first move it unchanged to the duplicates folder
        movetoduplicates()
        'now update the file lists
        If currentfilewasprocessed Then
            'remove the processed file from the processed file list and textbox
            For i = filenumber To UBound(processedfilelist, 2) - 1

                If Len(processedfilelist(nametype.full, i + 1)) > 0 Then
                    processedfilelist(nametype.full, i) = processedfilelist(nametype.full, i + 1)
                    processedfilelist(nametype.display, i) = processedfilelist(nametype.display, i + 1)
                Else
                    processedfilelist(nametype.full, i) = ""
                    processedfilelist(nametype.display, i) = ""
                End If
            Next i
            Me.lbxOutputFiles.Items.Remove(foldernumber)
        Else
            'it was an incoming file so just update that textbox
            'currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Me.lbxInputFiles)
            'Before returning refresh the input file window and update the buttons
            tempfoldername = InputMeta(foldernumber).DirectoryName  'keep the current foldername as the foldernumber could change with the update
            SetupFolders()
            restorefolderandnextfile(tempfoldername)

        End If
        If filenumber > 0 Then filenumber -= 1

    End Sub
    Function resequence(ByVal storefilename As String) As String
        'add a sequence suffix to this filename
        Dim filecounter As Integer = 1
        Dim fileinfo() As String

        'first split the name and the filetype
        fileinfo = Split(storefilename, ".")
        ' if the last two characters are '-x' where x is a number then increase the suffix.  Otherwise add '-1'
        If Microsoft.VisualBasic.Mid(fileinfo(0), Len(fileinfo(0)) - 2, 1) = "-" Then
            Try
                filecounter = CInt(Microsoft.VisualBasic.Mid(fileinfo(0), Len(fileinfo(0)) - 1, 1)) + 1
                'if no exception then we had a '-x' suffix.  Trim it off
                fileinfo(0) = Microsoft.VisualBasic.Left(fileinfo(0), Len(fileinfo(0)) - 2)
            Catch ex As Exception
                'if there was an exception then there was no number.  Keep filecounter as is
            End Try
        End If
        'now assemble the new file name
        resequence = fileinfo(0) & "-" & CStr(filecounter) & "." & fileinfo(1)
    End Function

    Sub restorefolderandnextfile(ByVal foldername)
        'come here after a file has been removed from the input folders and/or there are folder changes.  Refresh the connections
        Dim i As Integer
        Dim tempindex As Integer

        'find foldername in the new inputmeta
        For i = 0 To UBound(InputMeta)
            If StrComp(InputMeta(i).DirectoryName, foldername, CompareMethod.Text) = 0 Then Exit For
        Next

        foldernumber = i 'this restores the connection to the folder

        'move to the next file if there is one
        tempindex = Me.lbxInputFiles.SelectedIndex 'store the current index
        currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Me.lbxInputFiles) 'update the filelist

        If Me.lbxInputFiles.Items.Count > 0 Then
            Me.lbxInputFiles.SelectedIndex = Me.lbxInputFiles.Items.Count - 1 'if the old file was the last on the list, the index is now set to the new last

            If tempindex > Me.lbxInputFiles.Items.Count Then
                'Debug.Print("tempindex = {0:0} items count={1:0}", tempindex, lbox.Items.Count)
                Me.lbxInputFiles.SelectedIndex = tempindex 'otherwise it's set to the same position (which is now the next file)
            End If

            selectedfile = currentfilelist(nametype.full, Me.lbxInputFiles.SelectedIndex)
            PDFViewWindow.src = GetTempFileLocation(selectedfile) ' selectedfile
        End If
    End Sub

    Sub movetoduplicates()
        'this routine moves selectedfile to the duplicates folder
        Dim storefilename As String
        Dim storefilepath As String
        Dim ofi As FileInfo 'store file information for logging
        Dim pfi As FileInfo

        'Next do the file name and path 

        storefilename = Mid(selectedfile, InStrRev(selectedfile, "\"))  'get the filename
        If Not currentfilewasprocessed Then
            storefilepath = DuplicateDirectory & InputMeta(foldernumber).Foldername & "\" 'generate a file directory path corresponding to the incoming path
        Else
            storefilepath = DuplicateDirectory & "previously processed\" 'generate the previously processed file directory path
        End If
        Try
            'now move the file into the duplicate folder, checking that the directory exists and whether the file itself exists
            If Not My.Computer.FileSystem.DirectoryExists(storefilepath) Then My.Computer.FileSystem.CreateDirectory(storefilepath)

            If My.Computer.FileSystem.FileExists(storefilepath & storefilename) Then
                storefilename = resequence(storefilename)
            End If

            'grab the original file information before it's erased
            ofi = My.Computer.FileSystem.GetFileInfo(selectedfile)

            ' if this was a processed file, the move automatically erases the previously processed version
            My.Computer.FileSystem.MoveFile(selectedfile, storefilepath & storefilename, True)

            'record the process
            pfi = My.Computer.FileSystem.GetFileInfo(storefilepath & storefilename)
            If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then 'only log when deployed
                LogFileProcessed(ofi, pfi)
            End If
            'MsgBox("Processing complete.  Original file saved as " & tempfilename)
        Catch ex As Exception
            MsgBox("Error occurred while saving files.  Message: " & vbCrLf & ex.Message)
        End Try


    End Sub
    Sub LogFileProcessed(ByVal ofi As FileInfo, ByVal pfi As FileInfo)
        'log the file processing in the database

        Const SQLTYPETEXT = 1
        Const SQLTYPENUMBER = 2
        Const SQLTYPENULL = 3
        Const SQLTYPEDATETIME = 4 'FIXME this is wrong

        Dim cmd As SqlCommand
        Dim SaleCompleteConn As SqlConnection
        Dim connstring As String = "Data Source=ERS-SERVER04;Initial Catalog=ERSSalesComplete;Persist Security Info=True;User ID=ERSComplete;Password=ERS"

        Dim s_SQLCommand As String = ""
        Dim XanFuncLib As New XanLib.XanantecFunctionLibrary

        Dim s_FieldNames(5) As String 'FIXME to 6 if we include TS field
        Dim s_FieldValues(5) As String
        Dim i_FieldTypes(5) As Integer
        Dim s_TableName As String

        'Dim ofi As FileInfo = My.Computer.FileSystem.GetFileInfo(origfile)
        'Dim pfi As FileInfo = My.Computer.FileSystem.GetFileInfo(processedfile)

        s_TableName = "tblLogPdfActivity"

        'Set Field Names
        s_FieldNames(0) = "OriginalFilePath"
        s_FieldNames(1) = "OriginalFolder"
        s_FieldNames(2) = "ProcessedFilePath"
        s_FieldNames(3) = "ProcessedFolder"
        s_FieldNames(4) = "UserName"
        s_FieldNames(5) = "TimeStamp"
        's_FieldNames(6) = "TS"

        'Set Field Type
        i_FieldTypes(0) = SQLTYPETEXT
        i_FieldTypes(1) = SQLTYPETEXT
        i_FieldTypes(2) = SQLTYPETEXT
        i_FieldTypes(3) = SQLTYPETEXT
        i_FieldTypes(4) = SQLTYPETEXT
        i_FieldTypes(5) = SQLTYPETEXT 'FIXME this is wrong
        'i_FieldTypes(6) = SQLTYPETEXT 'FIXME this is wrong

        'Data to log
        s_FieldValues(0) = ofi.Name
        s_FieldValues(1) = ofi.DirectoryName
        s_FieldValues(2) = pfi.Name
        s_FieldValues(3) = pfi.DirectoryName
        s_FieldValues(4) = Environment.UserName
        s_FieldValues(5) = Date.Now

        'Save the info to Sales Complete 
        Try

            Try

                SaleCompleteConn = OpenSqlConnection(connstring)

            Catch ex1 As Exception

                MsgBox("The Sales Complete database is not responding.  Could be a variety of reasons.  The application will now close.  " & vbCrLf & vbCrLf & "Error: " & ex1.Message, MsgBoxStyle.Critical)
                End

            End Try

            s_SQLCommand = "INSERT INTO " & s_TableName & " " & XanFuncLib.GenerateSQLInsertString(s_FieldNames, s_FieldValues, i_FieldTypes)

            'MsgBox(s_SQLCommand)

            cmd = New SqlCommand(s_SQLCommand, SaleCompleteConn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("The Sales Complete database is not responding.  Could be a variety of reasons.  The application will now close.  " & vbCrLf & vbCrLf & "Error: " & ex.Message, MsgBoxStyle.Critical)
            End
        End Try

        Try
            cmd.Dispose()
        Catch ex1 As Exception

        End Try

        Try
            SaleCompleteConn.Close()
        Catch ex1 As Exception

        End Try
    End Sub
    Public Function OpenSqlConnection(ByVal connstring As String) As SqlConnection
        Dim sqlconn As New SqlConnection

        If connstring = "" Then
            MsgBox("You must set the connection string before you do anything else.")
        Else

            Try
                sqlconn.ConnectionString = connstring

                sqlconn.Open()

                If sqlconn.State <> 1 Then

                    MsgBox("Error connecting to the database.  The program will now terminate.  Connection = " & sqlconn.ConnectionString.ToString & " Connection state: " & sqlconn.State & ".", MsgBoxStyle.Critical)
                    End

                End If

            Catch ex As Exception

                MsgBox("Error connecting to the database.  The program will now terminate." & vbCrLf & vbCrLf & "Error: " & ex.Message, MsgBoxStyle.Critical)
                End

            End Try

        End If

        Return sqlconn

    End Function

    Private Sub cmdDeletePageFromPDF_Click(sender As Object, e As EventArgs) Handles cmdDeletePageFromPDF.Click

        'save index 
        Dim index As Int16 = lbxInputFiles.SelectedIndex
        Dim originFile As String = GetTempFileLocation(lbxInputFiles.SelectedItem)

        Dim originFileForArchive As String = originFile.Insert(originFile.LastIndexOf("."), "pagecut_" & Date.Now.Year & Date.Now.Month & Date.Now.Day & Date.Now.Hour & Date.Now.Minute & Date.Now.Second)
        Dim tempfolderdirectory As String = ArchiveDirectory & InputMeta(foldernumber).Foldername 'the archive folder ties back to the incoming folder

        currentfilelist = PopulateFileList(InputMeta(foldernumber).DirectoryName, Me.lbxInputFiles)


        If (index < 0 Or String.IsNullOrEmpty(txtPageNumber.Text)) Then
            MessageBox.Show("Select file and Enter page to remove")
            Return
        End If
        Dim removePageNumber As Integer = txtPageNumber.Text
        selectedfile = currentfilelist(nametype.full, index)


        Dim path As String = GetTempFileLocation(selectedfile)  'record the file position

        Dim destinationFile As String = path.Insert(path.LastIndexOf("."), "___")

        Dim r As New iTextSharp.text.pdf.PdfReader(path)
        'Create our destination file

        If r.NumberOfPages = 1 Or removePageNumber > r.NumberOfPages Then
            MessageBox.Show("Cannot remove this page.")
            lbxInputFiles.SelectedItem = originFile
            Return
        End If

        Using fs As New FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None)
            Using doc As New iTextSharp.text.Document()
                Using w As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                    'Open the desitination for writing
                    doc.Open()
                    Dim totalPages As Integer = r.NumberOfPages
                    Dim page As iTextSharp.text.pdf.PdfImportedPage


                    'Loop through each page that we want to keep
                    For pageNumber As Integer = 1 To totalPages
                        page = w.GetImportedPage(r, pageNumber)

                        If pageNumber = removePageNumber Then
                            'ignore page 
                        Else
                            'Add a new blank page to destination document
                            doc.NewPage()





                            'r.GetPageSize()
                            '  If (page.Width <= page.Height) Then
                            doc.SetPageSize(r.GetPageSize(pageNumber))
                            'doc.SetPageSize(rect)

                            'Extract the given page from our reader and add it directly to the destination PDF
                            w.DirectContent.AddTemplate(w.GetImportedPage(r, pageNumber), 0, 0)

                        End If
                    Next
                    'Close our document

                    doc.Close()
                End Using
            End Using
        End Using



        'reset folders

        '  Dim tempfolderdirectory As String = ArchiveDirectory & InputMeta(foldernumber).Foldername 'the archive folder ties back to the incoming folder

        ' My.Computer.FileSystem.CopyFile(selectedfile, tempfolderdirectory & "\" & originFileForArchive, True)


        My.Computer.FileSystem.DeleteFile(path)
        My.Computer.FileSystem.RenameFile(destinationFile, System.IO.Path.GetFileName(selectedfile))
        '  '  SetupFolders()
        '    restorefolderandnextfile(InputMeta(foldernumber).DirectoryName)
        'lbxInputFiles.SelectedItem = onFile

        lbxInputFiles.SelectedIndex = index
        PDFViewWindow.src = path ' selectedfile

    End Sub

    Private Sub btnRestoreFile_Click(sender As Object, e As EventArgs) Handles btnRestoreFile.Click
        Dim index As Int16 = lbxInputFiles.SelectedIndex

        If (index < 0) Then
            MessageBox.Show("Select file")
            Return
        End If


        Dim result As Integer = MessageBox.Show("Restore file? ", "Restore file? ", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then


            lbxInputFiles.SelectedIndex = 0
            lbxInputFiles.SelectedIndex = index

            'lbxInputFiles_SelectedIndexChanged(sender, e)


        End If





    End Sub


End Class


