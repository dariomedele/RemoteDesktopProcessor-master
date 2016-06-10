<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog2))
        Me.AxAcroPDF_new = New AxAcroPDFLib.AxAcroPDF()
        Me.AxAcroPDF_old = New AxAcroPDFLib.AxAcroPDF()
        Me.lbl_Ivefound = New System.Windows.Forms.Label()
        Me.btn_duplicate = New System.Windows.Forms.Button()
        Me.btn_discardold = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btnCombine = New System.Windows.Forms.Button()
        CType(Me.AxAcroPDF_new, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF_old, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxAcroPDF_new
        '
        Me.AxAcroPDF_new.Enabled = True
        Me.AxAcroPDF_new.Location = New System.Drawing.Point(2, 132)
        Me.AxAcroPDF_new.Name = "AxAcroPDF_new"
        Me.AxAcroPDF_new.OcxState = CType(resources.GetObject("AxAcroPDF_new.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF_new.Size = New System.Drawing.Size(574, 370)
        Me.AxAcroPDF_new.TabIndex = 1
        '
        'AxAcroPDF_old
        '
        Me.AxAcroPDF_old.Enabled = True
        Me.AxAcroPDF_old.Location = New System.Drawing.Point(592, 132)
        Me.AxAcroPDF_old.Name = "AxAcroPDF_old"
        Me.AxAcroPDF_old.OcxState = CType(resources.GetObject("AxAcroPDF_old.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF_old.Size = New System.Drawing.Size(574, 370)
        Me.AxAcroPDF_old.TabIndex = 2
        '
        'lbl_Ivefound
        '
        Me.lbl_Ivefound.AutoSize = True
        Me.lbl_Ivefound.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Ivefound.Location = New System.Drawing.Point(24, 9)
        Me.lbl_Ivefound.Name = "lbl_Ivefound"
        Me.lbl_Ivefound.Size = New System.Drawing.Size(578, 24)
        Me.lbl_Ivefound.TabIndex = 3
        Me.lbl_Ivefound.Text = "I've found this file already in the repository.  What do you want to do?"
        '
        'btn_duplicate
        '
        Me.btn_duplicate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_duplicate.Location = New System.Drawing.Point(118, 69)
        Me.btn_duplicate.Name = "btn_duplicate"
        Me.btn_duplicate.Size = New System.Drawing.Size(360, 39)
        Me.btn_duplicate.TabIndex = 4
        Me.btn_duplicate.Text = "This new one is a duplicate"
        Me.btn_duplicate.UseVisualStyleBackColor = True
        '
        'btn_discardold
        '
        Me.btn_discardold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_discardold.Location = New System.Drawing.Point(700, 69)
        Me.btn_discardold.Name = "btn_discardold"
        Me.btn_discardold.Size = New System.Drawing.Size(360, 39)
        Me.btn_discardold.TabIndex = 5
        Me.btn_discardold.Text = "Discard this old one"
        Me.btn_discardold.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.Location = New System.Drawing.Point(2, 508)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(1164, 39)
        Me.btn_cancel.TabIndex = 6
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btnCombine
        '
        Me.btnCombine.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCombine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnCombine.Location = New System.Drawing.Point(496, 69)
        Me.btnCombine.Name = "btnCombine"
        Me.btnCombine.Size = New System.Drawing.Size(185, 39)
        Me.btnCombine.TabIndex = 7
        Me.btnCombine.Text = "Combine them"
        Me.btnCombine.UseVisualStyleBackColor = False
        '
        'Dialog2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 557)
        Me.Controls.Add(Me.btnCombine)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_discardold)
        Me.Controls.Add(Me.btn_duplicate)
        Me.Controls.Add(Me.lbl_Ivefound)
        Me.Controls.Add(Me.AxAcroPDF_old)
        Me.Controls.Add(Me.AxAcroPDF_new)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog2"
        CType(Me.AxAcroPDF_new, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF_old, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxAcroPDF_new As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents AxAcroPDF_old As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents lbl_Ivefound As System.Windows.Forms.Label
    Friend WithEvents btn_duplicate As System.Windows.Forms.Button
    Friend WithEvents btn_discardold As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btnCombine As System.Windows.Forms.Button

End Class
