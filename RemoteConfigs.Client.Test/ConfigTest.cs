using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using RemoteConfigs.Client.Standard.Contract;
using RemoteConfigs.Client.Standard.Repository;
using RemoteConfigs.Client.Standard.Repository.Interface;

namespace RemoteConfigs.Client.Test
{
    public class ConfigTest
    {
        private IHttpRepository _httpRepo;

        [SetUp]
        public void Setup()
        {
            _httpRepo = new HttpRepository("RC_c5df336238433443e775c575d423c37ad998bac5");
        }

        [Test]
        public async Task GetAllConfigsTest()
        {
            List<ConfigWithSettingsList> allConfigs = await _httpRepo.GetAllConfigs();

            Assert.NotNull(allConfigs);
            Assert.NotZero(allConfigs.Count);
            Assert.Pass();
        }

        [Test]
        [TestCase("be4671bc")]
        public async Task GetSpecificConfigTest(string uniqueId)
        {
            ConfigWithSettingsList config = await _httpRepo.GetConfig(uniqueId);

            Assert.NotNull(config);
            Assert.NotNull(config.Settings);
            Assert.NotZero(config.Settings.Count);
            Assert.Pass();
        }

        [Test]
        [TestCase("be4671bc")]
        public async Task GetConfigAsObjectTest(string uniqueId)
        {
            ConfigWithSettingObject<Dictionary<string, string>> config = await _httpRepo.GetConfigAsObject<Dictionary<string, string>>(uniqueId);

            Assert.NotNull(config);
            Assert.NotNull(config.Settings);
            Assert.Pass();
        }

        [Test]
        public async Task CreateConfigTest()
        {
            const string name = "Kurt test";
            const string description = "Kurt's test config from test proj";

            CreateConfig newConfig = new CreateConfig
            {
                Name = name,
                Description = description,
                Settings = new List<Setting>
                {
                    new Setting
                    {
                        Key = "Hello",
                        Value = "Bye 👋"
                    }
                }
            };

            ConfigWithSettingsList config = await _httpRepo.CreateConfig(newConfig);

            Assert.NotNull(config);
            Assert.AreEqual(config.Name, name);
            Assert.AreEqual(config.Description, description);
            Assert.NotNull(config.Settings);
            Assert.NotZero(config.Settings.Count);
            Assert.AreEqual(config.Settings.Count, 1);
            Assert.Pass();
        }

        [Test]
        [TestCase("09ddd3bd")]
        public async Task UpdateConfigTest(string uniqueId)
        {
            const string name = "Kurt test updated";
            const string description = "Kurt's test config updated from test proj";

            UpdateConfig newConfig = new UpdateConfig
            {
                Name = name,
                Description = description,
                Settings = new List<Setting>
                {
                    new Setting
                    {
                        Key = "Bye bye",
                        Value = "Hello 👋"
                    }
                }
            };

            ConfigWithSettingsList config = await _httpRepo.UpdateConfig(uniqueId, newConfig);

            Assert.NotNull(config);
            Assert.AreEqual(config.Name, name);
            Assert.AreEqual(config.Description, description);
            Assert.NotNull(config.Settings);
            Assert.NotZero(config.Settings.Count);
            Assert.AreEqual(config.Settings.Count, 1);
            Assert.Pass();
        }

        [Test]
        [TestCase("09ddd3bd")]
        public async Task DeleteConfigTest(string uniqueId)
        {
            string config = await _httpRepo.DeleteConfig(uniqueId);

            Assert.NotNull(config);
            Assert.Pass();
        }
    }
}
