using System.Linq;
using CsvHelper.Configuration;

namespace TechnicalTest
{
    /// <summary>
    /// Inherited class to map Address object for CSV lib
    /// </summary>
    public sealed class AddressMap : CsvClassMap<Address>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressMap()
        {
            Map(m => m.StreetNumber).ConvertUsing(row => int.Parse(row.GetField<string>("Address").Split()[0]));
            Map(m => m.StreetName).ConvertUsing(row => string.Join(" ", row.GetField<string>("Address").Split().Skip(1)));
        }
    }

}