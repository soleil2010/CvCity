using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivClass
{
    public class CvCity
    {
        #region Private Attributes
        private string _name;
        private int _population;
        private int _happiness;
        private int _unhappiness;
        private List<Corporation> _listCorporation;
        #endregion Private Attributes

        #region Constructor
        /// <summary>
        /// Construct the object CvCity
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="population">Nombre de citoyen</param>
        /// <param name="happiness">Nombre de citoyen heureux</param>
        /// <param name="unhappiness">nombre de citoyen malheureux</param>
        public CvCity(string name, int population)
        {
            this._name = name;
            this._population = population;
            this._happiness = this._population;
            this._unhappiness = 0;
        }
        #endregion Constructor

        #region public methods
        /// <summary>
        /// Ajoute une corporation à la ville
        /// </summary>
        /// <param name="corporation"></param>
        public void NewCorporation(Corporation corporation)
        {
            if (_listCorporation == null) //vérifie que la liste soit vide
            {
                this._listCorporation = new List<Corporation>();
            }
            _listCorporation.Add(corporation);
            this.PublicOpinion(); //appelle la méthode
        }
        #endregion public methods

        #region private methods
        /// <summary>
        /// - Calcul the happiness depending of the number of corporation and their yields
        /// - Calcul the unhapiness depending of the number of corporation and their yields
        /// </summary>
        /// <param name="yield"></param>
        private void PublicOpinion()
        {
            int amountYield = 0;
            foreach (Corporation corporation in _listCorporation)
            {
                amountYield = corporation.Yield + amountYield;
            }
            double calculTemp = this._population * ((5.0 / 100) * amountYield);
            this._unhappiness = Convert.ToInt32(Math.Round(calculTemp, MidpointRounding.AwayFromZero));
            this._happiness = this._population - this._unhappiness;
        }
        #endregion private methods

        #region Accessors
        /// <summary>
        /// Retourne le nom de la ville ou permet de le changer
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
        /// Permet de retourner ou changer le nombre de citoyen
        /// </summary>
        public int Population
        {
            get
            {
                return this._population;
            }
            set
            {
                this._population = value;
            }
        }
        /// <summary>
        /// Permet de retourner le nombre d'habitant heureux
        /// </summary>
        public int Happiness
        {
            get
            {
                return this._happiness;
            }
        }
        /// <summary>
        /// Permet de retourner le nombre d'habitant malheureux
        /// </summary>
        public int Unhappiness
        {
            get
            {
                return this._unhappiness;
            }
        }
        public List<Corporation> ListCorporation
        {
            get
            {
                return this._listCorporation;
            }
        }
        #endregion Accessors
    }
}
