Imports System.Deployment.Application
Imports System.Reflection

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            'CheckForShortcut()
        End Sub

        Private Shared Sub CheckForShortcut()

            If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
                MsgBox("network")
                Dim ad As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
                'If (ad.IsFirstRun) Then 'first time user has run the app since installation or update
                If (True) Then 'first time user has run the app since installation or update
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
                    If (company.Length > 0 AndAlso description.Length > 0) Then
                        Dim desktopPath As String = String.Empty
                        desktopPath = String.Concat( _
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _
                            "\", description, ".appref-ms")
                        Dim shortcutName As String = String.Empty
                        shortcutName = String.Concat( _
                            Environment.GetFolderPath(Environment.SpecialFolder.Programs), _
                            "\", company, "\", description, ".appref-ms")
                        MsgBox("desktop = " & desktopPath)
                        MsgBox("shortcut = " & shortcutName)

                        '                        System.IO.File.Copy(shortcutName, desktopPath, True)
                    End If
                End If
            End If
        End Sub


    End Class



End Namespace

