//Henrik Phan, AE3413
//Malmö Högskola
//2016-01-09
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicChatClient
{
    class Client
    {
        ClientForm clientForm;
        TcpClient client;
        NetworkStream clientStream;
        BinaryReader reader;
        BinaryWriter writer;

        public List<string> Users { get; set; }
        public bool Exit { get; set; }

        public Client(ClientForm clientForm, string ip, int port, string name)
        {
            this.clientForm = clientForm;
            client = new TcpClient(ip, port);
            clientForm.DisplayMessage("Connected to server!");
            clientStream = new NetworkStream(client.Client);
            reader = new BinaryReader(clientStream);
            writer = new BinaryWriter(clientStream);

            Users = new List<string>();
            SendName(name);
        }

        /// <summary>
        /// Sends a message to the server containing username.
        /// </summary>
        private void SendName(string name)
        {
            writer.Write(name);
        }

        /// <summary>
        /// Reads from the network stream continously.
        /// </summary>
        public void Run()
        {
            while (!Exit)
            {
                try
                {
                    string received = reader.ReadString();
                    HandleReceivedMsg(received);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Connection lost");
                    System.Environment.Exit(1);
                }
            }
        }

        /// <summary>
        /// Parses the string read from the network stream and takes appropriate action.
        /// </summary>
        /// <param name="received">Message to handle.</param>
        private void HandleReceivedMsg(string received)
        {
            string[] strings = received.Split();

            if (strings[0] == "?joined")
            {
                Users.Add(strings[1]);
                clientForm.RefreshListBox();
            }
            else if (strings[0] == "?left")
            {
                Users.Remove(strings[1]);
                clientForm.RefreshListBox();
            }
            else
                clientForm.DisplayMessage(received);
        }

        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public void SendMessage(string message)
        {
            try
            {
                writer.Write(message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Connection lost");
                System.Environment.Exit(1);
            }
        }
    }
}
