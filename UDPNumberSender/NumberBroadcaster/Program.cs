using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberBroadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 9876);

            Console.Write("Press any key to start...\n");
            Console.ReadKey();

            while(true)
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 10);

                Byte[] sendBytes = Encoding.ASCII.GetBytes("Sensor: " + number);

                udpClient.Send(sendBytes, sendBytes.Length, endpoint);
                

                Thread.Sleep(100);
            }
        }
    }
}
