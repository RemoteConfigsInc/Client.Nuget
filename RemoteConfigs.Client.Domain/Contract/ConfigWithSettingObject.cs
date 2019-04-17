using Newtonsoft.Json;
using RemoteConfigs.Client.Domain.Contract;

namespace RemoteConfigs.Client.Domain.Contract
{
    public class ConfigWithSettingObject<T> : BaseConfig
    {
        [JsonProperty("settings")]
        public T Settings { get; set; }
    }
}
