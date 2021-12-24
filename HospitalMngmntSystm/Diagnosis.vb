Imports System.Data.SqlClient

Public Class Diagnosis
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim query As String
        query = ("INSERT INTO DiagnosisTbl VALUES('" + TextBox1.Text + "' , '" + ComboBox1.SelectedValue.ToString() + "' , '" + TextBox2.Text + "' , '" + TextBox6.Text + "' , '" + TextBox3.Text + "' ,'" + TextBox4.Text + "', '" + ComboBox2.SelectedValue.ToString() + "', '" + TextBox7.Text + "' )")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("New Diagnosis added successfully!!!")
        con.Close()
        Display()
    End Sub

    Private Sub fillID()
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM PatientTbl", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable
        adapter.Fill(tbl)
        ComboBox1.DataSource = tbl
        ComboBox1.DisplayMember = "PatientID"
        ComboBox1.ValueMember = "PatientID"
        con.Close()
    End Sub

    Private Sub fillTreatment()
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM TreatmentTbl", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable
        adapter.Fill(tbl)
        ComboBox2.DataSource = tbl
        ComboBox2.DisplayMember = "Description"
        ComboBox2.ValueMember = "Description"
        con.Close()
    End Sub

    Private Sub Diagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillID()
        fillTreatment()
        Display()
    End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM DiagnosisTbl"
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


    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM PatientTbl WHERE PatientID=" + ComboBox1.SelectedValue.ToString() + " ", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            TextBox2.Text = reader(1)
        End While
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the DiagnosisID that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM DiagnosisTbl WHERE DiagnosisID = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Diagnosis is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox7.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            con.Open()
            Dim query As String
            query = ("UPDATE DiagnosisTbl SET PatientID= '" + ComboBox1.SelectedValue.ToString() + "' , PatientName = '" + TextBox2.Text + "' ,Symptoms = '" + TextBox6.Text + "', Medicines = '" + TextBox3.Text + "', Diagnosis = '" + TextBox4.Text + "' , Treatment  = '" + ComboBox2.SelectedValue.ToString() + "' , Cost = '" + TextBox7.Text + "'  WHERE DiagnosisID = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Diagnosis updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM TreatmentTbl WHERE Description='" + ComboBox2.SelectedValue.ToString() + "' ", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            TextBox7.Text = reader(2)
        End While
        con.Close()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Treatment.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        db2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class