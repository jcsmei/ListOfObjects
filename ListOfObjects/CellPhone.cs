using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfObjects
{
    class CellPhone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string PhoneInfo()
        {
            return Brand + " " + Model + ": " + Price.ToString("c2");
        }
    }
}
