namespace SortedTechTest.RainfallAPI
{
    public class RainfallAPIManager
    {
        HttpClient client = new HttpClient();

        public RainfallAPIManager()
        {
            client.BaseAddress = new Uri("http://environment.data.gov.uk/");
        }

        public async Task<RainfallAPIResponse?> GetStationRainfallData(string stationId)
        {
            return await client.GetFromJsonAsync<RainfallAPIResponse>($"flood-monitoring/id/stations/{stationId}/readings");
        }
    }
}
