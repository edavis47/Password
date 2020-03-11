using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordHashingAndAuthentication
{
    class Password
    {
        public string MakeHash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] inputArray = Encoding.UTF8.GetBytes(input); //CONVERT INTO BYTE ARRAY
                byte[] hash = md5Hash.ComputeHash(inputArray); //HASH CAN ONLY TAKE A BYTE ARRAY

                StringBuilder hashedPass = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    hashedPass.Append(hash[i].ToString("x2"));
                }
                return hashedPass.ToString();
            }
        }
    }
}
