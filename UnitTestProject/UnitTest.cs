using System;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.ApplicationModel.Resources;
using CurrencyConverter;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestCurrencyRate
    {
        private double delta = 0.001;
        [TestMethod]
        public void GetNameCurrency()
        {
            var resourceLoader = new ResourceLoader();
            var demoJson = resourceLoader.GetString("demoJson");
            CurrencyRate currencyRate = new CurrencyRate(demoJson);

            var expected = currencyRate.GetNameCurrency();
            Assert.AreEqual(expected.Count, 3);

            Assert.AreEqual(expected[0], "RU Российский рубль");
            Assert.AreEqual(expected[1], "AUD Австралийский доллар");
            Assert.AreEqual(expected[2], "AZN Азербайджанский манат");
        }

        [TestMethod]
        public void ConvertRuToRU()
        {
            var resourceLoader = new ResourceLoader();
            var demoJson = resourceLoader.GetString("demoJson");
            CurrencyRate currencyRate = new CurrencyRate(demoJson);
            var expected = currencyRate.Convert("RU", "RU", 100);

            Assert.AreEqual(expected, 100, delta);
        }

        [TestMethod]
        public void ConvertRUtoAUD()
        {
            var resourceLoader = new ResourceLoader();
            var demoJson = resourceLoader.GetString("demoJson");
            CurrencyRate currencyRate = new CurrencyRate(demoJson);
            var expected = currencyRate.Convert("RU", "AUD", 100);

            Assert.AreEqual(expected, 100 / 53.8136, delta);
        }

        [TestMethod]
        public void ConvertAUDtoRU()
        {
            var resourceLoader = new ResourceLoader();
            var demoJson = resourceLoader.GetString("demoJson");
            CurrencyRate currencyRate = new CurrencyRate(demoJson);
            var expected = currencyRate.Convert("AUD", "RU", 100);

            Assert.AreEqual(expected, 100 * 53.8136, delta);
        }

        [TestMethod]
        public void ConvertAUDtoAZN()
        {
            var resourceLoader = new ResourceLoader();
            var demoJson = resourceLoader.GetString("demoJson");
            CurrencyRate currencyRate = new CurrencyRate(demoJson);
            var expected = currencyRate.Convert("AUD", "AZN", 100);

            Assert.AreEqual(expected, 100 * 53.8136 / 42.8776, delta);
        }
    }
}
