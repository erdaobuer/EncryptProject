using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;

namespace 加密解密
{
    /// <summary>
    /// 非对称加密解密，可逆
    /// 密钥对，公钥和私钥，有一个推算不出另一个
    /// 密钥对可以通过RSAKeys程序生成
    /// 缺点：速度慢
    /// </summary>
    public class RsaHelper
    {
        private static string PublicKey = @"<RSAKeyValue><Modulus>3arkgwbt/EA7qIt2hjGyAW+SSd/LpRxeh3QvYfLGOL4buE4gy4HN7yoDfUxY1xBM0Hntk3+UYwc/7a9G0PyoMFUK7B1I2JCH5HV1ksxqliP2o6BuFTmWEZ+KVGYdUlBH1OpqvglCzGzS+lPRx+4JnAtJ1eSg4EELeZJdN7+AdrE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private static string PrivateKey = @"<RSAKeyValue><Modulus>3arkgwbt/EA7qIt2hjGyAW+SSd/LpRxeh3QvYfLGOL4buE4gy4HN7yoDfUxY1xBM0Hntk3+UYwc/7a9G0PyoMFUK7B1I2JCH5HV1ksxqliP2o6BuFTmWEZ+KVGYdUlBH1OpqvglCzGzS+lPRx+4JnAtJ1eSg4EELeZJdN7+AdrE=</Modulus><Exponent>AQAB</Exponent><P>/D1h0i0g83rgx3UcsD9chCaMaWvSRmKLu/ArP3nRY6DbxDy2HXBaGSq7k6fwubCMHRJ0iqz2i3lEYeD1zHs8Iw==</P><Q>4PjWm1Qh3pBKSYw/L11hyRT4brNMP80mgafViHqKUYYKUYQfIcQXwdYT2ZASjmoMA/5L8J9Vj0ibiptPwCjVGw==</Q><DP>xtdgmL3Inwe70KBqmCmqteZpg+ViYufmfaYLgcN3JBG3jQ/LBJQAApzkN7cJFmitW3Gj+3nz9OkI1hvvyF1Rfw==</DP><DQ>voVd0YuNZ1uQ3fpcpDMUFeOhhLZpM3r8Sj8lUgBc1S+L237lkoXrjKdMhipB3MOoS1V3YF6/aamWt+pRvq2V0w==</DQ><InverseQ>MvwMEs93LuTybVvF6nCJIxDzVkGxvLeRi+WnysP3HkyYcvk7avNyfJg1UZSjIgIliLJtq0J4FI9tm2mYNiwdLA==</InverseQ><D>Wi0cWyVliXoECxP5Oqxa0vS1mXH+oYPB/O7KG9msxAaqtjaqZr++rC32T3HQrmUGKsV/XcLH9eVMH4BvmbM/I/BBynuXARcGHFF+aZ26O7UyWFp6rSfcXK826sdruK7xHdfL61TPtA6gZi17nqE2c+xEHq7D5qUQyf3OXhlMycU=</D></RSAKeyValue>";

        private static RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(1024);

        #region 加密

        /// <summary>
        /// 加密
        /// 加密的密文并不全能作为字符串打印出来，有乱码很正常
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            //将公钥导入到RSA对象中，准备加密；
            rsa.FromXmlString(PublicKey);

            //对数据data进行加密，并返回加密结果；
            //第二个参数用来选择Padding的格式
            byte[] buffer = rsa.Encrypt(data, false);
            return buffer;
        }

        #endregion 加密

        #region 解密

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            //将私钥导入RSA中，准备解密；
            rsa.FromXmlString(PrivateKey);

            //对数据进行解密，并返回解密结果；
            return rsa.Decrypt(data, false);
        }

        #endregion 解密
    }
}