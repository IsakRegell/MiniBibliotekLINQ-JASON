using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniBibliotekLINQ_JASON
{
    public class Författare
    {

        public string? Namn {  get; set; }
        public string? Land {  get; set; }
        public int Id {  get; set; }


        public List<string>? skrivnaBöcker {  get; set; }

        public Författare(string namn, string land, int id)
        {
            Namn = namn;
            Land = land;
            Id = id;
            skrivnaBöcker = new List<string>();
        }
    }
}
