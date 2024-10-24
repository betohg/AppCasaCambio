using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using AppCasaCambio.Models;

namespace AppCasaCambio.Data
{
    public class DBConexion
    {
        private readonly SQLiteAsyncConnection _database;

        // Constructor de la clase DBConexion
        public DBConexion()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "casaCambio.db");
            _database = new SQLiteAsyncConnection(databasePath);

        }

        public async Task InitAsync()
        {
            try
            {
                await _database.CreateTableAsync<Moneda>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la tabla: {ex.Message}");
            }
        }



        // Método para guardar una moneda en la base de datos
        public Task<int> SaveMonedaAsync(Moneda moneda)
        {
            return _database.InsertAsync(moneda);
        }

        // Método para obtener todas las monedas
        public Task<List<Moneda>> GetMonedasAsync()
        {
            return _database.Table<Moneda>().ToListAsync();
        }
    }
}
