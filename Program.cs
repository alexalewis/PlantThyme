using System;
using System.Linq;

namespace PlantThyme
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new PlantContext();
      var newPlant = new Plant();


      Console.WriteLine("Welcome to Party Thyme!");




      bool isRunning = true;
      while (isRunning == true)
      {
        Console.WriteLine("Which would you like to do with your plants? (VIEW), see which (NEED) watered, (PLANT), (REMOVE),  (WATER), get a (LOCATION) summary, or (QUIT)?");
        var input = Console.ReadLine().ToLower();

        if (input == "plant")
        {
          Console.WriteLine("What species would you like to plant?");
          newPlant.Species = Console.ReadLine();

          Console.WriteLine("Where is your plant located?");
          newPlant.LocatedPlant = Console.ReadLine().ToLower();

          Console.WriteLine("How much light does your plant need?");
          newPlant.LightNeeded = Console.ReadLine().ToLower();

          Console.WriteLine("How much water does your plant need?");
          newPlant.WaterNeeded = Console.ReadLine().ToLower();

          newPlant.LastWatered = DateTime.Now;
          newPlant.PlantDate = DateTime.Now;

          db.Plants.Add(newPlant);

          db.SaveChanges();
        }

        else if (input == "remove")
        {
          Console.WriteLine("Which plant would you like to remove?");
          var removePlant = Console.ReadLine().ToLower();

          var plantToDelete = db.Plants.First(p => p.Species == removePlant);
          db.Plants.Remove(plantToDelete);
          db.SaveChanges();
        }
        else if (input == "water")
        {
          Console.WriteLine("Which plant do you want to water?");
          var water = Console.ReadLine().ToLower();
          var plantToWater = db.Plants.First(p => p.Species == water);
          plantToWater.LastWatered = DateTime.Now;
          db.SaveChanges();
        }
        else if (input == "location")
        {
          Console.WriteLine("Which plant location would you like to see?");
          var location = Console.ReadLine().ToLower();

          var viewLocatedPlants = db.Plants.Where(p => p.LocatedPlant == location);
          foreach (var plant in viewLocatedPlants)
          {
            Console.WriteLine($"Your {plant.Species} is planted in/at {plant.LocatedPlant}.");
          }
        }
        else if (input == "view")
        {
          var viewCurrentPlants = db.Plants.OrderBy(p => p.LocatedPlant);
          foreach (var plant in viewCurrentPlants)
          {
            Console.WriteLine($"Your {plant.Species} is planted in/at {plant.LocatedPlant}.");
          }
        }
        else if (input == "need")
        {
          var plantsNeedWater = db.Plants.OrderBy(p => p.LastWatered);
          foreach (var plant in plantsNeedWater)
          {
            Console.WriteLine($"Your {plant.Species} needs water.");
          }
        }
        else if (input == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}
