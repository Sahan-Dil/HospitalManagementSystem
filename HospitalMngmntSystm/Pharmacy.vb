Imports System.Data.SqlClient

Public Class Pharmacy

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Pharmacy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillID()
        Display()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim query As String
        query = ("INSERT INTO PharmacyTbl VALUES('" + TextBox1.Text + "' , '" + ComboBox3.SelectedValue.ToString() + "' , '" + TextBox8.Text + "' , '" + TextBox7.Text + "' , '" + TextBox6.Text + "' ,'" + TextBox4.Text + "' )")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("New Pharmacy Inventory added successfully!!!")
        con.Close()
        Display()
    End Sub
    Private Sub fillID()
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM DiagnosisTbl", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable
        adapter.Fill(tbl)
        ComboBox3.DataSource = tbl
        ComboBox3.DisplayMember = "PatientID"
        ComboBox3.ValueMember = "PatientID"
        con.Close()
    End Sub
    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM PharmacyTbl"
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

    Private Sub ComboBox3_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox3.SelectionChangeCommitted
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM DiagnosisTbl WHERE PatientID=" + ComboBox3.SelectedValue.ToString() + " ", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            TextBox8.Text = reader(2)
            TextBox7.Text = reader(3)
            TextBox6.Text = reader(4)
        End While
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the ID that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM PharmacyTbl WHERE ID = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Inventory is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox4.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            con.Open()
            Dim query As String
            query = ("UPDATE PharmacyTbl SET PatientID= '" + ComboBox3.SelectedValue.ToString() + "' , PatientName = '" + TextBox8.Text + "' ,Symptoms = '" + TextBox7.Text + "', Medicines = '" + TextBox6.Text + "', Cost = '" + TextBox4.Text + "' WHERE ID = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Inventory updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        db3.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class