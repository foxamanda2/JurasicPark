﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        static void Main(string[] args)
        {
            //  1.Create a welcome to the zoo




            var dinosaurs = new List<Dinosaurs>()
            {
              new Dinosaurs()
              {
            Name = "Bobby",
            DietType = "Herbivore",
            WhenAcquired = DateTime.Now,
            Weight = 500,
            EnclosureNumber = 1,
              },

            new Dinosaurs()
            {
                Name = "Sarah",
                DietType = "Carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 400,
                EnclosureNumber = 2,
            },
            new Dinosaurs()
            {
               Name = "Violet",
                DietType = "Carnivore",
                WhenAcquired = DateTime.Now,
                Weight = 250,
                EnclosureNumber = 3,
            }
            };

            Greetings("Welcome to the Zoo Database");

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

                    // var intakeDate = dinosaurs.OrderBy(intake => intake.WhenAcquired);


                    //   --Ask for list in order from when acquired
                    //   --print out entire list of details

                }

                if (userchoice == "add")
                {
                    Console.Write("What is your Dinosaurs name? ");
                    var newName = Console.ReadLine();

                    Console.Write("What is your Dinosaurs diet type? ");
                    var newDietType = Console.ReadLine();

                    Console.Write("What is your Dinosaurs weight? ");
                    var newWeight = int.Parse(Console.ReadLine());

                    Console.Write("What is your Dinosaurs enclosure number? ");
                    var newEnclosure = int.Parse(Console.ReadLine());

                    var newDino = new Dinosaurs();
                    newDino.Name = newName;
                    newDino.DietType = newDietType;
                    newDino.WhenAcquired = DateTime.Now;
                    newDino.Weight = newWeight;
                    newDino.EnclosureNumber = newEnclosure;

                    dinosaurs.Add(newDino);
                }

                if (userchoice == "remove")
                {
                    Console.WriteLine("What Dinosaur do you want to remove?");
                    var dinoName = Console.ReadLine();


                    var FindDino = dinosaurs.Find(dino => dino.Name == dinoName);

                    dinosaurs.Remove(FindDino);


                }

                if (userchoice == "transfer")
                {
                    Console.WriteLine("What Dinosaur are you trying to transfer");
                    var dinoName = Console.ReadLine();


                    var FindDino = dinosaurs.Find(dino => dino.Name == dinoName);

                    Console.WriteLine("What enclosure do you want them to switch to?");
                    var TransferEnclosure = int.Parse(Console.ReadLine());

                    FindDino.EnclosureNumber = TransferEnclosure;


                }

                if (userchoice == "summary")
                {

                    var carnivores = dinosaurs.Where(dino => dino.DietType == "Carnivore");
                    var herbivores = dinosaurs.Where(dino => dino.DietType == "Herbivore");
                    var carnCount = carnivores.Count();
                    var herbCount = herbivores.Count();

                    Console.WriteLine($"There are {carnCount} carnivores in the zoo and {herbCount} herbivores in the zoo.");
                    Console.WriteLine("\n");

                    Console.Write("Would you like to see a list of the Carnivores or Herbivores? Yes or No?");
                    Console.WriteLine("\n");
                    var YesOrNo = Console.ReadLine().ToLower();

                    if (YesOrNo == "yes" || YesOrNo == "y")
                    {
                        Console.Write("Do you want to see Carnivores or Herbivores? H or C?");
                        Console.WriteLine("\n");
                        var HOrC = Console.ReadLine().ToLower();
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




            //      var quitzoo = false;
            //             --Should all be in a boolean while loop Quit == false 2.Give menu options

            // -View(be able to view Dinosaurs in an order of when Acquired)
            //   --Ask for list in order from when acquired
            //   --print out entire list of details

            // - Add a Dinosour
            // --Ask all of the properties of the dino
            // --Add those properties to a new instance
            // --Add to dino list

            // - Remove
            // --Ask which dino to find
            // --find the dino
            // --remove the dino from list

            // -Transfer
            // --Ask which dino to transfer
            // --Find the dino
            // --Ask which enclosure to switch to
            // --Update the old enclosure

            // -Summary
            // --Add the diet type into a new list
            // --Count the number of Carnivores and Herbivores
            // --print out data

            // - Quit
            // --Boolean if Quit == true then exit loop

            // 3.Exit zoo Statement
            Greetings("You have left the Zoo Database");
        }
    }
}
