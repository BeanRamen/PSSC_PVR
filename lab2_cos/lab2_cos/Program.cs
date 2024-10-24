using System;
using System.Collections.Generic;

namespace lab2_cos
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("BAG BAG BAG BHAG");
            
            UnValidCart[] listOfShoppies = ReadListOfShoppies().ToArray();
            Bag.UnvalidatedBag unvalidatedCart = new(listOfShoppies);
            Bag.IBag result = ValidateBagShoppies(unvalidatedCart);
        }
        Bag.IBag finalResult = result switch
        {
            Bag
        }

        private static List<UnValidCart> ReadListOfShoppies()
        {
            List<UnValidCart> listOfShoppies = [];
            Console.WriteLine("Enter the registration number and grade for each produc. Press enter without typing anything to finish.");
            do
            {
                string? registrationNumber = ReadValue("Registration Number: ");
                if (string.IsNullOrEmpty(registrationNumber))
                {
                    break;
                }

                string? pricy = ReadValue("Price: ");
                if (string.IsNullOrEmpty(pricy))
                {
                    break;
                }

                listOfShoppies.Add(new(registrationNumber, pricy));
            } while (true);
            return listOfShoppies;
        }

        private static Bag.IBag ValidateBagShoppies(Bag.UnvalidatedBag unvalidatedCart)=>
        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
