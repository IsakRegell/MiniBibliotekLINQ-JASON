namespace MiniBibliotekLINQ_JASON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotek bibliotek = new Bibliotek();
            List<Författare> AutorList = new List<Författare>();
            List<Bok> BookList = new List<Bok>();
            bool programIsRuning = true;

            while (programIsRuning)
            {
                Console.WriteLine("----MiniBibliotekApp----");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till ny författare");
                Console.WriteLine("3. Uppdatera bokinfo");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Lista alla böcker och författare");
                Console.WriteLine("8. Sök och filtrera böcker");
                Console.WriteLine("9. Avsluta och spara data");
                string FirstMenuOption = Console.ReadLine()!;


                switch (FirstMenuOption)
                {
                    case "1":
                        bibliotek.AddBook();
                        break;
                    case "2":
                        bibliotek.AddAutor();
                        break;
                    case "3":
                        bibliotek.UpdateBookInfo();
                        break;
                    case "4":
                        bibliotek.UpdateAutorInfo();
                        break;
                    case "5":
                        bibliotek.RemoveBook();//Finns inte än
                        break;
                    case "6":
                        bibliotek.RemoveAutor();
                        break;
                    case "7":
                        bibliotek.PrintBookListAndAutor();
                        break;
                    case "8":
                        bibliotek.SearchAndFilter();//Finns inte än
                        break;
                    case "9":
                        programIsRuning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val. Försök igen");
                        break;
                }
            }
            
        }
    }
}
