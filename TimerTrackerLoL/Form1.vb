Imports System.IO
Imports System.Runtime.InteropServices

Public Class InGameTracker

    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Private makel As String
    Private InitialStyle As Integer
    Public path As String
    Dim PercentVisible As Decimal
    Dim Summ1 As String
    Dim Summ1InUse As Boolean
    Dim Summ1ChampName As String
    Dim Summ1Timer As Integer
    Dim Summ2 As String
    Dim Summ2InUse As Boolean
    Dim Summ2ChampName As String
    Dim Summ2Timer As Integer
    Dim Summ3 As String
    Dim Summ3InUse As Boolean
    Dim Summ3ChampName As String
    Dim Summ3Timer As Integer
    Dim Summ4 As String
    Dim Summ4InUse As Boolean
    Dim Summ4ChampName As String
    Dim Summ4Timer As Integer
    Dim Summ5 As String
    Dim Summ5InUse As Boolean
    Dim Summ5ChampName As String
    Dim Summ5Timer As Integer
    Dim Summ6 As String
    Dim Summ6InUse As Boolean
    Dim Summ6ChampName As String
    Dim Summ6Timer As Integer


    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(My.Settings.winposx, My.Settings.winposy)
        InitialStyle = GetWindowLong(Me.Handle, -20)
        PercentVisible = 0.1

        SetWindowLong(Me.Handle, -20, InitialStyle Or &H80000 Or &H20)

        Me.TopMost = True
    End Sub

    Private Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetLayeredWindowAttributes")> Public Shared Function SetLayeredWindowAttributes(ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal alpha As Byte, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Me.Location = New Point(My.Settings.winposx, My.Settings.winposy)

        Dim CapTxt As String = GetCaption()
        Dim Path As String = My.Settings.textpath
        Dim debugMode As Boolean = False

        If CapTxt = "League of Legends (TM) Client" Or debugMode = True Then
            Me.TopMost = True
            Me.Show()
            Me.BringToFront()

            If debugMode = True Then
                Me.TransparencyKey = Color.Transparent
            ElseIf debugMode = False
                Me.TransparencyKey = Color.Black
            End If


            Try

                Dim keywords = {
                    "atrox", "akali", "ahri", "mumu", "ali", "nivia", "annie", "azir", "ashe",
                    "bard", "blitz", "brand", "braum",
                    "cait", "cass", "cho", "cork",
                    "dar", "dia", "mundo", "dr", "drav",
                    "ek", "eli", "eve", "ez",
                    "fid", "fio", "fiz",
                    "gal", "grag", "gang", "gp", "gar", "gnar", "grav",
                    "hec", "heim",
                    "ill", "ire",
                    "jar", "j4", "jay", "jan", "jax", "jhin", "jinx",
                    "kali", "karm", "kart", "kas", "kat", "ken", "kha", "kog", "kay", "kin",
                    "lb", "lebl", "lee", "leo", "lis", "luc", "lux", "lu",
                    "malz", "malp", "mao", "morg", "mord", "mf", "miss",
                    "nam", "nas", "nau", "nid", "noc", "nu",
                    "ola", "ori",
                    "pan", "pop",
                    "qui",
                    "ram", "rek", "reng", "renek", "rum", "riv", "ryz",
                    "sej", "she", "shy", "sion", "ska", "swa", "syn", "sha", "sin", "siv", "son", "sor", "raka",
                    "tar", "tru", "tk", "tah", "tal", "tee", "thre", "tri", "try", "tf", "twi", "twit",
                    "ur", "udy",
                    "vel", "vi", "vik", "vlad", "vol", "var", "vay", "vei",
                    "war", "ww", "wu",
                    "xer", "xin",
                    "yor", "yas", "yi",
                    "zac", "zed", "zig", "zy", "zil"}
                'Dim keywords = {"ezreal f", "ez f", "ezreal b", "ez b", "ez i", "ezreal i", "ez g", "ezreal g", "ez t", "ezreal t", "ez e", "ezreal e", "yasuo f", "yas f", "yas b", "yasuo b", "yasuo i", "yas i", "yasuo g", "yas g", "yasuo t", "yas t", "yasuo e", "yas e", "ashe f", "ashe b", "ashe i", "ashe g", "ashe t", "ashe e", "soraka f", "raka f", "soraka b", "raka b", "soraka i", "raka i", "soraka g", "raka g", "soraka t", "raka t", "soraka e", "raka e", "janna f", "jan f", "janna b", "jan b", "janna i", "jan i", "janna g", "jan g", "janna t", "jan t", "janna e", "jan e", "kalista f", "kali f", "kalista b", "kali b", "kalista i", "kali i", "kalista g", "kali  g", "kalista e", "kali  e", "twitch f", "twit f", "twitch b", "twit b", "twitch i", "twit i", "twitch g", "twit  g", "twitch e", "twit  e", "lulu f", "lulu b", "lulu i", "lulu  g", "lulu  e"}

                For Each keyword As String In keywords
                    If File.ReadAllText(Path).ToLower.Contains(keyword) Then

                        Label1.Hide()
                        hint.Hide()


                        Dim lifesaver = File.ReadAllLines(Path).FirstOrDefault(Function(x) x.ToLower.Contains(keyword))


                        Dim spell As String = lifesaver(lifesaver.Length - 1)
                        Dim champName As String = lifesaver.Remove(lifesaver.Length - 1)

#Region "champnames"

                        If champName.StartsWith("ashe") Then
                            champName = "Ashe "
                        End If

                        If champName.StartsWith("lu") Then
                            champName = "Lulu "
                        End If
                        If champName.StartsWith("vay") Then
                            champName = "Vayne "
                        End If
                        If champName.Contains("atrox") Then
                            champName = "Aatrox "
                        End If
                        If champName.StartsWith("akali") Then
                            champName = "Akali "
                        End If
                        If champName.Contains("mumu") Then
                            champName = "Amumu "
                        End If
                        If champName.Contains("nivia") Then
                            champName = "Anivia "
                        End If
                        If champName.StartsWith("azir") Then
                            champName = "Azir "
                        End If
                        If champName.StartsWith("ahri") Then
                            champName = "Ahri "
                        End If
                        If champName.StartsWith("ali") Then
                            champName = "Alistar "
                        End If
                        If champName.StartsWith("annie") Then
                            champName = "Annie "
                        End If
                        If champName.StartsWith("bard") Then
                            champName = "Bard "
                        End If
                        If champName.StartsWith("blitz") Then
                            champName = "Blitzcrank "
                        End If
                        If champName.StartsWith("brand") Then
                            champName = "Brand "
                        End If
                        If champName.StartsWith("braum") Then
                            champName = "Braum "
                        End If
                        If champName.StartsWith("cait") Then
                            champName = "Caitlyn "
                        End If
                        If champName.StartsWith("cass") Then
                            champName = "Cassiopeia "
                        End If
                        If champName.StartsWith("cho") Then
                            champName = "Cho'Gath "
                        End If
                        If champName.StartsWith("cork") Then
                            champName = "Corki "
                        End If
                        If champName.StartsWith("dar") Then
                            champName = "Darius "
                        End If
                        If champName.StartsWith("dia") Then
                            champName = "Diana "
                        End If
                        If champName.StartsWith("mundo") Or champName.StartsWith("dr") Then
                            champName = "Dr. Mundo "
                        End If
                        If champName.StartsWith("drav") Then
                            champName = "Draven "
                        End If
                        If champName.StartsWith("ek") Then
                            champName = "Ekko "
                        End If
                        If champName.StartsWith("eli") Then
                            champName = "Elise "
                        End If
                        If champName.StartsWith("eve") Then
                            champName = "Evelynn "
                        End If
                        If champName.StartsWith("ez") Then
                            champName = "Ezreal "
                        End If
                        If champName.StartsWith("fiz") Then
                            champName = "Fizz "
                        End If
                        If champName.StartsWith("fio") Then
                            champName = "Fiora "
                        End If
                        If champName.StartsWith("fid") Then
                            champName = "Fiddlesticks "
                        End If
                        If champName.StartsWith("grav") Then
                            champName = "Graves "
                        End If
                        If champName.StartsWith("gnar") Then
                            champName = "Gnar "
                        End If
                        If champName.StartsWith("gar") Then
                            champName = "Garen "
                        End If
                        If champName.StartsWith("gp") Or champName.StartsWith("gang") Then
                            champName = "Gankplank "
                        End If
                        If champName.StartsWith("gal") Then
                            champName = "Galio "
                        End If
                        If champName.StartsWith("grag") Then
                            champName = "Gragas "
                        End If
                        If champName.StartsWith("heim") Then
                            champName = "Heimerdinger "
                        End If
                        If champName.StartsWith("hec") Then
                            champName = "Hecarim "
                        End If
                        If champName.StartsWith("ill") Then
                            champName = "Illaoi "
                        End If
                        If champName.StartsWith("ire") Then
                            champName = "Irelia "
                        End If
                        If champName.StartsWith("jinx") Then
                            champName = "Jinx "
                        End If
                        If champName.StartsWith("jhin") Then
                            champName = "Jhin "
                        End If
                        If champName.StartsWith("jax") Then
                            champName = "Jax "
                        End If
                        If champName.StartsWith("jar") Or champName.Contains("j4") Then
                            champName = "Jarvan IV "
                        End If
                        If champName.StartsWith("jan") Then
                            champName = "Janna "
                        End If
                        If champName.StartsWith("jay") Then
                            champName = "Jayce "
                        End If
                        If champName.StartsWith("kay") Then
                            champName = "Kayle "
                        End If
                        If champName.StartsWith("kin") Then
                            champName = "Kindred "
                        End If
                        If champName.StartsWith("kali") Then
                            champName = "Kalista "
                        End If
                        If champName.StartsWith("karm") Then
                            champName = "Karma "
                        End If
                        If champName.StartsWith("kart") Then
                            champName = "Karthus "
                        End If
                        If champName.StartsWith("kas") Then
                            champName = "Kassadin "
                        End If
                        If champName.StartsWith("kat") Then
                            champName = "Katarina "
                        End If
                        If champName.StartsWith("ken") Then
                            champName = "Kennen "
                        End If
                        If champName.StartsWith("kha") Then
                            champName = "Kha'Zix "
                        End If
                        If champName.StartsWith("kog") Then
                            champName = "Kog'Maw "
                        End If
                        If champName.StartsWith("leo") Then
                            champName = "Leona "
                        End If
                        If champName.StartsWith("lee") Then
                            champName = "Lee Sin "
                        End If
                        If champName.StartsWith("lb") Or champName.StartsWith("lebl") Then
                            champName = "LeBlanc "
                        End If
                        If champName.StartsWith("lis") Then
                            champName = "Lissandra "
                        End If
                        If champName.StartsWith("luc") Then
                            champName = "Lucian "
                        End If
                        If champName.StartsWith("lux") Then
                            champName = "Lux "
                        End If
                        If champName.StartsWith("malz") Then
                            champName = "Malzahar "
                        End If
                        If champName.StartsWith("malp") Then
                            champName = "Malphite "
                        End If
                        If champName.StartsWith("mao") Then
                            champName = "Maokai "
                        End If
                        If champName.StartsWith("mord") Then
                            champName = "Mordekaiser "
                        End If
                        If champName.StartsWith("miss") Or champName.StartsWith("mf") Then
                            champName = "Miss Fortune "
                        End If
                        If champName.StartsWith("morg") Then
                            champName = "Morgana "
                        End If
                        If champName.StartsWith("nam") Then
                            champName = "Nami "
                        End If
                        If champName.StartsWith("nas") Then
                            champName = "Nasus "
                        End If
                        If champName.StartsWith("nu") Then
                            champName = "Nunu "
                        End If
                        If champName.StartsWith("nau") Then
                            champName = "Nautilus "
                        End If
                        If champName.StartsWith("nid") Then
                            champName = "Nidalee "
                        End If
                        If champName.StartsWith("noc") Then
                            champName = "Nocturne "
                        End If
                        If champName.StartsWith("ola") Then
                            champName = "Olaf "
                        End If
                        If champName.StartsWith("ori") Then
                            champName = "Orianna "
                        End If
                        If champName.StartsWith("pop") Then
                            champName = "Poppy "
                        End If
                        If champName.StartsWith("pan") Then
                            champName = "Pantheon "
                        End If
                        If champName.StartsWith("qui") Then
                            champName = "Quinn "
                        End If
                        If champName.StartsWith("ram") Then
                            champName = "Rammus "
                        End If
                        If champName.StartsWith("rek") Then
                            champName = "Rek'Sai "
                        End If
                        If champName.StartsWith("reng") Then
                            champName = "Rengar "
                        End If
                        If champName.StartsWith("renek") Then
                            champName = "Renekton "
                        End If
                        If champName.StartsWith("riv") Then
                            champName = "Riven "
                        End If
                        If champName.StartsWith("ryz") Then
                            champName = "Ryze "
                        End If
                        If champName.StartsWith("rum") Then
                            champName = "Rumble "
                        End If
                        If champName.StartsWith("sha") Then
                            champName = "Shaco "
                        End If
                        If champName.Contains("raka") Or champName.StartsWith("sor") Then
                            champName = "Soraka "
                        End If
                        If champName.StartsWith("sin") Then
                            champName = "Singed "
                        End If
                        If champName.StartsWith("siv") Then
                            champName = "Sivir "
                        End If
                        If champName.StartsWith("son") Then
                            champName = "Sona "
                        End If
                        If champName.StartsWith("sej") Then
                            champName = "Sejuani "
                        End If
                        If champName.StartsWith("she") Then
                            champName = "Shen "
                        End If
                        If champName.StartsWith("shy") Then
                            champName = "Shyvana "
                        End If
                        If champName.StartsWith("sion") Then
                            champName = "Sion "
                        End If
                        If champName.StartsWith("ska") Then
                            champName = "Skarner "
                        End If
                        If champName.StartsWith("swa") Then
                            champName = "Swain "
                        End If
                        If champName.StartsWith("syn") Then
                            champName = "Syndra "
                        End If
                        If champName.StartsWith("tf") Or champName.StartsWith("twi") Then
                            champName = "Twisted Fate "
                        End If
                        If champName.StartsWith("trynd") Then
                            champName = "Tryndamere "
                        End If
                        If champName.StartsWith("tri") Then
                            champName = "Tristana "
                        End If
                        If champName.StartsWith("thre") Then
                            champName = "Thresh "
                        End If
                        If champName.StartsWith("tee") Then
                            champName = "Teemo "
                        End If
                        If champName.StartsWith("tal") Then
                            champName = "Talon "
                        End If
                        If champName.StartsWith("twit") Then
                            champName = "Twitch "
                        End If
                        If champName.StartsWith("tk") Or champName.StartsWith("tah") Then
                            champName = "Tahm Kench "
                        End If
                        If champName.StartsWith("tar") Then
                            champName = "Taric "
                        End If
                        If champName.StartsWith("tru") Then
                            champName = "Trundle "
                        End If
                        If champName.StartsWith("udy") Then
                            champName = "Udyr "
                        End If
                        If champName.StartsWith("ur") Then
                            champName = "Urgot "
                        End If
                        If champName.StartsWith("var") Then
                            champName = "Varus "
                        End If
                        If champName.StartsWith("vei") Then
                            champName = "Veigar "
                        End If
                        If champName.StartsWith("vel") Then
                            champName = "Vel'Koz "
                        End If
                        If champName.StartsWith("vi") Then
                            champName = "Vi "
                        End If
                        If champName.StartsWith("vik") Then
                            champName = "Viktor "
                        End If
                        If champName.StartsWith("vlad") Then
                            champName = "Vladimir "
                        End If
                        If champName.StartsWith("vol") Then
                            champName = "Volibear "
                        End If
                        If champName.StartsWith("ww") Or champName.StartsWith("war") Then
                            champName = "Warwick "
                        End If
                        If champName.StartsWith("wu") Then
                            champName = "Wukong "
                        End If
                        If champName.StartsWith("xin") Then
                            champName = "Xin Zhao "
                        End If
                        If champName.StartsWith("xer") Then
                            champName = "Xerath "
                        End If
                        If champName.StartsWith("yor") Then
                            champName = "Yorick "
                        End If
                        If champName.StartsWith("yi") Then
                            champName = "Master Yi "
                        End If
                        If champName.StartsWith("yas") Then
                            champName = "Yasuo "
                        End If
                        If champName.StartsWith("zac") Then
                            champName = "Zac "
                        End If
                        If champName.StartsWith("zed") Then
                            champName = "Zed "
                        End If
                        If champName.StartsWith("zil") Then
                            champName = "Zilean "
                        End If
                        If champName.StartsWith("zig") Then
                            champName = "Ziggs "
                        End If
                        If champName.StartsWith("zy") Then
                            champName = "Zyra "
                        End If
#End Region

#Region "Barrier"
                        'Handles Barrier
                        If spell.ToString.Contains("b") Then
                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Barrier"
                                Summ1Timer = 210
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Barrier"
                                Summ2Timer = 210
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Barrier"
                                Summ3Timer = 210
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Barrier"
                                Summ4Timer = 210
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Barrier"
                                Summ5Timer = 210
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Barrier"
                                Summ6Timer = 210
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If


                        End If
#End Region
#Region "Flash"
                        ''Handles Flash
                        If spell = "f" Then
                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Flash"
                                Summ1Timer = 300
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Flash"
                                Summ2Timer = 300
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Flash"
                                Summ3Timer = 300
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Flash"
                                Summ4Timer = 300
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Flash"
                                Summ5Timer = 300
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Flash"
                                Summ6Timer = 300
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If

                        End If
#End Region
#Region "Exhaust"
                        'Handles Exhaust
                        If spell.ToString.Contains("e") Then

                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Exhaust"
                                Summ1Timer = 210
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Exhaust"
                                Summ2Timer = 210
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Exhaust"
                                Summ3Timer = 210
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Exhaust"
                                Summ4Timer = 210
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Exhaust"
                                Summ5Timer = 210
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Exhaust"
                                Summ6Timer = 210
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If
                        End If
#End Region
#Region "Heal"
                        'Handles Heal
                        If spell.ToString.Contains("h") Then

                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Heal"
                                Summ1Timer = 240
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Heal"
                                Summ2Timer = 240
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Heal"
                                Summ3Timer = 240
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Heal"
                                Summ4Timer = 240
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Heal"
                                Summ5Timer = 240
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Heal"
                                Summ6Timer = 240
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If
                        End If
#End Region
#Region "Ignite"
                        'Handles Ignite
                        If spell.ToString.Contains("i") Then

                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Ignite"
                                Summ1Timer = 210
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Ignite"
                                Summ2Timer = 210
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Ignite"
                                Summ3Timer = 210
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Ignite"
                                Summ4Timer = 210
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Ignite"
                                Summ5Timer = 210
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Ignite"
                                Summ6Timer = 210
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If
                        End If
#End Region
#Region "Teleport"
                        'Handles Teleport
                        If spell.ToString.Contains("t") Then

                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Teleport"
                                Summ1Timer = 300
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Teleport"
                                Summ2Timer = 300
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Teleport"
                                Summ3Timer = 300
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Teleport"
                                Summ4Timer = 300
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Teleport"
                                Summ5Timer = 300
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Teleport"
                                Summ6Timer = 300
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If
                        End If
#End Region
#Region "Cleanse"
                        'Handles Cleanse
                        If spell.ToString.Contains("c") Then

                            If Summ1InUse = False Then
                                Summ1ChampName = champName
                                Summ1InUse = True
                                Summ1 = "Cleanse"
                                Summ1Timer = 210
                                Summ1SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ2InUse = False Then
                                Summ2ChampName = champName
                                Summ2InUse = True
                                Summ2 = "Cleanse"
                                Summ2Timer = 210
                                Summ2SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ3InUse = False Then
                                Summ3ChampName = champName
                                Summ3InUse = True
                                Summ3 = "Cleanse"
                                Summ3Timer = 210
                                Summ3SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")

                            ElseIf Summ4InUse = False Then
                                Summ4ChampName = champName
                                Summ4InUse = True
                                Summ4 = "Cleanse"
                                Summ4Timer = 210
                                Summ4SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ5InUse = False Then
                                Summ5ChampName = champName
                                Summ5InUse = True
                                Summ5 = "Cleanse"
                                Summ5Timer = 210
                                Summ5SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            ElseIf Summ6InUse = False Then
                                Summ6ChampName = champName
                                Summ6InUse = True
                                Summ6 = "Cleanse"
                                Summ6Timer = 210
                                Summ6SpellCounter.Enabled = True
                                System.IO.File.WriteAllText(Path, "")
                            End If
                        End If
#End Region

                        ''End if should be above next below this comment
                    End If
                Next

            Catch ex As Exception

            End Try



        Else
            Me.TopMost = False
            Me.Hide()
        End If


    End Sub

    Private Sub SummSpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ1SpellCounter.Tick
        If Summ1InUse = True Then
            Summ1Timer = Summ1Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ1Timer)
            SummSpell1.Text = Summ1ChampName + Summ1 + ": " + stringTimer
            If Summ1Timer <= 0 Then
                SummSpell1.Text = Summ1ChampName + Summ1 + " Is Ready"
                Summ1InUse = False
            End If
        End If
    End Sub

    Private Sub Summ2SpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ2SpellCounter.Tick
        If Summ2InUse = True Then
            Summ2Timer = Summ2Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ2Timer)
            SummSpell2.Text = Summ2ChampName + Summ2 + ": " + stringTimer
            If Summ2Timer <= 0 Then
                SummSpell2.Text = Summ2ChampName + Summ2 + " Is Ready"
                Summ2InUse = False
            End If
        End If
    End Sub

    Private Sub Summ3SpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ3SpellCounter.Tick
        If Summ3InUse = True Then
            Summ3Timer = Summ3Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ3Timer)
            SummSpell3.Text = Summ3ChampName + Summ3 + " :  " + stringTimer
            If Summ3Timer <= 0 Then
                SummSpell3.Text = Summ3ChampName + Summ3 + " Is Ready"
                Summ3InUse = False
            End If
        End If
    End Sub

    Private Sub Summ4SpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ4SpellCounter.Tick
        If Summ4InUse = True Then
            Summ4Timer = Summ4Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ4Timer)
            SummSpell4.Text = Summ4ChampName + Summ4 + " :  " + stringTimer
            If Summ4Timer <= 0 Then
                SummSpell4.Text = Summ4ChampName + Summ4 + " Is Ready"
                Summ4InUse = False
            End If
        End If
    End Sub

    Private Sub Summ5SpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ5SpellCounter.Tick
        If Summ5InUse = True Then
            Summ5Timer = Summ5Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ5Timer)
            SummSpell5.Text = Summ5ChampName + Summ5 + " :  " + stringTimer
            If Summ5Timer <= 0 Then
                SummSpell5.Text = Summ5ChampName + Summ5 + " Is Ready"
                Summ5InUse = False
            End If
        End If
    End Sub

    Private Sub Summ6SpellCounter_Tick(sender As Object, e As EventArgs) Handles Summ6SpellCounter.Tick
        If Summ6InUse = True Then
            Summ6Timer = Summ6Timer - 1
            Dim stringTimer As String
            stringTimer = Convert.ToString(Summ6Timer)
            SummSpell6.Text = Summ6ChampName + Summ6 + " :  " + stringTimer
            If Summ6Timer <= 0 Then
                SummSpell6.Text = Summ6ChampName + Summ6 + " Is Ready"
                Summ6InUse = False
            End If
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class