using System.Text.Json;

namespace MiniBibliotekLINQ_JASON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataJSONfilPath = "LaibaryData.json";
            string allaDataSomJSONType = File.ReadAllText(dataJSONfilPath);
            MiniDB minLillaDB = JsonSerializer.Deserialize<MiniDB>(allaDataSomJSONType)!;

            Bibliotek bibliotek = new Bibliotek(minLillaDB);
            HelpMetods helpMet = new HelpMetods(minLillaDB);

            //List<Bok> allaBöckerFrånDB = minLillaDB.AllaböckerFrånDB;
            //List<Författare> allaAutorsFrånDB = minLillaDB.AllaförfattareFrånDB;

            
            
            

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
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "2":
                        bibliotek.AddAutor();
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "3":
                        bibliotek.UpdateBookInfo();
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "4":
                        bibliotek.UpdateAutorInfo();
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "5":
                        bibliotek.RemoveBookByTitle();
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "6":
                        bibliotek.RemoveAutor();
                        helpMet.SaveData(dataJSONfilPath, minLillaDB);
                        break;
                    case "7":
                        bibliotek.PrintBookListAndAutor();
                        break;
                    case "8":
                        bibliotek.SearchAndFilter();
                        break;
                    case "9":
                        Console.WriteLine("Du sparade och stängde ner applikationen...");
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
