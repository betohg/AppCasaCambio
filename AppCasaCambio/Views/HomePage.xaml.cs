using System.Text.Json;
using AppCasaCambio.Data;

namespace AppCasaCambio.Views;

public partial class HomePage : ContentPage
{
    private AppConfig appConfig;
    public HomePage()
    {
        InitializeComponent();
        LoadConfiguration();
        DisplayWelcomeMessage();
    }

    private void LoadConfiguration()
    {
        var filePath = "C:\\Users\\beto_\\source\\repos\\AppCasaCambio\\AppCasaCambio\\Data\\config.json";
        string jsonString = File.ReadAllText(filePath);
        appConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);
    }

    private void DisplayWelcomeMessage()
    {
        if (appConfig != null)
        {
            Title = appConfig.AppTitle; // Configura el título de la página
            ((Label)Content.FindByName("welcomeLabel")).Text = appConfig.WelcomeMessage; // Configura el mensaje de bienvenida
            ((Label)Content.FindByName("welcomeTitle")).Text = appConfig.WelcomeTitle;
        }
    }
}