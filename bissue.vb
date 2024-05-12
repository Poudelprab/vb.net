Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports project1.LibraryManagementDataSet1TableAdapters
Public Class bissue
    Public con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
    Private Sub bissue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim cmd As SqlCommand = New SqlCommand("Select * from issue", con)
            con.Open()
            GetData()
            GetData1()
            GetData2()
            '  PopulateComboBox1()
            PopulateComboBox2()
            con.Close()
            ' cmd.CommandType = CommandType.StoredProcedure


        Catch ex As Exception

            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub GetData()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("Select * from issue", con)
            ' command.CommandType = CommandType.StoredProcedure

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable
        End Using
    End Sub

    Private Sub GetData1()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("Select * from student", con)
            ' command.CommandType = CommandType.StoredProcedure

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView2.DataSource = dataTable
        End Using
    End Sub


    Private Sub GetData2()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("Select * from book", con)
            ' command.CommandType = CommandType.StoredProcedure

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            DataGridView3.DataSource = dataTable
        End Using
    End Sub








    Private Function CountIssuedBooks(studentId As String) As Integer
        Dim count As Integer = 0

        Try
            con.Open()
            Using command As New SqlCommand("[dbo].[usp_GetIssuedBooksCount]", con)
                command.Parameters.AddWithValue("@studentid", studentId)
                command.CommandType = CommandType.StoredProcedure
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try

        Return count
    End Function





    Private Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
        Try
            ' Retrieve the customizable value from the database
            Dim maxBooksAllowed As Integer = GetMaxBooksAllowedFromDatabase()

            ' Check if the student has already issued the maximum number of books
            If CountIssuedBooks(ComboBox1.Text()) >= maxBooksAllowed Then
                MsgBox("You have already reached the maximum limit of books that can be issued.", vbInformation)
                Return
            End If

            con.Open()

            ' Check if the book is in stock
            Dim checkStockQuery As String = "SELECT quantity FROM stock WHERE bookid = @bookid"
            Using checkStockCommand As New SqlCommand(checkStockQuery, con)
                checkStockCommand.Parameters.AddWithValue("@bookid", ComboBox2.Text())
                Dim stockQuantity As Integer = Convert.ToInt32(checkStockCommand.ExecuteScalar())

                ' If the book is out of stock, display a message and return
                If stockQuantity <= 0 Then
                    MsgBox("The book is currently out of stock.", vbInformation)
                    Return
                End If
            End Using

            Dim updateStockQuery As String = "UPDATE stock SET quantity = quantity - 1 WHERE bookid = @bookid"
            Using updateStockCommand As New SqlCommand(updateStockQuery, con)
                updateStockCommand.Parameters.AddWithValue("@bookid", ComboBox2.Text())
                updateStockCommand.ExecuteNonQuery()
            End Using

            Using command As New SqlCommand("[dbo].[usp_I_issue]", con)
                command.Parameters.AddWithValue("@studentid", ComboBox1.Text())
                command.Parameters.AddWithValue("@Name", TextBox4.Text())
                command.Parameters.AddWithValue("@bookid", ComboBox2.Text())
                command.Parameters.AddWithValue("@bookname", TextBox2.Text())
                command.Parameters.AddWithValue("issuedate", DateTimePicker1.Value())
                command.CommandType = CommandType.StoredProcedure
                command.ExecuteNonQuery()
            End Using

            GetData()

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try
    End Sub


    Private Function GetMaxBooksAllowedFromDatabase() As Integer
        Dim maxBooksAllowed As Integer ' Default value if retrieval from the database fails

        Try
            con.Open()
            Using command As New SqlCommand("SELECT MaxBooksAllowed FROM LibrarySettings", con)
                maxBooksAllowed = Convert.ToInt32(command.ExecuteScalar())
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try

        Return maxBooksAllowed
    End Function


    Private Sub stdid_Click(sender As Object, e As EventArgs) Handles stdid.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub bid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub



    '  Private Sub PopulateComboBox1()
    '      Try
    '       Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
    '            con.Open()
    'Dim command As New SqlCommand("SELECT studentid, Name FROM student", con)
    'Dim adapter As New SqlDataAdapter(command)
    'Dim dataTable As New DataTable()
    '
    '       adapter.Fill(dataTable)
    '
    ' ComboBox1.DisplayMember = "studentid"
    '    ComboBox1.ValueMember = "studentid"
    '            '   ComboBox1.DataSource = dataTable
    '  End Using
    ' Catch ex As Exception
    '        MsgBox(ex.Message, vbCritical)
    'End Try
    'End Sub



    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        '   Dim studentName As String = TextBox4.Text.Trim()
        '     If Not String.IsNullOrEmpty(studentName) Then
        '    Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
        '   con.Open()
        '  Dim command As New SqlCommand("SELECT studentid FROM student WHERE Name = @Name", con)
        'Command.Parameters.AddWithValue("@Name", studentName)

        '        Dim reader As SqlDataReader = command.ExecuteReader()
        '       If reader.HasRows Then
        '      reader.Read()
        '     ComboBox1.SelectedValue = reader("studentid").ToString()
        '    Else
        '   ComboBox1.SelectedValue = Nothing
        '  End If
        '
        '        reader.Close()
        '       End Using
        '      Else
        '     ComboBox1.SelectedValue = Nothing
        '    End If

    End Sub


    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Try
            con.Open()
            Using command As New SqlCommand("[dbo].[usp_u_issue]", con)
                command.Parameters.AddWithValue("@studentid", ComboBox1.Text())
                command.Parameters.AddWithValue("@Name", TextBox4.Text())
                command.Parameters.AddWithValue("@bookid", ComboBox2.Text())
                command.Parameters.AddWithValue("@bookname", TextBox2.Text())
                command.Parameters.AddWithValue("issuedate", DateTimePicker1.Value())
                command.CommandType = CommandType.StoredProcedure
                command.ExecuteNonQuery()

            End Using
            GetData()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
        con.Close()


    End Sub

    Private Sub PopulateComboBox2()
        Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
            Dim command As New SqlCommand("SELECT bookid, bookname FROM book", con)

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()

            adapter.Fill(dataTable)

            ' TextBox2.DisplayMember = "bookname"
            ComboBox2.ValueMember = "bookid"
            ComboBox2.DataSource = dataTable
        End Using
    End Sub

    Private Sub breset_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        GetData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Collegeui.Show()
    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        Dim bookName As String = TextBox2.Text.Trim()

        If Not String.IsNullOrEmpty(bookName) Then
            Using con As New SqlConnection("Data Source=PRABHAT\SQLEXPRESS;Initial Catalog=LibraryManagement;Integrated Security=True")
                con.Open()
                Dim command As New SqlCommand("SELECT bookid FROM book WHERE bookname = @bookname", con)
                command.Parameters.AddWithValue("@bookname", bookName)

                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    ComboBox2.SelectedValue = reader("bookid").ToString()
                Else
                    ComboBox2.SelectedItem = Nothing
                End If

                reader.Close()
            End Using
        Else
            ComboBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            con.Open()
            Dim command As New SqlCommand("SELECT * FROM student WHERE Name = @Name", con)
            command.Parameters.AddWithValue("@Name", TextBox4.Text())

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
End Class