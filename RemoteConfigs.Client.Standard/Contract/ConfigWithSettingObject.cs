using Newtonsoft.Json;

namespace RemoteConfigs.Client.Standard.Contract
{
    public class ConfigWithSettingObject<T> : BaseConfig
    {
        [JsonProperty("settings")]
        public T Settings { get; set; }
    }
}
