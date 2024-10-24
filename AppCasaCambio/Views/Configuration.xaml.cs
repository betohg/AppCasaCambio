using AppCasaCambio.Data;
using System.Text.Json;


namespace AppCasaCambio.Views;

public partial class Configuration : ContentPage
{
    private AppConfig appConfig;

    public Configuration()
    {
        InitializeComponent();
        LoadConfiguration();
        DisplayConfiguration();
    }

    private void LoadConfiguration()
    {
        var filePath = "C:\\Users\\beto_\\source\\repos\\AppCasaCambio\\AppCasaCambio\\Data\\config.json";
        string jsonString = File.ReadAllText(filePath);
        appConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);
    }

    private void DisplayConfiguration()
    {
        // Asigna los valores a los inputs
        appTitleEntry.Text = appConfig.AppTitle;
        welcomeMessageEntry.Text = appConfig.WelcomeMessage;
        welcomeTitleEntry.Text = appConfig.WelcomeTitle;
        userNameEntry.Text = appConfig.User.Name;
        welcomeLabel.Text = appConfig.WelcomeMessage; // Muestra el mensaje de bienvenida
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Actualiza los valores del objeto de configuración con los valores de los inputs
        appConfig.AppTitle = appTitleEntry.Text;
        appConfig.WelcomeMessage = welcomeMessageEntry.Text;
        appConfig.WelcomeTitle = welcomeTitleEntry.Text;
        appConfig.User.Name = userNameEntry.Text;

        // Guarda la configuración en el archivo JSON
        SaveConfiguration();
        DisplayAlert("Éxito", "Configuración guardada exitosamente.", "OK");
    }

    private void SaveConfiguration()
    {
        var filePath = "C:\\Users\\beto_\\source\\repos\\AppCasaCambio\\AppCasaCambio\\Data\\config.json";
        string jsonString = JsonSerializer.Serialize(appConfig);
        File.WriteAllText(filePath, jsonString);
    }
}