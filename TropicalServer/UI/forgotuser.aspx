<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotuser.aspx.cs" Inherits="TropicalServer.UI.forgotuser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="header" runat="server" CssClass="imageHeader" ImageUrl="~/Images/HeaderTropicalServer.png" />                  
        <div id="container">
            <div id ="BodyDetail">
                <label id="Loginlbl">MOBILE TRACKING</label>
            <div id="loginBox">              
                <label id="useridlbl">Password:</label>  <asp:TextBox ID="usernametextbox" runat="server"></asp:TextBox><br />
                <label id="passwordlbl">New Username:</label><asp:TextBox ID="passwordtextbox" runat="server"></asp:TextBox><br />
                <label>Re-entry new username</label><asp:TextBox ID="newpass" runat="server"></asp:TextBox>
                <asp:Button ID="loginButton" runat="server" Text="Update" />
                </div>
          </div></div>
    </form>
</body>
</html>
