using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RadioThermostat.DataTransferObjects;

namespace RadioThermostat
{
    public static class RadioThermostat
    {
        private static HttpClient client = new HttpClient();
        public static Uri uri;

        public static async Task<SystemInformation> GetSystemInformation()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}sys").Result);
            SystemInformation ret = JsonConvert.DeserializeObject<SystemInformation>(json);
            Console.WriteLine(JsonConvert.SerializeObject(ret, Formatting.Indented));
            return ret;
        }

        public static async Task<Model> GetModel()
        {
            var json = await Task.Run(() => QueryThermostat($"{uri.ToString()}tstat/model").Result);
            Model ret = JsonConvert.DeserializeObject<Model>(json);
            Console.WriteLine(JsonConvert.SerializeObject(ret, Formatting.Indented));
            return ret;
        }

        private static async Task<string>QueryThermostat(string url)
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
    