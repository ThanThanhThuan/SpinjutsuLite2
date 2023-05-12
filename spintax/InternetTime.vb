Imports System
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Net.Cache
Imports System.IO

Public Class InternetTime

    Public Shared Function GetNistTime(Optional ByRef ErrorMessage As String = "") As DateTime
        'also get local time if cannot connect
        ErrorMessage = ""
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        'Dim dateTime As DateTime = DateTime.MinValue
        Dim dateTime As DateTime = DateTime.Now
        Dim request As HttpWebRequest = CType(WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b"), HttpWebRequest)
        request.Method = "GET"
        request.Accept = "text/html, application/xhtml+xml, */*"
        request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)"
        request.ContentType = "application/x-www-form-urlencoded"
        request.CachePolicy = New RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        If response.StatusCode = HttpStatusCode.OK Then
            Dim stream As StreamReader = New StreamReader(response.GetResponseStream())
            Dim html As String = stream.ReadToEnd()
            Dim time As String = Regex.Match(html, "(?<=\btime="")[^""]*").Value
            Dim milliseconds As Double = Convert.ToInt64(time) / 1000
            dateTime = New DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime()
        Else
            'Console.Out.WriteLine(response.ResponseUri)
            ErrorMessage = "ERROR"
        End If

        Return dateTime
    End Function
End Class

Public Class TimeUpdater

    Public Shared Sub Main(ByVal args As String())
        Dim t As TimeUpdater = New TimeUpdater()
        Dim time As String = t.updateToInternetTime()
        Console.Out.WriteLine("OS time updated to: " & time)
        System.Threading.Thread.Sleep(2500)
    End Sub

    Public Sub New()
    End Sub

    Private Sub SetDate(ByVal dateInYourSystemFormat As String)
        Dim proc = New System.Diagnostics.ProcessStartInfo()
        proc.UseShellExecute = True
        proc.WorkingDirectory = "C:\Windows\System32"
        proc.CreateNoWindow = True
        proc.FileName = "C:\Windows\System32\cmd.exe"
        proc.Verb = "runas"
        proc.Arguments = "/C date " & dateInYourSystemFormat
        Try
            System.Diagnostics.Process.Start(proc)
        Catch
            MessageBox.Show("Error to change time of your system")
            Application.ExitThread()
        End Try
    End Sub

    Private Sub SetTime(ByVal timeInYourSystemFormat As String)
        Dim proc = New System.Diagnostics.ProcessStartInfo()
        proc.UseShellExecute = True
        proc.WorkingDirectory = "C:\Windows\System32"
        proc.CreateNoWindow = True
        proc.FileName = "C:\Windows\System32\cmd.exe"
        proc.Verb = "runas"
        proc.Arguments = "/C time " & timeInYourSystemFormat
        Try
            System.Diagnostics.Process.Start(proc)
        Catch
            MessageBox.Show("Error to change time of your system")
            Application.ExitThread()
        End Try
    End Sub

    Private Function updateToLocalTime() As String
        Dim time As String = DateTime.Now.ToString("h:mm:ss tt")
        SetTime(time)
        Return time
    End Function

    Private Function updateToInternetTime() As String
        Dim time As String = InternetTime.GetNistTime().ToString("h:mm:ss tt")
        SetTime(time)
        Return time
    End Function
End Class
