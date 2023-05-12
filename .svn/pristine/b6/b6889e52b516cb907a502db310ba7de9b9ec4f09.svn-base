Imports System.IO
Imports System.Net
Imports System.Text
Imports CopyProtectSoftware

Public Class FrmCustomActivate
    Public Shared datfile As String = Application.UserAppDataPath + "\appdata.txt"
    Private Sub btnRequestActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestActivation.Click

        'Some simple validation
        If String.IsNullOrEmpty(txtEmail.Text) Then
            MessageBox.Show("Please enter the email address from your license email")
            Return
        End If

        If String.IsNullOrEmpty(txtFullName.Text) Then
            MessageBox.Show("Please enter your full name")
            Return
        End If

        If String.IsNullOrEmpty(txtTransactionID.Text) Then
            MessageBox.Show("Please paste the activation code from your license email")
            Return
        End If
        'CpsSettings.LicenseUrl = ""
        'Dim fromweb As String = ReturnHttpGET("https://s3.amazonaws.com/prodcodes/spinjutsu/prodcodesspintool.txt")
        ''fromweb = """Spinjutsu Spintax Accelerator - Annual"",""icme85gv""" & vbCrLf & """Spinjutsu Spintax Accelerator - Lifetime"",""ikrv7baex"""
        'Dim PrCodes As New List(Of KV)
        'For Each l As String In fromweb.Split(vbCrLf)
        '    If Not (l.Contains(""",""")) Then Continue For
        '    Dim k As String = l.Substring(0, l.IndexOf(""",")).Replace("""", "")
        '    Dim v As String = l.Substring(l.IndexOf(""",") + 2).Replace("""", "")
        '    PrCodes.Add(New KV With {.MKey = k, .MValue = v})
        'Next
        'Dim f = PrCodes.Find(Function(x) x.MKey.EndsWith(Me.cmbLicenseType.Text))
        'If Not f Is Nothing Then
        '    'WAIT CONFIRM PRODUCT CODE
        '    'CpsSettings.SoftwareCode = f.MValue
        'End If

        Dim sb7 As New StringBuilder
        sb7.Append("licenseurl=" & CpsSettings.LicenseUrl)
        sb7.AppendLine.Append("softwarecode=" & CpsSettings.SoftwareCode)
        sb7.AppendLine.Append("email=" & txtEmail.Text.Trim)
        sb7.AppendLine.Append("name=" & txtFullName.Text.Trim)
        sb7.AppendLine.Append("key=" & txtTransactionID.Text.Trim)
        sb7.AppendLine.Append("licensetype=" & Me.cmbLicenseType.Text)
        Dim ActOK As Boolean = False

        Dim cpsService = New CpsService
        Dim cpsServiceResult = New CpsServiceResult
        'txtTransactionID.Text = "kdjf8734kd"
        'txtTransactionID.Text = "mowe734mf"
        lblMessage.Text = "Contacting license server......"
        cpsServiceResult = cpsService.Activate(txtEmail.Text.Trim, txtTransactionID.Text.Trim, txtFullName.Text.Trim)
        lblMessage.Text = cpsServiceResult.Description

        'cpsServiceResult.Result = True
        If cpsServiceResult.Result Then
            'Activated
            btnRequestActivation.Enabled = False
            sb7.AppendLine.Append("activate=ok")
            ActOK = True
        Else
            'Activation issue
            btnRequestActivation.Enabled = True
            sb7.AppendLine.Append("activate=fail")
            ActOK = False
        End If
        sb7.AppendLine.Append("lastcontactlocal=" & Now.ToString("yyyy-MM-dd HH:mm:ss"))
        Dim err As String = ""
        Dim ntime As String = InternetTime.GetNistTime(err).ToString("yyyy-MM-dd HH:mm:ss")
        If err = "" Then
            sb7.AppendLine.Append("lastcontactnist=" & ntime)
        Else
            sb7.AppendLine.Append("lastcontactnist=none")
        End If
        File.WriteAllText(datfile, SpinForm.Encrypt(sb7.ToString, "pw"))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

    End Sub

    Private Sub FrmCustomActivate_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.txtFullName.Text = "THAN THANH THUAN"
        Me.txtEmail.Text = "sangxuan1406@gmail.com"
        Me.txtTransactionID.Text = "iuermvc789"
        'get stored LicenseType
        If Me.cmbLicenseType.Items.Contains(SpinForm.LicenseType) Then
            Me.cmbLicenseType.SelectedIndex = Me.cmbLicenseType.Items.IndexOf(SpinForm.LicenseType)
        Else
            Me.cmbLicenseType.SelectedIndex = 0
        End If
    End Sub
    Public Function ReturnHttpGET(ByVal URL As String) As String
        Try
            Dim uri As New Uri(URL)
            If (uri.Scheme = Uri.UriSchemeHttp OrElse uri.Scheme = Uri.UriSchemeHttps) Then
                Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
                request.Method = WebRequestMethods.Http.Get
                Dim response As HttpWebResponse = request.GetResponse()
                Dim reader As New IO.StreamReader(response.GetResponseStream())
                Dim tmp As String = reader.ReadToEnd()
                response.Close()
                Return tmp
            End If
        Catch ex As Exception
            Return "FAIL: " & ex.Message
        End Try

        Return "FAIL"
    End Function
End Class