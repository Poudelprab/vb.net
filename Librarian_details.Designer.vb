<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Librarian_details
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Librarian_details))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cphno = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.cname = New System.Windows.Forms.Label()
        Me.ccode = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cpassword = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cphno)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.cname)
        Me.Panel1.Controls.Add(Me.ccode)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.cpassword)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1279, 986)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Location = New System.Drawing.Point(931, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(197, 58)
        Me.Panel2.TabIndex = 28
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(593, 330)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(215, 26)
        Me.DateTimePicker1.TabIndex = 27
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(174, 404)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(211, 26)
        Me.TextBox5.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 398)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 32)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "address"
        '
        'cphno
        '
        Me.cphno.AutoSize = True
        Me.cphno.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cphno.Location = New System.Drawing.Point(45, 490)
        Me.cphno.Name = "cphno"
        Me.cphno.Size = New System.Drawing.Size(123, 32)
        Me.cphno.TabIndex = 24
        Me.cphno.Text = "Phone no"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(597, 421)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(211, 26)
        Me.TextBox3.TabIndex = 23
        '
        'cname
        '
        Me.cname.AutoSize = True
        Me.cname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cname.Location = New System.Drawing.Point(45, 323)
        Me.cname.Name = "cname"
        Me.cname.Size = New System.Drawing.Size(81, 32)
        Me.cname.TabIndex = 22
        Me.cname.Text = "Name"
        '
        'ccode
        '
        Me.ccode.AutoSize = True
        Me.ccode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccode.Location = New System.Drawing.Point(464, 330)
        Me.ccode.Name = "ccode"
        Me.ccode.Size = New System.Drawing.Size(79, 32)
        Me.ccode.TabIndex = 17
        Me.ccode.Text = "D O B"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(172, 330)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(211, 26)
        Me.TextBox1.TabIndex = 19
        '
        'cpassword
        '
        Me.cpassword.AutoSize = True
        Me.cpassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpassword.Location = New System.Drawing.Point(467, 414)
        Me.cpassword.Name = "cpassword"
        Me.cpassword.Size = New System.Drawing.Size(76, 32)
        Me.cpassword.TabIndex = 18
        Me.cpassword.Text = "email"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(174, 491)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(211, 26)
        Me.TextBox2.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(344, 602)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 41)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Librarian_details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 991)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Librarian_details"
        Me.Text = "Librarian_details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cphno As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents cname As Label
    Friend WithEvents ccode As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cpassword As Label
    Friend WithEvents TextBox2 As TextBox
End Class
