using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppFogyasztas
{
    class Program
    {
        static List<Consumption> consumptions = FileIO.Read("fogyasztas.txt");
        static void Main(string[] args)
        {
            Task1();
            Task2();
            //Task3();
            Task4();
            Task5();

            Console.ReadKey();
        }

        private static void Task5()
        {
            /* Kérjük be az új tankolás adatait és ezt mentsük el a tankolás.txt fileba az utolsó sorba. */
            Console.WriteLine("5. Feladat");
            string[] fields = new string[] { "dátum", "távolság (km)", "mennyiség (liter)", "fizetett összeg", "benzinkút" };
            string newData = "";
            for (int i = 0; i < fields.Length; i++)
            {
                newData += DataImport(fields[i])+";";
            }

            newData = newData.Substring(0, newData.Length - 1);
            consumptions.Add(new Consumption(newData));
            FileIO.Write("fogyasztas.txt", newData);
            

        }

        private static string DataImport(string field)
        {
            Console.Write($"\t{field}: ");
            return Console.ReadLine();

        }

        private static void Task4()
        {
            /* Határozzuk meg melyik benzimkúton hányszor tankoltunk,
             * ha a benzinkút azonosítója NA, akkor nincs adat, tehát azt a kutat ne nézzük
             * A benzinkuatakat a tankolás száma szeirnt növekvő sorrendben írjuk ki
             */
            Console.WriteLine("4. feladat.");
            List<GasStation> gasStations = new List<GasStation>();
            for (int i = 0; i < consumptions.Count; i++)
            {
                if (consumptions[i].GasStationID != "NA")
                {
                    gasStations = Set(gasStations, consumptions[i].GasStationID);
                }
            }
            gasStations = gasStations.OrderByDescending(x => x.Counter).ToList();
            for (int i = 0; i < gasStations.Count; i++)
            {
                Console.WriteLine($"\t{gasStations[i].Name} : {gasStations[i].Counter} db.");
            }
        }

        private static List<GasStation> Set(List<GasStation> gasStations, string gasStationID)
        {
            for (int i = 0; i < gasStations.Count; i++)
            {
                if (gasStations[i].Name == gasStationID)
                {
                    gasStations[i].Counter++;
                    return gasStations;
                }
            }
            gasStations.Add(new GasStation(gasStationID));
            return gasStations;
        }

        private static void Task3()
        {
            /* Kérjünk be két dátumot a felhasználótól és határozzuk meg hány alkalommal tankoltunk a két időpont között */
            Console.WriteLine($"3. Feladat: ");
            Console.Write("\tKérem az első dátumot (éééé.hh.nn)");
            DateTime firstdate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\tKérem a második dátumot (éééé.hh.nn)");
            DateTime seconddate = Convert.ToDateTime(Console.ReadLine());
            List<Consumption> temp = consumptions.FindAll(x => x.Date >= firstdate && x.Date <= seconddate);
            Console.WriteLine($"A viszgált időszakban {temp.Count} db. tankolás volt.");
        }

        private static void Task2()
        {
            /* Határozzuk meg annak a tankolásnak az időpontját amikor a legdrágább volt az üzemanyag egység ára és az árát is írjuk ki*/
            double maxPrice = consumptions.Max(x => x.UnitPrice);
            DateTime date = consumptions.Find(x=> x.UnitPrice == maxPrice).Date;
            Console.WriteLine($"2. feladat: Legmagassab ár: {maxPrice: 0.00} ft/l, dátum {date.ToShortDateString()}");
        }

        private static void Task1()
        {
            /* határozzuk meg a vizsgált időszakban mennyi volt az átlag fogyasztás 100km-re levetítve */
            double allliter = consumptions.Sum(x => x.FuelQuantity);
            double allldistance = consumptions.Sum(x => x.Distance);
            Console.WriteLine($"Átlag fogyazstás {allliter / allldistance * 100: 0.00} liter.");
        }
    }
}
