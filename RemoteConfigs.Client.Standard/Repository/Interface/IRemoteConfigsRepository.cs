using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteConfigs.Client.Domain.Contract;

namespace RemoteConfigs.Client.Standard.Repository.Interface
{
    public interface IRemoteConfigsRepository
    {
        Task<List<ConfigWithSettingsList>> GetAllConfigs();
        Task<ConfigWithSettingsList> GetConfig(string uniqueId);
        Task<ConfigWithSettingObject<T>> GetConfigAsObject<T>(string uniqueId);
        Task<ConfigWithSettingsList> CreateConfig(CreateConfig newConfig);
        Task<ConfigWithSettingsList> UpdateConfig(string uniqueId, UpdateConfig updatedConfig);
        Task<string> DeleteConfig(string uniqueId);
    }
}