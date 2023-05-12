Module setup

    Public ds As New DataSet("RSS Feed")
    Public dt As New DataTable("RSS Items")

    Public bp As New System.Data.DataTable 'for BrowSEO
    Public bpname As String = ""
    Public bppath As String = ""

    Public catlist As New List(Of String)
    Public subcatlist As New List(Of String)
    Public abcatlist As New List(Of String)
    Public absubcatlist As New List(Of String)

    Public urllist As New List(Of String)
    Public rssfeedlist As New List(Of String)
    Public topiclist As New List(Of String)
    Public abtopiclist As New List(Of String)
    Public toprocess As New List(Of String)

    Public temp As String = ""
    '----
    Public category As String = ""
    Public subcat As String = ""
    Public topic As String = ""
    Public catpath As String = ""
    Public subcatpath As String = ""
    Public topicpath As String = ""
    '----
    Public abcategory As String = ""
    Public absubcat As String = ""
    Public abtopic As String = ""
    Public abcatpath As String = ""
    Public absubcatpath As String = ""
    Public abtopicpath As String = ""

    Public batchoutputpath As String = ""
    Public batchtemp As String = ""
    Public thearticle As String = ""
    'Public crlf As String = ControlChars.CrLf
    Public crlf As String = Environment.NewLine
    Public lineend As String = Environment.NewLine + Environment.NewLine
    Public nl As String = Environment.NewLine
    Public subheadingstyle As String = "RANDOM"
    Public subheadingmaster As String = "RANDOM"
    Public mydocs As String = ""
    Public mypics As String = ""
    Public thepath As String = ""
    Public rootpath As String = ""
    Public contentpath As String = ""
    Public spintaxpath As String = ""
    Public articlebuilderpath As String = ""
    Public picpath As String = ""
    Public staging As String = ""
    Public logpath As String = ""
    Public feedpath As String = ""
    Public projectpath As String = ""
    Public picpathsubcat As String = ""
    Public savetitle As String = ""
    Public savepdftitle As String = ""
    Public pathcurationintro As String = ""
    Public pathcurationoutro As String = ""
    Public htmlfull As String = ""
    Public htmlpath As String = ""
    Public picurlpath As String = ""
    Public rssfeedpath As String = ""
    Public projectfile As String = ""
    Public urlspath As String = ""
    Public workingcat As String = ""
    Public workingsubcat As String = ""
    Public thesubcat As String = ""
    Public thecat As String = ""
    Public picfolder As String = picpath + "\" + workingcat + "\" + workingsubcat
    Public picworking As String = picfolder
    Public thepicture As String = ""
    Public iframepicurl As String = ""
    Public htmlheaderalign As String = "center"
    Public precuration As String = ""
    Public curatedsegment As String = ""
    Public postcuration As String = ""
    Public videolistbase As String = "{https://youtube.com/watch?feature=youtu.be&v=VIDEOCODE|https://youtube.com/watch?feature=youtube_gdata&v=VIDEOCODE|https://www.youtube.com/watch?feature=youtu.be&v=VIDEOCODE|https://www.youtube.com/watch?feature=youtube_gdata&v=VIDEOCODE|https://youtu.be/VIDEOCODE|https://youtube.com/embed/VIDEOCODE|https://www.youtube.com/embed/VIDEOCODE|https://youtube.com/watch?feature=player_embedded&v=VIDEOCODE|https://www.youtube.com/watch?feature=player_embedded&v=VIDEOCODE|https://youtube.com/watch?v=VIDEOCODE|https://www.youtube.com/watch?v=VIDEOCODE|http://youtube.com/watch?feature=youtu.be&v=VIDEOCODE|http://youtube.com/watch?feature=youtube_gdata&v=VIDEOCODE|http://www.youtube.com/watch?feature=youtu.be&v=VIDEOCODE|http://www.youtube.com/watch?feature=youtube_gdata&v=VIDEOCODE|http://youtu.be/VIDEOCODE|http://youtube.com/embed/VIDEOCODE|http://www.youtube.com/embed/VIDEOCODE|http://youtube.com/watch?feature=player_embedded&v=VIDEOCODE|http://www.youtube.com/watch?feature=player_embedded&v=VIDEOCODE|http://youtube.com/watch?v=VIDEOCODE|http://www.youtube.com/watch?v=VIDEOCODE}"
    Public videolistmod As String = ""
    Public cat1 As String = ""
    Public subcat1 As String = ""
    Public topic1 As String = ""
    Public transition As String = ""
    Public lastsavepath As String = ""
    Public currentlyopenfile As String = ""
    Public browseodirdata As String = ""
    Public browseoexe As String = ""
    Public ExportFilename As String = ""
    Public rsstestfile As String = ""
    Public CurrentProject As String = ""

    Public curation As Boolean = False
    Public didcuration As Boolean = False
    Public curationsuccessful As Boolean = False
    Public batchmode As Boolean = False
    Public subheadings As New Boolean
    Public uselocalimage As Boolean = False
    Public iframepics As Boolean = False
    Public batchformattingidentical As Boolean = False
    Public builtcuration As Boolean = False
    Public curationtopical As Boolean = False
    Public curationauthor As Boolean = False
    Public links As Boolean = False
    Public madearticle As Boolean = True
    Public hasbrowseo As Boolean = False
    Public UseAllTopics As Boolean = False
    Public KeepBuilding As Boolean = False

    Public i As Integer
    Public j As Integer
    Public totaltopics As Integer
    Public nettopics As Integer
    Public abtotaltopics As Integer
    Public abnettopics As Integer
    Public thecatnum As Integer
    Public subcatnum As Integer
    Public batchneeded As Integer = 0
    Public batchmade As Integer = 0
    Public htmlheadingorder As Int32 = 1
    Public paragraphs As Int32 = 0
    Public modulesmade As Int32 = 0
    Public curationmaxtries As Integer = 5
    Public ForAdmin As Boolean = True

    Sub instantiate()
        bp.Columns.Add("Name")
        bp.Columns.Add("Path")

        ds.Tables.Add(dt)
        dt.Columns.Add("Entry", GetType(Integer))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Link", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("PubDate", GetType(String))
        dt.Columns.Add("GUID", GetType(String))


    End Sub

End Module
