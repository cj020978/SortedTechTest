using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SortedTechTest.Controllers
{
    public class RainfallReaderControllerTests : IClassFixture<WebApplicationFactory<Rainfall>>
    {
        private HttpClient _httpClient;

        public RainfallReaderControllerTests() 
        {
            var application = new WebApplicationFactory<Rainfall>();

            _httpClient = application.CreateClient();
        }

        [Theory]
        [InlineData("3680")]
        [InlineData("E7050")]
        [InlineData("242534TP")]
        [InlineData("52210")]
        public async Task GetRainfallReadingForStationId(string stationId)
        {
            var requestUri = string.Format("rainfall/id/{0}/readings", stationId);
            var response = await _httpClient.GetAsync(requestUri);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var rainfallDetails = await response.Content.ReadFromJsonAsync<RainfallReading[]>();
            Assert.NotNull(rainfallDetails);
            Assert.Equal(10, rainfallDetails.Length);
        }

        [Theory]
        [InlineData("3680", 1)]
        [InlineData("3680", 10)]
        [InlineData("3680", 100)]
        [InlineData("3680", 50)]
        [InlineData("3680", 32)]
        public async Task GetRainfallReadingForStationIdAndCount(string stationId, int count)
        {
            var requestUri = string.Format("rainfall/id/{0}/readings?count={1}", stationId, count);
            var response = await _httpClient.GetAsync(requestUri);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var rainfallDetails = await response.Content.ReadFromJsonAsync<RainfallReading[]>();
            Assert.NotNull(rainfallDetails);
            Assert.Equal(count, rainfallDetails.Length);
        }

        [Theory]
        [InlineData("1000000000")]
        [InlineData("ABC")]
        [InlineData("+554")]
        [InlineData("-1542")]
        public async Task GetRainfallReadingForInvalidStationId(string stationId)
        {
            var requestUri = string.Format("rainfall/id/{0}/readings", stationId);
            var response = await _httpClient.GetAsync(requestUri);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
            var errorDetails = await response.Content.ReadFromJsonAsync<Error.Error>();
            Assert.NotNull(errorDetails);
            Assert.Equal("No Data Found", errorDetails.message);
            Assert.NotNull(errorDetails.detail);
            Assert.Equal(1, errorDetails.detail.Length);
            Assert.Equal("Id", errorDetails.detail[0].propertyName);
            Assert.Equal("No readings found for the specified stationId", errorDetails.detail[0].message);
        }

        [Theory]
        [InlineData("3680", -1)]
        [InlineData("3680", 0)]
        [InlineData("3680", 101)]
        public async Task GetRainfallReadingForStationIdAndInvalidCount(string stationId, int count)
        {
            var requestUri = string.Format("rainfall/id/{0}/readings?count={1}", stationId, count);
            var response = await _httpClient.GetAsync(requestUri);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            var errorDetails = await response.Content.ReadFromJsonAsync<Error.Error>();
            Assert.NotNull(errorDetails);
            Assert.Equal("The value is outside the allowed range", errorDetails.message);
            Assert.NotNull(errorDetails.detail);
            Assert.Equal(1, errorDetails.detail.Length);
            Assert.Equal("Count", errorDetails.detail[0].propertyName);
            Assert.Equal("The Count value must be between 1 and 100", errorDetails.detail[0].message);
        }
    }
}
