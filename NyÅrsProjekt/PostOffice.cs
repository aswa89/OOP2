using System;
using System.Collections.Generic;
using System.Text;

namespace NyÅrsProjekt
{
    /// <summary>
    /// This class can access post office information from a database
    /// </summary>
    class PostOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Get all packages currently at this post office
        /// Requires route module implemented
        /// </summary>
        public List<Package> GetPackages()
        {
            throw new NotImplementedException();
        }
    }
}
