using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly List<WindowInfo> windows = new List<WindowInfo>();
        private readonly Dictionary<IntPtr, NotifyIcon> minimizedWindows = new Dictionary<IntPtr, NotifyIcon>();

        private Button? btnClose = null;
        private Button? btnMaximize = null;
        private Button? btnMinimize = null;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomTitleBar();
            ApplyDiscordStyle();
        }

        private void InitializeCustomTitleBar()
        {
            // Кнопка закрытия
            btnClose = new Button
            {
                Text = "?",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(46, 32),
                Location = new Point(ClientSize.Width - 46, 0),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);
            btnClose.Click += (s, e) => Close();
            Controls.Add(btnClose);

            // Кнопка развернуть/свернуть
            btnMaximize = new Button
            {
                Text = "?",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(46, 32),
                Location = new Point(ClientSize.Width - 92, 0),
                Cursor = Cursors.Hand
            };
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 70, 77);
            btnMaximize.Click += (s, e) => WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            Controls.Add(btnMaximize);

            // Кнопка свернуть
            btnMinimize = new Button
            {
                Text = "_",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(46, 32),
                Location = new Point(ClientSize.Width - 138, 0),
                Cursor = Cursors.Hand
            };
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 70, 77);
            btnMinimize.Click += (s, e) => WindowState = FormWindowState.Minimized;
            Controls.Add(btnMinimize);

            // Панель заголовка для перемещения
            var titleBar = new Panel
            {
                BackColor = Color.FromArgb(47, 49, 54),
                Height = 32,
                Dock = DockStyle.Top,
                Cursor = Cursors.SizeAll
            };
            titleBar.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
            Controls.Add(titleBar);
            titleBar.BringToFront();

            // Перемещаем кнопки на передний план
            btnClose.BringToFront();
            btnMaximize.BringToFront();
            btnMinimize.BringToFront();
        }

        private void ApplyDiscordStyle()
        {
            // Настройки формы
            this.BackColor = Color.FromArgb(64, 68, 75);
            this.ForeColor = Color.White;

            // Закругление формы
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            // Стиль ListBox
            listBoxWindows.BackColor = Color.FromArgb(54, 57, 63);
            listBoxWindows.ForeColor = Color.White;
            listBoxWindows.BorderStyle = BorderStyle.None;
            listBoxWindows.Font = new Font("Segoe UI", 10);
            listBoxWindows.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
                listBoxWindows.Width, listBoxWindows.Height, 10, 10));

            // Стиль кнопок (кроме кнопок заголовка)
            foreach (Button btn in Controls.OfType<Button>().Where(b => b != btnClose && b != btnMaximize && b != btnMinimize))
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(88, 101, 242);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 8, 8));

                // Эффекты при наведении
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(71, 82, 196);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 70, 180);
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshWindowList();
        }

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