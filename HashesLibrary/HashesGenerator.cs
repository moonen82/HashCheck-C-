using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HashesLibrary
{
    public class HashesGenerator
    {
        public string CreateMD5Hash (string input)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string CreateSHA1Hash(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string CreateSHA256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string CreateSHA384Hash(string input)
        {
            using (var sha384 = SHA384.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = sha384.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string CreateSHA512Hash(string input)
        {
            using (var sha512 = SHA512.Create())
            {
                using (var stream = File.OpenRead(input))
                {
                    var hash = sha512.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
