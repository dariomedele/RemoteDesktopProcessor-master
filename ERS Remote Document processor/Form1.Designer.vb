<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnFolder1 = New System.Windows.Forms.Button()
        Me.btnFolder2 = New System.Windows.Forms.Button()
        Me.btnFolder3 = New System.Windows.Forms.Button()
        Me.lbxInputFiles = New System.Windows.Forms.ListBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.PDFViewWindow = New AxAcroPDFLib.AxAcroPDF()
        Me.ERSLogo = New System.Windows.Forms.PictureBox()
        Me.btnFolder4 = New System.Windows.Forms.Button()
        Me.btnFolder8 = New System.Windows.Forms.Button()
        Me.btnFolder7 = New System.Windows.Forms.Button()
        Me.btnFolder6 = New System.Windows.Forms.Button()
        Me.btnFolder5 = New System.Windows.Forms.Button()
        Me.lbxOutputFiles = New System.Windows.Forms.ListBox()
        Me.CBoxDocuments = New System.Windows.Forms.ComboBox()
        Me.TbxMeta1 = New System.Windows.Forms.TextBox()
        Me.LblMeta1 = New System.Windows.Forms.Label()
        Me.LblMeta2 = New System.Windows.Forms.Label()
        Me.TbxMeta2 = New System.Windows.Forms.TextBox()
        Me.LblMeta3 = New System.Windows.Forms.Label()
        Me.TbxMeta3 = New System.Windows.Forms.TextBox()
        Me.LblMeta4 = New System.Windows.Forms.Label()
        Me.TbxMeta4 = New System.Windows.Forms.TextBox()
        Me.LblMeta5 = New System.Windows.Forms.Label()
        Me.TbxMeta5 = New System.Windows.Forms.TextBox()
        Me.LblMeta6 = New System.Windows.Forms.Label()
        Me.TbxMeta6 = New System.Windows.Forms.TextBox()
        Me.DtpMetadata = New System.Windows.Forms.DateTimePicker()
        Me.LblPDFBox = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnAddFiles = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblFileName = New System.Windows.Forms.Label()
        Me.Gbx_folders = New System.Windows.Forms.GroupBox()
        Me.btnFolder13 = New System.Windows.Forms.Button()
        Me.btnFolder12 = New System.Windows.Forms.Button()
        Me.btnFolder11 = New System.Windows.Forms.Button()
        Me.btnFolder10 = New System.Windows.Forms.Button()
        Me.btnFolder9 = New System.Windows.Forms.Button()
        Me.Gbx_metadata = New System.Windows.Forms.GroupBox()
        Me.TbxMeta8 = New System.Windows.Forms.TextBox()
        Me.LblMeta8 = New System.Windows.Forms.Label()
        Me.TbxMeta7 = New System.Windows.Forms.TextBox()
        Me.LblMeta7 = New System.Windows.Forms.Label()
        Me.LblDocumentType = New System.Windows.Forms.Label()
        Me.Lblversion = New System.Windows.Forms.Label()
        Me.BtnDuplicate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdDeletePageFromPDF = New System.Windows.Forms.Button()
        Me.txtPageNumber = New System.Windows.Forms.TextBox()
        Me.btnRestoreFile = New System.Windows.Forms.Button()
        CType(Me.PDFViewWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ERSLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gbx_folders.SuspendLayout()
        Me.Gbx_metadata.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFolder1
        '
        Me.btnFolder1.BackColor = System.Drawing.Color.LightGreen
        Me.btnFolder1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder1.Location = New System.Drawing.Point(6, 14)
        Me.btnFolder1.Name = "btnFolder1"
        Me.btnFolder1.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder1.TabIndex = 0
        Me.btnFolder1.Text = "unused folder"
        Me.btnFolder1.UseVisualStyleBackColor = False
        '
        'btnFolder2
        '
        Me.btnFolder2.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder2.Location = New System.Drawing.Point(100, 14)
        Me.btnFolder2.Name = "btnFolder2"
        Me.btnFolder2.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder2.TabIndex = 1
        Me.btnFolder2.Text = "unused folder"
        Me.btnFolder2.UseVisualStyleBackColor = True
        '
        'btnFolder3
        '
        Me.btnFolder3.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder3.Location = New System.Drawing.Point(194, 14)
        Me.btnFolder3.Name = "btnFolder3"
        Me.btnFolder3.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder3.TabIndex = 2
        Me.btnFolder3.Text = "unused folder"
        Me.btnFolder3.UseVisualStyleBackColor = True
        '
        'lbxInputFiles
        '
        Me.lbxInputFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbxInputFiles.FormattingEnabled = True
        Me.lbxInputFiles.Location = New System.Drawing.Point(13, 80)
        Me.lbxInputFiles.Name = "lbxInputFiles"
        Me.lbxInputFiles.Size = New System.Drawing.Size(150, 485)
        Me.lbxInputFiles.TabIndex = 3
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(1176, 638)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(88, 28)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PDFViewWindow
        '
        Me.PDFViewWindow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PDFViewWindow.Enabled = True
        Me.PDFViewWindow.Location = New System.Drawing.Point(178, 80)
        Me.PDFViewWindow.Name = "PDFViewWindow"
        Me.PDFViewWindow.OcxState = CType(resources.GetObject("PDFViewWindow.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PDFViewWindow.Size = New System.Drawing.Size(930, 483)
        Me.PDFViewWindow.TabIndex = 5
        '
        'ERSLogo
        '
        Me.ERSLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ERSLogo.Image = Global.WindowsApplication1.My.Resources.Resources.ERS_Logo_white_bkgd
        Me.ERSLogo.Location = New System.Drawing.Point(13, 600)
        Me.ERSLogo.Name = "ERSLogo"
        Me.ERSLogo.Size = New System.Drawing.Size(150, 72)
        Me.ERSLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ERSLogo.TabIndex = 6
        Me.ERSLogo.TabStop = False
        '
        'btnFolder4
        '
        Me.btnFolder4.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder4.Location = New System.Drawing.Point(288, 14)
        Me.btnFolder4.Name = "btnFolder4"
        Me.btnFolder4.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder4.TabIndex = 7
        Me.btnFolder4.Text = "unused folder"
        Me.btnFolder4.UseVisualStyleBackColor = True
        '
        'btnFolder8
        '
        Me.btnFolder8.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder8.Location = New System.Drawing.Point(664, 14)
        Me.btnFolder8.Name = "btnFolder8"
        Me.btnFolder8.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder8.TabIndex = 11
        Me.btnFolder8.Text = "unused folder"
        Me.btnFolder8.UseVisualStyleBackColor = True
        '
        'btnFolder7
        '
        Me.btnFolder7.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder7.Location = New System.Drawing.Point(570, 14)
        Me.btnFolder7.Name = "btnFolder7"
        Me.btnFolder7.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder7.TabIndex = 10
        Me.btnFolder7.Text = "unused folder"
        Me.btnFolder7.UseVisualStyleBackColor = True
        '
        'btnFolder6
        '
        Me.btnFolder6.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder6.Location = New System.Drawing.Point(476, 14)
        Me.btnFolder6.Name = "btnFolder6"
        Me.btnFolder6.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder6.TabIndex = 9
        Me.btnFolder6.Text = "unused folder"
        Me.btnFolder6.UseVisualStyleBackColor = True
        '
        'btnFolder5
        '
        Me.btnFolder5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder5.Location = New System.Drawing.Point(382, 14)
        Me.btnFolder5.Name = "btnFolder5"
        Me.btnFolder5.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder5.TabIndex = 8
        Me.btnFolder5.Text = "unused folder"
        Me.btnFolder5.UseVisualStyleBackColor = True
        '
        'lbxOutputFiles
        '
        Me.lbxOutputFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxOutputFiles.FormattingEnabled = True
        Me.lbxOutputFiles.HorizontalScrollbar = True
        Me.lbxOutputFiles.Location = New System.Drawing.Point(1114, 206)
        Me.lbxOutputFiles.Name = "lbxOutputFiles"
        Me.lbxOutputFiles.Size = New System.Drawing.Size(150, 355)
        Me.lbxOutputFiles.TabIndex = 12
        '
        'CBoxDocuments
        '
        Me.CBoxDocuments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoxDocuments.FormattingEnabled = True
        Me.CBoxDocuments.Location = New System.Drawing.Point(19, 58)
        Me.CBoxDocuments.Name = "CBoxDocuments"
        Me.CBoxDocuments.Size = New System.Drawing.Size(105, 21)
        Me.CBoxDocuments.TabIndex = 16
        '
        'TbxMeta1
        '
        Me.TbxMeta1.Location = New System.Drawing.Point(134, 55)
        Me.TbxMeta1.Name = "TbxMeta1"
        Me.TbxMeta1.Size = New System.Drawing.Size(87, 23)
        Me.TbxMeta1.TabIndex = 17
        Me.TbxMeta1.Visible = False
        '
        'LblMeta1
        '
        Me.LblMeta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblMeta1.Location = New System.Drawing.Point(131, 29)
        Me.LblMeta1.Name = "LblMeta1"
        Me.LblMeta1.Size = New System.Drawing.Size(90, 20)
        Me.LblMeta1.TabIndex = 23
        Me.LblMeta1.Text = "Label11234"
        Me.LblMeta1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMeta2
        '
        Me.LblMeta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta2.Location = New System.Drawing.Point(229, 29)
        Me.LblMeta2.Name = "LblMeta2"
        Me.LblMeta2.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta2.TabIndex = 25
        Me.LblMeta2.Text = "Label11234"
        Me.LblMeta2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta2
        '
        Me.TbxMeta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta2.Location = New System.Drawing.Point(229, 58)
        Me.TbxMeta2.Name = "TbxMeta2"
        Me.TbxMeta2.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta2.TabIndex = 24
        '
        'LblMeta3
        '
        Me.LblMeta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta3.Location = New System.Drawing.Point(338, 29)
        Me.LblMeta3.Name = "LblMeta3"
        Me.LblMeta3.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta3.TabIndex = 27
        Me.LblMeta3.Text = "Label11234"
        Me.LblMeta3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta3
        '
        Me.TbxMeta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta3.Location = New System.Drawing.Point(338, 58)
        Me.TbxMeta3.Name = "TbxMeta3"
        Me.TbxMeta3.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta3.TabIndex = 26
        '
        'LblMeta4
        '
        Me.LblMeta4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta4.Location = New System.Drawing.Point(450, 29)
        Me.LblMeta4.Name = "LblMeta4"
        Me.LblMeta4.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta4.TabIndex = 29
        Me.LblMeta4.Text = "Label11234"
        Me.LblMeta4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta4
        '
        Me.TbxMeta4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta4.Location = New System.Drawing.Point(450, 58)
        Me.TbxMeta4.Name = "TbxMeta4"
        Me.TbxMeta4.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta4.TabIndex = 28
        '
        'LblMeta5
        '
        Me.LblMeta5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta5.Location = New System.Drawing.Point(564, 29)
        Me.LblMeta5.Name = "LblMeta5"
        Me.LblMeta5.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta5.TabIndex = 31
        Me.LblMeta5.Text = "Label11234"
        Me.LblMeta5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta5
        '
        Me.TbxMeta5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta5.Location = New System.Drawing.Point(564, 58)
        Me.TbxMeta5.Name = "TbxMeta5"
        Me.TbxMeta5.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta5.TabIndex = 30
        '
        'LblMeta6
        '
        Me.LblMeta6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta6.Location = New System.Drawing.Point(678, 29)
        Me.LblMeta6.Name = "LblMeta6"
        Me.LblMeta6.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta6.TabIndex = 33
        Me.LblMeta6.Text = "Label11234"
        Me.LblMeta6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta6
        '
        Me.TbxMeta6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta6.Location = New System.Drawing.Point(678, 58)
        Me.TbxMeta6.Name = "TbxMeta6"
        Me.TbxMeta6.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta6.TabIndex = 32
        '
        'DtpMetadata
        '
        Me.DtpMetadata.AllowDrop = True
        Me.DtpMetadata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpMetadata.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpMetadata.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DtpMetadata.Location = New System.Drawing.Point(141, 59)
        Me.DtpMetadata.Name = "DtpMetadata"
        Me.DtpMetadata.Size = New System.Drawing.Size(80, 20)
        Me.DtpMetadata.TabIndex = 34
        '
        'LblPDFBox
        '
        Me.LblPDFBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblPDFBox.Location = New System.Drawing.Point(177, 79)
        Me.LblPDFBox.Name = "LblPDFBox"
        Me.LblPDFBox.Size = New System.Drawing.Size(897, 485)
        Me.LblPDFBox.TabIndex = 35
        Me.LblPDFBox.Text = "Label1"
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Location = New System.Drawing.Point(1176, 567)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(88, 28)
        Me.BtnPrint.TabIndex = 36
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'btnAddFiles
        '
        Me.btnAddFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddFiles.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddFiles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddFiles.Location = New System.Drawing.Point(1114, 165)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Size = New System.Drawing.Size(150, 32)
        Me.btnAddFiles.TabIndex = 37
        Me.btnAddFiles.Text = "Correct a file"
        Me.btnAddFiles.UseVisualStyleBackColor = True
        '
        'LblFileName
        '
        Me.LblFileName.BackColor = System.Drawing.Color.Transparent
        Me.LblFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFileName.Location = New System.Drawing.Point(422, -1)
        Me.LblFileName.Name = "LblFileName"
        Me.LblFileName.Size = New System.Drawing.Size(372, 34)
        Me.LblFileName.TabIndex = 38
        Me.LblFileName.Text = "File:"
        Me.LblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Gbx_folders
        '
        Me.Gbx_folders.Controls.Add(Me.btnFolder13)
        Me.Gbx_folders.Controls.Add(Me.btnFolder12)
        Me.Gbx_folders.Controls.Add(Me.btnFolder11)
        Me.Gbx_folders.Controls.Add(Me.btnFolder10)
        Me.Gbx_folders.Controls.Add(Me.btnFolder9)
        Me.Gbx_folders.Controls.Add(Me.btnFolder8)
        Me.Gbx_folders.Controls.Add(Me.btnFolder7)
        Me.Gbx_folders.Controls.Add(Me.btnFolder6)
        Me.Gbx_folders.Controls.Add(Me.btnFolder5)
        Me.Gbx_folders.Controls.Add(Me.btnFolder4)
        Me.Gbx_folders.Controls.Add(Me.btnFolder3)
        Me.Gbx_folders.Controls.Add(Me.btnFolder2)
        Me.Gbx_folders.Controls.Add(Me.btnFolder1)
        Me.Gbx_folders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gbx_folders.Location = New System.Drawing.Point(6, 22)
        Me.Gbx_folders.Name = "Gbx_folders"
        Me.Gbx_folders.Size = New System.Drawing.Size(1276, 51)
        Me.Gbx_folders.TabIndex = 39
        Me.Gbx_folders.TabStop = False
        Me.Gbx_folders.Text = "Incoming document folders"
        '
        'btnFolder13
        '
        Me.btnFolder13.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder13.Location = New System.Drawing.Point(1134, 14)
        Me.btnFolder13.Name = "btnFolder13"
        Me.btnFolder13.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder13.TabIndex = 16
        Me.btnFolder13.Text = "unused folder"
        Me.btnFolder13.UseVisualStyleBackColor = True
        '
        'btnFolder12
        '
        Me.btnFolder12.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder12.Location = New System.Drawing.Point(1040, 14)
        Me.btnFolder12.Name = "btnFolder12"
        Me.btnFolder12.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder12.TabIndex = 15
        Me.btnFolder12.Text = "unused folder"
        Me.btnFolder12.UseVisualStyleBackColor = True
        '
        'btnFolder11
        '
        Me.btnFolder11.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder11.Location = New System.Drawing.Point(946, 14)
        Me.btnFolder11.Name = "btnFolder11"
        Me.btnFolder11.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder11.TabIndex = 14
        Me.btnFolder11.Text = "unused folder"
        Me.btnFolder11.UseVisualStyleBackColor = True
        '
        'btnFolder10
        '
        Me.btnFolder10.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder10.Location = New System.Drawing.Point(852, 14)
        Me.btnFolder10.Name = "btnFolder10"
        Me.btnFolder10.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder10.TabIndex = 13
        Me.btnFolder10.Text = "unused folder"
        Me.btnFolder10.UseVisualStyleBackColor = True
        '
        'btnFolder9
        '
        Me.btnFolder9.BackColor = System.Drawing.SystemColors.Control
        Me.btnFolder9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFolder9.Location = New System.Drawing.Point(758, 14)
        Me.btnFolder9.Name = "btnFolder9"
        Me.btnFolder9.Size = New System.Drawing.Size(88, 32)
        Me.btnFolder9.TabIndex = 12
        Me.btnFolder9.Text = "unused folder"
        Me.btnFolder9.UseVisualStyleBackColor = True
        '
        'Gbx_metadata
        '
        Me.Gbx_metadata.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Gbx_metadata.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta8)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta8)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta7)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta7)
        Me.Gbx_metadata.Controls.Add(Me.LblDocumentType)
        Me.Gbx_metadata.Controls.Add(Me.DtpMetadata)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta6)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta6)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta5)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta5)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta4)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta4)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta3)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta3)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta2)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta2)
        Me.Gbx_metadata.Controls.Add(Me.LblMeta1)
        Me.Gbx_metadata.Controls.Add(Me.TbxMeta1)
        Me.Gbx_metadata.Controls.Add(Me.CBoxDocuments)
        Me.Gbx_metadata.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gbx_metadata.Location = New System.Drawing.Point(176, 569)
        Me.Gbx_metadata.Name = "Gbx_metadata"
        Me.Gbx_metadata.Size = New System.Drawing.Size(1012, 102)
        Me.Gbx_metadata.TabIndex = 40
        Me.Gbx_metadata.TabStop = False
        Me.Gbx_metadata.Text = "Please enter document information"
        '
        'TbxMeta8
        '
        Me.TbxMeta8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta8.Location = New System.Drawing.Point(896, 58)
        Me.TbxMeta8.Name = "TbxMeta8"
        Me.TbxMeta8.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta8.TabIndex = 39
        '
        'LblMeta8
        '
        Me.LblMeta8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta8.Location = New System.Drawing.Point(879, 29)
        Me.LblMeta8.Name = "LblMeta8"
        Me.LblMeta8.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta8.TabIndex = 38
        Me.LblMeta8.Text = "Label11234"
        Me.LblMeta8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbxMeta7
        '
        Me.TbxMeta7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxMeta7.Location = New System.Drawing.Point(787, 58)
        Me.TbxMeta7.Name = "TbxMeta7"
        Me.TbxMeta7.Size = New System.Drawing.Size(103, 20)
        Me.TbxMeta7.TabIndex = 36
        '
        'LblMeta7
        '
        Me.LblMeta7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeta7.Location = New System.Drawing.Point(787, 29)
        Me.LblMeta7.Name = "LblMeta7"
        Me.LblMeta7.Size = New System.Drawing.Size(103, 20)
        Me.LblMeta7.TabIndex = 37
        Me.LblMeta7.Text = "Label11234"
        Me.LblMeta7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDocumentType
        '
        Me.LblDocumentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDocumentType.Location = New System.Drawing.Point(16, 29)
        Me.LblDocumentType.Name = "LblDocumentType"
        Me.LblDocumentType.Size = New System.Drawing.Size(108, 20)
        Me.LblDocumentType.TabIndex = 35
        Me.LblDocumentType.Text = "Document Type"
        Me.LblDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lblversion
        '
        Me.Lblversion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lblversion.AutoSize = True
        Me.Lblversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblversion.Location = New System.Drawing.Point(16, 575)
        Me.Lblversion.Name = "Lblversion"
        Me.Lblversion.Size = New System.Drawing.Size(41, 13)
        Me.Lblversion.TabIndex = 41
        Me.Lblversion.Text = "version"
        '
        'BtnDuplicate
        '
        Me.BtnDuplicate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDuplicate.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnDuplicate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDuplicate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnDuplicate.Location = New System.Drawing.Point(1176, 601)
        Me.BtnDuplicate.Name = "BtnDuplicate"
        Me.BtnDuplicate.Size = New System.Drawing.Size(88, 28)
        Me.BtnDuplicate.TabIndex = 42
        Me.BtnDuplicate.Text = "Dupe"
        Me.BtnDuplicate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdDeletePageFromPDF)
        Me.GroupBox1.Controls.Add(Me.txtPageNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(1114, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 43)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Page"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Page #:"
        '
        'cmdDeletePageFromPDF
        '
        Me.cmdDeletePageFromPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeletePageFromPDF.Location = New System.Drawing.Point(97, 14)
        Me.cmdDeletePageFromPDF.Name = "cmdDeletePageFromPDF"
        Me.cmdDeletePageFromPDF.Size = New System.Drawing.Size(47, 23)
        Me.cmdDeletePageFromPDF.TabIndex = 1
        Me.cmdDeletePageFromPDF.Text = "Delete"
        Me.cmdDeletePageFromPDF.UseVisualStyleBackColor = True
        '
        'txtPageNumber
        '
        Me.txtPageNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPageNumber.Location = New System.Drawing.Point(54, 17)
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(37, 20)
        Me.txtPageNumber.TabIndex = 0
        '
        'btnRestoreFile
        '
        Me.btnRestoreFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestoreFile.Location = New System.Drawing.Point(1115, 130)
        Me.btnRestoreFile.Name = "btnRestoreFile"
        Me.btnRestoreFile.Size = New System.Drawing.Size(149, 28)
        Me.btnRestoreFile.TabIndex = 44
        Me.btnRestoreFile.Text = "Restore from Archive"
        Me.btnRestoreFile.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 682)
        Me.Controls.Add(Me.btnRestoreFile)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnDuplicate)
        Me.Controls.Add(Me.Lblversion)
        Me.Controls.Add(Me.btnAddFiles)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.lbxOutputFiles)
        Me.Controls.Add(Me.ERSLogo)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.lbxInputFiles)
        Me.Controls.Add(Me.Gbx_folders)
        Me.Controls.Add(Me.LblFileName)
        Me.Controls.Add(Me.Gbx_metadata)
        Me.Controls.Add(Me.PDFViewWindow)
        Me.Controls.Add(Me.LblPDFBox)
        Me.Name = "Form1"
        Me.Text = "Main Window"
        CType(Me.PDFViewWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ERSLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gbx_folders.ResumeLayout(False)
        Me.Gbx_metadata.ResumeLayout(False)
        Me.Gbx_metadata.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFolder1 As System.Windows.Forms.Button
    Friend WithEvents btnFolder2 As System.Windows.Forms.Button
    Friend WithEvents btnFolder3 As System.Windows.Forms.Button
    Friend WithEvents lbxInputFiles As System.Windows.Forms.ListBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents PDFViewWindow As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents ERSLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnFolder4 As System.Windows.Forms.Button
    Friend WithEvents btnFolder8 As System.Windows.Forms.Button
    Friend WithEvents btnFolder7 As System.Windows.Forms.Button
    Friend WithEvents btnFolder6 As System.Windows.Forms.Button
    Friend WithEvents btnFolder5 As System.Windows.Forms.Button
    Friend WithEvents lbxOutputFiles As System.Windows.Forms.ListBox
    Friend WithEvents CBoxDocuments As System.Windows.Forms.ComboBox
    Friend WithEvents TbxMeta1 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta1 As System.Windows.Forms.Label
    Friend WithEvents LblMeta2 As System.Windows.Forms.Label
    Friend WithEvents TbxMeta2 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta3 As System.Windows.Forms.Label
    Friend WithEvents TbxMeta3 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta4 As System.Windows.Forms.Label
    Friend WithEvents TbxMeta4 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta5 As System.Windows.Forms.Label
    Friend WithEvents TbxMeta5 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta6 As System.Windows.Forms.Label
    Friend WithEvents TbxMeta6 As System.Windows.Forms.TextBox
    Friend WithEvents DtpMetadata As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblPDFBox As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents btnAddFiles As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LblFileName As System.Windows.Forms.Label
    Friend WithEvents Gbx_folders As System.Windows.Forms.GroupBox
    Friend WithEvents Gbx_metadata As System.Windows.Forms.GroupBox
    Friend WithEvents LblDocumentType As System.Windows.Forms.Label
    Friend WithEvents TbxMeta7 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta7 As System.Windows.Forms.Label
    Friend WithEvents Lblversion As System.Windows.Forms.Label
    Friend WithEvents BtnDuplicate As System.Windows.Forms.Button
    Friend WithEvents TbxMeta8 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeta8 As System.Windows.Forms.Label
    Friend WithEvents btnFolder10 As System.Windows.Forms.Button
    Friend WithEvents btnFolder9 As System.Windows.Forms.Button
    Friend WithEvents btnFolder13 As System.Windows.Forms.Button
    Friend WithEvents btnFolder12 As System.Windows.Forms.Button
    Friend WithEvents btnFolder11 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdDeletePageFromPDF As Button
    Friend WithEvents txtPageNumber As TextBox
    Friend WithEvents btnRestoreFile As Button
End Class
