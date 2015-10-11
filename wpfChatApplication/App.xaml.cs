using System.Windows;
using wpfChatApplication.View;
using wpfChatApplication.ViewModel;

namespace wpfChatApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void App_Startup(object sender, StartupEventArgs e)
        {
            ChatWindow window = new ChatWindow(new ChatViewModel());
            window.Show();
        }
    }
}
