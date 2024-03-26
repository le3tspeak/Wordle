using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wordle
{

    internal class WordleSpiel
    {
        // Variable zur Speicherung, ob die Regeln bereits gesehen wurden.
        private bool regelngesehen;
        // Variablen zur Speicherung der Start- und Endzeit des Spiels.
        public DateTime start;
        public DateTime end;
        // Variable zur Speicherung der benötigten Zeit.
        public string zeit;

        // Setter-Methode für die Variable regelngesehen.
        public void SetRegelngesehen(bool regelngesehen)
        {
            this.regelngesehen = regelngesehen;
        }

        // Start-Methode für das Spiel mit dem Spielername als Parameter.
        public void Start(string spielerName)
        {
            Logo.WordleFarbe();                 // Zeigt das Wordle-Spiellogo als ASCII-Kunst in der Konsolentitelzeile an.
            Console.Clear();                    // Konsolenbildschirm leeren
            SpielStarten(spielerName);          // Startet das Spiel mit dem Spielername als Parameter
        }

        // Funktion zur Eingabe des Spieler-Namens
        public string HoleSpielerName()
        {
            string name;
            // Fordere den Spieler auf, seinen Namen einzugeben, und überprüfe die Gültigkeit des Namens.
            while (true)
            {
                Console.Write("Gib deinen Namen ein: ");
                name = Console.ReadLine();

                // Überprüfe, ob der Name nicht leer ist und keine Zahlen oder Sonderzeichen enthält.
                if (!Test.NullOrWhiteSpace(name) && !Test.EnthältZahlen(name) && !Test.EnthältSonderzeichen(name))
                    break; // Name ist gültig, beende die Schleife.
                else
                {
                    Console.Clear();    // Lösche den Bildschirm.          
                    Logo.WordleFarbe();      // Zeige das Wordle-Spiellogo an.
                    Console.WriteLine("Ungültige Eingabe. Der Name darf nicht leer sein und darf keine Zahlen enthalten.");
                }
            }
            return name; // Gib den gültigen Namen zurück.
        }

        // Funktionen für die Zeitmessung
        public void Startzeit()
        {
            start = DateTime.Now;
        }
        public void Endzeit()
        {
            end = DateTime.Now;
        }
        public string Zeit()
        {
            TimeSpan zeitdauer = end - start;
            return $"{zeitdauer.Minutes}:{zeitdauer.Seconds}";
        }

        // Spielstart Methode für das Spiel mit dem Spielername als Parameter
        public void SpielStarten(string spielerName)
        {
            // Liste von geheimen Wörtern
            List<string> wörter = new List<string> { "apfel", "tisch", "stuhl", "wolke", "kette" };

            bool ersteRunde = true;
            bool weitermachen = true;
            // Startzeit speichern
            Startzeit();

            // Spielrunden durchführen
            do
            {
                if (ersteRunde)
                {
                    SpielerBegrüßen(spielerName);   // Spieler begrüßen und Anweisungen anzeigen 
                    ersteRunde = false;
                }
                Console.Clear();
                Logo.WordleFarbe();
                string geheimesWort = ZufälligesWortAuswählen(wörter);      // Zufälliges Wort auswählen
                bool gewonnen = WortErraten(geheimesWort, spielerName);     // Wort raten und überprüfen, ob der Spieler gewonnen hat
                ErgebnisAnzeigen(gewonnen, spielerName, geheimesWort);      // Ergebnis der Runde anzeigen
                weitermachen = Weitermachen();                              // Spieler fragen, ob er eine weitere Runde spielen möchte
            } while (weitermachen);

            SpielBeenden(spielerName);
        }

        //Methode für den Highscore speicherin in Datei
        public void HighscoreSpeichern(string spielerName, string zeit)
        {
            // Pfad zur Highscore-Datei
            string datei = "highscore.txt";

            // Überprüfen, ob die Datei existiert
            if (!System.IO.File.Exists(datei))
            {
                // Wenn die Datei nicht existiert, wird sie erstellt und der Highscore-Eintrag hinzugefügt
                System.IO.File.WriteAllText(datei, $"{spielerName}\t{zeit}");
            }
            else
            {
                // Wenn die Datei existiert, wird der Highscore-Eintrag hinzugefügt
                System.IO.File.AppendAllText(datei, $"\n{spielerName}\t{zeit}");
            }
        }

        // Methode zum Lesen des Highscores aus der Datei
        public string HighscoreLesen()
        {
            // Pfad zur Highscore-Datei
            string datei = "highscore.txt";

            // Überprüfen, ob die Datei existiert
            if (!System.IO.File.Exists(datei))
            {
                // Wenn die Datei nicht existiert, wird sie erstellt und mit zufälligen Einträgen gefüllt
                Random zufall = new Random();
                string[] namen = { "Udo", "Kalle", "Franko", "Alex" };
                string highscore = "";
                for (int i = 0; i < namen.Length; i++)
                {
                    highscore += $"{namen[i]}\t{zufall.Next(2, 6)}:{zufall.Next(0, 60)}\n";
                }
                return highscore;
            }
            else
            {
                // Wenn die Datei existiert, wird der Inhalt gelesen und zurückgegeben
                return System.IO.File.ReadAllText(datei);
            }
        }

        // Highscore in der Konsole ausgegeben in einer tabellarischen Form und sortiert nach der niedrigsten Zeit
        public void HighscoreAnzeigen()
        {
            // Highscore aus der Datei lesen
            string highscore = HighscoreLesen();

            // Logo anzeigen
            Console.Clear();
            Logo.WordleFarbe();

            // Highscore in der Konsole anzeigen
            Console.WriteLine("Highscore\n");
            Console.WriteLine("Name\tZeit");
            Console.WriteLine("----\t----");

            // Highscore in eine Liste von Tupeln konvertieren
            List<(string, string)> highscoreListe = new List<(string, string)>();
            string[] highscoreEinträge = highscore.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (string eintrag in highscoreEinträge)
            {
                string[] daten = eintrag.Split('\t');
                highscoreListe.Add((daten[0], daten[1]));
            }

            // Highscore nach der Zeit sortieren
            highscoreListe = highscoreListe.OrderBy(x => TimeSpan.Parse(x.Item2)).ToList();

            // Highscore in der Konsole ausgeben
            foreach ((string name, string zeit) in highscoreListe)
            {
                Console.WriteLine($"{name}\t{zeit}");
            }

            // Warten auf Benutzereingabe
            Console.WriteLine("\nDrücke eine beliebige Taste, um zum Hauptmenü zurückzukehren.");
            Console.ReadKey();
        }

        // Methode zum Anzeigen der Regeln des Spiels
        private void SpielerBegrüßen(string spielerName)
        {
            // Begrüßungsnachricht und Legende anzeigen
            if (!regelngesehen)
                Rules.AnzeigeRegelnSpiel();

            Console.WriteLine($"Hallo {spielerName}!\n\nVersuche, das geheime Wort mit 5 Buchstaben zu erraten.\nDu hast 6 Versuche.\n");
        }

        // Methode zum Auswählen eines zufälligen Wortes aus einer Liste
        private string ZufälligesWortAuswählen(List<string> wörter)
        {
            // Zufälliges Wort aus der Liste auswählen
            Random zufall = new Random();
            return wörter[zufall.Next(wörter.Count)];
        }

        // Methode zum Raten des geheimen Wortes
        private bool WortErraten(string geheimesWort, string spielerName)
        {
            // Wort erraten
            for (int versuch = 1; versuch <= 6; versuch++)
            {
                Console.WriteLine($"\nVersuch {versuch} von 6:");
                Console.Title = $"Starten deinen {versuch} Versuch";
                string tipp = TippEingeben();

                // Überprüfen, ob die Eingabe Sonderzeichen ist oder Zahlen enthält
                if (Test.EnthältZahlen(tipp) || Test.EnthältSonderzeichen(tipp))
                {
                    Console.WriteLine("Bitte gib ein Wort mit genau 5 Buchstaben ein ohne Zahlen oder Sonderzeichen!");
                    versuch--;
                    continue;
                }
                // Überprüfen, ob die Eingabe Leer ist
                else if (Test.NullOrWhiteSpace(tipp))
                {
                    Console.WriteLine("Die eingabe darf nicht Leer sein. Bitte gib ein Wort mit genau 5 Buchstaben ein!");
                    versuch--;
                    continue;
                }
                // Überprüfen, ob die Länge des Tipps korrekt ist
                else if (tipp.Length != geheimesWort.Length)
                {
                    Console.WriteLine("Bitte gib ein Wort mit genau 5 Buchstaben ein!");
                    versuch--;
                    continue;
                }

                // Tipp überprüfen und Feedback geben
                (bool[] korrekteBuchstaben, bool[] falschePositionen, bool[] fehlendeBuchstaben) = TippÜberprüfen(tipp, geheimesWort);

                // Rückmeldung anzeigen
                RückmeldungAnzeigen(tipp, korrekteBuchstaben, falschePositionen, fehlendeBuchstaben);

                // Überprüfen, ob das Wort komplett richtig geraten wurde
                if (korrekteBuchstaben.All(x => x))
                {
                    return true;
                }
            }
            return false;
        }

        // Methode zum Überprüfen des Tipps des Spielers
        private (bool[], bool[], bool[]) TippÜberprüfen(string tipp, string geheimesWort)
        {
            // Überprüft den Tipp des Spielers und gibt entsprechendes Feedback.
            bool[] korrekteBuchstaben = new bool[geheimesWort.Length];  // Speichert, ob Buchstaben an der richtigen Stelle sind.
            bool[] falschePositionen = new bool[geheimesWort.Length];   // Speichert, ob Buchstaben vorhanden, aber an der falschen Stelle sind.
            bool[] fehlendeBuchstaben = new bool[geheimesWort.Length];  // Speichert, ob Buchstaben im geheimen Wort fehlen.

            // Durchlaufe den Tipp und vergleiche mit dem geheimen Wort.
            for (int i = 0; i < geheimesWort.Length; i++)
            {
                if (geheimesWort[i] == tipp[i])
                {
                    korrekteBuchstaben[i] = true;   // Buchstabe an richtiger Stelle.
                }
                else if (geheimesWort.Contains(tipp[i]))
                {
                    falschePositionen[i] = true;    // Buchstabe ist im Wort, aber an falscher Stelle.
                }
                else
                {
                    fehlendeBuchstaben[i] = true;   // Buchstabe fehlt im geheimen Wort.
                }
            }
            return (korrekteBuchstaben, falschePositionen, fehlendeBuchstaben); // Rückgabe des Ergebnisses.
        }

        // Methode zum Eingeben des Tipps des Spielers
        private string TippEingeben()
        {
            // Tipp des Spielers einlesen
            Console.Write("Gib deinen Tipp ein: ");
            return Console.ReadLine().Trim().ToLower();
        }

        // Methode zum Anzeigen des Feedbacks zum Tipp des Spielers
        private void RückmeldungAnzeigen(string tipp, bool[] korrekteBuchstaben, bool[] falschePositionen, bool[] fehlendeBuchstaben)
        {
            // Zeigt eine visuelle Rückmeldung zum Tipp des Spielers an.
            Console.WriteLine("Rückmeldung:");

            // Durchlaufe den Tipp und markiere die korrekten, falsch positionierten und fehlenden Buchstaben entsprechend.
            for (int i = 0; i < tipp.Length; i++)
            {
                if (korrekteBuchstaben[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;   // Grün für korrekte Buchstaben.
                }
                else if (falschePositionen[i])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Gelb für falsch positionierte Buchstaben.
                }
                else if (fehlendeBuchstaben[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;     // Rot für fehlende Buchstaben.
                }
                else
                {
                    Console.ResetColor(); // Zurücksetzen der Farbe für Buchstaben ohne Markierung.
                }

                Console.Write(i == 0 ? char.ToUpper(tipp[i]) : tipp[i]); // Drucke den Buchstaben und achte auf Großschreibung.
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Methode zum Anzeigen des Ergebnisses der Runde
        private void ErgebnisAnzeigen(bool gewonnen, string spielerName, string geheimesWort)
        {
            // Zeige das Ergebnis der Runde an.
            Console.WriteLine("\nDas geheime Wort war: " + char.ToUpper(geheimesWort[0]) + geheimesWort.Substring(1));

            // Aktualisiere den Konsolentitel entsprechend dem Spielergebnis.
            if (gewonnen) // Gewonnen
            {
                Endzeit();                              // Speichern der Endzeit
                zeit = Zeit();                          // Speichern der benötigten Zeit
                HighscoreSpeichern(spielerName, zeit);  // Speichern des Highscores in einer Datei

                // Anzeigen des Gewinns und des Highscores
                Console.Title = $"Glückwunsch {spielerName}! Gewonnen";                         // Titel für den Fall eines Gewinns.
                Console.WriteLine($"\nGlückwunsch, {spielerName}! Du hast das Wort erraten!");  // Nachricht für einen Gewinn.

                // Frage, ob der Highscore angezeigt werden soll
                Console.Write("Möchtest du den Highscore anzeigen? (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("J");
                Console.ResetColor();
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("N");
                Console.ResetColor();
                Console.Write("ein): ");
                string antwort = Console.ReadLine().Trim().ToLower();
                if (antwort == "ja" || antwort == "j")
                {
                    HighscoreAnzeigen();
                }
            }
            else // Niederlage
            {
                Console.Title = $"Entschuldigung, {spielerName}! Verloren";                                 // Titel für den Fall einer Niederlage.
                Console.WriteLine($"\nEntschuldigung, {spielerName}, dir sind die Versuche ausgegangen.");  // Nachricht für eine Niederlage.
            }
        }

        // Methode zum Fragen, ob der Spieler eine weitere Runde spielen möchte
        private static bool Weitermachen()
        {
            Console.Write("Möchtest du eine weitere Runde spielen? (");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("J");
            Console.ResetColor();
            Console.Write("a/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("N");
            Console.ResetColor();
            Console.Write("ein): ");
            string antwort = Console.ReadLine().Trim().ToLower();
            Console.Clear();
            return antwort == "ja" || antwort == "j";
        }

        // Methode zum Beenden des Spiels
        public void SpielBeenden(string spielerName)
        {
            Console.Clear();                                                // Löscht den Bildschirminhalt der Konsole.
            Logo.DankeFarbe(spielerName);                                   // Zeigt eine Dankesnachricht mit ASCII-Kunst an.
            Console.WriteLine($"\t\tDanke {spielerName}, fürs Spielen.");   // Gibt eine Dankesnachricht mit dem Spielername aus.
            Console.Title = $"Danke fürs Spielen {spielerName}";            // Consolen Titel Anpassen
            Console.ReadKey();                                              // Wartet auf eine Taste, bevor das Programm beendet wird.
            Environment.Exit(0);                                            // Beendet das Programm.
        }
    }
}
