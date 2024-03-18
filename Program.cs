using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordle
{
    // Die Hauptklasse des Programms.
    class Program
    {
        // Der Einstiegspunkt des Programms.
        static void Main(string[] args)
        {
            Menu menu = new Menu();                 // Instanziierung des WordleSpielMenüs-Objekts.
            menu.StartMenu();                       // Aufruf der Startmethode des Menüs.
        }
    }
}
