using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFSWebServices.Models
{
    public class Credit
    {
        [JsonProperty("applicationId") ]
        public int ApplicationId { get; set; }
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("bureau")]
        public string Bureau { get; set; }
        [JsonProperty("minPaymentPercentage")]
        public int? MinPaymentPercentage { get; set; }
        [JsonProperty("tradelines")]
        public List<Tradeline> Tradelines { get; set; }
    }
}
