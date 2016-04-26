//Henrik Phan, AE3413
//Malmö Högskola
//2016-01-09
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicChatServer
{
    public partial class ServerForm : Form
    {
        List<User> users;
        TcpListener listener;
        object lockObj = new object();

        delegate void DisplayDelegate(string message);
        delegate void Refresher();

        public ServerForm()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            users = new List<User>();

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 50000);
                listener.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                System.Environment.Exit(1);
            }

            txBoxLog.AppendText("Server started. \n");
            txBoxLog.AppendText("Listening on port 50000 \n");
            Thread t = new Thread(new ThreadStart(Listen));
            t.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txBoxMsg.TextLength == 0)
                return;
            MessageAllUsers("Server -> " + txBoxMsg.Text);
            txBoxMsg.Clear();
        }

        /// <summary>
        /// Allows user to press enter to send.
        /// </summary>
        private void txBoxMsg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Listens for incoming connections continously.
        /// </summary>
        private void Listen()
        {
            while (true)
            {
                //This method blocks while waiting for an incoming connection.
                Socket socket = listener.AcceptSocket();

                User user = new User(socket, this);
                SendUserList(user);
                users.Add(user);
                RefreshListBox();
                ThreadPool.QueueUserWorkItem(user.Run);
                MessageAllUsers("?joined " + user.Name);
                MessageAllUsers(user.Name + " connected.");
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Sends a message to all connected users.
        /// </summary>
        /// <param name="message">Message to send.</param>
        public void MessageAllUsers(string message)
        {
            DisplayMessage(message);
            lock (lockObj)
            {
                for (int i = 0; i < users.Count; i++)
                    users[i].SendMessage(message);
                RemoveDisconnected();
            }
        }

        /// <summary>
        /// Sends a message to a specific user.
        /// </summary>
        /// <param name="message">Message to send.</param>
        /// <param name="name">Name of recipient.</param>
        /// <param name="sender">User that sent the message.</param>
        public void MessageUser(string message, string name, User sender)
        {
            lock (lockObj)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Name == name)
                    {
                        users[i].SendMessage(name + "<-" + sender.Name + ' ' + message);
                        sender.SendMessage(sender.Name + "->" + name + ' ' + message);
                        return;
                    }
                }
                sender.SendMessage("User \"" + name + "\" not found");
            }
        }

        /// <summary>
        /// Sends a list of users currently connected.
        /// </summary>
        /// <param name="recipient"></param>
        private void SendUserList(User recipient)
        {
            lock (lockObj)
            {
                foreach (User u in users)
                    recipient.SendMessage("?joined " + u.Name);
            }
        }

        /// <summary>
        /// Removes users that have disconnected.
        /// </summary>
        private void RemoveDisconnected()
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Disconnected)
                {
                    users.RemoveAt(i);
                    RefreshListBox();
                    --i;
                }
            }
        }

        /// <summary>
        /// Appends valid text to the log.
        /// </summary>
        /// <param name="message">Text to append.</param>
        public void DisplayMessage(string message)
        {
            if (InvokeRequired)
                Invoke(new DisplayDelegate(DisplayMessage), message);
            else
            {
                if (message.StartsWith("?"))
                    return;
                txBoxLog.AppendText(message + '\n');
            }
        }

        public void RefreshListBox()
        {
            if (InvokeRequired)
            {
                Invoke(new Refresher(RefreshListBox));
            }
            else
            {
                lstBoxUsers.DataSource = null;
                lstBoxUsers.DataSource = users;
                lstBoxUsers.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// Stops error sound when pressing escape or enter.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == Keys.Enter)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
