using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFSWebServices.Models
{
    public class Tradeline
    {
        [JsonProperty("tradelineId")]
        public long TradelineId { get; set; }
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty("balance")]
        public int Balance { get; set; }
        [JsonProperty("monthlyPayment")]
        public int MonthlyPayment { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("isMortgage")]
        public bool IsMortgage { get; set; }
    }
}
