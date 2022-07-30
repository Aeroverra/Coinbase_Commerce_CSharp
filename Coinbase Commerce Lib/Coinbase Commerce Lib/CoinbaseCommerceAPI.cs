using Coinbase.Commerce.Models;
using Coinbase.Commerce.Models.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coinbase.Commerce
{
    public class CoinbaseCommerceAPI
    {
        private string Key { get; set; }
        private string Version { get; set; } = "2018-03-22";
        public CoinbaseCommerceAPI(String apiKey)
        {
            Key = apiKey;
        }
        private RestRequest GetRequest(Object body = null)
        {
            var request = new RestRequest();
            request.AddHeader("X-CC-Api-Key", Key);
            request.AddHeader("X-CC-Version", Version);
            if (body != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(JsonConvert.SerializeObject(body));
            }
            return request;
        }

        /// <summary>
        /// To get paid in cryptocurrency, you need to create a charge object 
        /// and provide the user with a cryptocurrency address to 
        /// which they must send cryptocurrency. Once a charge is 
        /// created a customer must broadcast a payment to the
        /// blockchain before the charge expires.
        /// </summary>
        public async Task<Response<Charge>> CreateChargeAsync(CreateCharge charge)
        {
            var client = new RestClient("https://api.commerce.coinbase.com/charges");
            var request = GetRequest(charge);
            var response = await client.ExecutePostAsync(request);
            return JsonConvert.DeserializeObject<Response<Charge>>(response.Content);
        }

        /// <summary>
        /// Retrieves the details of a charge that has been previously
        /// created. Supply the unique charge code that was returned when
        /// the charge was created. This information is also returned when
        /// a charge is first created.
        /// </summary>
        public async Task<Response<Charge>> GetChargeAsync(String id)
        {
            var client = new RestClient($"https://api.commerce.coinbase.com/charges/{id}");
            var request = GetRequest();
            var response = await client.GetAsync(request);
            return JsonConvert.DeserializeObject<Response<Charge>>(response.Content);
        }

        /// <summary>
        /// Cancels a charge that has been previously created.
        /// Supply the unique charge code that was returned when the charge was created.
        /// Note: Only new charges can be successfully canceled.
        /// Once payment is detected, charge can no longer be canceled.
        /// </summary>
        public async Task<Response<Charge>> CancelChargeAsync(String id)
        {
            var client = new RestClient($"https://api.commerce.coinbase.com/charges/{id}/cancel");
            var request = GetRequest();
            var response = await client.PostAsync(request);
            return JsonConvert.DeserializeObject<Response<Charge>>(response.Content);
        }

        /// <summary>
        /// Resolve a charge that has been previously marked as unresolved.
        /// Supply the unique charge code that was returned when the charge was created.
        /// Note: Only unresolved charges can be successfully resolved.
        /// For more on unresolved charges, check out at <see href="https://commerce.coinbase.com/docs/api/#charge-timeline">Charge timeline</see>
        /// </summary>
        public async Task<Response<Charge>> ResolveChargeAsync(String id)
        {
            var client = new RestClient($"https://api.commerce.coinbase.com/charges/{id}/resolve");
            var request = GetRequest();
            var response = await client.PostAsync(request);
            return JsonConvert.DeserializeObject<Response<Charge>>(response.Content);
        }

        /// <summary>
        /// List all the charges. All GET endpoints which return an object list
        /// support cursor based pagination with pagination information
        /// inside a pagination object. This means that to get all objects,
        /// you need to paginate through the results by always using the id
        /// of the last resource in the list as a starting_after parameter
        /// for the next call. To make it easier, the API will construct
        /// the next call into next_uri together with all the currently
        /// used pagination parameters. You know that you have paginated
        /// all the results when the response’s next_uri is empty.
        /// </summary>
        public async Task<PagedResponse<Charge>> ListChargesAsync(ListOrder? listOrder = null, int? limit = null, string startingAfter = null, string endingBefore = null)
        {
            var client = new RestClient($"https://api.commerce.coinbase.com/charges");
            var request = GetRequest();
            request.AddQueryParameter("order", $"{listOrder}");
            request.AddQueryParameter("limit", $"{limit}");
            request.AddQueryParameter("starting_after", $"{startingAfter}");
            request.AddQueryParameter("ending_before", $"{endingBefore}");
            var response = await client.GetAsync(request);
            return JsonConvert.DeserializeObject<PagedResponse<Charge>>(response.Content);
        }
    }
}
