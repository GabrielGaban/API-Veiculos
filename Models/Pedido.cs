using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veiculosAPI.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
    }
}
