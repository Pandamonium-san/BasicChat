//Henrik Phan, AE3413
//Malmö Högskola
//2016-01-09
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicChatClient
{
    public partial class ClientForm : Form
    {
        Thread tClient;
        Client client;

        delegate void DisplayDelegate(string message);
        delegate void Refresher();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void Start()
        {
            client = new Client(this, txBoxIP.Text, (int)numPort.Value, txBoxName.Text);

            lstBoxUsers.DataSource = client.Users;
            ThreadStart tStart = new ThreadStart(client.Run);
            tClient = new Thread(client.Run);
            tClient.Start();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Start();

                //Enable relevant UI elements, disable obsolete ones.
                {
                    btnConnect.Enabled = false;
                    btnSend.Enabled = true;
                    txBoxMsg.Enabled = true;
                    txBoxName.ReadOnly = true;
                    txBoxIP.ReadOnly = true;
                    numPort.ReadOnly = true;
                    numPort.Increment = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect: " + ex.Message, "Error");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txBoxMsg.TextLength == 0)
                return;
            client.SendMessage(txBoxMsg.Text);
            txBoxMsg.Clear();
        }

        /// <summary>
        /// Appends text to the log.
        /// </summary>
        /// <param name="message">Text to append.</param>
        public void DisplayMessage(string message)
        {
            if (InvokeRequired)
                Invoke(new DisplayDelegate(DisplayMessage), message);
            else
            {
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
                lstBoxUsers.DataSource = client.Users;
            }
        }

        /// <summary>
        /// Allows user to send by pressing enter.
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
        /// Allows user to whisper a specific client by double-clicking.
        /// </summary>
        private void lstBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txBoxMsg.Text.Length == 0 && lstBoxUsers.SelectedItem != null)
                txBoxMsg.AppendText("/whisper " + lstBoxUsers.SelectedItem.ToString() + " ");
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

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
