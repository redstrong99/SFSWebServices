using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFSWebServices.Models
{
    public class CreditReport
    {
        [JsonProperty("creditReports")]
        public List<Credit> Credits { get; set; }
    }
}
