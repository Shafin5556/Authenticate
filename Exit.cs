using DEXSTER.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEXSTER
{
    public partial class Exit : UserControl
    {
        int i;
        private static Exit _instance;
        private string SP;

        public static Exit Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Exit();
                return _instance;

            }

        }

        public string BP { get; private set; }

        public Exit()
        {
            InitializeComponent();
        }

        private void Exit_Load(object sender, EventArgs e)
        {
            siticoneLabel12.Visible = false;
            pictureBox1.Visible = false;
        }

        private void siticoneRoundedButton3_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                SafeExit();
            }
            else
            {
                Auto();

            }
        }

        private void siticoneLabel12_Click(object sender, EventArgs e)
        {

        }
        private async void Auto()
        {
            siticoneLabel12.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            siticoneLabel5.Text = "Please Wait Untill Finished!";
            Task.Run(() => release());
            for (i = 0; i <= 05; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => EMU_KILL());
            for (i = 0; i <= 10; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => NET_STOP());
            for (i = 0; i <= 10; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => FOLDER_DEL());
            for (i = 0; i <= 10; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => FakeRegistry());
            for (i = 0; i <= 40; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => DeleteRegistry());
            for (i = 0; i <= 50; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => DeleteResources());
            for (i = 0; i <= 60; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleteDerectory());
            for (i = 0; i <= 70; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => renew());
            for (i = 0; i <= 90; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => Terminate());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
        }
        private async void SafeExit()
        {
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            siticoneLabel5.Text = "Please Wait Untill Finished!";
            siticoneProgressBar1.Minimum = 0;
            siticoneProgressBar1.Maximum = 100;
            Task.Run(() => release());
            for (i = 0; i <= 05; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => NewResources());
            for (i = 0; i <= 20; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => Random_Device());
            for (i = 0; i <= 30; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => SafeShellV_1());
            for (i = 0; i <= 40; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => FakeRegistry());
            for (i = 0; i <= 60; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => DeleteRegistry());
            for (i = 0; i <= 70; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            Task.Run(() => DeleteResources());
            for (i = 0; i <= 80; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => DeleteDerectory());
            for (i = 0; i <= 90; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => renew());
            for (i = 0; i <= 95; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            await Task.Run(() => Terminate());
            for (i = 0; i <= 100; i++)
            {
                siticoneProgressBar1.Value = i;
                siticoneLabel12.ForeColor = Color.Gray;
                siticoneLabel12.Text = siticoneProgressBar1.Value.ToString() ;
            }
            siticoneLabel5.Text = "Success";
        }
        private void release()
        {
            System.Diagnostics.Process.Start("ipconfig", "/release");
        }
        private void renew()
        {
            System.Diagnostics.Process.Start("ipconfig", "/renew");
        }
        private void DISABLE()
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
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 1 admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 2 admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 3 admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 4 admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=GP-Internet admin=DISABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void ENABLE()
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
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 1 admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=Ethernet 2 admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=GP-Internet admin=ENABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
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
        private void Random_Device()
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
        private void Terminate()
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
            Application.Exit();
        }
        private void NewResources()
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
        private void SafeShell()
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
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/user/0/com.tencent.ig/files");
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
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/ImageDownload");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/LightData");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/MMKV");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Pandora");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs0");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs1");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferTmpDir");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/rawdata");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Roleinfo");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Screenshots");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/TableDatas");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/UpdateInfo");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/WeaponDIY");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/user/0/com.tencent.ig/files");
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
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Activity");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Arena");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Career");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Chat");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Commercial");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Crate");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Download");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Friend");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GatheringParadise");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GEM");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GM");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Loading");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/LobbyBubble");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Login");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/LoginBackUp");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Match");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Moment");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MusicBox");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Notice");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/pandora");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/PersonSpace");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Pet");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Plot");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/PufferDownload");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Reddot");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/RoleInfo");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Season");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Setting");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/SocialIsland");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Store");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Tables");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Team");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/UnknowPass");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Wardrobe");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
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
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/ImageDownload");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/LightData");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/MMKV");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Pandora");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs0");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs1");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferTmpDir");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/rawdata");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Roleinfo");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Screenshots");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/TableDatas");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/UpdateInfo");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/WeaponDIY");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 755 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 755 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 755 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 755 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 755 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 755 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 755 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 755 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 755 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 755 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb kill-server");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void SafeShellV_1()
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
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/user/0/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
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
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb kill-server");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            EMU_KILL();
            NET_STOP();
            FOLDER_DEL();
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void FOLDER_DEL()
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
                standardInput.WriteLine("del C:\\aow_drv.log");
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
        private void NET_STOP()
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
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
        private void DeleteResources()
        {
            if (File.Exists(@"adb.exe"))
            {

                    File.Delete("adb.exe");
            }
            else
            {
                File.Delete("adb.exe");
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

                    File.Delete("AdbWinApi.dll");
            }
            else
            {
                File.Delete("AdbWinApi.dll");
            }
        }
        private void DeleteDerectory()
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
                Directory.Delete(root11, true);
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
            string root30 = @"C:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root30))
            {
                Directory.Delete(root30, true);
            }
            string root31 = @"D:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root31))
            {
                Directory.Delete(root31, true);
            }
            string root32 = @"E:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root32))
            {
                Directory.Delete(root32, true);
            }
            string root33 = @"F:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root33))
            {
                Directory.Delete(root33, true);
            }
            string root34 = @"G:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root34))
            {
                Directory.Delete(root34, true);
            }
            string root35 = @"H:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root35))
            {
                Directory.Delete(root35, true);
            }
            string root36 = @"I:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root36))
            {
                Directory.Delete(root36, true);
            }
            string root110 = @"D:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root110))
            {
                Directory.Delete(root110, true);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Terminate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            renew();
        }
    }
}
