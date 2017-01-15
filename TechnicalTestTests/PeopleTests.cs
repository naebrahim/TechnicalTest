using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Tests
{
    [TestClass()]
    public class PeopleTests
    {
        /// <summary>
        /// Test the constructor with List argument
        /// </summary>
        [TestMethod()]
        public void PeopleTest()
        {
            var expectedData = InitData();

            People people = new People(expectedData);
            var actualData = people.ListOfPeople;

            Assert.IsTrue(expectedData.SequenceEqual(actualData, new PersonEqualityComparer()));
        }

        /// <summary>
        /// Test the constructor with filename argument
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void PeopleTest1()
        {
            People people = new People(String.Empty);
        }

        /// <summary>
        /// Test the constructor with filename argument
        /// </summary>
        [TestMethod()]
        public void PeopleTest2()
        {
            People people = new People(@"..\..\TestFiles\test.csv");
            var actualData = people.ListOfPeople;

            var expectedData = InitData();

            Assert.IsTrue(expectedData.SequenceEqual(actualData, new PersonEqualityComparer()));

        }

        /// <summary>
        /// Test to determine sorting of names
        /// </summary>
        [TestMethod()]
        public void GetSortedNamesByFrequencyTest()
        {
            // actual data
            var listOfPeople = InitData();
            People people = new People(listOfPeople);

            var actualData = people.GetSortedNamesByFrequency();

            Dictionary<string, int> expectedData = new Dictionary<string, int>
            {
                {"Nicole", 2},
                {"Anderson", 1},
                {"Anne", 1},
                {"Lillian", 1},
                {"Lopez", 1}
            };

            Assert.IsTrue(expectedData.SequenceEqual(actualData));
            //CollectionAssert.AreEquivalent((Dictionary<string, int>)inputDictionary, outputDictionary);
        }

        /// <summary>
        /// Test to determine of addresses
        /// </summary>
        [TestMethod()]
        public void GetSortedAddressesTest()
        {
            // actual data
            var testData = InitData();
            var people = new People(testData);
            List<Address> actualData = people.GetSortedAddresses();

            List<Address> expectedData = new List<Person>
            {
                new Person()
                {
                    FirstName = "Anne",
                    LastName = "Nicole",
                    Address = new Address() {StreetName = "Argyle Road", StreetNumber = 50},
                    PhoneNumber = "4101502"
                },
                new Person()
                {
                    FirstName = "Lillian",
                    LastName = "Anderson",
                    Address = new Address() {StreetName = "New Castle Point", StreetNumber = 2600},
                    PhoneNumber = "29384857"
                },
                new Person()
                {
                    FirstName = "Nicole",
                    LastName = "Lopez",
                    Address = new Address() {StreetName = "Scofield Road", StreetNumber = 5},
                    PhoneNumber = "7719513"
                }

            }.Select(p => p.Address).ToList();

            Assert.IsTrue(expectedData.SequenceEqual(actualData, new AddressEqualityComparer()));
        }

        public string ToAssertableString(IDictionary<string, int> dictionary)
        {
            var pairStrings = //dictionary.OrderBy(p => p.Key)
                                dictionary.Select(p => p.Key + ": " + string.Join(", ", p.Value));
            return string.Join("; ", pairStrings);
        }

        private static List<Person> InitData()
        {
            List<Person> listOfPeople = new List<Person>
            {
                new Person()
                {
                    FirstName = "Lillian",
                    LastName = "Anderson",
                    Address = new Address() {StreetName = "New Castle Point", StreetNumber = 2600},
                    PhoneNumber = "29384857"
                },
                new Person()
                {
                    FirstName = "Nicole",
                    LastName = "Lopez",
                    Address = new Address() {StreetName = "Scofield Road", StreetNumber = 5},
                    PhoneNumber = "7719513"
                },
                new Person()
                {
                    FirstName = "Anne",
                    LastName = "Nicole",
                    Address = new Address() {StreetName = "Argyle Road", StreetNumber = 50},
                    PhoneNumber = "4101502"
                }
            };
            return listOfPeople;
        }


        public class AddressEqualityComparer : IEqualityComparer<Address>
        {
            public bool Equals(Address x, Address y)
            {
                if (object.ReferenceEquals(x, y)) return true;

                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

                return x.FullAddress.Equals(y.FullAddress);
            }

            public int GetHashCode(Address obj)
            {
                if (object.ReferenceEquals(obj, null)) return 0;

                int hashCodeName = obj.FullAddress?.GetHashCode() ?? 0;
                int hasCodeAge = obj.FullAddress.GetHashCode();

                return hashCodeName ^ hasCodeAge;
            }
        }

        public class PersonEqualityComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                if (object.ReferenceEquals(x, y)) return true;

                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;


                return x.FirstName.Equals(y.FirstName) && x.LastName.Equals(y.LastName) && x.PhoneNumber.Equals(y.PhoneNumber) && x.Address.FullAddress.Equals(y.Address.FullAddress);
            }

            public int GetHashCode(Person obj)
            {
                if (object.ReferenceEquals(obj, null)) return 0;

                int hashCodeFirstName = obj.FirstName?.GetHashCode() ?? 0;
                int hashCodeLastName = obj.LastName?.GetHashCode() ?? 0;
                int hashCodePhoneNumber = obj.PhoneNumber?.GetHashCode() ?? 0;
                int hashCodeAddress = obj.Address?.GetHashCode() ?? 0;


                return hashCodeFirstName ^ hashCodeLastName ^ hashCodePhoneNumber ^ hashCodeAddress;
            }
        }

    }



}