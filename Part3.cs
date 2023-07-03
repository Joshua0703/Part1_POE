using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RecipeBook
{
    public partial class MainForm : Form
    {
        private List<Recipe> recipes;

        public MainForm()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Add any initialization code here if needed
            DisplayFoodGroupOptions();
        }

        private void DisplayFoodGroupOptions()
        {
            foodGroupListBox.Items.Clear();
            foodGroupListBox.Items.AddRange(Recipe.AvailableFoodGroups.ToArray());
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            // Add recipe logic
            // ...
        }

        private void viewRecipesButton_Click(object sender, EventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Create a copy of the recipes list to apply filters without changing the original list
                List<Recipe> filteredRecipes = new List<Recipe>(recipes);

                // Get the selected values from the controls for filtering
                string ingredientNameFilter = ingredientNameFilterTextBox.Text.Trim();
                string foodGroupFilter = foodGroupFilterComboBox.SelectedItem as string;
                double maxCaloriesFilter = (double)maxCaloriesFilterNumericUpDown.Value;

                // Apply filters
                if (!string.IsNullOrWhiteSpace(ingredientNameFilter))
                {
                    filteredRecipes = filteredRecipes.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientNameFilter))).ToList();
                }

                if (!string.IsNullOrWhiteSpace(foodGroupFilter))
                {
                    filteredRecipes = filteredRecipes.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroupFilter)).ToList();
                }

                filteredRecipes = filteredRecipes.Where(recipe => recipe.CalculateTotalCalories() <= maxCaloriesFilter).ToList();

                if (filteredRecipes.Count == 0)
                {
                    MessageBox.Show("No recipes found matching the selected filters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RecipeListForm recipeListForm = new RecipeListForm(filteredRecipes);
                    recipeListForm.ShowDialog();
                }
            }
        }

        private void ClearRecipeFields()
        {
            // Clear recipe fields logic
            // ...
        }
    }

    // Recipe and Ingredient classes remain the same

    public partial class RecipeListForm : Form
    {
        private List<Recipe> recipes;

        public RecipeListForm(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void RecipeListForm_Load(object sender, EventArgs e)
        {
            recipeListBox.Items.Clear();
            foreach (var recipe in recipes)
            {
                recipeListBox.Items.Add(recipe.RecipeName);
            }
        }

        private void recipeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = recipeListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < recipes.Count)
            {
                Recipe selectedRecipe = recipes[selectedIndex];
                DisplayRecipe(selectedRecipe);
            }
        }

        private void DisplayRecipe(Recipe recipe)
        {
            // Display recipe logic
            // ...
        }

        private string GetIngredientsText(List<Ingredient> ingredients)
        {
            // GetIngredientsText logic
            // ...
        }

        private string FormatIngredient(Ingredient ingredient)
        {
            // FormatIngredient logic
            // ...
        }

        private string GetStepsText(List<string> steps)
        {
            // GetStepsText logic
            // ...
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
