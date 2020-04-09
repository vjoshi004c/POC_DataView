<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGridView.aspx.cs" Inherits="POC_DataView.TestGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div >
           
            <h1> Lists  of users</h1>
            <div >
            <asp:Button id="btnAddUser" Text="Add User" runat="server" OnClick="btnAddUser_Click"  />

                <asp:Button id="btnShowListView" Text="ShowListView" runat="server" OnClick="btnShowListView_Click"  />
                <br />
                <br />
        </div>
        <div  style="background-color:#e8def6;" >
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound ="GridView1_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="UserID" ItemStyle-Width="15%">
            <ItemTemplate>
                <asp:TextBox ID="txtUserID" runat="server" style="border-style:none;background-color:#e8def6;" Text='<%# Eval("UserID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserName" ItemStyle-Width="15%">
            <ItemTemplate>
                <asp:TextBox ID="txUserName" runat="server" style="border-style:none;background-color:#e8def6;"  Text='<%# Eval("UserName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
       
       <%-- <asp:TemplateField HeaderText="UserEmail" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:TextBox ID="txtUserEmail" runat="server" Text='<%# Eval("UserEmail") %>' />
            </ItemTemplate>
        </asp:TemplateField>--%>
       
        <asp:BoundField DataField="UserEmail" HeaderText="UserEmail"   ItemStyle-Width="15%" />
         <asp:TemplateField HeaderText="UserImage" ItemStyle-Width="15%">
            <ItemTemplate>
               <%-- <asp:TextBox ID="txtUserImage" runat="server" Text='~\Images\User<%# Eval("UserImage") %>' />--%>
                 <asp:Image ID="imgUserImage" runat="server"  Width="100px"  style="border-style:none;"  height="100px" ImageUrl='<%# Eval("UserImage") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="15%" >
            <ItemTemplate>
                <asp:Button Text="Show" runat="server" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="15%">
            <ItemTemplate>
                <asp:Button Text="Edit" runat="server" CommandName="Edit User" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
            <ItemTemplate>
                <asp:Button Text="Delete" runat="server" CommandName="Delete User" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
