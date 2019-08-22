using System;
using System.Threading.Tasks;

namespace RadioThermostat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RadioThermostat");
            RadioThermostat.uri = new Uri("http://192.168.88.100");
            Task.Run(() => RadioThermostat.GetModel().GetAwaiter().GetResult());
            Task.Run(() => RadioThermostat.GetSystemInformation().GetAwaiter().GetResult());

            Console.ReadKey();
        }
    }
}
