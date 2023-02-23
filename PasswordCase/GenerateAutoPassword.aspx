<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateAutoPassword.aspx.cs"
    Inherits="PasswordCase.GenerateAutoPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>隨機產生密碼</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="font-size: larger;color: #ff4500;font-weight: bold " >隨機產生密碼</td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    密碼：
                </td>
                <td>
                    <asp:Label ID="LblPw" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnGenerate" runat="server" Text="隨機產生" 
                        onclick="BtnGenerate_Click" />
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
