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
    public partial class EditAgentAccount : Form
    {
        public string username, password;
        public int accID;
        public EditAgentAccount()
        {
            InitializeComponent();
        }
        public EditAgentAccount(string username, string password, int accountID)
        {
            this.username = username;
            this.password = password;
            accID = accountID;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void EditAgentAccount_Load(object sender, EventArgs e)
        {

        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            if (usernameText.Text.Length < 4)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Invalid Username.";
            }
            else if (usernameText.Text == "")
            {
                labelUsernameValid.Text = "";
            }
            else
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelUsernameValid.Text = "Valid Username.";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            if (passwordText.Text.Length < 8)
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.Red;
                labelPasswordValid.Text = "Invalid Password.";
            }
            else if (passwordText.Text == "")
            {
                labelPasswordValid.Text = "";
            }
            else
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelPasswordValid.Text = "Valid Password.";
            }
        }

        private void passwordText2_TextChanged(object sender, EventArgs e)
        {
            if (passwordText2.Text != passwordText.Text)
            {
                labelPassword2Valid.ForeColor = System.Drawing.Color.Red;
                labelPassword2Valid.Text = "Password not Confirmed.";
            }
            else if (passwordText2.Text == "")
            {
                labelPassword2Valid.Text = "";
            }
            else
            {
                labelPassword2Valid.ForeColor = System.Drawing.Color.LimeGreen;
                labelPassword2Valid.Text = "Password Confirmed";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (passwordText.Text.Length < 8)
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.Red;
                labelPasswordValid.Text = "Enter a Valid Password.";
                flag = true;
            }

            if (passwordText2.Text != passwordText.Text)
            {
                labelPassword2Valid.ForeColor = System.Drawing.Color.Red;
                labelPassword2Valid.Text = "Password not Confirmed.";
                flag = true;
            }

            if (!flag)
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("update Accounts set password = '" + passwordText.Text + "' where username = '" + username + "'", con);
                    cmd.ExecuteNonQuery();
                    passwordText.Text = "";
                    labelPassword2Valid.Text = "";
                    labelPasswordValid.Text = "";
                    passwordText2.Text = "";
                    MessageBox.Show("Password Updated Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameText.Text.Length < 4)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Enter a Valid Username.";
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Accounts where username = '" + usernameText.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Username Already Exists!");
                    con.Close();
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Accounts set username = '" + usernameText.Text + "' where username = '" + username + "'", con);
                        cmd.ExecuteNonQuery();
                        username = usernameText.Text;
                        usernameText.Text = "";
                        labelUsernameValid.Text = "";
                        MessageBox.Show("Username Updated Successfully!");
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        con.Close();
                    }
                }
            }
            
        }
    }
}
