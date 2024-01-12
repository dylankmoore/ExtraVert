using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO.Compression;
using System.Linq.Expressions;
using ExtraVert;

string greeting = @"Welcome to Extra Vert! Your one stop shop for a wide selection of plants.";

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 4,
        AskingPrice = 20.00M,
        City = "Nashville",
        ZIP = 37216,
        Sold = false,
        AvailableUntil = new DateTime(2024, 3, 14)
    },
    new Plant()
    {
        Species = "Pothos",
        LightNeeds = 3,
        AskingPrice = 25.00M,
        City = "Madison",
        ZIP = 37115,
        Sold = false,
        AvailableUntil = new DateTime(2024, 2, 25)
    },
    new Plant()
    {
        Species = "Lucky Bamboo",
        LightNeeds = 2,
        AskingPrice = 15.00M,
        City = "Atlanta",
        ZIP = 30002,
        Sold = false,
        AvailableUntil = new DateTime(2024, 4, 16)
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4,
        AskingPrice = 30.00M,
        City = "Nashville",
        ZIP = 37206,
        Sold = false,
        AvailableUntil = new DateTime(2024, 1, 31)
    },
    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 4,
        AskingPrice = 29.00M,
        City = "Savannah",
        ZIP = 31302,
        Sold = false,
        AvailableUntil = new DateTime(2024, 3, 29)
    }

};

Random random = new();


Console.WriteLine(greeting);
Console.WriteLine("\n");

// plant drawing
string PlantDrawing()
{
    string plantArt =
        "   ^\n" +
        "  ^^^\n" +
        " ^^^^^\n" +
        "^^^^^^^\n" +
        "   |\n" +
        "   |\n";
    Console.WriteLine(plantArt);
    return plantArt;
}

string plantArt = PlantDrawing();
string choice = null;
    while (choice != "0")
    {
        Console.WriteLine(@"Choose from the main menu:
    0. Exit
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5. Plant of the day
    6. Search light needs of plants
    7. View App Statistics
    8. Clear Console
");

    choice = Console.ReadLine();
    switch (choice)
    {
        case "0":
            Console.WriteLine("Thank you! Goodbye!");
            break;
        case "1":
            Console.WriteLine(@"A list of all of our plants:");
            ViewPlants();
            break;
        case "2":
            Console.WriteLine(@"Add a plant to inventory!");
            PostPlant();
            break;
        case "3":
            Console.WriteLine(@"Adopt a plant!");
            AdoptPlant();
            break;
        case "4":
            Console.WriteLine(@"Delist a plant");
            DelistPlant();
            break;
        case "5":
            Console.WriteLine(@"Discover the plant of the day!");
            PlantOfTheDay();
            break;
        case "6":
            Console.WriteLine(@"Search plants by their light needs!");
            SearchLightNeeds();
            break;
        case "7":
            ViewStats();
            break;
        case "8":
            Console.Clear();
            break;
             default:
            Console.WriteLine("Invalid Selection. Please enter a number between 0 and 8.\n\n");
            break;
    }
}

// view plants
void ViewPlants()
{
    // i is an index variable that starts at 0 & increases by 1 until it reaches the count of plants //

        for(int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
            // $"" is string interpolation - this line utilizes the plant index & details
            // {i + 1} adds the plant number
            Console.WriteLine($"\n{i + 1}.) {PlantDetails(plants[i])}");
        }
    }
}

// post a plant
void PostPlant()
{
    try
    {
    string plantSpecies = "";
    while (String.IsNullOrWhiteSpace(plantSpecies))
    { 
        Console.WriteLine("Enter the plant species: \n");
        plantSpecies = Console.ReadLine();
            
        if (String.IsNullOrWhiteSpace(plantSpecies))
        {
            Console.WriteLine("\nError: Plant species cannot be empty. Please enter a valid plant species. \n");
        }
    }

    int lightNeeds = 0;
    while (lightNeeds < 1 || lightNeeds > 5)
    {
        Console.WriteLine("\nEnter the light needs of the plant on a scale of 1-5: \n");
        if (!int.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1 || lightNeeds > 5)
        {
            Console.WriteLine("\nError: Invalid input. Please enter a number between 1 and 5. \n");
        }
    }

    decimal askingPrice = 0;
    while (askingPrice <= 0)
    {
    Console.WriteLine("\nEnter the plant's price: \n");
    if (!Decimal.TryParse(Console.ReadLine(), out askingPrice) || askingPrice <= 0)
    {
        Console.WriteLine("\nError: Invalid input. Enter a decimal number for the price. \n");
      }
    }

    string city = "";
    while (String.IsNullOrWhiteSpace(city))
    {
        Console.WriteLine(" \nEnter the city: \n");
        city = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("Error: Invalid input. Enter the name of the city.\n");
        }
    }

    string zip = "";
    while (String.IsNullOrWhiteSpace(zip) || zip.Length != 5)
    {
        Console.WriteLine("\nEnter the zip code: \n");
        zip = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(zip))
        {
            Console.WriteLine("\nError: Invalid input. Please enter a valid numeric zip code. \n");
        }
        else if (zip.Length != 5)
        {
            Console.WriteLine("\nError: Invalid zip code. Please enter a 5-digit number. \n");
        }
    }
    int zipCode = int.Parse(zip);
        Console.WriteLine($"\nValid zip code entered: {zipCode} \n");

    Console.Write("Enter the plant's expiration year:\n");
    int year = int.Parse(Console.ReadLine());

    Console.Write("\nEnter the plant's expiration month:\n");
    int month = int.Parse(Console.ReadLine());

    Console.Write("\nEnter the plant's expiration day: \n");
    int day = int.Parse(Console.ReadLine());

    DateTime expirationDate = new DateTime(year, month, day);

    // creating a new plant object
    Plant newPlant = new()
        {
            Species = plantSpecies,
            LightNeeds = lightNeeds,
            AskingPrice = askingPrice,
            City = city,
            ZIP = zipCode,
            Sold = false,
            AvailableUntil = expirationDate,
        };
        plants.Add(newPlant);

        Console.WriteLine("\nYou have successfully added a plant! \n");
    }
    //handling an exception & error msg if exception is caught
catch (ArgumentOutOfRangeException exception)
    {
    Console.WriteLine($"Error: {exception.Message}");
    }
}


// adopt a plant
    void AdoptPlant()
{   //filter through plants that are not sold & still available
    List<Plant> availablePlants = plants
        .Where(plant => !plant.Sold && plant.AvailableUntil > DateTime.Now)
        .ToList();
    //if there are no available plants
    if (availablePlants.Count == 0)
    { //send error msg
        Console.WriteLine("\nSorry, there are no available plants to adopt at this time.\n");
        return;
    }
    //display available plants
    Console.WriteLine("\nAvailable Plants:");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"\n{i + 1}. {availablePlants[i].Species}");
    }

    Console.WriteLine("\nSelect which plant you want to adopt:\n");
    //read & parse user input for chosen plant
    if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex > 0 && choiceIndex <= availablePlants.Count)
    {  //get chosen plant
        Plant chosenPlant = availablePlants[choiceIndex - 1];
        //make sure it is available
        if (!chosenPlant.Sold)
        { //mark the chosen plant as sold
            chosenPlant.Sold = true;
            Console.WriteLine($"\nCongratulations! You have adopted {chosenPlant.Species}!\n");
        }
        else
        { //error if chosen plant is not available
            Console.WriteLine($"\nError: Invalid selection, {chosenPlant.Species} is not currently available.\n");
        }
    }
    else
    { //error if input is invalid
        Console.WriteLine("\nError: Invalid input. Please enter the number of the plant you wish to adopt.\n");
    }
}

// delist a plant
    void DelistPlant()
    {
    while (true)
    {
        Console.WriteLine("\nEnter the number of the plant to delist: \n");
        //display plants w/ their index numbers
        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"\n{i + 1}. {plants[i].Species}\n");
        }
        //read and parse user's selection
        if (int.TryParse(Console.ReadLine(), out int choiceIndex))
        {   // check user's choice
            if (choiceIndex == 0)
            {   //selecting 0 exits to the main menu
                break;
            }
            if (choiceIndex >= 1 && choiceIndex <= plants.Count)
            {   //if valid number is entered, delist plant
                plants.RemoveAt(choiceIndex - 1);
                Console.WriteLine($"\nYou have delisted this plant.\n");
                break;
            }
            else
            {   //error msg for invalid plant selection
                Console.WriteLine("\nError: Invalid Selection. Please enter a valid plant number or 0 to see the main menu.\n");
            }
        }
        else
        {       //error msg for invalid input
            Console.WriteLine("\nError: Invalid Input. Please enter a valid number or 0 to see the main menu.\n");
            Console.ReadLine();
        }
    }
}

// random plant of the day
void PlantOfTheDay()
{
    Plant randomPlant = null!;
    int randomIndex;


    // do while loop is randomly selecting a plant from the plants list until it finds one that is not sold - sold is false
    do
    {
        randomIndex = random.Next(0, plants.Count);
        randomPlant = plants[randomIndex];
    }

    while (randomPlant.Sold);

    Console.WriteLine("\n");
    string plantArt = PlantDrawing();
    Console.WriteLine($"{randomPlant.Species} is the plant of the day! \n" +
        $"{randomPlant.Species} has a light need of {randomPlant.LightNeeds} on a scale of 1-5. \n" +
        $"It is located in {randomPlant.City} & costs ${randomPlant.AskingPrice} dollars. \n" +
        $"It will be available to purchase until {randomPlant.AvailableUntil}.");
    Console.WriteLine("\n");
}

// search plant's night needs
void SearchLightNeeds()
{
    Console.WriteLine("\nEnter a maximum light need between numbers 1 (shade) and 5 (full sun):\n");

    if (!int.TryParse(Console.ReadLine(), out int response) || response < 1 || response > 5)
    {
        Console.WriteLine("\nError: Invalid Input. Enter a valid number between 1 & 5:\n");
        return;
    } // filter plants based on user's input for light needs & availability
        List<Plant> availablePlants = plants
        .Where(plant => plant.LightNeeds == response && !plant.Sold)
        .ToList();
        
        if (availablePlants.Count == 0)
        {
            Console.WriteLine("\nThere are currently no available plants for this selection.\n");
        }
        else
        {   //display available plants & their species
            for (int i = 0; i < availablePlants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availablePlants[i].Species}\n");
            }
        }
    }

// view app stats
void ViewStats()
{
    Console.WriteLine("\nView app statistics:\n");

    Plant lowestPricePlant = plants.OrderBy(plant => plant.AskingPrice).FirstOrDefault();
    Console.WriteLine($"Plant with the lowest price: {lowestPricePlant?.Species ?? "N/A"}");

    int availablePlants = plants.Count(plant => !plant.Sold && plant.AvailableUntil > DateTime.Now);
    Console.WriteLine($"\nNumber of plants available: {availablePlants}");

    Plant highestLightPlant = plants.OrderByDescending(plant => plant.LightNeeds).FirstOrDefault();
    Console.WriteLine($"\nPlant with the highest night needs: {highestLightPlant?.Species ?? "N/A"}");

    //F2 is a format specifier so that the output will be precise
    double averageLightNeeds = plants.Where(plant => !plant.Sold).Average(plant => plant.LightNeeds);
    Console.WriteLine($"\nAverage light needs: {averageLightNeeds:F2}");

    double percentageAdopted = (double)plants.Count(plant => plant.Sold) / plants.Count * 100;
    Console.WriteLine($"\nPercentage of plants adopted: {percentageAdopted:F2}\n");
    }

// plant details
string PlantDetails(Plant plant)
{
    string plantString = $"Species: {plant.Species}\n" +
    $"Light Needs: {plant.LightNeeds} \n" +
    $"Asking Price: {plant.AskingPrice} \n" +
    $"City: {plant.City} \n" +
    $"ZIP: {plant.ZIP} \n" +
    $"Sold: {plant.Sold} \n" +
    $"Available Until: {plant.AvailableUntil} \n";

    return plantString;
}