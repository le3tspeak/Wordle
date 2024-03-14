namespace Wordle
{
    // Die Klasse Test enthält Hilfsmethoden zum Testen von Zeichenfolgen.
    internal class Test
    {
        // Überprüft, ob die Eingabe Zahlen enthält.
        internal static bool EnthältZahlen(string eingabe)
        {
            foreach (char c in eingabe)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        // Überprüft, ob die Eingabe Sonderzeichen enthält.
        internal static bool EnthältSonderzeichen(string eingabe)
        {
            foreach (char c in eingabe)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }
            return false;
        }

        // Überprüft, ob die Eingabe null oder Leerzeichen enthält.
        internal static bool NullOrWhiteSpace(string eingabe)
        {
            return (String.IsNullOrWhiteSpace(eingabe));
        }
    }
}
