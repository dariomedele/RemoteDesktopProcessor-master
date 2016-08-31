Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)> _
Public Class MyIndex

    Structure DocInfo
        Dim TagName As String
        Dim TagValue As String
    End Structure

    Dim m_TagToDescipt As New Collection         ' translate doc tags such as t,sh to Truck,ship to etc.

    Dim m_FilePrefix() As String

    Dim m_TagList As New ArrayList

    Dim m_DocDate As Date

    Public Sub ClearTags()
        ' clear the existing tag list
        m_TagList = Nothing
        m_TagList = New ArrayList

    End Sub

    Public Sub AddTag(ByVal strTagName As String, ByVal strTagValue As String)

        Dim OneSet As DocInfo

        If strTagName = "" Then
            strTagName = "Ticket Number"
        End If

        ' skip adding if Value = ""
        If strTagValue = "" Then Exit Sub

        OneSet.TagName = TagToDesc(MakeFileNameFriendly(strTagName))
        OneSet.TagValue = MakeFileNameFriendly(strTagValue)
        m_TagList.Add(OneSet)
        If OneSet.TagName = "Date" Then
            m_DocDate = DateTime.Parse(strTagValue)
        End If

    End Sub

    Public Function IndexDoc(ByVal strIndexUser As String, _
                             ByVal strDocNameWithPath As String, _
                             ByVal IndexByTagList As Boolean, _
                             Optional ByVal DocDate As Date = #12:00:00 AM#, _
                             Optional ByVal strDocType As String = "") As String


        'Call SetTagsToDesc(MetaTagsString, Metalabels)

        Dim lngID As Integer

        ' check if document exists in database
        Dim strDocName As String



        strDocName = Path.GetFileName(strDocNameWithPath)

        If InStr(strDocNameWithPath, "Archive") > 0 Then
            ' don't index archive
            Exit Function
        End If

        If (InStr(strDocName, " ") = 0) And (IndexByTagList = False) Then
            ' no spaces in file name, thus no tags, don't index
            Exit Function
        End If

        If strDocType = "" Then
            ' doc type was not passed, so auto gen from docuemnt name (first part of doc up to first space)
            strDocType = Split(strDocName, " ")(0)
        End If
        ' check if doc type is a legal type
        If strDocType <> "" Then
            If m_FilePrefix.Contains(strDocType) = False Then
                strDocType = ""
            End If
        End If

        If strDocType = "" Then
            ' don't index - just exit
            Return ""
        End If

        Dim TagList As New ArrayList
        Dim OneSet As DocInfo
        Dim dt As Date = Date.MinValue


        Dim db As SqlDataAdapter
        Dim rst As DataTable
        Dim strSQL As String = "select * from DocumentRef"
        Dim strWhere As String = "DocNameWithPath = " & qu(strDocNameWithPath)
        rst = MyrstEditR(strSQL, strWhere, , db)

        If rst.Rows.Count > 0 Then
            lngID = 0
        Else

            If IndexByTagList = False Then
                ' build the tag list from the file name
                TagList = GetTagsFromFile(strDocName, dt)
            Else
                ' we already have a tag list, use that
                TagList = m_TagList
                dt = m_DocDate
            End If

            With rst.Rows.Add
                .Item("DocTypeTag") = strDocType
                .Item("DocName") = strDocName
                .Item("DocNameWithPath") = strDocNameWithPath
                .Item("IndexByUser") = strIndexUser
                If dt > Date.MinValue Then
                    .Item("DocDate") = dt
                End If
            End With
            db.Update(rst)
            Debug.Print(rst.Rows(0).Item("ID").ToString)
            lngID = rst.Rows(0).Item("ID")
        End If

        ' if record already existed, then must be same record, 
        ' no need to re-gen child tags - 

        ' lngID = 0 is much a flag - if zero then record already 
        ' already existed - exit and skip child tags adding

        If lngID = 0 Then
            Return lngID.ToString
        End If

        ' now add child records


        Dim rstChild As DataTable
        rstChild = MyrstEdit("select * from DocumentRefTags where ID = 0", , db)

        Dim i As Integer = 1

        For Each OneSet In TagList
            If i > 1 Then
                If OneSet.TagName <> "Date" Then
                    With rstChild.Rows.Add
                        .Item("DocRef_ID") = lngID
                        .Item("TagName") = OneSet.TagName
                        .Item("TagValue") = OneSet.TagValue
                    End With
                End If
            End If
            i = i + 1
        Next
        db.Update(rstChild)

        Return "ok"

    End Function

 
    Public Function IndexDoct(ByVal strIndexUser As String, _
                                  ByVal strDocTypeTag As String, _
                                  ByVal strDocNameWithPath As String, _
                                  ByVal DocDate As Date, _
                                  ByVal MetaTagsString() As String, _
                                  ByVal Metalabels() As String, _
                                  ByVal strCon As String) As String

        ' test doc routine - NOT USED!
        ' Take passed connection var and convert to global var
        m_Con = strCon      ' this allows all code modules to use glocal m_Con


        Dim rst As New DataTable
        Dim strSQL As String
        Dim lngID As Integer

        ' check if document exists
        strSQL = "select * from DocumentRef where DocNameWithPath = " & qu(strDocNameWithPath)
        rst = Myrst(strSQL)
        If rst.Rows.Count > 0 Then
            lngID = rst.Rows(0).Item("ID")

            strSQL = "update DocumentRef set DocNameWithPath = @DocNameWithPath, " & _
                                             "DocTypeTag = @DocTypeTag, " & _
                                             "DocDate = @DocDate" & _
                     " where ID = " & lngID & _
                     ";SELECT " & lngID & " AS IDI"
        Else
            strSQL = "insert into DocumentRef ( DocNameWithPath, DocTypeTag, DocDate) " & _
                                      "VALUES (@DocNameWithPath,@DocTypeTag, @DocDate) " & _
                     ";SELECT SCOPE_IDENTITY() as IDI"
        End If

        Dim cmd As New SqlCommand(strSQL, GetCon)
        cmd.Parameters.AddWithValue("@DocNameWithPath", strDocNameWithPath)
        cmd.Parameters.AddWithValue("@DocTypeTag", strDocTypeTag)
        cmd.Parameters.Add("@DocDate", SqlDbType.DateTime).Value = DocDate
        cmd.Connection.Open()

        lngID = cmd.ExecuteScalar()

        ' if record already existed, then must be same record, 
        ' no need to re-gen child tags - but only parts of main doc record was change, so now just exit
        If lngID = 0 Then
            Return lngID.ToString
        End If

        ' now add child records
        ' only add child records if new:

        If rst.Rows.Count > 0 Then
            Return "no child add"
        End If

        Dim TagList(,) As String = New String(,) {{"Date", "08/07/2015"},
                                           {"Truck", "P220"},
                                           {"Driver", "Fred Dirks"}}

        Dim db As SqlDataAdapter
        Dim ChildRow As DataRow
        Dim rstChild As DataTable
        Dim i As Integer
        rstChild = MyrstEdit("select * from DocumentRefTags where ID = 0", , db)

        For i = 0 To UBound(TagList)
            ChildRow = rstChild.Rows.Add
            With ChildRow
                .Item("DocRef_ID") = lngID
                .Item("TagName") = TagList(i, 0)
                .Item("TagValue") = TagList(i, 1)
            End With
        Next
        db.Update(rstChild)

        Return "ok"

    End Function



    Public Function DeleteIndexDoc(ByVal strDocWithFullPath As String, ByVal strCon As String) As Boolean

        Dim strSQL As String

        strSQL = "delete from DocumentRef where DocNameWithPath = " & qu(strDocWithFullPath)

        m_Con = strCon
        MySqlExecute(strSQL)

        Return True
    End Function


    Public Function TestData() As String

        Dim rst As DataTable
        Dim str As String = ""

        rst = Myrst("select * from DocumentRef")
        If rst.Rows.Count > 0 Then
            With rst.Rows(0)
                str = .Item("IndexDate").ToString & " " & .Item("DocName")
            End With
        End If
        Return str

    End Function

    Public Function TestAdd(ByVal strC As String)

        Dim strDoc As String = "CDS d=Apr-01-2014 1 sh=C01730506.PDF"

        Dim db As SqlDataAdapter
        Dim rst As DataTable
        Dim strSQL As String = "select * from DocumentRef"
        Dim strWhere As String = "ID = 0"
        rst = MyrstEditR(strSQL, strWhere, strC, db)

        With rst.Rows.Add
            .Item("DocName") = "hello"
            .Item("DocNameWithPath") = strDoc
            .Item("IndexByUser") = "Albert"
            .Item("DocDate") = Date.Today
        End With
        db.Update(rst)
        Debug.Print(rst.Rows(0).Item("ID").ToString)


    End Function


    Public Function GetTagsFromFile(ByVal strDoc As String, ByRef dt As Date) As ArrayList

        Dim rlist As New ArrayList
        Dim OneSet As DocInfo

        Dim sv As String, sv2 As String
        Dim strToken As String
        Dim sth(,) As String
        Dim mainTags As String()
        Dim shold As String()
        mainTags = Split(strDoc, " ")       ' split out into sets

        ' first token is docuemnt type (CDS etc. - so no = sign
        Dim i As Integer = 1

        Dim intTagCount As Integer
        intTagCount = UBound(mainTags)

        For i = 0 To intTagCount
            'For Each strToken In mainTags
            strToken = mainTags(i)
            If i = 0 Then
                OneSet.TagName = "FileType"
                OneSet.TagValue = strToken
                rlist.Add(OneSet)
            Else
                If InStr(strToken, "=") > 0 Then
                    shold = Split(strToken, "=")
                    sv = shold(0)
                    If m_TagToDescipt.Contains(sv) Then
                        sv = m_TagToDescipt(sv)
                    End If
                    OneSet.TagName = sv
                    sv2 = shold(1)
                    If InStr(sv2, ".") > 0 Then
                        sv2 = Split(sv2, ".")(0)
                    End If
                    OneSet.TagValue = sv2
                    If OneSet.TagName = "Date" Then
                        If IsDate(OneSet.TagValue) Then
                            dt = OneSet.TagValue
                            'MsgBox("is date values are " & OneSet.TagName & ", " & OneSet.TagValue)
                        End If
                        rlist.Add(OneSet)
                    End If

                    ' check if truck and next token starts with T (trailer)
                    If sv = "Truck" Then
                        If i < intTagCount Then
                            If Left(mainTags(i + 1), 1) = "T" Then
                                OneSet.TagName = "Trailer"
                                OneSet.TagValue = mainTags(i + 1)
                                rlist.Add(OneSet)
                                i = i + 1
                            End If
                        End If
                    Else
                        ' assuime seq #
                        If Len(strToken) > 3 Then
                            OneSet.TagName = "REF"
                        Else
                            OneSet.TagName = "SEQ"
                        End If
                        OneSet.TagValue = strToken
                        If InStr(strToken, ".") = 0 Then
                            rlist.Add(OneSet)
                        Else
                            OneSet.TagName = "REF"
                            OneSet.TagValue = Split(strToken, ".")(0)
                            If Len(OneSet.TagValue) > 0 Then
                                rlist.Add(OneSet)
                            End If
                        End If
                    End If
                End If
                End If
        Next i

        Return rlist


    End Function


    Private Sub SetTagsToDesc(ByVal aTags() As String, ByVal aLabels() As String)

        Dim i As Integer
        Dim s As String
        For i = 0 To UBound(aTags)
            s = aTags(i)
            If InStr(s, "=") > 0 Then
                m_TagToDescipt.Add(aLabels(i).ToString, Split(s, "=")(0))
            End If
        Next

    End Sub

    Public Function TagToDesc(ByVal strTag As String) As String

        ' take the tag (with = sign) - remove = and convert to descripiton
        ' if value not found - then return the tag value
        Dim s As String

        If InStr(strTag, "=") > 0 Then
            s = Split(strTag, "=")(0)
            If m_TagToDescipt.Contains(s) Then
                Return m_TagToDescipt(s)
            Else
                Return strTag
            End If
        Else
            Return strTag
        End If

    End Function

    Public Sub New(ByVal MetaTagsString() As String, ByVal Metalabels() As String, ByVal FilePrefix() As String, ByVal strCon As String)

        ' Take passed connection var and convert to global var
        m_Con = strCon      ' this allows all code modules to use glocal m_Con

        m_FilePrefix = FilePrefix

        Call SetTagsToDesc(MetaTagsString, Metalabels)


    End Sub

    Private Function MakeFileNameFriendly(ByVal nameStr As String) As String
        'clean out illegal characters in a filename
        Dim replaceChar As Char
        Dim strIndex As Integer
        Dim i As Integer
        replaceChar = CChar("-")
        Dim ForbiddenFilenameChars As String = "\/:*?<>|"

        If Not nameStr Is Nothing Then
            For i = 0 To nameStr.Length - 1
                strIndex = ForbiddenFilenameChars.IndexOf(nameStr(i))
                If (strIndex >= 0) Then
                    nameStr = nameStr.Replace(ForbiddenFilenameChars(strIndex), replaceChar)
                End If
            Next
        End If
        Return nameStr
    End Function


End Class
