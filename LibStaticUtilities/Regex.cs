using System;
using System.Net;

namespace LibStaticUtilities_Regex
{
    public static class Regex
    {
        public static bool CheckValidIPv4(IPAddress ip) => CheckValidIPv4(ip.ToString());
        public static bool CheckValidIPv4(string ip)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^((0|1[0-9]{0,2}|2[0-9]?|2[0-4][0-9]|25[0-5]|[3-9][0-9]?)\.){3}(0|1[0-9]{0,2}|2[0-9]?|2[0-4][0-9]|25[0-5]|[3-9][0-9]?)$");
            return regex.IsMatch(ip);
        }

        public static bool CheckValidPort(uint port) => CheckValidPort(port.ToString());
        public static bool CheckValidPort(int port) => CheckValidPort(port.ToString());
        public static bool CheckValidPort(string port)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");
            return regex.IsMatch(port);
        }

        public static bool CheckFloat(string str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$");
            return regex.IsMatch(str);
        }

        public static bool CheckAlphaNumeric(string str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]+$");
            return regex.IsMatch(str);
        }
        public static bool CheckNumeric(string str)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            return regex.IsMatch(str);
        }

    }
}
