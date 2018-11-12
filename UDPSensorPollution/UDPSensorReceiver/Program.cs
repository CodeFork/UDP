using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSensorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(11111);
            IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Any, 11111);
            double totalSum = 0;

            while (true)
            {
                Byte[] receiveBytes = udp.Receive(ref RemoteEndPoint);

                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                if (receivedData.ToLower().Contains("stop"))
                {
                    break;
                }

                var dataLines = receivedData.Split("\r\n");
                var co = dataLines[3].Split(" ");
                var coValue = double.Parse(co[1]);
                var nox = dataLines[4].Split(" ");
                var noxValue = double.Parse(nox[1]);

                Console.WriteLine("co: " + coValue + ", nox: " + noxValue);
                totalSum = totalSum + (coValue + noxValue);
            }
            Console.Clear();
            Console.WriteLine($"Sum of values: {totalSum}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
