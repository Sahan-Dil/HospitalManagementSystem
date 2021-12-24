Imports System.Data.SqlClient

Public Class Receptionist

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        con.Open()
        Dim query As String
        query = ("INSERT INTO ReceptionistTbl VALUES('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + TextBox3.Text + "' , '" + TextBox4.Text + "' , '" + TextBox5.Text + "')")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("Receptionist added successfully!!!")
        con.Close()
        Display()

    End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM ReceptionistTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Receptionist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the ReceptionistID that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM ReceptionistTbl WHERE ReceptionistID = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Receptionist is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            con.Open()
            Dim query As String
            query = ("UPDATE ReceptionistTbl SET ReceptionistName= '" + TextBox2.Text + "' , Password = '" + TextBox3.Text + "' ,Phone = '" + TextBox4.Text + "' ,Address = '" + TextBox5.Text + "' WHERE ReceptionistID = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Receptionist updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Doctor.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Pharmacist.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        db4.Show()

    End Sub
End Class