﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="POC_DataView.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1>Edit User Information</h1>
        </div>
         <div  style="background-color:#e8def6;padding:50px" >
         
        <div>
            <asp:Label ID="lblUseriD" runat="server" Text="UserID" />:-
             <asp:TextBox ID="txtUserID" runat="server" Text="" />
        </div>
         <div>
             <asp:Label ID="lblUserName" runat="server" Text="UserName" /> :- 
              <asp:TextBox ID="txtUserName" runat="server" Text="" />
            
        </div>
         <div>
             <asp:Label ID="lblUserPassword" runat="server" Text="UserPassword" /> :-
             <asp:TextBox ID="txtUserPassword" runat="server" Text="" />
        </div>
         <div>
             <asp:Label ID="lblUserEmail" runat="server" Text="UserEmail" /> :-
             <asp:TextBox ID="txtUserEmail" runat="server" Text="" />
        </div>
              <div>
             <asp:Label ID="lblUserImge" runat="server" Text="UserImage" /> :-
             <asp:TextBox ID="txtUserImage" runat="server" Text="" />
        </div>
              <div>
                  
             <br />
        </div>
         <div>
            
             <asp:Button id="btnEditUser" Text="Edit User" runat="server" OnClick="btnEditUser_Click"  />
               <asp:Button id="btnShowListView" Text="Back to ShowListView" runat="server" OnClick="btnShowListView_Click"  />
        </div>
             </div>
    </form>
</body>
</html>
