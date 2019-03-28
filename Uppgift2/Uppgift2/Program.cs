using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarera variablar.
            bool isRunning = true;
            string ryggSäck = "\t";
            int menyVal;

            // Programet kommer att köras tills bool isRunning blir att satt till false i menyval 4.
            while (isRunning)
            {
                // Skriv ut menyvalen
                Console.WriteLine("\n\tVälkommen till ryggsäcken!");
                Console.WriteLine("\t[1] Lägg till ett föremål.");
                Console.WriteLine("\t[2] Skriv ut innehåll.");
                Console.WriteLine("\t[3] Rensa innehåll.");
                Console.WriteLine("\t[4] Avsluta.");
                Console.Write("\tVälj: ");

                // Acceptera enbart numeriska värden i variablen menyVal
                while (!int.TryParse(Console.ReadLine(), out menyVal))
                {
                    Console.WriteLine("Gör ett val mellan 1 - 4!");
                }

                // Switch case använder jag för att köra respektive kodblock de olika valen användaren gör.
                switch (menyVal)
                {
                    case 1:
                        // Val 1 fångar anvädanrens inmatning i strängen sak. Därefter adderar jag sak till ryggSäck strängen med +=. 
                        Console.Write("\n\tAnge vad du vill lägga i väskan: ");
                        string sak = Console.ReadLine();
                        ryggSäck += sak + "\n\t";
                        break;
                    case 2:
                        // Val 2 skriver ut innehållet i ryggSäck strängen.
                        Console.WriteLine("\n\tInnehållet i väskan: ");
                        Console.WriteLine(ryggSäck);
                        break;
                    case 3:
                        // Val 3 Rensar ryggSäck strängen och lägger till en tabb för snyggare presentation av innehållet.
                        Console.WriteLine("\n\tVäskan är tömd!");
                        ryggSäck = "\t";
                        break;
                    case 4:
                        // Val 4 sätter isRunning boolien till false vilket gör att programmet hoppar ur while loopen och avslutas.
                        isRunning = false;
                        break;
                    default:
                        // Default case som presenteras om menyVal är 1 - 4. 
                        Console.WriteLine("Gör ett val mellan 1 - 4!");
                        break;
                }
            }
        }
    }
}
