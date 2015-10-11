using System.Net.Sockets;
using System.Text;

namespace CommunicationLibrary
{
    public abstract class BaseMessaging
    {
        protected TcpClient client;
        protected TcpListener server;
        protected NetworkStream stream;

        public event MessageRecievedDelegate MessageRecieved;

        abstract public bool connect(string serverip, int port);
        abstract public void terminate();

        private volatile bool connected = false;

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public void send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public void recieve()
        {
            string responseData = string.Empty;
            while (connected)
            {
                while (stream.DataAvailable)
                {
                    byte[] data = new byte[256];

                    int bytes = stream.Read(data, 0, data.Length);
                    responseData += Encoding.ASCII.GetString(data, 0, bytes);

                    if (responseData.Length > 0)
                    {
                        MessageRecieved(new MessageRecievedEventArgs(string.Format("Server:{0}", responseData)));
                        responseData = string.Empty;
                    }
                }
            }
        }
    }
}
