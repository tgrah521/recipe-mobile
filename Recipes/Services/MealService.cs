using System.Net.Http.Json;
using Recipes.Models;

namespace Recipes.Services
{
    public class MealService
    {
        private readonly HttpClient _client;

        public MealService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://meine-rezepte.onthewifi.com/api/")
            };
        }

        public async Task<List<Meal>> GetMealsAsync()
        {
            return await _client.GetFromJsonAsync<List<Meal>>("all_meals");
        }

        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<Meal>($"meal/{id}");
        }

        public async Task<List<Meal>> SearchMealsAsync(string mealname)
        {
            var response = await _client.PostAsJsonAsync("search_meals", new { mealname });
            return await response.Content.ReadFromJsonAsync<List<Meal>>();
        }

        public async Task AddMealAsync(NewMeal meal)
        {
            await _client.PostAsJsonAsync("add_meal", meal);
        }
    }
}
