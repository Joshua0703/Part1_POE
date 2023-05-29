using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    {
        public string RecipeName { get; set; } // get,set to enter name of the recipe
        public int NumOfIngredients { get; set; } //get,set for NumOfIngreidents
        public List<Ingredient> Ingredients { get; set; }// List the number of Ingreidents
        public int NumOfSteps { get; set; } // List the steps in integers
        public List<string> Steps { get; set; }

        public Recipe(string name)
        {
            RecipeName = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void Print()
        {
            Console.WriteLine($"Recipe: {RecipeName}");//output to ask the name of the recipe
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < NumOfIngredients; i++)
            {
                Console.WriteLine($"{Ingredients[i].Name}: {Ingredients[i].Quantity} {Ingredients[i].Unit} ({Ingredients[i].FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < NumOfSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }
        // calculates the calrories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void ExplainCalorieRange()
        {
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories < 100)
            {
                Console.WriteLine("This recipe is low in calories.");
            }
            else if (totalCalories >= 100 && totalCalories <= 300) // will show that the calories are moderate amount in calroies
            {
                Console.WriteLine("This recipe has a moderate amount of calories.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;  // shows a red colour when the user has
                Console.WriteLine("This recipe is high in calories.");
                Console.ResetColor();
            }
        }
    }
    // Class showing the ingreidents
    class Ingredient
    {
        public string Name { get; set; } // get, set to get the recipe name
        public double Quantity { get; set; } // get, set to get the quanity
        public string Unit { get; set; } // get, set to get unit of measurment
        public double Calories { get; set; } // get, set to get the calories
        public string FoodGroup { get; set; } // get,set to add the food group its in
    }
    // Display available food group options
    private static readonly List<string> AvailableFoodGroups = new List<string> { "Fruits", "Vegetables", "Grains", "Proteins", "Dairy", "Fats and Oils" };


    public static void DisplayFoodGroupOptions()
    {
        Console.WriteLine("Available Food Groups:");
        for (int i = 0; i < AvailableFoodGroups.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {AvailableFoodGroups[i]}");
        }
    }

    static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>();
        /*
       Used to store the recipe which grows
       dynamically and can store unlimited recipes
       */


        while (true)
        {
            Console.WriteLine("Sanele's Recipe Book");
            Console.WriteLine();
            Console.WriteLine("Pick the command you would like to use:");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. View Recipes");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // allows the user to enter the name of the recipe
                    Console.WriteLine("Enter the name of the recipe:");

                    string recipeName = Console.ReadLine();
                    Recipe newRecipe = new Recipe(recipeName);

                    // shows the number of ingreidents
                    Console.WriteLine("Enter the number of ingredients you would like to add:");
                    newRecipe.NumOfIngredients = int.Parse(Console.ReadLine());

                    for (int i = 0; i < newRecipe.NumOfIngredients; i++)
                    {
                        Console.WriteLine($"Please enter the name of ingredient {i + 1}:");
                        string name = Console.ReadLine();

                        Console.WriteLine($"Please enter the quantity of ingredient {i + 1}:");
                        double quantity = double.Parse(Console.ReadLine());

                        Console.WriteLine($"Please enter the unit of ingredient {i + 1}:");
                        string unit = Console.ReadLine();

                        Console.WriteLine($"Please enter the number of calories for ingredient {i + 1}:");
                        double calories = double.Parse(Console.ReadLine());

                        Console.WriteLine($"Please select the food group for ingredient {i + 1}:");
                        DisplayFoodGroupOptions();
                        int foodGroupIndex = int.Parse(Console.ReadLine()) - 1;
                        string foodGroup = AvailableFoodGroups[foodGroupIndex];

                        newRecipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
                    }

                    Console.WriteLine("Please enter the number of steps:");
                    newRecipe.NumOfSteps = int.Parse(Console.ReadLine());

                    for (int i = 0; i < newRecipe.NumOfSteps; i++)
                    {
                        Console.WriteLine($"Please enter step {i + 1}:");
                        string step = Console.ReadLine();
                        newRecipe.Steps.Add(step);
                    }

                    recipes.Add(newRecipe);
                    break;

                // display no recipes found if recipe is not there
                case "2":
                    if (recipes.Count == 0)
                    {
                        Console.WriteLine("No recipes found.");
                    }
                    else
                    {
                        recipes = recipes.OrderBy(r => r.RecipeName).ToList();
                        //OrderBy method stores the recipes in Alphabetical

                        Console.WriteLine("Recipes:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].RecipeName}");
                        }

                        Console.WriteLine("Enter the number of the recipe you want to view:");
                        int recipeIndex = int.Parse(Console.ReadLine()) - 1;
                        // if statement to calculate the calroies if its above 300

                        if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                        {
                            Recipe selectedRecipe = recipes[recipeIndex];
                            selectedRecipe.Print();
                            selectedRecipe.ExplainCalorieRange();
                        }
                        else
                        {
                            Console.WriteLine("Invalid recipe number.");
                        }
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}