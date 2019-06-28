Public Class Form1
    Private Const GWL_EXSTYLE As Integer = (-20)
    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) Or WS_EX_TRANSPARENT)
        Dim allScreens = Screen.AllScreens
        If Left = Screen.PrimaryScreen.Bounds.Left Or Top = Screen.PrimaryScreen.Bounds.Top Then
            For Each screen In allScreens
                If Not screen Is Screen.PrimaryScreen Then
                    Dim form As New Form1 With {.Location = New Point(screen.Bounds.Left, screen.Bounds.Top)}
                    form.Show()
                End If
            Next
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
End Class
