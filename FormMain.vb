Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System
Imports Microsoft.Win32
Imports Excel
Public Class FormMain
    Private AeroEnabled As Boolean
    Private Drag As Boolean
    Private MouseX As Integer
    Private MouseY As Integer
    '************************
    Dim ProgressFinish As Boolean = False
    Dim TempFolder As String = Application.StartupPath & "\tmp"
    Dim URLUpload As String = "http://localhost/BearhugMonitor/?page=api&mode=1"
    Dim URLList As String = "http://localhost/BearhugMonitor/?page=api&mode=2"
    Dim UploadResponse As String
    Dim OutputPath As String
    Dim SourceType As String
    Dim Result As New DataSet()
    Dim myWebClient As New WebClient()
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            CheckAeroEnabled()
            Dim cp As CreateParams = MyBase.CreateParams
            If Not aeroEnabled Then
                cp.ClassStyle = cp.ClassStyle Or NativeConstants.CS_DROPSHADOW
                Return cp
            Else
                Return cp
            End If
        End Get
    End Property
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case NativeConstants.WM_NCPAINT
                Dim val = 2
                If aeroEnabled Then
                    NativeMethods.DwmSetWindowAttribute(Handle, 2, val, 4)
                    Dim bla As New NativeStructs.MARGINS()
                    With bla
                        .bottomHeight = 1
                        .leftWidth = 0
                        .rightWidth = 0
                        .topHeight = 0
                    End With
                    NativeMethods.DwmExtendFrameIntoClientArea(Handle, bla)
                End If
                Exit Select
        End Select
        MyBase.WndProc(m)
    End Sub
    Private Sub CheckAeroEnabled()
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim enabled As Integer = 0
            Dim response As Integer = NativeMethods.DwmIsCompositionEnabled(enabled)
            AeroEnabled = (enabled = 1)
        Else
            AeroEnabled = False
        End If
    End Sub
    Private Sub PanelMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelMove.MouseDown
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub PanelMove_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelMove.MouseMove
        If Drag Then
            Me.Top = Cursor.Position.Y - MouseY
            Me.Left = Cursor.Position.X - MouseX
        End If
    End Sub
    Private Sub PanelMove_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelMove.MouseUp
        Drag = False
    End Sub
    Private Sub LabelExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelExit.Click
        End
    End Sub
    Private Sub PanelExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelExit.Click
        End
    End Sub
    '*************************
    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BoxLoading.Width = 1
        Me.Height = 241
        If Not Command() = "" Then
            'MsgBox(Command())
            TextBoxPath.Text = Command()
        End If
        If Not Directory.Exists(TempFolder) Then
            Directory.CreateDirectory(TempFolder)
        Else
            For Each _file As String In Directory.GetFiles(TempFolder)
                File.Delete(_file)
            Next
        End If
        Try
            Dim myDatabuffer As Byte() = myWebClient.DownloadData(URLList)
            Dim download As String = Encoding.ASCII.GetString(myDatabuffer)
            Dim Result() As String = download.Split("|")
            Dim items As New List(Of String)()
            For i As Integer = 0 To Result.Count - 1
                Dim RealData() As String = Result(i).Split("-")
                items.Add(Result(i))
                Dim Str(2) As String
                Str(0) = RealData(1)
                Str(1) = RealData(0)
                Dim itm As ListViewItem
                itm = New ListViewItem(Str)
                ListViewToko.Items.Add(itm)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            MsgBox("Stack Trace: " & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical)
            If CheckDebug.CheckState = CheckState.Unchecked Then
                Close()
                End
            End If
        End Try
    End Sub
    Private Sub GetExcelData(ByVal filename As String)
        Try
            If filename.EndsWith(".xlsx") Then
                ' Reading from a binary Excel file (format; *.xlsx)
                Dim stream As FileStream = File.Open(filename, FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                Result = excelReader.AsDataSet()
                excelReader.Close()
                Dim items As New List(Of String)()
                For i As Integer = 0 To Result.Tables.Count - 1
                    items.Add(Result.Tables(i).TableName.ToString())
                Next
                ComboBoxSheet.DataSource = items
                SourceType = "xlsx"
            ElseIf filename.EndsWith(".xls") Then
                'Reading from a binary Excel file ('97-2003 format; *.xls)
                Dim stream As FileStream = File.Open(filename, FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Result = excelReader.AsDataSet()
                excelReader.Close()
                Dim items As New List(Of String)()
                For i As Integer = 0 To Result.Tables.Count - 1
                    items.Add(Result.Tables(i).TableName.ToString())
                Next
                ComboBoxSheet.DataSource = items
                SourceType = "xls"
            ElseIf filename.EndsWith(".csv") Then
                SourceType = "csv"
            Else
                SourceType = "unknown"
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical)
            MsgBox("Stack Trace: " & vbCrLf & Ex.StackTrace, MsgBoxStyle.Critical)
            If CheckDebug.CheckState = CheckState.Unchecked Then
                Close()
                End
            End If
        End Try
    End Sub
    Private Sub ConverToCSV(ByVal ind As Integer, ByVal StoreID As String)
        Try
            If Not SourceType = "unknown" Then
                Randomize()
                Dim RandValue As String = CInt(Int((99999 * Rnd()) + 10000))
                Dim OutputPath As String = TempFolder + "\" + StoreID + "-" + RandValue + ".csv"
                If SourceType = "xlsx" Or SourceType = "xls" Then
                    Dim a As String = ""
                    Dim row_no As Integer = 0
                    While row_no < Result.Tables(ind).Rows.Count
                        For i As Integer = 0 To Result.Tables(ind).Columns.Count - 1
                            a += Result.Tables(ind).Rows(row_no)(i).ToString().Replace(Chr(10), " ") + ";"
                        Next
                        row_no += 1
                        a += vbLf
                    End While
                    Dim csv As New StreamWriter(OutputPath, False)
                    csv.Write(a)
                    csv.Close()
                Else
                    File.Copy(TextBoxPath.Text, OutputPath)
                End If
                Dim responseArray As Byte() = myWebClient.UploadFile(URLUpload, OutputPath)
                UploadResponse = System.Text.Encoding.ASCII.GetString(responseArray)
                File.Delete(OutputPath)
                TextBoxResponse.Text = UploadResponse
                CheckResponse()
            Else
                MsgBox("File Type tidak di kenali", MsgBoxStyle.Exclamation)
                ButtonConvert.Enabled = True
                ButtonConvert.Text = "Upload"
                ProgressFinish = False
                If CheckDebug.CheckState = CheckState.Unchecked Then
                    Close()
                    End
                End If
            End If
            Return
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            MsgBox("Stack Trace: " & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical)
            ButtonConvert.Enabled = True
            ButtonConvert.Text = "Upload"
            ProgressFinish = False
            If CheckDebug.CheckState = CheckState.Unchecked Then
                Close()
                End
            End If
        End Try
    End Sub
    Private Sub CheckResponse()
        If TextBoxResponse.Text = "" Then
            TimerLoading1.Enabled = False
            MsgBox("Error: Server tidak memberikan respon", MsgBoxStyle.Critical)
            If CheckDebug.CheckState = CheckState.Unchecked Then
                Close()
                End
            End If
        Else
            Dim ResResponse() As String = TextBoxResponse.Text.Split("-")
            If ResResponse(0) = "0" Then 'Success
                ProgressFinish = True
            ElseIf ResResponse(0) = "1" Then 'DB Error
                TimerLoading1.Enabled = False
                MsgBox("Error: Database pada server sedang mengalami gangguan", MsgBoxStyle.Critical)
                If CheckDebug.CheckState = CheckState.Unchecked Then
                    Close()
                    End
                End If
            ElseIf ResResponse(0) = "2" Then 'Unreadable
                TimerLoading1.Enabled = False
                MsgBox("Error: Server tidak bisa membaca file yang di upload", MsgBoxStyle.Critical)
                If CheckDebug.CheckState = CheckState.Unchecked Then
                    Close()
                    End
                End If
            End If
        End If
    End Sub
    Private Sub ButtonConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConvert.Click
        If Not TextBoxPath.Text = "" Then
            If ListViewToko.SelectedItems.Count > 0 Then
                ButtonConvert.Enabled = False
                ButtonConvert.Text = "Please Wait..."
                ProgressFinish = False
                BoxLoading.Visible = True
                TimerLoading1.Enabled = True
                ConverToCSV(ComboBoxSheet.SelectedIndex, ListViewToko.Items(ListViewToko.FocusedItem.Index).SubItems(1).Text())
            Else
                MsgBox("Silahkan pilih nama toko terlebih dahulu", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Silahkan pilih file terlebih dahulu.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Private Sub ButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpen.Click
        Dim Chosen_File As String = ""
        If OpenFile.ShowDialog() = DialogResult.OK Then
            Chosen_File = OpenFile.FileName
        End If
        If Chosen_File = [String].Empty Then
            Return
        End If
        TextBoxPath.Text = Chosen_File
        GetExcelData(TextBoxPath.Text)
    End Sub
    Private Sub LabelTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LabelTitle.MouseDown
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub LabelTitle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LabelTitle.MouseMove
        If Drag Then
            Me.Top = Cursor.Position.Y - MouseY
            Me.Left = Cursor.Position.X - MouseX
        End If
    End Sub
    Private Sub LabelTitle_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LabelTitle.MouseUp
        Drag = False
    End Sub
    Private Sub CheckBoxShowResponse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxShowResponse.CheckedChanged
        If CheckBoxShowResponse.CheckState = CheckState.Checked Then
            Me.Height = 368
        Else
            Me.Height = 241
        End If
    End Sub
    Private Sub ButtonAddMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddMenu.Click
        Try
            Dim CommandKeyValue As String = Application.ExecutablePath & " %1"
            'Begin CSV
            Dim CSVKeyName As String = "HKEY_CLASSES_ROOT\Excel.CSV\shell\Upload to Dashboard\command"
            Registry.SetValue(CSVKeyName, "", CommandKeyValue)
            'Begin XLS
            Dim XLSKeyName As String = "HKEY_CLASSES_ROOT\Excel.Sheet.8\shell\Upload to Dashboard\command"
            Registry.SetValue(XLSKeyName, "", CommandKeyValue)
            'Begin XLSX
            Dim XLSXKeyName As String = "HKEY_CLASSES_ROOT\Excel.Sheet.12\shell\Upload to Dashboard\command"
            Registry.SetValue(XLSXKeyName, "", CommandKeyValue)
            'Send Success Alert
            MsgBox("Success adding contextmenu to Windows Explorer", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error adding contextmenu to Windows Explorer", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ButtonRemoveMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveMenu.Click
        Try
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("Excel.CSV\shell\Upload to Dashboard")
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("Excel.Sheet.8\shell\Upload to Dashboard")
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("Excel.Sheet.12\shell\Upload to Dashboard")
            MsgBox("Success remove contextmenu from Windows Explorer", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Failed to remove contextmenu from Windows Explorer", MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub TimerLoading1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoading1.Tick
        If BoxLoading.Width = 221 Then
            TimerLoading1.Enabled = False
            TimerLoading2.Enabled = True
        Else
            BoxLoading.Width = BoxLoading.Width + 2
        End If
    End Sub
    Private Sub TimerLoading2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoading2.Tick
        If ProgressFinish = True Then
            If BoxLoading.Width = 393 Then
                TimerLoading2.Enabled = False
                MsgBox("Berhasil di Upload", MsgBoxStyle.Information)
                If CheckDebug.CheckState = CheckState.Unchecked Then
                    File.Delete(TextBoxPath.Text)
                    Close()
                    End
                End If
            Else
                BoxLoading.Width = BoxLoading.Width + 1
            End If
        End If
    End Sub
End Class
Public Class NativeStructs
    Public Structure MARGINS
        Public leftWidth As Integer
        Public rightWidth As Integer
        Public topHeight As Integer
        Public bottomHeight As Integer
    End Structure
End Class
Public Class NativeMethods
    <DllImport("dwmapi")> _
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As NativeStructs.MARGINS) As Integer
    End Function
    <DllImport("dwmapi")> _
    Friend Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
    End Function
    <DllImport("dwmapi.dll")> _
    Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
    End Function
End Class
Public Class NativeConstants
    Public Const CS_DROPSHADOW As Integer = &H20000
    Public Const WM_NCPAINT As Integer = &H85
End Class
