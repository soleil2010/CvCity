using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivClass

{
    public class Corporation
    {
        #region Attributes
        private string _name;
        private string _productionType;
        private int _yield;
        #endregion Attributes
        
        #region Constructor
        /// <summary>
        /// Construit l'objet Corporation2
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="productionType">Type de production</param>
        /// <param name="yield">Output de la ville(nombre produit)</param>
        public Corporation(string name, string productionType, int yield)
        {
            this._name = name;
            this._productionType = productionType;
            this._yield = yield;
        }
        #endregion Constructor
        #region Accessors
        /// <summary>
        /// Nom de la corporation
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }
        /// <summary>
        /// Type de production
        /// </summary>
        public string ProductionType
        {
            get
            {
                return this._productionType;
            }
        }
        /// <summary>
        /// Output de la ville (nombre produit)
        /// </summary>
        public int Yield
        {
            get
            {
                return this._yield;
            }
            set
            {
                this._yield = value;
            }
        }
        #endregion Accessors
    }
}
