using System;

namespace Uppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  
                Deklarera variabler.
                Valde string för fNamn, eNamn och då jag läser in värden i med ReadLine() funktionen.
                ReadLine() läser enbart in string värden om inget annat anges.
                Valde int för alder, antalDagar då jag använder matematiska beräkningar för dessa.
            */
            string fNamn, eNamn;
            int alder, antalDagar;

            // Läs in för- och efternamn i variablarna fNamn, eNamn och hälsa välkommen.
            Console.WriteLine("------------------------ Uppgift 1 ------------------------");
            Console.WriteLine("Ange ditt förnamn:");
            fNamn = Console.ReadLine();
            Console.WriteLine("Ange ditt efternamn:");
            eNamn = Console.ReadLine();
            Console.WriteLine("Hej {0} {1}!", fNamn, eNamn);

            // Läs in ålder och spara i string variablen alder.
            Console.WriteLine("Hur gammal är du {0}?", fNamn);

            // Acceptera enbart numeriska värden i variablen alder
            while (!int.TryParse(Console.ReadLine(), out alder))
            {
                Console.WriteLine("Du måste ange ett numeriskt värde!");
            }

            // Mulitiplicera alder med 365 dagar. Laga resultatet i variabeln antalDagar. //
            antalDagar = alder * 365;

            // Skriv ut värdet i int variablen dagar.
            Console.WriteLine("Visste du {0}, att du är ungefär {1} dagar gammal.", fNamn, antalDagar);

            // Extra uppgifter //
            Console.WriteLine("---------------------- Extra Uppgift ----------------------");

            // Spara dagens datum i idag variablen.
            DateTime idag = DateTime.Now;
            DateTime birthday;

            // Fråga efter användarens födelsedag och lagra värdet i birthday variabeln.
            Console.WriteLine("Ange din födelsedag i formatet åååå-mm-dd:");
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Du måste ange din födelsedag i formatet åååå-mm-dd!");
            }

            // Räkna ut antal födelsedagar, månader, dagar, timmar, minuter och sekunder användaren har levt.
            TimeSpan tid = idag - birthday;

            // Har valt att använda Decimal varibalar här för att få mer exakta värden. Med int så tappade jag massa data.
            Decimal totalAr = Convert.ToDecimal(tid.TotalDays) / 365;
            Decimal totalManad = totalAr * 12;
            Decimal totalDagar = Convert.ToDecimal(tid.TotalDays);
            Decimal totalTimmar = Convert.ToDecimal(tid.TotalHours);
            Decimal totalMinuter = Convert.ToDecimal(tid.TotalMinutes);
            Decimal totalSekunder = Convert.ToDecimal(tid.TotalSeconds);

           // Presentera resultatet för användaren. Har valt att presentera värdena med ToString("0") för att inte ha med decimalerna.
            Console.WriteLine("------------------------ Statistik ------------------------");
            Console.WriteLine("Antal födelsedagar: {0}", totalAr.ToString("0.00"));
            Console.WriteLine("Antal månader:      {0}", totalManad.ToString("0"));
            Console.WriteLine("Antal dagar:        {0}", totalDagar.ToString("0"));
            Console.WriteLine("Antal timmar:       {0}", totalTimmar.ToString("0"));
            Console.WriteLine("Antal minuter:      {0}", totalMinuter.ToString("0"));
            Console.WriteLine("Antal sekunder:     {0}", totalSekunder.ToString("0"));
            Console.WriteLine("-----------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
