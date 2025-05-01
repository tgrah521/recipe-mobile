namespace Recipes
{
    public partial class App 
    {
        public App()
        {
            InitializeComponent();

            App.Current.MainPage = new AppShell();
        }
    }
}
