using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BankSystemForms
{
    public partial class NewClientAccount : Form
    {
        
        
        public NewClientAccount()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BankManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void CreateNewCustomerForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
        }

         

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string InputEmail = textBoxEmail.Text;
            if (!Client.CheckEmail(InputEmail))
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

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string fname = firstNameText.Text;
            string lname = textBoxSurname.Text;
            string gen = gender.Text;
            DateTime dob = dateTimePickerDOB.Value;
            string email = textBoxEmail.Text;
            string countr = countryBox.Text;
            string ssn = SSNText.Text;
            int inc = 0;
            string pn = phoneNumber.Text;
            int b = 0;
            string addr = AddressText.Text;
            bool flag = false;

            Client temp = new Client(fname, lname, gen, dob, email, countr, ssn, inc, pn, addr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select username from Accounts where username = '" + usernameText.Text + "'", con);
            if (usernameText.Text.Length < 4)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Enter a Valid Username.";
                flag = true;
            }
            else if (cmd.ExecuteScalar() != null)
            {
                labelUsernameValid.ForeColor = System.Drawing.Color.Red;
                labelUsernameValid.Text = "Username Already Exists";
                flag = true;
            }
            con.Close();
            if (passwordText.Text.Length < 4)
            {
                labelPasswordValid.ForeColor = System.Drawing.Color.Red;
                labelPasswordValid.Text = "Enter a Valid Password.";
                flag = true;
            }
            
            if (!(System.Text.RegularExpressions.Regex.IsMatch(incomeText.Text, "[^0-9]")) && incomeText.Text != "")
            {
                inc = int.Parse(incomeText.Text);

            }
            else
            {
                incomeValidLabel.ForeColor = System.Drawing.Color.Red;
                incomeValidLabel.Text = "Enter a Valid Income.";
                flag = true;
            }
            if (!(System.Text.RegularExpressions.Regex.IsMatch(balanceText.Text, "[^0-9]")) && balanceText.Text != "")
            {
                b = int.Parse(balanceText.Text);

            }
            else
            {
                labelBalanceValid.ForeColor = System.Drawing.Color.Red;
                labelBalanceValid.Text = "Enter a Valid Balance.";
                flag = true;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneNumber.Text, "[^0-9+-]") || phoneNumber.Text.Length < 10)
            {
                labelPNValid.ForeColor = System.Drawing.Color.Red;
                labelPNValid.Text = "Enter A valid Phone Number.";
                flag = true;
            }
            if (SSNText.Text.Length < 4 || System.Text.RegularExpressions.Regex.IsMatch(SSNText.Text, "[^0-9]"))
            {
                labelSSNValid.ForeColor = System.Drawing.Color.Red;
                labelSSNValid.Text = "Enter a Valid SSN.";
                flag = true;
            }
            if (temp.getsetForename == "invalid")
            {
                labelForenameInvalid.ForeColor = System.Drawing.Color.Red;
                labelForenameInvalid.Text = "Enter a Valid Firstname";
                flag = true;
            }
            if (temp.getsetSurname == "invalid")
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.Red;
                labelSurnameInvalid.Text = "Enter a Valid Lastname";
                flag = true;
            }
            if (temp.getsetEmail=="invalid")
            {
                labelEmailValid.ForeColor = System.Drawing.Color.Red;
                labelEmailValid.Text = "Enter a Valid Email Address";
                flag = true;
            }
            if (temp.getsetGender == "")
            {
                labelGenderInvalid.ForeColor = System.Drawing.Color.Red;
                labelGenderInvalid.Text = "Select a Gender.";
                flag = true;
            }

            if (temp.getsetCountry == "")
            {
                labelCountryValid.ForeColor = System.Drawing.Color.Red;
                labelCountryValid.Text = "Select a Country.";
                flag = true;
            }

            

            if (!flag)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Accounts(username, password, openDate) values(@un, @pw, @od)", con);
                    cmd.Parameters.AddWithValue("@un", usernameText.Text);
                    cmd.Parameters.AddWithValue("@pw", passwordText.Text);
                    cmd.Parameters.AddWithValue("@od", DateTime.Today);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into Clients(username, firstName, lastName, gender, email, country, SSN, phoneNumber, birthDate, income, balance, address) values('"+usernameText.Text+"', @fn, @ln, @g, @mail, @co, @ssn, @pn, @bd, @inc, @ba, @add)", con);
                    cmd.Parameters.AddWithValue("@fn", fname);
                    cmd.Parameters.AddWithValue("@ln", lname);
                    cmd.Parameters.AddWithValue("@g", gen);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@co", countr);
                    cmd.Parameters.AddWithValue("@ssn", ssn);
                    cmd.Parameters.AddWithValue("@pn", pn);
                    cmd.Parameters.AddWithValue("@bd", dob);
                    cmd.Parameters.AddWithValue("@inc", inc);
                    cmd.Parameters.AddWithValue("@ba", b);
                    cmd.Parameters.AddWithValue("@add", addr);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully!");
                    con.Close();
                    button1_Click(sender, e);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBoxForename_TextChanged(object sender, EventArgs e)
        {
            string forenamenowhitespace = Regex.Replace(firstNameText.Text, @"\s+" , "");
            if (!(forenamenowhitespace==""))
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

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            string surnamenowhitespace = Regex.Replace(textBoxSurname.Text, @"\s+", "");
            if (!(surnamenowhitespace == ""))
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.LimeGreen;
                labelSurnameInvalid.Text = "Valid Lastname.";
            }
            else
            {
                labelSurnameInvalid.ForeColor = System.Drawing.Color.Red;
                labelSurnameInvalid.Text = "Invalid Lastname.";
            }

        }

        private void CreateNewCustomerForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void labelEnternewcust_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(incomeText.Text, "[^0-9]") || incomeText.Text == "0")
            {
                incomeValidLabel.ForeColor = System.Drawing.Color.Red;
                incomeValidLabel.Text = "Invalid Income.";
            }

            else if (incomeText.Text == "")
            {
                incomeValidLabel.Text = "";
            }

            else
            {
                incomeValidLabel.ForeColor = System.Drawing.Color.LimeGreen;
                incomeValidLabel.Text = "Valid Income Value.";
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(gender.Text == ""))
            {
                labelGenderInvalid.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstNameText.Text = "";
            textBoxSurname.Text = "";
            gender.Text = "";
            dateTimePickerDOB.Value = DateTime.Today;
            textBoxEmail.Text = "";
            countryBox.Text = "";
            SSNText.Text = "";
            incomeText.Text = "";
            phoneNumber.Text = "";
            AddressText.Text = "";
            usernameText.Text = "";
            passwordText.Text = "";
            balanceText.Text = "";

            labelForenameInvalid.Text = "";
            labelSurnameInvalid.Text = "";
            incomeValidLabel.Text = "";
            labelCountryValid.Text = "";
            labelGenderInvalid.Text = "";
            labelEmailValid.Text = "";
            labelPNValid.Text = "";
            labelSSNValid.Text = "";
            labelUsernameValid.Text = "";
            labelPasswordValid.Text = "";
            labelBalanceValid.Text = "";
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void AddressText_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countryBox.Text == "")
                labelCountryValid.Text = "";
        }

        private void SSNText_TextChanged(object sender, EventArgs e)
        {
            if (SSNText.Text.Length < 4 || System.Text.RegularExpressions.Regex.IsMatch(SSNText.Text, "[^0-9]"))
            {
                labelSSNValid.ForeColor = System.Drawing.Color.Red;
                labelSSNValid.Text = "Invalid SSN";
            }

            else if (SSNText.Text == "")
            {
               labelSSNValid.Text = "";
            }
                   
            else
            {
                labelSSNValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelSSNValid.Text = "Valid SSN";
            }
                
        }

        private void phoneNumber_TextChanged_1(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(balanceText.Text, "[^0-9]") || balanceText.Text == "0")
            {
                labelBalanceValid.ForeColor = System.Drawing.Color.Red;
                labelBalanceValid.Text = "Invalid Balance.";
            }

            else if (balanceText.Text == "")
            {
                labelBalanceValid.Text = "";
            }

            else
            {
                labelBalanceValid.ForeColor = System.Drawing.Color.LimeGreen;
                labelBalanceValid.Text = "Valid Balance Value.";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CancelBTN_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            buttonSubmit_Click(sender, e);
        }
    }
}
