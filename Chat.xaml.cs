using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MesRush
{
    /// <summary>
    /// Логика взаимодействия для Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private TCPClient _tcpClient;

        public Chat()
        {
            InitializeComponent();
            _tcpClient = new TCPClient();
            Task.Run(() => _tcpClient.RecieveMessage());
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            var a = txt.Text;
            if (a == "/disconnect")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                allMessages.Items.Add(txt.Text);
                _tcpClient.SendMessage(txt.Text);
                txt.Clear();
            }
        }

        private void VixodButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
