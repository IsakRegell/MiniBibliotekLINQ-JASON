using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace MiniBibliotekLINQ_JASON
{
    public class Bibliotek
    {

        //List<Författare> AutorList = new List<Författare>();
        //List<Bok> BookList = new List<Bok>();
        public List<Författare> AutorList;
        public List<Bok> BookList;

        public Bibliotek(MiniDB minLillaDB)
        {
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
            Pausa();
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
            Pausa();
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
            Pausa();
        }

        public void UpdateBookInfo()
        {
            Console.Clear();
            PrintBookList();
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
                Pausa();
            }
            else
            {
                Console.WriteLine($"Ingen bok med titlen *{updBook}* hittades");
            }

        }

        public void UpdateAutorInfo()
        {
            Console.Clear();
            PrintAutorList();
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
                Pausa();
            }
            else
            {
                Console.WriteLine($"Ingen författare med namnet *{updateAutor}* hittades");
            }

        }

        public void RemoveAutor()
        {
            Console.Clear();
            PrintAutorList();
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
            Pausa();
        }

        public void RemoveBookByTitle()
        {
            Console.Clear();
            PrintBookList();
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
            Pausa();

        }

        public void SearchAndFilter()
        {

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
            Console.WriteLine("----Dessa böcker kan du uppdatera----");
            foreach (var book in BookList)
            {
                Console.WriteLine($"\nTitle : *{book.Title}*");
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


