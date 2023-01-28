<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="ctnContent1" ContentPlaceHolderID="ctnHead" runat="Server">
</asp:Content>
<asp:Content ID="ctnContent2" ContentPlaceHolderID="ctnPH" runat="Server">
    <a href="./logon.aspx">Log in</a>
    <br />
    <a href="./ManageUsers.aspx">Manage Users</a>
    <br />
    <br />
    <asp:Button ID="btnSignOut" runat="server" Text="Sign Out" />
</asp:Content>


