using System;
using System.Collections.Generic;
namespace WSW
{
    /// <summary>
    ///     A basic logging class similar to Debug or Console.
    /// </summary>
    public static class Log
    {
        private static StreamWriter stream = CreateStream();

        /// <summary>
        ///     Moves the current log file to the log folder
        ///     and starts a new file.
        /// </summary>
        public static void Rotate()
        {
            if (!File.Exists("log.txt")) return;
            if (!Directory.Exists("logs"))
            {
                Directory.CreateDirectory("logs");
            }

            stream.Close();
            File.Move("log.txt", $"logs\\log-{DateTime.Now:MM-dd-yyyy_hh-mm-ss}");
            stream = CreateStream();
        }
        private static StreamWriter CreateStream()
        {
            return new StreamWriter("log.txt", true);
        }

        /// <summary>
        ///     Writes to the log with the current date and time prefixed
        ///     to the string.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLine(string str)
        {
            stream.WriteLine($"[{DateTime.Now:MM/dd/yyyy HH:mm:ss:fff}] {str}");
            stream.Flush();
        }
        /// <summary>
        ///     Writes to the log with the current date, time, and level prefixed
        ///     to the string.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLine(string level, string str)
        {
            WriteLine($"[{level}] {str}");
        }

        /// <summary>
        ///     Writes a debugging message to the log.
        /// </summary>
        /// <param name="str"></param>
        public static void Debug(string str)
        {
            WriteLine("DEBUG", str);
        }
        /// <summary>
        ///     Writes information to the log.
        /// </summary>
        /// <param name="str"></param>
        public static void Info(string str)
        {
            WriteLine("INFO", str);
        }
        /// <summary>
        ///     Writes a warning to the log.
        /// </summary>
        /// <param name="str"></param>
        public static void Warning(string str)
        {
            WriteLine("WARN", str);
        }
        /// <summary>
        ///     Writes an error to the log.
        /// </summary>
        /// <param name="str"></param>
        public static void Error(string str)
        {
            WriteLine("ERROR", str);
        }
        /// <summary>
        ///     Writes a fatal error to the log.
        /// </summary>
        /// <param name="str"></param>
        public static void Fatal(string str)
        {
            WriteLine("FATAL", str);
        }
    }
}
