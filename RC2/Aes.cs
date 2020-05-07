using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace AesPlugin
{
    public class Aes : IEncoder
    {
        // Для работы TripleDES требуется вектор инициализации (IV) и ключ (Key)
        // Операции шифрования/деширования должны использовать одинаковые значения IV и Key

        public void EncryptStream(Stream sourcestream, Stream deststream, string key)
        {
            byte[] _key = new byte[32];
            byte[] _IV = new byte[16];

            byte[] myKey = Encoding.ASCII.GetBytes(key);

            for (int i = 0; i < _key.Length; i++) _key[i] = 0;
            for (int i = 0; (i < _key.Length) && (i < myKey.Length); i++) _key[i] = myKey[i];
            for (int i = 0; (i < _key.Length) && (i < _IV.Length); i++) _IV[i] = _key[i];
            _IV.Reverse();

            System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
            aes.IV = _IV;
            aes.Key = _key;
            var decStream = new CryptoStream(sourcestream, aes.CreateEncryptor(), CryptoStreamMode.Read);
            deststream.SetLength(0);
            decStream.CopyTo(deststream);
        }

        public void DecryptStream(Stream sourcestream, Stream deststream, string key)
        {
            byte[] _key = new byte[32];
            byte[] _IV = new byte[16];

            byte[] myKey = Encoding.ASCII.GetBytes(key);

            for (int i = 0; i < _key.Length; i++) _key[i] = 0;
            for (int i = 0; (i < _key.Length) && (i < myKey.Length); i++) _key[i] = myKey[i];
            for (int i = 0; (i < _key.Length) && (i < _IV.Length); i++) _IV[i] = _key[i];
            _IV.Reverse();

            System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
            aes.IV = _IV;
            aes.Key = _key;

            var decStream = new CryptoStream(sourcestream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            deststream.SetLength(0);
            decStream.CopyTo(deststream);

        }

        public string Expansion { get; } = ".aes";
    }
}
