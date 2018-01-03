using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise35NewVersion
{
    class ExerciseServer1
    {
        private IPAddress ip;
        private int port;
        private bool stop = false;

        public ExerciseServer1(int port)
        {
            ip = IPAddress.Parse("127.0.0.1");
            this.port = port; 
        }

        public void Run()
        {
            Console.WriteLine("Server has started on port " + port);

            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            while (!stop)
            {
                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Incoming query from " + socket.RemoteEndPoint);

                ClientHandler client = new ClientHandler(socket);
                Thread clientThread = new Thread(client.RunClient);
                clientThread.Start();
            }
        }
    }
}
