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
    public partial class EditManagerAccount : Form
    {
        public string username, password;
        public EditManagerAccount()
        {
            InitializeComponent();
        }
        public EditManagerAccount(string username, string password)
        {
            this.username = username;
            this.password = password;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
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

        
        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (p1.Text.Length < 8)
            {
                lb1.ForeColor = System.Drawing.Color.Red;
                lb1.Text = "Enter a Valid Password.";
                flag = true;
            }

            if (p2.Text != p1.Text)
            {
                lb2.ForeColor = System.Drawing.Color.Red;
                lb2.Text = "Password not Confirmed.";
                flag = true;
            }

            if (!flag)
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("update Accounts set password = '" + p1.Text + "' where username = '" + username + "'", con);
                    cmd.ExecuteNonQuery();
                    p1.Text = "";
                    lb2.Text = "";
                    lb1.Text = "";
                    p2.Text = "";
                    con.Close();
                    MessageBox.Show("Password Updated Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
            }
        }


        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void passwordText_TextChanged_1(object sender, EventArgs e)
        {
            if (p1.Text.Length < 8)
            {
                lb1.ForeColor = System.Drawing.Color.Red;
                lb1.Text = "Invalid Password.";
            }
            else if (p1.Text == "")
            {
                lb1.Text = "";
            }
            else
            {
                lb1.ForeColor = System.Drawing.Color.LimeGreen;
                lb1.Text = "Valid Password.";
            }
        }

        private void passwordText2_TextChanged_1(object sender, EventArgs e)
        {
            if (p2.Text != p1.Text)
            {
                lb2.ForeColor = System.Drawing.Color.Red;
                lb2.Text = "Password not Confirmed.";
            }
            else if (p2.Text == "")
            {
                lb2.Text = "";
            }
            else
            {
                lb2.ForeColor = System.Drawing.Color.LimeGreen;
                lb2.Text = "Password Confirmed";
            }
        }

        private void EditManagerAccount_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to permanently delete this account?";
            string title = "Confirmation Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Managers where username = '" + username + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from Accounts where username = '" + username + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Deleted Successfully!");
                this.Owner.Owner.Show();
                this.Owner.Close();
                con.Close();
            }
            else
            {
                
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                con.Close();
            }

        }
    }
}
