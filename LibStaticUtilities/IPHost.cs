using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace LibStaticUtilities_IPHostPort
{
    public static class IPHost
    {
        public static bool IsIPv4ValidFormat(string ip) => LibStaticUtilities_Regex.Regex.CheckValidIPv4(ip);
        public static bool IsIPv4ValidFormat(IPAddress ip) => LibStaticUtilities_Regex.Regex.CheckValidIPv4(ip);

        public static string[] GetIPv4FromHost(string host)
        {
            var ip = new List<string>();
            if (LibStaticUtilities_Regex.Regex.CheckValidIPv4(host))
                ip.Add(host);
            else
            {
                try
                {
                    var ipEntry = System.Net.Dns.GetHostEntry(host);
                    foreach (var ipaddy in ipEntry.AddressList)
                        ip.Add(ipaddy.ToString());
                }
                catch (Exception)
                {

                }
            }

            return ip.ToArray();
        }
        public static List<string> GetAllLocalIPv4(NetworkInterfaceType type)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                           .Where(x => x.NetworkInterfaceType == type && x.OperationalStatus == OperationalStatus.Up)
                           .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                           .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
                           .Select(x => x.Address.ToString())
                           .ToList();
        }

        public static List<string> GetAllLocalIPv4()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                           .Where(x => x.OperationalStatus == OperationalStatus.Up)
                           .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                           .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
                           .Select(x => x.Address.ToString())
                           .ToList();
        }

        public static IPAddress UInt32ToIPAddress(UInt32 address)
        {
            return new IPAddress(new byte[] {
                (byte)((address>>24) & 0xFF) ,
                (byte)((address>>16) & 0xFF) ,
                (byte)((address>>8)  & 0xFF) ,
                (byte)( address & 0xFF)});
        }
    }
}
