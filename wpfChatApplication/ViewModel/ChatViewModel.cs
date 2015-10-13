using CommunicationLibrary;
using System.Threading;

namespace wpfChatApplication.ViewModel
{
    public class ChatViewModel : BaseViewModel
    {
        private const string IPADDRESS = "127.0.0.1";
        private const int PORT = 8080;
        private string UserName = "User";

        Client _client;
        Thread _receiver;

        #region Constructor
        public ChatViewModel(Client client)
        {
            InitializeCommands();
            _client = client;
        }
        #endregion

        #region Commands

        public RelayCommand UserSend { get; internal set; }
        public RelayCommand UserConnect { get; internal set; }
        private void InitializeCommands()
        {
            UserSend = new RelayCommand(SendExecute, CanSend);
            UserConnect = new RelayCommand(ConnectExecute, CanConnect);
        }

        /// <summary>
        /// This needs additional work
        /// </summary>
        private void SendExecute()
        {
            _client.send(UserMessage);
            ChatLog += string.Format("{0} : {1}\n", UserName, UserMessage);
            UserMessage = string.Empty;
        }

        public bool CanSend()
        {
            if (_client != null && _client.Connected)
                return true;
            else
                return false;
        }

        private void ConnectExecute()
        {
            _client.Connected = _client.connect(IPADDRESS, PORT);
            _client.MessageRecieved += new MessageRecievedDelegate(RecieveMessage);

            if (_client.Connected)
            {
                ChatLog += "Connection Successfull \n";
                RecieverThreadStart();
            }
            else
            {
                ChatLog += "Failed to Connect \n";
            }
        }

        private bool CanConnect()
        {
            if (_client == null || !_client.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Properties
        private string _userMessage;
        public string UserMessage
        {
            get
            {
                return _userMessage;
            }
            set
            {
                _userMessage = value;
                OnPropertyChanged("UserMessage");
            }
        }

        private string _chatLog;
        public string ChatLog
        {
            get
            {
                return _chatLog;
            }
            set
            {
                _chatLog = value;
                OnPropertyChanged("ChatLog");
            }
        }

        #endregion

        private void RecieverThreadStart()
        {
            _receiver = new Thread(new ThreadStart(_client.recieve));
            _receiver.Start();
        }

        private void RecieveMessage(MessageRecievedEventArgs mr)
        {
            ChatLog += string.Format("Server : {0}", mr.Message);
        }
    }
}
