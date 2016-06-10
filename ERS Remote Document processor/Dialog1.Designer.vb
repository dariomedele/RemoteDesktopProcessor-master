<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogInput = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnInput = New System.Windows.Forms.Button()
        Me.BtnOutput = New System.Windows.Forms.Button()
        Me.BtnArchive = New System.Windows.Forms.Button()
        Me.Tbx_inputfolder = New System.Windows.Forms.TextBox()
        Me.Tbx_outputfolder = New System.Windows.Forms.TextBox()
        Me.Tbx_archivefolder = New System.Windows.Forms.TextBox()
        Me.Tbx_duplicateFolder = New System.Windows.Forms.TextBox()
        Me.btnDuplicate = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(776, 245)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Quit"
        '
        'BtnInput
        '
        Me.BtnInput.Location = New System.Drawing.Point(42, 17)
        Me.BtnInput.Name = "BtnInput"
        Me.BtnInput.Size = New System.Drawing.Size(104, 42)
        Me.BtnInput.TabIndex = 1
        Me.BtnInput.Text = "Input folder"
        Me.BtnInput.UseVisualStyleBackColor = True
        '
        'BtnOutput
        '
        Me.BtnOutput.Location = New System.Drawing.Point(42, 80)
        Me.BtnOutput.Name = "BtnOutput"
        Me.BtnOutput.Size = New System.Drawing.Size(104, 42)
        Me.BtnOutput.TabIndex = 2
        Me.BtnOutput.Text = "Output folder"
        Me.BtnOutput.UseVisualStyleBackColor = True
        '
        'BtnArchive
        '
        Me.BtnArchive.Location = New System.Drawing.Point(42, 141)
        Me.BtnArchive.Name = "BtnArchive"
        Me.BtnArchive.Size = New System.Drawing.Size(104, 42)
        Me.BtnArchive.TabIndex = 3
        Me.BtnArchive.Text = "Archive folder"
        Me.BtnArchive.UseVisualStyleBackColor = True
        '
        'Tbx_inputfolder
        '
        Me.Tbx_inputfolder.Location = New System.Drawing.Point(171, 29)
        Me.Tbx_inputfolder.Name = "Tbx_inputfolder"
        Me.Tbx_inputfolder.Size = New System.Drawing.Size(675, 20)
        Me.Tbx_inputfolder.TabIndex = 4
        '
        'Tbx_outputfolder
        '
        Me.Tbx_outputfolder.Location = New System.Drawing.Point(171, 92)
        Me.Tbx_outputfolder.Name = "Tbx_outputfolder"
        Me.Tbx_outputfolder.Size = New System.Drawing.Size(675, 20)
        Me.Tbx_outputfolder.TabIndex = 5
        '
        'Tbx_archivefolder
        '
        Me.Tbx_archivefolder.Location = New System.Drawing.Point(171, 153)
        Me.Tbx_archivefolder.Name = "Tbx_archivefolder"
        Me.Tbx_archivefolder.Size = New System.Drawing.Size(675, 20)
        Me.Tbx_archivefolder.TabIndex = 6
        '
        'Tbx_duplicateFolder
        '
        Me.Tbx_duplicateFolder.Location = New System.Drawing.Point(171, 212)
        Me.Tbx_duplicateFolder.Name = "Tbx_duplicateFolder"
        Me.Tbx_duplicateFolder.Size = New System.Drawing.Size(675, 20)
        Me.Tbx_duplicateFolder.TabIndex = 8
        '
        'btnDuplicate
        '
        Me.btnDuplicate.Location = New System.Drawing.Point(42, 200)
        Me.btnDuplicate.Name = "btnDuplicate"
        Me.btnDuplicate.Size = New System.Drawing.Size(104, 42)
        Me.btnDuplicate.TabIndex = 7
        Me.btnDuplicate.Text = "Duplicate folder"
        Me.btnDuplicate.UseVisualStyleBackColor = True
        '
        'Dialog1
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(934, 286)
        Me.Controls.Add(Me.Tbx_duplicateFolder)
        Me.Controls.Add(Me.btnDuplicate)
        Me.Controls.Add(Me.Tbx_archivefolder)
        Me.Controls.Add(Me.Tbx_outputfolder)
        Me.Controls.Add(Me.Tbx_inputfolder)
        Me.Controls.Add(Me.BtnArchive)
        Me.Controls.Add(Me.BtnOutput)
        Me.Controls.Add(Me.BtnInput)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Please choose the folders"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialogInput As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnInput As System.Windows.Forms.Button
    Friend WithEvents BtnOutput As System.Windows.Forms.Button
    Friend WithEvents BtnArchive As System.Windows.Forms.Button
    Friend WithEvents Tbx_inputfolder As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_outputfolder As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_archivefolder As System.Windows.Forms.TextBox
    Friend WithEvents Tbx_duplicateFolder As System.Windows.Forms.TextBox
    Friend WithEvents btnDuplicate As System.Windows.Forms.Button

End Class
