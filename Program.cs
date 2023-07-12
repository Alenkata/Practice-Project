﻿using System;
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
            while (!Regex.IsMatch(fName, @"[A-Z]{1}[a-z]{2,}")) //validates the entered first name//
            {
                Console.Write("Invalid first name!");
                Console.WriteLine("Enter a valid first name: "); fName = Console.ReadLine();
            }
            Console.Write("Enter your surname: "); string surname = Console.ReadLine();
            while (!Regex.IsMatch(surname, @"[A-Z]{1}[a-z]{2,}")) //validates the entered surname//
            {
                Console.Write("Invalid surname!");
                Console.WriteLine("Enter a valid surname: "); surname = Console.ReadLine();
            }

            Console.WriteLine($"\nHello {fName} {surname}, what to you want to do");

            while (true)
            {
                Console.WriteLine("\nA.Generate Password"); //option A to generate a password//
                Console.WriteLine("B.Generate Email");  //option B to generate an email//
                Console.WriteLine("C. Exit the program.");   //option to exit//
                string userChoice = Console.ReadLine(); //user input to choose either one of this options//

                if (userChoice == "A")
                {
                    addChars(ref chars);
                    Console.WriteLine("Enter the length of your desired password: "); //the length of password
                    int length = 0;
                    if (int.TryParse(Console.ReadLine(), out length))
                    {
                        Console.WriteLine(GeneratePassword(length)); //generates and displays the password/passwords//
                    }
                }
                else if (userChoice == "B")
                {
                    string[] lowerCharacters = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; //string array with only lowercase letters//
                    string[] upperCharacters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }; //string array with only uppercase letter//
                    string[] mixedCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }; //string array with mixed case letter//
                    Random random = new Random();
                    int emailLength = 15; //the average length of an email address//
                    Console.WriteLine("What do you want your email to contain?");
                    Console.WriteLine("A. Only lower case characters"); //generates email with lowercase letters//
                    Console.WriteLine("B. Only upper case characters"); //generates email with uppercase letters//
                    Console.WriteLine("C.Both"); //generates email which contains uppercase and lowercase letters//
                    string EmUsChoice = Console.ReadLine(); //which option the user decides//
                    Console.WriteLine("How many emails do you want to be generated? "); int EmLength = int.Parse(Console.ReadLine()); //the amount of emails the user wants the program to generate//

                    if (EmUsChoice == "A") //this will generate an example email/emails containing lowercase letters//
                    {
                        for (int i = 0; i < EmLength; i++)
                        {
                            string email = "";
                            for (int b = 0; b < emailLength; b++)
                            {
                                email += lowerCharacters[random.Next(0, 26)];
                            }
                            email += "@example.com";
                            Console.WriteLine(email);
                        }
                    }
                    else if (EmUsChoice == "B") //this will generate an example email/emails containing uppercase letters//
                    {
                        for (int l = 0; l < EmLength; l++)
                        {
                            string email = "";
                            for (int a = 0; a < emailLength; a++)
                            {
                                email += upperCharacters[random.Next(0, 26)];
                            }
                            email += "@example.com";
                            Console.WriteLine(email);
                        }
                    }
                    else if (EmUsChoice == "C") //this will generate an example email/emails containing mixed letters//
                    {
                        for (int y = 0; y < EmLength; y++)
                        {
                            string email = "";
                            for (int q = 0; q < emailLength; q++)
                            {
                                email += mixedCharacters[random.Next(0, 42)];
                            }
                            email += "@example.com";
                            Console.WriteLine(email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid action!");
                        Console.WriteLine("Enter a valid function: "); string UsEmChoice = Console.ReadLine();
                    }

                }
                else if (userChoice == "C")
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
        static string GeneratePassword(int length) //this method is used in the process of generating the password/passswordsD//
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
        static void addChars(ref List<char> chars) //this is used in the process of generating the letters in the password/passwords
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
