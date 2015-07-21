using System;
using System.Collections.Generic;
using System.Text;

namespace TCPReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPReciever recv = new TCPReciever("127.0.0.1", 15000);
            recv.listen();
        }
    }
}
