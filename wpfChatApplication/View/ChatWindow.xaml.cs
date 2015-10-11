using System.Windows;
using wpfChatApplication.ViewModel;

namespace wpfChatApplication.View
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow(ChatViewModel cVM)
        {
            InitializeComponent();
            DataContext = cVM;
        }
    }
}
