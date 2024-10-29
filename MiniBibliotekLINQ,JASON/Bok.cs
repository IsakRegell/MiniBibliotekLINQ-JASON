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
        public string? Forfattare {  get; set; }
        public string? Genre {  get; set; }
        public int Id {  get; set; }
        public int Isbn { get; set; }

        public List<int>? RecensionerList {  get; set; }


        public Bok(string title, string forfattare, string genre, int id, int isbn)
        {
            Title = title;
            Forfattare = forfattare;
            Genre = genre;
            Id = id;
            Isbn = isbn;
            RecensionerList = new List<int>();
        }
    }


    //public Bibliotek()
    //{
    //    //Bok book1 = new Bok("Isaks äventyr", "Ove LPP", "Action", 123, 111);
    //    //BookList.Add(book1);
    //    //book1.RecensionerList!.Add(3);
    //    //Författare författare1 = new Författare("Ove LPP", "Sverige", 1);
    //    //AutorList.Add(författare1);

    //    //Bok book2 = new Bok("Amandas äventyr", "Anette RSS", "Drama", 321, 222);
    //    //BookList.Add(book2);
    //    //book2.RecensionerList!.Add(4);
    //    //Författare författare2 = new Författare("Anette RSS", "Tyskland", 2);
    //    //AutorList.Add(författare2);
    //}

}
