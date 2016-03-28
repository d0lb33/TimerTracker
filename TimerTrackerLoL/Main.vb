Public Class Main
    Dim start As Boolean = True
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If findtxt.ShowDialog = DialogResult.OK Then
            My.Settings.textpath = findtxt.FileName
            InGameTracker.path = findtxt.FileName
            txtBoxloc.Text = findtxt.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If start = True Then
            MsgBox("Make sure to start League Of Legends in borderless mode, else wise this will not work!", MsgBoxStyle.Information)
            Label7.Text = "Change XY position of Timer Tracker." & vbCrLf & "Can't edit while running Timer Tracker!"
            InGameTracker.Show()
            start = False
            Button2.Text = "Stop"
            winposX.Enabled = False
            winposY.Enabled = False
        ElseIf start = False
            InGameTracker.Close()
            start = True
            Label7.Text = "Change XY position of Timer Tracker."
            Button2.Text = "Start"
            winposX.Enabled = True
            winposY.Enabled = True
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForUpdates()
        winposX.Text = My.Settings.winposx
        winposY.Text = My.Settings.winposy

        If My.Settings.textpath = "" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
            txtBoxloc.Text = My.Settings.textpath
            InGameTracker.path = My.Settings.textpath
        End If
        InGameTracker.Close()
    End Sub

    Private Sub winposX_TextChanged(sender As Object, e As EventArgs) Handles winposX.TextChanged
        If winposX.Text = "" Then

        Else
            Dim stringToIntegerX As Integer = Integer.Parse(winposX.Text)
            My.Settings.winposx = stringToIntegerX
            My.Settings.Save()
        End If
    End Sub

    Private Sub winposY_TextChanged(sender As Object, e As EventArgs) Handles winposY.TextChanged
        If winposY.Text = "" Then
        Else
            Dim stringToIntegerY As Integer = Integer.Parse(winposY.Text)
            My.Settings.winposy = stringToIntegerY
            My.Settings.Save()
        End If

    End Sub

    Private Sub findtxt_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles findtxt.FileOk

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.FileSystem.FileExists(My.Settings.textpath) Then
            If My.Settings.textpath.EndsWith(".txt") Then
                Button2.Enabled = True
                exist.Text = ""
            Else
                Button2.Enabled = False
                exist.Text = "File Exists, but is not a text file or does not end in .txt!"
            End If

        Else
            Button2.Enabled = False
            exist.Text = "MyNotes.txt not found!"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MessageBox.Show("The normal location for 'MyNotes.txt' is ""C:\Riot Games\League Of Legends\RADS\solutions\lol_game_client_sln\releases\X.X.X.X\MyNotes.txt"" " & vbCrLf & vbCrLf & "Note* X.X.X.X is the current version of the client. So make sure to update the MyNotes.txt directory every patch!" & vbCrLf & vbCrLf & "If the file doesn't exist, go into a game and type ""/note blah"".")
    End Sub

    Private Sub txtBoxloc_TextChanged(sender As Object, e As EventArgs) Handles txtBoxloc.TextChanged
        My.Settings.textpath = txtBoxloc.Text
    End Sub
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub CheckForUpdates()
        If My.Computer.FileSystem.FileExists("Timer Tracker Update.exe") Then

            Try
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/ddqilnur23eyw04/timertracker.txt?dl=1")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = sr.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion


                If newestversion <= currentversion Then
                    ''uptodate
                Else
                    ''Need update
                    Dim result As DialogResult = MessageBox.Show("Would you like to update Timer Tracker?", "Confirm update?", MessageBoxButtons.YesNo)
                    If (result = DialogResult.Yes) Then
                        Process.Start("Timer Tracker Update.exe")
                        Me.Close()
                    ElseIf (result = DialogResult.No)
                    End If
                End If
            Catch ex As Exception
                ''Handles the NO INTERNET problem
                MsgBox("Can't connect to update servers, Please check your connection.", MsgBoxStyle.Information)
            End Try

        Else
            MsgBox("You do not have the Timer Tracker Update.exe in the same directory as Timer Tracker. To recieve the latest updates automatically it is recommended you keep Timer Tracker.exe and Timer Tracker Update.exe together!")
        End If
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        drag = False
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Label8_MouseMove(sender As Object, e As MouseEventArgs) Handles Label8.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Label8_MouseUp(sender As Object, e As MouseEventArgs) Handles Label8.MouseUp
        drag = False
    End Sub

    Private Sub Label8_MouseDown(sender As Object, e As MouseEventArgs) Handles Label8.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
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

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        MessageBox.Show("After entering the correct location of your MyNotes.txt file, click Start." & vbCrLf & vbCrLf & "Now, launch a game. You should see Timer Tracker show at the top left of your screen." & vbCrLf & vbCrLf & "Once in game, type in chat ""/n ez f""." & vbCrLf & vbCrLf & "A timer for Ezreals flash should start." & vbCrLf & vbCrLf & "Supported Summoner Spells: Flash (f); Barrier(b); Ignite(i); Heal(h); Exhaust(e); Cleanse(c)")
    End Sub
End Class