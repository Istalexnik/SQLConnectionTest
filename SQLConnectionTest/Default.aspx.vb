
Partial Class _Default
    Inherits BasePage


    Protected Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Logon.aspx", True)
    End Sub
End Class
