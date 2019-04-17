using System;
using Newtonsoft.Json;

namespace RemoteConfigs.Client.Domain.Contract
{
    public class BaseConfig
    {
        [JsonProperty("uniqueID")]
        public string UniqueId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("lastModifiedOn")]
        public DateTime LastModifiedOn { get; set; }
    }
}
