using System;
using System.Collections.Generic;
using System.Text;

namespace NyÅrsProjekt
{
    /// <summary>
    /// Sender/receiver information for package
    /// </summary>
    class PersonAddress
    {
        public string Name { get; set; }
        public string CareOf { get; set; }
        public Address Address { get; set; }
    }
}
