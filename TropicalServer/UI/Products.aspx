<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.UI.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <asp:Label ID="Label1" runat="server" Text="Welcome to Tropical Cheese Industries!"></asp:Label>

    </p>

    <div class="productCategories">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="productCategories_ItemCommand">
    <ItemTemplate>
        <div class="productCategoriesLabel">
            <table>
                <tr>                    
                    <asp:Button ID="Menu" runat="server" Text='<%#Eval("ItemTypeDescription") %>' CommandArgument='<%#Eval("ItemTypeID") %>'></asp:Button>
                </tr>
            </table>
        </div>
    </ItemTemplate>
    </asp:Repeater>
    </div>

    <div class="dataGrid">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ItemNumber" AllowPaging="True" OnPreRender="GridView1_PreRender"
            PageSize="5" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="ItemNumber" HeaderText ="ItemNumber" InsertVisible="false" ReadOnly="true" 
                    SortExpression="ItemNumber" />
                <asp:BoundField DataField="ItemDescription" HeaderText ="ItemDescription" InsertVisible="false" ReadOnly="true" 
                    SortExpression="ItemDescription" />
                <asp:BoundField DataField="PrePrice" HeaderText ="PrePrice" InsertVisible="false" ReadOnly="true" 
                    SortExpression="PrePrice" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
                <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
</asp:Content>
