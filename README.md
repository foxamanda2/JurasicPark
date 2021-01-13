# JurasicPark

Problem
Make an application that manages a dinosaur zoo
C R U D

Create: Add (create) a new dinosaur to put into the zoo
Read: Get lists of dinosaurs in zoo - perhaps by different attributes.
Update: Transfer the dinosaur to a new enclosure.
Delete: Remove a dinosaur from the zoo.

Examples:

> When you view the dinosaurs in the zoo a list needs to be returned with a list
> of the dinosaurs ordered by when Acquired. If there are none print out there arent any.
> There should be a function where you can Add a dinosaur and a list will prompt you to add
> all of the properties to the new intake.
> There should be an option to remove a Dinosaur from your zoo by finding them by name.
> If a Dinosaur needs to be transferred you should be able to input a new enclosure number
> There needs to be an ability to print out the number of herbivores and Carnivores.
> Quit ability.

Name - Bobby
Diet Type- Herbivore or carnivore
When Acquired- Current time
Weight- 50lbs
Enclosure number- 1

Data:

Name-string
Diet-string
WhenAcquired- int
Weight-int
EnclosureNumber-int

These should all be properties belonging to a class Dinosaur.
We will place them all in a list

Algorithm

1. Create a welcome to the zoo

var quitzoo=false;
--Should all be in a boolean while loop Quit==false 2. Give menu options

- View (be able to view Dinosaurs in an order of when Acquired )
  --Ask for list in order from when acquired
  --print out entire list of details

-Add a Dinosour
--Ask all of the properties of the dino
--Add those properties to a new instance
--Add to dino list

-Remove
--Ask which dino to find
--find the dino
--remove the dino from list

-Transfer
--Ask which dino to transfer
--Find the dino
--Ask which enclosure to switch to
--Update the old enclosure

-Summary
--Add the diet type into a new list
--Count the number of Carnivores and Herbivores
--print out data

-Quit
--Boolean if Quit==true then exit loop

3. Exit zoo Statement
