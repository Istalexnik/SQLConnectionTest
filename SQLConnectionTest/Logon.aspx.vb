
Imports System.Data
Imports System.Data.SqlClient

Partial Class Logon
    Inherits BasePage

    Private Function ValidateUser(username As String, password As String) As Boolean
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim lookupPassword As String = ""

        If (username Is Nothing) OrElse (username.Length = 0) OrElse (username.Length > 20) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If

        If (password Is Nothing) OrElse (password.Length = 0) OrElse (password.Length > 20) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If

        Try
            con = New SqlConnection(constr)
            con.Open()
            cmd = New SqlCommand("Select col_password from tbl_siteuser where col_username=@username", con)
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 25)
            cmd.Parameters("@username").Value = username
            lookupPassword = CType(cmd.ExecuteScalar, String)

            cmd.Dispose()
            con.Dispose()
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message)
        End Try

        If String.IsNullOrEmpty(lookupPassword) Then
            Return False
        End If

        Return String.Compare(lookupPassword, password, False) = 0
    End Function


    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If ValidateUser(txtUsername.Value, txtPassword.Value) Then
            FormsAuthentication.RedirectFromLoginPage(txtUsername.Value, chbPersistCookie.Checked)
        Else
            Response.Redirect("logon.aspx", True)
        End If
    End Sub
End Class
