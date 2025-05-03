using Recipes.Models;
using Recipes.Services;

namespace Recipes.ViewModels
{
    public class MealDetailPageViewModel: ContentPage
    {
        private readonly MealService _apiService = new MealService();
        public Meal Meal { get; set; }

        public MealDetailPageViewModel(int mealId)
        {
            LoadMeal(mealId);
        }

        private async Task LoadMeal(int mealId)
        {
            Meal = await _apiService.GetMealByIdAsync(mealId);
        }
    }
}
