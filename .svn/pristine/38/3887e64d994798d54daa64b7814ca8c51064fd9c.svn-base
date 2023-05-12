Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module converters

    Function GetVideoCode(ByVal theurl)
        GetVideoCode = ""
        Dim tempurl As String = ""
        Dim p1 As Boolean = False
        Dim p2 As Boolean = False
        Dim k As Int32 = 0
        Dim n As Int32 = 0
        If Uri.IsWellFormedUriString(theurl, UriKind.Absolute) Then
            If Mid(theurl, 1, 4) = "http" Then
                If Mid(theurl, 5, 1) = "s" Then
                    tempurl = Mid(theurl, 9, Len(theurl) - 8)
                Else
                    tempurl = Mid(theurl, 8, Len(theurl) - 7)
                End If
                k = tempurl.IndexOf("&v=")
                If k > 0 Then
                    tempurl = Mid(tempurl, k + 4, Len(tempurl) - k + 4)
                    p1 = True
                End If
                k = tempurl.IndexOf("?v=")
                If k > 0 Then
                    tempurl = Mid(tempurl, k + 4, Len(tempurl) - k + 4)
                    p1 = True
                End If
                If p1 Then
                    n = tempurl.IndexOf("?")
                    If n > 0 Then tempurl = Mid(tempurl, 1, n)
                    n = tempurl.IndexOf("&")
                    If n > 0 Then tempurl = Mid(tempurl, 1, n)
                    GetVideoCode = tempurl
                End If
            End If
        End If
        Return GetVideoCode
    End Function

    Function GetSpunVideoText(ByVal thecode)
        GetSpunVideoText = ""
        If thecode <> "" Then
            videolistmod = videolistbase
            videolistmod = videolistmod.Replace("VIDEOCODE", thecode)
            GetSpunVideoText = videolistmod
        End If
        Return GetSpunVideoText
    End Function

    Function GetSpunEmbedCode(ByVal thecode)
        GetSpunEmbedCode = ""
        If thecode <> "" Then
            'Dim iFrameStandard As String = "<iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/VIDEOCODE"" frameborder=""0"" gesture=""media"" allow=""encrypted-media"" allowfullscreen></iframe>"
            GetSpunEmbedCode = "<iframe {width=""656"" height=""369""|width=""662"" height=""372""|width=""660"" height=""371""|width=""560"" height=""315""} src=""https://www.youtube.com/embed/" + thecode + """"
            'Dim iFrameSeq As String = "{#A#B#C|#A#C#B|#B#A#C|#B#C#A|#C#A#B|#C#B#A}"
            'GetSpunEmbedCode += iFrameSeq.Replace("#A", "?rel=0").Replace("#B", "?controls=0").Replace("#C", "?showinfo=0") + """"
            'GetSpunEmbedCode += "{| frameborder=""0""}"
            'GetSpunEmbedCode += "{| gesture=""media""}"
            'GetSpunEmbedCode += "{| allow=""encrypted-media""}"
            'GetSpunEmbedCode += "{| allowfullscreen}"
            GetSpunEmbedCode += " frameborder=""0"" allowfullscreen"
            GetSpunEmbedCode += "></iframe>"
        End If
        Return GetSpunEmbedCode
    End Function

    Public Function findspace(ByVal s As String, ByVal n As Integer) As Integer
        Dim newFound As Integer = -1
        For i As Integer = 1 To n
            newFound = s.IndexOf(" ", newFound + 1)
            If newFound = -1 Then
                Return newFound
            End If
        Next
        Return newFound
    End Function

    Public Function WebSafeFileName(ByVal original As String)
        Dim pattern As String = "[^a-zA-Z0-9\-]+"
        Dim regex As New Regex(pattern)
        Dim filenameorig As String = Path.GetFileNameWithoutExtension(original)
        Dim filenamemod As String = regex.Replace(filenameorig, "-")
        WebSafeFileName = original.Replace(filenameorig, filenamemod)
        Return WebSafeFileName
    End Function


End Module
