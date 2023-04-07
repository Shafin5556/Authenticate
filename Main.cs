using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DEXSTER
{
    public partial class Main : Form
    {
        private static Main _instance;
        public static Main Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Main();
                return _instance;

            }

        }
        public Main()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("adb");
            if (localByName.Length > 0)
            {
                MessageBox.Show("Anti Process Still Runnnig Dont Close!!!");
            }
            else
            {

            }
        }
        private async void Exitkill()
        {
           Task.Run(() => kill());
           Task.Run(() => FakeRegistry());
           Task.Run(() => DeleteRegistry());
            await Task.Run(() => Forcestop());
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Forcestop()
        {
            Environment.Exit(0);
        }
        private void FakeRegistry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Tencent");
            key.SetValue("1", "1");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
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
        private void Main_Load(object sender, EventArgs e)
        {
            FIREWALLON();
            CPU();
            CHECKER_RUN();

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
        private void DLL_elapsed(object sender, ElapsedEventArgs e)
        {
            if (File.Exists("DEXSTER_Services.dll"))
            {

            }
            else
            {
                MessageBox.Show("Load Driver Failed");
            }
        }
        private void CHECKER()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Elapsed += CHECKER_elapsed;
            timer.Start();
        }
        private void CHECKER_elapsed(object sender, ElapsedEventArgs e)
        {
            using (RegistryKey key3 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\PublicProfile"))
            {
                if (key3 == null)
                {
                    FIREWALLON();
                }
                else
                {
                    Object o = key3.GetValue("EnableFirewall");
                    if (o == null)
                    {
                        FIREWALLON();
                    }
                    else
                    {
                        int firewall = (int)o;
                        if (firewall == 1)
                        {

                        }
                        else
                        {
                            FIREWALLON();
                        }
                    }
                }
            }
        }
        private async void CPU()
        {
            Task.Run(() => USAGE());
        }
        private async void CHECKER_RUN()
        {
            Task.Run(() => CHECKER());
        }
        private async void Detected()
        {
            Task.Run(() => Taskkill());
            Task.Run(() => RESETNETSH());
            Task.Run(() => FIREWALLON());
            await Task.Run(() => Forcestop());
        }
        private void USAGE()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\AndroidEmulator.exe");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\AndroidEmulator.exe\\PerfOptions");
            key.SetValue("CpuPriorityClass", 3, RegistryValueKind.DWord);
            key.Close();
        }
        private void DNS_DEFAULT()
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
                standardInput.WriteLine("netsh interface ipv4 set dns Wi-Fi dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns Wi-Fi dhcp");
                standardInput.WriteLine("netsh interface ipv4 set dns GP-Internet dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns GP-Internet dhcp");
                standardInput.WriteLine("netsh interface ipv4 set dns Ethernet dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns Ethernet dhcp");
                standardInput.WriteLine("netsh interface ipv4 set dns Ethernet 2 dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns Ethernet 2 dhcp");
                standardInput.WriteLine("netsh interface ipv4 set dns Ethernet 3 dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns Ethernet 3 dhcp");
                standardInput.WriteLine("netsh interface ipv4 set dns Ethernet 4 dhcp");
                standardInput.WriteLine("netsh interface ipv6 set dns Ethernet 4 dhcp");
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
                standardInput.WriteLine("netsh winsock reset");
                standardInput.WriteLine("netsh int ip reset");
                standardInput.WriteLine("netsh firewall reset");
                standardInput.WriteLine("ipconfig /release");
                standardInput.WriteLine("ipconfig /renew");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (!siticonePictureBox3.Controls.Contains(Start.Instance))
            {
                siticonePictureBox3.Controls.Add(Start.Instance);
                Start.Instance.Dock = DockStyle.Fill;
                Start.Instance.BringToFront();
            }
            else
                Start.Instance.BringToFront();
        }

        private void siticonePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            if (!siticonePictureBox3.Controls.Contains(Exit.Instance))
            {
                siticonePictureBox3.Controls.Add(Exit.Instance);
                Exit.Instance.Dock = DockStyle.Fill;
                Exit.Instance.BringToFront();
            }
            else
                Exit.Instance.BringToFront();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (!siticonePictureBox3.Controls.Contains(Tools.Instance))
            {
                siticonePictureBox3.Controls.Add(Tools.Instance);
                Tools.Instance.Dock = DockStyle.Fill;
                Tools.Instance.BringToFront();
            }
            else
                Tools.Instance.BringToFront();
        }

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void siticonePictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/DEXSTER555");
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                MessageBox.Show("Emu Still Runnnig Dont Close!!!");
            }
            else
            {
                Exitkill();
            }
        }

        private void siticoneRoundedButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void siticoneButton2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void siticoneButton3_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void moveImageBox(object sender)
        {

        }

        private void imgSlide_Click(object sender, EventArgs e)
        {

        }
    }
}
