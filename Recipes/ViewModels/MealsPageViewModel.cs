using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Recipes.Models;
using Recipes.Services;

namespace Recipes.ViewModels
{
    public partial class MealsPageViewModel : ObservableObject
    {
        private readonly MealService _apiService = new MealService();

        public ObservableCollection<Meal> Meals { get; set; } = new();

        [ObservableProperty]
        private string searchText;

        // Der Befehl wird nun mit RelayCommand erstellt
        public ICommand SearchCommand { get; }

        public MealsPageViewModel()
        {
            // Der Command wird mit einer Lambda-Funktion erstellt
            SearchCommand = new RelayCommand(async () => await SearchMeals());
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
