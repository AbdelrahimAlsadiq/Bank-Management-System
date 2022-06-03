using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BankingSystem
{
    class Client
    {
        static int CustomerCount = 0;
        private string firstName, lastName, gender, email, country, SSN, phoneNumber, address;
        private DateTime DOB;
        int income;
        public Client(string fname, string lname, string gen, DateTime dob, string email, string countr, string ssn, int inc, string pn, string addr)
        {
            CustomerCount++;
            getsetForename = fname;
            getsetSurname = lname;
            getsetGender = gen;
            getsetDOB = dob;
            getsetEmail = email;
            getsetCountry = countr;
            getsetSSN = ssn;
            getsetIncome = inc;
            getsetPN = pn;
            getsetAddress = addr;


        }

       

        public string getsetPN
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public string getsetSSN
        {
            get
            {
                return SSN;
            }
            set
            {
                SSN = value;
            }
        }

        public string getsetAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string getsetCountry
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public int getsetIncome
        {
            get
            {
                return income;
            }
            set
            {
                income = value;
            }
        }

        public string getsetGender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public DateTime getsetDOB
        {
            get
            {
                return DOB;
            }
            set
            {
                DOB = value;
            }
        }

        

        public string getsetEmail
        {
            get
            {
                return email;

            }

            set
            {
                bool valid = CheckEmail(value);

                if (valid)
                {
                    email = value;
                }
                else
                {
                    email = "invalid";
                }

            }
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

        public string getsetForename
        {
            set
            {
                string strForenameNoWhitespace = Regex.Replace(value, @"\s+", "");
                if (!(strForenameNoWhitespace == ""))
                {
                    firstName = value.ToUpper();
                }
                else
                {
                    firstName = "invalid";
                }

            }
            get
            {
                return firstName;
            }
        }

        public string getsetSurname
        {
            set
            {
                string strSurnameNoWhitespace = Regex.Replace(value, @"\s+", "");
                if (!(strSurnameNoWhitespace == ""))
                {
                    lastName = value.ToUpper();
                }
                else
                {
                    lastName = "invalid";
                }


            }
            get
            {
                return lastName;
            }
        }




    }
}



