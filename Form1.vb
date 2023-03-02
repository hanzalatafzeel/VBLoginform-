Imports System.Data.OleDb
Public Class Form1

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data  Source=C:\Users\huzai\Documents\Login Form.accdb")

        ' Get username and password from text boxes
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Attempt to authenticate user
        Dim authenticated As Boolean = AuthenticateUser(username, password, connectionString)

        ' Display result to user
        If authenticated Then
            resultLabel.Text = "Login successful!"
        Else
            resultLabel.Text = "Incorrect username or password."
        End If

    End Sub


    Private Function AuthenticateUser(username As String, password As String, mycon As String) As Boolean
        ' Open connection to Access database
        Using connection As New OleDbConnection(mycon)
            connection.Open()

            ' Prepare SQL query
            Dim query As String = $"SELECT COUNT(*) FROM users WHERE username='{username}' AND password='{password}'"
            Dim command As New OleDbCommand(query, connection)

            ' Execute query and get result
            Dim count As Integer = CInt(command.ExecuteScalar())

            ' Return true if user exists and password is correct
            Return count > 0
        End Using
    End Function
    '    mycon.Open()

    'Dim mycmd As New OleDbCommand("Select * from Account where Uname = '" & TextBox1.Text & "' And My_Password '" & TextBox2.Text & "'", mycon)
    'Dim myread As OleDbDataReader = mycmd.ExecuteReader
    'If myread.Read Then
    '        MsgBox("Success")
    '        TextBox1.Clear()
    '        TextBox2.Clear()

    'Else
    '        MsgBox("The password or username seems incorrect")
    'End If
    '    mycon.Close()


    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Form2.Show()
    '    Me.Hide()
    'End Sub

End Class

'Imports System.Data.OleDb

'Public Class Form1
'    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
'        ' Connection string for Access database
'        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=login.accdb;Persist Security Info=False;"

'        ' Get username and password from text boxes
'        Dim username As String = usernameTextBox.Text
'        Dim password As String = passwordTextBox.Text

'        ' Attempt to authenticate user
'        Dim authenticated As Boolean = AuthenticateUser(username, password, connectionString)

'        ' Display result to user
'        If authenticated Then
'            resultLabel.Text = "Login successful!"
'        Else
'            resultLabel.Text = "Incorrect username or password."
'        End If
'    End Sub

'    Private Function AuthenticateUser(username As String, password As String, connectionString As String) As Boolean
'        ' Open connection to Access database
'        Using connection As New OleDbConnection(connectionString)
'            connection.Open()

'            ' Prepare SQL query
'            Dim query As String = $"SELECT COUNT(*) FROM users WHERE username='{username}' AND password='{password}'"
'            Dim command As New OleDbCommand(query, connection)

'            ' Execute query and get result
'            Dim count As Integer = CInt(command.ExecuteScalar())

'            ' Return true if user exists and password is correct
'            Return count > 0
'        End Using
'    End Function
'End Class
