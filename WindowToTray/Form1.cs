using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace WindowToTray
{
    public partial class Form1 : Form
    {
        // WinAPI импорт
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private readonly List<WindowInfo> windows = new List<WindowInfo>();
        private readonly Dictionary<IntPtr, NotifyIcon> minimizedWindows = new Dictionary<IntPtr, NotifyIcon>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            RefreshWindowList();
        }

        private void RefreshWindowList()
        {
            windows.Clear();
            listBoxWindows.Items.Clear();

            EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (hWnd != IntPtr.Zero)
                {
                    var sb = new StringBuilder(256);
                    GetWindowText(hWnd, sb, sb.Capacity);
                    string title = sb.ToString();

                    if (!string.IsNullOrEmpty(title) && IsWindowVisible(hWnd))
                    {
                        windows.Add(new WindowInfo(hWnd, title));
                        listBoxWindows.Items.Add(title);
                    }
                }
                return true;
            }, IntPtr.Zero);
        }

        // Обработчик для кнопки обновления (должен совпадать с Designer.cs)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshWindowList();
        }

        // Обработчик для кнопки сворачивания окна (должен совпадать с Designer.cs)
        private void btnMinimizeSelected_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedIndex >= 0)
            {
                WindowInfo selectedWindow = windows[listBoxWindows.SelectedIndex];
                ShowWindow(selectedWindow.Handle, SW_HIDE);

                var windowIcon = new NotifyIcon(components)
                {
                    Icon = SystemIcons.Application,
                    Text = selectedWindow.Title,
                    Visible = true
                };

                windowIcon.DoubleClick += (s, args) =>
                {
                    ShowWindow(selectedWindow.Handle, SW_SHOW);
                    windowIcon.Dispose();
                    minimizedWindows.Remove(selectedWindow.Handle);
                };

                minimizedWindows.Add(selectedWindow.Handle, windowIcon);
            }
            else
            {
                MessageBox.Show("Выберите окно из списка!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик для кнопки сворачивания приложения (должен совпадать с Designer.cs)
        private void btnMinimizeApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            trayIcon.Visible = true;
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var icon in minimizedWindows.Values)
            {
                icon.Dispose();
            }
            base.OnFormClosing(e);
        }
    }

    public class WindowInfo
    {
        public IntPtr Handle { get; }
        public string Title { get; }

        public WindowInfo(IntPtr handle, string title)
        {
            Handle = handle;
            Title = title;
        }
    }
}