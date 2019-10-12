using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivClass
{
    [TestClass]
    public class TestCorporation
    {
        #region Privates Attributes
        private Corporation _corporation;
        private string _name;
        private string _productionType;
        private int _yield;
        #endregion Privates Attributes

        [TestInitialize]
        public void Init()
        {
            _name = "Armurerie";
            _productionType = "Armes";
            _yield = 3;
            _corporation = new Corporation(_name, _productionType, _yield);
        }
        [TestMethod]
        public void TestGetName()
        {
            Assert.AreEqual(_name, _corporation.Name);
        }
        
        [TestMethod]
        public void TestGetProductionType()
        {
            Assert.AreEqual(_productionType, _corporation.ProductionType);
        }

        [TestMethod]
       public void TestGetYield()
        {
            Assert.AreEqual(_yield, _corporation.Yield);
        }
        [TestMethod]
        public void TestSetYield()
        {
            this._yield = 2;
            _corporation.Yield = _yield;
            Assert.AreEqual(_yield, _corporation.Yield);
        }
    }
}
