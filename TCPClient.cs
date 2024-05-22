using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MesRush
{
    internal class TCPClient
    {
        Socket socket;
        public TCPClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("26.244.168.67", 8888);
            Task.Run(() => RecieveMessage());
        }

        public async void SendMessage(string message)
        {
            var noliki = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(noliki, SocketFlags.None);
        }

        public async void RecieveMessage()
        {
            while (true)
            {
                byte[] noliki = new byte[1024];
                await socket.ReceiveAsync(noliki, SocketFlags.None);
                string message = Encoding.UTF8.GetString(noliki);
            }
        }
    }
}
