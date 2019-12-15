<%@ Page Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.UI.Orders" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="order_date" runat="server" Text="Order Date:"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Today</asp:ListItem>
        <asp:ListItem>Last 7 Days</asp:ListItem>
        <asp:ListItem>Last 1 Month</asp:ListItem>
        <asp:ListItem>Last 6 Months</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="custid" runat="server" Text="Customer ID:"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="custname" runat="server" Text="Customer Name:"></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="manager" runat="server" Text="Sales Manager:"></asp:Label><asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Hitesh</asp:ListItem>
        <asp:ListItem>Chee</asp:ListItem>
        <asp:ListItem>Anupam</asp:ListItem>
        <asp:ListItem>Nii</asp:ListItem>
        <asp:ListItem>Andy</asp:ListItem>
    </asp:DropDownList>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional" runat="server">
        <Triggers>

            <asp:PostBackTrigger ControlID="GridView1"/>
        </Triggers>

 <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="OrderID" OnRowCommand="GridView1_RowCommand" 
        OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
        OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <AlternatingRowStyle CssClass ="AltRow" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle CssClass="Row" BackColor="White" ForeColor="#003399" />
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle CssClass="AltRow" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <Columns>
               <asp:TemplateField headertext="OrderID">
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                   </ItemTemplate>
                   <EditItemTemplate>
                       <asp:TextBox ID="txtOrderID" Text='<%# Eval("OrderID") %>' runat="server"></asp:TextBox>                 
                   </EditItemTemplate>                 
               </asp:TemplateField>
           <%-- <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" ReadOnly="true" />--%>
                <asp:TemplateField headertext="Tracking">
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tracking") %>'></asp:Label>                          
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtTracking" Text='<%# Eval("Tracking") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>
                <asp:TemplateField headertext="OrderDate">
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>                           
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtOrderDate" Text='<%# Eval("OrderDate") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>
                <asp:TemplateField headertext="Customer_ID">
                       <ItemTemplate>
                           <asp:Label ID="Label4" runat="server" Text='<%# Eval("Customer_ID") %>'></asp:Label>                           
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtCustomer_ID" Text='<%# Eval("Customer_ID") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>
                <asp:TemplateField headertext="Address">
                       <ItemTemplate>
                           <asp:Label ID="Label5" runat="server" Text='<%# Eval("Address") %>'></asp:Label>                         
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtAddress" Text='<%# Eval("Address") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>
                <asp:TemplateField headertext="Customer_Name">
                       <ItemTemplate>
                           <asp:Label ID="Label6" runat="server" Text='<%# Eval("Customer_Name") %>'></asp:Label>                          
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtCustomer_Name" Text='<%# Eval("Customer_Name") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>
                <asp:TemplateField headertext="Route">
                       <ItemTemplate>
                           <asp:Label ID="Label7" runat="server" Text='<%# Eval("Route") %>'></asp:Label>                           
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtRoute" Text='<%# Eval("Route") %>' runat="server"></asp:TextBox>                 
                       </EditItemTemplate>                 
                   </asp:TemplateField>

                <asp:TemplateField headertext="Avilable Actions">
                           <ItemTemplate>
                               <asp:Button ID="Button1" runat="server" Text="View" AutoPostBack="true" CommandName="View" CommandArgument='<%# Container.DataItemIndex %>'/>
                               <asp:Button ID="Button2" runat="server" Text="Edit" CommandName="Edit" ToolTip="Edit"/>
                               <asp:Button ID="Button3" runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete"/>
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:Button ID="Button4" runat="server" Text="Update" CommandName="Update" ToolTip="Update"/>
                               <asp:Button ID="Button5" runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Cancel"/>                 
                           </EditItemTemplate>                 
                   </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
      
    </asp:GridView>
     </ContentTemplate>
             </asp:UpdatePanel>
    <asp:Button ID="Button6" runat="server" Text="Button"/>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button6" PopupControlID="vp" OkControlID="close"></asp:ModalPopupExtender>
   
    <asp:Panel ID="vp" runat ="server" BorderColor="white" ForeColor="white" BorderWidth="10" style="background-color:#6495ED">
        <asp:Label ID="Label21" runat="server" Text="OrderTracking Number: "></asp:Label><asp:Label ID="Label31" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="Label22" runat="server" Text="OrderDate: "></asp:Label><asp:Label ID="Label32" runat="server" Text=""></asp:Label><br/>
         <asp:Label ID="Label23" runat="server" Text="Customer ID: "></asp:Label><asp:Label ID="Label33" runat="server" Text=""></asp:Label><br/>
         <asp:Label ID="Label24" runat="server" Text="Address: "></asp:Label><asp:Label ID="Label34" runat="server" Text=""></asp:Label><br/>
          <asp:Label ID="Label25" runat="server" Text="Customer Name: "></asp:Label><asp:Label ID="Label35" runat="server" Text=""></asp:Label><br/>
          <asp:Label ID="Label26" runat="server" Text="Route: "></asp:Label><asp:Label ID="Label36" runat="server" Text=""></asp:Label><br/>
          <asp:Button ID="close" runat="server" Text="close"/>       
    </asp:Panel >
</asp:Content>





<%--    <asp:Button ID="filter" runat="server" Text="Filter" onClick="filter_Click"/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="orderid">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="orderid" HeaderText="orderid" SortExpression="orderid" ReadOnly="true"/>
            <asp:BoundField DataField="tracking" HeaderText="tracking" SortExpression="tracking" ReadOnly="true"/>
            <asp:BoundField DataField="orderdate" HeaderText="orderdate" SortExpression="orderdate" />
            <asp:BoundField DataField="custid" HeaderText="custid" SortExpression="custid" ReadOnly="true"/>
            <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" ReadOnly="true"/>
            <asp:BoundField DataField="custname" HeaderText="custname" SortExpression="custname" ReadOnly="true"/>
            <asp:BoundField DataField="route" HeaderText="route" SortExpression="route" ReadOnly="true"/>           
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteOrder" SelectMethod="GetAllOrder" TypeName="TropicalServer.OrderDataLayer" UpdateMethod="UpdateOrder">
        <DeleteParameters>
            <asp:Parameter Name="OrderId" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="OrderId" Type="Int32" />
            <asp:Parameter Name="tracking" Type="String" />
            <asp:Parameter Name="orderdate" Type="String" />
            <asp:Parameter Name="custid" Type="Int32" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="custname" Type="String" />
            <asp:Parameter Name="route" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>--%>



