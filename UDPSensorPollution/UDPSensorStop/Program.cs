using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSensorStop
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 11111);

            Console.Write("Press any key to stop the server!\n");
            Console.ReadKey();

            Byte[] sendBytes = Encoding.ASCII.GetBytes("stop");
            udpClient.Send(sendBytes, sendBytes.Length, endpoint);
        }
    }
}
