using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Commerce.Models.Shared
{
    public class Charge : Json
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("hosted_url")]
        public string HostedUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("expires_at")]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty("confirmed_at")]
        public DateTimeOffset ConfirmedAt { get; set; }


        [JsonProperty("checkout")]
        public Checkout Checkout { get; set; }


        [JsonProperty("timeline")]
        public Timeline[] Timeline { get; set; }


        [JsonProperty("metadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("pricing_type")]
        public PricingType PricingType { get; set; }

        [JsonProperty("pricing")]
        public Dictionary<string, Money> Pricing { get; set; }

        [JsonProperty("payments")]
        public Payment[] Payments { get; set; }


        [JsonProperty("addresses")]
        public Dictionary<string, string> Addresses { get; set; }
    }
}
