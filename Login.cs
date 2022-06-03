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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");


        private void LoginBTN_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (usernameText.Text == "")
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Enter a Username.";
                flag = true;
            }
            if (passwordText.Text == "")
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.Red;
                labelPasswordValid.Text = "Enter a Password.";
                flag = true;
            }
            if (roleBox.Text == "")
            {
                labelRoleValid.ForeColor = System.Drawing.Color.Red;
                labelRoleValid.Text = "Select a Role.";
                flag = true;
            }

            if (!flag)
            {
                con.Open();
                string query1 = "select username from Accounts where username = '" + usernameText.Text + "' and password = '" + passwordText.Text + "'";
                string query2 = "select password from Accounts where username = '" + usernameText.Text + "' and password = '" + passwordText.Text + "'";
                string query3 = "select username from Managers where username = '" + usernameText.Text + "'";
                string query4 = "select username from Agents where username = '" + usernameText.Text + "'";
                string query5 = "select agentID from Agents where username = '" + usernameText.Text + "'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                if (cmd.ExecuteScalar() != null && cmd2.ExecuteScalar() != null)
                {
                    if (roleBox.Text == "Manager")
                    {
                        cmd = new SqlCommand(query3, con);
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Invalid Username or Password.");
                            usernameText.Text = "";
                            passwordText.Text = "";
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login Successful!");
                            con.Close();
                            ManagerMenu menu = new ManagerMenu(usernameText.Text, passwordText.Text);
                            usernameText.Text = "";
                            passwordText.Text = "";
                            menu.Owner = this;
                            menu.Show();
                            this.Hide();
                        }
                    }

                    else if (roleBox.Text == "Agent")
                    {
                        cmd = new SqlCommand(query4, con);
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Invalid Username or Password.");
                            usernameText.Text = "";
                            passwordText.Text = "";
                            con.Close();
                        }
                        else
                        {
                            cmd = new SqlCommand(query5, con);
                            int accID = Convert.ToInt32(cmd.ExecuteScalar());
                            MessageBox.Show("Login Successful!");
                            con.Close();
                            AgentMenu menu = new AgentMenu(usernameText.Text, passwordText.Text, accID);
                            usernameText.Text = "";
                            passwordText.Text = "";
                            menu.Owner = this;
                            menu.Show();
                            this.Hide();
                        }
                    }
                    
                    else
                    {
                        MessageBox.Show("Invalid Username or Password.");
                        usernameText.Text = "";
                        passwordText.Text = "";
                        con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                    usernameText.Text = "";
                    passwordText.Text = "";
                    con.Close();
                }
            }
            
        }

        private void QuitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitPic_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginPic_Click(object sender, EventArgs e)
        {
            LoginBTN_Click(sender, e);
        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            if (usernameText.Text != "")
            {
                labelUsernameValid.Text = "";
            }
        }

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roleBox.Text != "")
            {
                labelRoleValid.Text = "";
            }
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            if (passwordText.Text != "")
            {
                labelPasswordValid.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
