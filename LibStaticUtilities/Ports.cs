using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;
using System.Linq;

namespace LibStaticUtilities_IPHostPort
{
    public static class Ports
    {
        public const int MinPortNumber = 1025;
        public const int MaxPortNumber = 65535;

        public static bool IsPortValid(uint port) => IsPortValid(port.ToString());
        public static bool IsPortValid(int port) => IsPortValid(port.ToString());
        public static bool IsPortValid(string port)
        {
            if(!LibStaticUtilities_Regex.Regex.CheckValidPort(port))
                return false;

            int p = int.Parse(port);
            if (!(MinPortNumber <= p && p <= MaxPortNumber)) 
               return false;

            return true;
        }

        public static bool IsPortAvailable(IPAddress ip, int port)
        {
            var availablePorts = new List<int>();
            var ipStr = ip.ToString();

            var properties = IPGlobalProperties.GetIPGlobalProperties();

            // Active connections
            var connections = properties.GetActiveTcpConnections();
            foreach ( var connection in connections )
                if(connection.LocalEndPoint.Address == ip)
                    availablePorts.Add(connection.LocalEndPoint.Port);

            // Active tcp listners
            var endPointsTcp = properties.GetActiveTcpListeners();
            foreach (var listener in endPointsTcp)
                if (listener.Address == ip)
                    availablePorts.Add(listener.Port);

            // Active udp listeners
            var endPointsUdp = properties.GetActiveUdpListeners();
            foreach( var listener in endPointsUdp)
                availablePorts.Add(listener.Port);

            foreach (int p in availablePorts)
                if (p == port)
                    return false;

            return true;
        }

        public static int GetAvailablePort(string ip, int start = MinPortNumber) => GetAvailablePort(IPAddress.Parse(ip), start);
        public static int GetAvailablePort(IPAddress ip, int start = MinPortNumber)
        {
            for (int i = start; i <= MaxPortNumber; i++)
            {
                if(IsPortAvailable(ip, i))
                    return i;
            }

            return start;
        }
    }
}
