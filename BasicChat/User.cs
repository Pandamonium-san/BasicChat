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

namespace BasicChatServer
{
    /// <summary>
    /// Represents a connected user from a client.
    /// </summary>
    public class User
    {
        static int anonID = 0;

        ServerForm serverForm;
        Socket socket;
        NetworkStream nwStream;
        BinaryReader reader;
        BinaryWriter writer;

        public bool Disconnected { get; set; }
        public string Name { get; private set; }

        public User(Socket socket, ServerForm form)
        {
            this.socket = socket;
            this.serverForm = form;
            this.nwStream = new NetworkStream(socket);
            reader = new BinaryReader(nwStream);
            writer = new BinaryWriter(nwStream);

            ReceiveName();
        }

        /// <summary>
        /// Reads a string from the network stream and sets it as this user's name.
        /// </summary>
        public void ReceiveName()
        {
            Name = reader.ReadString();
            if (Name == null || Name == "")
            {
                Name = "Anon" + anonID++.ToString();
            }
        }

        /// <summary>
        /// Reads from the network stream continously. If there is no data to read, the thread will block.
        /// If data is unable to be read, checks whether socket is still connected.
        /// </summary>
        /// <param name="obj"></param>
        public void Run(object obj)
        {
            while (!Disconnected)
            {
                try
                {
                    string received = reader.ReadString();
                    HandleReceivedMsg(received);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unable to read from stream: " + ex.Message);
                }

                //Check whether connection is still active.
                if (!Disconnected && !IsSocketConnected(socket))
                    CloseConnection();
            }
        }

        /// <summary>
        /// Parses the string read from the network stream and takes appropriate action.
        /// </summary>
        /// <param name="received">Message to handle.</param>
        private void HandleReceivedMsg(string received)
        {
            string[] strings = received.Split(new char[]{' '}, 3, StringSplitOptions.RemoveEmptyEntries);

            if (strings[0] == "/whisper" && strings.Count() == 3)
            {
                serverForm.MessageUser(strings[2], strings[1], this);
            }
            else
                serverForm.MessageAllUsers(Name + ">> " + received);
        }

        /// <summary>
        /// Send a message to the client that this user represents.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public void SendMessage(string message)
        {
            if (!Disconnected && !IsSocketConnected(socket))
            {
                CloseConnection();
                return;
            }
            if (!Disconnected)
                writer.Write(message);
        }

        /// <summary>
        /// Closes the socket and marks this user as disconnected.
        /// </summary>
        private void CloseConnection()
        {
            if (Disconnected)
                return;
            socket.Close();
            Disconnected = true;
            serverForm.MessageAllUsers("?left " + Name);
            serverForm.MessageAllUsers(Name + " disconnected.");
        }

        /// <summary>
        /// Polls the client and determines whether a socket is still connected.
        /// </summary>
        /// <param name="s">Socket to test.</param>
        private static bool IsSocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if ((part1 && part2) || !s.Connected)
                return false;
            else
                return true;
        }
    }
}
