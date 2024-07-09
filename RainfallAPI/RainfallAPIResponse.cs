using System.Text.Json.Serialization;

namespace SortedTechTest.RainfallAPI
{
    public class RainfallAPIResponse
    {
        [JsonPropertyName("@context")]
        public string? Context { set; get; }

        [JsonPropertyName("meta")]
        public RainfallAPIMeta? Meta { set; get; }

        [JsonPropertyName("items")]
        public RainfallAPIItem[]? Items { set; get; }
    }
}
