Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class admin_password
    Public con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
    Private Sub admin_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        GetData1()
        con.Close()

    End Sub

    Private Sub clzloginbtn_Click(sender As Object, e As EventArgs) Handles clzloginbtn.Click
        Try

            con.Open()
            Using command As New SqlCommand("[dbo].[usp_I_InsertUser]", con)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@librarianid", TextBox1.Text())
                command.Parameters.AddWithValue("@username", TextBox.Text())
                command.Parameters.AddWithValue("@password", TextBox2.Text())
                MsgBox("records Inserted sucessfully")

                command.ExecuteNonQuery()

            End Using
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            con.Open()
            Dim command As New SqlCommand("SELECT * FROM libadmin WHERE Name =@Name", con)
            command.Parameters.AddWithValue("@Name", TextBox3.Text())

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub GetData1()

        Dim command As New SqlCommand("SELECT * FROM libadmin ", con)
        ' command.CommandType = CommandType.StoredProcedure

        Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        admin.Show()
    End Sub
End Class