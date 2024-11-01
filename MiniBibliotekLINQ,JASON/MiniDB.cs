using System.Text.Json.Serialization;
using MiniBibliotekLINQ_JASON;

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
