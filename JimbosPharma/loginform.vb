Imports Guna.UI2.WinForms
Imports System.Data.SqlClient
Imports Tulpep.NotificationWindow
Imports System.IO


Public Class loginform
    Public Class GlobalUser
        Public Shared Username As String
        Public Shared Password As String
        Public Shared LastName As String
        Public Shared UserType As String
        Public Shared Status As String
        Public Shared EmailAddress As String
        Public Shared Contact As String
        Public Shared UserId As String
    End Class

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        ' Check if username or password fields are empty
        If Walanglamanuser(txtuser) OrElse Walanglamanuser(txtpass) Then Return

        ' SQL command to select user details
        cmd = New SqlClient.SqlCommand("SELECT * FROM tbluser WHERE Username = @username AND Password = @password", con)
        cmd.Parameters.AddWithValue("@username", txtuser.Text.Trim())
        cmd.Parameters.AddWithValue("@password", txtpass.Text.Trim())

        Try
            ' Open connection and execute command
            con.Open()
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' Assign user information to shared properties
                GlobalUser.Username = dr("Username").ToString()
                GlobalUser.Password = dr("Password").ToString()
                GlobalUser.LastName = dr("LastName").ToString()
                GlobalUser.UserType = dr("User_Type").ToString()
                GlobalUser.Status = dr("Status").ToString()
                GlobalUser.EmailAddress = dr("EmailAddress").ToString()
                GlobalUser.Contact = dr("Contact").ToString()
                GlobalUser.UserId = dr("ID").ToString()

                dr.Close()

                ' Check account status
                If GlobalUser.Status.Equals("active", StringComparison.OrdinalIgnoreCase) Then
                    ' Clear login fields
                    txtuser.Clear()
                    txtpass.Clear()

                    ' Handle user based on type
                    HandleUserType()
                Else
                    MsgBox("Access Denied! Inactive account.", vbExclamation)
                End If
            Else
                dr.Close()
                MsgBox("Access Denied! Invalid username or password.", vbExclamation)
            End If

        Catch ex As SqlClient.SqlException
            MsgBox("Database error: " & ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox("Unexpected error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            ' Ensure connection is properly closed
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


  Public Sub HandleUserType()
        ' Display a common message for all user types
        MsgBox("Access Granted! Welcome " & GlobalUser.LastName, vbInformation)

        Select Case GlobalUser.UserType
            Case "Cashier"
                frmsettle.lblsettle.Text = GlobalUser.Username
                cashier.btnreturn.Visible = False
                frmchangepass.oldpassword.Text = GlobalUser.Password
                frmchangepass.newpass.Text = GlobalUser.Password
                frmlock.lockpass.Text = GlobalUser.Password
                frmchangepass.struserrs.Text = GlobalUser.Username
                LoadImage(cashier.userpic, GlobalUser.UserId)
                cashier.btnreturns.Visible = False
                cashier.btnlogouts.Visible = True

                cashier.ShowDialog()

            Case "Staff"
                frmstaffboard.lbluser.Text = "Welcome, " & GlobalUser.LastName
                frmstockadjustment.txtadjusted.Text = GlobalUser.Username
                frmsettle.lblsettle.Text = GlobalUser.Username
                LoadImage(frmstaffboard.userpic, GlobalUser.UserId) ' Load staff image
                cashier.btnreturn.Visible = False
                frmqty.lblname.Text = GlobalUser.Username
                frmchangepass.oldpassword.Text = GlobalUser.Password
                frmlock.lockpass.Text = GlobalUser.Password
                frmstockadjustment.txtadjusted.Text = GlobalUser.Username
                LoadImage(frmstaffboard.userpic, GlobalUser.UserId)
                cashier.btnreturns.Visible = True
                cashier.btnlogouts.Visible = False
                frmstaffboard.ShowDialog()

            Case Else
                dashboard.lblcont.Text = GlobalUser.Contact
                dashboard.lbl2.Text = GlobalUser.EmailAddress
                frmqty.lblname.Text = GlobalUser.Username
                frmsettle.lblsettle.Text = GlobalUser.Username
                ' Load user image into the dashboard's PictureBox

                LoadImage(dashboard.userpic, GlobalUser.UserId)
                dashboard.ShowDialog()
        End Select
    End Sub

    Private Sub LoadImage(pictureBox As PictureBox, userId As String)


        Dim imageData As Byte() = GetUserImageData(userId)
        Try
            If imageData IsNot Nothing Then
                Using ms As New MemoryStream(imageData)
                    pictureBox.Image = Image.FromStream(ms)
                End Using
            Else
                pictureBox.Image = Nothing ' Clear the image if no data is available
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message)
        End Try



    End Sub

    Private Function GetUserImageData(userId As String) As Byte()
        Dim imageData As Byte() = Nothing
        Dim query As String = "SELECT imagepath FROM tbluser WHERE ID = @userId" ' imagepath stores the binary data

        Using cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@userId", userId)

            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso TypeOf result Is Byte() Then
                    imageData = CType(result, Byte())
                End If
            Catch ex As Exception
                MessageBox.Show("Error retrieving image data: " & ex.Message)
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using

        Return imageData
    End Function


    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs)
        Application.Exit()

    End Sub


    Private Sub loginform_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Guna2GradientButton1.PerformClick() ' Simulate a click  if ENTER on the login button

        End If
    End Sub


    Private Sub Button10_Click_1(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Guna2GradientButton2_Click_1(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Application.Exit()
    End Sub

    Private Sub txtpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpass.KeyDown
        txtpass.PasswordChar = "*"c

    End Sub




    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub


    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub



    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If txtpass.PasswordChar = ControlChars.NullChar Then
            ' Hide the password and change icon to "closed eye"
            txtpass.PasswordChar = "*"c
            PictureBox1.Image = My.Resources.eye ' Replace with your actual closed eye image
        Else
            ' Show the password and change icon to "open eye"
            txtpass.PasswordChar = ControlChars.NullChar
            PictureBox1.Image = Nothing ' Replace with your actual open eye image
        End If
    End Sub
End Class