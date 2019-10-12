using System;
using System.Collections.Generic; //Permet de récupérer une librairie (collection générique, ici)
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivClass
{
    [TestClass]
    public class TestCountry
    {
        #region Private Attributes
        private Country _country;
        private CvCity _cvCity;
        private string _name;
        private int _numCitizen;
        private int _countryHappiness;
        private int _countryUnHappiness;
        private List<CvCity> _listCvCity;
        #endregion Private Attributes

        [TestInitialize]
        /// <summary>
        /// Initialize the object Country
        /// </summary>
        public void Init()
        {
            _name = "Germany";
            _country = new Country(_name);
            _cvCity = new CvCity("konigsberg", 30);
        }
        [TestMethod]
        ///<summary>
        ///Test when we add a new city in the country
        ///<summary>
        public void TestNewCvCity()
        {
            _listCvCity = new List<CvCity>();
            _listCvCity.Add(_cvCity);
            _country.NewCvCity(_cvCity);
            CollectionAssert.Equals(_listCvCity, _country.ListCvCity);
        }
        [TestMethod]
        ///<summary>
        ///Test when we remove a city in the country
        ///<summary>
        public void TestRemoveCvCity()
        {
            _listCvCity = new List<CvCity>();
            _country.NewCvCity(_cvCity);
            _country.RemoveCvCity(_cvCity);
            CollectionAssert.Equals(_listCvCity, _country.ListCvCity);
        }

        [TestMethod]
        ///<summary>
        ///Test number of citizen in the country
        ///</summary>
        public void TestTotalCitizen()
        {
            _numCitizen = 30;
            _country.NewCvCity(_cvCity);
            Assert.AreEqual(_numCitizen, _country.NumCitizen);
        }
        [TestMethod]
        ///<summary>
        ///Test Happiness
        ///</summary>
        public void TestTotalHappiness()
        {
            _countryHappiness = 30;
            _country.NewCvCity(_cvCity);
            Assert.AreEqual(_countryHappiness, _country.CountryHappiness);
        }

        [TestMethod]
        /// <summary>
        /// Test the unhappiness of the country
        /// </summary>
        public void TestTotalUnhappiness()
        {
            _countryUnHappiness = 5;
            _cvCity.NewCorporation(new Corporation("Armurerie", "Armes", 3));
            _country.NewCvCity(_cvCity);
            Assert.AreEqual(_countryUnHappiness, _country.CountryUnHappiness);
        }
        [TestMethod]
        ///<summary>
        ///
        ///</summary>
        public void TestListnumCvCity()
        {
            _listCvCity = new List<CvCity>();
            _listCvCity.Add(new CvCity("Berlin", 20));
            _country.NewCvCity(new CvCity("konigsberg", 30));
            CollectionAssert.Equals(_country.ListCvCity, _listCvCity);
        }

        [TestMethod]
        /// <summary>
        /// Test Accessor Name
        /// </summary>
        public void TestName()
        {
            Assert.AreEqual(_name, _country.Name);
        }

        [TestMethod]
        /// <summary>
        /// Test ListCvCity
        /// </summary>
        public void TestListCvCity()
        {
            //
            _listCvCity = new List<CvCity>();
            CvCity city = new CvCity("konigsberg", 30);
            _listCvCity.Add(city);

            _country.NewCvCity(_cvCity);
            List<CvCity> lstActual = _country.ListCvCity;
            Assert.IsTrue(AreEquivalent(_listCvCity, lstActual));
        }

        public bool AreEquivalent(List<CvCity> expected, List<CvCity> actual)
        {
            bool success = false;
            if (actual.Count == expected.Count)
            {
                int iCity = 0;
                foreach(CvCity city in actual)
                {
                    if (city.Happiness == expected[iCity].Happiness &&
                        city.Name == expected[iCity].Name &&
                        city.Population == expected[iCity].Population &&
                        city.Unhappiness == expected[iCity].Unhappiness
                       )
                    {
                        success = CorporationsAreEqual(expected[iCity].ListCorporation, city.ListCorporation);
                    }
                    if (!success)
                        break;

                    iCity++;
                }
            }
            return success;
        }

        public bool CorporationsAreEqual(List<Corporation> expected, List<Corporation> actual)
        {
            bool success = false;

            if (expected != null && actual != null)
            {
                if(expected.Count == actual.Count)
                {
                    int iCorp = 0;
                    foreach ( Corporation corp in actual)
                    {
                        if (corp.Name == expected[iCorp].Name &&
                           corp.ProductionType == expected[iCorp].ProductionType &&
                           corp.Yield == expected[iCorp].Yield
                          )
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                            break;
                        }
                        iCorp++;
                    }
                }
            }
            else if (expected == null && actual == null)
                success = true;

            return success;
        }
    }
}
