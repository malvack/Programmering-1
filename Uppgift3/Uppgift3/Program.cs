using System;

namespace Uppgift_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklaration av variabler
            Random slumpat = new Random(); // skapar ett random objekt

            // Jag lade till 20 i Next metodens parameter för att se til latt det inte blev högre tal än 20.
            int speltal = slumpat.Next(20); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20

            // läs på, vad är overload metoder? https://msdn.microsoft.com/en-us/library/system.random.next(v=vs.110).aspx
            bool spela = true; // Variabel för att kontrollera om spelet ska fortsätta köras
            int tal; // Jag måste deklarera tal innan while loppen för inmatning används.

            // Spela är true när programmet startar. While loopen kollar om spela inte är true vilket gör att koden innanför while loopen inte körs alls. Tog bort !.
            while (spela)
            {
                Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                // Jag använder en While loop som retunerar true om rätt inmatning görs.
                while (!int.TryParse(Console.ReadLine(), out tal))
                {
                    Console.Write("\n\tDu måste ange ett numeriskt värde!\n\tGissa på ett tal mellan 1 och 20: ");
                }

                if (tal < speltal)
                {
                    Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
                }

                if (tal > speltal)
                {
                    // Det saknas ett + tecken efter tal.
                    Console.WriteLine("\tDet inmatade talet " + tal + " är för stort, försök igen.");
                }
                // Här använder vi en felaktig operand "=". För att jämnföra två värden behöver vi ange "==" istället.
                if (tal == speltal)
                {
                    Console.WriteLine("\tGrattis, du gissade rätt!");
                    // Programmet stänger alltid av efter första gissningen. Det saknades "måsvingar" i IF satsen.
                    spela = false;
                    // Lade bara till detta för att kunna se resultatet så att programmet inte stänger ner sig direkt.
                    Console.ReadLine();
                }
            }
        }
    }
}