using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppFogyasztas
{
    class Consumption
    {
        public DateTime Date { get; set; }
        public double Distance { get; set; }
        public double FuelQuantity { get; set; }
        public int Price { get; set; }
        public string GasStationID { get; set; }
        public double UnitPrice { get; set; }
        public Consumption(string row)
        {
            Date = Convert.ToDateTime(row.Split(';')[0]);
            Distance = Convert.ToDouble(row.Split(';')[1]);
            FuelQuantity = Convert.ToDouble(row.Split(';')[2]);
            Price = Convert.ToInt32(row.Split(';')[3]);
            GasStationID = row.Split(';')[4];
            UnitPrice = Price / FuelQuantity;

        }

    }
}
