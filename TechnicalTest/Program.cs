using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace TechnicalTest
{

    class Program
    {
        static int Main(string[] args)
        {
            string filename;

            try
            {
                // get input file (fullpath) from command line or command prompt
                if (args.Length > 0)
                {
                    filename = Path.GetFullPath(args[0]);
                }
                else
                {
                    Console.Write("Enter input filename incl. path:");
                    filename = Console.ReadLine();
                }

                if (filename != null)
                {
                    // check if the file exists 
                    if (!File.Exists(filename))
                    {
                        Console.WriteLine("File does not exist. Please use a valid filename");
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid filename");
                    return 1;
                }

                // load data from the csv file
                var people = new People(filename);

                // get list of names sorted by frequency
                var frequencyPeopleNames = people.GetSortedNamesByFrequency();

                // get list of sorted addresses
                var peopleSortedByAddresses = people.GetSortedAddresses();

                // output lists to respective files
                using (StreamWriter sw = new StreamWriter(@"..\..\DataFiles\names.txt"))
                {
                    foreach (var name in frequencyPeopleNames)
                    {
                        sw.WriteLine("{0},{1}", name.Key, name.Value);
                    }
                }

                using (StreamWriter sw = new StreamWriter(@"..\..\DataFiles\addresses.txt"))
                {
                    foreach (var address in peopleSortedByAddresses)
                    {
                        sw.WriteLine("{0} {1}", address.StreetNumber, address.StreetName);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);
                return 1;
            }

            return 0;
        }
    }
}
