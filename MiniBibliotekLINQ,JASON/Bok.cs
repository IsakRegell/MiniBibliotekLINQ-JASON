using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBibliotekLINQ_JASON
{

    public class Bok
    {
        public string? Title {  get; set; }
        public string? Författare {  get; set; }
        public string? Genre {  get; set; }
        public int Id {  get; set; }
        public int Isbn { get; set; }

        public List<int>? RecensionerList {  get; set; }


        public Bok(string title, string författare, string genre, int id, int isbn)
        {
            Title = title;
            Författare = författare;
            Genre = genre;
            Id = id;
            Isbn = isbn;
            RecensionerList = new List<int>();
        }
    }

   
    
}
