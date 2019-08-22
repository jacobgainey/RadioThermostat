using System;

namespace RadioThermostat.DataTransferObjects
{
    public class SystemInformation
    {
        public string uuid { get; set; }
        public int api_version { get; set; }
        public string fw_version { get; set; }
        public string wlan_fw_version { get; set; }
    }
}
