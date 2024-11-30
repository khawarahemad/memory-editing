using KeyAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace microsoft
{
    public partial class Login : Form
    {
        public static api KeyAuthApp = new api(
            name: "newauth",
            ownerid: "KyGA5aevlv",
            secret: "076373d5c2bebeef395d83ce42f6f99abc9f276dd458851c9b77a68ea2e1d879",
            version: "1.0"
        );

        public Login()
        {
            InitializeComponent();

            // Disable SSL certificate validation (for development only)
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            // Initialize the KeyAuth API
            KeyAuthApp.init();
        }

        private void LodInFormation()
        {
            Username.Text = Properties.Settings.Default.Username;
            Password.Text = Properties.Settings.Default.Password;
        }

        private void SaveUsernameAndPassword()
        {
            Properties.Settings.Default.Username = Username.Text;
            Properties.Settings.Default.Password = Password.Text;
            Properties.Settings.Default.Save();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(Username.Text, Password.Text);
            if (KeyAuthApp.response.success)
            {
                Progressbar.Start();
                sta.Text = KeyAuthApp.response.message;
            }
            else
            {
                sta.Text = KeyAuthApp.response.message;
            }
        }

        private void LoginSucess()
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Progressbar_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value += 50;
            if (guna2ProgressBar1.Value >= 100)
            {
                LoginSucess();
                Progressbar.Stop();
            }
        }

        private bool iscrackeraprunring11(string Processname)
        {
            Process[] processes = Process.GetProcessesByName(Processname);
            return processes.Length > 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool iscrackeraprunring = iscrackeraprunring11("ProcessHacker") ||
                                      iscrackeraprunring11("Procexp64") ||
                                      iscrackeraprunring11("x64dbg") ||
                                      iscrackeraprunring11("Cheat Engine") ||
                                      iscrackeraprunring11("CheatEngine-x86_64-SSE4-AVX2") ||
                                      iscrackeraprunring11("dnspy") ||
                                      iscrackeraprunring11("CheatEngine-i368") ||
                                      iscrackeraprunring11("CheatEngine-x86_64");

            if (iscrackeraprunring)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("You Are Cracker MotherLover");
                        Process.Start("shutdown", "/s /t 0");
                        Application.Exit();
                    }
                }
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e) { }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e) { }
    }
}
