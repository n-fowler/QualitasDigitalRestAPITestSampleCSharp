using System.Text.Json.Serialization;

namespace QualitasDigitalAPITestSampleCSharp.src.TestClasses
{
    public class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
    }
}
