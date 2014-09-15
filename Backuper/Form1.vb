Imports System.IO
Imports sndir.Directory
Imports sndir.Connection
Imports System.ComponentModel

Public Class Form1

#Region "Configuration"
    Const Root As String = "C:\SirenNinja\Backuper"
    Const RootBack As String = Root + "\Backup"
    'Dim Config As String = "C:\SirenNinja\Backuper\config.cfg"
    Dim _textone As String = ""
    Dim _texttwo As String = ""
    Dim _namer As String = ""
    Public Shared Connecter As String = "N/A"
#End Region

#Region "Connection/Loading"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
        End Sub

    Private Sub LogInStatusBar1_Click(sender As Object, e As EventArgs) Handles LogInStatusBar1.Click
        Try
            Dim nameFolder As String = InputBox("Type a website. (Ex. www.google.com).")
            Try
                Connection(nameFolder)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\sndir.dll") Then
            MsgBox("sncd.dll is missing. Please redownload the program!")
            Application.Exit()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        snCreateDirectory(RootBack)
        Connection("www.google.com")
    End Sub

#End Region

#Region "Timer(s)"
    Private Sub Constant_Tick(sender As Object, e As EventArgs) Handles Constant.Tick

        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            Me.LogInThemeContainer1.Text = "Backuper (Administrator) [" + Me.Height.ToString + " , " + Me.Width.ToString + "]"
        Else
            Me.LogInThemeContainer1.Text = "Backuper (User) [" + Me.Height.ToString + " , " + Me.Width.ToString + "]"
        End If

        'Folder and file
        If LogInRadioButton4.Checked = True Then
            'LogInOnOffSwitch1.Visible = False
            'LogInOnOffSwitch1.Enabled = False
            LogInButton1.Enabled = False
            LogInButton2.Enabled = True
        Else
            'LogInOnOffSwitch1.Visible = False
            'LogInOnOffSwitch1.Enabled = False
            LogInButton2.Enabled = False
            LogInButton1.Enabled = True
        End If

        'Custom and program directory
        If LogInRadioButton1.Checked = True Then
            LogInButton3.Enabled = False
            LogInButton5.Enabled = False
            LogInNormalTextBox2.Text = RootBack
        Else
            LogInButton3.Enabled = True
            LogInButton5.Enabled = True
        End If

        'Start button
        If LogInRadioButton1.Checked = True Then
            If Not LogInNormalTextBox1.Text = Nothing Then
                LogInButton4.Enabled = True
            Else
                LogInButton4.Enabled = False
            End If
        Else
            If Not LogInNormalTextBox1.Text = Nothing And LogInButton3.Enabled = False Then
                LogInButton4.Enabled = True
            Else
                LogInButton4.Enabled = False
            End If

            If Not LogInNormalTextBox1.Text = Nothing And Not LogInNormalTextBox2.Text = Nothing Then
                LogInButton4.Enabled = True
            Else
                LogInButton4.Enabled = False
            End If
        End If

        LogInStatusBar1.Text = Connecter
    End Sub
#End Region

#Region "Buttons 1/2/3"
    Private Sub LogInButton1_Click(sender As Object, e As EventArgs) Handles LogInButton1.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            FolderBrowserDialog1.ShowNewFolderButton = True
            LogInNormalTextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If


    End Sub

    Private Sub LogInButton2_Click(sender As Object, e As EventArgs) Handles LogInButton2.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Open file"
        If LogInOnOffSwitch1.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
            ofd.Multiselect = True
        Else
            ofd.Multiselect = False
        End If
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            LogInNormalTextBox1.Text = ofd.FileName
        End If
        'MsgBox()
    End Sub

    Private Sub LogInButton3_Click(sender As Object, e As EventArgs) Handles LogInButton3.Click
        If FolderBrowserDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            FolderBrowserDialog2.ShowNewFolderButton = True
            LogInNormalTextBox2.Text = FolderBrowserDialog2.SelectedPath
        End If
    End Sub
#End Region

#Region "Gathering the files/creating stuff"
    Private Sub LogInButton4_Click(sender As Object, e As EventArgs) Handles LogInButton4.Click


        'Program Directory
        If LogInRadioButton1.Checked = True Then
            _texttwo = Root + "\Backup"

            'Folder
            If LogInRadioButton3.Checked = True Then
                LogInNormalTextBox2.Text = Root + "\Backup"
                Try
                    Dim dir1 As DirectoryInfo = New DirectoryInfo(LogInNormalTextBox1.Text)
                    If dir1.Exists Then
                        _textone = LogInNormalTextBox1.Text
                    Else
                        MsgBox(LogInNormalTextBox1.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If
                Catch ex As Exception

                End Try

                'File
            ElseIf LogInRadioButton4.Checked = True Then
                LogInNormalTextBox2.Text = Root + "\Backup"
                Try
                    Dim dir2 As FileInfo = New FileInfo(LogInNormalTextBox1.Text)
                    If dir2.Exists Then
                        _textone = LogInNormalTextBox1.Text
                    Else
                        MsgBox(LogInNormalTextBox1.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If
                Catch ex As Exception

                End Try

                'Error
            Else
                MsgBox("Nothing checked in settings?")
            End If









            'Custom Directory
        ElseIf LogInRadioButton2.Checked = True Then


            'Folder
            If LogInRadioButton3.Checked = True Then
                Try
                    Dim dir3 As DirectoryInfo = New DirectoryInfo(LogInNormalTextBox1.Text)
                    If dir3.Exists Then
                        _textone = LogInNormalTextBox1.Text
                    Else
                        MsgBox(LogInNormalTextBox1.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If

                    Dim dir4 As DirectoryInfo = New DirectoryInfo(LogInNormalTextBox2.Text)
                    If dir4.Exists Then
                        _textone = LogInNormalTextBox2.Text
                    Else
                        MsgBox(LogInNormalTextBox2.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If
                Catch ex As Exception

                End Try

                'File
            ElseIf LogInRadioButton4.Checked = True Then
                Try
                    Dim dir5 As FileInfo = New FileInfo(LogInNormalTextBox1.Text)
                    If dir5.Exists Then
                        _textone = LogInNormalTextBox1.Text
                    Else
                        MsgBox(LogInNormalTextBox1.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If

                    Dim dir6 As DirectoryInfo = New DirectoryInfo(LogInNormalTextBox2.Text)
                    If dir6.Exists Then
                        _textone = LogInNormalTextBox2.Text
                    Else
                        MsgBox(LogInNormalTextBox2.Text + " doesn't exist!", MsgBoxStyle.Critical, "Error")
                        Return
                    End If
                Catch ex As Exception

                End Try


                'Error
            Else
                MsgBox("Nothing checked in settings?")
                Return
            End If


            'Error
        Else
            MsgBox("Nothing checked in settings?")
            Return
        End If






        If _textone = Nothing And _texttwo = Nothing Then
        Else
            LogInLabel3.Visible = True
            Finish()
        End If
    End Sub

    Private Sub Finish()
        Dim nameFolderPublic As String = ""
        Try
            If LogInOnOffSwitch2.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
                Static nameFolder As String = InputBox("Please select a name to put the files in.")
                nameFolderPublic = nameFolder

                If LogInRadioButton3.Checked = True Then
                    My.Computer.FileSystem.CopyDirectory(LogInNormalTextBox1.Text, LogInNormalTextBox2.Text + "\" + nameFolder)
                    checkWithName(LogInNormalTextBox2.Text + "\" + nameFolderPublic, False)

                    If LogInOnOffSwitch3.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
                        Process.Start(LogInNormalTextBox2.Text + "\" + nameFolderPublic)
                    End If
                    LogInLabel3.Visible = False
                End If



                If LogInRadioButton4.Checked = True Then
                    My.Computer.FileSystem.CopyFile(LogInNormalTextBox1.Text, RootBack + "\" + nameFolderPublic + "\" + System.IO.Path.GetFileName(LogInNormalTextBox1.Text))
                    checkWithName(Root + "\Backup\" + nameFolderPublic + "\" + System.IO.Path.GetFileName(LogInNormalTextBox1.Text), True)

                    If LogInOnOffSwitch3.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
                        Process.Start(Root + "\Backup\" + nameFolderPublic)
                    End If
                    LogInLabel3.Visible = False
                End If

                If Not LogInNormalTextBox2.Text = RootBack Then
                    My.Settings.form2.Add(LogInNormalTextBox2.Text + "\" + nameFolderPublic)
                End If



            Else



                If LogInRadioButton3.Checked = True Then
                    My.Computer.FileSystem.CopyDirectory(LogInNormalTextBox1.Text, LogInNormalTextBox2.Text)
                    checkWithoutName(LogInNormalTextBox2.Text, False)

                    If LogInOnOffSwitch3.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
                        Process.Start(LogInNormalTextBox2.Text)
                    End If
                    LogInLabel3.Visible = False
                End If



                If LogInRadioButton4.Checked = True Then
                    My.Computer.FileSystem.CopyFile(LogInNormalTextBox1.Text, LogInNormalTextBox2.Text + "\" + System.IO.Path.GetFileName(LogInNormalTextBox1.Text))
                    checkWithoutName(LogInNormalTextBox2.Text + "\" + System.IO.Path.GetFileName(LogInNormalTextBox1.Text), True)

                    If LogInOnOffSwitch3.Toggled = LogInOnOffSwitch.Toggles.Toggled Then
                        Process.Start(LogInNormalTextBox2.Text)
                    End If
                    LogInLabel3.Visible = False
                End If



                If Not LogInNormalTextBox2.Text = Root + "\Backup" Then
                    My.Settings.form2.Add(LogInNormalTextBox2.Text)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub checkWithoutName(dest As String, file As Boolean)

        Try
            If file = False Then
                Dim dir As DirectoryInfo = New DirectoryInfo(dest)

                If dir.Exists Then
                    MsgBox("The folder has been backed up!")
                Else
                    MsgBox("Error: The folder wasn't backed up!")
                End If
            Else
                Dim fil As FileInfo = New FileInfo(dest)

                If fil.Exists Then
                    MsgBox("The file has been backed up!")
                Else
                    MsgBox("Error: The file wasn't backed up!")
                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub checkWithName(dest As String, file As Boolean)

        Try
            If file = False Then
                Dim dir As DirectoryInfo = New DirectoryInfo(dest)

                If dir.Exists Then
                    MsgBox("The folder has been backed up!")
                Else
                    MsgBox("Error: The folder wasn't backed up!")
                End If
            Else
                Dim fil As FileInfo = New FileInfo(dest)

                If fil.Exists Then
                    MsgBox("The file has been backed up!")
                Else
                    MsgBox("Error: The file wasn't backed up!")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "TextBox changes and stuff"
    Private Sub LogInRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles LogInRadioButton3.Click
        LogInNormalTextBox1.Text = ""
    End Sub

    Private Sub LogInRadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles LogInRadioButton4.Click
        LogInNormalTextBox1.Text = ""
    End Sub

    Private Sub LogInButton5_Click(sender As Object, e As EventArgs) Handles LogInButton5.Click
        Form2.Show()
    End Sub

    Private Sub LogInRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles LogInRadioButton2.Click
        LogInNormalTextBox2.Text = ""
    End Sub
#End Region


End Class
