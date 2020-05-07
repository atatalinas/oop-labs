using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginInterface
{
    public interface IEncoder
    {
        void EncryptStream(Stream sourcestream, Stream deststream, string key);
        void DecryptStream(Stream sourcestream, Stream deststream, string key);
        string Expansion { get; }
        //string Name { get; }
    }
}
