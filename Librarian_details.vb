Imports System.Data.SqlClient

Public Class Librarian_details
    Public con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
    Private Sub Librarian_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            Using command As New SqlCommand("select * from libadmin", con)
                con.Open()
            End Using
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
                con.Open()
                Using command As New SqlCommand("[dbo].[usp_I_libadmin]", con)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Name", TextBox1.Text())
                    command.Parameters.AddWithValue("@address", TextBox5.Text())
                    command.Parameters.AddWithValue("@phoneno", Convert.ToInt64(TextBox2.Text()))
                    command.Parameters.AddWithValue("@DOB", DateTimePicker1.Value())
                    command.Parameters.AddWithValue("@email", TextBox3.Text())
                    MsgBox("records inserted sucessfully")

                    command.ExecuteNonQuery()

                End Using
            End Using
            Me.Hide()
            admin_password.Show()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub


End Class