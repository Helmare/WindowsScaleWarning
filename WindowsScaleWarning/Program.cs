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
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Check if process is already running.
            if (Process.GetProcessesByName("wsw").Length > 1)
            {
                Log.Fatal("Instance of this application already running.");
                return;
            }

            ProcessWatch[] watches = LoadWatches();
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
                            Log.Info($"{watch.Name} closed.");
                        }
                        watch.Opened = false;
                    }
                    else
                    {
                        if (watch.AutoKill) process.Kill();
                        if (!watch.Opened)
                        {
                            Log.Info($"{watch.Name} opened.");
                            WarningBox.Show(process, watch);
                        }
                        watch.Opened = true;
                    }
                }
            }
        }

        /// <summary>
        ///     Loads watches from the watch.json file.
        /// </summary>
        /// <returns></returns>
        private static ProcessWatch[] LoadWatches()
        {
            if (!File.Exists("watch.json"))
            {
                Log.Warning("watch.json file does not exist.");
                return Array.Empty<ProcessWatch>();
            }

            string json = File.ReadAllText("watch.json");
            ProcessWatch[]? watches = null;
            try
            {
                watches = JsonConvert.DeserializeObject<ProcessWatch[]>(json);
            }
            catch (JsonSerializationException ex)
            {
                Log.Error($"watch.json -> {ex.Message}");
            }

            if (watches == null)
            {
                Log.Warning("Could not load watch.json file.");
                return Array.Empty<ProcessWatch>();
            }
            else
            {
                Log.Info("Succsessfully loaded watch.json.");
                Log.Info($"{watches.Length} watches found.");
                foreach (ProcessWatch watch in watches)
                {
                    Log.Info($"\t{watch.Name}: {watch.ProcessName}");
                }
                return watches;
            }
        }
    }
}