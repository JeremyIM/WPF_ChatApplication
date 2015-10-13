using System.ComponentModel;

namespace wpfChatApplication.ViewModel
{
    /// <summary>
    /// CHANGE THIS JEREMY!
    /// Probably still needs changing...
    /// </summary>
    abstract public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
