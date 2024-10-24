using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppCasaCambio.Models
{
    public class Moneda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public decimal ValorCompra { get; set; }

        public decimal ValorVenta { get; set; }
    }
}
