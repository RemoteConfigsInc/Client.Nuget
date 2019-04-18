using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteConfigs.Client.Standard.Contract
{
    public class CreateConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("settings")]
        public List<Setting> Settings { get; set; }
    }
}
