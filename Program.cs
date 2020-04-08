using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2019MajusTantargyFelosztasEmelt
{
    class Tan
    {
        public string TanarNeve { get; set; }
        public string TantargyNeve { get; set; }
        public string Osztaly { get; set; }
        public int OrakSzama { get; set; }

        public Tan(string tanuloNeve, string tantargyNeve, string osztaly, int orakSzama)
        {
            this.TanarNeve = tanuloNeve;
            this.TantargyNeve = tantargyNeve;
            this.Osztaly = osztaly;
            this.OrakSzama = orakSzama;
        }
    }
    class Program
    {
        static List<Tan> Adat = new List<Tan>();
        static Tan tan;
        static void Main(string[] args)
        {
            ElsoFeladat();
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();

            Console.ReadKey();
        }

        #region 7. Feladat
        private static void HetedikFeladat() => Console.WriteLine($"7. feladat\nAz iskolában {Adat.Select(x => x.TanarNeve).Distinct().Count()} tanár van.");
        #endregion
        #region 6. Feladat
        private static void HatodikFeladat()
        {
            Console.WriteLine("6. feladat");

            Console.Write("Osztály= ");
            string megadottOsztaly = Console.ReadLine();

            Console.Write("Tantárgy=");
            string megadottTantargyNeve = Console.ReadLine();

            int csoportos = 0;

            for (int i = 0; i < Adat.Count; i++)
            {
                if (megadottTantargyNeve == Adat[i].TantargyNeve && megadottOsztaly == Adat[i].Osztaly)
                {
                    csoportos++;
                }
            }

            string isCsoportosan = (csoportos > 1) ? "Csoportosbontásban tanulják.": "Nem csoportbontásban tanulják.";

            Console.WriteLine(isCsoportosan);
        }
        #endregion
        #region 5. Feladat

        private static void OtodikFeladat()
        {
            FileStream of = new FileStream(@"of.txt", FileMode.Create);
            StreamWriter kiOf = new StreamWriter(of, Encoding.UTF8);

            for (int i = 0; i < Adat.Count; i++)
            {
                if (Adat[i].TantargyNeve == "osztalyfonoki")
                {
                    kiOf.WriteLine($"{Adat[i].Osztaly} - {Adat[i].TanarNeve}");
                    kiOf.Flush();
                }
            }

            kiOf.Close();
            of.Close();
        }
        #endregion
        #region 4. Feladat

        private static void NegyedikFeladat()
        {
            Console.WriteLine("4. feladat");
            Console.Write("Egy tanár neve= ");
            string egyTanarNeve = Console.ReadLine();

            int orakSzama = 0;

            for (int i = 0; i < Adat.Count; i++)
            {
                if (egyTanarNeve == Adat[i].TanarNeve)
                    orakSzama += Adat[i].OrakSzama;
            }

            Console.WriteLine($"A tanár heti óraszáma: {orakSzama}");
        }
        #endregion
        #region 3. Feladat
        private static void HarmadikFeladat() => Console.WriteLine($"3. feladat\nAz iskolában a heti összóraszám: {Adat.Sum(x => x.OrakSzama)}");
        #endregion
        #region 2. Feladat

        private static void MasodikFeladat() => Console.WriteLine($"2. feladat\nA fájlban {Adat.Count} feljegyzés van.");
        #endregion
        #region 1. Feladat

        private static void ElsoFeladat()
        {
            StreamReader sr = new StreamReader("beosztas.txt");

            while (!sr.EndOfStream)
            {
                string tanar = sr.ReadLine();
                string tantargy = sr.ReadLine();
                string osztaly = sr.ReadLine();
                int orakSzama = Convert.ToInt32(sr.ReadLine());

                tan = new Tan(tanar, tantargy, osztaly, orakSzama);

                Adat.Add(tan);
            }

            sr.Close();
        }
        #endregion
    }
}
