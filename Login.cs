using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace DEXSTER
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void RgstrBtn_Click(object sender, EventArgs e)
        {

        }

        private void key_TextChanged(object sender, EventArgs e)
        {

        }
        private async void Validation()
        {

                Main main = new Main();
                main.Show();
                this.Hide();
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            Validation();
        }
        private void Pass_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void siticoneLabel4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "F4")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Ring02.wav");
                player.Play();
                MessageBox.Show("Membership Detected Enjoy 😜");
            }
        }

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
