using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Number_sender
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.24.231"); //
            UdpClient udpClient = new UdpClient("192.168.24.231", 7011);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 7011); //
            //udpClient.Connect(RemoteIpEndPoint); //

            Console.Write("Press any key to start...");
            Console.ReadKey();

            while(true)
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 10);

                Byte[] sendBytes = Encoding.ASCII.GetBytes("Sensor: " + number);

                udpClient.Send(sendBytes, sendBytes.Length); //, RemoteEndPoint);

                Thread.Sleep(100);
            }

        }
    }
}