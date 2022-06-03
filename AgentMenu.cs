using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystemForms
{
    public partial class AgentMenu : Form
    {
        public AgentMenu()
        {
            InitializeComponent();
        }

        public string username, password;
        public int accID;
        public AgentMenu(string username, string password, int accID)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.accID = accID;
        }
        private void NewAgent_Click(object sender, EventArgs e)
        {
            NewClientAccount f1 = new NewClientAccount();
            f1.Owner = this;
            f1.Show();
            this.Hide();
        }

        private void buttonCreditAccount_Click(object sender, EventArgs e)
        {
            EditAgentAccount edit = new EditAgentAccount(username, password, accID);
            edit.Owner = this;
            edit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ManageTransactions tran = new ManageTransactions(username);
            tran.Owner = this;
            tran.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NewAgent_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginButton_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            buttonCreditAccount_Click(sender, e);
        }

        private void AgentMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
