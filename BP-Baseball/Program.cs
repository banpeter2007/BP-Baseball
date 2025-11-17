using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_Baseball
{
    class Versenyzok
    {
        public string nev;
        public string dij;
        public int ev;
        public string liga;

        public Versenyzok(string n, string d, int e, string l)
        {
            nev = n;
            dij = d;
            ev = e;
            liga = l;
        }
    }
    internal class Program
    {
        #region fejlec
        static void fejlec()
        {
            /*
                BP - Baseball
                BP - 11.17.
            */

            Type type = typeof(Program);
            string namespaceName = type.Namespace;
            Console.WriteLine(namespaceName);
            for (int i = 0; i < namespaceName.Length; i++) Console.Write('-');
            Console.WriteLine();
        }
        #endregion
        static void Main(string[] args)
        {
            fejlec();

            string sor;
            string[] reszek;
            StreamReader be = new StreamReader("dijak.csv");
            List<Versenyzok> versenyzok= new List<Versenyzok>();
            be.ReadLine();
            sor = be.ReadLine();
            while (sor != null)
            {
                reszek = sor.Split(';');
                try
                {
                    string nev = reszek[0];
                    string dij = reszek[1];
                    int ev = Convert.ToInt32(reszek[2]);
                    string liga = reszek[3];
                    Versenyzok versenyzok_uj = new Versenyzok(nev, dij, ev, liga);
                    versenyzok.Add(versenyzok_uj);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Hiba a sor feldolgozása közben: {sor}. Hibaüzenet: {ex.Message}");
                }
                sor = be.ReadLine();
            }

            be.Close();

            //3. feladat
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"2007 és 2010 között {versenyzok.Count()} díjat osztottak ki.");

            Console.WriteLine();

            //4. feladat
            Console.WriteLine("4. feladat:");
            Console.Write("Kérem a játékos nevét: ");
            string benev = Console.ReadLine();

            Console.WriteLine();

            //5. feladat
            Console.WriteLine("5. feladat:");
            bool van = false;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].nev == benev)
                {
                    van = true;
                    Console.WriteLine($"név: {versenyzok[i].nev}");
                    Console.WriteLine($"díj: {versenyzok[i].dij}");
                    Console.WriteLine($"év: {versenyzok[i].ev}");
                    break;
                }
            }

            if (van == false)
                Console.WriteLine("Nincs ilyen nevű játékos!");

            Console.WriteLine();

            //6. feladat
            Console.WriteLine("6. feladat:");
            List<string> kaptak = new List<string>();

            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].dij == "Gold Glove" && versenyzok[i].ev == 2009)
                    kaptak.Add(versenyzok[i].nev);
            }

            foreach (string v in kaptak)
                Console.WriteLine(v);
            
            Console.WriteLine();
            Console.WriteLine("Kilépéshez nyomja meg az ENTER billentyűt.");
            Console.ReadLine();
        }
    }
}
