using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteConfigs.Client.Standard.Contract
{
    public class ConfigWithSettingsList : BaseConfig
    {
        [JsonProperty("settings")]
        public List<Setting> Settings { get; set; }
    }
}
