Imports System.Data.SqlClient

Public Class stockk
    Public con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")

    Private Sub stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        GetData()
        GetData1()
        Timer1.start()
        con.Close()
    End Sub


    Private Sub GetData()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("SELECT * FROM book", con)
            ' command.CommandType = CommandType.StoredProcedure

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView2.DataSource = dataTable
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            con.Open()
            Dim command As New SqlCommand("SELECT * FROM book WHERE bookname = @bookname", con)
            command.Parameters.AddWithValue("@bookname", TextBox1.Text())

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView2.DataSource = dataTable
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub GetData1()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("SELECT * FROM stock", con)
            ' command.CommandType = CommandType.StoredProcedure

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable
        End Using
    End Sub
    Private Sub refreshstockdata()
        GetData1()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            con.Open()
            Dim command As New SqlCommand("SELECT * FROM stock WHERE bookid = @bookid", con)
            command.Parameters.AddWithValue("@bookid", ComboBox1.Text())

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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Collegeui.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        refreshstockdata()
    End Sub
End Class