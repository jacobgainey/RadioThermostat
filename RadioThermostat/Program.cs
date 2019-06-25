using System;
using System.Threading.Tasks;

namespace RadioThermostat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RadioThermostat");
            Task.Run(() => RadioThermostat.RunAsync().GetAwaiter().GetResult());
            Console.ReadKey();
        }
    }
}
