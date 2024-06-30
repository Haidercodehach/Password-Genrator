using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Genrator
{
    internal class Program
    {

        private static readonly string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string NumericChars = "0123456789";
        private static readonly string SpecialChars = "!@#$%^&*()";

        public static string GeneratePassword(int length)
        {
            StringBuilder password = new StringBuilder();

    password.Append(GetRandomChar(LowercaseChars));
            password.Append(GetRandomChar(UppercaseChars));
            password.Append(GetRandomChar(NumericChars));
            password.Append(GetRandomChar(SpecialChars));

            // Generate remaining characters randomly
            Random random = new Random();
            for (int i = 4; i < length; i++)
            {
                string charSet = GetRandomCharSet(random);
                char randomChar = GetRandomChar(charSet);
                password.Append(randomChar);
            }

            // Shuffle the password characters
            string shuffledPassword = ShufflePassword(password.ToString());
            return shuffledPassword;
        }

        private static char GetRandomChar(string charSet)
        {
            Random random = new Random();
            int index = random.Next(charSet.Length);
            return charSet[index];
        }

        private static string GetRandomCharSet(Random random)
        {
            string[] charSets = { LowercaseChars, UppercaseChars, NumericChars, SpecialChars };
            int index = random.Next(charSets.Length);
            return charSets[index];
        }

        private static string ShufflePassword(string password)
        {
            char[] passwordArray = password.ToCharArray();
            Random random = new Random();
            int n = passwordArray.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = passwordArray[k];
                passwordArray[k] = passwordArray[n];
                passwordArray[n] = value;
            }
            return new string(passwordArray);
        }

        public static void Main(string[] args)
        {
            int passwordLength;
            string cLength;
            Console.WriteLine("Hi I am random Password Genrator ");
         
          
            while (true)
            {
                Console.WriteLine("Please Enter the length of your password in numbers");
                cLength = Console.ReadLine();
                bool success = int.TryParse(cLength, out passwordLength);

                if (success)
                {
                    if(cLength!=null)
                    {
                        string password = GeneratePassword(passwordLength);
                        Console.WriteLine("Your Password is:  " + password);
                        break;
                    }else if (cLength==null)
                    {
                        continue;
                    }
                   
                }
            }
            
        }
    }

}
