using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.Text.Json.Serialization;
using Web_API.Models.Enuns;

namespace Web_API.Models
{
    public class Periferico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoPerifericosEnum TipoPeriferico { get; set; }
        public double Preco { get; set; }
        public int? ComputadorId { get; set; }

        [JsonIgnore]
        public Computador? Computador { get; set; }
    }
}