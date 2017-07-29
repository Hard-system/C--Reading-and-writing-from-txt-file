using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ////the symbol @ helps for telling that this is a string literal there are not escape- 
            ////characters in there..  the other more ugly way is: instead one \ we can put two \\ and it will work  
            string filePath = @"C:\Users\Miroslav\Desktop\Demos\Text.txt";
            ////read all lines of text inside of the txt file
            //List<string> lines = File.ReadAllLines(filePath).ToList();

            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}


            List<Person> people = new List<Person>();
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                //Tozi Split mi pomaga da slaga mqsto tochno tam kydeto ima zapetaika v tekstoviq file mejdu dannite
                string[] entries = line.Split(','); //in this way I am splitting the line of multiple entries based upon a comma delimitation

                Person newPerson = new Person();
                newPerson.FirstName = entries[0];
                newPerson.Email = entries[1];
                newPerson.Country = entries[2];

                people.Add(newPerson);
            }
            Console.WriteLine("Read from text file!");
            foreach (var person in people)
            {
                //the $ sign give us option to put curly brace and inside a CSharp code
                //similar example could be: person.FirstName + " " + person.Email + " " + person.Country
                Console.WriteLine($"{ person.FirstName }: { person.Email } { person.Country }");
            }
            //here I did not have new object person but I can- 
            //write simply the properties
            people.Add(new Person { FirstName = "John", Email = "service@user.com", Country = "Australia" });
            //Below I put this new person object and save it in the txt file

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{ person.FirstName }, { person.Email }, { person.Country }");
            }
            Console.WriteLine("Writing to text file!");


            File.WriteAllLines(filePath, output);
            //As many times as I run the project as many times the new object person will be saved in the file
            Console.WriteLine("All entries written!");

            Console.ReadLine();
        }
    }
}
