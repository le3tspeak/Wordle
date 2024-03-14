using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Wordle
{
    // Die Klasse Logo enthält Methoden zum Anzeigen von ASCII-Kunst für das Spiel.
    internal class Logo
    {
        // Zeigt das Wordle-Spiellogo als ASCII-Kunst in der Konsolentitelzeile an.
        public static void Wordle()
        {
            Console.Title = "Willkommen bei Wordle";
            string ASCII = @"
 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| | _____  _____ | || |     ____     | || |  _______     | || |  ________    | || |   _____      | || |  _________   | |
| ||_   _||_   _|| || |   .'    `.   | || | |_   __ \    | || | |_   ___ `.  | || |  |_   _|     | || | |_   ___  |  | |
| |  | | /\ | |  | || |  /  .--.  \  | || |   | |__) |   | || |   | |   `. \ | || |    | |       | || |   | |_  \_|  | |
| |  | |/  \| |  | || |  | |    | |  | || |   |  __ /    | || |   | |    | | | || |    | |   _   | || |   |  _|  _   | |
| |  |   /\   |  | || |  \  `--'  /  | || |  _| |  \ \_  | || |  _| |___.' / | || |   _| |__/ |  | || |  _| |___/ |  | |
| |  |__/  \__|  | || |   `.____.'   | || | |____| |___| | || | |________.'  | || |  |________|  | || | |_________|  | |
| |              | || |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'
 ";
            Console.WriteLine(ASCII);
        }

        // Zeigt eine Dankesnachricht für den Spieler mit ASCII-Kunst an.
        public static void Danke(string spielername)
        {
            Console.Title = $"Danke fürs Spielen {spielername}";
            string ASCII = @" 
         .----------------.  .----------------.  .-----------------. .----------------.  .----------------. 
        | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
        | |  ________    | || |      __      | || | ____  _____  | || |  ___  ____   | || |  _________   | |
        | | |_   ___ `.  | || |     /  \     | || ||_   \|_   _| | || | |_  ||_  _|  | || | |_   ___  |  | |
        | |   | |   `. \ | || |    / /\ \    | || |  |   \ | |   | || |   | |_/ /    | || |   | |_  \_|  | |
        | |   | |    | | | || |   / ____ \   | || |  | |\ \| |   | || |   |  __'.    | || |   |  _|  _   | |
        | |  _| |___.' / | || | _/ /    \ \_ | || | _| |_\   |_  | || |  _| |  \ \_  | || |  _| |___/ |  | |
        | | |________.'  | || ||____|  |____|| || ||_____|\____| | || | |____||____| | || | |_________|  | |
        | |              | || |              | || |              | || |              | || |              | |
        | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
         '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
        ";
            Console.WriteLine(ASCII);
        }

        // Zeigt das Wordle-Spiellogo in Farbe als ASCII-Kunst in der Konsolentitelzeile an.
        public static void WordleFarbe()
        {
            Console.Title = "Willkommen bei Wordle";

            string ASCII = @"
\e[37m .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.\e[0m
\e[37m| \e[31m.--------------.\e[37m || \e[31m.--------------.\e[37m || \e[31m.--------------.\e[37m || \e[31m.--------------.\e[37m || \e[31m.--------------.\e[37m || \e[31m.--------------.\e[37m |\e[0m
\e[37m| \e[31m|\e[32m _____  _____ \e[31m|\e[37m || \e[31m|\e[32m     ____     \e[31m|\e[37m || \e[31m|\e[32m  _______     \e[31m|\e[37m || \e[31m|\e[32m  ________    \e[31m|\e[37m || \e[31m|\e[32m   _____      \e[31m|\e[37m || \e[31m|\e[32m  _________   \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|\e[32m|_   _||_   _|\e[31m|\e[37m || \e[31m|\e[32m   .'    `.   \e[31m|\e[37m || \e[31m|\e[32m |_   __ \    \e[31m|\e[37m || \e[31m|\e[32m |_   ___ `.  \e[31m|\e[37m || \e[31m|\e[32m  |_   _|     \e[31m|\e[37m || \e[31m|\e[32m |_   ___  |  \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|\e[32m  | | /\ | |  \e[31m|\e[37m || \e[31m|\e[32m  /  .--.  \  \e[31m|\e[37m || \e[31m|\e[32m   | |__) |   \e[31m|\e[37m || \e[31m|\e[32m   | |   `. \ \e[31m|\e[37m || \e[31m|\e[32m    | |       \e[31m|\e[37m || \e[31m|\e[32m   | |_  \_|  \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|\e[32m  | |/  \| |  \e[31m|\e[37m || \e[31m|\e[32m |  |    |  | \e[31m|\e[37m || \e[31m|\e[32m   |  __ /    \e[31m|\e[37m || \e[31m|\e[32m   | |    | | \e[31m|\e[37m || \e[31m|\e[32m    | |   _   \e[31m|\e[37m || \e[31m|\e[32m   |  _|  _   \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|\e[32m  |   /\   | \e[31m |\e[37m || \e[31m|\e[32m  \  `--'  /  \e[31m|\e[37m || \e[31m|\e[32m  _| |  \ \_  \e[31m|\e[37m || \e[31m|\e[32m  _| |___.' / \e[31m|\e[37m || \e[31m|\e[32m   _| |__/ |  \e[31m|\e[37m || \e[31m|\e[32m  _| |___/ |  \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|\e[32m  |__/  \__|  \e[31m|\e[37m || \e[31m|\e[32m   `.____.'   \e[31m|\e[37m || \e[31m|\e[32m |____| |___| \e[31m|\e[37m || \e[31m|\e[32m |________.'  \e[31m|\e[37m || \e[31m|\e[32m  |________|  \e[31m|\e[37m || \e[31m|\e[32m |_________|  \e[31m|\e[37m |\e[0m
\e[37m| \e[31m|              |\e[37m || \e[31m|              |\e[37m || \e[31m|              |\e[37m || \e[31m|              |\e[37m || \e[31m|              |\e[37m || \e[31m|              |\e[37m |\e[0m
\e[37m| \e[31m'--------------'\e[37m || \e[31m'--------------'\e[37m || \e[31m'--------------'\e[37m || \e[31m'--------------'\e[37m || \e[31m'--------------'\e[37m || \e[31m'--------------'\e[37m |\e[0m
\e[37m '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' \e[0m
";

            // Regulärer Ausdruck für die Ersetzung von Escape-Sequenzen
            string pattern = @"\\e\[37m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[37m");  // Ersetze die Escape-Sequenz für die Farbe Weiß durch den entsprechenden ANSI-Code

            pattern = @"\\e\[32m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[32m");  // Ersetze die Escape-Sequenz für die Farbe Grün durch den entsprechenden ANSI-Code

            pattern = @"\\e\[31m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[31m");  // Ersetze die Escape-Sequenz für die Farbe Rot durch den entsprechenden ANSI-Code

            pattern = @"\\e\[0m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[0m");   // Ersetze die Escape-Sequenz für die Rückkehr zur Standardfarbe durch den entsprechenden ANSI-Code

            // Ausgabe der ASCII-Kunst
            Console.WriteLine(ASCII);
        }

        // Zeigt das Danke-Spiellogo in Farbe als ASCII-Kunst in der Konsolentitelzeile an.
        public static void DankeFarbe(string spielername)
        {
            // ASCII-Kunst mit ANSI-Escape-Sequenzen für die Farbänderungen
            string ASCII = @"
         .----------------.  .----------------.  .-----------------. .----------------.  .----------------. 
        | \e[37m.--------------.\e[0m || \e[37m.--------------.\e[0m || \e[37m.--------------.\e[0m || \e[37m.--------------.\e[0m || \e[37m.--------------.\e[0m |
        | |\e[33m  ________    \e[0m| || |\e[33m      __      \e[0m| || |\e[33m ____  _____  \e[0m| || |\e[33m  ___  ____   \e[0m| || |\e[33m  _________   \e[0m| |
        | |\e[33m |_   ___ `.  \e[0m| || |\e[33m     /  \     \e[0m| || |\e[33m|_   \|_   _| \e[0m| || |\e[33m |_  ||_  _|  \e[0m| || |\e[33m |_   ___  |  \e[0m| |
        | |\e[33m   | |   `. \ \e[0m| || |\e[33m    / /\ \    \e[0m| || |\e[33m  |   \ | |   \e[0m| || |\e[33m   | |_/ /    \e[0m| || |\e[33m   | |_  \_|  \e[0m| |
        | |\e[33m   | |    | | \e[0m| || |\e[33m   / ____ \   \e[0m| || |\e[33m  | |\ \| |   \e[0m| || |\e[33m   |  __'.    \e[0m| || |\e[33m   |  _|  _   \e[0m| |
        | |\e[33m  _| |___.' / \e[0m| || |\e[33m _/ /    \ \_ \e[0m| || |\e[33m _| |_\   |_  \e[0m| || |\e[33m  _| |  \ \_  \e[0m| || |\e[33m  _| |___/ |  \e[0m| |
        | |\e[33m |________.'  \e[0m| || |\e[33m|____|  |____|\e[0m| || |\e[33m|_____|\____| \e[0m| || |\e[33m |____||____| \e[0m| || |\e[33m |_________|  \e[0m| |
        | |\e[33m              \e[0m| || |\e[33m              \e[0m| || |\e[33m              \e[0m| || |\e[33m              \e[0m| || |\e[33m              \e[0m| |
        | \e[37m'--------------'\e[0m || \e[37m'--------------'\e[0m || \e[37m'--------------'\e[0m || \e[37m'--------------'\e[0m || \e[37m'--------------'\e[0m |
         \e[37m'----------------'\e[0m  \e[37m'----------------'\e[0m  \e[37m'----------------'\e[0m  \e[37m'----------------'\e[0m  \e[37m'----------------'\e[0m 
        ";

            // Regulärer Ausdruck für die Ersetzung von Escape-Sequenzen
            string pattern = @"\\e\[37m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[37m"); // Ersetze die Escape-Sequenz für die Farbe Weiß durch den entsprechenden ANSI-Code

            pattern = @"\\e\[33m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[33m"); // Ersetze die Escape-Sequenz für die Farbe Gelb durch den entsprechenden ANSI-Code

            pattern = @"\\e\[0m";
            ASCII = Regex.Replace(ASCII, pattern, "\x1b[0m"); // Ersetze die Escape-Sequenz für die Rückkehr zur Standardfarbe durch den entsprechenden ANSI-Code

            // Ausgabe der ASCII-Kunst
            Console.WriteLine(ASCII);
        }
    }
}