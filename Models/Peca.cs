using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models.Enuns;
using System.Text.Json.Serialization;

namespace Web_API.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? Geracao { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public TipoPecaEnum TipoPeca { get; set; }
        public double Preco { get; set; }
        public int? ComputadorId { get; set; }

        [JsonIgnore]
        public Computador? Computador { get; set; }
    }
}