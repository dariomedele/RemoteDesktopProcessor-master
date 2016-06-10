Imports System.Windows.Forms
Imports System.IO
Imports Scripting

Public Class Dialog2
    Private Const maxTime As Long = 20

    'Private WithEvents _PDFCreator As PDFCreator.clsPDFCreator
    'Private pErr As PDFCreator.clsPDFCreatorError
    Dim pdfs As New pdfforge.PDF.PDF

    Private Sub Dialog2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'when the form opens, put the two files into the pdf viewer controls
        AxAcroPDF_new.src = Form1.selectedfile
        AxAcroPDF_old.src = Form1.destinationfile
    End Sub

    Private Sub btn_duplicate_Click(sender As System.Object, e As System.EventArgs) Handles btn_duplicate.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btn_discardold_Click(sender As System.Object, e As System.EventArgs) Handles btn_discardold.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btn_cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnCombine_Click(sender As System.Object, e As System.EventArgs) Handles btnCombine.Click
        'combine the files and then return a 'no' which will move the duplicate to the duplicates
        Dim fso As New FileSystemObject
        Dim tempfi As FileInfo ', fitemp As FileInfo, tempfile As Scripting.File

        Dim combo(1) As String

        combo(0) = Form1.selectedfile
        combo(1) = Form1.destinationfile

        tempfi = New FileInfo(Form1.selectedfile) 'parse the source file information to be used with the temporary file

        'disconnect the existing file from the pdf viewer control
        AxAcroPDF_old.src = Form1.selectedfile

        Try
            pdfs.MergePDFFiles(combo, tempfi.DirectoryName & "\" & "tempcombine.pdf", True) 'combine the file into a temporary file
            My.Computer.FileSystem.MoveFile(tempfi.DirectoryName & "\" & "tempcombine.pdf", combo(1), True)

        Catch ex As Exception
            MsgBox("Oops this isn't good. Tell Richard : " & ex.ToString)
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class
