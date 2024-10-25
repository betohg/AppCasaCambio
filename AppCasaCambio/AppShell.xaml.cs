using AppCasaCambio.Data;
using System.Text.Json;

namespace AppCasaCambio
{
    public partial class AppShell : Shell
    {
        private AppConfig appConfig;
        public AppShell()
        {
            InitializeComponent();
            LoadConfiguration();
            DisplayConfiguration();
        }

        private void LoadConfiguration()
        {
            var filePath = "C:\\Users\\beto_\\Source\\Repos\\AppCasaCambio\\AppCasaCambio\\Data\\config.json";
            string jsonString = File.ReadAllText(filePath);
            appConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);
        }

        private void DisplayConfiguration()
        {
            // Asigna los valores a los inputs
            hometitle.Title = appConfig.Navbar.Home;
            operationstitle.Title = appConfig.Navbar.Operations;
            registertitle.Title = appConfig.Navbar.Register;
            configurationtitle.Title = appConfig.Navbar.Configuration;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadConfiguration();
            DisplayConfiguration();
        }
    }
}
