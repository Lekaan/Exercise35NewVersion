using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercise35NewVersion
{
    class ClientHandler
    {
        private Socket clientSocket;

        public ClientHandler(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }

        public void RunClient()
        {
            NetworkStream stream = new NetworkStream(clientSocket);
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);

            sw.WriteLine("You have connected to the server...");
            sw.Flush();

            string command = sr.ReadLine();
            while(command != null)
                ExecuteCommand(command, sw);

            sw.Close();
            sr.Close();
            stream.Close();
            clientSocket.Close();
        }

        public void ExecuteCommand(string command, StreamWriter sw)
        {
            switch(command.ToLower())
            {
                case "hello server":
                    sw.WriteLine("Hello Client");
                    sw.Flush();
                    break;
                default:
                    sw.WriteLine("Unknown command");
                    sw.Flush();
                    break;
            }
        }
    }
}
