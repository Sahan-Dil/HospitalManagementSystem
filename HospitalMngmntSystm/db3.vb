Imports System.Data.SqlClient

Public Class db3
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub db1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        con.Open()
        Dim query1 As String = "SELECT COUNT(*) FROM DoctorTbl"
        Dim cmd1 As SqlCommand = New SqlCommand(query1, con)
        Dim count1 As String
        count1 = cmd1.ExecuteScalar
        Label2.Text = "Doctors :  " + count1

        Dim query2 As String = "SELECT COUNT(*) FROM ReceptionistTbl"
        Dim cmd2 As SqlCommand = New SqlCommand(query2, con)
        Dim count2 As String
        count2 = cmd2.ExecuteScalar
        Label3.Text = "Receptionist :  " + count2

        Dim query3 As String = "SELECT COUNT(*) FROM PharmacistTbl"
        Dim cmd3 As SqlCommand = New SqlCommand(query3, con)
        Dim count3 As String
        count3 = cmd3.ExecuteScalar
        Label4.Text = "Pharmacist :  " + count3

        Dim query4 As String = "SELECT COUNT(*) FROM PatientTbl"
        Dim cmd4 As SqlCommand = New SqlCommand(query4, con)
        Dim count4 As String
        count4 = cmd4.ExecuteScalar
        Label5.Text = "Patients :  " + count4

        con.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Pharmacy.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Refresh()
    End Sub
End Class