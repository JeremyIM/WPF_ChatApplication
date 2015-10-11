using CommunicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wpfChatApplication.ViewModel
{
    public class ChatViewModel : BaseViewModel
    {
        private const string IPADDRESS = "127.0.0.1";
        private const int PORT = 8080;

        Client client;
        Thread receiver;


        #region Constructor
        public ChatViewModel()
        {
            InitializeCommands();
        }
        #endregion

        #region Commands

        private void InitializeCommands()
        {

        }


        private void Connect()
        {
        }

        private void Client_MessageRecieved(MessageRecievedEventArgs msg)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        #endregion

        private void RecieveMessage(MessageRecievedEventArgs mr)
        {
        }




    }
}
