using AppCasaCambio.Data;
using AppCasaCambio.Models;
using System;
using System.Collections.Generic;

namespace AppCasaCambio.Views
{
    public partial class RegisterCoin : ContentPage
    {
        private readonly DBConexion _database;

        public RegisterCoin()
        {
            InitializeComponent();

            // Inicializa la conexión a la base de datos
            _database = new DBConexion();
            InitDatabase();
        }

        private async void InitDatabase()
        {
            await _database.InitAsync();
        }


        // Método que maneja el evento de clic en el botón Registrar Moneda
        private async void OnRegistrarMonedaClicked(object sender, EventArgs e)
        {
            // Verifica que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreMonedaEntry.Text) || string.IsNullOrEmpty(ventaMonedaEntry.Text) || string.IsNullOrEmpty(compraMonedaEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            try
            {
                // Convierte los valores ingresados para Venta y Compra a decimal
                var venta = decimal.Parse(ventaMonedaEntry.Text);
                var compra = decimal.Parse(compraMonedaEntry.Text);

                // Crea una nueva instancia de Moneda
                var nuevaMoneda = new Moneda
                {
                    Nombre = nombreMonedaEntry.Text,
                    ValorVenta = venta,
                    ValorCompra = compra
                };

                // Guarda la moneda en la base de datos
                await _database.SaveMonedaAsync(nuevaMoneda);

                // Muestra un mensaje de éxito
                await DisplayAlert("Éxito", "Moneda registrada exitosamente", "OK");

                // Limpia los campos de entrada
                nombreMonedaEntry.Text = string.Empty;
                ventaMonedaEntry.Text = string.Empty;
                compraMonedaEntry.Text = string.Empty;
            }
            catch (FormatException)
            {
                await DisplayAlert("Error", "Por favor, ingrese valores numéricos válidos para Venta y Compra", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
