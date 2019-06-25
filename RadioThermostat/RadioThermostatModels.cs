using System;

namespace RadioThermostat
{
    public class SystemInformation
    {
        public string uuid { get; set; }
        public int api_version { get; set; }
        public string fw_version { get; set; }
        public string wlan_fw_version { get; set; }
    }

    public class Model
    {
        public string model { get; set; }
    }
    
}
