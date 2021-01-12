using System;
using System.Collections.Generic;
using System.Text;

namespace NyÅrsProjekt
{
    /// <summary>
    /// Package information: dimensions, shipping id, receiver & sender
    /// Retrieves data from the database
    /// </summary>
    class Package
    { 
        public int Id { get; set; }
        public int Weight { get; set; } // g
        public int Width { get; set; } // mm
        public int Height { get; set; } // mm
        public int Length { get; set; } // mm
        public PersonAddress Receiver { get; set; }
        public PersonAddress Sender { get; set; }

        public int Volume // mm^3
        {
            get
            {
                return (Width * Length) * Height;
            }
        }
        
        /// <summary>
        /// This method validates the given dimensions
        /// </summary>
        /// <returns>True or false</returns>
        public bool ValidateDimensions()
        {
            return true;
            return 140 <= Length && Length <= 1500
                && 90 <= Width
                && 15 <= Height
                && Length + Width + Height <= 3000
                && Weight <= 50000;
        }

        /// <summary>
        /// Calculated price according to weight
        /// </summary>
        /// <returns>Price of shipping</returns>
        public int Price
        {
            get
            {
                // bool extraPrice = Length + Width + Height > 2000;
                if (Weight <= 3)
                {
                    return 140;
                }
                else if (Weight <= 5)
                {
                    return 167;
                }
                else if (Weight <= 10)
                {
                    return 212;
                }
                else if (Weight <= 15)
                {
                    return 258;
                }
                else if (Weight <= 20)
                {
                    return 298;
                }
                else // Weight > 20
                {
                    return 350; // Påhitt
                }
            }
        }
    }
}
