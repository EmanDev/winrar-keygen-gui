Imports System.IO
Public Class Form1

    Public Class MyUtilities
        Shared Sub RunCommandCom(ByVal command As String, ByVal arguments As String, ByVal permanent As Boolean)
            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()
            pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments
            pi.FileName = "cmd.exe"
            p.StartInfo = pi
            p.Start()
        End Sub
    End Class

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("Be sure to save the license file as 'rarreg.key' in order to register the license.", MsgBoxStyle.Information, "WinRAR Keygen")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "KEY File (*.key)|*.key"
        SaveFileDialog1.FileName = "rarreg.key"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xpath As String = Path.Combine(Path.GetTempPath(), "winrar-keygen.exe")
            File.WriteAllBytes(xpath, My.Resources.winrar_keygen)
            Dim username As String = TextBox1.Text
            Dim lictype As String = ComboBox1.Text
            Dim q As String = Chr(34)
            Dim p As String = Chr(62)
            Dim sb As String = " "
            Dim gen As String = q + username + q + sb + q + lictype + q + sb + p + sb + SaveFileDialog1.FileName

            MyUtilities.RunCommandCom(xpath, gen, False)
        Else
            MsgBox("Cancelled! User has cancelled the operation.", MsgBoxStyle.Information, "WinRAR Keygen")
        End If
    End Sub
End Class
