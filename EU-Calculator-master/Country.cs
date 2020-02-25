using System;
using System.Collections.Generic;
using System.Text;

namespace EUCalculator
{
    class Country
    {
        public string CountryName { get; set; }
        public int Vote { get; set; } 
        public double Percentage { get; set; }
        public Country(string CountryName, double Percentage)
        {
            this.CountryName = CountryName;
            this.Percentage = Percentage;

        }



    }
}
