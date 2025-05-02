using Recipes.Models;
using Recipes.Services;
using System.Windows.Input;

namespace Recipes.ViewModels
{
    public class AddMealPageViewModel 
    {
        private readonly MealService _apiService = new MealService();

        public string MealName { get; set; }
        public string Note { get; set; }
        public int Stars { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public ICommand AddIngredientCommand { get; }
        public ICommand AddMealCommand { get; }

        public AddMealPageViewModel()
        {
            AddIngredientCommand = new Command(AddIngredient);
            AddMealCommand = new Command(AddMeal);
        }

        private void AddIngredient()
        {
            Ingredients.Add(new Ingredient());
        }

        private async void AddMeal()
        {
            var newMeal = new NewMeal
            {
                MealName = MealName,
                Note = Note,
                Stars = Stars,
                Ingredients = Ingredients
            };

            await _apiService.AddMealAsync(newMeal);
        }
    }
}
