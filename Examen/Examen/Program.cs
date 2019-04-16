using System;
using System.Collections.Generic;

/* 
 * Skapare: Martin Olsson | malvack (a) gmail . com
 * Kurs: Programmering 1
 * Uppgift: Loggboken
 * Datum: 2019-04-11 
 * 
 */
 
namespace Examen
{
    
    class Program
    {
        // Initiera variabler
        static List<string[]> loggBok = new List<string[]>(); // Håller alla logg vektor.
        static bool kör = true; // Hanterar om programmet ska avslutat eller ej.
        static int val; // Hanterar användarens menyval.

        static void Main(string[] args)
        {
            while (kör) // Programmet körs tills kör är false. 
            {
                VisaMeny(); // Anropa metoden för visning av meny.

                switch (val)
                {
                    case 1:
                        SkrivUtLoggbok(); // Anropa metoden för utskrift av hela loggboken.
                        break;
                    case 2:
                        SkapaLogg(); // Anropa metoden för att skapa inlägg i loggboken.
                        break;
                    case 3:
                        SökTitel(); // Anropa metod för att söka inlägg med en titel.
                        break;
                    case 4:
                        TaBortLogg(); // Anropa metod för att ta bort en logg.
                        break;
                    case 5:
                        Avsluta(); // Anropa metoden för att avsluta programmet.
                        break;
                    default:
                        FelVal(); // Anropa metoden för fel inmatning.
                        break;
                }
            }
        }

        // METOD: VisaMeny
        static void VisaMeny()
        {
            Console.WriteLine("----------------------- LOGGBOKEN ----------------------");
            Console.WriteLine("\n\t[1] Skriv ut alla loggar\n\t[2] Skriv nytt inlägg i loggboken\n\t[3] Sök inlägg i loggboken\n\t[4] Tabort logg\n\t[5] Avsluta programmet");
            Console.Write("\tVälj: ");
            Int32.TryParse(Console.ReadLine(), out val); // Kontrollera att användaren angett rätt val.
        }

        // METOD:  Val 1 SkrivUtLoggBoken.
        static void SkrivUtLoggbok()
        {
            foreach (string[] element in loggBok) // Loopa igenom loggbokens element och skriv ut resultatet.
            {
                Console.WriteLine("\n\tLogg#[{0}] ", loggBok.IndexOf(element)); // Skriver ut indexet på var elementet befinner sig i loggBok.
                Console.WriteLine("\tDatum: {0}", element[0]);
                Console.WriteLine("\tTitel: {0}", element[1]);
                Console.WriteLine("\tText:  {0}", element[2] + "\n");
            }

        }

        // METOD:  Val 2 SkapaLogg.
        static void SkapaLogg()
        {
            Console.Write("\n\tAnge en titel på loggen: ");
            string titel = Console.ReadLine();
            Console.Write("\tAnge en text: ");
            string text = Console.ReadLine();

            string[] arr = new string[3] { DateTime.Now.ToString("yyyy/MM/dd"), titel, text }; // Skapar en vektor 
            loggBok.Add(arr); // Lägger till vektorn i loggBok listan.


        }

        // METOD: Val 3 SökTitel.
        static void SökTitel()
        {
            bool träff = false; // Hanterar om användaren får träff på sökord.
            // Console.Write("\n\tAnge ett datum (yyyy/MM/dd) eller sökord du letar efter: "); // Sök med jämförelseoperator.
            Console.Write("\n\tAnge ett år, månad, datum eller sökord du letar efter: "); // Sök med Contain klassen.
            string sökord = Console.ReadLine();

            foreach (string[] element in loggBok) // Loopa igenom listan loggBok element.
            {
                foreach (string cell in element) //Loopa igenom varje inlägg cell
                {
                    /*  Alternativ med jämförelseoperator:
                        if (cell == sökord) 
                        { 
                            Console.WriteLine("\n\tDatum: {0}", element[0]);
                            Console.WriteLine("\tTitel:   {0}", element[1]);
                            Console.WriteLine("\tText:    {0}", element[2] + "\n");
                            träff = true;
                       }

                     */

                    if (cell.Contains(sökord)) // Använder Cointains klassen för att hitta sökordet.
                    {
                        Console.WriteLine("\n\tDatum: {0}", element[0]);
                        Console.WriteLine("\tTitel:   {0}", element[1]);
                        Console.WriteLine("\tText:    {0}", element[2] + "\n");
                        träff = true;
                    }
                }
            }

            if (!träff) Console.WriteLine("\tDet verkar inte som att något inlägg innehåller: " + sökord); // Meddela avändaren om ingent träff har hittats.
        }

        // METOD: Val 4 TabortLogg
        static void TaBortLogg()
        {
            
            foreach (string[] element in loggBok) // Loopa igenom loggbokens element och skriv ut resultatet.
            {
                Console.WriteLine("\n\tLogg#[{0}]", loggBok.IndexOf(element)); // Skriver ut indexet på var elementet befinner sig i loggBok.
                Console.WriteLine("\tTitel:   {0}", element[1]);
            }
            Console.Write("\n\tAnge Logg# du vill ta bort: ");

            bool ok = Int32.TryParse(Console.ReadLine(), out int loggID); // Kontrollera att användaren angett rätt val.

            if (ok) { 
                try { loggBok.RemoveAt(loggID); } // Här försöker vi ta bort det Index som användaren matat in.
                catch { Console.WriteLine("\n\tIndex finns inte med i listan!"); } // Om användaren matar in fel Index. Presentera det för användaren.
            }

            if (!ok) { Console.WriteLine("\n\tDu har angett ett felaktigt värde!"); } // Om användaren matar in något felaktigt värde så presentera det föra användaren.

        }

        // METOD: Val 5 Avsluta.
        static void Avsluta()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Det är kul med lite färg!
            Console.WriteLine("\n\tTack för att du använda loggboken!\n\tTryck [enter] för att avsluta!"); // Tacka användaren!
            Console.ReadLine(); // Ge användaren tid att läsa avtackningen.
            kör = false; // Boolen kör sätts till false vilket resultetat is att switch loopen i main metoden bryts.
        }

        // METOD: Val Default FelVal.
        static void FelVal()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Det är kul med lite färg!
            Console.WriteLine("\n\tFelaktig inmatning. Välj [1]-[5] från menyn.");
            Console.ForegroundColor = ConsoleColor.Gray; // Det är kul med lite färg!
        }

    }
}
