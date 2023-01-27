<%@ Page Title="Manage Users" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="ManageUsers.aspx.vb" Inherits="ManageUsers" %>

<asp:Content ID="ctnContent1" ContentPlaceHolderID="ctnHead" runat="server">
</asp:Content>

<asp:Content ID="ctnContent2" ContentPlaceHolderID="ctnPH" runat="server">

    <asp:Button ID="btnSignOut" runat="server" Text="Sign Out" />

    <br />


    Username:
    <br />
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    Password:
    <br />
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:DropDownList ID="ddRole" runat="server" >
        <asp:ListItem Value="A">Admin</asp:ListItem>
        <asp:ListItem Selected="True" Value="U">User</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
    <asp:Button ID="btnSavePerson" runat="server" Text="Save" />
    <asp:Button ID="btnLoadPerson" runat="server" Text="Load" />

    <asp:GridView ID="gvShowUsers" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="col_username" HeaderText="Username" />
            <asp:BoundField DataField="col_password" HeaderText="Password" />
            <asp:BoundField DataField="col_role" HeaderText="Role" />
            <asp:BoundField DataField="col_createdate" HeaderText="Create Date" />
            <asp:BoundField DataField="col_editdate" HeaderText="Edit Date" />
        </Columns>
    </asp:GridView>
</asp:Content>
