﻿using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class User : BaseEntity<long>
    {
        String _name;
        String _email;
        String _password;

        public String Name { get => _name; set => _name = value; }
        public String Email { get => _email; set => _email = value; }
        public String Password { get => _password; set => _password = value; }
        public long UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public void GetStr()
        {

            using (MD5 mD5 = MD5.Create())
            {
                String Hash = GetMd5Hash(mD5, Password);

                Console.WriteLine("MD 5 " + Hash);

                if(VerifyMd5Hash(mD5, Password, Hash))
                {
                    Console.WriteLine("MD 5 ");
                }
                else
                {
                    Console.WriteLine("MD 5 ");
                }
            }
        }

        public static String GetMd5Hash(MD5 mD5, String input)
        {
            byte[] data = mD5.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        static Boolean VerifyMd5Hash(MD5 mD5, String input, String hash)
        {
            String HashInput = GetMd5Hash(mD5, input);

            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            if (0 == stringComparer.Compare(mD5, HashInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}