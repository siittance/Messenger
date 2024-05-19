using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MesRush
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Socket socket;
        public MainWindow()
        {
            InitializeComponent();
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //}

        private void ConnectChatButton(object sender, RoutedEventArgs e)
        {
            string textBoxVvodIP = IP.Text;
            string textBoxVvod = Client_Name.Text;

            if (string.IsNullOrEmpty(textBoxVvodIP) || !IsValidIpAddress(textBoxVvodIP))
            {
                MessageBox.Show("Пожалуйста, введите корректный IP-адрес");
                return;
            }

            if (string.IsNullOrEmpty(textBoxVvod))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя");
                return;
            }

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var IP_Adress = IP.Text;
            socket.Connect(IP_Adress, 8888);
            Chat chat = new Chat();
            chat.Show();
            this.Close();
        }

        private bool IsValidIpAddress(string ipAddress)
        {
            string pattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

            return Regex.IsMatch(ipAddress, pattern);
        }

        private void CreateNewChatClick(object sender, RoutedEventArgs e)
        {
            CheckTextBoxClientName();
        }

        private void CheckTextBoxClientName()
        {
            string textBoxVvod = Client_Name.Text;
            
             if (string.IsNullOrEmpty(textBoxVvod))
             {
                MessageBox.Show("Пожалуйста, введите имя пользователя");
             }
        }
    }
}