using DEXSTER.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;



namespace DEXSTER
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            File.Delete("Siticone.UI.dll");
            File.Delete("Bunifu_UI_v1.52.dll");
            File.WriteAllBytes("Siticone.UI.dll", Resources.Siticone_UI);
            File.WriteAllBytes("Bunifu_UI_v1.52.dll", Resources.Bunifu_UI_v1_52);
            File.SetAttributes("Siticone.UI.dll", FileAttributes.Hidden);
            File.SetAttributes("Bunifu_UI_v1.52.dll", FileAttributes.Hidden);
            if (File.Exists("DEXSTER_Services.dll"))
            {
                Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
                if (localByName.Length > 0)
                {
                    System.Diagnostics.Process.Start("ipconfig", "/renew");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login());
                }
                else
                {
                    System.Diagnostics.Process.Start("ipconfig", "/renew");
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
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login());
                }

            }
            else
            {
                MessageBox.Show("Load Driver Failed");
                Application.Exit();
            }
        }
    }
}
