<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TropicalServer.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <title>Login page</title>
    <link href="../AppThemes/TropicalStyles/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="Form" runat="server" visible="True">
        <div id="header">            
            <asp:Image ID="Image" runat="server" CssClass="imageHeader" ImageUrl="~/Images/HeaderTropicalServer.png" />          
        </div>
        <div id="container">
            <div id ="BodyDetail">
                <label id="Loginlbl">MOBILE TRACKING</label>
            <div id="loginBox">              
                <label id="useridlbl">Login ID:</label>  <asp:TextBox ID="usernametextbox" runat="server" Width="214px"></asp:TextBox>
                <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernametextbox" ErrorMessage="Please type your username"></asp:RequiredFieldValidator></div>
                <label id="passwordlbl">Password:</label><asp:TextBox ID="passwordtextbox" runat="server" TextMode="Password" Width="214px"></asp:TextBox>
                <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passwordtextbox" ErrorMessage="Please type your password"></asp:RequiredFieldValidator></div>
                <label id ="login">&nbsp;               
                Remember myID<asp:CheckBox ID="CheckBox1" runat="server" /></label>
                <asp:Button ID="loginButton" runat="server" Text="Login" onClick="loginButton_Click"/>
                </div>
          <div id="forgot">
                <a href="forgotuser.aspx" id="forgotUsername">Forgot Username</a>
                <a href="forgotpass.aspx" id="forgotPassword">Forgot Password</a>
            </div></div></div>
    </form>
</body>
</html>
