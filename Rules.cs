using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal class Rules
    {
        // Methode zur Anzeige der Regeln des Spiels
        private static void AnzeigeRegeln()
        {
            // Bildschirm löschen und Wordle-Logo anzeigen
            Console.Clear();
            Logo.WordleFarbe();

            // Regeln des Spiels anzeigen
            Console.WriteLine("Regeln für Wordle:");
            Console.WriteLine("1. Versuche das geheime Wort mit 5 Buchstaben zu erraten.");
            Console.WriteLine("2. Du hast insgesamt 6 Versuche.");
            Console.WriteLine("3. Für jeden Tipp erhältst du Rückmeldungen über korrekte Buchstaben an der richtigen Stelle,");
            Console.WriteLine("   korrekte Buchstaben an der falschen Stelle und fehlende Buchstaben im Wort.");
            Console.WriteLine("   \nLegende für die Farben:");

            // Farblegenden für die Rückmeldung anzeigen
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

            // Weitere Regel anzeigen
            Console.WriteLine("\n4. Viel Spaß beim Raten!");
        }

        // Methode zur Anzeige der Regeln im Menü
        public static void AnzeigeRegelnMenu()
        {
            // Regeln anzeigen und Benutzeranweisung geben
            AnzeigeRegeln();
            Console.WriteLine("\nDrücke eine Taste, um zum Hauptmenü zurückzukehren...");
            Console.Title = "Regel zu Wordle";
            Console.ReadKey(); // Warten auf Benutzerinteraktion
        }

        // Methode zur Anzeige der Regeln vor Spielstart
        public static void AnzeigeRegelnSpiel()
        {
            // Regeln anzeigen und Benutzeranweisung geben
            AnzeigeRegeln();
            Console.WriteLine("\nDrücke eine Taste, um das Spiel zu Starten...");
            Console.Title = "Regel zu Wordle";
            Console.ReadKey(); // Warten auf Benutzerinteraktion
        }
    }
}
