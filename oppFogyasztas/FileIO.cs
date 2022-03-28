using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace oppFogyasztas
{
    class FileIO
    {
        public static List<Consumption> Read(string fileName)
        {
            List<Consumption> consumptions = new List<Consumption>();
            try
            {
                StreamReader read = new StreamReader(fileName);
                read.ReadLine();
                while (!read.EndOfStream)
                {
                    consumptions.Add(new Consumption(read.ReadLine()));
                }
                read.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba a fájl olvasása közben.");
            }

            return consumptions;
        }

        public static void Write(string filename, string data) 
        {
            try
            {
                StreamWriter write = new StreamWriter(filename, true);
                write.WriteLine(data);
                write.Close();

            }
            catch (IOException)
            {

                Console.WriteLine("Hiba a file írása közben.");
            }        
        }
    }
}
