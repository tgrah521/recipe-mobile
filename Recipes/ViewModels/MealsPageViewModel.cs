using System.Collections.ObjectModel;
using System.Windows.Input;
using Recipes.Models;
using Recipes.Services;
using Recipes.Models;
using Recipes.Services;

namespace RecipeApp.ViewModels
{
    public class MealsPageViewModel : BaseViewModel
    {
        private readonly MealService _apiService = new MealService();
        public ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal>();

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
            }
        }

        public ICommand SearchCommand { get; }

        public MealsPageViewModel()
        {
            SearchCommand = new Command(async () => await SearchMeals());
            LoadMeals();
        }

        private async Task LoadMeals()
        {
            var meals = await _apiService.GetMealsAsync();
            Meals.Clear();
            foreach (var meal in meals)
                Meals.Add(meal);
        }

        private async Task SearchMeals()
        {
            var meals = await _apiService.SearchMealsAsync(SearchText);
            Meals.Clear();
            foreach (var meal in meals)
                Meals.Add(meal);
        }
    }
}
