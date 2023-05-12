﻿Imports System.IO
Imports CopyProtectSoftware
Imports CopyProtectSoftwareAppVB.UserControls
Public Class SpinForm
    Implements IMainForm

    Private CurrentFile As String = ""
    Public Shared LicenseType As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Clipboard.SetText(rtbOutput.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("You should have something at the Spinner text box")
            Return
        End If

        rtbOutput.Text = dospin(TextBox1.Text)
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("You should have something at the Spinner text box")
            Return
        End If
        rtbOutput.Text = dospin(TextBox1.Text)
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint, SplitContainer3.Panel1.Paint

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Computer.Clipboard.SetText(txtSpintax.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim spunlist As String = "{"
        For Each entry As String In txtList.Lines
            spunlist += entry + "|"
        Next
        spunlist = Mid(spunlist, 1, Len(spunlist) - 1)
        spunlist += "}"
        txtSpintax.Text = spunlist
    End Sub

    Private Sub SpinForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tooltip1 As New ToolTip
        tooltip1.SetToolTip(Me.Button1, "Generate an output from the above spintax and view it in the Output window")
        tooltip1.SetToolTip(Me.Button3, "Generate a new spun version using the same spintax")
        tooltip1.SetToolTip(Me.Button2, "Copy output to the clipboard")
        tooltip1.SetToolTip(Me.Button4, "Generate spintax from the list above")
        tooltip1.SetToolTip(Me.Button5, "Copy output to the clipboard")
        tooltip1.SetToolTip(Me.Button6, "Generate spintax from the list of videos, with 22 variants for each video")
        tooltip1.SetToolTip(Me.Button7, "Copy output to the clipboard")
        tooltip1.SetToolTip(Me.Button8, "Copy output to the clipboard")
        tooltip1.SetToolTip(Me.Button9, "Generate a spun result")
        tooltip1.SetToolTip(Me.Button8, "Generate a spun result")
        tooltip1.SetToolTip(Me.txtList, "Type or paste your list of items here, one item per line")
        tooltip1.SetToolTip(Me.TextBox5, "Type or paste your list of videos here, one item per line.  Ensure each entry contains the full URL as well as either &v= or ?v=")
        '---
        '' Identify what the first Link is.
        'Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(0, 8)

        '' Identify that the first link is visited already.
        'Me.LinkLabel1.Links(0).Visited = True

        ' Set the Text property to a string.
        'Me.LinkLabel1.Text = "Register Online.  Visit Microsoft.  Visit MSN."
        Me.LinkLabel1.Text = "Find out how Spinjutsu Pro can improve your productivity"
        ' Create new links using the Add method of the LinkCollection class.
        ' Underline the appropriate words in the LinkLabel's Text property.
        ' The words 'Register', 'Microsoft', and 'MSN' will 
        ' all be underlined and behave as hyperlinks.

        ' First check that the Text property is long enough to accommodate
        ' the desired hyperlinked areas.  If it's not, don't add hyperlinks.
        Dim txt = Me.LinkLabel1.Text
        Me.LinkLabel1.Links.Add(txt.IndexOf("Spinjutsu"), "Spinjutsu Pro".Length, "https://spinjutsu.net/")
        'If Me.LinkLabel1.Text.Length >= 45 Then
        '    Me.LinkLabel1.Links(0).LinkData = "Register"
        '    Me.LinkLabel1.Links.Add(24, 9, "www.microsoft.com")
        '    Me.LinkLabel1.Links.Add(42, 3, "www.msn.com")
        '    ' The second link is disabled and will appear as red.
        '    Me.LinkLabel1.Links(1).Enabled = False
        'End If
        '-----------------
        SetupLicensingOptions()
        Dim cmail As String = ""
        Dim cname As String = ""
        Dim ckey As String = ""
        Dim lastcontactlocal As String = "2000-01-01"
        Dim lastcontactnist As String = "2000-01-01"
        Dim datfile As String = Application.UserAppDataPath + "\appdata.txt"
        Dim PreviousActivation As New List(Of KV)
        Dim PreviousStatus As String = "none"
        If File.Exists(datfile) Then
            Try
                Dim dat As String = ""
                Decrypt(File.ReadAllText(datfile), "pw", dat)
                For Each l As String In dat.Split(vbNewLine)
                    l = l.Replace(vbLf, "")
                    PreviousActivation.Add(New KV With {.MKey = l.Split("=")(0), .MValue = l.Substring(l.Split("=")(0).Length + 1)})
                Next
                'ok or fail
                PreviousStatus = PreviousActivation.Find(Function(x) x.MKey = "activate").MValue
                cmail = PreviousActivation.Find(Function(x) x.MKey = "email").MValue
                cname = PreviousActivation.Find(Function(x) x.MKey = "name").MValue
                ckey = PreviousActivation.Find(Function(x) x.MKey = "key").MValue
                lastcontactlocal = PreviousActivation.Find(Function(x) x.MKey = "lastcontactlocal").MValue
                lastcontactnist = PreviousActivation.Find(Function(x) x.MKey = "lastcontactnist").MValue
                LicenseType = PreviousActivation.Find(Function(x) x.MKey = "licensetype").MValue
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        Dim DontCheckLicense As Boolean = False
        If PreviousStatus = "ok" Then
            'Dim ntime As DateTime = InternetTime.GetNistTime()
            'If CDate(lastcontactnist).AddDays(7) > ntime Then
            '    DontCheckLicense = True
            'End If
        End If
        If True Then 'Not DontCheckLicense Then
            '-------------------
            DisableApp()
            Application.DoEvents()
            Dim cpsValidate = New CpsValidate(Me)
            cpsValidate.ShowDialog()
        Else
            Me.ActivateToolStripMenuItem.Enabled = False
            Me.LabelMessage.Text = "Licensed to " & cname
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim TheURL As String = ""
        Dim VideoCode As String = ""
        Dim OneSpunVideo As String = ""
        Dim OneSpunEmbed As String = ""
        Dim SpunList As String = "{"
        Dim SpunListEmbeds As String = "{"

        For Each line As String In TextBox5.Lines
            line.Trim()
        Next

        For Each video As String In TextBox5.Lines
            VideoCode = GetVideoCode(video)
            If VideoCode <> "" Then
                OneSpunVideo = GetSpunVideoText(VideoCode)
                OneSpunEmbed = GetSpunEmbedCode(VideoCode)
                SpunList += OneSpunVideo + "|"
                SpunListEmbeds += OneSpunEmbed + "|"
            Else
                'frmSpinjutsu.log("Bad video URL " + video)
                MessageBox.Show("Bad video URL " + video)
            End If
        Next
        SpunList = Mid(SpunList, 1, Len(SpunList) - 1)
        SpunList += "}"
        TextBox6.Text = SpunList
        SpunListEmbeds = Mid(SpunListEmbeds, 1, Len(SpunListEmbeds) - 1)
        SpunListEmbeds += "}"
        TextBox7.Text = SpunListEmbeds
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text = TextBox6.Text
        rtbOutput.Text = dospin(TextBox1.Text)
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text = TextBox7.Text
        rtbOutput.Text = dospin(TextBox1.Text)
        TabControl1.SelectTab(1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        My.Computer.Clipboard.SetText(TextBox6.Text)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Computer.Clipboard.SetText(TextBox7.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Determine which link was clicked within the LinkLabel.
        Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True

        ' Displays the appropriate link based on the value of the LinkData property of the Link object.
        Dim target As String = CType(e.Link.LinkData, String)

        ' If the value looks like a URL, navigate to it.
        ' Otherwise, display it in a message box.
        If (target IsNot Nothing) AndAlso (target.StartsWith("http")) Then
            System.Diagnostics.Process.Start(target)
        Else
            MessageBox.Show(("Item clicked: " + target))
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.CurrentFile = OpenFileDialog1.FileName
        End If
        Me.TextBox1.Text = File.ReadAllText(Me.CurrentFile)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.DefaultExt = "*.txt"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt"
        SaveFileDialog1.CreatePrompt = True
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.rtbOutput.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.UnicodePlainText)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Do you want to quit Spinjutsu Lite ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            End
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.CurrentFile = "" Then
            SaveAsToolStripMenuItem_Click(SaveAsToolStripMenuItem, New EventArgs)
            Return
        End If
        If MessageBox.Show("Do you want to save output to " & Me.CurrentFile & " ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Me.rtbOutput.SaveFile(Me.CurrentFile, RichTextBoxStreamType.UnicodePlainText)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As New frmAboutBox
        f.ShowDialog()
    End Sub

    Private Sub CtrA_KeyPress(ByVal sender As Object, ByVal _
    e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, txtList.KeyPress, txtSpintax.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress
        'Crt+A = select ALL
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub
    Public Sub SetStatusLabel(ByVal txt As String)

        LabelMessage.Text = txt

    End Sub
    Private Sub SetupLicensingOptions()
        CpsSettings.LicenseUrl = "https://license.extellior.com"
        CpsSettings.SoftwareCode = "spintaxtoolset"
        'CpsSettings.LicenseUrl = "http://testclient.e-srv.com"
        'CpsSettings.SoftwareCode = "product1"
        'put any customizations for licensing dialogs here
        'otherwise will just use defaults
    End Sub

    Public Sub SetLicenseStatus(message As String) Implements IMainForm.SetLicenseStatus
        SetStatusLabel(message)
        'Throw New NotImplementedException()
    End Sub

    Public Sub EnableApp() Implements IMainForm.EnableApp
        Me.TabControl1.Enabled = True
        Me.OpenToolStripMenuItem.Enabled = True
        Me.SaveToolStripMenuItem.Enabled = True
        Me.SaveAsToolStripMenuItem.Enabled = True
        ActivateToolStripMenuItem.Enabled = False
        DeactivateToolStripMenuItem.Enabled = True
        'Throw New NotImplementedException()
    End Sub

    Public Sub DisableApp() Implements IMainForm.DisableApp
        Me.TabControl1.Enabled = False
        Me.OpenToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveAsToolStripMenuItem.Enabled = False
        ActivateToolStripMenuItem.Enabled = True
        DeactivateToolStripMenuItem.Enabled = False
        'Throw New NotImplementedException()
    End Sub
    Private Sub DoActivate()

        'Use internal activation dialog, or your own custom activation form

        'internal
        'Dim cpsActivate = new CpsActivate(Me)
        'cpsActivate.ShowDialog()

        'custom example
        Dim customActivate = New FrmCustomActivate()
        customActivate.ShowDialog(Me)

    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        DoActivate()
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        'show deactivate from license dialog
        Dim cpsDeactivate = New CpsDeactivate(Me)
        cpsDeactivate.ShowDialog()
    End Sub
    Public Shared Function Encrypt(plainText As String, pw As String) As String
        Dim password As String = pw & "dunn"
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return cipherText
    End Function
    Public Shared Function Decrypt(cipherText As String, pw As String, ByRef plainText As String) As Boolean
        Dim password As String = pw & "dunn"
        Dim wrapper As New Simple3Des(password)
        ' DecryptData throws if the wrong password is used.
        Try
            plainText = wrapper.DecryptData(cipherText)
            Return True
        Catch ex As System.Security.Cryptography.CryptographicException
            Return False
        End Try
    End Function
End Class
Public Class KV
    Private mKeyValue As String
    Public Property MKey() As String
        Get
            Return mKeyValue
        End Get
        Set(ByVal value As String)
            mKeyValue = value
        End Set
    End Property
    Private mValueValue As String
    Public Property MValue() As String
        Get
            Return mValueValue
        End Get
        Set(ByVal value As String)
            mValueValue = value
        End Set
    End Property

End Class