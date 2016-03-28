Imports System.Net

Public Class Updater
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function

    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists("Timer Tracker.exe") Then
            CheckForUpdates()
        Else
            MsgBox("Timer Tracker.exe not found, please make sure Timer Tracker is placed in the same directory as Timer Tracker Update.", MessageBoxIcon.Exclamation)
            Me.Close()
        End If


        ProgressBar1.ForeColor = Color.DeepSkyBlue
    End Sub

    Public Sub CheckForUpdates()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/ddqilnur23eyw04/timertracker.txt?dl=1")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion = GetFileVersionInfo("Timer Tracker.exe").ToString()

            ' Dim currentversion As String = Application.ProductVersion


            If newestversion <= currentversion Then
                ''uptodate
                uptodate.BringToFront()
            Else
                ''Need update
                Dim result As DialogResult = MessageBox.Show("Would you like to update Timer Tracker?", "Confirm update?", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then

                    Try
                        My.Computer.FileSystem.DeleteFile("Timer Tracker.exe")
                    Catch ex As Exception
                        MsgBox(ex)
                    End Try
                    Dim client As WebClient = New WebClient
                    AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
                    AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
                    client.DownloadFileAsync(New Uri("http://www.redpoisonjb.com/timertracker.exe"), "Timer Tracker.exe")
                    updatingpanel.BringToFront()

                ElseIf (result = DialogResult.No)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ''Handles the NO INTERNET problem
            MsgBox("Can't connect to our servers, Please check your connection.", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100

        ProgressBar1.Value = Integer.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        uptodate.BringToFront()
    End Sub



    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Close()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top

    End Sub

    Private Sub Panel1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel

    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub closebuttonuptodate_Click(sender As Object, e As EventArgs) Handles closebuttonuptodate.Click
        Process.Start("Timer Tracker.exe")
        Me.Close()
    End Sub
End Class
