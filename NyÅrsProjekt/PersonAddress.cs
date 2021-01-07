using System;
using System.Collections.Generic;
using System.Text;

namespace NyÅrsProjekt
{
    /// <summary>
    /// This class can access sender/receiver information
    /// </summary>
    class PersonAddress
    {
        public string Name { get; set; }
        public string CareOf { get; set; }
        public Address Address { get; set; }
    }
}
