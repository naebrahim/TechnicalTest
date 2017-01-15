using System;

namespace TechnicalTest
{
    /// <summary>
    /// Representation of Person's address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Street number portion of Address
        /// </summary>
        public int StreetNumber { get; set; }

        /// <summary>
        /// Street name portion of Address
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Full address (StreetNumber + Streetname) 
        /// </summary>
        public string FullAddress => string.Concat(StreetNumber, " ", StreetName);

    }
}