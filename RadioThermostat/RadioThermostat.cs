using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RadioThermostat
{
    public static class RadioThermostat
    {
        public static HttpClient client = new HttpClient();

        public static async Task RunAsync()
        {
            SystemInformation system = new SystemInformation();
            system = await GetSystemInformation("http://192.168.88.100/sys");
            Console.WriteLine(JsonConvert.SerializeObject(system, Formatting.Indented));

            Model model = new Model();
            model = await GetModel("http://192.168.88.100/tstat/model");
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.Indented));
        }

        public static async Task<SystemInformation> GetSystemInformation(string path)
        {
            SystemInformation system = new SystemInformation();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                system = await response.Content.ReadAsAsync<SystemInformation>();
            }
            return system;
        }

        public static async Task<Model> GetModel(string path)
        {
            Model model = new Model();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<Model>();
            }
            return model;
        }
    }
}
    