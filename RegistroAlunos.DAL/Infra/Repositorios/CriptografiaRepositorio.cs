using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RegistroAlunos.Repositório
{
    public class CriptografiaRepositorio
    {
        private const string ChaveCriptografia = "ControleAcesso";
        private static byte[] _chave = { };
        private static readonly byte[] Iv = { 12, 20, 45, 71, 85, 99, 110, 123 };

        public static string Criptografar(string valor)
        {
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] input = Encoding.UTF8.GetBytes(valor);
                    _chave = Encoding.UTF8.GetBytes(ChaveCriptografia.Substring(0, 8));

                    using (
                        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                            desCryptoServiceProvider.CreateEncryptor(_chave, Iv), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public static string Descriptografar(string valor)
        {
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] input = Convert.FromBase64String(valor);
                    _chave = Encoding.UTF8.GetBytes(ChaveCriptografia.Substring(0, 8));
                    using (
                        CryptoStream cryptoStream = new CryptoStream(memoryStream,
                            desCryptoServiceProvider.CreateDecryptor(_chave, Iv), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(input, 0, input.Length);
                        cryptoStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
        }
    }
}
