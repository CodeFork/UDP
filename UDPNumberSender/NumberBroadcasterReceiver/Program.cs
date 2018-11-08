using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NumberBroadcasterReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(9876);
            IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Any, 9876);

            while (true)
            {
                Byte[] receiveBytes = udp.Receive(ref RemoteEndPoint);

                string receivedData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine(receivedData);
            }
        }

    }
}