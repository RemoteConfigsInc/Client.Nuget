﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoteConfigs.Client.Domain.Contract
{
    public class UpdateConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("settings")]
        public List<Setting> Settings { get; set; }
    }
}