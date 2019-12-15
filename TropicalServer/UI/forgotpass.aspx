<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpass.aspx.cs" Inherits="TropicalServer.UI.forgotpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../AppThemes/TropicalStyles/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="header" runat="server" CssClass="imageHeader" ImageUrl="~/Images/HeaderTropicalServer.png" />                  
        <div id="container">
            <div id ="BodyDetail">
                <label id="Loginlbl">MOBILE TRACKING</label>
            <div id="loginBox">              
                <label id="useridlbl">Username:</label>  <asp:TextBox ID="usernametextbox" runat="server"></asp:TextBox><br />
                <label id="passwordlbl">New password:</label><asp:TextBox ID="passwordtextbox" runat="server"></asp:TextBox><br />
                <label>Re-entry new password</label><asp:TextBox ID="newpass" runat="server"></asp:TextBox>
                <asp:Button ID="Update" runat="server" Text="Update" onClick="Update_Click"/>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Back" runat="server" Text="Back" onClick="Back_Click"/>
                </div>
          </div></div>
    </form>
</body>
</html>
