using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201130
{
    struct Kategoria
    {
        public string Nev;
        public int Tulelok;
        public int Eltuntek;

        public Kategoria(string sor)
        {
            var t = sor.Split(';');
            Nev = t[0];
            Tulelok = int.Parse(t[1]);
            Eltuntek = int.Parse(t[2]);
        }
    }

    class Program
    {
        static List<Kategoria> kategoriak = new List<Kategoria>();
        static void Main(string[] args)
        {
            F01();
            F02();
            F03();
            F04();
            F06();
            F07();
            Console.ReadKey(true);
        }

        private static void F07()
        {
            int maxi = 0;
            for (int i = 1; i < kategoriak.Count; i++)
            {
                if (kategoriak[i].Tulelok > kategoriak[maxi].Tulelok)
                    maxi = i;
            }
            Console.WriteLine($"7. feladat: {kategoriak[maxi].Nev}");
        }

        private static void F06()
        {
            Console.WriteLine("6. feladat:");
            foreach (var k in kategoriak)
            {
                if (k.Eltuntek > (k.Eltuntek + k.Tulelok) * .6F)
                    Console.WriteLine($"\t{k.Nev}");
            }
        }

        private static void F04()
        {

            Console.Write("4. feladat: kulcsszó: ");
            var kulcsszo = Console.ReadLine();

            int i = 0;

            while (i < kategoriak.Count && !kategoriak[i].Nev.Contains(kulcsszo))
            {
                i++;
            }

            if(i < kategoriak.Count)
            {
                Console.WriteLine("\tVan találat!");
                F05(kulcsszo);
            }
            else Console.WriteLine("\tNincs találat!");


        }

        private static void F05(string kulcsszo)
        {
            Console.WriteLine("5. feladat:");
            foreach (var k in kategoriak)
            {
                if(k.Nev.Contains(kulcsszo))
                    Console.WriteLine($"\t{k.Nev} {k.Tulelok + k.Eltuntek} fő");
            }
        }

        private static void F03()
        {
            int sum = 0;
            foreach (var k in kategoriak)
            {
                sum += k.Tulelok + k.Eltuntek;
            }
            Console.WriteLine($"3. feladat {sum} fő");
        }

        private static void F02()
        {
            Console.WriteLine($"2. feladat: {kategoriak.Count} db");
        }

        private static void F01()
        {
            var sr = new StreamReader(@"..\..\Res\titanic.txt");

            while (!sr.EndOfStream)
            {
                kategoriak.Add(new Kategoria(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
