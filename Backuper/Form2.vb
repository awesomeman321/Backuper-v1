Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.form2 IsNot Nothing Then
            For Each ite In My.Settings.form2
                LogInListBox1.AddItem(ite)

            Next
        End If
    End Sub

    Private Sub LogInButton1_Click(sender As Object, e As EventArgs) Handles LogInButton1.Click
        Form1.LogInNormalTextBox2.Text = LogInListBox1.SelectedItem.ToString
        Me.Close()
        Form1.Show()
    End Sub
End Class