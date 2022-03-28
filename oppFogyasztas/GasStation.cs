using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppFogyasztas
{
    class GasStation
    {
        public string Name { get; set; }
        public int Counter { get; set; }
        public GasStation(string name)
        {
            Name = name;
            Counter = 1;
        }
    }
}
