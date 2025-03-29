namespace WindowToTray
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            SuspendLayout();
            // 
            // btnMinimizeSelected
            // 
            btnMinimizeSelected.BackColor = SystemColors.Control;
            btnMinimizeSelected.Location = new Point(325, 380);
            btnMinimizeSelected.Margin = new Padding(4, 3, 4, 3);
            btnMinimizeSelected.Name = "btnMinimizeSelected";
            btnMinimizeSelected.Size = new Size(120, 31);
            btnMinimizeSelected.TabIndex = 1;
            btnMinimizeSelected.Text = "Свернуть окно";
            btnMinimizeSelected.UseVisualStyleBackColor = false;
            btnMinimizeSelected.Click += btnMinimizeSelected_Click;
            // 
            // trayIcon
            // 
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "WindowToTray";
            trayIcon.Visible = true;
            trayIcon.DoubleClick += trayIcon_DoubleClick;
            // 
            // listBoxWindows
            // 
            listBoxWindows.FormattingEnabled = true;
            listBoxWindows.ItemHeight = 15;
            listBoxWindows.Location = new Point(234, 50);
            listBoxWindows.Margin = new Padding(4, 3, 4, 3);
            listBoxWindows.Name = "listBoxWindows";
            listBoxWindows.Size = new Size(308, 289);
            listBoxWindows.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Control;
            btnRefresh.Location = new Point(234, 345);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 31);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnMinimizeApp
            // 
            btnMinimizeApp.BackColor = SystemColors.Control;
            btnMinimizeApp.Location = new Point(424, 345);
            btnMinimizeApp.Margin = new Padding(4, 3, 4, 3);
            btnMinimizeApp.Name = "btnMinimizeApp";
            btnMinimizeApp.Size = new Size(120, 31);
            btnMinimizeApp.TabIndex = 4;
            btnMinimizeApp.Text = "В трей";
            btnMinimizeApp.UseVisualStyleBackColor = false;
            btnMinimizeApp.Click += btnMinimizeApp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMinimizeApp);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxWindows);
            Controls.Add(btnMinimizeSelected);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "WindowToTray";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnMinimizeSelected;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ListBox listBoxWindows;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMinimizeApp;
    }
}