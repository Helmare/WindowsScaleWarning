using Newtonsoft.Json;
using System.Diagnostics;

namespace WSW
{
    internal static class Program
    {
        private const string WatchConfigFile = "watch.json";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            Log.Info("New instance launched.");

            // Check if process is already running.
            if (Process.GetProcessesByName("wsw").Length > 1)
            {
                Log.Fatal("Previous instance already running.");
                return;
            }

            Run();
        }

        /// <summary>
        ///     Runs the main loop.
        /// </summary>
        private static void Run()
        {
            // Setup variables.
            ProcessWatch[] watches = LoadWatches();
            DateTime lastWrite = File.GetLastWriteTime(WatchConfigFile);
            double lastScale = 0;

            // Main Loop
            while (true)
            {
                Thread.Sleep(250);
                double scale = Screen.PrimaryScreen.GetScale();
                if (scale != lastScale)
                {
                    if (scale == 1)
                    {
                        Log.Info("Stopping watch, scale set to 100%");
                    }
                    else if (lastScale == 1 || lastScale == 0)
                    {
                        Log.Info($"Starting watch, scale set to {scale * 100:N0}%");
                    }
                    else
                    {
                        Log.Debug($"Windows scale changed to {scale * 100:N0}%");
                    }
                    lastScale = scale;
                }
                if (scale == 1) continue;

                // Check if watch.json was updated
                DateTime curWrite = File.GetLastWriteTime(WatchConfigFile);
                if (lastWrite != curWrite)
                {
                    Log.Info($"{WatchConfigFile} has been updated. Reloading...");
                    watches = LoadWatches();
                    lastWrite = curWrite;
                }

                // Check for process open status change.
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
                            Log.Info($"{watch.Name} opened, show warning.");
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
            if (!File.Exists(WatchConfigFile))
            {
                Log.Warning($"{WatchConfigFile} file does not exist.");
                return Array.Empty<ProcessWatch>();
            }

            string json = File.ReadAllText(WatchConfigFile);
            ProcessWatch[]? watches = null;
            try
            {
                watches = JsonConvert.DeserializeObject<ProcessWatch[]>(json);
            }
            catch (JsonSerializationException ex)
            {
                Log.Error($"{WatchConfigFile} -> {ex.Message}");
            }

            if (watches == null)
            {
                Log.Warning($"Could not load {WatchConfigFile} file.");
                return Array.Empty<ProcessWatch>();
            }
            else
            {
                Log.Info($"Succsessfully loaded {WatchConfigFile}.");
                Log.Info($"{watches.Length} watches found.");
                foreach (ProcessWatch watch in watches)
                {
                    Log.Info($"    {watch.Name}: {watch.ProcessName}");
                }
                return watches;
            }
        }
    }
}