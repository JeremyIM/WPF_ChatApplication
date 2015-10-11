using System;

namespace CommunicationLibrary
{
    public delegate void MessageRecievedDelegate(MessageRecievedEventArgs msg);

    public class MessageRecievedEventArgs : EventArgs
    {
        string message;

        public MessageRecievedEventArgs(string value)
        {
            message = value;
        }

        public string Message
        {
            get { return message; }
        }
    }
}
