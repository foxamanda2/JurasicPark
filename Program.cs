using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace JurasicPark
{
    class Dinosaurs
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired;
        public int Weight { get; set; }

        public int EnclosureNumber { get; set; }

    }



    class Program
    {

        static void Greetings(string message)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();
        }

        static string promptforstring(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            return input;
        }

        static void Main(string[] args)
        {

            // var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);


            var dinosaurs = new List<Dinosaurs>()
            {
              new Dinosaurs()
              {
               Name = "Bobby",
               DietType = "Herbivore",
               WhenAcquired = DateTime.Today,
               Weight = 500,
               EnclosureNumber = 1,
              },

            new Dinosaurs()
            {
                Name = "Sarah",
                DietType = "Carnivore",
                WhenAcquired = DateTime.Today,
                Weight = 400,
                EnclosureNumber = 2,
            },
            new Dinosaurs()
            {
                Name = "Violet",
                DietType = "Carnivore",
                WhenAcquired = DateTime.Today,
                Weight = 250,
                EnclosureNumber = 3,
            }
            };

            Greetings("Welcome to the dino zoo");

            var QuitZoo = false;

            while (QuitZoo == false)
            {

                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("View");
                Console.WriteLine("Add");
                Console.WriteLine("Remove");
                Console.WriteLine("Transfer");
                Console.WriteLine("Summary");
                Console.WriteLine("Quit");

                var userchoice = Console.ReadLine().ToLower().Trim();
                if (userchoice == "view")
                {
                    Console.WriteLine("Would you like to view Dinosaurs in/by: ");
                    Console.WriteLine("Zoo");
                    Console.WriteLine("Intake Date");
                    Console.WriteLine("Enclosure");


                    var viewchoice = Console.ReadLine().ToLower().Trim();
                    if (viewchoice == "zoo")
                    {
                        var intakeorder = dinosaurs.OrderBy(dino => dino.WhenAcquired);
                        if (dinosaurs.Count != 0)
                        {


                            foreach (var dino in intakeorder)
                            {

                                Console.WriteLine($" The dinosaurs name is {dino.Name} their diet is {dino.DietType}.\n They were acquired on {dino.WhenAcquired}.\n Their weight is {dino.Weight} lbs.\n They are in enclosure {dino.EnclosureNumber}");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry you have no Dinosaurs in your zoo");
                        }
                    }

                    if (viewchoice == "intake date")
                    {
                        var YOrN = promptforstring("Would you like to see a Dinosaur acquired after a certain date? Y or N? ").ToLower();
                        if (YOrN == "y" || YOrN == "yes")
                        {
                            var date = DateTime.Parse(promptforstring("What date are you looking for? "));
                            var datefound = dinosaurs.Where(dinodate => dinodate.WhenAcquired >= date);
                            foreach (var dino in datefound)
                            {
                                Console.WriteLine($"{dino.Name} was acquired on {date}");
                            }


                        }
                    }

                    if (viewchoice == "enclosure")
                    {
                        var enclosurenumber = int.Parse(promptforstring("What enclosure would you like? "));
                        var enclosure = dinosaurs.Where(enclosure => enclosure.EnclosureNumber == enclosurenumber);
                        if (enclosure.Count() != 0)
                        {
                            Console.WriteLine($"The Dinosaur located in {enclosurenumber} is: ");
                            foreach (var dino in enclosure)
                            {
                                Console.WriteLine($" The dinosaurs name is {dino.Name} their diet is {dino.DietType}.\n They were acquired on {dino.WhenAcquired}.\n Their weight is {dino.Weight} lbs.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no Dinosaurs in this enclosure");
                        }
                    }


                }



                if (userchoice == "add")
                {
                    var newName = promptforstring("What is your Dinosaurs name? ");

                    var newDietType = promptforstring("What is your Dinosaurs diet type? ");

                    var newWeight = int.Parse(promptforstring("What is your Dinosaurs weight? "));

                    var newEnclosure = int.Parse(promptforstring("What is your Dinosaurs enclosure number? "));

                    var newDino = new Dinosaurs();
                    newDino.Name = newName;
                    newDino.DietType = newDietType;
                    newDino.WhenAcquired = DateTime.Today;
                    newDino.Weight = newWeight;
                    newDino.EnclosureNumber = newEnclosure;

                    dinosaurs.Add(newDino);
                }

                if (userchoice == "remove")
                {
                    var dinoName = promptforstring("What Dinosaur do you want to remove? ").ToLower();


                    var FindDino = dinosaurs.Find(dino => dino.Name == dinoName);

                    dinosaurs.Remove(FindDino);


                }

                if (userchoice == "transfer")
                {

                    var dinoName = promptforstring("What Dinosaur are you trying to transfer: ").ToLower();

                    var FindDino = dinosaurs.Find(dino => dino.Name.ToLower() == dinoName);

                    var TransferEnclosure = promptforstring("What enclosure do you want them to switch to?");

                    FindDino.EnclosureNumber = int.Parse(TransferEnclosure);


                }

                if (userchoice == "summary")
                {

                    var carnivores = dinosaurs.Where(dino => dino.DietType == "Carnivore" || dino.DietType == "carnivore");
                    var herbivores = dinosaurs.Where(dino => dino.DietType == "Herbivore" || dino.DietType == "herbivore");
                    var carnCount = carnivores.Count();
                    var herbCount = herbivores.Count();

                    Console.WriteLine($"There are {carnCount} carnivores in the zoo and {herbCount} herbivores in the zoo.");
                    Console.WriteLine("\n");

                    Console.Write("Would you like to see a list of the Carnivores or Herbivores? Yes or No? ");
                    Console.WriteLine("\n");
                    var YesOrNo = Console.ReadLine().ToLower();

                    if (YesOrNo == "yes" || YesOrNo == "y")
                    {
                        Console.WriteLine("\n");
                        var HOrC = promptforstring("Do you want to see Carnivores or Herbivores? H or C? ").ToLower();
                        if (HOrC == "h")
                        {
                            foreach (var herb in herbivores)
                            {
                                Console.WriteLine($" The dinosaurs name is {herb.Name} their diet is {herb.DietType}.\n They were acquired on {herb.WhenAcquired}.\n Their weight is {herb.Weight} lbs.\n They are in enclosure {herb.EnclosureNumber}");
                            }
                        }
                        if (HOrC == "c")
                        {
                            foreach (var carn in carnivores)
                            {
                                Console.WriteLine($" The dinosaurs name is {carn.Name} their diet is {carn.DietType}.\n They were acquired on {carn.WhenAcquired}.\n Their weight is {carn.Weight} lbs.\n They are in enclosure {carn.EnclosureNumber}");
                            }
                        }

                    }

                }


                if (userchoice == "quit")
                {
                    QuitZoo = true;
                }

            }

            var fileWriter = new StreamWriter("dinosaurs.csv");

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(dinosaurs);

            fileWriter.Close();

            Greetings("You have left the Dino Zoo");
        }
    }
}

