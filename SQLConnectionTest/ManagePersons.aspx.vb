
Imports System.CodeDom
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Net.Sockets
Imports System.Web.ApplicationServices

Partial Class ManagePersons
    Inherits BasePage

    Dim insertStatement As String = "insert into tbl_person(col_firstname, col_lastname, col_dob, col_phone,
col_address, col_city, col_state, col_zip, col_flagged) values (@col_firstname, @col_lastname, @col_dob,
@col_phone, @col_address, @col_city, @col_state, @col_zip, @col_flagged)"

    Dim selectStatement As String = "select * from tbl_person"

    Dim deleteStatement As String = "delete tbl_person where col_personid = @col_personid"

    Dim updateStatement As String = "update tbl_person set col_firstname = @col_firstname, col_lastname = @col_lastname 
where col_personid = @col_personid"

    Dim searchStatement As String = "select * from tbl_person where 1=1"

    'Dim testStatement As String = "select col_firstname from tbl_person where 1=1"


    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Dim con As SqlConnection = New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim sda As SqlDataAdapter
    Dim dt As DataTable

#Region "Insert"

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        cmd = New SqlCommand(insertStatement, con)


        'If String.IsNullOrEmpty(txtFirstname.Text) Then
        '  txtFirstname.Text = e.Rows("col_firstname")
        'End If

        cmd.Parameters.AddWithValue("@col_firstname", txtFirstname.Text)
        cmd.Parameters.AddWithValue("@col_lastname", txtLastname.Text)
        cmd.Parameters.AddWithValue("@col_dob", txtDOB.Text)
        cmd.Parameters.AddWithValue("@col_phone", txtPhone.Text)
        cmd.Parameters.AddWithValue("@col_address", txtAddress.Text)
        cmd.Parameters.AddWithValue("@col_city", ddlCity.SelectedValue)
        cmd.Parameters.AddWithValue("@col_state", rblState.SelectedValue)
        cmd.Parameters.AddWithValue("@col_zip", txtZip.Text)
        cmd.Parameters.AddWithValue("@col_flagged", chkFlagged.Checked)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Debug.WriteLine(ex.Message, "---------" & ex.ToString)
        Finally
            con.Close()
            MsgBox("Succesfully Inserted", vbSystemModal + vbInformation, "Message")
            LoadGrid()
        End Try
    End Sub

#End Region

#Region "Load"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadGrid()
        End If
    End Sub


    'Private Sub LoadGrid()
    '    cmd = New SqlCommand(selectStatement, con)
    '    sda = New SqlDataAdapter(cmd)
    '    dt = New DataTable
    '    sda.Fill(dt)
    '    gvShowPersons.DataSource = dt
    '    gvShowPersons.DataBind()
    'End Sub



    Private Sub LoadGrid(Optional sortExpression As String = Nothing)
        cmd = New SqlCommand(selectStatement, con)
        sda = New SqlDataAdapter
        sda.SelectCommand = cmd
        dt = New DataTable
        sda.Fill(dt)


        If Not sortExpression Is Nothing Then
            Dim dv As DataView = dt.AsDataView
            Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
            dv.Sort = sortExpression & " " & Me.SortDirection
            gvShowPersons.DataSource = dv
        Else
            gvShowPersons.DataSource = dt

        End If
        gvShowPersons.DataBind()

    End Sub

#End Region

#Region "Sort"

    Public  Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Protected Sub gvShowPersons_Sorting(sender As Object, e As GridViewSortEventArgs)
        LoadGrid(e.SortExpression)
    End Sub

#End Region

#Region "Edit"


    Protected Sub gvShowPersons_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvShowPersons.EditIndex = e.NewEditIndex
        LoadGrid()

    End Sub

    Protected Sub gvShowPersons_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvShowPersons.EditIndex = -1
        LoadGrid()
    End Sub

    Protected Sub gvShowPersons_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        cmd = New SqlCommand(updateStatement, con)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@col_firstname", CType(gvShowPersons.Rows(e.RowIndex).FindControl("txtFirstname"), TextBox).Text)
        cmd.Parameters.AddWithValue("@col_lastname", CType(gvShowPersons.Rows(e.RowIndex).FindControl("txtLastname"), TextBox).Text)
        cmd.Parameters.AddWithValue("@col_personid", CType(gvShowPersons.Rows(e.RowIndex).FindControl("lbPersonID"), LinkButton).Text)
        con.Open()
        cmd.ExecuteNonQuery()
        gvShowPersons.EditIndex = -1
        con.Close()
        LoadGrid()

    End Sub

#End Region

#Region "Delete"
    Protected Sub gvShowPersons_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        cmd = New SqlCommand(deleteStatement, con)
        cmd.Parameters.AddWithValue("@col_personid", CType(gvShowPersons.Rows(e.RowIndex).FindControl("lbPersonID"), LinkButton).Text)
        con.Open()
        cmd.ExecuteNonQuery()

        con.Close()
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "insertConfirmation", "<script>alert('The record is deleted');</script>")
        'MsgBox("Deleted Succesfully", vbSystemModal & vbInformation, "Message")
        LoadGrid()

    End Sub
#End Region

    Protected Sub gvShowPersons_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvShowPersons.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub




    Protected Sub btnsearch_Click(sender As Object, e As EventArgs)
        cmd = New SqlCommand()
        sda = New SqlDataAdapter(cmd)


        If Not String.IsNullOrWhiteSpace(txtPersonID.Text) Then
            searchStatement += " and col_personid like '%' + @col_personid + '%'"
            cmd.Parameters.AddWithValue("@col_personid", txtPersonID.Text)
        End If

        If Not String.IsNullOrWhiteSpace(txtFirstname.Text) Then
            searchStatement += " and col_firstname like '%' + @col_firstname + '%'"
            cmd.Parameters.AddWithValue("@col_firstname", txtFirstname.Text)
        End If

        If Not String.IsNullOrWhiteSpace(txtLastname.Text) Then
            searchStatement += " and col_lastname like '%'+ @col_lastname+ '%'"
            cmd.Parameters.AddWithValue("@col_lastname", txtLastname.Text)
        End If

        'If Not String.IsNullOrWhiteSpace(txtFirstname.Text) Then
        '    searchStatement += " and col_dob like '%'+ @col_dob+ '%'"
        '    cmd.Parameters.AddWithValue("@col_dob", txtDOB.Text)
        'End If

        If Not String.IsNullOrWhiteSpace(txtPhone.Text) Then
            searchStatement += " and col_phone like '%'+ @col_phone+ '%'"
            cmd.Parameters.AddWithValue("@col_phone", txtPhone.Text)

        End If

        If Not String.IsNullOrWhiteSpace(txtAddress.Text) Then
            searchStatement += " and col_address like '%'+ @col_address+ '%'"
            cmd.Parameters.AddWithValue("@col_address", txtAddress.Text)
        End If

        'If Not String.IsNullOrWhiteSpace(ddlCity.SelectedValue) Then
        '    searchStatement += " and col_city = @col_city"
        '    cmd.Parameters.AddWithValue("@col_city", ddlCity.SelectedValue)
        'End If

        'If Not String.IsNullOrWhiteSpace(rblState.SelectedValue) Then
        '    searchStatement += " and col_state = @col_state"
        '    cmd.Parameters.AddWithValue("@col_state", rblState.SelectedValue)

        'End If

        'If Not String.IsNullOrWhiteSpace(txtZip.Text) Then
        '    searchStatement += " and col_zip like '%'+ @col_zip+ '%'"
        '    cmd.Parameters.AddWithValue("@col_zip", txtZip.Text)

        'End If

        'If Not String.IsNullOrWhiteSpace(chkFlagged.Checked) Then
        '    searchStatement += " and col_flagged  = @col_flagged"
        '    cmd.Parameters.AddWithValue("@col_flagged", chkFlagged.Checked)
        'End If

        'If Not String.IsNullOrWhiteSpace(col_createdate.Text) Then
        '    searchStatement += " and col_createdate like '%'+ @col_createdate+ '%'"
        '    cmd.Parameters.AddWithValue("@col_createdate", txtCreateDate.Text)
        'End If

        'If Not String.IsNullOrWhiteSpace(col_editdate.Text) Then
        '    searchStatement += " and col_editdate like '%'+ @col_editdate+ '%'"
        '    cmd.Parameters.AddWithValue("@col_editdate", txtEditDate.Text)
        'End If


        cmd.CommandType = CommandType.Text
        cmd.CommandText = searchStatement
        cmd.Connection = con




        dt = New DataTable
        sda.Fill(dt)
        gvShowPersons.DataSource = dt
        gvShowPersons.DataBind()



    End Sub






End Class
