//Author: Justin Davis
//Encrypting and Decrypting
//4/20/20

using System;
using System.Linq;

namespace EncryptDecrypt
{
    class Program
    {
        
        public static char[] letters = new char[] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        static void Main(string[] args)
        {
            Startup();
        }

        public static void Startup()
        {
            Console.WriteLine("Welcome to my encryption program.");
            bool isAlpha = false;
            string userInput = "";
            while (isAlpha == false)
            {
                Console.WriteLine("Please enter a phrase (all letters) to be encrypted.");
                userInput = Console.ReadLine().ToLower();
                isAlpha = AllLettersOrSpaces(userInput);
            }            
            string encryptedMessage = Encrypt(userInput, 3);
            Console.WriteLine("Your encrypted message is " + encryptedMessage);
            string decryptedMessage = Decrypt(encryptedMessage, 3);
            Console.WriteLine("Your decrypted message is " + decryptedMessage);
        }

        public static bool AllLettersOrSpaces(string input)
        {

            foreach(char a in input)
            {
                if(letters.Contains(a) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static string Encrypt(string input, int rotateBy)
        {
            int index = 0;
            input = input.ToLower();
            string encryptedString = "";
            foreach (char letter in input)
            {
                if (letter != ' ')
                {
                    index = Array.IndexOf(letters, letter);
                    if (index - rotateBy >= 1)
                    {
                        encryptedString += letters[index - rotateBy];
                    }
                    else
                    {
                        int overFlowIndex = 26 - ((index - rotateBy) * -1);
                        encryptedString += letters[overFlowIndex];
                    }
                }
                else
                {
                    encryptedString += ' ';
                }
            }
            return encryptedString;
        }

        public static string Decrypt(string input, int rotateBy)
        {
            int index = 0;
            input = input.ToLower();
            string decryptedString = "";
            foreach (char letter in input)
            {
                if (letter != ' ')
                {
                    index = Array.IndexOf(letters, letter);
                    if (index + rotateBy <= 26)
                    {
                        decryptedString += letters[index + rotateBy];
                    }
                    else
                    {
                        int overFlowIndex = ((26 - (index + rotateBy)) * -1);
                        decryptedString += letters[overFlowIndex];
                    }
                }
                else
                {
                    decryptedString += ' ';
                }
            }
            return decryptedString;
        }
    }
}
