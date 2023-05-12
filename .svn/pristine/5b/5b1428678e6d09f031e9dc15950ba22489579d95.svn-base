Imports System.Text.RegularExpressions
Module spinbuilder
    Public Function GetTokens(str As String, Optional ByRef ids As List(Of Integer) = Nothing) As List(Of String)
        'get results between curlys
        Dim regex As New Regex("(?<=\{)[^}^{]*(?=\})", RegexOptions.IgnoreCase)
        Dim matches As MatchCollection = regex.Matches(str)
        Dim res = New List(Of String)
        ids = New List(Of Integer)
        For Each m As Match In matches
            'Add id and value (not including curly) to lists
            ids.Add(m.Index)
            res.Add(m.Value)
        Next
        Return res
    End Function
    Public Function dospin(text As String) As String
        If Not CheckSpintax(text) Then Return "Spintax {} Mismatch"
        Dim ids = New List(Of Integer)
        Dim res = New List(Of String)
        Dim chosens = New List(Of String)
        'Dim text = e.ToString
        'text = text.Replace(vbCrLf, "")
        Dim minus As Integer = 0
        Dim nm As Integer = 0
        'We will replace all curly patterns step by step, by a random option of its choices
        Do While text.Contains("{")
            nm += 1
            ids = New List(Of Integer)
            ' Get basic curly patterns - that means those not containing other curlys inside.
            ' ids are there index (position in the text)
            res = GetTokens(text, ids)
            chosens = New List(Of String)
            minus = 0
            For i = 0 To res.Count - 1

                Dim randomi As Integer = 0
                ' Initialize the random-number generator.
                Randomize()
                Dim count = res(i).Split("|"c).Length
                ' Generate random value between 1 and count. 
                randomi = CInt(Int((count * Rnd()) + 1)) - 1
                'select random choice in pattern
                Dim chosen = res(i).Split("|"c)(randomi)
                chosens.Add(chosen)
                'Replace that pattern with this choice, making the text shorter
                Dim before = text.Substring(0, ids(i) - minus - 1)
                Dim after = text.Substring(ids(i) - minus + res(i).Length + 1)
                Dim oldtext = text
                text = before & chosen & after
                'this is the change in text length, we remember to minus at index
                'for next loop, so that the index will fit with New text
                minus = minus + res(i).Length - chosen.Length + 2
            Next
        Loop

        Return text
    End Function
    Public Function CheckSpintax(text As String) As Boolean
        'check if all curlys are closed
        'Dim bracketPairs As Dictionary(Of Char, Char) = New Dictionary(Of Char, Char)() From {{"("c, ")"c}, {"{"c, "}"c}, {"["c, "]"c}, {"<"c, ">"c}}
        Dim bracketPairs As Dictionary(Of Char, Char) = New Dictionary(Of Char, Char)() From {{"{"c, "}"c}}
        Dim brackets As Stack(Of Char) = New Stack(Of Char)()
        Try
            For Each c As Char In text
                If bracketPairs.Keys.Contains(c) Then
                    brackets.Push(c)
                ElseIf bracketPairs.Values.Contains(c) Then
                    If c = bracketPairs(brackets.First()) Then
                        brackets.Pop()
                    Else
                        Return False
                    End If
                Else
                    Continue For
                End If
            Next
        Catch
            Return False
        End Try

        Return If(brackets.Count() = 0, True, False)
        '=======
        'If text.Count(Function(c As Char) c = "{"c) = text.Count(Function(c As Char) c = "}"c) Then
        '    Return True
        'End If
        'Return False
    End Function
End Module
