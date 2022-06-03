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
using System.Text.RegularExpressions;
namespace BankSystemForms
{
    public partial class NewAgentManagerAccount : Form
    {
        public NewAgentManagerAccount()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void NewAgentAccount_Load(object sender, EventArgs e)
        {

        }
        
        public static bool CheckEmail(string strEmail)
        {

            bool AtSignReached = false;
            bool DotReached = false;
            string strEmailname = "";
            string strEmailHost = "";
            string strEmailSuffix = "";


            foreach (var character in strEmail)
            {
                if (character.ToString() == " ")
                {
                    return false;
                }
                else if (character.ToString() == "@")
                {
                    AtSignReached = true;
                    if (strEmailname == "")
                    {

                        return false;
                    }

                }
                if (!AtSignReached)
                {
                    strEmailname += character;
                }

                if (AtSignReached && !DotReached)
                {
                    strEmailHost += character;
                }

                if (character.ToString() == ".")
                {
                    DotReached = true;

                }
                else if (DotReached)
                {
                    strEmailSuffix += character;

                    if (!Char.IsLetter(character))
                    {
                        return false;
                    }
                }
            }


            if (strEmail == "")
            {
                return false;

            }
            else
            {
                if (strEmailHost == "")
                {
                    return false;

                }
                if (!AtSignReached)
                {
                    return false;
                }

                if (!DotReached)
                {
                    return false;

                }

                return true;
            }


        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            ManagerMenu menu = new ManagerMenu();
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstNameText.Text = "";
            textBoxSurname.Text = "";
            phoneNumber.Text = "";
            AddressText.Text = "";
            usernameText.Text = "";
            passwordText.Text = "";
            textBoxEmail.Text = "";

            labelForenameInvalid.Text = "";
            labelSurnameInvalid.Text = "";
            labelEmailValid.Text = "";
            labelPNValid.Text = "";
            labelUsernameValid.Text = "";
            labelPasswordValid.Text = "";
            labelDepartmentValid.Text = "";
            labelRoleValid.Text = "";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string fname = firstNameText.Text;
            string lname = textBoxSurname.Text;
            string pn = phoneNumber.Text;
            string mail = textBoxEmail.Text;
            string addr = AddressText.Text;
            bool flag = false;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select username from Accounts where username = '" + usernameText.Text + "'", con);
            if (usernameText.Text.Length < 4)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Enter a Valid Username.";
                flag = true;
            }
            else if (cmd1.ExecuteScalar() != null)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Username Already Exists";
                flag = true;
            }
            con.Close();
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber.Text, "[^0-9+-]") || phoneNumber.Text.Length < 10)
            {
                labelPNValid.ForeColor = System.Drawing.Color.Red;
                labelPNValid.Text = "Enter A valid Phone Number.";
                flag = true;
            }
            if (passwordText.Text.Length < 8)
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.Red;
                labelPasswordValid.Text = "Enter a Valid Password.";
                flag = true;
            }
            if (roleBox.Text == "")
            {
                labelRoleValid.ForeColor = System.Drawing.Color.Red;
                labelRoleValid.Text = "Select a Role.";
                flag = true;
            }
            else if (roleBox.Text == "Manager" && departmentBox.Text == "")
            {
                labelDepartmentValid.ForeColor = System.Drawing.Color.Red;
                labelDepartmentValid.Text = "Select a Department.";
                flag = true;
            }
            if (!CheckEmail(mail))
            {
                labelEmailValid.ForeColor = System.Drawing.Color.Red;
                labelEmailValid.Text = "Enter a Valid Email.";
                flag = true;
            }
            if (fname.Length <= 0)
            {
                labelForenameInvalid.ForeColor = System.Drawing.Color.Red;
                labelForenameInvalid.Text = "Enter a Valid Firstname";
                flag = true;
            }
            if (lname.Length <= 0)
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.Red;
                labelSurnameInvalid.Text = "Enter a Valid Lastname";
                flag = true;
            }

            if (!flag && roleBox.Text == "Manager")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Accounts(username, password, openDate) values(@un, @pw, @od)", con);
                    cmd.Parameters.AddWithValue("@un", usernameText.Text);
                    cmd.Parameters.AddWithValue("@pw", passwordText.Text);
                    cmd.Parameters.AddWithValue("@od", DateTime.Today);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("select departmentID from Departments where name = '" + departmentBox.Text + "'", con);
                    int depID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand("insert into Managers(username, firstName, lastName, phoneNumber, email, address, departmentID) values('" + usernameText.Text + "', @fn, @ln, @pn, @em, @add, "+depID+")", con);
                    cmd.Parameters.AddWithValue("@fn", fname);
                    cmd.Parameters.AddWithValue("@ln", lname);
                    cmd.Parameters.AddWithValue("@pn", pn);
                    cmd.Parameters.AddWithValue("@em", mail);
                    cmd.Parameters.AddWithValue("@add", addr);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manager Account Created Successfully!");
                    button1_Click(sender, e);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (!flag && roleBox.Text == "Agent")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Accounts(username, password, openDate) values(@un, @pw, @od)", con);
                    cmd.Parameters.AddWithValue("@un", usernameText.Text.ToString());
                    cmd.Parameters.AddWithValue("@pw", passwordText.Text.ToString());
                    cmd.Parameters.AddWithValue("@od", DateTime.Today);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into Agents(username, firstName, lastName, phoneNumber, email, address) values('"+usernameText.Text+"', @fn, @ln, @pn, @em, @add)", con);
                    cmd.Parameters.AddWithValue("@fn", fname);
                    cmd.Parameters.AddWithValue("@ln", lname);
                    cmd.Parameters.AddWithValue("@pn", pn);
                    cmd.Parameters.AddWithValue("@em", mail);
                    cmd.Parameters.AddWithValue("@add", addr);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Agent Account Created Successfully!");
                    con.Close();
                    button1_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void firstNameText_TextChanged(object sender, EventArgs e)
        {
            string forenamenowhitespace = Regex.Replace(firstNameText.Text, @"\s+", "");
            if (!(forenamenowhitespace == ""))
            {
                labelForenameInvalid.ForeColor = System.Drawing.Color.LimeGreen;
                labelForenameInvalid.Text = "Valid Firstname.";
            }
            else if (firstNameText.Text == "")
            {
                labelForenameInvalid.Text = "";
            }
            else
            {
                labelForenameInvalid.ForeColor = System.Drawing.Color.Red;
                labelForenameInvalid.Text = "Invalid Firstname.";
            }
        }

        private void textBoxSurname_TextChanged_1(object sender, EventArgs e)
        {
            string surnamenowhitespace = Regex.Replace(textBoxSurname.Text, @"\s+", "");
            if (!(surnamenowhitespace == ""))
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.LimeGreen;
                labelSurnameInvalid.Text = "Valid Lastname.";
            }
            else if (textBoxSurname.Text == "")
            {
                labelSurnameInvalid.Text = "";
            }
            else
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.Red;
                labelSurnameInvalid.Text = "Invalid Lastname.";
            }

        }

        private void phoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber.Text, "[^0-9+-]") || phoneNumber.Text.Length < 10)
            {
                labelPNValid.ForeColor = System.Drawing.Color.Red;
                labelPNValid.Text = "Invalid Phone Number.";
            }
            else if (phoneNumber.Text == "")
            {
                labelPNValid.Text = "";
            }
            else
            {
                labelPNValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelPNValid.Text = "Valid Phone Number.";
            }
        }

        private void AddressText_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string InputEmail = textBoxEmail.Text;
            if (!CheckEmail(InputEmail))
            {
                labelEmailValid.ForeColor = System.Drawing.Color.Red;
                labelEmailValid.Text = "Invalid Email Address";
            }
            else if (textBoxEmail.Text == "")
            {
                labelEmailValid.Text = "";
            }
            else
            {
                labelEmailValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelEmailValid.Text = "Valid Email Address";
            }
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

        private void labelUsernameValid_Click(object sender, EventArgs e)
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

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roleBox.Text == "Agent")
            {
                labelRoleValid.Text = "";
                labelDepartmentValid.Text = "";
                departmentBox.Hide();
                department.Hide();
            }
            else
            {
                department.Show();
                departmentBox.Show();
            }
        }

        private void departmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentBox.Text != "")
            {
                labelDepartmentValid.Text = "";
            }
        }

        private void labelPasswordValid_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            buttonSubmit_Click(sender, e);
        }
    }
}
