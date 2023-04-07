using DEXSTER.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEXSTER
{
    public partial class Tools : UserControl
    {
        private static Tools _instance;
        public static Tools Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Tools();
                return _instance;

            }

        }

        public string BP { get; private set; }

        public Tools()
        {
            InitializeComponent();
        }

        private void Tools_Load(object sender, EventArgs e)
        {
            siticoneLabel12.Visible = false;
            pictureBox1.Visible = false;
        }

        private void siticoneRoundedButton5_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                siticoneLabel5.Text = "Please Wait";
                siticoneLabel12.Visible = true;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                MessageBox.Show("Please Select your apk file ", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                string SourcePath;
                SourcePath = dlg.FileName;
                string TargetPath;
                TargetPath = "C:\\Windows\\com_tencent_ig.apk";
                string root1 = @"C:\Windows\com_tencent_ig.apk";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(root1))
                    {
                        File.Delete((root1));
                        File.Copy(dlg.FileName, TargetPath);
                        Do();

                    }
                    else
                    {
                        File.Copy(dlg.FileName, TargetPath);
                        Do();

                    }


                }


            }
            else
            {
                MessageBox.Show("Please Open Emu in Normal Mode", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Do()
        {
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            int i;
            siticoneProgressBar1.Minimum = 0;
            siticoneProgressBar1.Maximum = 100;
            await Task.Run(() => CheackingResourcesInstall());
            for (i = 0; i <= 20; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => Install());
            for (i = 0; i <= 40; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => Finished());
            for (i = 0; i <= 60; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleResourecesInstall());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            siticoneLabel5.Text = "Success";
        }
        private void Install()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 uninstall com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 install C:\\Windows\\com_tencent_ig.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }
        private void Finished()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("taskkill /F /im adb.exe");
                standardInput.WriteLine("taskkill /f /im adb.exe");
            }





        }
        private void DeleResourecesInstall()
        {
            if (File.Exists(@"adb.exe"))
            {
                try
                {
                    File.Delete("adb.exe");
                }
                catch
                {

                }
            }
            else
            {

            }
            if (File.Exists(@"AdbWinApi.dll"))
            {
                try
                {
                    File.Delete("AdbWinApi.dll");
                }
                catch
                {

                }

            }
            else
            {

            }


        }
        private void Delete()
        {
            string root1 = @"C:\Windows\com_tencent_ig.apk";
            File.Delete((root1));

        }

        private void siticoneLabel12_Click(object sender, EventArgs e)
        {

        }
        private void CheackingResourcesInstall()
        {
            if (File.Exists(@"adb.exe"))
            {
                try
                {


                }
                catch
                {

                }
            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {
                try
                {


                }
                catch
                {

                }

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }

        }

        private void siticoneLabel5_Click(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                RunNM();
                MessageBox.Show("Game will be open please Wait", "Notice",
                MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Run The Emulator in Normlall Mode First", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void RunNM()
        {
            pictureBox1.Enabled = true;
            await Task.Run(() => NewResources());
            await Task.Run(() => Game());
            siticoneLabel5.Text = "Success";
        }
        private void NewResources()
        {

            if (File.Exists(@"C:\\DEXSTER.dll"))
            {
                try
                {

                }
                catch
                {

                }
            }
            else
            {

            }
            if (File.Exists(@"adb.exe"))
            {
                try
                {

                }
                catch
                {

                }
            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {
                try
                {

                }
                catch
                {

                }

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }

            if (File.Exists(@"C:\\Windows\\SystemDEXV11.zip"))
            {

            }
            else
            {
                if (File.Exists("DEXSTER_Services.dll"))
                {
                    string TargetPath;
                    TargetPath = "C:\\Windows\\SystemDEXV11.zip";
                    File.Copy("DEXSTER_Services.dll", TargetPath);
                    File.SetAttributes("C:\\Windows\\SystemDEXV11.zip", FileAttributes.Hidden);
                }
                else
                {

                    MessageBox.Show("Load Driver Failed");

                }
            }

        }
        private void Game()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            DeepUninstall();
        }
        private async void DeepUninstall()
        {
            siticoneLabel12.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            int i;
            siticoneProgressBar1.Minimum = 0;
            siticoneProgressBar1.Maximum = 100;
            await Task.Run(() => Taskkill());
            for (i = 0; i <= 40; i++)
            {
                siticoneLabel5.Text = "Please Wait";
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => FakeRegistry());
            for (i = 0; i <= 40; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleteRegistry());
            for (i = 0; i <= 60; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleteResources());
            for (i = 0; i <= 80; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleteDerectoryPermanent());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            siticoneLabel5.Text = "Success";
        }
        private void DeleteResources()
        {
            if (File.Exists(@"adb.exe"))
            {
                try
                {
                    File.Delete("adb.exe");
                }
                catch
                {

                }
            }
            else
            {

            }
            if (File.Exists(@"AdbWinApi.dll"))
            {
                try
                {
                    File.Delete("AdbWinApi.dll");
                }
                catch
                {

                }

            }
            else
            {

            }
        }
        private void DeleteDerectory()
        {
            string root = @"C:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root))
            {
                Directory.Delete(root, true);

            }
            else
            {

            }
            string root1 = @"D:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root1))
            {
                Directory.Delete(root1, true);

            }
            else
            {

            }
            string root2 = @"E:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root2))
            {
                Directory.Delete(root2, true);

            }
            else
            {

            }
            string root3 = @"F:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root3))
            {
                Directory.Delete(root3, true);

            }
            else
            {

            }
            string root4 = @"G:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root4))
            {
                Directory.Delete(root4, true);

            }
            else
            {

            }
            string root5 = @"H:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root5))
            {
                Directory.Delete(root5, true);

            }
            else
            {

            }
            string root6 = @"I:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root6))
            {
                Directory.Delete(root6, true);

            }
            else
            {

            }
            string root7 = @"J:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root7))
            {
                Directory.Delete(root7, true);

            }
            else
            {

            }
            string root8 = @"K:\\Program Files\\TxGameAssistant\\ui";
            if (Directory.Exists(root8))
            {
                Directory.Delete(root8, true);

            }
            else
            {

            }
            string root9 = @"C:\\TxGameAssistant\\ui";
            if (Directory.Exists(root9))
            {
                Directory.Delete(root9, true);

            }
            else
            {

            }
            string root10 = @"D:\\TxGameAssistant\\ui";
            if (Directory.Exists(root10))
            {
                Directory.Delete(root10, true);

            }
            else
            {

            }
            string root11 = @"E:\\TxGameAssistant\\ui";
            if (Directory.Exists(root11))
            {
                Directory.Delete(root1, true);

            }
            else
            {

            }
            string root12 = @"F:\\TxGameAssistant\\ui";
            if (Directory.Exists(root12))
            {
                Directory.Delete(root12, true);

            }
            else
            {

            }
            string root13 = @"G:\\TxGameAssistant\\ui";
            if (Directory.Exists(root13))
            {
                Directory.Delete(root13, true);

            }
            else
            {

            }
            string root14 = @"H:\\TxGameAssistant\\ui";
            if (Directory.Exists(root14))
            {
                Directory.Delete(root14, true);

            }
            else
            {

            }
            string root15 = @"I:\\TxGameAssistant\\ui";
            if (Directory.Exists(root15))
            {
                Directory.Delete(root15, true);

            }
            else
            {

            }
            string root16 = @"J:\\TxGameAssistant\\ui";
            if (Directory.Exists(root16))
            {
                Directory.Delete(root16, true);

            }
            else
            {

            }
            string root17 = @"K:\\TxGameAssistant\\ui";
            if (Directory.Exists(root17))
            {
                Directory.Delete(root17, true);

            }
            else
            {

            }
            string root30 = @"C:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root30))
            {
                Directory.Delete(root30, true);

            }
            else
            {

            }
            string root31 = @"D:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root31))
            {
                Directory.Delete(root31, true);

            }
            else
            {

            }
            string root32 = @"E:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root32))
            {
                Directory.Delete(root32, true);

            }
            else
            {

            }
            string root33 = @"F:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root33))
            {
                Directory.Delete(root33, true);

            }
            else
            {

            }
            string root34 = @"G:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root34))
            {
                Directory.Delete(root34, true);

            }
            else
            {

            }
            string root35 = @"H:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root35))
            {
                Directory.Delete(root35, true);

            }
            else
            {

            }
            string root36 = @"I:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root36))
            {
                Directory.Delete(root36, true);

            }
            else
            {

            }
            string root37 = @"J:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root37))
            {
                Directory.Delete(root37, true);

            }
            else
            {

            }
            string root38 = @"K:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root38))
            {
                Directory.Delete(root38, true);

            }
            else
            {

            }
            string root39 = @"C:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root39))
            {
                Directory.Delete(root39, true);

            }
            else
            {

            }
            string root110 = @"D:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root110))
            {
                Directory.Delete(root110, true);

            }
            else
            {

            }
            string root111 = @"E:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root111))
            {
                Directory.Delete(root11, true);

            }
            else
            {

            }
            string root112 = @"F:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root112))
            {
                Directory.Delete(root112, true);

            }
            else
            {

            }
            string root113 = @"G:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root113))
            {
                Directory.Delete(root113, true);

            }
            else
            {

            }
            string root114 = @"H:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root114))
            {
                Directory.Delete(root114, true);

            }
            else
            {

            }
            string root115 = @"I:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root115))
            {
                Directory.Delete(root115, true);

            }
            else
            {

            }
            string root116 = @"J:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root116))
            {
                Directory.Delete(root116, true);

            }
            else
            {

            }
            string root117 = @"K:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root117))
            {
                Directory.Delete(root117, true);

            }
            else
            {

            }
            string root18 = @"K:\\Temp";
            if (Directory.Exists(root18))
            {
                Directory.Delete(root18, true);

            }
            string root19 = @"D:\\Temp";
            if (Directory.Exists(root19))
            {
                Directory.Delete(root19, true);

            }
            else
            {

            }
            string root20 = @"E:\\Temp";
            if (Directory.Exists(root20))
            {
                Directory.Delete(root20, true);

            }
            else
            {

            }
            string root21 = @"F:\\Temp";
            if (Directory.Exists(root21))
            {
                Directory.Delete(root21, true);

            }
            else
            {

            }
            string root22 = @"G:\\Temp";
            if (Directory.Exists(root22))
            {
                Directory.Delete(root22, true);

            }
            else
            {

            }
            string root23 = @"H:\\Temp";
            if (Directory.Exists(root23))
            {
                Directory.Delete(root23, true);

            }
            else
            {

            }
            string root24 = @"I:\\Temp";
            if (Directory.Exists(root24))
            {
                Directory.Delete(root24, true);

            }
            else
            {

            }
            string root25 = @"J:\\Temp";
            if (Directory.Exists(root25))
            {
                Directory.Delete(root25, true);

            }
            else
            {

            }
            string root27 = @"C:\\Temp";
            if (Directory.Exists(root27))
            {
                Directory.Delete(root27, true);

            }
            else
            {

            }
        }
        private void DeleteDerectoryPermanent()
        {
            string root = @"C:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root))
            {
                Directory.Delete(root, true);

            }
            else
            {

            }
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root1))
            {
                Directory.Delete(root1, true);

            }
            else
            {

            }
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root2))
            {
                Directory.Delete(root2, true);

            }
            else
            {

            }
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root3))
            {
                Directory.Delete(root3, true);

            }
            else
            {

            }
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root4))
            {
                Directory.Delete(root4, true);

            }
            else
            {

            }
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root5))
            {
                Directory.Delete(root5, true);

            }
            else
            {

            }
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root6))
            {
                Directory.Delete(root6, true);

            }
            else
            {

            }
            string root7 = @"J:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root7))
            {
                Directory.Delete(root7, true);

            }
            else
            {

            }
            string root8 = @"K:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root8))
            {
                Directory.Delete(root8, true);

            }
            else
            {

            }
            string root9 = @"C:\\TxGameAssistant";
            if (Directory.Exists(root9))
            {
                Directory.Delete(root9, true);

            }
            else
            {

            }
            string root10 = @"D:\\TxGameAssistant";
            if (Directory.Exists(root10))
            {
                Directory.Delete(root10, true);

            }
            else
            {

            }
            string root11 = @"E:\\TxGameAssistant";
            if (Directory.Exists(root11))
            {
                Directory.Delete(root1, true);

            }
            else
            {

            }
            string root12 = @"F:\\TxGameAssistant";
            if (Directory.Exists(root12))
            {
                Directory.Delete(root12, true);

            }
            else
            {

            }
            string root13 = @"G:\\TxGameAssistant";
            if (Directory.Exists(root13))
            {
                Directory.Delete(root13, true);

            }
            else
            {

            }
            string root14 = @"H:\\TxGameAssistant";
            if (Directory.Exists(root14))
            {
                Directory.Delete(root14, true);

            }
            else
            {

            }
            string root15 = @"I:\\TxGameAssistant";
            if (Directory.Exists(root15))
            {
                Directory.Delete(root15, true);

            }
            else
            {

            }
            string root16 = @"J:\\TxGameAssistant";
            if (Directory.Exists(root16))
            {
                Directory.Delete(root16, true);

            }
            else
            {

            }
            string root17 = @"K:\\TxGameAssistant";
            if (Directory.Exists(root17))
            {
                Directory.Delete(root17, true);

            }
            else
            {

            }
            string root30 = @"C:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root30))
            {
                Directory.Delete(root30, true);

            }
            else
            {

            }
            string root31 = @"D:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root31))
            {
                Directory.Delete(root31, true);

            }
            else
            {

            }
            string root32 = @"E:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root32))
            {
                Directory.Delete(root32, true);

            }
            else
            {

            }
            string root33 = @"F:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root33))
            {
                Directory.Delete(root33, true);

            }
            else
            {

            }
            string root34 = @"G:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root34))
            {
                Directory.Delete(root34, true);

            }
            else
            {

            }
            string root35 = @"H:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root35))
            {
                Directory.Delete(root35, true);

            }
            else
            {

            }
            string root36 = @"I:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root36))
            {
                Directory.Delete(root36, true);

            }
            else
            {

            }
            string root37 = @"J:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root37))
            {
                Directory.Delete(root37, true);

            }
            else
            {

            }
            string root38 = @"K:\\Program Files\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root38))
            {
                Directory.Delete(root38, true);

            }
            else
            {

            }
            string root39 = @"C:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root39))
            {
                Directory.Delete(root39, true);

            }
            else
            {

            }
            string root110 = @"D:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root110))
            {
                Directory.Delete(root110, true);

            }
            else
            {

            }
            string root111 = @"E:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root111))
            {
                Directory.Delete(root11, true);

            }
            else
            {

            }
            string root112 = @"F:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root112))
            {
                Directory.Delete(root112, true);

            }
            else
            {

            }
            string root113 = @"G:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root113))
            {
                Directory.Delete(root113, true);

            }
            else
            {

            }
            string root114 = @"H:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root114))
            {
                Directory.Delete(root114, true);

            }
            else
            {

            }
            string root115 = @"I:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root115))
            {
                Directory.Delete(root115, true);

            }
            else
            {

            }
            string root116 = @"J:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root116))
            {
                Directory.Delete(root116, true);

            }
            else
            {

            }
            string root117 = @"K:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root117))
            {
                Directory.Delete(root117, true);

            }
            else
            {

            }
            string root18 = @"K:\\Temp";
            if (Directory.Exists(root18))
            {
                Directory.Delete(root18, true);

            }
            string root19 = @"D:\\Temp";
            if (Directory.Exists(root19))
            {
                Directory.Delete(root19, true);

            }
            else
            {

            }
            string root20 = @"E:\\Temp";
            if (Directory.Exists(root20))
            {
                Directory.Delete(root20, true);

            }
            else
            {

            }
            string root21 = @"F:\\Temp";
            if (Directory.Exists(root21))
            {
                Directory.Delete(root21, true);

            }
            else
            {

            }
            string root22 = @"G:\\Temp";
            if (Directory.Exists(root22))
            {
                Directory.Delete(root22, true);

            }
            else
            {

            }
            string root23 = @"H:\\Temp";
            if (Directory.Exists(root23))
            {
                Directory.Delete(root23, true);

            }
            else
            {

            }
            string root24 = @"I:\\Temp";
            if (Directory.Exists(root24))
            {
                Directory.Delete(root24, true);

            }
            else
            {

            }
            string root25 = @"J:\\Temp";
            if (Directory.Exists(root25))
            {
                Directory.Delete(root25, true);

            }
            else
            {

            }
            string root27 = @"C:\\Temp";
            if (Directory.Exists(root27))
            {
                Directory.Delete(root27, true);

            }
            else
            {

            }
        }
        private void Taskkill()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("taskkill /F /im AndroidEmulator.exe");
                standardInput.WriteLine("taskkill /F /im AndroidEmulatorEn.exe");
                standardInput.WriteLine("taskkill /F /im AndroidEmulatorEx.exe");
                standardInput.WriteLine("taskkill /F /im TBSWebRenderer.exe");
                standardInput.WriteLine("taskkill /F /im AppMarket.exe");
                standardInput.WriteLine("taskkill /f /im tensafe_1.exe");
                standardInput.WriteLine("taskkill /f /im tensafe_2.exe");
                standardInput.WriteLine("taskkill /f /im tencentdl.exe");
                standardInput.WriteLine("taskkill /f /im conime.exe");
                standardInput.WriteLine("taskkill /f /im QQDL.EXE");
                standardInput.WriteLine("taskkill /f /im qqlogin.exe");
                standardInput.WriteLine("taskkill /f /im dnfchina.exe");
                standardInput.WriteLine("taskkill /f /im dnfchinatest.exe");
                standardInput.WriteLine("taskkill /f /im txplatform.exe");
                standardInput.WriteLine("taskkill /f /im aow_exe.exe");
                standardInput.WriteLine("taskkill /f /im WinAPIX86.dll");
                standardInput.WriteLine("taskkill /f /im DEX.exe");
                standardInput.WriteLine("taskkill /F /IM TitanService.exe");
                standardInput.WriteLine("taskkill /F /IM ProjectTitan.exe");
                standardInput.WriteLine("taskkill /F /IM Auxillary.exe");
                standardInput.WriteLine("taskkill /F /IM TP3Helper.exe");
                standardInput.WriteLine("taskkill /F /IM tp3helper.data");
                standardInput.WriteLine("TaskKill /F /IM AndroidEmulator.exe");
                standardInput.WriteLine("TaskKill /F /IM aow_exe.exe");
                standardInput.WriteLine("TaskKill /F /IM QMEmulatorService.exe");
                standardInput.WriteLine("TaskKill /F /IM RuntimeBroker.exe");
                standardInput.WriteLine("taskkill /F /im adb.exe");
                standardInput.WriteLine("taskkill /F /im GmeLoader.exe");
                standardInput.WriteLine("taskkill /F /im cef_frame_render.exe");
                standardInput.WriteLine("taskkill /F /im syzs_dl_svr.exe");
                standardInput.WriteLine("taskkill /f /im adb.exe");
                standardInput.WriteLine("net stop 1");
                standardInput.WriteLine("net stop aow_drv");
                standardInput.WriteLine("net stop aow_drv_x64_ev");
                standardInput.WriteLine("net stop AOW_DRV_X64");
                standardInput.WriteLine("del /s /f /q C:\\aow_drv.log");
                standardInput.WriteLine("net stop QMEmulatorService");
                standardInput.WriteLine("del C:\\aow_drv.log");
                standardInput.WriteLine("net stop Tensafe");
                standardInput.WriteLine("net stop UniFairy_x64");
                standardInput.WriteLine("net stop UniFairy");
                standardInput.WriteLine("net stop UniSafe");
                standardInput.WriteLine("net stop libEGL");
                standardInput.WriteLine("net stop libGLESv1");
                standardInput.WriteLine("net stop libGLESv2");
                standardInput.WriteLine("net stop libOpenglRenderV3");
                standardInput.WriteLine("/ c sc stop KProcessHacker & sc delete KProcessHacker &sc stop KProcessHacker2 &sc delete KProcessHacker2 &sc stop KProcessHacker3 &sc delete KProcessHacker3 &sc stop KProcessHacker1 &sc delete KProcessHacker1 &sc stop aow_drv &sc delete aow_drv & sc stop AndroidKernel");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void FakeRegistry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Tencent");
            key.SetValue("1", "2669");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC");
            key.SetValue("1", "2669");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
            key.Close();
        }
        private void DeleteRegistry()
        {
            string explorerKeyPath = @"SOFTWARE\\";
            using (RegistryKey explorerKey = Registry.CurrentUser.OpenSubKey(explorerKeyPath, writable: true))
            {
                if (explorerKey != null)
                {
                    explorerKey.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }
            }
            string explorerKeyPath1 = @"SOFTWARE\\";
            using (RegistryKey explorerKey1 = Registry.LocalMachine.OpenSubKey(explorerKeyPath1, writable: true))
            {
                if (explorerKey1 != null)
                {
                    explorerKey1.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }

            }


        }
        private void siticoneRoundedButton4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedButton2_Click_1(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                Reset();
                MessageBox.Show("Game Will Auto Open", "Team DEXSTER",
                MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Run The Emulator in Normlall Mode First", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void Reset()
        {
            siticoneLabel12.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            await Task.Run(() => DEXGUESTV1());
        }
        private void DEXGUESTV1()
        {
            if (File.Exists(@"adb.exe"))
            {

            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }
            File.WriteAllBytes("DEXGUESTV1.exe", Resources.DEXGUESTV1);
            ProcessStartInfo DEX = new ProcessStartInfo();
            DEX.FileName = @"DEXGUESTV1.exe";
            DEX.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = Process.Start(DEX);

        }

        private void siticoneRoundedButton3_Click_1(object sender, EventArgs e)
        {
            siticoneLabel12.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            MessageBox.Show("Slect your unzip AOW_Rootfs_100", "Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            string SourcePath;
            SourcePath = dlg.FileName;
            string TargetPath;
            TargetPath = "C:\\Windows\\AOW_Rootfs_100.zip";
            string zipPath = @"C:\Windows\AOW_Rootfs_100.zip";
            string extractPath = @"D:\TxGameAssistant\AOW_Rootfs_100\";
            string root = @"C:\\Program Files\\TxGameAssistant";
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            string root7 = @"J:\\Program Files\\TxGameAssistant";
            string root8 = @"K:\\Program Files\\TxGameAssistant";
            string root9 = @"C:\\TxGameAssistant";
            string root10 = @"D:\\TxGameAssistant";
            string root11 = @"E:\\TxGameAssistant";
            string root12 = @"F:\\TxGameAssistant";
            string root13 = @"G:\\TxGameAssistant";
            string root14 = @"H:\\TxGameAssistant";
            string root15 = @"I:\\TxGameAssistant";
            string root16 = @"J:\\TxGameAssistant";
            string root17 = @"K:\\TxGameAssistant";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                siticoneLabel5.Text = "Please Wait";
                Taskkill();
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
                if (Directory.Exists(root1))
                {
                    Directory.Delete(root1, true);
                }
                if (Directory.Exists(root2))
                {
                    Directory.Delete(root2, true);
                }
                if (Directory.Exists(root3))
                {
                    Directory.Delete(root3, true);
                }
                if (Directory.Exists(root4))
                {
                    Directory.Delete(root4, true);
                }
                if (Directory.Exists(root5))
                {
                    Directory.Delete(root5, true);
                }
                if (Directory.Exists(root6))
                {
                    Directory.Delete(root6, true);
                }
                if (Directory.Exists(root7))
                {
                    Directory.Delete(root7, true);
                }
                if (Directory.Exists(root8))
                {
                    Directory.Delete(root8, true);
                }
                if (Directory.Exists(root9))
                {
                    Directory.Delete(root9, true);
                }
                if (Directory.Exists(root10))
                {
                    Directory.Delete(root10, true);
                }
                if (Directory.Exists(root11))
                {
                    Directory.Delete(root1, true);
                }
                if (Directory.Exists(root12))
                {
                    Directory.Delete(root12, true);
                }
                if (Directory.Exists(root13))
                {
                    Directory.Delete(root13, true);
                }
                if (Directory.Exists(root14))
                {
                    Directory.Delete(root14, true);
                }
                if (Directory.Exists(root15))
                {
                   Directory.Delete(root15, true);
                }
                if (Directory.Exists(root16))
                {
                    Directory.Delete(root16, true);
                }
                if (Directory.Exists(root17))
                {
                    Directory.Delete(root17, true);
                }
                if (File.Exists(TargetPath))
                {
                    File.Delete((TargetPath));
                }
                File.Copy(dlg.FileName, TargetPath);
                Directory.CreateDirectory("D:\\TxGameAssistant\\AOW_Rootfs_100");
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                EMU_INS();
            }
        }
        private async void EMU_INS()
        {
            int i;
            await Task.Run(() => Taskkill());
            siticoneProgressBar1.Maximum = 100;
            for (i = 0; i <= 20; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => RESETNETSH());
            siticoneProgressBar1.Maximum = 100;
            for (i = 0; i <= 20; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => PortsNM());
            for (i = 0; i <= 30; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => FakeRegistry());
            for (i = 0; i <= 40; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => RegistryDelete());
            for (i = 0; i <= 40; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => InputRegistryHigh());
            for (i = 0; i <= 60; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => NewResources());
            for (i = 0; i <= 80; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => NewDirectory());
            for (i = 0; i <= 90; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => StartNormal());
            for (i = 0; i <= 100; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneProgressBar1.Value = i;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            siticoneLabel5.Text = "Success";

        }
        private void StartNormal()
        {
            string start = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            Process.Start(Path.Combine(start) + "/AndroidEmulator.exe", "-cmd StartApk -param -startpkg com.tencent.ig -engine aow -vm 100");
        }
        private void NewDirectory()
        {
            Directory.CreateDirectory("D:\\TxGameAssistant\\");
            string zipPath = @"C:\Windows\SystemDEXV11.zip";
            string extractPath = @"D:\TxGameAssistant\";
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
        private void InputRegistryHigh()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\AOW_Rootfs_100");
            key.SetValue("InstallPath", "C:\\TxGameAssistant\\AOW_Rootfs_100");
            key.SetValue("Version", "4.1.25.90");
            key.SetValue("InstallDone", 1, RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UI");
            key.SetValue("InstallPath", "C:\\TxGameAssistant\\UI");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("TempPath", "C:\\Temp\\TxGameDownload\\Component\\");
            key.SetValue("UserLanguage", "en");
            key.SetValue("DirectxVersion", 10, RegistryValueKind.DWord);
            key.SetValue("GpsLocation", "22.540323,113.934578");
            key.SetValue("com.tencent.ig_ContentScale", 1, RegistryValueKind.DWord);
            key.SetValue("dpiAware", 1, RegistryValueKind.DWord);
            key.SetValue("VMCpuCount", 4, RegistryValueKind.DWord);
            key.SetValue("VMResWidth", 1920, RegistryValueKind.DWord);
            key.SetValue("VMResHeight", 1080, RegistryValueKind.DWord);
            key.SetValue("FxaaQuality", 0, RegistryValueKind.DWord);
            key.SetValue("GraphicsCardEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("LocalShaderCacheEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMMemorySizeInMB", 8192, RegistryValueKind.DWord);
            key.SetValue("AudioRenderEndpoint", "{0.0.0.00000000}.{039b451e-2621-4c98-bca0-8ac82bef4810}");
            key.SetValue("AudioCaptureEndpoint", "{0.0.1.00000000}.{2252bc2d-0a26-4e66-8e8a-364f0ec02cd3}");
            key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            key.SetValue("ForceDirectX", 1, RegistryValueKind.DWord);
            key.SetValue("RenderOptimizeEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("ShaderCacheEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMDPI", 240, RegistryValueKind.DWord);
            key.SetValue("VSyncEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMDeviceManufacturer", "samsung");
            key.SetValue("VMDeviceModel", "ASUS_I001DA");
            key.SetValue("com.tencent.ig_FPSLevel", 90, RegistryValueKind.DWord);
            key.SetValue("com.tencent.ig_RenderQuality", 2, RegistryValueKind.DWord);
            key.Close();
        }
        private void RegistryDelete()
        {
            string explorerKeyPath = @"SOFTWARE\\";
            using (RegistryKey explorerKey = Registry.CurrentUser.OpenSubKey(explorerKeyPath, writable: true))
            {
                if (explorerKey != null)
                {
                    explorerKey.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }
            }
            string explorerKeyPath1 = @"SOFTWARE\\";
            using (RegistryKey explorerKey1 = Registry.LocalMachine.OpenSubKey(explorerKeyPath1, writable: true))
            {
                if (explorerKey1 != null)
                {
                    explorerKey1.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }
            }
        }
        private void PortsNM()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK protocol=ANY dir=in remoteip=123.151.71.34 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK protocol=ANY dir=in remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK protocol=ANY dir=out remoteip=123.151.71.34 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK protocol=ANY dir=out remoteip=203.205.239.243 action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void RESETNETSH()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("ipconfig /registerdns");
                standardInput.WriteLine("ipconfig /release");
                standardInput.WriteLine("ipconfig /renew");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.WriteLine("netsh int ip reset");
                standardInput.WriteLine("netsh winsock reset");
                standardInput.WriteLine("netsh interface ipv4 reset");
                standardInput.WriteLine("netsh interface ipv6 reset");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\TxGameAssistant\\AOW_Rootfs_100");
        }

        private async void siticoneRoundedButton4_Click_1(object sender, EventArgs e)
        {
            Task.Run(() => VN_HAX_FIX());
        }
        private async void VN_HAX_FIX()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall delete rule name =SAFEOUTVN");
                standardInput.WriteLine("netsh advfirewall firewall delete rule name =SAFEOUTVN");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            Thread.Sleep(10000);
            Process process1 = new Process();
            process1.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process1.Start();
            using (StreamWriter standardInput = process1.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process1.WaitForExit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getFirewallStatus();
        }
        private string getFirewallStatus()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;


            Process process = Process.Start(processStartInfo);


            if (process != null)
            {
                process.StandardInput.WriteLine("netsh advfirewall show allprofiles | find \"State\"");
                process.StandardInput.Close();
                string outputString = process.StandardOutput.ReadToEnd();
                int count = 0;
                for (int i = 0; i < outputString.Length - 3; i++)
                {
                    if (outputString.Substring(i, 3).CompareTo(@"OFF") == 0)
                    {
                        MessageBox.Show("On");
                    }
                    else if (outputString.Substring(i, 2).CompareTo("ON") == 0)
                    {
                        MessageBox.Show("On");
                    }
                }
            }
            return string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ipconfig", "/release");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ipconfig", "/renew");
        }

        private void siticoneRoundedButton4_Click_2(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
              CHECK_ID();
            }
            else
            {
                MessageBox.Show("Run The Emulator First", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CHECK_ID()
        {
            if (File.Exists(@"adb.exe"))
            {

            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = false,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell settings get secure android_id");
                standardInput.WriteLine("adb -s emulator-5554 shell sleep 50");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }
    }
}
