using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCPReciever
{
    class TCPReciever
    {
        string server;
        int port;
        TcpListener listener;

        public TCPReciever(string server, int port)
        {
            this.server = server;
            this.port = port;
            this.listener = null;
        }

        public void listen()
        {
            try
            {
                IPAddress addr = IPAddress.Parse(this.server);
                this.listener = new TcpListener(addr, this.port);

                this.listener.Start();

                byte[] buf = new byte[1024];
                string message = null;

                while (true)
                {
                    Console.WriteLine("接続待ち...");
                    using (TcpClient client = this.listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        Console.WriteLine("接続完了！");
                        int i;
                        while ((i = stream.Read(buf, 0, buf.Length)) != 0)
                        {
                            message = System.Text.Encoding.ASCII.GetString(buf, 0, i);
                            Console.WriteLine("受信文字列：{0}", message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.listener.Stop();
            }
        }
    }
}
