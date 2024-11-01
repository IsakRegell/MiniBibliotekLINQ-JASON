using System.Text.Json;
using MiniBibliotekLINQ_JASON;

namespace MiniBibliotekLINQ_JASON
{
    public class Bibliotek
    {

        private MiniDB minLillaDB;
        private HelpMetods hjälpMetoder;

        public List<Författare> AutorList { get; private set; }
        public List<Bok> BookList { get; private set; }

        // Konstruktorn tar emot en existerande instans av MiniDB och skapar en HelpMetods-instans
        public Bibliotek(MiniDB minLillaDB)
        {
            this.minLillaDB = minLillaDB;
            hjälpMetoder = new HelpMetods(minLillaDB); 
            AutorList = minLillaDB.AllaförfattareFrånDB;
            BookList = minLillaDB.AllaböckerFrånDB;
        }




        public void PrintBookListAndAutor()
        {
            Console.Clear();
            Console.WriteLine("----Alla böcker i LISTAN----");
            foreach (var book in BookList)
            {
                string RecensionerList = string.Join("/5* ", book.RecensionerList!);
                Console.WriteLine($"\nTitle : *{book.Title}* Författare : *{book.Forfattare}* Genre : *{book.Genre}* Bokens ID : *{book.Id}* \n Bookens ISBN *{book.Isbn}* Bokens resentioner *{RecensionerList}/5*");
            }
            Console.WriteLine("\n---Detta är alla författare i våran LISTA---");
            foreach (var autor in AutorList)
            {
                Console.WriteLine($"Författarens namn : *{autor.Namn}* Författarens hemland : *{autor.Land}* Författarens ID : *{autor.Id}*");
            }
            hjälpMetoder.Pausa();
        }

        public void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Kul att du vill lägga till en bok! Svara på följande frågor för att lyckas!");
            Console.WriteLine("\n Vad är Titlen på boken? : ");
            string nyTitle = Console.ReadLine()!;
            Console.WriteLine("Vad heter författaren som skrev boken? : ");
            string nyFörfattare = Console.ReadLine()!;
            Console.WriteLine("Vilket land kommer författaren ifrån? : ");
            string nyLand = Console.ReadLine()!;
            Console.WriteLine("Vad är författarens ID? : ");
            int newFörfattareId = Convert.ToInt32(Console.ReadLine()!);
            Console.WriteLine("Vilken genre klassas boken som? : ");
            string nyGenre = Console.ReadLine()!;
            Console.WriteLine("Vad har boken för id? : ");
            int nyId = Convert.ToInt32(Console.ReadLine()!);
            Console.WriteLine("Vad är bokens ISBN? : ");
            int nyIsbn = Convert.ToInt32(Console.ReadLine()!);

            Bok newBook = new Bok(nyTitle, nyFörfattare, nyGenre, nyId, nyIsbn);
            Författare newFörfattare = new Författare(nyFörfattare, nyLand, newFörfattareId);
            BookList.Add(newBook);
            AutorList.Add(newFörfattare);

            Console.WriteLine($"Boken med titlen *{nyTitle}* blev tillagd");
            hjälpMetoder.Pausa();
        }

        public void AddAutor()
        {
            Console.Clear();
            Console.WriteLine("Dags att lägga till en författare!");
            Console.WriteLine("\nVad heter författaren du vill lägga till? : ");
            string addAutor = Console.ReadLine()!;
            Console.WriteLine("Vilket land kommer hen ifrån? : ");
            string addLand = Console.ReadLine()!;
            Console.WriteLine("Vad är författarens ID? : ");
            int addId = Convert.ToInt32(Console.ReadLine()!);

            Författare LäggTillförfattare = new Författare(addAutor, addLand, addId);
            AutorList.Add(LäggTillförfattare);
            Console.WriteLine($"Författaren med namnet *{addAutor}* lades till i författarlistan");
            hjälpMetoder.Pausa();
        }

        public void UpdateBookInfo()
        {
            Console.Clear();
            Console.WriteLine("----Dessa böcker kan du uppdatera----");
            hjälpMetoder.PrintBookList();
            Console.WriteLine("\nSkriv titlen på boken du vill uppdatera? : ");
            string updBook = Console.ReadLine()!;

            bool bookFound = false;
            int bookIndex = -1;

            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].Title!.Equals(updBook, StringComparison.OrdinalIgnoreCase))
                {
                    bookFound = true;
                    bookIndex = i;
                    break;
                }
            }
            if (bookFound)
            {
                Bok bookToUpdate = BookList[bookIndex];

                Console.WriteLine($"\nDu uppdaterar boken med titlen *{bookToUpdate.Title}*");

                Console.WriteLine("Ange ny title på boken (lämna tomt för att behålla nuvarande titel) : ");
                string updTitle = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(updTitle)) bookToUpdate.Title = updTitle;

                Console.WriteLine("Ange ny författare (lämna tomt för att behålla nuvarande författare) : ");
                string updAutor = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(updAutor)) bookToUpdate.Forfattare = updAutor;

                Console.WriteLine("Ange ny genre (lämna tomt för att behålla nuvarande genre) : ");
                string updGenre = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(updGenre)) bookToUpdate.Genre = updGenre;

                Console.WriteLine("Ange nytt ID (lämna tomt för att behålla nuvarande ID) : ");
                string updId = Console.ReadLine()!;
                if (int.TryParse(updId, out int newId)) bookToUpdate.Id = newId;

                Console.WriteLine("Ange nytt ISBN (lämna tomt för att behålla nuvarande ISBN) : ");
                string updIsbn = Console.ReadLine()!;
                if (int.TryParse(updIsbn, out int newIsbn)) bookToUpdate.Isbn = newIsbn;


                Console.WriteLine($"Boken *{bookToUpdate.Title}* har uppdaterats!");
                hjälpMetoder.Pausa();
            }
            else
            {
                Console.WriteLine($"Ingen bok med titlen *{updBook}* hittades");
            }

        }

        public void UpdateAutorInfo()
        {
            Console.Clear();
            hjälpMetoder.PrintAutorList();
            Console.WriteLine("\nSkriv Namnet på författaren du vill uppdatera? : ");
            string updateAutor = Console.ReadLine()!;

            bool AutorFound = false;
            int autorIndex = -1;

            for (int i = 0; i < AutorList.Count; i++)
            {
                if (AutorList[i].Namn!.Equals(updateAutor, StringComparison.OrdinalIgnoreCase))
                {
                    AutorFound = true;
                    autorIndex = i;
                    break;
                }
            }
            if (AutorFound)
            {
                Författare autorToUpdate = AutorList[autorIndex];

                Console.WriteLine($"\nDu uppdaterar författarens info med namnet *{autorToUpdate.Namn}*");

                Console.WriteLine("Ange det nya namnet på författaren (lämna tomt för att behålla nuvarande namnet) : ");
                string autorNewName = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(autorNewName))
                {
                    string oldName = autorToUpdate.Namn!;
                    autorToUpdate.Namn = autorNewName;

                    BookList.Where(book => book.Forfattare!.Equals(oldName, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(book => book.Forfattare = autorNewName);
                }

                Console.WriteLine("Ange det nya landet författaren är ifrån (lämna tomt för att behålla nuvarande land) : ");
                string autorNewContry = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(autorNewName)) autorToUpdate.Land = updateAutor;

                Console.WriteLine("Ange författarens nya ID (lämna tomt för att behålla nuvarande ID) : ");
                string autorNewId = Console.ReadLine()!;
                if (int.TryParse(autorNewId, out int allNewId)) autorToUpdate.Id = allNewId;
                hjälpMetoder.Pausa();
            }
            else
            {
                Console.WriteLine($"Ingen författare med namnet *{updateAutor}* hittades");
            }

        }

        public void RemoveAutor()
        {
            Console.Clear();
            hjälpMetoder.PrintAutorList();
            Console.WriteLine("\nSkriv namnet på författaren du vill ta bort: ");
            string autorToRemoveName = Console.ReadLine()!;

            var autorToRemove = AutorList.FirstOrDefault(a => a.Namn!.Equals(autorToRemoveName, StringComparison.OrdinalIgnoreCase));

            if (autorToRemove == null)
            {
                Console.WriteLine("Författarem hittades inte i listan");
                return;
            }
            if (BookList.Any(book => book.Forfattare!.Equals(autorToRemove!.Namn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Författaren *{autorToRemove!.Namn}* har böcker kopplade till sig.");
                Console.WriteLine("Vill du ta bort författaren trots att den har böcker kopplade till sig? (j/n)");

                if (!Console.ReadLine()!.Equals("j", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Författaren har inte tagits bort.");
                    return;
                }
            }
            AutorList.Remove(autorToRemove!);
            Console.WriteLine($"\nFörfattaren *{autorToRemove!.Namn}* har tagits bort!");
            hjälpMetoder.Pausa();
        }

        public void RemoveBookByTitle()
        {
            Console.Clear();
            hjälpMetoder.PrintBookList();
            Console.WriteLine("\nSkriv titlen på boken du vill ta bort: ");
            string bookToRemoveTitle = Console.ReadLine()!;

            var bookToRemove = BookList.FirstOrDefault(b => b.Title!.Equals(bookToRemoveTitle, StringComparison.OrdinalIgnoreCase));

            if (bookToRemove == null)
            {
                Console.WriteLine("Titlen hittades inte i listan");
                return;
            }
            BookList.Remove(bookToRemove);
            Console.WriteLine($"\nBoken *{bookToRemoveTitle}* har tagits bort");
            hjälpMetoder.Pausa();

        }

        public void SearchAndFilter()
        {
            Console.Clear();
            Console.WriteLine("---Filtrerad sökning---");
            Console.WriteLine("1. För sökning via genre");
            Console.WriteLine("2. För sökning med författare");
            string minimenyval = Console.ReadLine()!;

            if (minimenyval == "1")
            {
                Console.Clear();
                Console.WriteLine("GENRE som finns inne");
                Console.WriteLine(" ");
                var genres = BookList.Select(b => b.Genre).Distinct();
                foreach (var genre in genres)
                {
                    Console.WriteLine(genre);
                }
                Console.WriteLine("\n\nVilken genre vill du ha mer info om?");
                string genremenyval = Console.ReadLine()!;

                var booksInGenre = BookList.Where(b => b.Genre!.Equals(genremenyval, StringComparison.OrdinalIgnoreCase));


                if (booksInGenre.Any())
                {
                    Console.WriteLine($"Böcker i genren {genremenyval}:");
                    foreach (var book in booksInGenre)
                    {
                        Console.WriteLine($"Boken : *{book.Title}* matcha din sökning");
                    }
                }
                else
                {
                    Console.WriteLine("Inga böcker finns i den genren.");
                }
            }
            if (minimenyval == "2")
            {
                Console.Clear();
                Console.WriteLine("Författare som finns inne\n");

                var författareFrånBöcker = BookList.Select(b => b.Forfattare).Distinct();
                var författareFrånAutorList = AutorList.Select(b => b.Namn).Distinct();

                // Kombinerar de två listorna och tar bort dubbletter
                var allaFörfattare = författareFrånBöcker.Concat(författareFrånAutorList).Distinct();

                // Skriver ut alla författare
                foreach (var författare in allaFörfattare)
                {
                    Console.WriteLine(författare);
                }

                Console.WriteLine("\n\nVilken Författare vill du ha mer info om?");
                string författaremenyval = Console.ReadLine()!;

                // Hämta alla böcker av den valda författaren
                var böckerAvFörfattare = BookList.Where(b => b.Forfattare!.Equals(författaremenyval, StringComparison.OrdinalIgnoreCase));

                // Kontrollera om det finns några böcker för författaren
                if (böckerAvFörfattare.Any())
                {
                    Console.WriteLine($"\nBöcker av {författaremenyval}:");
                    foreach (var bok in böckerAvFörfattare)
                    {
                        Console.WriteLine($"{bok.Title} - Genre: {bok.Genre}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga böcker hittades för den författaren.");
                }
            }
            hjälpMetoder.Pausa();
        }


    }
}


