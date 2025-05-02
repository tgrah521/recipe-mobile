using Recipes.ViewModels;

namespace Recipes.Views
{
    public partial class AddMealPage 
    {
        public AddMealPage()
        {
            InitializeComponent();
            BindingContext = new AddMealPageViewModel();
        }
    }
}
