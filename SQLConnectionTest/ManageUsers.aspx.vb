
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class ManageUsers
    Inherits BasePage
    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Dim selectUserString As String = "SELECT col_username, col_password, col_role, col_createdate, col_editdate FROM tbl_siteuser"


    Private Sub EndEditing()
        Response.Redirect("./Default.aspx")
    End Sub

    Protected Sub btnSaveperson_Click(sender As Object, e As EventArgs) Handles btnSavePerson.Click
        If Not String.IsNullOrEmpty(txtUsername.Text) AndAlso Not String.IsNullOrEmpty(txtPassword.Text) Then
            InsertData("INSERT INTO tbl_siteuser (col_username, col_password, col_role) VALUES (@username, @password, @role)")
        End If
    End Sub

    Private Sub LoadGrid()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(selectUserString)
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                gvShowUsers.DataSource = cmd.ExecuteReader()
                gvShowUsers.DataBind()
                con.Close()
            End Using
        End Using
    End Sub
    Private Sub InsertData(statement As String)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(statement)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@role", ddRole.SelectedValue)

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()

                con.Close()
                EndEditing()
            End Using
        End Using
    End Sub

    Protected Sub btnLoadpersons_Click(sender As Object, e As EventArgs) Handles btnLoadPerson.Click
        LoadGrid()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadGrid()
        End If
    End Sub




    Protected Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Logon.aspx", True)
    End Sub
End Class

