﻿using System;
using System.Collections.Generic;

namespace Övning7
{
    class Program
    {

        /*
         * 
         *      ALGORITMER
         *      
         *      Du behöver bara göra den här uppgiften om du siktar på ett betyg över C.
         *      För en bedömning på B-nivå ska du fylla i sortering och sökning för siffror, som beskrivs i case 1, 2 och 3.
         *      För en bedömning på A-nivå ska du även arbeta med sortering och sökning av bokstäver, som beskrivs i case 4, 5 och 6.
         *      
         *      Om du inte söker ett betyg över C kan du lämna in uppgiften blank.
         * 
         */

        static void Main(string[] args)
        {
            bool isRunning = true;
            bool intSortering = false; // Så vi kan kolla om våra siffror är sorterade
            bool bokstavSortering = false; // Så vi kan kolla om våra bokstäver är sorterade
            List<int> sifferLista = new List<int>(); // Här sparas siffrorna som vi genererar
            List<string> ordLista = new List<string>(); // Här sparas bokstäverna som vi genererar
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\tVälkommen till Övning 7 - Algoritmer\n\t#########################\n\n\t[1]Generera siffror\n\t[2]Sortera siffror\n\t[3]Sök bland siffror\n\n\t[4][EXTRA]Generera bokstäver\n\t[5][EXTRA]Sortera bokstäver\n\t[6][EXTRA]Sök bland bokstäver\n\n\t[7]Avsluta program");
                Int32.TryParse(Console.ReadLine(), out int meny); // Tar emot användarinput för vår meny
                switch (meny)
                {
                    case 1: // Här genererar vi ett fritt antal siffror och sparar i en lista för framtida sortering och sökning.
                        Console.Clear();
                        Console.WriteLine("\n\tVar god skriv in hur många siffror du vill generera.");
                        Int32.TryParse(Console.ReadLine(), out int siffror); // Tar emot antal siffror användaren vill generera
                        Random rnd = new Random(); // Skapar ett Random-objekt
                        for (int i = 0; i < siffror; i++) // FÖR VARJE siffra användaren vill generera
                        {
                            sifferLista.Add(rnd.Next(1, 100)); // Så sparar vi ett värde mellan 1 - 99 i vår sifferlista
                        }
                        SifferUtskrift(sifferLista); // Kallar på vår utskriftsmetod
                        intSortering = false; // Nya värden i listan gör den oorganiserad. Den behöver sorteras.
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 2: // Här ska vi sortera sifferlistan.                                                                       (BUBBELSORTERING AV SIFFROR)
                        Console.Clear();
                        if (sifferLista.Count > 0)
                        {
                            Console.WriteLine("\n\tSiffror sorterade. Se resultat;\n");

                            /*
                             *      BUBBELSORTERING (Kap 14.2.1)
                             * 
                             * FÖR (Loop A) en gång per inlägg i (sifferLista - 1)
                             *      FÖR (Loop B) en gång per inlägg i ((inlista - 1) - A)
                             *           OM siffra på plats (B) är större än siffra på plats (B+1)
                             *                Skapa temporärvariabel med samma värde som siffra på plats B
                             *                Siffra på plats B får samma värde som siffra på plats B+1
                             *                Siffra på plats B+1 får samma värde som den temporära variabeln
                             */

                            intSortering = true; // Listan är sorterad.
                            SifferUtskrift(sifferLista);

                        }
                        else
                        {
                            Console.WriteLine("\n\tDet saknas inlägg i sifferlistan. Generera lite siffror först.");
                        }
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 3: // Här ska användaren kunna söka bland siffrorna med en binärsökning.                                     (BINÄRSÖKNING AV SIFFROR)
                        Console.Clear();
                        if (sifferLista.Count > 0)
                        {
                            if (intSortering)
                            {
                                Console.WriteLine("\n\tVilken siffra vill du söka på?");
                                Int32.TryParse(Console.ReadLine(), out int key); // Tar emot användarens sökning
                                if (key < 0) key = 0; // Ser till att sökningen är på ett positivt tal

                                /*
                                 *      BINÄRSÖKNING (Kap 14.3)
                                 *      
                                 * Skapa "första" variabel med värdet 0
                                 * Skapa "sista" variabel med värdet av sifferlistans längd - 1
                                 * SÅ LÄNGE "första" är mindre än eller lika med "sista"
                                 *      Skapa "mellan" variabel genom "första" + "sista" delat med 2.
                                 *      OM sökvärde är större än siffra på indexplats "mellan" i sifferlistan
                                 *           "första" får värdet av "mellan" + 1
                                 *      ANNARS OM sökvärde är mindre än siffra på indexplats "mellan" i sifferlistan
                                 *           "sista" får värdet av "mellan" - 1
                                 *      ANNARS
                                 *           Skriv ut att siffran de sökt på finns på element "mellan" i sifferlistan.
                                 * OM "första" är större än "sista" när sökningen är över
                                 *      Skriv ut att sökningen inte lyckades.
                                 * 
                                 */

                                SifferUtskrift(sifferLista); // Skriver ut hela listan med vår metod.
                            }
                            else
                            {
                                Console.WriteLine("\n\tSiffrorna i din lista behöver sorteras. Kör en sortering innan sökningen."); // Användaren behöver göra en sortering.
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet saknas inlägg i sifferlistan. Generera lite siffror först."); // Användaren har inte genererat något värde till listan.
                        }
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 4: // Det här menyvalet är färdigskrivet för att generera ett antal nonsensord i slumpvald ordning.
                        Console.Clear();
                        Console.WriteLine("\n\tVar god skriv in hur många 'ord' du vill generera.");
                        Int32.TryParse(Console.ReadLine(), out int ord); // Tar emot antal siffror användaren vill generera
                        Random rnd2 = new Random(); // Skapar ett Random-objekt
                        for (int i = 0; i < ord; i++) // FÖR VARJE siffra användaren vill generera
                        {
                            char[] charVec = new char[rnd2.Next(5, 11)];
                            for (int j = 0; j < charVec.Length; j++)
                            {
                                charVec[j] = Convert.ToChar(rnd2.Next(97, 123));
                            }
                            ordLista.Add(new string(charVec));
                        }
                        BokstavUtskrift(ordLista);
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 5: // Här ska du skriva klart bubbelsorteringsalgoritmen som behövs för att sortera våra nonsensord i ordLista.                                (BUBBELSORTERING AV BOKSTÄVER)
                        Console.Clear();
                        if (ordLista.Count > 0)
                        {
                            Console.WriteLine("\n\tBokstäver sorterade. Se resultat;\n");

                            /*
                                 *      BUBBELSORTERING med bokstäver
                                 *      
                                 * Samma princip gäller för bubbelsortering med bokstäver som med siffror. Skillnaden är att vi behöver ett annat sätt att jämföra dem.
                                 * Vi kan använda CompareTo-metoden för att jämföra två strängar. Länk: https://msdn.microsoft.com/en-us/library/35f0x18w(v=vs.110).aspx
                                 * Om vi tilldelar en tillfällig int ett värde från CompareTo kan vi veta om den ena är tidigare (alfabetiskt) än den andra. Testa dig gärna fram lite!
                                 * Kodexempel;
                                 * 
                                 * int tmp = string1.CompareTo(string2);
                                 * if (tmp > 0)
                                 * 
                                 * Om vi vill få fram specifikt den första bokstaven ur ett ord kan vi använda ett index. Om vi kallar på ett index från en sträng får vi bokstaven på indikerad plats.
                                 * Exempelvis;
                                 * 
                                 * string ex = "Exempel";
                                 * Console.WriteLine(ex[0]);
                                 * 
                                 * Exemplet ovan kommer att ge oss ett stort 'E' som utskrift.
                                 * 
                                 * Med allt det här i åtanke kan vi göra en bubbelsortering utifrån första bokstaven i värdet användaren skriver in jämfört med första bokstaven i de värden som
                                 * finns sparade i ordLista. Knepigt, men det går! Skillnaden är, effektivt, att vi bygger ett jämförbart intvärde genom CompareTo-metoden, istället för att
                                 * direkt jämföra intvärden.
                                 * 
                                 */

                            bokstavSortering = true; // Listan är sorterad.
                            BokstavUtskrift(ordLista);

                        }
                        else
                        {
                            Console.WriteLine("\n\tDet saknas inlägg i bokstavslistan. Generera lite bokstäver först.");
                        }
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 6: // Här ska användaren kunna söka på första bokstaven av våra nonsensord i ordLista.                                                      (BINÄRSÖKNING AV BOKSTÄVER)
                        Console.Clear();
                        if (ordLista.Count > 0)
                        {
                            if (bokstavSortering)
                            {
                                Console.WriteLine("\n\tVilken bokstav ska sökningen börja på?");
                                string key = Console.ReadLine(); ; // Tar emot användarens sökning
                                if (key.Length <= 0) key = "a"; // Ser till att sökningen alltid är något, i det här fallet "a"

                                /*
                                 *      BINÄRSÖKNING med bokstäver
                                 *      
                                 * Utifrån de nya verktyg vi har gått igenom tidigare (CompareTo och att plocka ut enstaka char från strängar för jämförelser) så
                                 * ska vi här skriva en binärsökning för att leta efter bokstäver.
                                 * 
                                 */

                                BokstavUtskrift(ordLista); // Skriver ut hela listan med vår metod.
                            }
                            else
                            {
                                Console.WriteLine("\n\tSiffrorna i din lista behöver sorteras. Kör en sortering innan sökningen."); // Användaren behöver göra en sortering.
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tDet saknas inlägg i sifferlistan. Generera lite siffror först."); // Användaren har inte genererat något värde till listan.
                        }
                        MenyAvslut(); // Kallar på vår standardiserade menyavslutning.
                        break;

                    case 7: // Programmet avslutas
                        isRunning = false;
                        break;
                }
            }
        }

        // Allting under den här punkten är metoder till syfte av programmets användarvänlighet.

        static void SifferUtskrift(List<int> sifferLista) // Tar emot en lista, skriver ut alla inlägg i listan på ett stiligt vis.
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int counter = 0; // Initierar en räknare
            foreach (int s in sifferLista) // FÖR VARJE siffra i sifferlistan
                if (counter == 0) // OM räknaren är noll
                {
                    if (s < 10)
                        Console.Write("\t" + s + "  "); // Skjut fram raden, skriv ut siffran, lägg till mer utrymme för läsbarhet
                    else
                        Console.Write("\t" + s + " "); // Skjut fram raden, skriv ut siffran
                    counter++; // Öka räknare med ett
                }
                else if (counter < 4) // ANNARS OM räknaren är mindre än fem
                {
                    if (s < 10)
                        Console.Write(s + "  "); // Skjut fram raden, skriv ut siffran, lägg till mer utrymme för läsbarhet
                    else
                        Console.Write(s + " "); // Skjut fram raden, skriv ut siffran
                    counter++; // Öka räknare med 1
                }
                else // ANNARS
                {
                    Console.WriteLine(s + " "); // Skriv ut siffra på ny rad
                    counter = 0; // Nollställ räknare
                }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void BokstavUtskrift(List<string> ordLista) // Tar emot en lista, skriver ut alla inlägg i listan på ett stiligt vis.
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string b in ordLista)
            {
                Console.WriteLine("\t " + b);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MenyAvslut() // För att undvika upprepande kod
        {
            Console.WriteLine("\n\tTryck ENTER för att återvända till menyn.");
            Console.ReadLine();
        }

    }
}
