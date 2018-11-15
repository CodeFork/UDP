using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPSensorSender
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
                int nox = rnd.Next(15, 215);
                double co = (double) (rnd.Next(132465, 965343)) / 100000.00;
                int c = rnd.Next(1, 3);
                string level = "";

                switch (c)
                {
                    case 1:
                        level = "Low";
                        break;
                    case 2:
                        level = "Medium";
                        break;
                    case 3:
                        level = "High";
                        break;
                }

                string data = "Pollution sensor v.1.1. \r\n" +
                "Location: Maglegaardsvej \r\n" +
                $"Time: {DateTime.UtcNow} \r\n" +
                $"CO: {co} \r\n" +
                $"NOx: {nox} \r\n" +
                $"Particle level: {level} \r\n";

                Console.WriteLine(data);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(data);

                udpClient.Send(sendBytes, sendBytes.Length, endpoint);
                

                Thread.Sleep(2000);
            }
        }
    }
}
