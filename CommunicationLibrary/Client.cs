using System;
using System.Net.Sockets;

namespace CommunicationLibrary
{
    public class Client : BaseMessaging
    {
        public Client() { }

        public override bool connect(string serverip, int port)
        {
            try
            {
                client = new TcpClient(serverip, port);
                stream = client.GetStream();
            }
            catch (Exception error)
            {
                return false;
            }
            return true;
        }

        public override void terminate()
        {
            try
            {
                stream.Close();
                client.Close();
            }
            catch (System.Exception error)
            {

            }
        }
    }
}
