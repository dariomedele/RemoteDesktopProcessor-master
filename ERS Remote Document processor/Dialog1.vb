Imports System.Windows.Forms


Public Class Dialog1
    Dim lastinputpath As String = "" 'a place to store the last filepath 


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        'update the folder paths
        Form1.InputDirectory = Me.Tbx_inputfolder.Text
        Form1.OutputDirectory = Me.Tbx_outputfolder.Text
        Form1.ArchiveDirectory = Me.Tbx_archivefolder.Text
        Form1.DuplicateDirectory = Me.Tbx_duplicateFolder.Text
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' set up the dialogue box here

        If My.Computer.FileSystem.DirectoryExists(Form1.InputDirectory) Then Me.Tbx_inputfolder.Text = Form1.InputDirectory
        If My.Computer.FileSystem.DirectoryExists(Form1.OutputDirectory) Then Me.Tbx_outputfolder.Text = Form1.OutputDirectory
        If My.Computer.FileSystem.DirectoryExists(Form1.ArchiveDirectory) Then Me.Tbx_archivefolder.Text = Form1.ArchiveDirectory
        If My.Computer.FileSystem.DirectoryExists(Form1.DuplicateDirectory) Then Me.Tbx_duplicateFolder.Text = Form1.DuplicateDirectory

    End Sub

    Private Sub BtnInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInput.Click, BtnOutput.Click, BtnArchive.Click, btnDuplicate.Click
        'collect a new folder
        Dim folderBrowserDialog1 As New FolderBrowserDialog
        Dim b As Button
        Dim folderstring As String = "incoming"


        'now set up the folder dialog
        b = CType(sender, Button)
        Debug.Print(b.Name)
        Select Case b.Name
            Case Me.BtnArchive.Name
                folderstring = "archive"
            Case Me.BtnOutput.Name
                folderstring = "output"
            Case Me.btnDuplicate.Name
                folderstring = "duplicate"
        End Select


        ' Set the Help text description for the FolderBrowserDialog. 
        folderBrowserDialog1.Description = "Select the directory that you want to use for " & folderstring & " folders"

        ' Allow the user to create New folders via the FolderBrowserDialog. 
        folderBrowserDialog1.ShowNewFolderButton = True

        ' Default to the My Documents folder. 
        If Len(lastinputpath) > 0 Then folderBrowserDialog1.SelectedPath = lastinputpath

        'now get the folder names
        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            lastinputpath = folderBrowserDialog1.SelectedPath & "\" 'record the inputted filepath for next time
            Select Case b.Name
                Case Me.BtnArchive.Name
                    Me.Tbx_archivefolder.Text = folderBrowserDialog1.SelectedPath & "\"
                Case Me.BtnOutput.Name
                    Me.Tbx_outputfolder.Text = folderBrowserDialog1.SelectedPath & "\"
                Case Me.BtnInput.Name
                    Me.Tbx_inputfolder.Text = folderBrowserDialog1.SelectedPath & "\"
                Case Me.btnDuplicate.Name
                    Me.Tbx_duplicateFolder.Text = folderBrowserDialog1.SelectedPath & "\"
            End Select
        End If

    End Sub
End Class
