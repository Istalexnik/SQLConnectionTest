
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Security.Policy

Partial Class Logon
    Inherits BasePage



    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If ValidateUser(txtEmail.Value, txtPassword.Value) Then

            FormsAuthentication.RedirectFromLoginPage(txtEmail.Value, chbPersistCookie.Checked)
        Else
            Response.Redirect("logon.aspx", True)
        End If
    End Sub




    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Dim status As Label = TryCast(Me.Master.FindControl("lblstatus"), Label)
    '    status.Text = "Logout"
    'End Sub


    Private Function ValidateUser(email As String, password As String) As Boolean
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim lookupPassword As String = ""

        Dim tb As TextBox = CType(Master.FindControl("txtMaster"), TextBox)

        tb.Text = "Something"


        If (email Is Nothing) OrElse (email.Length = 0) OrElse (email.Length > 20) Then
            Debug.WriteLine("[ValidateUser] Input validation of Email failed.")
            Return False
        End If

        If (password Is Nothing) OrElse (password.Length = 0) OrElse (password.Length > 20) Then
            Debug.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If

        Try
            con = New SqlConnection(constr)
            con.Open()
            cmd = New SqlCommand("Select col_password from tbl_user where col_email=@col_email", con)
            cmd.Parameters.Add("@col_email", SqlDbType.VarChar, 25)
            cmd.Parameters("@col_email").Value = email
            lookupPassword = CType(cmd.ExecuteScalar, String)

            cmd.Dispose()
            con.Dispose()
        Catch ex As Exception
            Debug.WriteLine("[ValidateUser] Exception " + ex.Message)
        End Try

        If String.IsNullOrEmpty(lookupPassword) Then
            Return False
        End If

        Return String.Compare(lookupPassword, password, False) = 0
    End Function




End Class
