using Coinbase.Commerce.Models.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Commerce.Models
{
    public class CreateCharge : Json
    {
        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pricing_type")]
        public PricingType PricingType { get; set; } 

        [JsonProperty("local_price")]
        public Money LocalPrice { get; set; }


        [JsonProperty("metadata")]
        public JObject Metadata { get; set; } = new JObject();


        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }
}
