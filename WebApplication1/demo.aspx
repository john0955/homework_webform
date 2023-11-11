<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="WebApplication1.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <table>

                <tr>

                    <td>姓名:</td>
                    <td> 
                        <asp:HiddenField ID="sn" runat="server" />
                        <asp:TextBox ID="cname" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>

                    <td>年齡:</td>
                    <td>
                        
                        <asp:TextBox ID="zage" runat="server"></asp:TextBox>

                    </td>
                </tr>

                <tr>

                    <td>生日:</td>
                    <td>
                        

                        <asp:TextBox ID="birthday" runat="server"></asp:TextBox>
                    </td>
                </tr>

            </table>

            <asp:Button ID="go" runat="server" Text="建立帳號" OnClick="go_Click" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="cname" HeaderText="姓名" />
                <asp:BoundField DataField="zage" HeaderText="年齡" />
                <asp:BoundField DataField="birthday" HeaderText="生日" />
                <asp:BoundField DataField="sn" HeaderText="" >
                <ItemStyle Font-Size="0pt" CssClass="Hide" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Button" CommandName="zedit" Text="修改" />
                <asp:ButtonField ButtonType="Button" CommandName="zdelete" Text="刪除" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
