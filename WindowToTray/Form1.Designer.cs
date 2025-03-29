namespace WindowToTray
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnMinimizeSelected;
        private NotifyIcon trayIcon;
        private ListBox listBoxWindows;
        private Button btnRefresh;
        private Button btnMinimizeApp;
        private Button btnClose;
        private Button btnMaximize;
        private Button btnMinimize;
        private Panel titleBar;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnMinimizeSelected = new Button();
            trayIcon = new NotifyIcon(components);
            listBoxWindows = new ListBox();
            btnRefresh = new Button();
            btnMinimizeApp = new Button();
            btnClose = new Button();
            btnMaximize = new Button();
            btnMinimize = new Button();
            titleBar = new Panel();
            lblTitle = new Label();
            titleBar.SuspendLayout();
            SuspendLayout();

            // btnMinimizeSelected
            btnMinimizeSelected.Location = new Point(325, 345);
            btnMinimizeSelected.Name = "btnMinimizeSelected";
            btnMinimizeSelected.Size = new Size(120, 31);
            btnMinimizeSelected.TabIndex = 1;
            btnMinimizeSelected.Text = "Свернуть окно";
            btnMinimizeSelected.UseVisualStyleBackColor = true;
            btnMinimizeSelected.Click += btnMinimizeSelected_Click;

            // trayIcon
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "WindowToTray";
            trayIcon.Visible = true;
            trayIcon.DoubleClick += trayIcon_DoubleClick;

            // listBoxWindows
            listBoxWindows.FormattingEnabled = true;
            listBoxWindows.ItemHeight = 15;
            listBoxWindows.Location = new Point(30, 50);
            listBoxWindows.Name = "listBoxWindows";
            listBoxWindows.Size = new Size(740, 289);
            listBoxWindows.TabIndex = 2;

            // btnRefresh
            btnRefresh.Location = new Point(30, 345);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 31);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // btnMinimizeApp
            btnMinimizeApp.Location = new Point(650, 345);
            btnMinimizeApp.Name = "btnMinimizeApp";
            btnMinimizeApp.Size = new Size(120, 31);
            btnMinimizeApp.TabIndex = 4;
            btnMinimizeApp.Text = "В трей";
            btnMinimizeApp.UseVisualStyleBackColor = true;
            btnMinimizeApp.Click += btnMinimizeApp_Click;

            // btnClose
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(754, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 32);
            btnClose.TabIndex = 5;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;

            // btnMaximize
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.Cursor = Cursors.Hand;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMaximize.ForeColor = Color.White;
            btnMaximize.Location = new Point(708, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(46, 32);
            btnMaximize.TabIndex = 6;
            btnMaximize.Text = "□";
            btnMaximize.UseVisualStyleBackColor = false;

            // btnMinimize
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(662, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 32);
            btnMinimize.TabIndex = 7;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = false;

            // titleBar
            titleBar.BackColor = Color.FromArgb(47, 49, 54);
            titleBar.Controls.Add(lblTitle);
            titleBar.Controls.Add(btnMinimize);
            titleBar.Controls.Add(btnMaximize);
            titleBar.Controls.Add(btnClose);
            titleBar.Cursor = Cursors.SizeAll;
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(800, 32);
            titleBar.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(10, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 19);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "WindowToTray";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(800, 450);
            Controls.Add(titleBar);
            Controls.Add(btnMinimizeApp);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxWindows);
            Controls.Add(btnMinimizeSelected);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "WindowToTray";
            Load += Form1_Load;
            Resize += Form1_Resize;
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}