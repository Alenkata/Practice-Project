using System;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PassEmGen
{
    class Program
    {
        static List<char> chars = new List<char>();
        static void Main(string[] args)
        {
            Console.Write("Enter your first name: "); string fName = Console.ReadLine();
            while(!Regex.IsMatch(fName, @"[A-Z]{1}[a-z]{2,}")) //validates the entered first name//
            {
                Console.Write("Invalid first name!");
                Console.WriteLine("Enter a valid first name: "); fName = Console.ReadLine();
            }
            Console.Write("Enter your surname: "); string surname = Console.ReadLine();
            while(!Regex.IsMatch(surname, @"[A-Z]{1}[a-z]{2,}"))
            {
                Console.Write("Invalid surname!");
                Console.WriteLine("Enter a valid surname: "); surname = Console.ReadLine();
            }

            while(true)
            { 
                Console.WriteLine($"\nHello {fName} {surname}, what do you want to generate?");
                Console.WriteLine("A. Password"); //option A to generate a password//
                Console.WriteLine("B. Email");  //option B to generate an email//
                Console.WriteLine("C. Exit the program.");   //option to exit//
                string userChoice = Console.ReadLine();

                if(userChoice == "A")
                {
                    addChars(ref chars);
                        Console.WriteLine("Enter the length of your desired password: "); //the length of password
                        int length = 0;
                        if (int.TryParse(Console.ReadLine(), out length))
                        {
                            Console.WriteLine(GeneratePassword(length));
                        }
                }
                else if(userChoice == "B")
                {
                    string[] lowerCharacters = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; //only lowercase letters//
                    string[] upperCharacters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }; //only uppercase letters//
                    string[] mixedCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}; //both case letters//
                    Random random= new Random();
                    int emailLength = 15; //the average length of an email address//
                    Console.WriteLine("What do you want your email to contain?");
                    Console.WriteLine("A. Only lower case characters"); //generates email with lowercase letters//
                    Console.WriteLine("B. Only upper case characters"); //generates email with uppercase letters//
                    Console.WriteLine("C.Both"); //generates email which contains uppercase and lowercase letters//
                    string EmUsChoice = Console.ReadLine();
                    Console.WriteLine("How many emails do you want to be generated? "); int EmLength = int.Parse(Console.ReadLine());

                    }
                else if(userChoice == "C")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid action!");
                }
                continue;
            }
        }
        static string GeneratePassword(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            int k = 0;
            while (k < length)
            {
                sb.Append(chars[rnd.Next(0, chars.Count)]);
                k++;
            }
            
            return sb.ToString();
        }
        static void addChars(ref List<char> chars)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                chars.Add(c);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                chars.Add(c);
            }
        }
    }
}
