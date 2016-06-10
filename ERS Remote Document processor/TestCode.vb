Imports System.Deployment.Application
Imports System.Reflection


Module Testcode

    Sub test1()

        Dim code As Assembly = Assembly.GetExecutingAssembly()
        Dim company As String = String.Empty
        Dim description As String = String.Empty

        If (Attribute.IsDefined(code, GetType(AssemblyCompanyAttribute))) Then
            Dim ascompany As AssemblyCompanyAttribute = _
                CType(Attribute.GetCustomAttribute(code, _
                GetType(AssemblyCompanyAttribute)), AssemblyCompanyAttribute)
            company = ascompany.Company
        End If
        If (Attribute.IsDefined(code, GetType(AssemblyDescriptionAttribute))) Then
            Dim asdescription As AssemblyDescriptionAttribute = _
                CType(Attribute.GetCustomAttribute(code, _
                GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute)
            description = asdescription.Description
        End If

        Debug.Print(company)


        'If (company.Length > 0 AndAlso description.Length > 0) Then
        '    Dim desktopPath As String = String.Empty
        '    desktopPath = String.Concat( _
        '        Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _
        '        "\", description, ".appref-ms")
        '    Dim shortcutName As String = String.Empty
        '    shortcutName = String.Concat( _
        '        Environment.GetFolderPath(Environment.SpecialFolder.Programs), _
        '        "\", company, "\", description, ".appref-ms")
        '    System.IO.File.Copy(shortcutName, desktopPath, True)
        'End If
        'End If
        'End If
    End Sub


End Module
