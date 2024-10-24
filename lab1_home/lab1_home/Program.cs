using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab1_home
{
    public interface IQuantity { }

    public record UnitQuantity(int Cantitate) : IQuantity;

    public record KilogramQuantity(decimal Kilograme) : IQuantity;

    public record Produs(string Nume, decimal Pret);

    public record ItemCos(Produs Produs, IQuantity Cantitate);

    public class CosCumparaturi
    {
        private List<ItemCos> _items = new List<ItemCos>();

        public void AdaugaProdus(Produs produs, IQuantity cantitate)
        {
            _items.Add(new ItemCos(produs, cantitate));
        }

        public void EliminaProdus(Produs produs)
        {
            _items.RemoveAll(item => item.Produs == produs);
        }

        public decimal CalculeazaTotal()
        {
            return _items.Sum(item =>
                CalculeazaPret(item.Cantitate, item.Produs.Pret));
        }

        private decimal CalculeazaPret(IQuantity cantitate, decimal pretPeUnitate)
        {
            return cantitate switch
            {
                UnitQuantity u => u.Cantitate * pretPeUnitate,
                KilogramQuantity k => k.Kilograme * pretPeUnitate,
                _ => 0
            };
        }

        public void AfiseazaCos()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"Produs: {item.Produs.Nume}, Cantitate: {item.Cantitate}, Pret: {item.Produs.Pret}");
            }
            Console.WriteLine($"Total: {CalculeazaTotal()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cos = new CosCumparaturi();

            while (true)
            {
                Console.WriteLine("1. Adauga produs");
                Console.WriteLine("2. Elimina produs");
                Console.WriteLine("3. Afiseaza cos");
                Console.WriteLine("4. Iesi");

                var optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.WriteLine("Introdu numele produsului:");
                        var nume = Console.ReadLine();
                        Console.WriteLine("Introdu pretul produsului:");
                        var pret = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Unitate (u) sau kilogram (kg)?");
                        var tip = Console.ReadLine();
                        return tip switch
                        {
                            
                        }
                        
                    /*if (tip == "u")
                        {
                            Console.WriteLine("Introdu cantitatea:");
                            var cantitate = int.Parse(Console.ReadLine());
                            cos.AdaugaProdus(new Produs(nume, pret), new UnitQuantity(cantitate));
                        }
                        else if (tip == "kg")
                        {
                            Console.WriteLine("Introdu cantitatea in kilograme:");
                            var kilograme = decimal.Parse(Console.ReadLine());
                            cos.AdaugaProdus(new Produs(nume, pret), new KilogramQuantity(kilograme));
                        }*/

                    case "2":
                        Console.WriteLine("Introdu numele produsului de eliminat:");
                        var numeEliminat = Console.ReadLine();
                        cos.EliminaProdus(new Produs(numeEliminat, 0));
                        break;

                    case "3":
                        cos.AfiseazaCos();
                        break;

                    case "4":
                        return;
                }
            }
        }
    }
}
