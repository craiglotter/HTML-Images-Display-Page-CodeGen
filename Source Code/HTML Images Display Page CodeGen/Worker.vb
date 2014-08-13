Imports System.IO

Public Class Worker

    Inherits System.ComponentModel.Component

    ' Declares the variables you will use to hold your thread objects.

    Public WorkerThread As System.Threading.Thread


    Public filefolder As String = ""
    Public numberofcolumns As String = ""
    Public imagewidth As String = ""
    Public imageheight As String = ""
    Public downloadpath As String = ""
    Public RecursiveWalk As Boolean = False
    Public FolderWalkChosen As Boolean = True
    Public savefilepath As String = ""
    'Public AddNewDescriptor As Boolean = False



    Private filecount As Long = 0
    Private filecounter As Long = 0


    Public result As String = ""

    Public Event WorkerComplete(ByVal Result As String)
    Public Event WorkerProgress(ByVal filesrenamed As Long, ByVal currentfilename As String, ByVal totalfiles As Long)



#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message("The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString)
                Display_Message1.ShowDialog()
                Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
            End If
        Catch exc As Exception
            MsgBox("An error occurred in HTML Images Display Page CodeGen's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub



    Public Sub ChooseThreads(ByVal threadNumber As Integer)
        Try
            ' Determines which thread to start based on the value it receives.
            Select Case threadNumber
                Case 1
                    ' Sets the thread using the AddressOf the subroutine where
                    ' the thread will start.
                    WorkerThread = New System.Threading.Thread(AddressOf WorkerExecute)
                    ' Starts the thread.
                    WorkerThread.Start()

            End Select
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Public Sub WorkerExecute()
        Try
            filecount = 0
            filecounter = 0

            Dim testoutput As FileInfo = New FileInfo(savefilepath)
            If testoutput.Exists = True Then
                testoutput.Delete()
            End If
            testoutput = Nothing

            Try
                If FolderWalkChosen = True Then
                    Dim dir As DirectoryInfo = New DirectoryInfo(filefolder)
                    Dim filewriter As StreamWriter
                    filewriter = New StreamWriter(savefilepath, False)
                    filewriter.WriteLine("<table border=""0"" cellspacing=""0"" cellpadding=""4"">" & vbCrLf)
                    filewriter.Close()
                    If dir.Exists = True Then
                        FolderWalker(filefolder)
                    End If
                    filewriter = New StreamWriter(savefilepath, True)
                    filewriter.WriteLine("</table>" & vbCrLf)
                    filewriter.Close()
                    dir = Nothing
                Else
                    Dim fir As FileInfo = New FileInfo(downloadpath)
                    If fir.Exists = True Then
                        'TextFileWalker(downloadpath)
                    End If
                    fir = Nothing
                End If
            Catch ex As Exception
                Error_Handler(ex, "Moving Files")
            End Try


            result = "Success"
            RaiseEvent WorkerComplete(result)
        Catch ex As Exception
            result = "Failure"
            RaiseEvent WorkerComplete(result)
        End Try

        WorkerThread.Abort()
    End Sub

    Private Sub TextFileWalker(ByVal targetFile As String)
        Try

            Dim finfo As FileInfo = New FileInfo(targetFile)

            If finfo.Exists = True Then
                Dim filereader As StreamReader = New StreamReader(finfo.FullName)
                While filereader.Peek > -1
                    Dim apptorun As String
                    Dim lineread As String = ""
                    lineread = filereader.ReadLine
                    If (Not lineread Is Nothing) And (Not lineread = "") Then
                        apptorun = numberofcolumns.Replace("#inputtext#", lineread)
                        Log_Handler("Action Taken: " & apptorun)
                        result = ApplicationLauncher(apptorun)
                        filecounter = filecounter + 1
                        RaiseEvent WorkerProgress(filecounter, lineread, filecount)
                    End If

                End While
                filereader.Close()

            End If

            finfo = Nothing
        Catch ex As Exception
            Error_Handler(ex, "TextFileWalker")
        End Try
    End Sub 'TextFileWalker

    Private Sub FolderWalker(ByVal targetDirectory As String)
        Try
            Dim filewriter As StreamWriter
            Dim dinfo As DirectoryInfo = New DirectoryInfo(targetDirectory)
            Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
            filecount = filecount + Directory.GetFiles(targetDirectory).Length
            Dim fileName As String
            Dim currentcolumn As Integer = 1

            For Each fileName In fileEntries
                Try

                    Dim finfo As FileInfo = New FileInfo(fileName)
                    If Not finfo.Name.ToLower = "thumbs.db" Then
                        filewriter = New StreamWriter(savefilepath, True)

                        If currentcolumn = 1 Then
                            filewriter.WriteLine("<tr>")
                        End If
                        filewriter.WriteLine("<td align=""center"" valign=""top"">")
                        filewriter.WriteLine("<a target=""_blank"" href=""" & finfo.FullName.Replace(finfo.DirectoryName, downloadpath).Replace("\", "/").Replace("//", "/") & """>")
                        filewriter.Write("<img border=""0"" src=""" & finfo.FullName.Replace(finfo.DirectoryName, downloadpath).Replace("\", "/").Replace("//", "/") & """ ")
                        If Not imagewidth = "" And Not imagewidth = Nothing Then
                            filewriter.Write("width=""" & imagewidth & """ ")
                        End If
                        If Not imageheight = "" And Not imageheight = Nothing Then
                            filewriter.Write("height = """ & imageheight & """")
                        End If
                        filewriter.WriteLine("></a><br>")
                        filewriter.WriteLine(finfo.Name.Replace(finfo.Extension, "") & "</td>")


                        filewriter.WriteLine("</td>")
                        currentcolumn = currentcolumn + 1
                        If currentcolumn > numberofcolumns Then
                            filewriter.WriteLine("</tr>")
                            currentcolumn = 1
                        End If



                        filewriter.Close()
                        Dim apptorun As String
                        apptorun = "Added " & finfo.FullName
                        Log_Handler("Action Taken: " & apptorun)

                        filecounter = filecounter + 1

                    Else
                        Dim apptorun As String
                        apptorun = "Ignored " & finfo.FullName
                        Log_Handler("Action Taken: " & apptorun)
                    End If
                    finfo = Nothing

                Catch ex As Exception
                    Error_Handler(ex, "Processing Files")
                End Try
                RaiseEvent WorkerProgress(filecounter, fileName, filecount)
            Next fileName

            filewriter = New StreamWriter(savefilepath, True)
            While currentcolumn <> 1

                filewriter.WriteLine("<td align=""center"" valign=""top"">")

                filewriter.WriteLine("&nbsp;</td>")
                currentcolumn = currentcolumn + 1
                If currentcolumn > numberofcolumns Then
                    filewriter.WriteLine("</tr>")
                    currentcolumn = 1
                End If

            End While
            filewriter.Close()


            If RecursiveWalk = True Then
                Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
                Dim subdirectory As String
                For Each subdirectory In subdirectoryEntries

                    FolderWalker(subdirectory)

                Next subdirectory
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub 'ProcessDirectory


    Private Sub Log_Handler(ByVal identifier_msg As String)
        Try
            Dim dir As DirectoryInfo = New DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            Dim filewriter As StreamWriter = New StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)

            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy HH:mm:ss") & " - " & identifier_msg)


            filewriter.Flush()
            filewriter.Close()

        Catch exc As Exception
            'Error_Handler(exc, "Activity Logger")
            Error_Handler(exc)
        End Try
    End Sub


    Private Function ApplicationLauncher(ByVal AppToRun As String) As String
        Dim s As String = ""
        Try
            Dim myProcess As Process = New Process


            myProcess.StartInfo.UseShellExecute = False


            Dim sErr As StreamReader
            Dim sOut As StreamReader
            Dim sIn As StreamWriter


            myProcess.StartInfo.CreateNoWindow = True

            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True

            myProcess.StartInfo.FileName = "cmd.exe"

            myProcess.Start()
            sIn = myProcess.StandardInput
            sIn.AutoFlush = True

            sOut = myProcess.StandardOutput()
            sErr = myProcess.StandardError

            sIn.Write(AppToRun & System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()

            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If

            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()


        Catch ex As Exception
            Error_Handler(ex, "ApplicationLauncher")
        End Try
        Return s
    End Function
End Class
