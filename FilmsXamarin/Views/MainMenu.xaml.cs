using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FilmsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : TabbedPage
    {
        public MainMenu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage navigationPage = new NavigationPage(new FilmsPage());
            Children.Add(new FilmsPage() { Title = "Films", IconImageSource = "BarFilmIcon.png" });
        }
    }
}
