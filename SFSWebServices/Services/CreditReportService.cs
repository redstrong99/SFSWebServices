using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SFSWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SFSWebServices.Services
{
    public class CreditReportService : ICreditReportService
    {
        public async Task<List<Credit>> GetData()
        {
            List<Credit> credits = new List<Credit>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://raw.githubusercontent.com/StrategicFS/Recruitment/master/creditData.json");
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var creditReport = JsonConvert.DeserializeObject<CreditReport>(apiResponse);
                    credits = creditReport.Credits;
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }

            return credits;
        }
    }
}
