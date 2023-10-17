using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilnehmerverwaltung_V2
{
    internal class Program
    {
        /*
         * Implementieren Sie eine Applikation mit der beliebig viele Teilnehmerdaten 
         * erfasst und dargestellt werden können. 
         * Folgende Anforderung sollen dabei erfüllt werden:

         * max. Anzahl der Teilnehmer soll zu Beginn vom User befragt werden
        - Einlesen folgender Daten:
            - Name, Vorname
            - Geburtsdatum
            - PLZ, Ort
        - Fehlertolerante Eingaben
        - verwenden sie Methoden wo sinnvoll
        - verwenden sie Farben
        - Teilnehmerdaten sollen nach der Eingabe tabellarisch ausgegeben werden
        *
         * */
        static void Main(string[] args)
        {
            Teilnehmer teilnehmer = new Teilnehmer();
            string headerText = "Teilnehmer Verwaltung v2.0 02023 WIFI_Soft";


            CreatHeader(headerText, ConsoleColor.Yellow, true);

            Console.WriteLine("Bitte geben Sie die Teilnehemr Daten ein : ");

            teilnehmer = GetStudentsInfo();

            DispalyStudentInfo(teilnehmer);

            SaveStudentInfo(teilnehmer,"meineTeilnehemr.json")

        }

        

        private static Teilnehmer GetStudentsInfo()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Name = ReadString("\tVorname: ");
            teilnehmer.Nachname = ReadString("\tNachname:");
            teilnehmer.Geburtsdatumn = ReadDateTime("\tGeburtsdatun");
            teilnehmer.Plz = ReadInt("\tPLZ");
            teilnehmer.Ort = ReadString("\tWohnort:");

            return teilnehmer;
        }

        private static void DispalyStudentInfo(Teilnehmer studentInfo)
            )
        {
            Console.WriteLine("\nDie";
        }

        private static int ReadInt(string inputPromt)
        {
            string input = string.Empty;
            int inputValue = 0;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPromt);
                input = Console.ReadLine();


                try
                {
                    inputDateTime = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Eingabe.");
                    inputValue = 0;
                    Console.ResetColor();
                    inputIsValid = false;
                }

            }
            while (!inputIsValid);

            return inputValue;
            
        }

        private static string ReadString(string inputPromt)
        {
            Console.Write(inputPromt);
            return string.Empty;
        }
        

        private static DateTime ReadDateTime(string inputPromt)
        {
            string input = string.Empty;
            DateTime inputDateTime = DateTime.MinValue;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPromt);
                input = Console.ReadLine();
                

                try
                {
                    inputDateTime = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Datumseingabe.");
                    inputDateTime = DateTime.MinValue;
                    Console.ResetColor();
                    inputIsValid = false;
                }

            }
            while (!inputIsValid);

            return inputDateTime;
        }

        private static void CreatHeader(string headerText, ConsoleColor, headerTextColor, bool, clearScreen)
        {
            int xTitelPos = 0;
            
            if(clearScreen)
            {
                Console.Clear();
            }



            //Darstellung Programm Header
            string titel = "Teilnehmer Verwaltung v1.0";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (headerText.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(" " + headerText + " ");
            ConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = headerTextTextcolor;
            Console.Write("" + headerText + " ");
            Console.ForegroundColor = oldColor;

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = titel;
        }

        
    }
}
