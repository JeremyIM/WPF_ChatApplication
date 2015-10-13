using Microsoft.Practices.Unity;
using System.Windows;
using wpfChatApplication.View;

namespace wpfChatApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void App_Startup(object sender, StartupEventArgs e)
        {
            UnityContainer _container = new UnityContainer();
            ChatWindow window = _container.Resolve<ChatWindow>();
            window.Show();
        }
    }
}
