<%@ Page Title="Log In Page" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="Logon.aspx.vb" Inherits="Logon" %>

<asp:Content ID="cntContent1" ContentPlaceHolderID="ctnHead" Runat="Server">
</asp:Content>
<asp:Content ID="ctnContent2" ContentPlaceHolderID="ctnPH" Runat="Server">
    <h3>Please Log In</h3>
    <table>
        <tr>
            <td>Username:</td>
            <td><input id="txtUsername" type="text" runat="server"></td>
            <td><asp:RequiredFieldValidator ID="vUsername" runat="server" ControlToValidate="txtUsername"
                ErrorMessage="*" Display="Static"/></td>
        </tr>

        <tr>
            <td>Password:</td>
            <td><input id="txtPassword" type="password" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="vPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="*" Display="Static"/></td>
        </tr>

        <tr>
            <td>Persist Cookie:</td>
            <td><asp:CheckBox ID="chbPersistCookie" runat="server" AutoPostBack="false" /></td>
            <td></td>
        </tr>

    </table>
            <asp:Button ID="btnLogin" runat="server" Text="Log In"/>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>

