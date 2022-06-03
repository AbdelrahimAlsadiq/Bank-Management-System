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
    public partial class ManageTransactions : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        string username;
        private void reset()
        {
            balanceUNText.Text = "";
            textBox1.Text = "Account Balance";
            user.Text = "";
            amo.Text = "";
            fromUsername.Text = "";
            toUsername.Text = "";
            transferAmount.Text = "";
        }
        private void checkBalance()
        {
            con.Open();
            string query = "select balance from clients where username = '" + balanceUNText.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteScalar() == null)
            {
                MessageBox.Show("Account is Not Found.");
                con.Close();

            }
            else
            {
                textBox1.Text = cmd.ExecuteScalar().ToString() + "\tEGP";
            }
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
            AgentsDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        public ManageTransactions()
        {
            InitializeComponent();
            displayTrans();
        }
        public ManageTransactions(string username)
        {
            this.username = username;
            InitializeComponent();
            displayTrans();

        }
        private void ClientMenu_Load(object sender, EventArgs e)
        {

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (balanceUNText.Text == "")
            {
                MessageBox.Show("Enter a Username.");
                textBox1.Text = "Account Balance";
            }
            else
            {
                checkBalance();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                MessageBox.Show("Enter A Username.");
            }
            else if (amo.Text == "")
            {
                MessageBox.Show("Enter A Balance Value.");
            }
            else
            {
                con.Open();
                string query = "select balance from clients where username = '" + user.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Account is not Found.");
                    con.Close();
                }
                else
                {
                    int Balance = Convert.ToInt32(cmd.ExecuteScalar());
                    try
                    {
                        Balance += Convert.ToInt32(amo.Text);
                        cmd = new SqlCommand("update Clients set balance = " + Balance + " where username = '" + user.Text + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into Transactions(clientUsername, agentUsername, transDate, transType, amount) values (@c, @a, @t, @tt, @am)", con);
                        cmd.Parameters.AddWithValue("@c", user.Text);
                        cmd.Parameters.AddWithValue("@a", username);
                        cmd.Parameters.AddWithValue("@t", DateTime.Today);
                        cmd.Parameters.AddWithValue("@tt", "Deposit");
                        cmd.Parameters.AddWithValue("@am", amo.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Deposit Operation Done Successfully!");
                        reset();
                        displayTrans();
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Balance Value.");
                        con.Close();
                    }
                }
            }
        }

        private void WithdrawBTN_Click(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                MessageBox.Show("Enter A Username.");
            }
            else if (amo.Text == "")
            {
                MessageBox.Show("Enter A Balance Value.");
            }
            else
            {
                con.Open();
                string query = "select balance from clients where username = '" + user.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Account is not Found.");
                }
                else
                {
                    int Balance = Convert.ToInt32(cmd.ExecuteScalar());
                    try
                    {
                        Balance -= Convert.ToInt32(amo.Text);
                        if (Balance < 0)
                        {
                            MessageBox.Show("Insufficient Balance Value.");
                            con.Close();
                        }
                        else
                        {
                            cmd = new SqlCommand("update Clients set balance = " + Balance + " where username = '" + user.Text +"'", con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select clientID from Clients where username = '" + user + "'", con);
                            int clientID = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd = new SqlCommand("insert into Transactions(clientUsername, agentUsername, transDate, transType, amount) values (@c, @a, @t, @tt, @am)", con);
                            cmd.Parameters.AddWithValue("@c", user.Text);
                            cmd.Parameters.AddWithValue("@a", username);
                            cmd.Parameters.AddWithValue("@t", DateTime.Today);
                            cmd.Parameters.AddWithValue("@tt", "Withdraw");
                            cmd.Parameters.AddWithValue("@am", amo.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Withdraw Operation Done Successfully!");
                            reset();
                            displayTrans();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Balance Value.");
                        con.Close();
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fromUsername.Text == "")
            {
                MessageBox.Show("Enter (from) Username.");
            }
            else if (toUsername.Text == "")
            {
                MessageBox.Show("Enter (to) Username.");
            }
            else if (transferAmount.Text == "")
            {
                MessageBox.Show("Enter a Balance Value.");
            }
            else
            {
                con.Open();
                string query1 = "select balance from clients where username = '" + fromUsername.Text + "'";
                string query2 = "select balance from clients where username = '" + toUsername.Text + "'";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);

                if (cmd1.ExecuteScalar() == null || cmd2.ExecuteScalar() == null)
                {
                    MessageBox.Show("Eiter (from) or (to) or \nboth Accounts are not Found.");
                    con.Close();
                    return;
                }

                else
                {
                    int balance1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    int balance2 = Convert.ToInt32(cmd2.ExecuteScalar());

                    // first Account
                    int Balance1 = balance1;
                    try
                    {
                        Balance1 -= Convert.ToInt32(transferAmount.Text);
                        if (Balance1 < 0)
                        {
                            MessageBox.Show("Insufficient Balance Value.");
                            con.Close();
                            return;
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("update Clients set balance = " + Balance1 + " where username = '" + fromUsername.Text + "'", con);
                            cmd.ExecuteNonQuery();


                            // second account
                            int Balance2 = balance2 + Convert.ToInt32(transferAmount.Text);
                            cmd = new SqlCommand("update Clients set balance = " + Balance2 + " where username = '" + toUsername.Text + "'", con);
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd8 = new SqlCommand("insert into Transactions(clientUsername, agentUsername, transDate, transType, amount) values (@c, @a, @t, @tt, @am)", con);
                            cmd8.Parameters.AddWithValue("@c", fromUsername.Text);
                            cmd8.Parameters.AddWithValue("@a", username);
                            cmd8.Parameters.AddWithValue("@t", DateTime.Today);
                            cmd8.Parameters.AddWithValue("@tt", "Transfer");
                            cmd8.Parameters.AddWithValue("@am", transferAmount.Text);
                            cmd8.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Transfer Operation Done Successfully!");

                            reset();
                            displayTrans();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Balance Value.");
                        con.Close();
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WithdrawBTN_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button2_Click_1(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}