Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class admin
    Private Sub admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim con As SqlConnection = New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=SSPI")
            Dim cmd As SqlCommand = New SqlCommand("Select * from adminlogin ", con)

            cmd.CommandType = CommandType.StoredProcedure


        Catch ex As Exception

            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub clzpasslbl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub clzcodelbl_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub clzloginbtn_Click(sender As Object, e As EventArgs) Handles clzloginbtn.Click
        Try
            Dim username As String = TextBox.Text
            Dim password As String = TextBox2.Text

            Using connection As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
                connection.Open()

                Using command As New SqlCommand("[dbo].[ValidateUser]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", password)
                    command.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output

                    command.ExecuteNonQuery()

                    If CInt(command.Parameters("@result").Value) = 1 Then
                        ' User is valid
                        'MsgBox("Login successful!", vbInformation)
                        Me.Hide()
                        Collegeui.Show()


                        TextBox.Text = ""
                        TextBox2.Text = ""
                    Else
                        ' User is invalid
                        MsgBox("Invalid username or password.", vbCritical)
                    End If
                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub




    Private Sub clzcodelbl_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Frontpage.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Librarian_details.Show()

    End Sub
End Class