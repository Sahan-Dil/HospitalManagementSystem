Imports System.Data.SqlClient

Public Class Login
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        If (ComboBox1.SelectedItem.ToString() = "Doctor") Then
            If (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show("Enter your ID and password!!!", "login")
            Else
                Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM DoctorTbl WHERE DoctorID='" + Val(TextBox1.Text).ToString + "' and Password='" + TextBox2.Text + "' ", con)
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Login Success", "login")
                    Me.Hide()
                    db2.Show()
                Else
                    MessageBox.Show("Login Failed", "login")
                End If
            End If
        ElseIf (ComboBox1.SelectedItem.ToString() = "Receptionist") Then
            If (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show("Enter your ID and password!!!", "login")
            Else
                Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM ReceptionistTbl WHERE ReceptionistID='" + Val(TextBox1.Text).ToString + "' and Password='" + TextBox2.Text + "' ", con)
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Login Success", "login")
                    Me.Hide()
                    db1.Show()
                Else
                    MessageBox.Show("Login Failed", "login")
                End If
            End If
        ElseIf (ComboBox1.SelectedItem.ToString() = "Pharmacist") Then
            If (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show("Enter your ID and password!!!", "login")
            Else
                Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM PharmacistTbl WHERE PharmacistID='" + Val(TextBox1.Text).ToString + "' and Password='" + TextBox2.Text + "' ", con)
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Login Success", "login")
                    Me.Hide()
                    db3.Show()
                Else
                    MessageBox.Show("Login Failed", "login")
                End If
            End If
        ElseIf (ComboBox1.SelectedItem.ToString() = "Admin") Then
            If (TextBox1.Text = "" Or TextBox2.Text = "") Then
                MessageBox.Show("Enter your ID and password!!!", "login")
            ElseIf (TextBox1.Text = "Admin" And TextBox2.Text = "1234") Then
                MessageBox.Show("Login Success", "login")
                Me.Hide()
                db4.Show()
            Else
                MessageBox.Show("Login Failed", "login")
            End If
        End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class