using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BspTeilnehmerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name = String.Empty;
            String vorname = string.Empty;
            DateTime geburtsDatum = DateTime.MinValue;
            String input = String.Empty;

            Console.Clear();
            //Header
            Console.WriteLine("Teilnehmer Daten eingeben:");

            //Eingabe der Daten
            Console.Write("\tVorname:");
            //Validierung des wertebereichs für Geburtsdatum (16 - 95)
            vorname = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\tName:");
            name = Console.ReadLine();

            Console.Write("\tGeburtsDatum:");
            input = Console.ReadLine();
            geburtsDatum = DateTime.Parse(input);
            try
            {
                geburtsDatum = DateTime.ParseExact(input, "dd-MM-yyyy" , CultureInfo.InvariantCulture);
            }
            catch 
            {
                Console.WriteLine("\aERROR: Ungültige Datumseingabe.");
                geburtsDatum = DateTime.MaxValue;
                
            }
            #endregion

            if (geburtsDatum.Year != DateTime.MinValue.Year)
            {
                return;
              

            }



            //Validierung des wertebereichs für Geburtsdatum (16 - 95)
            #region Validierung
            int alter = DateTime.Now.Year - geburtsDatum.Year;
            if (alter < 16 || alter >95)
            {
                Console.WriteLine("ERROR:\a Leider ist der Teilnehmer ausserhalb das gültiger alter")
            }
            //Ausgabe der Daten

        }
    }
}
