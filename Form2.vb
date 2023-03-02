Imports System.Data.OleDb

Public Class Form2
    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\huzai\Documents\Login Form.accdb")
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mycon.Open()
        Dim mycmd As New OleDbCommand("Insert into Account (Uname , My_Password , Email , Mobile_Number) Values ('" & TextBox1.Text & "' , '" & TextBox2.Text & "' , '" & TextBox3.Text & "' , '" & TextBox4.Text & "')", mycon)
        Try
            mycmd.ExecuteNonQuery()
            mycon.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            MsgBox("Registered Successfully")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class