using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise35NewVersion
{
    class ServerApp
    {
        static void Main(string[] args)
        {
            ExerciseServer1 server = new ExerciseServer1(12000);
            server.Run();
        }
    }
}
