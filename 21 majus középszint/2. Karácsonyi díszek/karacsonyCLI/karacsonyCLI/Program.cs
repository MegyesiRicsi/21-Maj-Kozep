using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace karacsonyCLI
{
    class NapiMunka
    {
        public static int KeszultDb { get; private set; }
        public int Nap { get; private set; }
        public int HarangKesz { get; private set; }
        public int HarangEladott { get; private set; }
        public int AngyalkaKesz { get; private set; }
        public int AngyalkaEladott { get; private set; }
        public int FenyofaKesz { get; private set; }
        public int FenyofaEladott { get; private set; }

        public NapiMunka(string sor)
        {
            string[] s = sor.Split(';');
            Nap = Convert.ToInt32(s[0]);
            HarangKesz = Convert.ToInt32(s[1]);
            HarangEladott = Convert.ToInt32(s[2]);
            AngyalkaKesz = Convert.ToInt32(s[3]);
            AngyalkaEladott = Convert.ToInt32(s[4]);
            FenyofaKesz = Convert.ToInt32(s[5]);
            FenyofaEladott = Convert.ToInt32(s[6]);

            NapiMunka.KeszultDb += HarangKesz + AngyalkaKesz + FenyofaKesz;
        }

        public int NapiBevetel()
        {
            return -(HarangEladott * 1000 + AngyalkaEladott * 1350 + FenyofaEladott * 1500);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<NapiMunka>();
            var sr = new StreamReader("diszek.txt");
            while (!sr.EndOfStream)
            {
                lista.Add(new NapiMunka(sr.ReadLine()));
            }
            var ossz = (from sor in lista 
                        select sor.AngyalkaKesz+sor.FenyofaKesz+sor.HarangKesz);
            Console.WriteLine($"4.feladat: Összesen {ossz.Sum()} darab dísz készült.");
            bool volte = false;
            foreach (var item in ossz)
            {
                if (item==0)
                {
                    volte = true;
                    break;
                }
            }
            if (volte)
            {
                Console.WriteLine("5. feladat: Volt olyan nap, amikor egyetlen dísz sem készült");
            }
            else
            {
                Console.WriteLine("5. feladat: Nem volt olyan nap, amikor egyetlen dísz sem készült");
            }

            int nap = 0;
            do
            {
                Console.Write("\nAdja meg a keresett napot [1 ... 40]: ");
                nap = int.Parse(Console.ReadLine());
            } while (nap > 40 || nap<1);
            var megadott = (from sor in lista where sor.Nap == nap select sor);
            int maradtA = 0;
            int maradtF = 0;
            int maradtH = 0;
            foreach (var item in lista)
            {
                if (item.Nap<16)
                {
                    maradtA = maradtA + item.AngyalkaKesz + item.AngyalkaEladott;
                    maradtF = maradtF + item.FenyofaKesz + item.FenyofaEladott;
                    maradtH = maradtH + item.HarangKesz + item.HarangEladott;
                }
               
               
            }
            Console.WriteLine($"A(z) {nap} végé {maradtH} harang, {maradtA} angyalka és {maradtF} fenyőfa maradt készleten.");
            
            
            Console.ReadKey();
        }
    }
}
