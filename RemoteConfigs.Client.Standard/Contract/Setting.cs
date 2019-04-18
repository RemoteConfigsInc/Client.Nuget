using Newtonsoft.Json;

namespace RemoteConfigs.Client.Standard.Contract
{
    public class Setting
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
