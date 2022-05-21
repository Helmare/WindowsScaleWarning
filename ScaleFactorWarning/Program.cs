using Newtonsoft.Json;
using System.Diagnostics;

namespace ScaleFactorWarning
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ProcessWatch[]? watches = JsonConvert.DeserializeObject<ProcessWatch[]>(File.ReadAllText("watch.json"));
            if (watches == null)
            {
                MessageBox.Show("Failed to start ScaleFactorWarning");
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
                            string? message = watch.Message;
                            if (message == null)
                            {
                                message = $"WINDOWS SCALE WARNING\n\nYou just opened {watch.Name}, which is poorly affected by windows scaling.";
                            }

                            DialogResult result = MessageBox.Show(message + $"\n\nWould you like to close {watch.Name}?", "ScaleFactorWarning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                process.Kill();
                            }
                        }
                        watch.Opened = true;
                    }
                }
            }
        }
    }
}