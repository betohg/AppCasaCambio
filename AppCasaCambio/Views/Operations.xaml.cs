using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCasaCambio.Data;
using AppCasaCambio.Models;
using Microsoft.Maui.Controls;

namespace AppCasaCambio.Views
{
    public partial class Operations : ContentPage
    {
        private readonly DBConexion _database;

        public Operations()
        {
            InitializeComponent();
            _database = new DBConexion();

            // Cargar las monedas desde la base de datos
            LoadMonedasAsync();
        }

        // Método para cargar las monedas en los pickers
        private async Task LoadMonedasAsync()
        {
            try
            {
                var monedas = await _database.GetMonedasAsync();

                // Asignar las monedas a los pickers
                monedaOrigenPicker.ItemsSource = monedas;
                monedaDestinoPicker.ItemsSource = monedas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las monedas: {ex.Message}");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMonedasAsync();
        }

        // Evento para el botón de Compra
        private void OnCompraClicked(object sender, EventArgs e)
        {
            if (double.TryParse(cantidadEntry.Text, out double cantidad) &&
                monedaOrigenPicker.SelectedItem is Moneda monedaOrigen &&
                monedaDestinoPicker.SelectedItem is Moneda monedaDestino) // Asegúrate de que monedaDestino esté seleccionada
            {
                // Calcular el resultado de la compra
                double resultadoCompra = Math.Round(cantidad * (double)monedaOrigen.ValorCompra / (double)monedaDestino.ValorVenta, 2);

                // Mostrar el resultado
                resultadoCompraLabel.Text = $"${resultadoCompra}";
            }
            else
            {
                DisplayAlert("Error", "Por favor ingresa una cantidad válida y selecciona una moneda de origen.", "OK");
            }
        }

        // Evento para el botón de Venta
        private void OnVentaClicked(object sender, EventArgs e)
        {
            if (double.TryParse(cantidadEntry.Text, out double cantidad) &&
                monedaDestinoPicker.SelectedItem is Moneda monedaDestino &&
                monedaOrigenPicker.SelectedItem is Moneda monedaOrigen)
            {
                // Calcular el resultado de la venta
                double resultadoVenta = Math.Round(cantidad * (double)monedaOrigen.ValorVenta / (double)monedaDestino.ValorCompra, 2);

                // Mostrar el resultado
                resultadoVentaLabel.Text = $"${resultadoVenta}";
            }
            else
            {
                DisplayAlert("Error", "Por favor ingresa una cantidad válida y selecciona una moneda de destino.", "OK");
            }
        }
    }
}
