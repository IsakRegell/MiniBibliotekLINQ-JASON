using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniBibliotekLINQ_JASON
{
    public class MiniDB
    {
        [JsonPropertyName("Bocker")]
        public List<Bok> AllaböckerFrånDB { get; set; }



        [JsonPropertyName("AutorList")]
        public List<Författare> AllaförfattareFrånDB { get; set; }
    }
}
