using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Commerce.Models.Shared
{

    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ListOrder
    {
        Asc,
        Desc
    }

}
