﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veiculosAPI.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
    }
}
