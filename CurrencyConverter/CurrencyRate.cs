using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyRate : IConverterCurrency
    {
        private Currency currency;

        public CurrencyRate(string json)
        {
            currency = Currency.FromJson(json);
        }

        public double Convert(string from, string to, double value)
        {
            if (from == to && to == "RU")
            {
                return value;
            }

            if (from == "RU")
            {
                return value / currency.Valute[to].Value;
            }

            if (to == "RU")
            {
                return value * currency.Valute[from].Value;
            }

            return value * currency.Valute[from].Value / currency.Valute[to].Value;
        }

        public List<string> GetNameCurrency()
        {
            List<string> namesCurrency = new List<string>
            {
                "RU Российский рубль"
            };

            foreach (var obj in currency.Valute)
            {
                namesCurrency.Add(obj.Value.CharCode + " " + obj.Value.Name);
            }

            return namesCurrency;
        }
    }

    internal partial class Currency
    {
        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("PreviousDate")]
        public DateTimeOffset PreviousDate { get; set; }

        [JsonProperty("PreviousURL")]
        public string PreviousUrl { get; set; }

        [JsonProperty("Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Dictionary<string, Valute> Valute { get; set; }
    }

    internal partial class Valute
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("NumCode")]
        public string NumCode { get; set; }

        [JsonProperty("CharCode")]
        public string CharCode { get; set; }

        [JsonProperty("Nominal")]
        public long Nominal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Previous")]
        public double Previous { get; set; }
    }

    internal partial class Currency
    {
        public static Currency FromJson(string json) => JsonConvert.DeserializeObject<Currency>(json, Converter.Settings);
    }

    internal static class Serialize
    {
        public static string ToJson(this Currency self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
