using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SortedTechTest.RainfallAPI
{
    public class RainfallAPIMeta
    {
        [JsonPropertyName("publisher")]
        public string? Publisher { set; get; }

        [JsonPropertyName("licence")]
        public string? Licence { set; get; }

        [JsonPropertyName("documentation")]
        public string? Documentation { set; get; }

        [JsonPropertyName("version")]
        public string? Version { set; get; }

        [JsonPropertyName("comment")]
        public string? Comment { set; get; }

        [JsonPropertyName("hasFormat")]
        public string[]? HasFormat { set; get; }

        [JsonPropertyName("limit")]
        public int Limit { set; get; }
    }
}
