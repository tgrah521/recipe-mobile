using Recipes.ViewModels;

namespace Recipes.Views
{
    public partial class AddMealPage : ContentPage
    {
        public AddMealPage()
        {
            InitializeComponent();
            BindingContext = new AddMealPageViewModel();
        }
    }
}
