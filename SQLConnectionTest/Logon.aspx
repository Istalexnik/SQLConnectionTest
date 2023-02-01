<%@ Page Title="Log In Page" Language="VB" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="false" CodeFile="Logon.aspx.vb" Inherits="Logon" %>



<asp:Content ID="cntContent1" ContentPlaceHolderID="ctnHead" runat="Server">
</asp:Content>
<asp:Content ID="ctnContent2" ContentPlaceHolderID="ctnPH" runat="Server">

    <div>
        <h3>Please Log In</h3>
        <table>
            <tr>
                <td>Email:</td>
                <td><input id="txtEmail" type="text" runat="server"></td>
                <td><asp:RequiredFieldValidator ID="vEmailNotEmpty" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="*" Display="Static" />
                    <asp:RegularExpressionValidator ID="vEmailFormat" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" 
                        Display="Static" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
                </td>
            </tr>

            <tr>
                <td>Password:</td>
                <td> <input id="txtPassword" type="password" runat="server" /></td>
                <td><asp:RequiredFieldValidator ID="vPassword" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="*" Display="Static" /></td>
            </tr>

            <tr>
                <td>Persist Cookie:</td>
                <td><asp:CheckBox ID="chbPersistCookie" runat="server" AutoPostBack="false" /> </td>
                <td></td>
            </tr>
        </table>
        <asp:Button ID="btnLogin" runat="server" Text="Log In" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>

</asp:Content>

