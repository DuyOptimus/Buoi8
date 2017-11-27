using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Broadcast
{
    class Program
    {
        public static void Main()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe1 = new IPEndPoint(IPAddress.Broadcast, 9050);
            IPEndPoint ipe2 = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 9050);
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.ASCII.GetBytes(hostname);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            sock.SendTo(data, ipe1);
            sock.SendTo(data, ipe2);
            sock.Close();
        }
    }
}
