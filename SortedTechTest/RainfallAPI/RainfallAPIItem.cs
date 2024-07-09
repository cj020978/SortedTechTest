using System.Text.Json.Serialization;

namespace SortedTechTest.RainfallAPI
{
    public class RainfallAPIItem
    {
        [JsonPropertyName("@id")]
        public string? Id { set; get; }

        [JsonPropertyName("dateTime")]

        public string? DateTime { set; get; }

        [JsonPropertyName("measure")]
        public string? Measure { set; get; }

        [JsonPropertyName("value")]
        public decimal Value { set; get; }
    }
}
