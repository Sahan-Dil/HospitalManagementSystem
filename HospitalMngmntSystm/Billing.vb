Imports System.Data.SqlClient

Public Class Billing

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Patient.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        total()
        con.Open()
        Dim query As String
        query = ("INSERT INTO BillingTbl VALUES('" + TextBox1.Text + "' , '" + ComboBox1.SelectedValue.ToString() + "' , '" + TextBox2.Text + "' , '" + TextBox6.Text + "' , '" + TextBox3.Text + "' ,'" + TextBox4.Text + "', '" + TextBox5.Text + "' , '" + TextBox7.Text + "' , '" + TextBox8.Text + "' )")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("New Bill details added successfully!!!")
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

    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM BillingTbl"
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



    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillID()
        Display()
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM DiagnosisTbl WHERE PatientID=" + ComboBox1.SelectedValue.ToString() + " ", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            TextBox2.Text = reader(2)
            TextBox6.Text = reader(7)
        End While
        con.Close()

        con.Open()
        Dim cmd1 As New SqlCommand("SELECT * FROM PharmacyTbl WHERE PatientID=" + ComboBox1.SelectedValue.ToString() + " ", con)
        Dim adapter1 As New SqlDataAdapter(cmd1)
        Dim dt1 As New DataTable
        Dim reader1 As SqlDataReader
        reader1 = cmd1.ExecuteReader
        While reader1.Read
            TextBox3.Text = reader1(5)
        End While
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the Bill No that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM BillingTbl WHERE BillNo = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Bill is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            total()
            con.Open()
            Dim query As String
            query = ("UPDATE BillingTbl SET PatientID= '" + ComboBox1.SelectedValue.ToString() + "' , PatientName = '" + TextBox2.Text + "' ,DiagnosisCost = '" + TextBox6.Text + "', PharmacyCost = '" + TextBox3.Text + "', ChannelFee = '" + TextBox4.Text + "'  , DoctorCharges = '" + TextBox5.Text + "' ,  HospitalCharges = '" + TextBox7.Text + "' ,  Total = '" + TextBox8.Text + "'  WHERE BillNo = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Bill updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub total()
        Dim totalFees = Val(TextBox6.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox7.Text)
        TextBox8.Text = totalFees
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        db1.Show()

    End Sub
End Class