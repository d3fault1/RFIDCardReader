using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace RFIDReader
{
    static class Serializer
    {
        private static byte[] key = { 56, 37, 89, 13, 79, 27, 50, 92 };
        private static byte[] iv = { 40, 17, 29, 11, 83, 10, 63, 48 };
        private static string path = @"config.dat";

        public static void Serialize(DataModel[] data)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        formatter.Serialize(cryptoStream, data);
                    }
                }
            }
            catch
            {
                return;
            }

            
        }

        public static DataModel[] Deserialize()
        {
            if (!File.Exists(path)) return null;

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        DataModel[] deserialized = (DataModel[])formatter.Deserialize(cryptoStream);

                        return deserialized;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
