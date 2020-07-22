using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using StatlerWaldorfCorp.TeamService.Models;
using System.Text.Json;

namespace StatlerWaldorfCorp.TeamService.LocationClient
{
    public class HttpLocationClient : ILocationClient
    {
        public string Url { get; set; }
        public HttpLocationClient(string url)
        {
            Url = url;
        }
        public async Task<LocationRecord> GetLatestForMember(Guid memberId)
        {
            LocationRecord locationRecord = null;
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(this.Url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = await httpClient.GetAsync($"/locations/{memberId}/latest");
                if(response.IsSuccessStatusCode){
                    var jsonStr = await response.Content.ReadAsStringAsync();
                    locationRecord = JsonSerializer.Deserialize<LocationRecord>(jsonStr);
                }
                return locationRecord;
            }
        }
    }
}