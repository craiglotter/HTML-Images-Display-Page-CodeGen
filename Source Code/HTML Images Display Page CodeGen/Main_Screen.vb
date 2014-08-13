Imports Microsoft.Win32
Imports System.IO

Public Class Main_Screen
    Inherits System.Windows.Forms.Form

    Dim WithEvents Worker1 As Worker
    Public Delegate Sub WorkerhHandler(ByVal Result As String)
    Public Delegate Sub WorkerProgresshHandler(ByVal filesrenamed As Long, ByVal currentfilename As String, ByVal totalfiles As Long)

    Private splash_loader As Splash_Screen
    Public dataloaded As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Worker1 = New Worker
        AddHandler Worker1.WorkerComplete, AddressOf WorkerHandler
        AddHandler Worker1.WorkerProgress, AddressOf WorkerProgressHandler
    End Sub

    Public Sub New(ByVal splash As Splash_Screen)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        splash_loader = splash
        Worker1 = New Worker
        AddHandler Worker1.WorkerComplete, AddressOf WorkerHandler
        AddHandler Worker1.WorkerProgress, AddressOf WorkerProgressHandler
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents label22 As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents filefoldertxt As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents numberofcolumnstxt As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents WhiteCoverBlock As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents downloadpathtxt As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents imagewidthtxt As System.Windows.Forms.TextBox
    Friend WithEvents imageheighttxt As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main_Screen))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.downloadpathtxt = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.numberofcolumnstxt = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.filefoldertxt = New System.Windows.Forms.TextBox
        Me.label22 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.WhiteCoverBlock = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label16 = New System.Windows.Forms.Label
        Me.imagewidthtxt = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.imageheighttxt = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.imageheighttxt)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.imagewidthtxt)
        Me.Panel1.Controls.Add(Me.downloadpathtxt)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.numberofcolumnstxt)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.filefoldertxt)
        Me.Panel1.Controls.Add(Me.label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.WhiteCoverBlock)
        Me.Panel1.Location = New System.Drawing.Point(8, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 240)
        Me.Panel1.TabIndex = 11
        '
        'downloadpathtxt
        '
        Me.downloadpathtxt.BackColor = System.Drawing.Color.Azure
        Me.downloadpathtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.downloadpathtxt.ForeColor = System.Drawing.Color.Black
        Me.downloadpathtxt.Location = New System.Drawing.Point(16, 64)
        Me.downloadpathtxt.Name = "downloadpathtxt"
        Me.downloadpathtxt.Size = New System.Drawing.Size(200, 20)
        Me.downloadpathtxt.TabIndex = 59
        Me.downloadpathtxt.Text = "Eg: 2006/Images/"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 8)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "IMAGES PATH"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(384, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 16)
        Me.CheckBox1.TabIndex = 57
        Me.CheckBox1.Text = "RECURSIVE"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(224, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 8)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "COLUMNS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'numberofcolumnstxt
        '
        Me.numberofcolumnstxt.BackColor = System.Drawing.Color.Azure
        Me.numberofcolumnstxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numberofcolumnstxt.ForeColor = System.Drawing.Color.Black
        Me.numberofcolumnstxt.Location = New System.Drawing.Point(224, 64)
        Me.numberofcolumnstxt.Name = "numberofcolumnstxt"
        Me.numberofcolumnstxt.Size = New System.Drawing.Size(40, 20)
        Me.numberofcolumnstxt.TabIndex = 55
        Me.numberofcolumnstxt.Text = "1"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Orange
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(16, 200)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 23)
        Me.Button3.TabIndex = 54
        Me.Button3.Text = "Proceed"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkOrange
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(384, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 20)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "BROWSE"
        '
        'filefoldertxt
        '
        Me.filefoldertxt.BackColor = System.Drawing.Color.Azure
        Me.filefoldertxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.filefoldertxt.ForeColor = System.Drawing.Color.Black
        Me.filefoldertxt.Location = New System.Drawing.Point(16, 16)
        Me.filefoldertxt.Name = "filefoldertxt"
        Me.filefoldertxt.ReadOnly = True
        Me.filefoldertxt.Size = New System.Drawing.Size(360, 20)
        Me.filefoldertxt.TabIndex = 48
        Me.filefoldertxt.Text = ""
        '
        'label22
        '
        Me.label22.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.label22.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(128, 152)
        Me.label22.Name = "label22"
        Me.label22.ReadOnly = True
        Me.label22.Size = New System.Drawing.Size(304, 13)
        Me.label22.TabIndex = 46
        Me.label22.Text = ""
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(24, 152)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(416, 16)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "Current Input:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(128, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(248, 16)
        Me.Label19.TabIndex = 41
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(24, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(392, 16)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Analysis End:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(128, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(248, 16)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "0"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(128, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(248, 16)
        Me.Label11.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(128, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(248, 16)
        Me.Label10.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(152, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Resting..."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(24, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(376, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Gallery Files:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(376, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Analysis Start:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(376, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Program Launched:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label1.Location = New System.Drawing.Point(360, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Waiting"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.ForeColor = System.Drawing.Color.Black
        Me.PictureBox5.Location = New System.Drawing.Point(336, 200)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.ForeColor = System.Drawing.Color.Black
        Me.PictureBox4.Location = New System.Drawing.Point(320, 200)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 25
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.ForeColor = System.Drawing.Color.Black
        Me.PictureBox3.Location = New System.Drawing.Point(304, 200)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 24
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.ForeColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(288, 200)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.ForeColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(272, 200)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(144, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 32)
        Me.Label2.TabIndex = 28
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(16, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(144, 8)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "FOLDER TO PROCESS"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'WhiteCoverBlock
        '
        Me.WhiteCoverBlock.ForeColor = System.Drawing.Color.Black
        Me.WhiteCoverBlock.Location = New System.Drawing.Point(16, 192)
        Me.WhiteCoverBlock.Name = "WhiteCoverBlock"
        Me.WhiteCoverBlock.Size = New System.Drawing.Size(432, 56)
        Me.WhiteCoverBlock.TabIndex = 58
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(352, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label8, "Current System Time")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ContextMenu1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Resting..."
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Display Main Screen"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Exit Application"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select the folder to scan"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(360, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 8)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "BUILD 20060307.1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Button4.Location = New System.Drawing.Point(376, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 16)
        Me.Button4.TabIndex = 59
        Me.Button4.Text = "KILL PROCESSES"
        Me.Button4.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(320, 40)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Select the folder you wish to parse, enter your required inputs and hit the Proce" & _
        "ed button to continue."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "*.*|All text files"
        Me.OpenFileDialog1.Title = "Select input file"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "htm"
        Me.SaveFileDialog1.FileName = "output.htm"
        Me.SaveFileDialog1.Filter = "HTML files|*.html|All files|*.*"
        Me.SaveFileDialog1.Title = "Select the file to save code to"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(272, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 8)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "WIDTH"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'imagewidthtxt
        '
        Me.imagewidthtxt.BackColor = System.Drawing.Color.Azure
        Me.imagewidthtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imagewidthtxt.ForeColor = System.Drawing.Color.Black
        Me.imagewidthtxt.Location = New System.Drawing.Point(272, 64)
        Me.imagewidthtxt.Name = "imagewidthtxt"
        Me.imagewidthtxt.Size = New System.Drawing.Size(56, 20)
        Me.imagewidthtxt.TabIndex = 62
        Me.imagewidthtxt.Text = "113"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(336, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 8)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "HEIGHT"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'imageheighttxt
        '
        Me.imageheighttxt.BackColor = System.Drawing.Color.Azure
        Me.imageheighttxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageheighttxt.ForeColor = System.Drawing.Color.Black
        Me.imageheighttxt.Location = New System.Drawing.Point(336, 64)
        Me.imageheighttxt.Name = "imageheighttxt"
        Me.imageheighttxt.Size = New System.Drawing.Size(56, 20)
        Me.imageheighttxt.TabIndex = 64
        Me.imageheighttxt.Text = "150"
        '
        'Main_Screen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(474, 312)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 344)
        Me.MinimumSize = New System.Drawing.Size(480, 344)
        Me.Name = "Main_Screen"
        Me.ShowInTaskbar = False
        Me.Text = "HTML Images Display Page CodeGen"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private current_light As Integer = 0
    Private current_colour As Integer = 0
    Private currently_working As Boolean = False

    Private filefolder As String
    Private numberofcolumns As String
    Private imageheight As String
    Private imagewidth As String
    Private filetoreplacewith As String
    Private downloadpath As String


    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString)
                Display_Message1.ShowDialog()
                Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
            End If
        Catch exc As Exception
            MsgBox("An error occurred in HTML Images Display Page CodeGen's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Public Sub Load_Registry_Values()
        Try
            Dim configflag As Boolean
            configflag = False
            Dim str As String
            Dim keyflag1 As Boolean = False
            Dim oReg As RegistryKey = Registry.LocalMachine
            Dim keys() As String = oReg.GetSubKeyNames()
            System.Array.Sort(keys)

            For Each str In keys
                If str.Equals("Software\HTML Images Display Page CodeGen") = True Then
                    keyflag1 = True
                    Exit For
                End If
            Next str

            If keyflag1 = False Then
                oReg.CreateSubKey("Software\HTML Images Display Page CodeGen")
            End If

            keyflag1 = False

            Dim oKey As RegistryKey = oReg.OpenSubKey("Software\HTML Images Display Page CodeGen", True)

            str = oKey.GetValue("filefolder")
            If Not IsNothing(str) And Not (str = "") Then
                filefolder = str
            Else
                configflag = True
                oKey.SetValue("filefolder", (Application.StartupPath))
                filefolder = (Application.StartupPath)
            End If
            filefoldertxt.Text = filefolder

            str = oKey.GetValue("numberofcolumns")
            If Not IsNothing(str) And Not (str = "") Then
                numberofcolumns = str
            Else
                configflag = True
                oKey.SetValue("numberofcolumns", ("1"))
                numberofcolumns = ("1")
            End If
            numberofcolumnstxt.Text = numberofcolumns

            str = oKey.GetValue("downloadpath")
            If Not IsNothing(str) And Not (str = "") Then
                downloadpath = str
            Else
                configflag = True
                oKey.SetValue("downloadpath", "2006/Images/")
                downloadpath = "2006/Images/"
            End If
            downloadpathtxt.Text = downloadpath


            str = oKey.GetValue("imageheight")
            If Not IsNothing(str) And Not (str = "") Then
                imageheight = str
            Else
                configflag = True
                oKey.SetValue("imageheight", ("113"))
                imageheight = ("113")
            End If
            imageheighttxt.Text = imageheight

            str = oKey.GetValue("imagewidth")
            If Not IsNothing(str) And Not (str = "") Then
                imagewidth = str
            Else
                configflag = True
                oKey.SetValue("imagewidth", ("150"))
                imagewidth = ("150")
            End If
            imagewidthtxt.Text = imagewidth

            oKey.Close()
            oReg.Close()

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Save_Registry_Values()
        Try
            Dim oReg As RegistryKey = Registry.LocalMachine
            Dim oKey As RegistryKey = oReg.OpenSubKey("Software\HTML Images Display Page CodeGen", True)

            oKey.SetValue("filefolder", filefoldertxt.Text)
            oKey.SetValue("numberofcolumns", numberofcolumnstxt.Text)
            oKey.SetValue("downloadpath", downloadpathtxt.Text)
            oKey.SetValue("imagewidth", imagewidthtxt.Text)
            oKey.SetValue("imageheight", imageheighttxt.Text)

            oKey.Close()
            oReg.Close()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub run_green_lights()
        Try
            Label1.ForeColor = Color.LimeGreen
            Label1.Text = "Waiting"
            Label7.Text = "Resting..."

            current_light = current_light - 1
            If current_light < 1 Then
                current_light = 5
            End If
            current_colour = 0
            PictureBox1.Image = ImageList1.Images(1)
            PictureBox2.Image = ImageList1.Images(1)
            PictureBox3.Image = ImageList1.Images(1)
            PictureBox4.Image = ImageList1.Images(1)
            PictureBox5.Image = ImageList1.Images(1)

            Select Case current_light
                Case 0

                    PictureBox1.Image = ImageList1.Images(0)
                Case 1

                    PictureBox2.Image = ImageList1.Images(0)
                Case 2

                    PictureBox3.Image = ImageList1.Images(0)
                Case 3

                    PictureBox4.Image = ImageList1.Images(0)
                Case 4

                    PictureBox5.Image = ImageList1.Images(0)
                Case 5

                    PictureBox1.Image = ImageList1.Images(0)
            End Select

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub run_orange_lights()
        Try
            Label1.ForeColor = Color.DarkOrange
            Label1.Text = "Working"

            current_light = current_light - 1
            If current_light < 1 Then
                current_light = 5
            End If
            current_colour = 1
            PictureBox1.Image = ImageList1.Images(3)
            PictureBox2.Image = ImageList1.Images(3)
            PictureBox3.Image = ImageList1.Images(3)
            PictureBox4.Image = ImageList1.Images(3)
            PictureBox5.Image = ImageList1.Images(3)
            Select Case current_light
                Case 0
                    PictureBox1.Image = ImageList1.Images(2)
                Case 1
                    PictureBox2.Image = ImageList1.Images(2)
                Case 2
                    PictureBox3.Image = ImageList1.Images(2)
                Case 3
                    PictureBox4.Image = ImageList1.Images(2)
                Case 4
                    PictureBox5.Image = ImageList1.Images(2)
                Case 5
                    PictureBox1.Image = ImageList1.Images(2)
            End Select

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub run_lights()
        Try
            If current_colour = 1 Then
                Select Case current_light
                    Case 0
                        PictureBox5.Image = ImageList1.Images(3)
                        PictureBox1.Image = ImageList1.Images(2)
                    Case 1
                        PictureBox1.Image = ImageList1.Images(3)
                        PictureBox2.Image = ImageList1.Images(2)
                    Case 2
                        PictureBox2.Image = ImageList1.Images(3)
                        PictureBox3.Image = ImageList1.Images(2)
                    Case 3
                        PictureBox3.Image = ImageList1.Images(3)
                        PictureBox4.Image = ImageList1.Images(2)
                    Case 4
                        PictureBox4.Image = ImageList1.Images(3)
                        PictureBox5.Image = ImageList1.Images(2)
                    Case 5
                        PictureBox5.Image = ImageList1.Images(3)
                        PictureBox1.Image = ImageList1.Images(2)
                End Select
            Else
                Select Case current_light
                    Case 0
                        PictureBox5.Image = ImageList1.Images(1)
                        PictureBox1.Image = ImageList1.Images(0)
                    Case 1
                        PictureBox1.Image = ImageList1.Images(1)
                        PictureBox2.Image = ImageList1.Images(0)
                    Case 2
                        PictureBox2.Image = ImageList1.Images(1)
                        PictureBox3.Image = ImageList1.Images(0)
                    Case 3
                        PictureBox3.Image = ImageList1.Images(1)
                        PictureBox4.Image = ImageList1.Images(0)
                    Case 4
                        PictureBox4.Image = ImageList1.Images(1)
                        PictureBox5.Image = ImageList1.Images(0)
                    Case 5
                        PictureBox5.Image = ImageList1.Images(1)
                        PictureBox1.Image = ImageList1.Images(0)
                End Select

            End If

            current_light = current_light + 1
            If current_light > 5 Then
                current_light = 1
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            run_lights()
            Label8.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Label8.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
            Label10.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")

            Load_Registry_Values()
            Timer2.Start()
            dataloaded = True
            splash_loader.Visible = False
            splash_loader.WindowState = FormWindowState.Minimized
            splash_loader.Opacity = 0
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub exit_application()
        Try
            Me.WindowState = FormWindowState.Minimized
            Me.Opacity = 0
            Save_Registry_Values()
            If Worker1.WorkerThread Is Nothing = False Then
                Worker1.WorkerThread.Abort()
                Worker1.Dispose()
            End If
            NotifyIcon1.Dispose()
            Application.Exit()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Main_Screen_closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            exit_application()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub


    Public Sub WorkerHandler(ByVal Result As String)
        Try
            currently_working = False
            Label19.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")
            If Result.StartsWith("Success") Then
                'Label12.Text = Label12.Text & "  (" & Result.Replace("Success", "") & " files in base folder)"
            End If
            NotifyIcon1.Text = "Resting... "
            run_green_lights()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Public Sub WorkerProgressHandler(ByVal filesrenamed As Long, ByVal currentfilename As String, ByVal totalfiles As Long)
        Try
            'Label12.Text = (filesrenamed).ToString & " (of " & totalfiles.ToString & ")"
            Label12.Text = (filesrenamed).ToString
            label22.Text = currentfilename
            label22.Select(0, 0)
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub run_worker()
        run_orange_lights()
        Label11.Text = ""
        Label12.Text = ""
        Label19.Text = ""
        Label11.Text = Format(Now(), "dd/MM/yyyy hh:mm:ss tt")

        Worker1.savefilepath = SaveFileDialog1.FileName
        Worker1.filefolder = filefoldertxt.Text
        Worker1.numberofcolumns = numberofcolumnstxt.Text.Trim.ToLower
        Worker1.imagewidth = imagewidthtxt.Text.Trim.ToLower
        Worker1.imageheight = imageheighttxt.Text.Trim.ToLower
        Worker1.downloadpath = downloadpathtxt.Text
        'If RadioButton1.Checked = True Then
        Worker1.FolderWalkChosen = True
        'Else
        '    Worker1.FolderWalkChosen = False
        'End If
        If CheckBox1.Checked = True Then
            Worker1.RecursiveWalk = True
        Else
            Worker1.RecursiveWalk = False
        End If
        'If CheckBox2.Checked = True Then
        '    Worker1.AddNewDescriptor = True
        'Else
        '    Worker1.AddNewDescriptor = False
        'End If

        Worker1.ChooseThreads(1)
        currently_working = True
    End Sub



    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Try
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub show_application()
        Try
            Me.Opacity = 1

            Me.BringToFront()
            Me.Refresh()
            Me.WindowState = FormWindowState.Normal

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub NotifyIcon1_dblclick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        show_application()
    End Sub
    Private Sub NotifyIcon1_snglclick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        show_application()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        show_application()
    End Sub

    Private Sub Main_Screen_resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try

            If Me.WindowState = FormWindowState.Minimized Then
                NotifyIcon1.Visible = True
                Me.Opacity = 0
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub force_check()
        Try

            If currently_working = False Then
                If ((Not downloadpathtxt.Text = "") Or (Not filefoldertxt.Text = "")) And (Not numberofcolumnstxt.Text = "") Then
                    Dim result As DialogResult = SaveFileDialog1.ShowDialog
                    If result = DialogResult.OK Then
                        Label7.Text = "Busy Working..."
                        NotifyIcon1.Text = "Busy Working..."
                        run_worker()
                    End If
                Else
                    MsgBox("Please ensure that all the application's inputs are filled in before continuing.", MsgBoxStyle.Information, "Operation Launch Denied")
                End If

            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        force_check()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Not filefoldertxt.Text = "" Then
                FolderBrowserDialog1.SelectedPath = filefoldertxt.Text
            End If
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If Not result = DialogResult.Cancel Then
                filefoldertxt.Text = FolderBrowserDialog1.SelectedPath
                filefolder = FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Worker1.WorkerThread Is Nothing = False Then
                Worker1.WorkerThread.Abort()
                Worker1.Dispose()
            End If
        Catch ex As Exception
            Error_Handler(ex)
        Finally
            WorkerHandler("Killed")
        End Try
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not downloadpathtxt.Text = "" Then
                OpenFileDialog1.FileName = downloadpathtxt.Text
            End If
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If Not result = DialogResult.Cancel Then
                downloadpathtxt.Text = OpenFileDialog1.FileName
                downloadpath = OpenFileDialog1.FileName
            End If

        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub filefoldertxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filefoldertxt.TextChanged
        If filefoldertxt.Text.Length > 0 Then
            'RadioButton1.Enabled = True
            CheckBox1.Enabled = True
            'RadioButton1.Checked = True
        Else
            'RadioButton1.Enabled = False
            CheckBox1.Enabled = False
        End If
    End Sub

    'Private Sub downloadpathtxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downloadpathtxt.TextChanged
    '    If downloadpathtxt.Text.Length > 0 Then
    '        RadioButton2.Enabled = True
    '        RadioButton2.Checked = True
    '    Else
    '        RadioButton2.Enabled = False
    '    End If
    'End Sub
End Class
