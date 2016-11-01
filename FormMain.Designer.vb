<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.ButtonConvert = New System.Windows.Forms.Button
        Me.ButtonOpen = New System.Windows.Forms.Button
        Me.ComboBoxSheet = New System.Windows.Forms.ComboBox
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.TextBoxPath = New System.Windows.Forms.TextBox
        Me.LabelSheet = New System.Windows.Forms.Label
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.ListViewToko = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.LabelExit = New System.Windows.Forms.Label
        Me.PanelExit = New System.Windows.Forms.PictureBox
        Me.PanelMove = New System.Windows.Forms.PictureBox
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.CheckBoxShowResponse = New System.Windows.Forms.CheckBox
        Me.LabelResponse = New System.Windows.Forms.Label
        Me.LabelOptions = New System.Windows.Forms.Label
        Me.ButtonAddMenu = New System.Windows.Forms.Button
        Me.ButtonRemoveMenu = New System.Windows.Forms.Button
        Me.BoxLoading = New System.Windows.Forms.PictureBox
        Me.TimerLoading1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLoading2 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckDebug = New System.Windows.Forms.CheckBox
        CType(Me.PanelExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BoxLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonConvert
        '
        Me.ButtonConvert.Location = New System.Drawing.Point(254, 178)
        Me.ButtonConvert.Name = "ButtonConvert"
        Me.ButtonConvert.Size = New System.Drawing.Size(129, 51)
        Me.ButtonConvert.TabIndex = 0
        Me.ButtonConvert.Text = "Upload"
        Me.ButtonConvert.UseVisualStyleBackColor = True
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(341, 43)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(42, 20)
        Me.ButtonOpen.TabIndex = 1
        Me.ButtonOpen.Text = "..."
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'ComboBoxSheet
        '
        Me.ComboBoxSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSheet.FormattingEnabled = True
        Me.ComboBoxSheet.Location = New System.Drawing.Point(80, 179)
        Me.ComboBoxSheet.Name = "ComboBoxSheet"
        Me.ComboBoxSheet.Size = New System.Drawing.Size(155, 21)
        Me.ComboBoxSheet.TabIndex = 3
        '
        'OpenFile
        '
        Me.OpenFile.Filter = "Spreadsheet Document|*.csv;*.xls;*.xlsx"
        '
        'TextBoxPath
        '
        Me.TextBoxPath.BackColor = System.Drawing.Color.White
        Me.TextBoxPath.Location = New System.Drawing.Point(12, 43)
        Me.TextBoxPath.Name = "TextBoxPath"
        Me.TextBoxPath.ReadOnly = True
        Me.TextBoxPath.Size = New System.Drawing.Size(319, 20)
        Me.TextBoxPath.TabIndex = 4
        '
        'LabelSheet
        '
        Me.LabelSheet.AutoSize = True
        Me.LabelSheet.Location = New System.Drawing.Point(8, 182)
        Me.LabelSheet.Name = "LabelSheet"
        Me.LabelSheet.Size = New System.Drawing.Size(66, 13)
        Me.LabelSheet.TabIndex = 5
        Me.LabelSheet.Text = "Sheet Name"
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.Location = New System.Drawing.Point(11, 273)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.Size = New System.Drawing.Size(224, 82)
        Me.TextBoxResponse.TabIndex = 6
        '
        'ListViewToko
        '
        Me.ListViewToko.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewToko.FullRowSelect = True
        Me.ListViewToko.Location = New System.Drawing.Point(12, 72)
        Me.ListViewToko.MultiSelect = False
        Me.ListViewToko.Name = "ListViewToko"
        Me.ListViewToko.Size = New System.Drawing.Size(371, 96)
        Me.ListViewToko.TabIndex = 8
        Me.ListViewToko.UseCompatibleStateImageBehavior = False
        Me.ListViewToko.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nama Toko"
        Me.ColumnHeader1.Width = 310
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 50
        '
        'LabelExit
        '
        Me.LabelExit.AutoSize = True
        Me.LabelExit.BackColor = System.Drawing.Color.Red
        Me.LabelExit.ForeColor = System.Drawing.Color.White
        Me.LabelExit.Location = New System.Drawing.Point(372, 6)
        Me.LabelExit.Name = "LabelExit"
        Me.LabelExit.Size = New System.Drawing.Size(14, 13)
        Me.LabelExit.TabIndex = 12
        Me.LabelExit.Text = "X"
        '
        'PanelExit
        '
        Me.PanelExit.BackColor = System.Drawing.Color.Red
        Me.PanelExit.Location = New System.Drawing.Point(364, 0)
        Me.PanelExit.Name = "PanelExit"
        Me.PanelExit.Size = New System.Drawing.Size(30, 25)
        Me.PanelExit.TabIndex = 11
        Me.PanelExit.TabStop = False
        '
        'PanelMove
        '
        Me.PanelMove.BackColor = System.Drawing.Color.Coral
        Me.PanelMove.Location = New System.Drawing.Point(0, 0)
        Me.PanelMove.Name = "PanelMove"
        Me.PanelMove.Size = New System.Drawing.Size(392, 25)
        Me.PanelMove.TabIndex = 10
        Me.PanelMove.TabStop = False
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Coral
        Me.LabelTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.White
        Me.LabelTitle.Location = New System.Drawing.Point(9, 6)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(61, 14)
        Me.LabelTitle.TabIndex = 13
        Me.LabelTitle.Text = "Import Data"
        '
        'CheckBoxShowResponse
        '
        Me.CheckBoxShowResponse.AutoSize = True
        Me.CheckBoxShowResponse.Location = New System.Drawing.Point(12, 213)
        Me.CheckBoxShowResponse.Name = "CheckBoxShowResponse"
        Me.CheckBoxShowResponse.Size = New System.Drawing.Size(75, 17)
        Me.CheckBoxShowResponse.TabIndex = 14
        Me.CheckBoxShowResponse.Text = "Advanced"
        Me.CheckBoxShowResponse.UseVisualStyleBackColor = True
        '
        'LabelResponse
        '
        Me.LabelResponse.AutoSize = True
        Me.LabelResponse.Location = New System.Drawing.Point(8, 251)
        Me.LabelResponse.Name = "LabelResponse"
        Me.LabelResponse.Size = New System.Drawing.Size(89, 13)
        Me.LabelResponse.TabIndex = 15
        Me.LabelResponse.Text = "Server Response"
        '
        'LabelOptions
        '
        Me.LabelOptions.AutoSize = True
        Me.LabelOptions.Location = New System.Drawing.Point(251, 251)
        Me.LabelOptions.Name = "LabelOptions"
        Me.LabelOptions.Size = New System.Drawing.Size(43, 13)
        Me.LabelOptions.TabIndex = 16
        Me.LabelOptions.Text = "Options"
        '
        'ButtonAddMenu
        '
        Me.ButtonAddMenu.Location = New System.Drawing.Point(254, 273)
        Me.ButtonAddMenu.Name = "ButtonAddMenu"
        Me.ButtonAddMenu.Size = New System.Drawing.Size(131, 25)
        Me.ButtonAddMenu.TabIndex = 17
        Me.ButtonAddMenu.Text = "Add to Menu"
        Me.ButtonAddMenu.UseVisualStyleBackColor = True
        '
        'ButtonRemoveMenu
        '
        Me.ButtonRemoveMenu.Location = New System.Drawing.Point(254, 301)
        Me.ButtonRemoveMenu.Name = "ButtonRemoveMenu"
        Me.ButtonRemoveMenu.Size = New System.Drawing.Size(131, 25)
        Me.ButtonRemoveMenu.TabIndex = 18
        Me.ButtonRemoveMenu.Text = "Remove from Menu"
        Me.ButtonRemoveMenu.UseVisualStyleBackColor = True
        '
        'BoxLoading
        '
        Me.BoxLoading.BackColor = System.Drawing.Color.Tomato
        Me.BoxLoading.Location = New System.Drawing.Point(0, 25)
        Me.BoxLoading.Name = "BoxLoading"
        Me.BoxLoading.Size = New System.Drawing.Size(393, 4)
        Me.BoxLoading.TabIndex = 19
        Me.BoxLoading.TabStop = False
        Me.BoxLoading.Visible = False
        '
        'TimerLoading1
        '
        Me.TimerLoading1.Interval = 1
        '
        'TimerLoading2
        '
        Me.TimerLoading2.Interval = 20
        '
        'CheckDebug
        '
        Me.CheckDebug.AutoSize = True
        Me.CheckDebug.Location = New System.Drawing.Point(254, 338)
        Me.CheckDebug.Name = "CheckDebug"
        Me.CheckDebug.Size = New System.Drawing.Size(88, 17)
        Me.CheckDebug.TabIndex = 20
        Me.CheckDebug.Text = "Debug Mode"
        Me.CheckDebug.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 255)
        Me.Controls.Add(Me.CheckDebug)
        Me.Controls.Add(Me.BoxLoading)
        Me.Controls.Add(Me.ButtonRemoveMenu)
        Me.Controls.Add(Me.ButtonAddMenu)
        Me.Controls.Add(Me.LabelOptions)
        Me.Controls.Add(Me.LabelResponse)
        Me.Controls.Add(Me.CheckBoxShowResponse)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.LabelExit)
        Me.Controls.Add(Me.PanelExit)
        Me.Controls.Add(Me.PanelMove)
        Me.Controls.Add(Me.ListViewToko)
        Me.Controls.Add(Me.TextBoxResponse)
        Me.Controls.Add(Me.LabelSheet)
        Me.Controls.Add(Me.TextBoxPath)
        Me.Controls.Add(Me.ComboBoxSheet)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.ButtonConvert)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data"
        Me.TopMost = True
        CType(Me.PanelExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BoxLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonConvert As System.Windows.Forms.Button
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents ComboBoxSheet As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents LabelSheet As System.Windows.Forms.Label
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents ListViewToko As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelExit As System.Windows.Forms.Label
    Friend WithEvents PanelExit As System.Windows.Forms.PictureBox
    Friend WithEvents PanelMove As System.Windows.Forms.PictureBox
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents CheckBoxShowResponse As System.Windows.Forms.CheckBox
    Friend WithEvents LabelResponse As System.Windows.Forms.Label
    Friend WithEvents LabelOptions As System.Windows.Forms.Label
    Friend WithEvents ButtonAddMenu As System.Windows.Forms.Button
    Friend WithEvents ButtonRemoveMenu As System.Windows.Forms.Button
    Friend WithEvents BoxLoading As System.Windows.Forms.PictureBox
    Friend WithEvents TimerLoading1 As System.Windows.Forms.Timer
    Friend WithEvents TimerLoading2 As System.Windows.Forms.Timer
    Friend WithEvents CheckDebug As System.Windows.Forms.CheckBox

End Class
