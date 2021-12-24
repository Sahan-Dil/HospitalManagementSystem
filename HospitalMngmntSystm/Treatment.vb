Imports System.Data.SqlClient

Public Class Treatment
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub Treatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim query As String
        query = ("INSERT INTO TreatmentTbl VALUES('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + TextBox6.Text + "' )")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("New Treatment added successfully!!!")
        con.Close()
        Display()
    End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM TreatmentTbl"
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the TreatmentID that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM TreatmentTbl WHERE TreatmentID = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Treatment is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            con.Open()
            Dim query As String
            query = ("UPDATE TreatmentTbl SET Description= '" + TextBox2.Text + "' , Cost = '" + TextBox6.Text + "' WHERE TreatmentID = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Treatment updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Diagnosis.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        db2.Show()
    End Sub
End Class