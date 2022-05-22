using Newtonsoft.Json;
using System.Diagnostics;

namespace WSW
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            if (Process.GetProcessesByName("wsw").Length > 1)
            {
                MessageBox.Show("Instance of this application already running.", "Windows Scaling Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProcessWatch[]? watches = JsonConvert.DeserializeObject<ProcessWatch[]>(File.ReadAllText("watch.json"));
            if (watches == null)
            {
                MessageBox.Show("Failed to load \"watch.json\". There may be a syntax error", "Windows Scaling Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                Thread.Sleep(250);
                if (Screen.PrimaryScreen.GetScale() == 1) continue;

                // Reset watches
                foreach (ProcessWatch watch in watches)
                {
                    Process? process = Process.GetProcessesByName(watch.ProcessName).FirstOrDefault();
                    if (process == null)
                    {
                        if (watch.Opened)
                        {
                            Debug.WriteLine($"{watch.Name} closed.");
                        }
                        watch.Opened = false;
                    }
                    else
                    {
                        if (watch.AutoKill) process.Kill();
                        if (!watch.Opened)
                        {
                            Debug.WriteLine($"{watch.Name} opened.");
                            WarningBox.Show(process, watch);
                        }
                        watch.Opened = true;
                    }
                }
            }
        }
    }
}