using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DatenTypenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl; //==> Delaration

            zahl = 10; // ==> Intialisirung
            //zahl = zahl + 10;

            int counter = 3;   //==> Deklsrstion & Intialisierung
            


            Console.WriteLine(zahl);
            Console.WriteLine(counter);
            Console.WriteLine(" Counter: " + counter + " Max: " + int.MaxValue + " Min: " + int.MinValue);

            bool isPowerOn = false;

            Console.WriteLine(" power state : " + isPowerOn);
            Console.WriteLine($"power state : {isPowerOn} {counter} {zahl}");

            string name = "Gandalf";
            Console.WriteLine($"Name: {name} ");
            Console.WriteLine($"Länge : {name.Length} Zeichen ");
            counter = name.Length + 5;

            Console.WriteLine();

            name = "";
            name = string.Empty;

            double weight = 15.856;
            Console.WriteLine($"Gewicht : {weight} kg");

            decimal salary = 1564.32154m;
            Console.WriteLine($"Gehalt : € {salary}");



            
        }
    }
}
