using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankSystemForms
{
    public partial class ManageAccounts : Form
    {
        public int tempID;
        public string accUsername;
        public ManageAccounts()
        {
            InitializeComponent();
            displayClients();
            displayAgents();
            displayTrans();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void displayClients()
        {
            con.Open();
            string query = "select clients.*, Accounts.password, Accounts.openDate from clients inner join accounts on clients.username = accounts.username";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AccountDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void displayAgents()
        {
            con.Open();
            string query = "select agents.*, Accounts.password, Accounts.openDate from agents inner join accounts on agents.username = accounts.username";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void displayTrans()
        {
            con.Open();
            string query = "select * from transactions";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            transDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void ManageAccounts_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tempID = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
                accUsername = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = tempID + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tempID == 0)
            {
                MessageBox.Show("Select an Account to Remove.");
            }
            else
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("delete from Clients where clientID = " +tempID, con);
                    SqlCommand cmd2 = new SqlCommand("delete from Accounts where username = '" + accUsername + "'", con);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted Successfully!");
                    con.Close();
                    tempID = 0;
                    textBox3.Text = "";
                    displayClients();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (tempID == 0)
            {
                MessageBox.Show("Select an Account to Remove.");
            }
            else
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("delete from Agents where AgentID = " + tempID, con);
                    SqlCommand cmd2 = new SqlCommand("delete from Accounts where username = '" +accUsername+"'", con);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted Successfully!");
                    con.Close();
                    tempID = 0;
                    textBox1.Text = "";
                    displayAgents();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CancelBTN_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void AccountDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tempID = Convert.ToInt32(AccountDGV.SelectedRows[0].Cells[0].Value.ToString());
                accUsername = AccountDGV.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = tempID + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("truncate table transactions", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Transactions Log Deleted Successfully!");
            displayTrans();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void labelEnternewcust_Click(object sender, EventArgs e)
        {

        }
    }
}
