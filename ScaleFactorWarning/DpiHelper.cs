using System.Runtime.InteropServices;

namespace ScaleFactorWarning
{
    /// <summary>
    ///     Contains methods for finding the DPI of monitors.
    /// </summary>
    public static class DpiHelper
    {
        /// <summary>
        ///     Gets the screen scaling applied by windows.
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public static double GetScale(this Screen screen)
        {
            GetDpiForScreen(screen, DpiType.Effective, out uint dpiX, out uint dpiY);
            return dpiX / 96.0;
        }
        private static IntPtr MonitorFromScreen(Screen screen)
        {
            Point center = new Point
            {
                X = screen.Bounds.Left + screen.Bounds.Width / 2,
                Y = screen.Bounds.Top + screen.Bounds.Height / 2
            };
            return MonitorFromPoint(center, 2);
        }
        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromPoint([In] Point point, [In] uint dwFlags);
        private static IntPtr GetDpiForScreen(Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        {
            IntPtr mon = MonitorFromScreen(screen);
            return GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
        }
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);
    }

    /// <summary>
    ///     DpiTypes for requesting Dpi from a monitor.
    /// </summary>
    public enum DpiType
    {
        Effective = 0,
        Angular = 1,
        Raw = 2
    }
}
