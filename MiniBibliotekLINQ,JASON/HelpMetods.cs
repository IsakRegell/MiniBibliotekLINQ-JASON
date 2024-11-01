using System.Text.Json;
using MiniBibliotekLINQ_JASON;
namespace MiniBibliotekLINQ_JASON
{
    public class HelpMetods
    {

        public List<Författare> AutorList;
        public List<Bok> BookList;
        public MiniDB minLillaDB;

        public HelpMetods(MiniDB minLillaDB)
        {
            this.minLillaDB = minLillaDB;
            AutorList = minLillaDB.AllaförfattareFrånDB;
            BookList = minLillaDB.AllaböckerFrånDB;
        }


        public void SaveData(string dataJSONfilPath, MiniDB minLillaDB)
        {
            string updateradeLillaDB = JsonSerializer.Serialize(minLillaDB, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(dataJSONfilPath, updateradeLillaDB);
        }


        public void PrintAutorList()
        {
            foreach (var autor in AutorList)
            {
                Console.WriteLine($"Författarens namn : *{autor.Namn}*");
            }
        }
        public void PrintBookList()
        {
            foreach (var book in BookList)
            {
                Console.WriteLine($"Title : *{book.Title}*");
            }
        }

        public void Printbookgenre()
        {
            foreach (var book in BookList)
            {
                Console.WriteLine($"Genre : *{book.Genre}*");
            }
        }
        public void PrintbookFörfattareautor()
        {
            foreach (var book in BookList)
            {
                Console.WriteLine($"Författare : *{book.Forfattare}*");
            }
            foreach (var autor in AutorList)
            {
                Console.WriteLine($"Författare : *{autor.Namn}*");
            }
        }
        public void Pausa()
        {
            Console.WriteLine("\n Tryck på en tangent för att komma till MENYN...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
