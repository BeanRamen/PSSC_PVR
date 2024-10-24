using lab3.Models;
using lab3.Workflows;

using System;
using System.Collections.Generic;
using System.Linq;

using static lab3.Models.ItemPublishedEvent;

namespace lab3
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      UnvalidatedCartPrice[] listOfPrices = ReadListOfPrices().ToArray();      
      PublishItemCommand command = new(listOfPrices);
      PublishItemWorkflow workflow = new();
      IItemPublishedEvent result = workflow.Execute(command, CheckCartExists);

      string message = result switch
      {
        ItemPublishSucceededEvent @event => @event.Csv,
        ItemPublishFailedEvent @event => $"Publish failed: \r\n{string.Join("\r\n", @event.Reasons)}",
        _ => throw new NotImplementedException()
      };

      Console.WriteLine();
      Console.WriteLine("============================");
      Console.WriteLine("Catalog Preturi:");
      Console.WriteLine("============================");
      Console.WriteLine(message);
    }

    private static List<UnvalidatedCartPrice> ReadListOfPrices()
    {
      List<UnvalidatedCartPrice> listOfPrices = [];
      do
      {
        //read registration number and price and create a list of prices
        string? registrationNumber = ReadValue("Registration Number: ");
        if (string.IsNullOrEmpty(registrationNumber))
        {
          break;
        }

        string? itemPrice = ReadValue("Item Price: ");
        if (string.IsNullOrEmpty(itemPrice))
        {
          break;
        }

        string? TVA = ReadValue("TVA: ");
        if (string.IsNullOrEmpty(TVA))
        {
          break;
        }

        listOfPrices.Add(new(registrationNumber, itemPrice, TVA));
      } while (true);
      return listOfPrices;
    }

    private static string? ReadValue(string prompt)
    {
      Console.Write(prompt);
      return Console.ReadLine();
    }

    private static bool CheckCartExists(CartRegistrationNumber registrationNumber) =>
      existingCarts.Contains(registrationNumber.Value);

    private static readonly IEnumerable<string> existingCarts = ["1", "2", "3", "4"];
  }
}