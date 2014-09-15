Imports System.IO
Imports Backuper
Imports System.Windows.Forms

Public Class Directory

    Public Shared Sub SnCreateDirectory(directory As String)
        Dim dir1 As DirectoryInfo = New DirectoryInfo(directory)
        Try
            If dir1.Exists Then
                Console.WriteLine("That path already exists!")
                Return
            Else
                Dim result = MessageBox.Show(directory + " doesn't exist, would you like to create that directory?", "Backuper", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If result = DialogResult.Yes Then
                    dir1.Create()
                    Console.WriteLine("The directory was created successfully!")
                End If

                If result = DialogResult.No Then
                    Environment.Exit(0)
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
End Class
