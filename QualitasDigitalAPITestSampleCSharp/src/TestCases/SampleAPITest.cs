using NUnit.Framework;
using QualitasDigitalAPITestSampleCSharp.src.TestClasses;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace QualitasDigitalAPITestSampleCSharp
{
    [TestFixture]
    public class SampleAPITest
    {
        private const string testUrl = "http://api.zippopotam.us";

        [TestCase("us", "28412", HttpStatusCode.OK, TestName = "Sample API Test - Status Code OK")]
        [TestCase("us", "99999", HttpStatusCode.NotFound, TestName = "Sample API Test - Status Code Not Found - invalid zip")]
        [TestCase("us", "", HttpStatusCode.NotFound, TestName = "Sample API Test - Status Code Not Found - empty zip")]
        [TestCase("", "28412", HttpStatusCode.NotFound, TestName = "Sample API Test - Status Code Not Found - empty country")]
        public void SampleAPITestStatusCode(string countryCode, string zipCode, HttpStatusCode expectedHttpStatusCode)
        {
            //Arrange all necessary preconditions and inputs
            RestClient client = new RestClient(testUrl);
            RestRequest request = new RestRequest($"{countryCode}/{zipCode}", Method.Get);

            //Act on the object or method under test
            var response = client.ExecuteAsync(request);

            //Assert that the expected results have occurred
            Assert.AreEqual(expectedHttpStatusCode, response.Result.StatusCode);
        }

        [TestCase("us", "28412", TestName = "Sample API Test - Location - US")]
        public async Task SampleAPITestResponse(string countryCode, string zipCode)
        {
            RestClient client = new RestClient(testUrl);
            RestRequest request = new RestRequest($"{countryCode}/{zipCode}", Method.Get);

            var response =  await client.ExecuteAsync(request);

            var actualLocation = new SystemTextJsonSerializer().Deserialize<Location>(response);

            Location expectedLocation = new Location()
            {
                PostCode = "28412",
                Country = "United States",
                CountryAbbreviation = "US",
                Places = new List<Place>() 
                { 
                    new Place()
                    {
                        PlaceName = "Wilmington",
                        Longitude = "-77.9141",
                        State = "North Carolina",
                        StateAbbreviation = "NC",
                        Latitude = "34.1572"
                    } 
                }
            };

            Assert.AreEqual(expectedLocation.PostCode, actualLocation.PostCode);
            Assert.AreEqual(expectedLocation.Country, actualLocation.Country);
            Assert.AreEqual(expectedLocation.CountryAbbreviation, actualLocation.CountryAbbreviation);
            Assert.AreEqual(expectedLocation.Places.Count, actualLocation.Places.Count);
            Assert.AreEqual(expectedLocation.Places[0].PlaceName, actualLocation.Places[0].PlaceName);
            Assert.AreEqual(expectedLocation.Places[0].Longitude, actualLocation.Places[0].Longitude);
            Assert.AreEqual(expectedLocation.Places[0].State, actualLocation.Places[0].State);
            Assert.AreEqual(expectedLocation.Places[0].StateAbbreviation, actualLocation.Places[0].StateAbbreviation);
            Assert.AreEqual(expectedLocation.Places[0].Latitude, actualLocation.Places[0].Latitude);
            return;
        }
    }
}
