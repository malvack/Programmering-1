using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarera variablar.
            bool isRunning = true;
            string[] ryggSäck = new string[5];
            int menyVal;

            // Programet kommer att köras tills bool isRunning blir att satt till false i menyval 4.
            while (isRunning)
            {
                // Skriv ut menyvalen
                Console.WriteLine("\n\tVälkommen till ryggsäcken!");
                Console.WriteLine("\t[1] Lägg till ett föremål.");
                Console.WriteLine("\t[2] Skriv ut innehåll.");
                Console.WriteLine("\t[3] Sök i väskan.");
                Console.WriteLine("\t[4] Avsluta.");
                Console.Write("\tVälj: ");

                // Acceptera enbart numeriska värden i variablen menyVal
                while (!int.TryParse(Console.ReadLine(), out menyVal))
                {
                    Console.Write("\n\tGör ett val mellan 1 - 4: ");
                }

                // Switch case använder jag för att köra respektive kodblock de olika valen användaren gör.
                switch (menyVal)
                {
                    case 1:
                        // Val 1 fångar användarens inmatning i strängen sak. Lägg sedan till inmatningen i ryggSäck[i]. 

                        for (int i = 0; i < ryggSäck.Length; i++)
                        {
                            Console.Write("\tLägg något i väskan: ");
                            string sak = Console.ReadLine();
                            ryggSäck[i] = sak;
                        }
                        break;

                    case 2:
                        // Val 2 skriver ut innehållet i ryggSäck strängen.

                        // Kollan om index 0 är tom. Det gör att programmet inte kraschar om man kollar i väskan om ryggSäck[] är tom.
                        if (ryggSäck[0] == null)
                        {
                            Console.WriteLine("\tVäskan är tom!");
                        }
                        else
                        {

                            Console.WriteLine("\n\tInnehållet i väskan: ");

                            // Loopa igenom arrayn och skriver ut innehållet
                            for (int i = 0; i < ryggSäck.Length; i++)
                            {
                                Console.WriteLine("\t" + ryggSäck[i]);
                            }
                        }
                        break;

                    case 3:
                        // Val 3

                        // Kollan om index 0 är tom. Det gör att programmet inte kraschar om man kollar i väskan om ryggSäck[] är tom.
                        if (ryggSäck[0] == null)
                        {
                            Console.WriteLine("\tVäskan är tom!");
                        }
                        else
                        {
                            Console.Write("\n\tAnge vad du letar efter: ");
                            string sökOrd = Console.ReadLine();
                       
                            // Loopa igenom arrayn och letar efter sökOrd och presenterar innehållet.
                            for (int i = 0; i < ryggSäck.Length; i++)
                            {
                                if (ryggSäck[i].ToUpper() == sökOrd.ToUpper())
                                {
                                    Console.WriteLine("\n\t" + ryggSäck[i] + " finns i väskan!");
                                } else
                                {
                                    Console.WriteLine("\n\t" + sökOrd + " finns inte i väskan!");
                                }
                            }
                        }
                        break;

                    case 4:
                        // Val 4 sätter isRunning boolien till false vilket gör att programmet hoppar ur while loopen och avslutas.
                        isRunning = false;
                        break;

                    default:
                        // Default case som presenteras om menyVal är 1 - 4. 
                        Console.Write("\n\tGör ett val mellan 1 - 4: ");
                        break;
                }
            }
        }
    }
}
