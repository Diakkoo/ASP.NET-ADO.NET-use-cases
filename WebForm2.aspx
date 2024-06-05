<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="E6.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="70px"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="性别"></asp:Label>
&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
        <p>
            <asp:Label ID="Label4" runat="server" Text="年龄"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="35px"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="部门"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Insert_click" Text="添加数据" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Update_click" Text="修改数据" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Delete_click" Text="删除数据" />
        </p>
        <asp:Label ID="Label6" runat="server"></asp:Label>
    </form>
</body>
</html>
