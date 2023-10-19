﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeilnehmerVerwaltung_v2
{
    internal class Program
    {
        /*
         * Implementieren Sie eine Applikation mit der beliebig viele Teilnehmerdaten 
         * erfasst und dargestellt werden können. 
         * Folgende Anforderung sollen dabei erfüllt werden:
                        
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
            int teilnehemrCount = 0;
            Teilnehmer teilnehmer = new Teilnehmer();
            Teilnehmer[] teilnehmerListe;
            string headerText = "Teilnehmer Verwaltung v2.0  ©2023 WIFI-Soft";

            //header ausgeben
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            //abfrage anzahl teilnehmer
            teilnehemrCount = ReadInt("Bite Anzahl Teilnehmer eingeben: ");

            teilnehmerListe = new Teilnehmer[teilnehemrCount];

            //teilnehmer daten; eingabe starten
            Console.WriteLine("Bitte geben Sie die Teilnehmer Daten ein: ");
            for (int i = 0; i < teilnehmerListe.Length; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i+1} / {teilnehmerListe.Length} : ");
                //Hint : Die GetStudentInfos() Metode kann auch überladen werden, damit eine ganze Liste 
                teilnehmerListe[i] = GetStudentInfos();
            }

            //ausgabe der daten
            Console.WriteLine("\nDie TeilnehmerDaten:\n");
            DisplayStudentInfo(teilnehmerListe);

            //TODO: Implent JSON and XML format too!!
            SaveStudenInfosToFile(teilnehmerListe, "meineTeilnehmerDaten.csv");
        }

        private static void SaveStudenInfosToFile(Teilnehmer[] teilnehmerListe, string filename)
        {
            //TODO: wie funktionieret StreamReader?
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                for (int i = 0; i < students.Length; i++)
                {
                    string dataLine = $"{students[i].Name}, {students[i].Nachname}, {students[i].Geburtsdatum}, {students[i].Plz},{students[i].Ort},";
                    sw.WriteLine(dataLine);
                }
            }
            
        }

        private static Teilnehmer GetStudentInfos()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Name = ReadString("\tVorname: ");
            teilnehmer.Nachname = ReadString("\tNachname: ");
            teilnehmer.Geburtsdatum = ReadDateTime("\tGeburtsdatum: ");  //eingabe geburtsdatum => Methode weil komplex            
            teilnehmer.Plz = ReadInt("\tPLZ: ");  //eingabe PLZ => Methode weil komplex
            teilnehmer.Ort = ReadString("\tWohnort: ");

            return teilnehmer;
        }

        private static void DisplayStudentInfo(Teilnehmer studentInfo)
        {
            for(int i = 0; i < studentInfo.lenght; i++)
            {
                DisplayStudentInfo(studentInfo[i]);
            }

            
        }

        private static string ReadString(string inputPrompt)
        {
            string input = string.Empty;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        private static int ReadInt(string inputPrompt)
        {
            string input = string.Empty;
            int inputValue = 0;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    inputValue = int.Parse(input);
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

        private static DateTime ReadDateTime(string inputPrompt)
        {
            string input = string.Empty;
            DateTime inputDateTime = DateTime.MinValue;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);                
                input = Console.ReadLine();
                
                try
                {
                    inputDateTime = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
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

        private static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
        {
            int xTitelPos = 0;

            //soll der bildschirm gelöscht werden?
            if (clearScreen)
            {
                Console.Clear();
            }

            //Darstellung Programm Header            
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (headerText.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = headerTextColor;
            Console.Write(" " + headerText + " ");
            Console.ForegroundColor = oldColor;

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = headerText;
        }
    }
}
