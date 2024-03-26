using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal class Menu
    {
        // Deklaration der Variablen
        public string spielerName;              // Variable zur Speicherung des Spieler-Namens.
        WordleSpiel wordle = new WordleSpiel(); // Instanzierung eines WordleSpiel-Objekts für das Spiel.

        // Methode zum Anzeigen des Hauptmenüs und zur Steuerung des Spielablaufs.
        public void StartMenu()
        {
            // Deklaration der Variablen
            bool ersterstart = true;            // Variable zur Verfolgung des ersten Spielstarts.
            bool regelngesehen = false;         // Variable zur Verfolgung, ob die Regeln bereits gesehen wurden.

            // Wenn es sich um den ersten Start handelt, wird der Benutzer nach seinem Namen gefragt und das Spiel wird gestartet.
            if (ersterstart)
            {
                Console.Clear();                          // Konsolenbildschirm leeren.
                Logo.WordleFarbe();                       // Anzeige des Wordle-Spiellogos als ASCII-Kunst in der Konsolentitelzeile.
                spielerName = wordle.HoleSpielerName();   // Abfrage des Spieler-Namens und Spielstart.
                ersterstart = false;                      // Die Variable ersterstart wird auf false gesetzt, da das Spiel jetzt nicht mehr zum ersten Mal gestartet wird.
            }

            // Menüschleife, um das Hauptmenü anzuzeigen und die Benutzereingabe zu verarbeiten.
            do
            {
                // Menupunkt für das Hauptmenü für den Highscore
                Console.Clear();                            // Konsolenbildschirm leeren.
                Logo.WordleFarbe();                         // Anzeige des Wordle-Spiellogos.

                // Menü anzeigen
                Console.Clear();                            // Konsolenbildschirm leeren.
                Logo.WordleFarbe();                         // Anzeige des Wordle-Spiellogos.
                Console.Title = "Hauptmenü";                // Setzen des Konsolentitels.
                Console.WriteLine("Wordle - Hauptmenü\n");  // Anzeige des Hauptmenüs.
                Console.WriteLine("1. Neues Spiel");        // Option für ein neues Spiel.
                Console.WriteLine("2. Regeln anzeigen");    // Option, um die Regeln anzuzeigen.
                Console.WriteLine("3. Spiel beenden\n");    // Option, um das Spiel zu beenden.
                Console.WriteLine("4. Highscore anzeigen\n"); // Option, um den Highscore anzuzeigen.


                Console.Write("Wähle eine Option: ");       // Aufforderung zur Benutzereingabe.

                // Benutzereingabe lesen und verarbeiten
                string eingabe = Console.ReadLine();        // Einlesen der Benutzereingabe.

                // Verzweigung, um die Benutzereingabe zu verarbeiten.
                switch (eingabe)
                {
                    case "1":
                        wordle.SetRegelngesehen(regelngesehen);  // Übergeben, ob die Regeln bereits gesehen wurden.
                        wordle.Start(spielerName);               // Starten eines neuen Spiels.
                        break;
                    case "2":
                        regelngesehen = true;                    // Setzen der Variable auf true, um anzuzeigen, dass die Regeln gesehen wurden.
                        wordle.SetRegelngesehen(regelngesehen);  // Übergeben der Information an das Wordle-Objekt.
                        Rules.AnzeigeRegelnMenu();               // Anzeige der Spielregeln.
                        break;
                    case "3":
                        wordle.SpielBeenden(spielerName);        // Beenden des Spiels und Dankesagung an den Spieler.
                        break;
                    case "4":
                        wordle.HighscoreAnzeigen();               // Anzeigen des Highscores.
                        break;
                    default:
                        break;
                }

            } while (true); // Das Menü wird kontinuierlich angezeigt, bis das Spiel beendet wird.
        }
    }
}
