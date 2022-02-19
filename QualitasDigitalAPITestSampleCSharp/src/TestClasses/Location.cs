using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QualitasDigitalAPITestSampleCSharp.src.TestClasses
{
    public class Location
    {
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
    }
}
