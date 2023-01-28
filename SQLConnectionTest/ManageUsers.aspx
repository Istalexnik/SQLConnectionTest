<%@ Page Title="Manage Users" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="ManageUsers.aspx.vb" Inherits="ManageUsers" %>

<asp:Content ID="ctnContent1" ContentPlaceHolderID="ctnHead" runat="server">
</asp:Content>

<asp:Content ID="ctnContent2" ContentPlaceHolderID="ctnPH" runat="server">
    Email:
    <br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    Password:
    <br />
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:DropDownList ID="ddRole" runat="server">
        <asp:ListItem Value="A">Admin</asp:ListItem>
        <asp:ListItem Selected="True" Value="U">User</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnSaveUser" runat="server" Text="Save" />
    <asp:Button ID="btnLoadUser" runat="server" Text="Load" />

    <asp:GridView ID="gvShowUsers" CssClass="GridLook" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" CellPadding="10"
        OnRowCancelingEdit="gvShowUsers_RowCancelingEdit" OnRowEditing="gvShowUsers_RowEditing" OnRowUpdating="gvShowUsers_RowUpdating" OnRowDeleting="gvShowUsers_RowDeleting">
        <Columns>


            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="lbEdit" runat="server" Text="Edit" CommandName="Edit" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="lbUpdate" runat="server" Text="Update" CommandName="Update" />
                    <asp:LinkButton ID="lbCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("col_userid") %>'>Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:LinkButton ID="aUserID" Text='<%# Eval("col_userid") %>' PostBackUrl='<%# String.Format("UserDetails.aspx?userid={0}", Eval("col_userid")) %>' runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("col_email") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("col_email") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("col_password") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPassword" runat="server" Text='<%#Eval("col_password") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("col_type") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtType" runat="server" Text='<%#Eval("col_type") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Access Level">
                <ItemTemplate>
                    <asp:Label ID="lblAccessLevel" runat="server" Text='<%# Eval("col_accesslevel") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAccessLevel" runat="server" Text='<%#Eval("col_accesslevel") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Person ID">
                <ItemTemplate>
                    <asp:Label ID="lblPersonID" runat="server" Text='<%# Eval("col_personid") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPersonID" runat="server" Text='<%#Eval("col_personid") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Username">
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("col_username") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%#Eval("col_username") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Create Date">
                <ItemTemplate>
                    <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("col_createdate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit Date">
                <ItemTemplate>
                    <asp:Label ID="lblEditDate" runat="server" Text='<%# Eval("col_editdate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="#663300" ForeColor="#ffffff" />
        <RowStyle BackColor="#e7ceb6" />
    </asp:GridView>
</asp:Content>
