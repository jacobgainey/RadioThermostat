using System;
using System.Collections.Generic;
using System.Text;

namespace RadioThermostat.DataTransferObjects
{
    public struct Network
    {
        public string ssid { get; set; }
        public string bssid { get; set; }
        public int channel { get; set; }
        public int security { get; set; }
        public int ip { get; set; }
        //public string ipaddr { get; set; }
        //public string ipmask { get; set; }
        //public string ipgw { get; set; }
        //public string ipdns1 { get; set; }
        //public string ipdns2 { get; set; }
        public string rssi { get; set; }
    }
}
