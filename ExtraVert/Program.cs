using System.IO.Compression;
using ExtraVert;

string greeting = @"Welcome to Plant World!";

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Spider Plant",
        LightNeeds = 4,
        AskingPrice = 20.0M,
        City = "Nashville",
        ZIP = 37216,
        Sold = false,
    },
    new Plant()
    {
        Species = "Pothos",
        LightNeeds = 3,
        AskingPrice = 20.0M,
        City = "Madison",
        ZIP = 37115,
        Sold = false,
    },
    new Plant()
    {
        Species = "Lucky Bamboo",
        LightNeeds = 2,
        AskingPrice = 25.0M,
        City = "Atlanta",
        ZIP = 30002,
        Sold = false,
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4,
        AskingPrice = 20.0M,
        City = "Nashville",
        ZIP = 37206,
        Sold = false,
    },
    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 4,
        AskingPrice = 20.0M,
        City = "Savannah",
        ZIP = 31302,
        Sold = false,
    }

};

Console.WriteLine(greeting);

foreach (var plant in plants)
{
    Console.WriteLine($"Species: {plant.Species}, City: {plant.City}, ZIP: {plant.ZIP}, Price: {plant.AskingPrice}, Sold: {plant.Sold}");
}
