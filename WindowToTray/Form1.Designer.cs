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
            btnMinimizeSelected.Location = new Point(423, 307);
            btnMinimizeSelected.Name = "btnMinimizeSelected";
            btnMinimizeSelected.Size = new Size(120, 32);
            btnMinimizeSelected.TabIndex = 1;
            btnMinimizeSelected.Text = "Свернуть окно";
            btnMinimizeSelected.UseVisualStyleBackColor = true;
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
            listBoxWindows.Location = new Point(233, 12);
            listBoxWindows.Name = "listBoxWindows";
            listBoxWindows.Size = new Size(310, 289);
            listBoxWindows.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(233, 307);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 32);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnMinimizeApp
            // 
            btnMinimizeApp.Location = new Point(296, 345);
            btnMinimizeApp.Name = "btnMinimizeApp";
            btnMinimizeApp.Size = new Size(183, 32);
            btnMinimizeApp.TabIndex = 4;
            btnMinimizeApp.Text = "Свернуть приложение";
            btnMinimizeApp.UseVisualStyleBackColor = true;
            btnMinimizeApp.Click += btnMinimizeApp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMinimizeApp);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxWindows);
            Controls.Add(btnMinimizeSelected);
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