<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGridViewSecond.aspx.cs" Inherits="POC_DataView.TestGridViewSecond" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <div >
           
            <h1> Lists  of users</h1>
            <div>
            <asp:Button id="btnAddUser" Text="Add User" runat="server" OnClick="btnAddUser_Click"  />
                   <asp:Button id="btnShowListView" Text="ShowGridView" runat="server" OnClick="btnShowListView_Click"  />
        </div>
            <asp:DataList ID="dListUser" runat="server"  Width="100%"  RepeatColumns="4" OnItemCommand="dListUser_ItemCommand" OnItemDataBound="dListUser_ItemDataBound">
    <ItemTemplate>
        <div style="padding:20px;">
            <table class="table-responsive" border="0"  style="width:100%; padding:20px;background-color:#e8def6; " >
                <tr >
                    <td>
                         <h4>
                             <asp:Label runat="server" ID="Label2"  Text="UserID"> </asp:Label>
                            <asp:Label runat="server" ID="lblUserID"  Text='<%# Eval("UserID") %>'> </asp:Label>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        UserName : <asp:Label runat="server" ID="lblUserName"
                Text='<%# Eval("UserName") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        UserEmail :
                         <asp:Label runat="server" ID="lblUserEmail"
                             Text='<%# Eval("UserEmail") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                         UserImage :
                         <asp:Image ID="imgUserImage" runat="server"  Width="100px"  style="border-style:none;"  height="100px" ImageUrl='<%# Eval("UserImage") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Show" runat="server" CommandName="View" CommandArgument="<%# Container.DataItem %>" />
                 <asp:Button Text="Edit" runat="server" CommandName="Edit User" CommandArgument="<%# Container.DataItem %>" />
            <asp:Button Text="Delete" runat="server" CommandName="Delete User" CommandArgument="<%# Container.DataItem %>" />
                    </td>
                </tr>
               
            </table>
        </div>
               
    </ItemTemplate>
</asp:DataList>


            
        </div>
    </form>
</body>
</html>
