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
    public partial class ManagerMenu : Form
    {
        public string username, password;
        public ManagerMenu()
        {
            InitializeComponent();
        }
        public ManagerMenu(string un, string pw)
        {
            username = un;
            password = pw;
            InitializeComponent();
        }
        private void ManagerMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void NewAgent_Click(object sender, EventArgs e)
        {
            NewAgentManagerAccount newAcc = new NewAgentManagerAccount();
            newAcc.Owner = this;
            newAcc.Show();
            this.Hide();
        }

        private void buttonCreditAccount_Click(object sender, EventArgs e)
        {
            EditManagerAccount ed = new EditManagerAccount(username, password);
            ed.Owner = this;
            ed.Show();
            this.Hide();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ManageAccounts m = new ManageAccounts();
            m.Owner = this;
            m.Show();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            buttonCreditAccount_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login temp = new Login();
            temp.Show();
            this.Close();
        }
    }
}
