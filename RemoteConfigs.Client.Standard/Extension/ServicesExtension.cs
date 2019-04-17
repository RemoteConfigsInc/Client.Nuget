using System;
using Microsoft.Extensions.DependencyInjection;
using RemoteConfigs.Client.Standard.Repository;
using RemoteConfigs.Client.Standard.Repository.Interface;

namespace RemoteConfigs.Client.Standard.Extension
{
    public static class ServicesExtension
    {
        public static void AddRemoteConfigs(this IServiceCollection service, string apiKey)
        {
            service.AddTransient<IRemoteConfigsRepository>(construct => new RemoteConfigsRepository(apiKey));
        }

        public static void AddRemoteConfigs<T>(this IServiceCollection service, string apiKey) where T : class, IRemoteConfigsRepository, new()
        {
            service.AddTransient<IRemoteConfigsRepository>(construct => (T)Activator.CreateInstance(typeof(T), apiKey));
        }
    }
}
