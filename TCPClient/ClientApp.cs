using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class ClientApp
    {
        static void Main(string[] args)
        {
            ExerciseClient1 client = new ExerciseClient1(12000);
            client.Run();
        }
    }
}
