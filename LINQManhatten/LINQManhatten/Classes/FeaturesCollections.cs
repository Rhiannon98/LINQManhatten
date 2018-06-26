using System.Collections.Generic;
using Newtonsoft.Json;

namespace LINQManhatten.Classes
{
    /// <summary>
    /// This class nabs the features and puts them in a list
    /// </summary>
    public class FeaturesCollections
    {
        [JsonProperty]
        public List<Features> Features { get; set; }
        public string Type { get; set; }
    }
}
