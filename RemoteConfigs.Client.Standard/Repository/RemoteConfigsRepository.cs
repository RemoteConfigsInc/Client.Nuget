using Newtonsoft.Json;
using RemoteConfigs.Client.Standard.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RemoteConfigs.Client.Domain.Contract;

namespace RemoteConfigs.Client.Standard.Repository
{
    public class RemoteConfigsRepository : IRemoteConfigsRepository
    {
        private readonly string _apiKey;

        private readonly string _configurationsUrl;

        private const string RemoteConfigsUrl = "https://api.remoteconfigs.com/";
        private const string ConfigurationsEndpoint = "Configurations";
        private const string ConfigurationsObjectEndpoint = "Object";
        private const string HeaderKey = "apikey";

        public RemoteConfigsRepository(string apiKey)
        {
            _apiKey = apiKey;

            _configurationsUrl = Path.Combine(RemoteConfigsUrl, ConfigurationsEndpoint);
        }

        public async Task<List<ConfigWithSettingsList>> GetAllConfigsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.GetAsync(_configurationsUrl);
                string content = await response.Content.ReadAsStringAsync();
                List<ConfigWithSettingsList> allConfigs = JsonConvert.DeserializeObject<List<ConfigWithSettingsList>>(content);
                return allConfigs;
            }
        }

        public async Task<ConfigWithSettingsList> GetConfigAsync(string uniqueId)
        {
            string configurationUrl = Path.Combine(_configurationsUrl, uniqueId);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.GetAsync(configurationUrl);
                string content = await response.Content.ReadAsStringAsync();
                ConfigWithSettingsList config = JsonConvert.DeserializeObject<ConfigWithSettingsList>(content);
                return config;
            }
        }

        public async Task<ConfigWithSettingObject<T>> GetConfigAsObjectAsync<T>(string uniqueId)
        {
            string configurationObjectUrl = Path.Combine(_configurationsUrl, uniqueId, ConfigurationsObjectEndpoint);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.GetAsync(configurationObjectUrl);
                string content = await response.Content.ReadAsStringAsync();
                ConfigWithSettingObject<T> config = JsonConvert.DeserializeObject<ConfigWithSettingObject<T>>(content);
                return config;
            }
        }

        public async Task<ConfigWithSettingsList> CreateConfigAsync(CreateConfig newConfig)
        {
            string configurationUrl = Path.Combine(_configurationsUrl);

            string payload = JsonConvert.SerializeObject(newConfig);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.PostAsync(configurationUrl, new StringContent(payload, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();
                ConfigWithSettingsList config = JsonConvert.DeserializeObject<ConfigWithSettingsList>(content);
                return config;
            }
        }

        public async Task<ConfigWithSettingsList> UpdateConfigAsync(string uniqueId, UpdateConfig updatedConfig)
        {
            string configurationUrl = Path.Combine(_configurationsUrl, uniqueId);

            string payload = JsonConvert.SerializeObject(updatedConfig);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.PutAsync(configurationUrl, new StringContent(payload, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();
                ConfigWithSettingsList config = JsonConvert.DeserializeObject<ConfigWithSettingsList>(content);
                return config;
            }
        }

        public async Task<string> DeleteConfigAsync(string uniqueId)
        {
            string configurationUrl = Path.Combine(_configurationsUrl, uniqueId);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HeaderKey, _apiKey);
                HttpResponseMessage response = await client.DeleteAsync(configurationUrl);
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

    }
}
