using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSAKeys
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            using (StreamWriter writer = new StreamWriter("../PrivateKey.xml", false))//这个文件要保密
            {
                writer.WriteLine(rsa.ToXmlString(true));
            }
            using (StreamWriter writer = new StreamWriter("../PublicKey.xml", false))
            {
                writer.WriteLine(rsa.ToXmlString(false));
            }
        }
    }
}