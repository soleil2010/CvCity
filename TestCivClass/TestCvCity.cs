using System;
using System.Collections.Generic; //Permet de récupérer une librairie (collection générique, ici)
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivClass
{
    [TestClass]
    public class TestCvCity
    {
        #region private Attributes
        private CvCity _cvCity;
        private string _name;
        private int _population;
        private int _happiness;
        private int _unhappiness;
        private List<Corporation> _listCorporation;
        #endregion private Attributes
        [TestInitialize]
        public void Init()
        {
            _population = 30;
            _name = "konigberg";
            _cvCity = new CvCity(_name, _population);

        }
        [TestMethod]
        public void TestUnhappiness()
        {
            this._unhappiness = 0;
            Assert.AreEqual(_unhappiness, _cvCity.Unhappiness);
        }
        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual(_name, _cvCity.Name);
        }
        [TestMethod]
        public void TestPopulation()
        {
            Assert.AreEqual(_population, _cvCity.Population);
        }
        [TestMethod]
        public void TestHappiness()
        {
            this._happiness = _population;
            Assert.AreEqual(_happiness, _cvCity.Happiness);
        }
        [TestMethod]
        public void TestNewCorporation()
        {
            _listCorporation = new List<Corporation>();
            _listCorporation.Add(new Corporation("Armurerie", "Armes", 3));
            _cvCity.NewCorporation(new Corporation("Armurerie", "Armes", 3));
            CollectionAssert.Equals(_listCorporation, _cvCity.ListCorporation);
        }
        [TestMethod]
        public void TestPublicOpinionUnhappy() //Problème avec private methods
        {
            _unhappiness = 5;
            _cvCity.NewCorporation(new Corporation("Armurerie", "Armes", 3));
            Assert.AreEqual(_unhappiness, _cvCity.Unhappiness);
        }

        [TestMethod]
        public void TestPublicOpinionHappy()
        {
            _happiness = 25;
            _cvCity.NewCorporation(new Corporation("Armurerie", "Armes", 3));
            Assert.AreEqual(_happiness, _cvCity.Happiness);
        }
        [TestCleanup]
        public void Cleanup()
        {
            this._happiness = 0;
            this._unhappiness = 0;
            this._listCorporation = null;
        }
    }
}
