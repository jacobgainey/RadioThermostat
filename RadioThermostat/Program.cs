using Newtonsoft.Json;
using RadioThermostat.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace RadioThermostat
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RadioThermostat");

            Uri uri = GetUri("http://192.168.88.100");

            //Console.WriteLine(uri.AbsoluteUri);
            //Console.WriteLine(uri.Scheme);
            //Console.WriteLine(uri.Host);
            //Console.WriteLine(uri.AbsolutePath);

            RadioThermostat.uri = new Uri("http://192.168.88.100");

            Hvac hvac = Task.Run(() => RadioThermostat.GetHvac()).Result;
            Info info = Task.Run(() => RadioThermostat.GetInfo()).Result;
            Mode mode = Task.Run(() => RadioThermostat.GetMode()).Result;
            Model model = Task.Run(() => RadioThermostat.GetModel()).Result;
            Name name = Task.Run(() => RadioThermostat.GetName()).Result;
            Network network = Task.Run(() => RadioThermostat.GetNetwork()).Result;

            Console.WriteLine(JsonConvert.SerializeObject(hvac, Formatting.None));
            Console.WriteLine(JsonConvert.SerializeObject(info, Formatting.None));
            Console.WriteLine(JsonConvert.SerializeObject(mode, Formatting.None));
            Console.WriteLine(JsonConvert.SerializeObject(model, Formatting.None));
            Console.WriteLine(JsonConvert.SerializeObject(name, Formatting.None));
            Console.WriteLine(JsonConvert.SerializeObject(network, Formatting.None));
            Console.ReadKey();
        }

        private static Uri GetUri(this string s)
        {
            return new UriBuilder(s).Uri;
        }

    }
}
