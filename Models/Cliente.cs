﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veiculosAPI.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
