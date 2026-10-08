using System.Runtime.InteropServices;
using System.Windows;

namespace StudentRegistrationApp
{
    public partial class App : Application
    {
        // ==================== P/Invoke untuk DPI Awareness ====================
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetProcessDPIAware();

        [DllImport("shcore.dll", SetLastError = true)]
        private static extern int SetProcessDpiAwareness(int value);

        protected override void OnStartup(StartupEventArgs e)
        {
            // ---- Set DPI awareness SEBELUM window dibuat ----
            try
            {
                // 2 = PROCESS_PER_MONITOR_DPI_AWARE (Windows 8.1+)
                SetProcessDpiAwareness(2);
            }
            catch
            {
                // Fallback: System DPI Aware (Windows Vista+)
                try { SetProcessDPIAware(); } catch { }
            }

            // ---- Aktifkan rendering mode terbaik ----
            System.Windows.Media.RenderOptions.ProcessRenderMode =
                System.Windows.Interop.RenderMode.Default;

            base.OnStartup(e);

            // ---- Buat MainWindow secara manual ----
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}