Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Module GeneralCode

    Public m_Con As String
    Public Function GetCon() As SqlConnection

        ' return SQL conneciton object

        Return New SqlConnection(m_Con)

    End Function

    Public Function GetConstr() As String

        ' return conneciton string

        Return m_Con


    End Function



    Public Function Myrst(ByVal strSQL As String, Optional ByVal strCon As String = "") As DataTable

        ' Myrstc.Rows(0)
        ' this also allows one to pass custom connection string - if not passed, then default


        If strCon = "" Then
            strCon = GetConstr()
        End If

        Dim mycon As New SqlConnection(strCon)

        Dim oReader As New SqlDataAdapter
        Dim rstData As New DataSet

        oReader.SelectCommand = New SqlCommand(strSQL, mycon)

        Try
            oReader.Fill(rstData)
        Finally
        End Try
        Return rstData.Tables(0)


    End Function

    Public Function MyrstEdit(ByVal strSQL As String, Optional ByVal strCon As String = "", _
                              Optional ByRef oReader As SqlDataAdapter = Nothing, _
                              Optional ByRef SQLCon As SqlConnection = Nothing) As DataTable

        ' Myrstc.Rows(0)
        ' this also allows one to pass custom connection string - if not passed, then default
        ' same as MyRst, but allows one to "edit" the reocrdset, and add to reocrdset and then commit the update.

        If strCon = "" Then
            strCon = GetConstr()
        End If

        SQLCon = New SqlConnection(strCon)
        SQLCon.Open()
        oReader = New SqlDataAdapter(strSQL, SQLCon)
        Dim rstData As New DataSet
        Dim cmdBuilder = New SqlCommandBuilder(oReader)
        'oReader.SelectCommand = New SqlCommand(strSQL, mycon)

        Try
            oReader.Fill(rstData)
            oReader.AcceptChangesDuringUpdate = True
        Finally
        End Try
        Return rstData.Tables(0)

    End Function



    Public Sub MySqlExecute(ByVal strSQL As String)

        ' general "easey" run sql action query (update, insert etc)

        Dim MySQL As New SqlCommand(strSQL, GetCon)
        MySQL.Connection.Open()
        MySQL.ExecuteNonQuery()


    End Sub

    Public Function qu(ByVal str As String) As String

        str = Replace(str, ";", "")   ' to prevent sql injection
        str = Replace(str, "(", "")
        ' to allow a select with a ' or " quote, lets escape them
        str = Replace(str, "'", "''")
        'str = Replace(str, """", "\""")

        Return "'" & str & "'"

    End Function



    Public Function MyrstEditR(ByVal strSQL As String, Optional ByVal strWhere As String = "ID = 0", _
                                                Optional ByVal strCon As String = "", _
                                                Optional ByRef oReader As SqlDataAdapter = Nothing, _
                                                Optional ByRef SQLCon As SqlConnection = Nothing) As DataTable

        ' this routine is same as "most" previous rst editors
        ' wants a "where clause" - if not adding, then using ID = 0
        ' Wwhen you execute a update, then PK of row is SET!!
        ' strSQL and strWhere should be seperate

        If strCon = "" Then strCon = m_Con
        SQLCon = New SqlConnection(strCon)

        oReader = New SqlDataAdapter(strSQL & " WHERE " & strWhere, SQLCon)
        Dim rstData As New DataTable
        Dim cmdBuilder = New SqlCommandBuilder(oReader)
        Dim strinsert As String = cmdBuilder.GetInsertCommand.CommandText & ";" & strSQL & " WHERE ID = SCOPE_IDENTITY()"
        Dim cmInsert As New SqlCommand
        Dim sparm As SqlParameter
        With cmInsert
            .CommandText = strinsert
            For Each sparm In cmdBuilder.GetInsertCommand.Parameters
                Dim dbTypet As New System.Data.SqlDbType
                dbTypet = GetDBType(sparm.DbType.GetType)
                'Select Case sparm.DbType
                '    Case DbType.String
                '        dbTypet = Data.SqlDbType.VarChar
                '    Case DbType.Date
                '        dbTypet = Data.SqlDbType.Date
                '    Case DbType.DateTime
                '        dbTypet = Data.SqlDbType.DateTime
                '    Case DbType.Currency
                '        dbTypet = Data.SqlDbType.SmallMoney
                '    Case DbType.Int32
                '        dbTypet = Data.SqlDbType.Int
                'End Select

                .Parameters.Add(New SqlParameter(sparm.ParameterName, dbTypet, sparm.Size, sparm.SourceColumn))
            Next sparm
        End With

        Try
            oReader.InsertCommand = cmInsert
            oReader.Fill(rstData)
        Catch
        End Try
        Return rstData


    End Function


    Private Function GetDBType(ByVal theType As System.Type) As SqlDbType
        Dim p1 As SqlClient.SqlParameter
        Dim tc As System.ComponentModel.TypeConverter
        p1 = New SqlClient.SqlParameter()
        tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType)
        If tc.CanConvertFrom(theType) Then
            p1.DbType = tc.ConvertFrom(theType.Name)
        Else
            'Try brute force
            Try
                p1.DbType = tc.ConvertFrom(theType.Name)
            Catch ex As Exception
                'Do Nothing
            End Try
        End If
        Return p1.SqlDbType
    End Function





End Module

