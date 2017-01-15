using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using CsvHelper;

namespace TechnicalTest
{
    /// <summary>
    /// Representation of a group of persons
    /// </summary>
    public class People
    {
        public List<Person> ListOfPeople { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="filename">Fullpath of file containing CSV data</param>
        public People(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                var csvReader = new CsvReader(sr);
                csvReader.Configuration.RegisterClassMap<PersonMap>();
                this.ListOfPeople = csvReader.GetRecords<Person>().ToList();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="persons">List of Person obejcts</param>
        public People(List<Person> persons)
        {
            this.ListOfPeople = persons;
        }

        /// <summary>
        /// Sorts list of names by frequency
        /// </summary>
        /// <returns>Dictionary containing name and associated frequency</returns>
        public Dictionary<string, int> GetSortedNamesByFrequency()
        {
            return
                       (ListOfPeople.Select(person => person.FirstName)).Concat(
                           ListOfPeople.Select(person => person.LastName))
                           .GroupBy(p => p)
                           .Select(ng => new { Count = ng.Count(), Name = ng.Key })
                           .OrderByDescending(c => c.Count)
                           .ThenBy(n => n.Name).ToDictionary(d => d.Name, d => d.Count);
        }

        /// <summary>
        /// Sorts addresses by street name
        /// </summary>
        /// <returns>List of Address obejcts in sorted order</returns>
        public List<Address> GetSortedAddresses()
        {
            return ListOfPeople.Select(person => person.Address).OrderBy(a => a.StreetName).ToList();
        }

    }


}