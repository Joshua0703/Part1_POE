using System;

namespace RecipeApplication
{
    //Class declaration
    class Recipe
    {
        private string name;
        private int numberIngredients;
        private string[] ingredients;
        private int[] quantities;
        private int[] originalQuantities;
        private string[] units;
        private int numberSteps;
        private string[] steps;

        public Recipe()
        {
            // Simple constructor
        }
//Statement used to display option to user
        public void EnterRecipe()
        {
            Console.WriteLine("Enter recipe name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter number of ingredients:");
            numberIngredients = int.Parse(Console.ReadLine());
            ingredients = new string[numberIngredients];
            quantities = new int[numberIngredients];
            originalQuantities = new int[numberIngredients];
            units = new string[numberIngredients];

            for (int i = 0; i < numberIngredients; i++)
            {
                Console.WriteLine("\nIngredient " + (i + 1) + ":");
                Console.WriteLine("--------------------");
                Console.WriteLine("Enter name of ingredient " + (i + 1) + ":");
                ingredients[i] = Console.ReadLine();
                Console.WriteLine("Enter quantity of ingredient " + (i + 1) + ":");
                quantities[i] = int.Parse(Console.ReadLine());
                originalQuantities[i] = quantities[i];
                Console.WriteLine("Enter unit of measurement for ingredient " + (i + 1) + ":");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("\n\nEnter number of steps:");
            Console.WriteLine("------------------------");
            numberSteps = int.Parse(Console.ReadLine());
            steps = new string[numberSteps];

            for (int i = 0; i < numberSteps; i++)
            {
                Console.WriteLine("Enter description of step " + (i + 1) + ":");
                steps[i] = Console.ReadLine();
            }
        }
//Statement to display recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Your Recipe: \n");
            Console.WriteLine("Recipe Name: " + name);
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < numberIngredients; i++)
            {
                Console.WriteLine("- " + quantities[i] + " " + units[i] + " of " + ingredients[i]);
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < numberSteps; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }
//statement used to scale quantities 
        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < numberIngredients; i++)
            {
                quantities[i] = (int)Math.Round(quantities[i] * factor);
            }
        }
//statement to clear quantities for the recipe
        public void ClearQuantities()
        {
            // Reset quantities to their original values
            for (int i = 0; i < numberIngredients; i++)
            {
                quantities[i] = originalQuantities[i];
            }
        }
// Statement to clear the recipe
        public void ClearRecipe()
        {
            name = null;
            numberIngredients = 0;
            ingredients = null;
            quantities = null;
            units = null;
            numberSteps = 0;
            steps = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        recipe.EnterRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                        double factor = Console.Read();
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        recipe.ClearQuantities();
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        break;
                    case 6:
                        Console.WriteLine("Finshed & Thank You... Goodbye...");
                        break;

                }
            }
        }
    }
}