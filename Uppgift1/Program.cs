using System;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  
                Deklarera variabler.
                Valde string för fNamn, eNamn och alder då jag läser in värden i med ReadLine() funktionen.
                ReadLine() läser enbart in string värden.
                Valde int för antalDagar då jag använder denna i matematiska beräkningar.
            */
            string fNamn, eNamn, alder;
            int antalDagar;

            // Läs in för- och efternamn i variablarna fNamn, eNamn och hälsa välkommen.
            Console.WriteLine("----------- Uppgift 1 -----------");
            Console.WriteLine("Ange ditt förnamn:");
            fNamn = Console.ReadLine();
            Console.WriteLine("Ange ditt efternamn:");
            eNamn = Console.ReadLine();
            Console.WriteLine("Hej {0} {1}!", fNamn, eNamn);

            // Läs in ålder och spara i string variablen alder.
            Console.WriteLine("Hur gammal är du {0}?", fNamn);
            alder = Console.ReadLine();

            // Konventera om alder str till int32 och mulitiplicera med 365 dagar. Laga resultatet i variabeln dagar. //
            antalDagar = Convert.ToInt32(alder) * 365;

            // Skriv ut värdet i int variablen dagar.
            Console.WriteLine("{0}, du är {1} dagar gammal!", fNamn, antalDagar);
        }
    }
}
