<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="加密解密.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #div_md5 {
            background-color: burlywood;
            width: 800px;
        }

        #div_des {
            background-color: darkcyan;
            width: 800px;
        }

        #div_rsa {
            background-color: cornflowerblue;
            width: 800px;
        }

        .class_title {
            font-size: 20px;
            color: brown;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_md5">
            <label class="class_title">MD5加密</label><br />
            <br />
            密码：<asp:TextBox ID="tb_pwd" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btn_toMD5" runat="server" Text="MD5加密" OnClick="btn_toMD5_Click" />
            <br />
            <br />
            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MD5密文：</label><asp:TextBox ID="tb_md5Pwd" runat="server" Width="300px"></asp:TextBox><br />
            <br />
            <label>16位MD5密文One：</label><asp:TextBox ID="tb_md5Pwd1" runat="server" Width="300px"></asp:TextBox><br />
            <br />
            <label>16位MD5密文Two：</label><asp:TextBox ID="tb_md5Pwd2" runat="server" Width="300px"></asp:TextBox><br />
            <br />
            <label>32位MD5密文One：</label><asp:TextBox ID="tb_md5Pwd3" runat="server" Width="300px"></asp:TextBox><br />
            <br />
            <label>16位MD5密文Two：</label><asp:TextBox ID="tb_md5Pwd4" runat="server" Width="300px"></asp:TextBox><br />
            <br />
            <label>文件：</label><%--<asp:TextBox ID="tb_fileName" runat="server" Width="300px"></asp:TextBox>--%>
            <asp:FileUpload ID="FileUpload1" runat="server" />

            &nbsp;&nbsp;
            <asp:Button ID="tb_md5File" runat="server" Text="获取文件MD5摘要" OnClick="tb_md5File_Click"></asp:Button>
            <br />
            <br />
            <label>MD5摘要</label>
            <asp:TextBox ID="tb_mdFile" runat="server" Width="300px"></asp:TextBox>
        </div>
        <br />
        <br />
        <div id="div_des">
            <label class="class_title">DES加密</label><br />
            <br />
            密码：<asp:TextBox ID="tb_DESpassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
            <%--<br />
            <br />
             密钥：<asp:TextBox ID="tb_secretKey" runat="server" Width="300px" TextMode="Password">dt521522</asp:TextBox>

            <br />
            <br />
            向量：<asp:TextBox ID="tb_iv" runat="server" Width="300px" TextMode="Password">dt521522</asp:TextBox>--%>
            <asp:Button ID="btn_toDES" runat="server" Text="DES加密" OnClick="btn_toDES_Click" />
            <br />
            <br />
            DES密文：<asp:TextBox ID="tb_DESPwd" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btn_DESToPwd" runat="server" Text="DES解密" OnClick="btn_DESToPwd_Click" />
            <br />
            <br />
            解密密码：<asp:TextBox ID="tb_DEStoPwd" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
        </div>
        <br />
        <br />
        <div id="div_rsa">
            <label class="class_title">RSA加密</label><br />
            <br />
            密码：<asp:TextBox ID="tb_password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btn_RASEncrypt" runat="server" Text="DES加密" OnClick="btn_RASEncrypt_Click" />
            <br />
            <br />
            RSA密文：<asp:TextBox ID="tb_RSApassword" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="DES解密" OnClick="Button2_Click" />
            <br />
            <br />
            解密密码：<asp:TextBox ID="tb_RASDecrypt" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
        </div>
    </form>
</body>
</html>