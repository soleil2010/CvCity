using System;
using System.Collections.Generic;
using System.Text;

namespace CivClass
{
    public class Country
    {
        #region Private Attributes
        private string _name;
        private int _numCitizen;
        private int _countryHappiness;
        private int _countryUnHappiness;
        private List<CvCity> _listCvCity;
        #endregion Private Attributes

        #region Constructor
        /// <summary>
        /// Construction of the object Country
        /// </summary>
        /// <param name="name">Name of the country</param>
        public Country(string name)
        {
            this._name = name;
            CalculateInformations();
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Check if there is already a list of city
        /// Add a new list if there is no list
        /// Add a city to the list
        /// </summary>
        /// <param name="cvCity"></param>
        public void NewCvCity(CvCity cvCity)
        {
            if (_listCvCity == null)
            {
                this._listCvCity = new List<CvCity>();
            }
            _listCvCity.Add(cvCity);
            CalculateInformations();
        }

        public void RemoveCvCity(CvCity cvCity)
        {
            if (_listCvCity != null)
            {
                _listCvCity.Remove(cvCity);
            }
            CalculateInformations();
        }

        private void CalculateInformations()
        {
            this.TotalCitizen();
            this.TotalHappiness();
            this.TotalUnhappiness();
        }
        /// <summary>
        /// Update the total number of citizen in the country
        /// </summary>
        private void TotalCitizen()
        {
            _numCitizen = 0;
            if (_listCvCity != null)
            { 
                foreach (CvCity cvCity in _listCvCity)
                {
                    _numCitizen = _numCitizen + cvCity.Population;
                }
            }
        }
        /// <summary>
        /// Update the number total of happiness in the country
        /// </summary>
        private void TotalHappiness()
        {
            _countryHappiness = 0;
            if(_listCvCity!=null)
            {
                foreach (CvCity cvCity in _listCvCity)
                {
                    _countryHappiness = _countryHappiness + cvCity.Happiness;
                }
            }
        }
        /// <summary>
        /// Update the number of unhappiness in the country
        /// </summary>
        private void TotalUnhappiness()
        {
            _countryUnHappiness = 0;
            if (_listCvCity != null)
            {
                foreach (CvCity cvCity in _listCvCity)
                {
                    _countryUnHappiness = _countryUnHappiness + cvCity.Unhappiness;
                }
            }
        }
        #endregion Methods

        #region Accessors
        /// <summary>
        /// Return or set the name of the country
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                this._name = value;
            }
        }
        /// <summary>
        /// return the number of citizen of the country
        /// </summary>
        public int NumCitizen
        {
            get
            {
                return this._numCitizen;
            }
        }
        /// <summary>
        /// return cities of the country
        /// </summary>
        public List<CvCity> ListCvCity
        {
            get
            {
                return this._listCvCity;
            }
        }
        /// <summary>
        /// return the happiness of the country
        /// </summary>
        public int CountryHappiness
        {
            get
            {
                return this._countryHappiness;
            }
        }
        /// <summary>
        /// return the unhappiness of the country
        /// </summary>
        public int CountryUnHappiness
        {
            get
            {
                return this._countryUnHappiness;
            }
        }
        #endregion Accessors
    }
}
