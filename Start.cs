using DEXSTER.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DEXSTER
{
    public partial class Start : UserControl
    {
        int i;
        private static Start _instance;
        private string SP;
        private string ST;

        public static Start Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Start();
                return _instance;

            }

        }
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            siticoneLabel12.Visible = false;
            pictureBox1.Visible = false;
            siticonePanel3.Visible = false;
            siticoneRoundedButton3.Visible = false;
            string path = "C:\\DEXSTER.txt";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                ST = "DEXSTERANTIBAN";
                SP = text.ToString();
            }
        }
        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneWinToggleSwith1_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith1.Checked)
            {
                siticoneLabel5.Text = "High Mode Selected";
                siticoneWinToggleSwith2.Checked = false;
                siticoneWinToggleSwith3.Checked = false;
                siticoneWinToggleSwith4.Checked = false;
            }
        }

        private void siticoneWinToggleSwith3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith3.Checked)
            {
                siticoneLabel5.Text = "Smart Mode Selected";
                siticoneWinToggleSwith1.Checked = false;
                siticoneWinToggleSwith2.Checked = false;
                siticoneWinToggleSwith4.Checked = false;

            }
        }

        private void siticoneWinToggleSwith2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith2.Checked)
            {
                siticoneLabel5.Text = "Low Mode Selected";
                siticoneWinToggleSwith1.Checked = false;
                siticoneWinToggleSwith3.Checked = false;
                siticoneWinToggleSwith4.Checked = false;

            }
        }

        private void siticoneWinToggleSwith4_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith4.Checked)
            {
                siticoneLabel5.Text = "Normal Mode Selected";
                siticoneWinToggleSwith1.Checked = false;
                siticoneWinToggleSwith2.Checked = false;
                siticoneWinToggleSwith3.Checked = false;

            }
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                MessageBox.Show("Emu Already Running Close Manually or use Safe Exit");
            }
            else
            {
                timer1.Enabled = true;
                siticoneLabel12.Visible = true;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneWinToggleSwith8.Checked = false;
                siticoneRoundedButton3.Visible = false;
                pictureBox1.Visible = true;
                pictureBox1.Enabled = true;
                siticoneLabel5.Text = "Starting In High Mode";
                Start_Task();
            }
        }
        private async void Start_Task()
        {
            await Task.Run(() => Start_Task_For_Emu());
        }
        private async void Start_Task_For_Emu()
        {
            await Task.Run(() => EMU_KILL());
            for (i = 0; i <= 10; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            Task.Run(() => FakeRegistry());
            for (i = 0; i <= 20; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            Task.Run(() => RegistryDelete());
            for (i = 0; i <= 30; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            await Task.Run(() => Resources_Directory_REPLACE());
            for (i = 0; i <= 40; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            await Task.Run(() => DEXSTERLOOP_IN_OUT());
            for (i = 0; i <= 50; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            await Task.Run(() => Start7());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
        }
        private void MODE_DETECT()
        {
            if (siticoneWinToggleSwith1.Checked)
            {
                IN_Ports();
                for (i = 0; i <= 50; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                OUT_PortsVer_1();
                for (i = 0; i <= 60; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                InputRegistryHigh();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.High_Ver);
            }
            else if (siticoneWinToggleSwith2.Checked)
            {
                IN_Ports();
                for (i = 0; i <= 50; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                OUT_PortsVer_1();
                for (i = 0; i <= 60; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                InputRegistryLow();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Low_Ver);
            }
            else if (siticoneWinToggleSwith3.Checked)
            {
                IN_Ports();
                for (i = 0; i <= 50; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                OUT_PortsVer_1();
                for (i = 0; i <= 60; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                InputRegistrySmart();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Smart_Ver);
            }
            else if (siticoneWinToggleSwith4.Checked)
            {
                InputRegistryHigh();
                for (i = 0; i <= 55; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
                }
                PortsNM();
                for (i = 0; i <= 55; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Normal_Ver);
            }
        }
        private void FIREWALLOFF()
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
                standardInput.WriteLine("netsh advfirewall set allprofiles state off");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void FIREWALLON()
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
                standardInput.WriteLine("netsh advfirewall set allprofiles state on");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void StartNormal()
        {
            string start = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            Process.Start(Path.Combine(start) + "/AndroidEmulator.exe", "-cmd StartApk -param -startpkg com.tencent.ig -engine aow -vm 100");
        }
        private void EMU_KILL()
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
                standardInput.WriteLine("taskkill /F /IM TitanService.exe");
                standardInput.WriteLine("taskkill /F /IM ProjectTitan.exe");
                standardInput.WriteLine("taskkill /F /IM Auxillary.exe");
                standardInput.WriteLine("taskkill /F /IM TP3Helper.exe");
                standardInput.WriteLine("taskkill /F /IM tp3helper.data");
                standardInput.WriteLine("TaskKill /F /IM QMEmulatorService.exe");
                standardInput.WriteLine("TaskKill /F /IM RuntimeBroker.exe");
                standardInput.WriteLine("taskkill /F /im adb.exe");
                standardInput.WriteLine("taskkill /F /im GmeLoader.exe");
                standardInput.WriteLine("taskkill /F /im cef_frame_render.exe");
                standardInput.WriteLine("taskkill /F /im syzs_dl_svr.exe");
                standardInput.WriteLine("taskkill /f /im adb.exe");
                standardInput.WriteLine("net stop aow_drv");
                standardInput.WriteLine("net stop aow_drv_x64_ev");
                standardInput.WriteLine("net stop AOW_DRV_X64");
                standardInput.WriteLine("net stop QMEmulatorService");
                standardInput.WriteLine("net stop Tensafe");
                standardInput.WriteLine("net stop UniFairy_x64");
                standardInput.WriteLine("net stop UniFairy");
                standardInput.WriteLine("net stop UniSafe");
                standardInput.WriteLine("net stop libEGL");
                standardInput.WriteLine("net stop libGLESv1");
                standardInput.WriteLine("net stop libGLESv2");
                standardInput.WriteLine("net stop libOpenglRenderV3");
                standardInput.WriteLine("/ c sc stop KProcessHacker & sc delete KProcessHacker &sc stop KProcessHacker2 &sc delete KProcessHacker2 &sc stop KProcessHacker3 &sc delete KProcessHacker3 &sc stop KProcessHacker1 &sc delete KProcessHacker1 &sc stop aow_drv &sc delete aow_drv & sc stop AndroidKernel");
                standardInput.WriteLine("del C:\\aow_drv.log");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.WriteLine("del /s /f /q %USERPROFILE%\\Appdata\\local\temp\\*.*");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.WriteLine("ipconfig /registerdns");
                standardInput.WriteLine("netsh firewall reset");
                standardInput.WriteLine("netsh int ip reset");
                standardInput.WriteLine("netsh winsock reset");
                standardInput.WriteLine("netsh interface ipv4 reset");
                standardInput.WriteLine("netsh interface ipv6 reset");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void UniFairy()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=34.231.0.0-34.231.255.255,72.41.0.0-72.41.255.255,54.161.0.0-54.161.255.255,52.71.0.0-52.71.255.255,35.171.0.0-35.171.255.255,3.81.0.0-3.81.255.255,54.81.0.0-54.81.255.255,52.91.0.0-52.91.255.255,3.91.0.0-3.91.255.255,54.91.0.0-54.91.255.255,52.202.0.0-52.202.255.255,34.202.0.0-34.202.255.255,44.202.0.0-44.202.255.255,67.202.0.0-67.202.255.255,3.212.0.0-3.212.255.255,44.212.0.0-44.212.255.255,18.212.0.0-18.212.255.255,52.22.0.0-52.22.255.255,23.22.0.0-23.22.255.255,107.22.0.0-107.22.255.255,3.222.0.0-3.222.255.255,44.222.0.0-44.222.255.255,3.232.0.0-3.232.255.255,34.232.0.0-34.232.255.255,18.232.0.0-18.232.255.255,54.242.0.0-54.242.255.255,54.152.0.0-54.152.255.255,54.162.0.0-54.162.255.255,52.72.0.0-52.72.255.255,54.172.0.0-54.172.255.255,35.172.0.0-35.172.255.255,3.82.0.0-3.82.255.255,54.82.0.0-54.82.255.255,3.92.0.0-3.92.255.255,34.192.0.0-34.192.255.255,44.192.0.0-44.192.255.255,52.3.0.0-52.3.255.255,52.203.0.0-52.203.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=34.203.0.0-34.203.255.255,44.203.0.0-44.203.255.255,3.213.0.0-3.213.255.255,18.213.0.0-18.213.255.255,23.23.0.0-23.23.255.255,107.23.0.0-107.23.255.255,3.223.0.0-3.223.255.255,44.223.0.0-44.223.255.255,3.233.0.0-3.233.255.255,34.233.0.0-34.233.255.255,18.233.0.0-18.233.255.255,54.243.0.0-54.243.255.255,35.153.0.0-35.153.255.255,53.163.0.0-53.163.255.255,52.73.0.0-52.73.255.255,35.173.0.0-35.173.255.255,3.83.0.0-3.83.255.255,54.83.0.0-54.83.255.255,3.93.0.0-3.93.255.255,34.193.0.0-34.193.255.255,44.193.0.0-44.193.255.255,52.4.0.0-52.4.255.255,52.204.0.0-52.204.255.255,34.204.0.0-34.204.255.255,44.204.0.0-44.204.255.255,54.204.0.0-54.204.255.255,18.204.0.0-18.204.255.255,3.214.0.0-3.214.255.255,44.214.0.0-44.214.255.255,18.214.0.0-18.214.255.255,100.24.0.0-100.24.255.255,3.224.0.0-3.224.255.255,34.224.0.0-34.224.255.255,54.224.0.0-54.224.255.255,3.234.0.0-3.234.255.255,34.234.0.0-34.234.255.255,18.234.0.0-18.234.255.255,52.44.0.0-52.44.255.255,54.144.0.0-54.144.255.255,52.54.0.0-52.54.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=54.164.0.0-54.164.255.255,54.174.0.0-54.174.255.255,35.174.0.0-35.174.255.255,54.84.0.0-54.84.255.255,3.94.0.0-3.94.255.255,34.194.0.0-34.194.255.255,52.5.0.0-52.5.255.255,52.205.0.0-52.205.255.255,34.205.0.0-34.205.255.255,44.205.0.0-44.205.255.255,54.205.0.0-54.205.255.255,18.205.0.0-18.205.255.255,3.215.0.0-3.215.255.255,44.215.0.0-44.215.255.255,18.215.0.0-18.215.255.255,100.25.0.0-100.25.255.255,3.225.0.0-3.225.255.255,34.225.0.0-34.225.255.255,54.225.0.0-54.225.255.255,3.235.0.0-3.235.255.255,34.235.0.0-34.235.255.255,54.235.0.0-54.235.255.255,18.235.0.0-18.235.255.255,52.45.0.0-52.45.255.255,54.145.0.0-54.145.255.255,52.55.0.0-52.55.255.255,54.165.0.0-54.165.255.255,54.175.0.0-54.175.255.255,35.175.0.0-35.175.255.255,3.85.0.0-3.85.255.255,54.85.0.0-54.85.255.255,3.95.0.0-3.95.255.255,34.195.0.0-34.195.255.255,44.195.0.0-44.195.255.255,52.6.0.0-52.6.255.255,52.206.0.0-52.206.255.255,34.206.0.0-34.206.255.255,44.206.0.0-44.206.255.255,18.206.0.0-18.206.255.255,50.16.0.0-50.16.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=3.208.0.0-3.208.255.255,44.208.0.0-44.208.255.255,54.208.0.0-54.208.255.255,18.208.0.0-18.208.255.255,3.218.0.0-3.218.255.255,100.28.0.0-100.28.255.255,3.228.0.0-3.228.255.255,34.228.0.0-34.228.255.255,3.238.0.0-3.238.255.255,34.238.0.0-34.238.255.255,54.158.0.0-54.158.255.255,35.168.0.0-35.168.255.255,3.88.0.0-3.88.255.255,34.198.0.0-34.198.255.255,44.198.0.0-44.198.255.255,54.198.0.0-54.198.255.255,3.209.0.0-3.209.255.255,54.209.0.0-54.209.255.255,18.209.0.0-18.209.255.255,50.19.0.0-50.19.255.255,3.219.0.0-3.219.255.255,44.219.0.0-44.219.255.255,100.29.0.0-100.29.255.255,174.129.0.0-174.129.255.255,3.229.0.0-3.229.255.255,34.229.0.0-34.229.255.255,3.239.0.0-3.239.255.255,54.159.0.0-54.159.255.255,35.169.0.0-35.169.255.255,3.89.0.0-3.89.255.255,54.89.0.0-54.89.255.255,34.199.0.0-34.199.255.255,44.199.0.0-44.199.255.255,52.0.100.0-52.0.255.255,52.200.100.0-52.200.255.255,34.200.100.0-34.200.255.255,44.200.100.0-44.200.255.255,44.210.100.0-44.210.255.255,54.210.100.0-54.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=18.210.100.0-18.210.255.255,52.20.100.0-52.20.255.255,23.20.100.0-23.20.255.255,107.20.100.0-107.20.255.255,3.220.100.0-3.220.255.255,44.220.100.0-44.220.255.255,100.30.100.0-100.30.255.255,3.230.100.0-3.230.255.255,34.230.100.0-34.230.255.255,54.160.100.0-54.160.255.255,52.70.100.0-52.70.255.255,3.80.100.0-3.80.255.255,54.80.100.0-54.80.255.255,52.90.100.0-52.90.255.255,3.90.100.0-3.90.255.255,54.90.100.0-54.90.255.255,52.1.100.0-52.1.255.255,52.201.100.0-52.201.255.255,34.201.100.0-34.201.255.255,3.211.100.0-3.211.255.255,54.211.100.0-54.211.255.255,18.211.100.0-18.211.255.255,52.21.100.0-52.21.255.255,23.21.100.0-23.21.255.255,107.21.100.0-107.21.255.255,3.221.100.0-3.221.255.255,44.221.100.0-44.221.255.255,54.221.100.0-54.221.255.255,3.231.100.0-3.231.255.255,34.231.100.0-34.231.255.255,54.161.100.0-54.161.255.255,52.71.100.0-52.71.255.255,3.81.100.0-3.81.255.255,54.81.100.0-54.81.255.255,52.91.100.0-52.91.255.255,3.91.100.0-3.91.255.255,54.91.100.0-54.91.255.255,52.2.100.0-52.2.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=52.202.100.0-52.202.255.255,34.202.100.0-34.202.255.255,44.202.100.0-44.202.255.255,3.212.100.0-3.212.255.255,44.212.100.0-44.212.255.255,18.212.100.0-18.212.255.255,52.22.100.0-52.22.255.255,23.22.100.0-23.22.255.255,3.222.100.0-3.222.255.255,44.222.100.0-44.222.255.255,3.232.100.0-3.232.255.255,34.232.100.0-34.232.255.255,18.232.100.0-18.232.255.255,54.152.100.0-54.152.255.255,54.162.100.0-54.162.255.255,52.72.100.0-52.72.255.255,184.72.100.0-184.72.255.255,54.172.100.0-54.172.255.255,35.172.100.0-35.172.255.255,3.82.100.0-3.82.255.255,54.82.100.0-54.82.255.255,34.192.100.0-34.192.255.255,44.192.100.0-44.192.255.255,52.3.100.0-52.3.255.255,52.203.100.0-52.203.255.255,34.203.100.0-34.203.255.255,44.203.100.0-44.203.255.255,3.213.100.0-3.213.255.255,44.213.100.0-44.213.255.255,18.213.100.0-18.213.255.255,52.23.100.0-52.23.255.255,107.23.100.0-107.23.255.255,3.223.100.0-3.223.255.255,3.233.100.0-3.233.255.255,34.233.100.0-34.233.255.255,18.233.100.0-18.233.255.255,54.243.100.0-54.243.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=35.153.100.0-35.153.255.255,54.163.100.0-54.163.255.255,52.73.100.0-52.73.255.255,184.73.100.0-184.73.255.255,54.173.100.0-54.173.255.255,35.173.100.0-35.173.255.255,3.83.100.0-3.83.255.255,54.83.100.0-54.83.255.255,3.93.100.0-3.93.255.255,34.193.100.0-34.193.255.255,44.193.100.0-44.193.255.255,52.4.100.0-52.4.255.255,52.204.100.0-52.204.255.255,44.204.100.0-44.204.255.255,54.204.100.0-54.204.255.255,18.204.100.0-18.204.255.255,3.214.100.0-3.214.255.255,44.214.100.0-44.214.255.255,18.214.100.0-18.214.255.255,100.24.100.0-100.24.255.255,3.224.100.0-3.224.255.255,54.224.100.0-54.224.255.255,3.234.100.0-3.234.255.255,54.234.100.0-54.234.255.255,18.234.100.0-18.234.255.255,52.44.100.0-52.44.255.255,54.144.100.0-54.144.255.255,52.54.100.0-52.54.255.255,54.164.100.0-54.164.255.255,54.174.100.0-54.174.255.255,35.174.100.0-35.174.255.255,3.84.100.0-3.84.255.255,54.84.100.0-54.84.255.255,3.94.100.0-3.94.255.255,34.194.100.0-34.194.255.255,44.194.100.0-44.194.255.255,52.5.100.0-52.5.255.255,52.205.100.0-52.205.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=34.205.100.0-34.205.255.255,44.205.100.0-44.205.255.255,54.205.100.0-54.205.255.255,18.205.100.0-18.205.255.255,3.215.100.0-3.215.255.255,44.215.100.0-44.215.255.255,18.215.100.0-18.215.255.255,100.25.100.0-100.25.255.255,3.225.100.0-3.225.255.255,34.225.100.0-34.225.255.255,54.225.100.0-54.225.255.255,3.235.100.0-3.235.255.255,34.235.100.0-34.235.255.255,54.235.100.0-54.235.255.255,18.235.100.0-18.235.255.255,52.45.100.0-52.45.255.255,54.145.100.0-54.145.255.255,52.55.100.0-52.55.255.255,35.175.100.0-35.175.255.255,3.85.100.0-3.85.255.255,54.85.100.0-54.85.255.255,3.95.100.0-3.95.255.255,34.195.100.0-34.195.255.255,52.6.100.0-52.6.255.255,52.206.100.0-52.206.255.255,34.206.100.0-34.206.255.255,44.206.100.0-44.206.255.255,18.206.100.0-18.206.255.255,50.16.100.0-50.16.255.255,3.216.100.0-3.216.255.255,44.216.100.0-44.216.255.255,100.26.100.0-100.26.255.255,3.226.100.0-3.226.255.255,34.226.100.0-34.226.255.255,54.226.100.0-54.226.255.255,3.236.100.0-3.236.255.255,34.236.100.0-34.236.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=54.236.100.0-54.236.255.255,54.146.100.0-54.146.255.255,54.156.100.0-54.156.255.255,54.166.100.0-54.166.255.255,52.86.100.0-52.86.255.255,3.86.100.0-3.86.255.255,54.86.100.0-54.86.255.255,34.196.100.0-34.196.255.255,44.196.100.0-44.196.255.255,52.7.100.0-52.7.255.255,52.207.100.0-52.207.255.255,34.207.100.0-34.207.255.255,44.207.100.0-44.207.255.255,18.207.100.0-18.207.255.255,50.17.100.0-50.17.255.255,3.217.100.0-3.217.255.255,44.217.100.0-44.217.255.255,100.27.100.0-100.27.255.255,3.227.100.0-3.227.255.255,34.227.100.0-34.227.255.255,54.227.100.0-54.227.255.255,3.237.100.0-3.237.255.255,34.237.100.0-34.237.255.255,54.237.100.0-54.237.255.255,54.147.100.0-54.147.255.255,54.157.100.0-54.157.255.255,54.167.100.0-54.167.255.255,52.87.100.0-52.87.255.255,3.87.100.0-3.87.255.255,54.87.100.0-54.87.255.255,44.197.100.0-44.197.255.255,54.197.100.0-54.197.255.255,3.208.100.0-3.208.255.255,44.208.100.0-44.208.255.255,54.208.100.0-54.208.255.255,18.208.100.0-18.208.255.255,3.218.100.0-3.218.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=52.20.200.0-52.20.255.255,18.210.200.0-18.210.255.255,23.20.200.0-23.20.255.255,107.20.200.0-107.20.255.255,3.220.200.0-3.220.255.255,44.220.200.0-44.220.255.255,100.30.200.0-100.30.255.255,3.230.200.0-3.230.255.255,34.230.200.0-34.230.255.255,54.160.200.0-54.160.255.255,52.70.200.0-52.70.255.255,35.170.200.0-35.170.255.255,3.80.200.0-3.80.255.255,54.80.200.0-54.80.255.255,52.90.200.0-52.90.255.255,3.90.200.0-3.90.255.255,54.90.200.0-54.90.255.255,52.1.200.0-52.1.255.255,75.101.200.0-75.101.255.255,52.201.200.0-52.201.255.255,34.201.200.0-34.201.255.255,44.201.200.0-44.201.255.255,3.211.200.0-3.211.255.255,44.211.200.0-44.211.255.255,18.211.200.0-18.211.255.255,52.21.200.0-52.21.255.255,23.21.200.0-23.21.255.255,107.21.200.0-107.21.255.255,3.221.200.0-3.221.255.255,44.221.200.0-44.221.255.255,54.221.200.0-54.221.255.255,100.31.200.0-100.31.255.255,3.231.200.0-3.231.255.255,34.231.200.0-34.231.255.255,54.161.200.0-54.161.255.255,52.71.200.0-52.71.255.255,35.171.200.0-35.171.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=44.216.0.0-44.216.255.255,100.26.0.0-100.26.255.255,3.226.0.0-3.226.255.255,34.226.0.0-34.226.255.255,54.226.0.0-54.226.255.255,3.236.0.0-3.236.255.255,34.236.0.0-34.236.255.255,54.236.0.0-54.236.255.255,54.146.0.0-54.146.255.255,54.166.0.0-54.166.255.255,52.86.0.0-52.86.255.255,3.86.0.0-3.86.255.255,54.86.0.0-54.86.255.255,34.196.0.0-34.196.255.255,44.196.0.0-44.196.255.255,54.196.0.0-54.196.255.255,52.7.0.0-52.7.255.255,34.207.0.0-34.207.255.255,44.207.0.0-44.207.255.255,18.207.0.0-18.207.255.255,50.17.0.0-50.17.255.255,3.217.0.0-3.217.255.255,44.217.0.0-44.217.255.255,100.27.0.0-100.27.255.255,3.227.0.0-3.227.255.255,34.227.0.0-34.227.255.255,54.227.0.0-54.227.255.255,3.237.0.0-3.237.255.255,34.237.0.0-34.237.255.255,54.237.0.0-54.237.255.255,54.147.0.0-54.147.255.255,54.157.0.0-54.157.255.255,54.167.0.0-54.167.255.255,15.177.0.0-15.177.255.255,52.87.0.0-52.87.255.255,3.87.0.0-3.87.255.255,54.87.0.0-54.87.255.255,34.197.0.0-34.197.255.255,44.197.0.0-44.197.255.255,54.197.0.0-54.197.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=174.129.100.0-174.129.255.255,3.229.100.0-3.229.255.255,34.229.100.0-34.229.255.255,3.239.100.0-3.239.255.255,34.239.100.0-34.239.255.255,54.159.100.0-54.159.255.255,35.169.100.0-35.169.255.255,3.89.100.0-3.89.255.255,54.89.100.0-54.89.255.255,34.199.100.0-34.199.255.255,44.199.100.0-44.199.255.255,52.0.200.0-52.0.255.255,52.200.200.0-52.200.255.255,34.200.200.0-52.200.255.255,44.200.200.0-44.200.255.255,3.210.200.0-3.210.255.255,44.210.200.0-44.210.255.255,54.210.200.0-54.210.255.255,18.210.200.0-18.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=54.160.0.0-54.160.255.255,52.70.0.0-52.70.255.255,35.170.0.0-35.170.255.255,54.80.0.0-54.80.255.255,52.90.0.0-52.90.255.255,3.90.0.0-3.90.255.255,54.90.0.0-54.90.255.255,52.1.0.0-52.1.255.255,52.201.0.0-52.201.255.255,34.201.0.0-34.201.255.255,44.201.0.0-44.201.255.255,3.211.0.0-3.211.255.255,44.211.0.0-44.211.255.255,54.211.0.0-54.211.255.255,18.211.0.0-18.211.255.255,52.21.0.0-52.21.255.255,23.21.0.0-23.21.255.255,3.221.0.0-3.221.255.255,44.221.0.0-44.221.255.255,54.221.0.0-54.221.255.255,100.31.0.0-100.31.255.255,3.231.0.0-3.231.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=44.218.100.0-44.218.255.255,100.28.100.0-100.28.255.255,3.228.100.0-3.228.255.255,34.228.100.0-34.228.255.255,3.238.100.0-3.238.255.255,34.238.100.0-34.238.255.255,54.158.100.0-54.158.255.255,35.168.100.0-35.168.255.255,34.198.100.0-34.198.255.255,44.198.100.0-44.198.255.255,54.198.100.0-54.198.255.255,3.209.100.0-3.209.255.255,44.209.100.0-44.209.255.255,54.209.100.0-54.209.255.255,18.209.100.0-18.209.255.255,3.219.100.0-3.219.255.255,44.219.100.0-44.219.255.255,100.29.100.0-100.29.255.255,174.129.100.0-174.129.255.255,3.229.100.0-3.229.255.255,34.229.100.0-34.229.255.255,3.239.100.0-3.239.255.255,34.239.100.0-34.239.255.255,54.159.100.0-54.159.255.255,35.169.100.0-35.169.255.255,3.89.100.0-3.89.255.255,54.89.100.0-54.89.255.255,34.199.100.0-34.199.255.255,44.199.100.0-44.199.255.255,52.0.200.0-52.0.255.255,52.200.200.0-52.200.255.255,34.200.200.0-52.200.255.255,44.200.200.0-44.200.255.255,3.210.200.0-3.210.255.255,44.210.200.0-44.210.255.255,54.210.200.0-54.210.255.255,18.210.200.0-18.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=in remoteip=207.171.0.0-207.171.255.255,207.171.0.0-207.171.255.255,54.239.0.0-54.239.255.255,207.171.0.0-207.171.255.255,34.200.0.0-34.200.255.255,44.200.0.0-44.200.255.255,3.210.0.0-3.210.255.255,44.210.0.0-44.210.255.255,54.210.0.0-54.210.255.255,18.210.0.0-18.210.255.255,52.20.0.0-52.20.255.255,23.20.0.0-23.20.255.255,107.20.0.0-107.20.255.255,3.220.0.0-3.220.255.255,44.220.0.0-44.220.255.255,100.30.0.0-100.30.255.255,3.230.0.0-3.230.255.255,34.230.0.0-34.230.255.255,54.160.0.0-54.160.255.255,52.70.0.0-52.70.255.255,35.170.0.0-35.170.255.255,54.80.0.0-54.80.255.255,52.90.0.0-52.90.255.255,3.90.0.0-3.90.255.255,54.90.0.0-54.90.255.255,52.1.0.0-52.1.255.255,52.201.0.0-52.201.255.255,34.201.0.0-34.201.255.255,44.201.0.0-44.201.255.255,3.211.0.0-3.211.255.255,44.211.0.0-44.211.255.255,54.211.0.0-54.211.255.255,18.211.0.0-18.211.255.255,52.21.0.0-52.21.255.255,23.21.0.0-23.21.255.255,3.221.0.0-3.221.255.255,44.221.0.0-44.221.255.255,54.221.0.0-54.221.255.255,100.31.0.0-100.31.255.255,3.231.0.0-3.231.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=34.231.0.0-34.231.255.255,72.41.0.0-72.41.255.255,54.161.0.0-54.161.255.255,52.71.0.0-52.71.255.255,35.171.0.0-35.171.255.255,3.81.0.0-3.81.255.255,54.81.0.0-54.81.255.255,52.91.0.0-52.91.255.255,3.91.0.0-3.91.255.255,54.91.0.0-54.91.255.255,52.202.0.0-52.202.255.255,34.202.0.0-34.202.255.255,44.202.0.0-44.202.255.255,67.202.0.0-67.202.255.255,3.212.0.0-3.212.255.255,44.212.0.0-44.212.255.255,18.212.0.0-18.212.255.255,52.22.0.0-52.22.255.255,23.22.0.0-23.22.255.255,107.22.0.0-107.22.255.255,3.222.0.0-3.222.255.255,44.222.0.0-44.222.255.255,3.232.0.0-3.232.255.255,34.232.0.0-34.232.255.255,18.232.0.0-18.232.255.255,54.242.0.0-54.242.255.255,54.152.0.0-54.152.255.255,54.162.0.0-54.162.255.255,52.72.0.0-52.72.255.255,54.172.0.0-54.172.255.255,35.172.0.0-35.172.255.255,3.82.0.0-3.82.255.255,54.82.0.0-54.82.255.255,3.92.0.0-3.92.255.255,34.192.0.0-34.192.255.255,44.192.0.0-44.192.255.255,52.3.0.0-52.3.255.255,52.203.0.0-52.203.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=34.203.0.0-34.203.255.255,44.203.0.0-44.203.255.255,3.213.0.0-3.213.255.255,18.213.0.0-18.213.255.255,23.23.0.0-23.23.255.255,107.23.0.0-107.23.255.255,3.223.0.0-3.223.255.255,44.223.0.0-44.223.255.255,3.233.0.0-3.233.255.255,34.233.0.0-34.233.255.255,18.233.0.0-18.233.255.255,54.243.0.0-54.243.255.255,35.153.0.0-35.153.255.255,53.163.0.0-53.163.255.255,52.73.0.0-52.73.255.255,35.173.0.0-35.173.255.255,3.83.0.0-3.83.255.255,54.83.0.0-54.83.255.255,3.93.0.0-3.93.255.255,34.193.0.0-34.193.255.255,44.193.0.0-44.193.255.255,52.4.0.0-52.4.255.255,52.204.0.0-52.204.255.255,34.204.0.0-34.204.255.255,44.204.0.0-44.204.255.255,54.204.0.0-54.204.255.255,18.204.0.0-18.204.255.255,3.214.0.0-3.214.255.255,44.214.0.0-44.214.255.255,18.214.0.0-18.214.255.255,100.24.0.0-100.24.255.255,3.224.0.0-3.224.255.255,34.224.0.0-34.224.255.255,54.224.0.0-54.224.255.255,3.234.0.0-3.234.255.255,34.234.0.0-34.234.255.255,18.234.0.0-18.234.255.255,52.44.0.0-52.44.255.255,54.144.0.0-54.144.255.255,52.54.0.0-52.54.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=54.164.0.0-54.164.255.255,54.174.0.0-54.174.255.255,35.174.0.0-35.174.255.255,54.84.0.0-54.84.255.255,3.94.0.0-3.94.255.255,34.194.0.0-34.194.255.255,52.5.0.0-52.5.255.255,52.205.0.0-52.205.255.255,34.205.0.0-34.205.255.255,44.205.0.0-44.205.255.255,54.205.0.0-54.205.255.255,18.205.0.0-18.205.255.255,3.215.0.0-3.215.255.255,44.215.0.0-44.215.255.255,18.215.0.0-18.215.255.255,100.25.0.0-100.25.255.255,3.225.0.0-3.225.255.255,34.225.0.0-34.225.255.255,54.225.0.0-54.225.255.255,3.235.0.0-3.235.255.255,34.235.0.0-34.235.255.255,54.235.0.0-54.235.255.255,18.235.0.0-18.235.255.255,52.45.0.0-52.45.255.255,54.145.0.0-54.145.255.255,52.55.0.0-52.55.255.255,54.165.0.0-54.165.255.255,54.175.0.0-54.175.255.255,35.175.0.0-35.175.255.255,3.85.0.0-3.85.255.255,54.85.0.0-54.85.255.255,3.95.0.0-3.95.255.255,34.195.0.0-34.195.255.255,44.195.0.0-44.195.255.255,52.6.0.0-52.6.255.255,52.206.0.0-52.206.255.255,34.206.0.0-34.206.255.255,44.206.0.0-44.206.255.255,18.206.0.0-18.206.255.255,50.16.0.0-50.16.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=3.208.0.0-3.208.255.255,44.208.0.0-44.208.255.255,54.208.0.0-54.208.255.255,18.208.0.0-18.208.255.255,3.218.0.0-3.218.255.255,100.28.0.0-100.28.255.255,3.228.0.0-3.228.255.255,34.228.0.0-34.228.255.255,3.238.0.0-3.238.255.255,34.238.0.0-34.238.255.255,54.158.0.0-54.158.255.255,35.168.0.0-35.168.255.255,3.88.0.0-3.88.255.255,34.198.0.0-34.198.255.255,44.198.0.0-44.198.255.255,54.198.0.0-54.198.255.255,3.209.0.0-3.209.255.255,54.209.0.0-54.209.255.255,18.209.0.0-18.209.255.255,50.19.0.0-50.19.255.255,3.219.0.0-3.219.255.255,44.219.0.0-44.219.255.255,100.29.0.0-100.29.255.255,174.129.0.0-174.129.255.255,3.229.0.0-3.229.255.255,34.229.0.0-34.229.255.255,3.239.0.0-3.239.255.255,54.159.0.0-54.159.255.255,35.169.0.0-35.169.255.255,3.89.0.0-3.89.255.255,54.89.0.0-54.89.255.255,34.199.0.0-34.199.255.255,44.199.0.0-44.199.255.255,52.0.100.0-52.0.255.255,52.200.100.0-52.200.255.255,34.200.100.0-34.200.255.255,44.200.100.0-44.200.255.255,44.210.100.0-44.210.255.255,54.210.100.0-54.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=18.210.100.0-18.210.255.255,52.20.100.0-52.20.255.255,23.20.100.0-23.20.255.255,107.20.100.0-107.20.255.255,3.220.100.0-3.220.255.255,44.220.100.0-44.220.255.255,100.30.100.0-100.30.255.255,3.230.100.0-3.230.255.255,34.230.100.0-34.230.255.255,54.160.100.0-54.160.255.255,52.70.100.0-52.70.255.255,3.80.100.0-3.80.255.255,54.80.100.0-54.80.255.255,52.90.100.0-52.90.255.255,3.90.100.0-3.90.255.255,54.90.100.0-54.90.255.255,52.1.100.0-52.1.255.255,52.201.100.0-52.201.255.255,34.201.100.0-34.201.255.255,3.211.100.0-3.211.255.255,54.211.100.0-54.211.255.255,18.211.100.0-18.211.255.255,52.21.100.0-52.21.255.255,23.21.100.0-23.21.255.255,107.21.100.0-107.21.255.255,3.221.100.0-3.221.255.255,44.221.100.0-44.221.255.255,54.221.100.0-54.221.255.255,3.231.100.0-3.231.255.255,34.231.100.0-34.231.255.255,54.161.100.0-54.161.255.255,52.71.100.0-52.71.255.255,3.81.100.0-3.81.255.255,54.81.100.0-54.81.255.255,52.91.100.0-52.91.255.255,3.91.100.0-3.91.255.255,54.91.100.0-54.91.255.255,52.2.100.0-52.2.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=52.202.100.0-52.202.255.255,34.202.100.0-34.202.255.255,44.202.100.0-44.202.255.255,3.212.100.0-3.212.255.255,44.212.100.0-44.212.255.255,18.212.100.0-18.212.255.255,52.22.100.0-52.22.255.255,23.22.100.0-23.22.255.255,3.222.100.0-3.222.255.255,44.222.100.0-44.222.255.255,3.232.100.0-3.232.255.255,34.232.100.0-34.232.255.255,18.232.100.0-18.232.255.255,54.152.100.0-54.152.255.255,54.162.100.0-54.162.255.255,52.72.100.0-52.72.255.255,184.72.100.0-184.72.255.255,54.172.100.0-54.172.255.255,35.172.100.0-35.172.255.255,3.82.100.0-3.82.255.255,54.82.100.0-54.82.255.255,34.192.100.0-34.192.255.255,44.192.100.0-44.192.255.255,52.3.100.0-52.3.255.255,52.203.100.0-52.203.255.255,34.203.100.0-34.203.255.255,44.203.100.0-44.203.255.255,3.213.100.0-3.213.255.255,44.213.100.0-44.213.255.255,18.213.100.0-18.213.255.255,52.23.100.0-52.23.255.255,107.23.100.0-107.23.255.255,3.223.100.0-3.223.255.255,3.233.100.0-3.233.255.255,34.233.100.0-34.233.255.255,18.233.100.0-18.233.255.255,54.243.100.0-54.243.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=35.153.100.0-35.153.255.255,54.163.100.0-54.163.255.255,52.73.100.0-52.73.255.255,184.73.100.0-184.73.255.255,54.173.100.0-54.173.255.255,35.173.100.0-35.173.255.255,3.83.100.0-3.83.255.255,54.83.100.0-54.83.255.255,3.93.100.0-3.93.255.255,34.193.100.0-34.193.255.255,44.193.100.0-44.193.255.255,52.4.100.0-52.4.255.255,52.204.100.0-52.204.255.255,44.204.100.0-44.204.255.255,54.204.100.0-54.204.255.255,18.204.100.0-18.204.255.255,3.214.100.0-3.214.255.255,44.214.100.0-44.214.255.255,18.214.100.0-18.214.255.255,100.24.100.0-100.24.255.255,3.224.100.0-3.224.255.255,54.224.100.0-54.224.255.255,3.234.100.0-3.234.255.255,54.234.100.0-54.234.255.255,18.234.100.0-18.234.255.255,52.44.100.0-52.44.255.255,54.144.100.0-54.144.255.255,52.54.100.0-52.54.255.255,54.164.100.0-54.164.255.255,54.174.100.0-54.174.255.255,35.174.100.0-35.174.255.255,3.84.100.0-3.84.255.255,54.84.100.0-54.84.255.255,3.94.100.0-3.94.255.255,34.194.100.0-34.194.255.255,44.194.100.0-44.194.255.255,52.5.100.0-52.5.255.255,52.205.100.0-52.205.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=34.205.100.0-34.205.255.255,44.205.100.0-44.205.255.255,54.205.100.0-54.205.255.255,18.205.100.0-18.205.255.255,3.215.100.0-3.215.255.255,44.215.100.0-44.215.255.255,18.215.100.0-18.215.255.255,100.25.100.0-100.25.255.255,3.225.100.0-3.225.255.255,34.225.100.0-34.225.255.255,54.225.100.0-54.225.255.255,3.235.100.0-3.235.255.255,34.235.100.0-34.235.255.255,54.235.100.0-54.235.255.255,18.235.100.0-18.235.255.255,52.45.100.0-52.45.255.255,54.145.100.0-54.145.255.255,52.55.100.0-52.55.255.255,35.175.100.0-35.175.255.255,3.85.100.0-3.85.255.255,54.85.100.0-54.85.255.255,3.95.100.0-3.95.255.255,34.195.100.0-34.195.255.255,52.6.100.0-52.6.255.255,52.206.100.0-52.206.255.255,34.206.100.0-34.206.255.255,44.206.100.0-44.206.255.255,18.206.100.0-18.206.255.255,50.16.100.0-50.16.255.255,3.216.100.0-3.216.255.255,44.216.100.0-44.216.255.255,100.26.100.0-100.26.255.255,3.226.100.0-3.226.255.255,34.226.100.0-34.226.255.255,54.226.100.0-54.226.255.255,3.236.100.0-3.236.255.255,34.236.100.0-34.236.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=54.236.100.0-54.236.255.255,54.146.100.0-54.146.255.255,54.156.100.0-54.156.255.255,54.166.100.0-54.166.255.255,52.86.100.0-52.86.255.255,3.86.100.0-3.86.255.255,54.86.100.0-54.86.255.255,34.196.100.0-34.196.255.255,44.196.100.0-44.196.255.255,52.7.100.0-52.7.255.255,52.207.100.0-52.207.255.255,34.207.100.0-34.207.255.255,44.207.100.0-44.207.255.255,18.207.100.0-18.207.255.255,50.17.100.0-50.17.255.255,3.217.100.0-3.217.255.255,44.217.100.0-44.217.255.255,100.27.100.0-100.27.255.255,3.227.100.0-3.227.255.255,34.227.100.0-34.227.255.255,54.227.100.0-54.227.255.255,3.237.100.0-3.237.255.255,34.237.100.0-34.237.255.255,54.237.100.0-54.237.255.255,54.147.100.0-54.147.255.255,54.157.100.0-54.157.255.255,54.167.100.0-54.167.255.255,52.87.100.0-52.87.255.255,3.87.100.0-3.87.255.255,54.87.100.0-54.87.255.255,44.197.100.0-44.197.255.255,54.197.100.0-54.197.255.255,3.208.100.0-3.208.255.255,44.208.100.0-44.208.255.255,54.208.100.0-54.208.255.255,18.208.100.0-18.208.255.255,3.218.100.0-3.218.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=52.20.200.0-52.20.255.255,18.210.200.0-18.210.255.255,23.20.200.0-23.20.255.255,107.20.200.0-107.20.255.255,3.220.200.0-3.220.255.255,44.220.200.0-44.220.255.255,100.30.200.0-100.30.255.255,3.230.200.0-3.230.255.255,34.230.200.0-34.230.255.255,54.160.200.0-54.160.255.255,52.70.200.0-52.70.255.255,35.170.200.0-35.170.255.255,3.80.200.0-3.80.255.255,54.80.200.0-54.80.255.255,52.90.200.0-52.90.255.255,3.90.200.0-3.90.255.255,54.90.200.0-54.90.255.255,52.1.200.0-52.1.255.255,75.101.200.0-75.101.255.255,52.201.200.0-52.201.255.255,34.201.200.0-34.201.255.255,44.201.200.0-44.201.255.255,3.211.200.0-3.211.255.255,44.211.200.0-44.211.255.255,18.211.200.0-18.211.255.255,52.21.200.0-52.21.255.255,23.21.200.0-23.21.255.255,107.21.200.0-107.21.255.255,3.221.200.0-3.221.255.255,44.221.200.0-44.221.255.255,54.221.200.0-54.221.255.255,100.31.200.0-100.31.255.255,3.231.200.0-3.231.255.255,34.231.200.0-34.231.255.255,54.161.200.0-54.161.255.255,52.71.200.0-52.71.255.255,35.171.200.0-35.171.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=44.216.0.0-44.216.255.255,100.26.0.0-100.26.255.255,3.226.0.0-3.226.255.255,34.226.0.0-34.226.255.255,54.226.0.0-54.226.255.255,3.236.0.0-3.236.255.255,34.236.0.0-34.236.255.255,54.236.0.0-54.236.255.255,54.146.0.0-54.146.255.255,54.166.0.0-54.166.255.255,52.86.0.0-52.86.255.255,3.86.0.0-3.86.255.255,54.86.0.0-54.86.255.255,34.196.0.0-34.196.255.255,44.196.0.0-44.196.255.255,54.196.0.0-54.196.255.255,52.7.0.0-52.7.255.255,34.207.0.0-34.207.255.255,44.207.0.0-44.207.255.255,18.207.0.0-18.207.255.255,50.17.0.0-50.17.255.255,3.217.0.0-3.217.255.255,44.217.0.0-44.217.255.255,100.27.0.0-100.27.255.255,3.227.0.0-3.227.255.255,34.227.0.0-34.227.255.255,54.227.0.0-54.227.255.255,3.237.0.0-3.237.255.255,34.237.0.0-34.237.255.255,54.237.0.0-54.237.255.255,54.147.0.0-54.147.255.255,54.157.0.0-54.157.255.255,54.167.0.0-54.167.255.255,15.177.0.0-15.177.255.255,52.87.0.0-52.87.255.255,3.87.0.0-3.87.255.255,54.87.0.0-54.87.255.255,34.197.0.0-34.197.255.255,44.197.0.0-44.197.255.255,54.197.0.0-54.197.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=174.129.100.0-174.129.255.255,3.229.100.0-3.229.255.255,34.229.100.0-34.229.255.255,3.239.100.0-3.239.255.255,34.239.100.0-34.239.255.255,54.159.100.0-54.159.255.255,35.169.100.0-35.169.255.255,3.89.100.0-3.89.255.255,54.89.100.0-54.89.255.255,34.199.100.0-34.199.255.255,44.199.100.0-44.199.255.255,52.0.200.0-52.0.255.255,52.200.200.0-52.200.255.255,34.200.200.0-52.200.255.255,44.200.200.0-44.200.255.255,3.210.200.0-3.210.255.255,44.210.200.0-44.210.255.255,54.210.200.0-54.210.255.255,18.210.200.0-18.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=54.160.0.0-54.160.255.255,52.70.0.0-52.70.255.255,35.170.0.0-35.170.255.255,54.80.0.0-54.80.255.255,52.90.0.0-52.90.255.255,3.90.0.0-3.90.255.255,54.90.0.0-54.90.255.255,52.1.0.0-52.1.255.255,52.201.0.0-52.201.255.255,34.201.0.0-34.201.255.255,44.201.0.0-44.201.255.255,3.211.0.0-3.211.255.255,44.211.0.0-44.211.255.255,54.211.0.0-54.211.255.255,18.211.0.0-18.211.255.255,52.21.0.0-52.21.255.255,23.21.0.0-23.21.255.255,3.221.0.0-3.221.255.255,44.221.0.0-44.221.255.255,54.221.0.0-54.221.255.255,100.31.0.0-100.31.255.255,3.231.0.0-3.231.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=44.218.100.0-44.218.255.255,100.28.100.0-100.28.255.255,3.228.100.0-3.228.255.255,34.228.100.0-34.228.255.255,3.238.100.0-3.238.255.255,34.238.100.0-34.238.255.255,54.158.100.0-54.158.255.255,35.168.100.0-35.168.255.255,34.198.100.0-34.198.255.255,44.198.100.0-44.198.255.255,54.198.100.0-54.198.255.255,3.209.100.0-3.209.255.255,44.209.100.0-44.209.255.255,54.209.100.0-54.209.255.255,18.209.100.0-18.209.255.255,3.219.100.0-3.219.255.255,44.219.100.0-44.219.255.255,100.29.100.0-100.29.255.255,174.129.100.0-174.129.255.255,3.229.100.0-3.229.255.255,34.229.100.0-34.229.255.255,3.239.100.0-3.239.255.255,34.239.100.0-34.239.255.255,54.159.100.0-54.159.255.255,35.169.100.0-35.169.255.255,3.89.100.0-3.89.255.255,54.89.100.0-54.89.255.255,34.199.100.0-34.199.255.255,44.199.100.0-44.199.255.255,52.0.200.0-52.0.255.255,52.200.200.0-52.200.255.255,34.200.200.0-52.200.255.255,44.200.200.0-44.200.255.255,3.210.200.0-3.210.255.255,44.210.200.0-44.210.255.255,54.210.200.0-54.210.255.255,18.210.200.0-18.210.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UniFairy protocol=ANY dir=out remoteip=207.171.0.0-207.171.255.255,207.171.0.0-207.171.255.255,54.239.0.0-54.239.255.255,207.171.0.0-207.171.255.255,34.200.0.0-34.200.255.255,44.200.0.0-44.200.255.255,3.210.0.0-3.210.255.255,44.210.0.0-44.210.255.255,54.210.0.0-54.210.255.255,18.210.0.0-18.210.255.255,52.20.0.0-52.20.255.255,23.20.0.0-23.20.255.255,107.20.0.0-107.20.255.255,3.220.0.0-3.220.255.255,44.220.0.0-44.220.255.255,100.30.0.0-100.30.255.255,3.230.0.0-3.230.255.255,34.230.0.0-34.230.255.255,54.160.0.0-54.160.255.255,52.70.0.0-52.70.255.255,35.170.0.0-35.170.255.255,54.80.0.0-54.80.255.255,52.90.0.0-52.90.255.255,3.90.0.0-3.90.255.255,54.90.0.0-54.90.255.255,52.1.0.0-52.1.255.255,52.201.0.0-52.201.255.255,34.201.0.0-34.201.255.255,44.201.0.0-44.201.255.255,3.211.0.0-3.211.255.255,44.211.0.0-44.211.255.255,54.211.0.0-54.211.255.255,18.211.0.0-18.211.255.255,52.21.0.0-52.21.255.255,23.21.0.0-23.21.255.255,3.221.0.0-3.221.255.255,44.221.0.0-44.221.255.255,54.221.0.0-54.221.255.255,100.31.0.0-100.31.255.255,3.231.0.0-3.231.255.255 action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void DEXSTERLOOP_IN_OUT()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK1 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=in remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK2 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=in remoteip=183.57.48.55 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK3 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=out remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK4 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=out remoteip=183.57.48.55 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK5 protocol=ANY dir=in remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK6 protocol=ANY dir=in remoteip=183.57.48.55 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK7 protocol=ANY dir=in remoteip=203.205.0.0-203.205.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK8 protocol=ANY dir=in remoteip=183.57.0.0-183.57.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK9 protocol=ANY dir=out remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK10 protocol=ANY dir=out remoteip=183.57.48.55 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK11 protocol=ANY dir=out remoteip=203.205.0.0-203.205.255.255 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK12 protocol=ANY dir=out remoteip=183.57.0.0-183.57.255.255 action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            if (siticoneWinToggleSwith1.Checked)
            {
                InputRegistryHigh();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.High_Ver);
            }
            else if (siticoneWinToggleSwith2.Checked)
            {
                InputRegistryLow();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Low_Ver);
            }
            else if (siticoneWinToggleSwith3.Checked)
            {

                InputRegistrySmart();
                for (i = 0; i <= 70; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Smart_Ver);
            }
            else if (siticoneWinToggleSwith4.Checked)
            {
                InputRegistryHigh();
                for (i = 0; i <= 55; i++)
                {
                    siticoneProgressBar1.Value = i;
                    siticoneLabel12.ForeColor = Color.Gray;
                    siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
                }
                File.WriteAllText(@"D:\\TxGameAssistant\\ui\Config.ini", Resources.Normal_Ver);
            }
        }
        private void TCP_IN()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN1 protocol=TCP remoteport=53 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN2 protocol=TCP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN3 protocol=TCP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN4 protocol=TCP remoteport=1-21,23-24,26-49,52-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN5 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN6 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN7 protocol=TCP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN8 protocol=TCP remoteport=5228,58741,8013,8080,8081,8006,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN9 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN10 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN11 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN12 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN13 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN14 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }
        private void TCP_OUT()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT1 protocol=TCP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT2 protocol=TCP remoteport=1-21,23-24,26-49,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT3 protocol=TCP remoteport=53 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT4 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=80 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT5 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT6 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT7 protocol=TCP remoteport=5228,58741,8013,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT8 protocol=TCP remoteport=5228,58741,8013,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT9 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,19000-25000,18000-19000,10000-15000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT10 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,19000-25000,18000-19000,10000-15000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT11 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT12 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT13 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCPO_OUT14 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }
        private void UDP_IN()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN1 protocol=UDP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN2 protocol=UDP remoteport=1-21,23-24,26-49,52-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN3 protocol=UDP remoteport=53 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN4 protocol=UDP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN5 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN6 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN7 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN8 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN9 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN10 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN11 protocol=UDP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN12 protocol=UDP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN13 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN14 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void UDP_OUT()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT1 protocol=UDP remoteport=1-21,23-24,26-49,52,54-79,81-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT2 protocol=UDP remoteport=1-20,23-24,26-49,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT3 protocol=UDP remoteport=80,443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT4 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=UDP remoteport=53 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT5 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=UDP remoteport=52-79 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT6 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT7 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT8 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT9 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT10 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,18000-19000,21000-25000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT11 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,18000-19000,21000-25000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT12 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT13 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT14 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT15 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }

        }
        private void DEL_Rule()
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
                standardInput.WriteLine("netsh advfirewall firewall delete rule name=SAFEOUTVN");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void IN_Ports()
        {
            SpawnPortsBlocked();
            TCP_IN();
            UDP_IN();
        }
        private void OUT_PortsVer_1()
        {
            TCP_OUT();
            UDP_OUT();
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXSTERLOOPUPDATE interface=any dir=out action=block remoteip=203.205.0.0-203.205.255.255,123.151.0.0-123.151.255.255,58.250.0.0-58.250.255.255,113.105.0.0-113.105.255.255");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEIN8 protocol=TCP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEIN10 protocol=UDP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUT6 protocol=UDP remoteport=80,443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVER1 program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=80,443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8080 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8013 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8081 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8088 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8089 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8080 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8013 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8081 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8086 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8088 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8089 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8080 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8013 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8081 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8088 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8089 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8080 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8013 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8081 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8086 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8088 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8089 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=10404 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=10012 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=13003 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=13004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=15692 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8081 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=8013 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=20371 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=23946 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=27042 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=27043 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8080 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8013 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8081 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8088 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8089 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=10404 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=10012 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=13003 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=13004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=15692 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8081 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=8013 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=20371 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=23946 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=27042 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=UDP remoteport=27043 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=20371 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=23946 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=27042 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=NORMAL protocol=TCP remoteport=27043 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void FakeRegistry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent");
            key.SetValue("1", "1");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
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
        private void InputRegistryHigh()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\AOW_Rootfs_100");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\AOW_Rootfs_100");
            key.SetValue("Version", "4.1.25.90");
            key.SetValue("InstallDone", 1, RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UI");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\UI");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("TempPath", "D:\\Temp\\TxGameDownload\\Component\\");
            key.SetValue("UserLanguage", "en");
            key.SetValue("DirectxVersion", 10, RegistryValueKind.DWord);
            key.SetValue("com.tencent.ig_ContentScale", 1, RegistryValueKind.DWord);
            key.SetValue("dpiAware", 0, RegistryValueKind.DWord);
            key.SetValue("VMCpuCount", 8, RegistryValueKind.DWord);
            key.SetValue("VMResWidth", 1920, RegistryValueKind.DWord);
            key.SetValue("VMResHeight", 1080, RegistryValueKind.DWord);
            key.SetValue("FxaaQuality", 0, RegistryValueKind.DWord);
            key.SetValue("GraphicsCardEnabled", 1, RegistryValueKind.DWord);
            key.SetValue("LocalShaderCacheEnabled", 1, RegistryValueKind.DWord);
            key.SetValue("VMMemorySizeInMB", 8192, RegistryValueKind.DWord);
            key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            key.SetValue("ForceDirectX", 3, RegistryValueKind.DWord);
            key.SetValue("RenderOptimizeEnabled", 1, RegistryValueKind.DWord);
            key.SetValue("ShaderCacheEnabled", 1, RegistryValueKind.DWord);
            key.SetValue("VMDPI", 480, RegistryValueKind.DWord);
            key.SetValue("VSyncEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMDeviceManufacturer", "samsung");
            key.SetValue("VMDeviceModel", "ASUS_I001DA");
            key.SetValue("com.tencent.ig_RenderQuality", 2, RegistryValueKind.DWord);
            key.Close();
        }
        private void InputRegistryLow()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\AOW_Rootfs_100");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\AOW_Rootfs_100");
            key.SetValue("Version", "4.1.25.90");
            key.SetValue("InstallDone", 1, RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UI");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\UI");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UIData");
            key.SetValue("Version", "4.1.25.90");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("TempPath", "D:\\Temp\\TxGameDownload\\Component\\");
            key.SetValue("UserLanguage", "en");
            key.SetValue("DirectxVersion", 12, RegistryValueKind.DWord);
            key.SetValue("com.tencent.ig_ContentScale", 0, RegistryValueKind.DWord);
            key.SetValue("dpiAware", 1, RegistryValueKind.DWord);
            key.SetValue("VMCpuCount", 0, RegistryValueKind.DWord);
            key.SetValue("VMResWidth", 852, RegistryValueKind.DWord);
            key.SetValue("VMResHeight", 480, RegistryValueKind.DWord);
            key.SetValue("FxaaQuality", 0, RegistryValueKind.DWord);
            key.SetValue("GraphicsCardEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("LocalShaderCacheEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMMemorySizeInMB", 0, RegistryValueKind.DWord);
            key.SetValue("EnableGLESv3", 0, RegistryValueKind.DWord);
            key.SetValue("ForceDirectX", 3, RegistryValueKind.DWord);
            key.SetValue("RenderOptimizeEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("ShaderCacheEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMDPI", 480, RegistryValueKind.DWord);
            key.SetValue("VSyncEnabled", 0, RegistryValueKind.DWord);
            key.SetValue("VMDeviceManufacturer", "samsung");
            key.SetValue("VMDeviceModel", "ASUS_I001DA");
            key.SetValue("com.tencent.ig_RenderQuality", 0, RegistryValueKind.DWord);
            key.Close();
        }
        private void InputRegistrySmart()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\AOW_Rootfs_100");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\AOW_Rootfs_100");
            key.SetValue("Version", "4.1.25.90");
            key.SetValue("InstallDone", 1, RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UI");
            key.SetValue("InstallPath", "D:\\TxGameAssistant\\UI");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UIData");
            key.SetValue("Version", "4.1.25.90");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("UserLanguage", "en");
            key.SetValue("com.tencent.ig_ContentScale", 1, RegistryValueKind.DWord);
            key.SetValue("dpiAware", 1, RegistryValueKind.DWord);
            key.SetValue("VMResWidth", 1920, RegistryValueKind.DWord);
            key.SetValue("VMResHeight", 1080, RegistryValueKind.DWord);
            key.SetValue("VMDPI",240, RegistryValueKind.DWord);
            key.SetValue("VMDeviceManufacturer", "samsung");
            key.SetValue("VMDeviceModel", "ASUS_I001DA");
            key.SetValue("com.tencent.ig_RenderQuality", 0, RegistryValueKind.DWord);
            key.Close();
        }       
        private void Resources_Directory_REPLACE()
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
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
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
            NewDirectory();
            UI_REPLACE();

        }
        private void NewDirectory()
        {
            string Anti1 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\0";
            if (File.Exists(Anti1))
            {
                File.Delete((Anti1));
            }
            string Anti2 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\0.ini";
            if (File.Exists(Anti2))
            {
                File.Delete((Anti2));
            }
            string Anti3 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\30";
            if (File.Exists(Anti3))
            {
                File.Delete((Anti3));
            }
            string Anti4 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\30.ini";
            if (File.Exists(Anti4))
            {
                File.Delete((Anti4));
            }
            string Anti5 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\367";
            if (File.Exists(Anti5))
            {
                File.Delete((Anti5));
            }
            string Anti6 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\367.ini";
            if (File.Exists(Anti6))
            {
                File.Delete((Anti6));
            }
            string Anti7 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\300";
            if (File.Exists(Anti7))
            {
                File.Delete((Anti7));
            }
            string Anti8 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\300.ini";
            if (File.Exists(Anti8))
            {
                File.Delete((Anti8));
            }
            string Anti9 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\188";
            if (File.Exists(Anti9))
            {
                File.Delete((Anti9));
            }
            string Anti10 = @"D:\TxGameAssistant\AOW_Rootfs_100\0\188.ini";
            if (File.Exists(Anti10))
            {
                File.Delete((Anti10));
            }
            string root = @"C:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root))
            {
                Directory.Delete(root, true);
            }
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root1))
            {
                Directory.Delete(root1, true);
            }
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root2))
            {
                Directory.Delete(root2, true);
            }
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root3))
            {
                Directory.Delete(root3, true);
            }
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root4))
            {
                Directory.Delete(root4, true);
            }
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root5))
            {
                Directory.Delete(root5, true);
            }
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root6))
            {
                Directory.Delete(root6, true);
            }
            string root9 = @"C:\\TxGameAssistant";
            if (Directory.Exists(root9))
            {
                Directory.Delete(root9, true);
            }
            string root10 = @"D:\\TxGameAssistant\\ui";
            if (Directory.Exists(root10))
            {
                Directory.Delete(root10, true);
            }
            string root11 = @"E:\\TxGameAssistant";
            if (Directory.Exists(root11))
            {
                Directory.Delete(root1, true);
            }
            string root12 = @"F:\\TxGameAssistant";
            if (Directory.Exists(root12))
            {
                Directory.Delete(root12, true);
            }
            string root13 = @"G:\\TxGameAssistant";
            if (Directory.Exists(root13))
            {
                Directory.Delete(root13, true);
            }
            string root14 = @"H:\\TxGameAssistant";
            if (Directory.Exists(root14))
            {
                Directory.Delete(root14, true);
            }
            string root15 = @"I:\\TxGameAssistant";
            if (Directory.Exists(root15))
            {
                Directory.Delete(root15, true);
            }
            string root110 = @"D:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root110))
            {
                Directory.Delete(root110, true);
            }
            string root19 = @"D:\\Temp";
            if (Directory.Exists(root19))
            {
                Directory.Delete(root19, true);
            }
            string root20 = @"E:\\Temp";
            if (Directory.Exists(root20))
            {
                Directory.Delete(root20, true);
            }
            string root21 = @"F:\\Temp";
            if (Directory.Exists(root21))
            {
                Directory.Delete(root21, true);
            }
            string root22 = @"G:\\Temp";
            if (Directory.Exists(root22))
            {
                Directory.Delete(root22, true);
            }
            string root23 = @"H:\\Temp";
            if (Directory.Exists(root23))
            {
                Directory.Delete(root23, true);
            }
            string root24 = @"I:\\Temp";
            if (Directory.Exists(root24))
            {
                Directory.Delete(root24, true);
            }
            string root27 = @"C:\\Temp";
            if (Directory.Exists(root27))
            {
                Directory.Delete(root27, true);
            }
        }
        private void UI_REPLACE()
        {
            string root28 = @"D:\\TxGameAssistant\\ui";
            if (Directory.Exists(root28))
            {
                MessageBox.Show("Unknown Error Occured", "Team DEXSTER",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Directory.CreateDirectory("D:\\TxGameAssistant\\");
                string zipPath = @"C:\Windows\SystemDEXV11.zip";
                string extractPath = @"D:\TxGameAssistant\";
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
        private void Start7()
        {
            string start = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            Process.Start(Path.Combine(start) + "/AndroidEmulator.exe", "-vm 100"); 
        }
        private void siticoneLabel5_Click(object sender, EventArgs e)
        {

        }

        private void siticoneProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneLabel12_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneWinToggleSwith8_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith8.Checked)
            {
                Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
                if (localByName.Length > 0)
                {
                    if (siticoneWinToggleSwith8.Checked)
                    {
                        pictureBox1.Visible = true;
                        pictureBox1.Enabled = true;
                        Run_Pubg();
                    }
                    else
                    {
                    }
                }
                else
                {
                    siticoneLabel5.Text = "Run The Emulator First";
                    siticoneWinToggleSwith8.Checked = false;
                }

            }
        }
        private async void Run_Pubg()
        {
            await Task.Run(() => Pubg());
        }
        private async void Pubg()
        {
            await Task.Run(() => CheckResources());
            for (i = 0; i <= 10; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DISABLED());
            for (i = 0; i <= 30; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            await Task.Run(() => IN_Ports());
            for (i = 0; i <= 50; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => OUT_PortsVer_1());
            for (i = 0; i <= 60; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => ENABLED());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            await Task.Run(() => DEXSTERLOOP_Device_ID());
            for (i = 0; i <= 70; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => StartingCode_V1());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString();
            }
            siticoneLabel5.Text = "Success";
        }
        private void DISABLED()
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
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=DISABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void ENABLED()
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
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=ENABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void PORT_OPEN()
        {
            System.Timers.Timer timer = new System.Timers.Timer(30000);
            timer.AutoReset = true;
            timer.Elapsed += PORT_OPEN_elapsed;
            timer.Start();
        }
        private void PORT_OPEN_elapsed(object sender, ElapsedEventArgs e)
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void NEW_METHOD_Safe()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void NEW_METHOD_Risk()
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void PORT_CLOSE()
        {
            System.Timers.Timer timer = new System.Timers.Timer(25000);
            timer.AutoReset = true;
            timer.Elapsed += PORT_CLOSE_elapsed;
            timer.Start();
        }
        private void PORT_CLOSE_elapsed(object sender, ElapsedEventArgs e)
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=SAFEOUTVN program=D:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=443 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Ver_Checker()
        {
            //string answer = siticoneLabel19.Text.ToString();
           // if (answer == "Safe")
            {
                NEW_METHOD_Safe();
            }
           // else if (answer == "Risk")
            {
                NEW_METHOD_Risk();
            }
        }
        private void kill()
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
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.WriteLine("del /s /f /q %USERPROFILE%\appdata\\local\temp\\*.*");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void CheckResources()
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
        private void DEVICE_ID_CHANGER()
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
                standardInput.WriteLine("adb -s emulator-5554 shell settings get secure android_id");
                standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id  " + SP + ST + " ");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void StartingCode_V1()
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
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 500 /proc");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Active.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/AgreeIllegalAvatarRule.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/BP_WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Cached.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/iTOPPrefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/SettingConfig_Slot.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Active.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/AgreeIllegalAvatarRule.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/BP_WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Cached.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/iTOPPrefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/SettingConfig_Slot.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /default.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/build.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.vbox86.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/hw/gralloc.vbox86.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/xbin/su");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.titan.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /fstab.vbox86");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /default.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libhardware.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.vbox86.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/hw/gralloc.vbox86.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libbcinfo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /init.superuser.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/bin/androVM_setprop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /.libcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libhardware.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/ContactsProvider/ContactsProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DefaultContainerService/DefaultContainerService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DocumentsUI/DocumentsUI.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DownloadProvider/DownloadProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/ExtServices/ExtServices.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/FusedLocation/FusedLocation.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/GoogleLoginService/GoogleLoginService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/GoogleServicesFramework/GoogleServicesFramework.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/InputDevices/InputDevices.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/MediaProvider/MediaProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/PackageInstaller/PackageInstaller.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Phonesky/Phonesky.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/PlayGames/PlayGames.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Provision/Provision.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Settings/Settings.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/SettingsProvider/SettingsProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Shell/Shell.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/StatementService/StatementService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/SystemUI/SystemUI.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/TelephonyProvider/TelephonyProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell mv /init.vbox86.rc /init.vbox86.rc1");
                standardInput.WriteLine("adb -s emulator-5554 shell mv /system/build.prop /system/build.prop1");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine("adb -s emulator-5554 shell sleep 120");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            Lobby_PORTS();
            FakeRegistry();
            Registry_CHECKER();
            kill();
            LobbyAntiban();
        }
        private void Registry_CHECKER()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Elapsed += Registry_CHECKER_elapsed;
            timer.Start();
        }
        private void Registry_CHECKER_elapsed(object sender, ElapsedEventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                RegistryDelete();
            }
        }
        private void Lobby_PORTS()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY protocol=TCP remoteport=8080,8081,8088,8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY protocol=UDP remoteport=8080,8081,8088,8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY protocol=TCP remoteport=8081,8088,8086 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY protocol=UDP remoteport=8080,8081,8088,8086 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Anti()
        {
            string Anti1 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\0";
            if (File.Exists(Anti1))
            {
                File.Delete((Anti1));
            }
            string Anti2 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\0.ini";
            if (File.Exists(Anti2))
            {
                File.Delete((Anti2));
            }
            string Anti3 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\30";
            if (File.Exists(Anti3))
            {
                File.Delete((Anti3));
            }
            string Anti4 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\30.ini";
            if (File.Exists(Anti4))
            {
                File.Delete((Anti4));
            }
            string Anti5 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\367";
            if (File.Exists(Anti5))
            {
                File.Delete((Anti5));
            }
            string Anti6 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\367.ini";
            if (File.Exists(Anti6))
            {
                File.Delete((Anti6));
            }
            string Anti8 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\300.ini";
            if (File.Exists(Anti8))
            {
                File.Delete((Anti8));
            }
            string Anti9 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\188";
            if (File.Exists(Anti9))
            {
                File.Delete((Anti9));
            }
            string Anti10 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\188.ini";
            if (File.Exists(Anti10))
            {
                File.Delete((Anti10));
            }

        }
        private void LobbyAntiban()
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
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libapp.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libBugly.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libcubehawk.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libhelpshiftlistener.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libigshare.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libijkffmpeg.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libImSDK.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libITOP.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libkk-image.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/liblbs.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libmarsxlog.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libmmkv.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libnpps-jni.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsentry.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsentry-android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libst-engine.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libswappy.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtgpa.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtprt.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libvlink.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libzip.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libzlib.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libc++_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libdiscord_connect_sdk_android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libflutter.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudarch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudcore.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libGCloudVoice.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgnustl_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libPandoraVideo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsoundtouch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libapp.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libBugly.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libcubehawk.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libhelpshiftlistener.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libigshare.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libijkffmpeg.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libImSDK.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libITOP.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libkk-image.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/liblbs.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libmarsxlog.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libmmkv.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libnpps-jni.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsentry.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsentry-android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libst-engine.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libswappy.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtgpa.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtprt.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libvlink.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libzip.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libzlib.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libc++_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libdiscord_connect_sdk_android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libflutter.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudarch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudcore.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libGCloudVoice.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgnustl_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libPandoraVideo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsoundtouch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void DEXSTERLOOP_Device_ID()
        {
            string path = "C:\\DEXSTERLOOP_Device_ID.txt";
            if (File.Exists(path))
            {
                string SP = File.ReadAllText(path);
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
                    standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.manufacturer " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.runtime.firstboot " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.device " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop android.device.id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.model " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.brand " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.name " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.mac_address " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop net.hostname " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.serialno " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop gaid " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell content insert --uri content://settings/secure --bind name:s:android_id --bind value:s:" + SP + "");
                    standardInput.Flush();
                    standardInput.Close();
                    process.WaitForExit();
                }
            }
            else
            {
                string validchars = "a5b3cd0efg8hij5k9lm6n8op3qr7s2tu6vw5xy4z";
                var sb = new StringBuilder();
                var rand = new Random();
                for (int i = 1; i <= 34; i++)
                {
                    int idx = rand.Next(0, validchars.Length);
                    char randomChar = validchars[idx];
                    sb.Append(randomChar);
                }
                SP = sb.ToString();
                string Key = "C:\\";
                File.WriteAllText(Path.Combine(Key, "DEXSTERLOOP_Device_ID.txt"), SP);
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
                    standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.manufacturer " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.runtime.firstboot " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.device " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop android.device.id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.model " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.brand " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.name " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.mac_address " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop net.hostname " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.serialno " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop gaid " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell content insert --uri content://settings/secure --bind name:s:android_id --bind value:s:" + SP + "");
                    standardInput.Flush();
                    standardInput.Close();
                    process.WaitForExit();
                }
            }

        }

        private void siticoneWinToggleSwith7_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith7.Checked)
            {
                siticoneLabel5.Text = "Operation Blocked By Admin";
                siticoneWinToggleSwith7.Checked = false;
            }

        }

        private void siticoneLabel4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneWinToggleSwith5_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith5.Checked)
            {
                siticoneLabel5.Text = "Operation Blocked By Admin";
                siticoneWinToggleSwith5.Checked = false;
            }
        }

        private void siticoneWinToggleSwith6_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith6.Checked)
            {
                siticoneLabel5.Text = "Operation Blocked By Admin";
                siticoneWinToggleSwith6.Checked = false;
            }

        }
        private void Chnager_WithKey()
        {
            string path = "C:\\DEXSTER.txt";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                ST = "DEXSTERANTIBAN";
                SP = text.ToString();
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
                standardInput.WriteLine("adb -s emulator-5554 shell settings get secure android_id");
                standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id  " + SP + ST + " ");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            Task.Run(() => NewResources1());
            for (i = 0; i <= 50; i++)
            {
                siticoneProgressBar1.Value = i;
            }
            siticoneLabel12.ForeColor = Color.Gray;
            siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            Task.Run(() => Game());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
            }
            siticoneLabel12.ForeColor = Color.Gray;
            siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            siticoneLabel5.Text = "Success";
        }
        private void NewResources1()
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

        private void siticonePanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SpawnPortsBlocked()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=UDP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=UDP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=UDP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=UDP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }


        private void SpawnPortsUnBlocked()
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
                standardInput.WriteLine("netsh advfirewall firewall delete rule name = ILANDBLOCK");
                standardInput.WriteLine("netsh advfirewall firewall delete rule name = ILANDBLOCK");
                standardInput.WriteLine("netsh advfirewall firewall delete rule name = ILANDBLOCK");
                standardInput.WriteLine("netsh advfirewall firewall delete rule name = ILANDBLOCK");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private async void IN()
        {
            Task.Run(() => SpawnPortsBlocked());
            for (i = 0; i <= 100; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = "100%";
                siticoneProgressBar1.Value = i;
            }

        }
        private async void OUT()
        {
            Task.Run(() => SpawnPortsUnBlocked());
            for (i = 0; i <= 100; i++)
            {
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = "100%";
                siticoneProgressBar1.Value = i;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryDelete();
            InputRegistryHigh();
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
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
                standardInput.WriteLine("netsh advfirewall firewall delete rule name=NORMAL");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }


        private void siticonePanel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void siticoneWinToggleSwith10_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneWinToggleSwith10.Checked)
            {
                SpawnPortsBlocked();
            }
            else
            {
                SpawnPortsUnBlocked();
            }
        }

        private void siticoneLabel19_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel13_Click(object sender, EventArgs e)
        {

        }
        public bool serviceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (serviceExists("ALG"))
            {
                MessageBox.Show("Existed");
            }
            else
            {
                MessageBox.Show("Not Existed");
            }

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                standardInput.WriteLine("netsh winsock reset");
                standardInput.WriteLine("netsh int ip reset");
                standardInput.WriteLine("netsh firewall reset");
                standardInput.WriteLine("ipconfig /release");
                standardInput.WriteLine("ipconfig /renew");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =in remoteip = 123.151.71.34 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =in remoteip = 123.151.71.34 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =out remoteip = 123.151.71.34 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =out remoteip = 123.151.71.34 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =in remoteip = 203.205.239.243 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =in remoteip = 203.205.239.243 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =out remoteip = 203.205.239.243 action = block enable = yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name = DEXSTERLOOP protocol = ANY dir =out remoteip = 203.205.239.243 action = block enable = yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            TCP_IN();
            UDP_IN();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }
        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("aow_exe");
            if (localByName.Length > 0)
            {
                if (siticoneWinToggleSwith4.Checked)
                {
                    Task.Delay(20000);
                    RunNM();
                    timer1.Enabled = false;
                    timer1.Stop();
                }
                else
                {
                    siticoneLabel5.Text = "Running.";
                    Task.Delay(20000);
                    Run_Pubg();
                    timer1.Enabled = false;
                    timer1.Stop();
                    siticoneLabel5.Text = "Auto Game Done";
                }
            }
            else
            {
                siticoneLabel5.Text = "Game Not Found";
            }
        }
    }

}
