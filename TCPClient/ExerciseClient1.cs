using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class ExerciseClient1
    {
        private string ip;
        private int port;

        public ExerciseClient1(int port)
        {
            ip = "127.0.0.1";
            this.port = port;
        }

        public void Run()
        {
            TcpClient server = new TcpClient(ip, port);

            NetworkStream stream = server.GetStream();
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter(stream);

            Console.WriteLine(sr.ReadLine());

            string userInput = Console.ReadLine();

            while(userInput.ToLower() != "exit")
            {
                sw.WriteLine(userInput);
                sw.Flush();
                
                Console.WriteLine(sr.ReadLine());

                userInput = Console.ReadLine();
            }

            sw.Close();
            sr.Close();
            stream.Close();
            server.Close();

        }
    }
}
