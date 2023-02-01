
Imports System.Activities
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing

Partial Class ManageUsers
    Inherits BasePage
    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Dim selectStatement As String = "SELECT col_userid, col_email, col_password, col_type, col_accesslevel, col_personid, col_username, col_createdate,  col_editdate FROM tbl_user order by col_createdate desc"
    Dim insertStatement As String = "INSERT INTO tbl_user (col_email, col_password, col_type) VALUES (@col_email, @col_password, @col_type)"
    Dim deleteStatement As String = "DELETE FROM tbl_user WHERE col_userid = @col_userid"
    Dim updateStatement As String = "UPDATE tbl_user SET col_email = @col_email, col_password = @col_password, col_type = @col_type, col_accesslevel = @col_accesslevel, col_username = @col_username, col_personid = @col_personid, col_editdate = CURRENT_TIMESTAMP where col_userid = @col_userid"

    Private Sub EndEditing()
        Response.Redirect("./Default.aspx")
    End Sub

    Protected Sub btnSaveperson_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso Not String.IsNullOrEmpty(txtPassword.Text) Then
            InsertData()
        End If
    End Sub

    Protected Sub btnLoaduser_Click(sender As Object, e As EventArgs) Handles btnLoadUser.Click
        LoadGrid()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadGrid()
        End If
    End Sub

    Private Sub LoadGrid()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(selectStatement, con)
                cmd.CommandType = CommandType.Text

                Using adapter As New SqlDataAdapter(cmd)
                    Using ds As New DataSet
                        adapter.Fill(ds)
                        gvShowUsers.DataSource = ds.Tables(0)
                        gvShowUsers.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub InsertData()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(insertStatement)
                cmd.CommandType = CommandType.Text

                cmd.Parameters.AddWithValue("@col_email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@col_password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@col_type", ddRole.SelectedValue)

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()

                con.Close()
                EndEditing()
            End Using
        End Using
    End Sub


    Protected Sub gvShowUsers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvShowUsers.PageIndexChanging
        gvShowUsers.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub

    Protected Sub gvShowUsers_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvShowUsers.EditIndex = -1
        LoadGrid()
    End Sub

    Protected Sub gvShowUsers_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvShowUsers.EditIndex = e.NewEditIndex
        LoadGrid()
    End Sub

    Protected Sub gvShowUsers_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(updateStatement)
                cmd.CommandType = CommandType.Text


                cmd.Parameters.AddWithValue("@col_userid", CType(gvShowUsers.Rows(e.RowIndex).FindControl("aUserID"), LinkButton).Text)
                cmd.Parameters.AddWithValue("@col_email", CType(gvShowUsers.Rows(e.RowIndex).FindControl("txtEmail"), TextBox).Text)
                cmd.Parameters.AddWithValue("@col_password", CType(gvShowUsers.Rows(e.RowIndex).FindControl("txtPassword"), TextBox).Text)
                cmd.Parameters.AddWithValue("@col_type", CType(gvShowUsers.Rows(e.RowIndex).FindControl("ddType"), DropDownList).SelectedValue)
                cmd.Parameters.AddWithValue("@col_accesslevel", CType(gvShowUsers.Rows(e.RowIndex).FindControl("txtAccessLevel"), TextBox).Text)
                cmd.Parameters.AddWithValue("@col_username", CType(gvShowUsers.Rows(e.RowIndex).FindControl("txtUsername"), TextBox).Text)
                cmd.Parameters.AddWithValue("@col_personid", CType(gvShowUsers.Rows(e.RowIndex).FindControl("txtPersonID"), TextBox).Text)

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                gvShowUsers.EditIndex = -1
                LoadGrid()
            End Using
        End Using
    End Sub

    Protected Sub gvShowUsers_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(deleteStatement)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@col_userid", CType(gvShowUsers.Rows(e.RowIndex).FindControl("aUserID"), LinkButton).Text)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                LoadGrid()
            End Using
        End Using
    End Sub
End Class

