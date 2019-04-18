using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteConfigs.Client.Standard.Contract;

namespace RemoteConfigs.Client.Standard.Repository.Interface
{
    public interface IRemoteConfigsRepository
    {
        Task<List<ConfigWithSettingsList>> GetAllConfigsAsync();
        Task<ConfigWithSettingsList> GetConfigAsync(string uniqueId);
        Task<ConfigWithSettingObject<T>> GetConfigAsObjectAsync<T>(string uniqueId);
        Task<ConfigWithSettingsList> CreateConfigAsync(CreateConfig newConfig);
        Task<ConfigWithSettingsList> UpdateConfigAsync(string uniqueId, UpdateConfig updatedConfig);
        Task<string> DeleteConfigAsync(string uniqueId);
    }
}