using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using System.Text.Json.Serialization;

namespace Web_API.Models
{
    public class Computador
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int? UsuarioId { get; set; }


        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        public List<Periferico> Perifericos { get; set; } = [];
        public List<Peca> Pecas { get; set; } = [];
    }
}