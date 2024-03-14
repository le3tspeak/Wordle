using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal class Menu
    {
        public string spielerName;              // Der Name des Spielers.
        WordleSpiel wordle = new WordleSpiel(); // Instanziierung des WordleSpiel-Objekts.

        public void StartMenu()
        {
            bool ersterstart = true;
            bool regelngesehen = false;

            if (ersterstart)
                Console.Clear();                          // Bildschirm löschen
                Logo.WordleFarbe();                       // Zeigt das Wordle-Spiellogo als ASCII-Kunst in der Konsolentitelzeile an.
                spielerName = wordle.HoleSpielerName();   // Spielername abfragen und Spiel starten
                ersterstart = false;                      // Setze die Variable auf false, da das Spiel jetzt nicht mehr zum ersten Mal gestartet wird.                

            do
            {
                // Menü anzeigen
                Console.Clear();                            // Bildschirm löschen
                Logo.WordleFarbe();
                Console.WriteLine("Wordle - Hauptmenü\n");
                Console.WriteLine("1. Neues Spiel");
                Console.WriteLine("2. Regeln anzeigen");
                Console.WriteLine("3. Spiel beenden\n");
                Console.Write("Wähle eine Option: ");

                // Benutzereingabe lesen und verarbeiten
                string eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        wordle.SetRegelngesehen(regelngesehen);
                        wordle.Start(spielerName);               // Neues Spiel starten
                        break;
                    case "2":
                        regelngesehen = true;                    // Ändere boll auf True für Regelngesehen
                        wordle.SetRegelngesehen(regelngesehen);  // Setze in Wordle Regeln als gesehen
                        Rules.AnzeigeRegelnMenu();               // Regeln anzeigen
                        break;
                    case "3":
                        wordle.SpielBeenden(spielerName);        // Spiel Beenden und Dankesagung
                        break;
                    default:
                        break;
                }

            } while (true);
        }
    }
}
