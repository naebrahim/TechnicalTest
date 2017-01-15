using CsvHelper.Configuration;

namespace TechnicalTest
{
    /// <summary>
    /// Inherited class to map Person object for CSV lib
    /// </summary>
    public sealed class PersonMap : CsvClassMap<Person>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonMap()
        {
            Map(m => m.FirstName);
            Map(m => m.LastName);
            References<AddressMap>(m => m.Address);
            Map(m => m.PhoneNumber);
        }
    }
}