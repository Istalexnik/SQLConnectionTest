<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="ManagePersons.aspx.vb" Inherits="ManagePersons" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ctnHead" runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 70%;
        }

        .auto-style2
        {
            height: 23px;
        }

        .auto-style3
        {
            height: 26px;
        }

        .auto-style4
        {
            height: 26px;
            width: 141px;
        }

        .auto-style5
        {
            width: 141px;
        }

        .auto-style6
        {
            height: 23px;
            width: 141px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctnPH" runat="Server">

<%--    turn off Enter key postback using JS--%>
    <script>$(document).keypress(
            function (event)
            {
                if (event.which == '13')
                {
                    event.preventDefault();
                }
            });</script>


    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label runat="server" Text="Person ID"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtPersonID" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Firstname"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstname" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Firstname is required"
                    ControlToValidate="txtFirstname" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label runat="server" Text="Lastname"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtLastname" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lastname is required"
                    ControlToValidate="txtLastname" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="DOB"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="DOB is required"
                    ControlToValidate="txtDOB" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Phone is required"
                    ControlToValidate="txtPhone" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is required"
                    ControlToValidate="txtAddress" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server">
                    <asp:ListItem>Tampa</asp:ListItem>
                    <asp:ListItem>Denver</asp:ListItem>
                    <asp:ListItem>Dallas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="State"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="FL">Florida</asp:ListItem>
                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td></td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Zip"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Zip is required"
                    ControlToValidate="txtZip" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Flagged"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkFlagged" runat="server" />
            </td>
            <td></td>

        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Create Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCreateDate" runat="server" />
            </td>
            <td></td>

        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label runat="server" Text="Edit Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEditDate" runat="server" />
            </td>
            <td></td>

        </tr>

        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
            <td></td>

        </tr>

        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Button ID="btnInsert" runat="server" Text="Insert" Font-Bold="True" Font-Size="Medium" />
                <asp:Button ID="btnsearch" runat="server" Text="Search" Font-Bold="True" Font-Size="Medium" Style="margin-left: 5px" CausesValidation="False" OnClick="btnsearch_Click" />
            </td>
        </tr>
    </table>

    <br />






    <div align="center">


        <asp:GridView ID="gvShowPersons" AutoGenerateColumns="false"  runat="server" BackColor="#CCCCCC" Width="80%" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="gvShowPersons_PageIndexChanging" OnSorting="gvShowPersons_Sorting"
            OnRowDeleting="gvShowPersons_RowDeleting" OnRowEditing="gvShowPersons_RowEditing" OnRowCancelingEdit="gvShowPersons_RowCancelingEdit" OnRowUpdating="gvShowPersons_RowUpdating">
            <Columns>

                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="60px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lbUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false" />
                        <asp:LinkButton ID="lbCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                    </EditItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px">
                    <ItemTemplate>
                        <asp:LinkButton OnClientClick="return confirm('Are you sure you want delete?');" ID="lbDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("col_personid") %>' CausesValidation="false">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Person ID" SortExpression="col_personid" ValidateRequestMode="Enabled">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPersonID" Text='<%# Eval("col_personid") %>' PostBackUrl='<%# String.Format("PersonDetails.aspx?personid={0}", Eval("col_personid")) %>' runat="server" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Firstname" SortExpression="col_firstname">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstname" runat="server" Text='<%# Eval("col_firstname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstname" runat="server" Text='<%#Eval("col_firstname") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>




                <asp:TemplateField HeaderText="Lastname" SortExpression="col_lastname">
                    <ItemTemplate>
                        <asp:Label ID="lblLastname" runat="server" Text='<%# Eval("col_lastname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastname" runat="server" Text='<%#Eval("col_lastname") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>






            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>


</asp:Content>

