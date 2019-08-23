namespace RadioThermostat.DataTransferObjects
{
    public struct Info
    {
        public string UUID { get; set; }
        public int api_version { get; set; }
        public string fw_version { get; set; }
        public string wlan_fw_version { get; set; }
    }
}