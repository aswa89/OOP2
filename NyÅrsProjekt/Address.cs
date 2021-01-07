using System;
using System.Collections.Generic;
using System.Text;

namespace NyÅrsProjekt
{
    /// <summary>
    /// Address information for PostOffices and Persons
    /// </summary>
    class Address
    {
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public override string ToString()
        {
            string s = $"{Street} {StreetNumber} ";

            if (ApartmentNumber != 0)
            {
                s += $"({ApartmentNumber}) ";
            }

            s += $"{ZipCode} {City} ({Province})";

            return s;
        }
    }
}
