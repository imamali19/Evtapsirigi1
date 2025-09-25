using System.Windows.Forms;

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
            if (password.Text.Length < 8)
            {
                MessageBox.Show("En az 8 simvoldan ibaret olmalidir");
            }
            string specialSymbols = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";
            string upperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerLetters = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            bool has3InARow = false;
            for (int i = 0; i < password.Text.Length; i++)
            {
                if (digits.Contains(password.Text[i]))
                {
                    if (i + 1 < password.Text.Length && digits.Contains(password.Text[i + 1]))
                    {
                        if (i + 2 < password.Text.Length && digits.Contains(password.Text[i + 2]))
                            has3InARow = true;
                        else hasDigit = true;
                    }
                }
                else if (upperLetters.Contains(password.Text[i]))
                {
                    if (i + 1 < password.Text.Length && upperLetters.Contains(password.Text[i + 1]))
                    {
                        if ( i + 2 < password.Text.Length && upperLetters.Contains(password.Text[i + 2]))
                            has3InARow = true;
                        else hasUpper = true;
                    }
                }
                else if (lowerLetters.Contains(password.Text[i]))
                {
                    if (i + 1 < password.Text.Length && lowerLetters.Contains(password.Text[i + 1]))
                    {
                        if (i + 2 < password.Text.Length && lowerLetters.Contains(password.Text[i + 2]))
                            has3InARow = true;
                        else hasLower = true;
                    }
                }
                else if (specialSymbols.Contains(password.Text[i]))
                {
                    if (i + 1 < password.Text.Length && specialSymbols.Contains(password.Text[i + 1]))
                    {
                        if ( i + 2 < password.Text.Length && specialSymbols.Contains(password.Text[i + 2]))
                            has3InARow = true;
                        else hasSpecial = true;
                    }
                }
            }
                if (hasDigit && hasLower && hasUpper && hasSpecial && !has3InARow) MessageBox.Show("Sifre ugurla yaradildi");
                else
                {
                    if (!hasUpper) MessageBox.Show("En az 1 boyuk herf olmalidir");
                    if (!hasLower) MessageBox.Show("En az 1 kicik herf olmalidir");
                    if (!hasDigit) MessageBox.Show("En az 1 reqem olmalidir");
                    if (!hasSpecial) MessageBox.Show("En az 1 xususi simvol olmalidir");
                    if(has3InARow) MessageBox.Show("Eyni tipli simvollar ard-arda 3 defe gele bilmez");
                }

            
        }
    }
}
