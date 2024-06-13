<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookstore.aspx.cs" Inherits="E6.bookstore" %>

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
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Larger" Font-Underline="True" Text="欢迎进入图书管理后台"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="No" OnRowCancelingEdit="GVcancelingEdit" OnRowDeleting="GVdeleting" OnRowEditing="GVediting" OnRowUpdating="GVupdating">
            <Columns>
                <asp:ButtonField CommandName="delete" Text="删除" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="Linkbt1" runat="server" CommandName="update">确认</asp:LinkButton>
                        <asp:LinkButton ID="Linkbt2" runat="server" CommandName="cancel">取消</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <br/>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="Linkbt3" runat="server" CausesValidation="False" CommandName="edit">编辑</asp:LinkButton>
                    </ItemTemplate>


                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br/>
        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="新增图书" />
    </form>
</body>
</html>
