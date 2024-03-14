using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal class Rules
    {
        private static void AnzeigeRegeln()
        {
            // Hier können die Regeln des Spiels angezeigt werden
            Console.Clear();  // Bildschirm löschen
            Logo.WordleFarbe();
            Console.WriteLine("Regeln für Wordle:");
            Console.WriteLine("1. Versuche das geheime Wort mit 5 Buchstaben zu erraten.");
            Console.WriteLine("2. Du hast insgesamt 6 Versuche.");
            Console.WriteLine("3. Für jeden Tipp erhältst du Rückmeldungen über korrekte Buchstaben an der richtigen Stelle,");
            Console.WriteLine("   korrekte Buchstaben an der falschen Stelle und fehlende Buchstaben im Wort.");
            Console.WriteLine("   \nLegende für die Farben:");

            // Zeige die Farblegenden für die Rückmeldung an.
            foreach (var (farbe, text) in new Dictionary<ConsoleColor, string>
            {
                { ConsoleColor.Green, "      Korrekter Buchstabe an der richtigen Stelle" },
                { ConsoleColor.Yellow, "      Korrekter Buchstabe an der falschen Stelle" },
                { ConsoleColor.Red, "      Fehlender Buchstabe" }
            })
            {
                Console.ForegroundColor = farbe;
                Console.Write($"{text}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine("\n4. Viel Spaß beim Raten!");
        }

        public static void AnzeigeRegelnMenu()
        {
            AnzeigeRegeln();
            Console.WriteLine("\nDrücke eine Taste, um zum Hauptmenü zurückzukehren...");
            Console.ReadKey();
        }

        public static void AnzeigeRegelnSpiel()
        {
            AnzeigeRegeln();
            Console.WriteLine("\nDrücke eine Taste, um das Spiel zu Starten...");
            Console.ReadKey();
        }
    }
}
