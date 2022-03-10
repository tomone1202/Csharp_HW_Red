using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClassicWebAPI.Models
{
    public class PostDataInfo
    {
        [JsonProperty("Subregion")]
        public string Subregion { get; set; }

        [JsonProperty("Countries")]
        public string[] Countries { get; set; }

        internal void dump()
        {
            throw new NotImplementedException();
        }
    }
}