using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 加密解密
{
    public partial class Default : System.Web.UI.Page
    {
        public static byte[] encryptPwd;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_toMD5_Click(object sender, EventArgs e)
        {
            var pwd = tb_pwd.Text.ToString().Trim();
            var md5Pwd = MD5Helper.ToMD5(pwd);
            var md5Pwd1 = MD5Helper.Get16MD5One(pwd);
            var md5Pwd2 = MD5Helper.Get16MD5Two(pwd);
            var md5Pwd3 = MD5Helper.Get32MD5One(pwd);
            var md5Pwd4 = MD5Helper.Get32MD5Two(pwd);
            tb_md5Pwd.Text = md5Pwd;
            tb_md5Pwd1.Text = md5Pwd1;
            tb_md5Pwd2.Text = md5Pwd2;
            tb_md5Pwd3.Text = md5Pwd3;
            tb_md5Pwd4.Text = md5Pwd4;
        }

        protected void btn_toDES_Click(object sender, EventArgs e)
        {
            var pwd = tb_DESpassword.Text.ToString();
            //var key = tb_secretKey.Text.ToString();
            //var iv = tb_iv.Text.ToString();
            //if (pwd.Length > 0 && key.Length > 0 && iv.Length > 0)
            if (pwd.Length > 0 && pwd.Length >= 10)
            {
                var DESPwd = DESHelper.DESEncrypt(pwd);
                tb_DESPwd.Text = DESPwd;
            }
            else
            {
                Response.Write("<script>alert('请输入要加密的密码！！！')</script>");
            }
        }

        protected void btn_DESToPwd_Click(object sender, EventArgs e)
        {
            var DESPwd = tb_DESPwd.Text.ToString();
            //var key = tb_secretKey.Text.ToString();
            //var iv = tb_iv.Text.ToString();
            //if (DESPwd.Length > 0)
            //{
            //var pwd = DESHelper.DESDecrypt(DESPwd, key, iv);
            var pwd = DESHelper.DESDecrypt(DESPwd);
            tb_DEStoPwd.Text = pwd;
            //}
        }

        protected void tb_md5File_Click(object sender, EventArgs e)
        {
            //判断文件是否存在
            if (!this.FileUpload1.HasFile) return;
            //判断文件大小，是否符合设置要求
            double fileLength = this.FileUpload1.FileContent.Length / (1024.0 * 1024.0);
            //获取配置文件中上传文件大小的限制
            double limitedLength = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["PhysicsObjectLength"]);
            limitedLength = limitedLength / 1024.0;//转换成MB单位
            //判断实际文件大小是否符合要求
            if (fileLength > limitedLength)
            {
                Response.Write("<script>alert('上传文件大小不能超过" + limitedLength + "MB')</script>");
                return;
            }
            //【3】获取文件名，判断文件扩展是否符合要求
            string fileName = this.FileUpload1.FileName;
            //判断文件名是否是exe文件
            if (fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower() == "exe")
            {
                Response.Write("<script>alert('文件不能是exe文件')</script>");
                return;
            }

            //获取服务器文件夹路径
            string path = Server.MapPath("~/files");

            fileName = path + "/" + fileName;
            if (fileName != null)
            {
                var md5File = MD5Helper.AbstractFile(fileName);
                this.tb_mdFile.Text = md5File;
            }
        }

        /// <summary>
        /// 非对称加密
        /// 加密的密文并不全能作为字符串打印出来，有乱码很正常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_RASEncrypt_Click(object sender, EventArgs e)
        {
            var pwd = this.tb_password.Text.ToString();
            byte[] data = ASCIIEncoding.ASCII.GetBytes(pwd);
            encryptPwd = RsaHelper.Encrypt(data);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            byte[] decryptPwd;
            decryptPwd = RsaHelper.Decrypt(encryptPwd);
            var decryptPwdString = ASCIIEncoding.ASCII.GetString(decryptPwd);
            this.tb_RASDecrypt.Text = decryptPwdString;
        }
    }
}