using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();


            GetCursorPosition2();



        }

        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator System.Windows.Point(POINT point)
            {
                return new System.Windows.Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static POINT GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }


        public void GetCursorPosition2()
        {
            Task.Run(() => {

                while (true)
                {
                    Thread.Sleep(1000);
                    IntPtr c = System.Windows.Forms.Cursor.Current.Handle;
                    this.Dispatcher.Invoke(() => {
                        tb_screen.Text = string.Format("X:{0}, Y:{1}, handle:{2}", 
                            System.Windows.Forms.Cursor.Position.X, 
                            System.Windows.Forms.Cursor.Position.Y,
                            c.ToString());
                    });
                    Thread.Sleep(1000);
                }
            });
            
        }

        private void CalculateDPI()
        {
            double dWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double dHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            float dpiX = 0.0f;
            float dpiY = 0.0f;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }

            int PixelsPerXLogicalInch = 0; // dpi for x
            int PixelsPerYLogicalInch = 0; // dpi for y

            using (ManagementClass mc = new ManagementClass("Win32_DesktopMonitor"))
            {
                using (ManagementObjectCollection moc = mc.GetInstances())
                {

                    foreach (ManagementObject each in moc)
                    {
                        PixelsPerXLogicalInch = int.Parse((each.Properties["PixelsPerXLogicalInch"].Value.ToString()));
                        PixelsPerYLogicalInch = int.Parse((each.Properties["PixelsPerYLogicalInch"].Value.ToString()));
                    }

                }
            }

            StringBuilder tsb = new StringBuilder();
            tsb.AppendLine(string.Format("Screen: with:{0}, Height:{1}", dWidth, dHeight));
            tsb.AppendLine(string.Format("graphics DPI: X:{0}, Y:{1}", dpiX, dpiY));
            tsb.AppendLine(string.Format("Management DPI: X:{0}, Y:{1}", PixelsPerXLogicalInch, PixelsPerYLogicalInch));
            tb_screen.Text = tsb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var p = Process.Start(@"C:\Users\v-yulmao\AppData\Local\youdao\dict\Application\YoudaoDict.exe");

            ProcessStartInfo processinfo = new ProcessStartInfo();

            var p = Process.Start(@"C:\Users\v-yulmao\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\有道\网易有道词典\启动网易有道词典");

            while (p.MainWindowHandle == IntPtr.Zero)
            {
                try
                {
                    p.WaitForInputIdle(1000);
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                p.Refresh();
            }

            SendKeys.Send()
        }
    }
}
