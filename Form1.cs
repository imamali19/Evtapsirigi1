using System;
using System.Windows.Forms;``````
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = password.Text;
            string errors = "";
            string digits = "0123456789";
            string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            string specialSymbols = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            for (int i = 0; i < pwd.Length; i++)
            {
                char ch = pwd[i];

                if (digits.Contains(ch)) hasDigit = true;
                else if (upperLetters.Contains(ch)) hasUpper = true;
                else if (lowerLetters.Contains(ch)) hasLower = true;
                else if (specialSymbols.Contains(ch)) hasSpecial = true;
            }

            if (pwd.Length < 8)
                errors += "Minimum 8 simvol olmalidir.\n";
            if (!hasUpper)
                errors += "En azi 1 b y k herf olmalidir.\n";
            if (!hasLower)
                errors += "En azi 1 ki ik herf olmalidir.\n";
            if (!hasDigit)
                errors += "En azi 1 reqem olmalidir.\n";
            if (!hasSpecial)
                errors += "En azi 1 x susi simvol olmalidir.\n";
            if (ContainsSequentialTriplet(pwd, digits) ||
                ContainsSequentialTriplet(pwd, lowerLetters) ||
                ContainsSequentialTriplet(pwd, upperLetters))
            {
                errors += "- 'abc', '123' kimi ardicil simvollar olmamalidir.\n";
            }

            if (string.IsNullOrEmpty(errors))
                MessageBox.Show("Sifre ugurla yaradildi");
            else
                MessageBox.Show("Sifre teleblere cavab vermir:\n\n" + errors);
        }
        private bool ContainsSequentialTriplet(string input, string alphabet)
        {
            for (int i = 0; i <= input.Length - 3; i++)
            {
                int index1 = alphabet.IndexOf(input[i]);
                int index2 = alphabet.IndexOf(input[i + 1]);
                int index3 = alphabet.IndexOf(input[i + 2]);

                if (index1 != -1 && index2 == index1 + 1 && index3 == index2 + 1)
                    return true;
            }
            return false;
        }
    }
}
