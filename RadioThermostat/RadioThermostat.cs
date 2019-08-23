using Newtonsoft.Json;
using RadioThermostat.DataTransferObjects;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RadioThermostat
{
    public static class RadioThermostat
    {
        private static HttpClient client = new HttpClient();
        public static Uri uri;

        public static async Task<DataTransferObjects.Info> GetInfo()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}sys").Result);
            return JsonConvert.DeserializeObject<Info>(json);
        }

        public static async Task<Model> GetModel()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}tstat/model").Result);
            return JsonConvert.DeserializeObject<Model>(json);
        }

        public static async Task<Name> GetName()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}sys/name").Result);
            return JsonConvert.DeserializeObject<Name>(json);
        }

        public static async Task<Mode> GetMode()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}sys/mode").Result);
            return JsonConvert.DeserializeObject<Mode>(json);
        }

        public static async Task<Hvac> GetHvac()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}tstat/hvac_settings").Result);
            return JsonConvert.DeserializeObject<Hvac>(json);
        }

        public static async Task<Network> GetNetwork()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}sys/network").Result);
            return JsonConvert.DeserializeObject<Network>(json);
        }

        private static async Task<string> QueryThermostat(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}