namespace YimUpdater
{
    partial class MainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            pictureBox1 = new PictureBox();
            CloseBtn = new Button();
            minBtn = new Button();
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            YimMenu_Tab = new TabPage();
            button1 = new Button();
            LuaScripts_Tab = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2TabControl1.SuspendLayout();
            YimMenu_Tab.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(393, 44);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = Color.Transparent;
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn;
            CloseBtn.BackgroundImageLayout = ImageLayout.Center;
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CloseBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CloseBtn.FlatStyle = FlatStyle.Flat;
            CloseBtn.ForeColor = SystemColors.Desktop;
            CloseBtn.Location = new Point(1002, 4);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(105, 35);
            CloseBtn.TabIndex = 2;
            CloseBtn.UseVisualStyleBackColor = false;
            // 
            // minBtn
            // 
            minBtn.BackColor = Color.Transparent;
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn;
            minBtn.BackgroundImageLayout = ImageLayout.Center;
            minBtn.FlatAppearance.BorderSize = 0;
            minBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            minBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            minBtn.FlatStyle = FlatStyle.Flat;
            minBtn.Location = new Point(891, 4);
            minBtn.Name = "minBtn";
            minBtn.Size = new Size(105, 35);
            minBtn.TabIndex = 3;
            minBtn.UseVisualStyleBackColor = false;
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Controls.Add(YimMenu_Tab);
            guna2TabControl1.Controls.Add(LuaScripts_Tab);
            guna2TabControl1.ItemSize = new Size(180, 40);
            guna2TabControl1.Location = new Point(12, 50);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1095, 566);
            guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(200, 50, 50);
            guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(200, 50, 50);
            guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(155, 0, 0);
            guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(155, 0, 0);
            guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(100, 0, 0);
            guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(255, 128, 0);
            guna2TabControl1.TabButtonSize = new Size(180, 40);
            guna2TabControl1.TabIndex = 4;
            guna2TabControl1.TabMenuBackColor = Color.Transparent;
            guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // YimMenu_Tab
            // 
            YimMenu_Tab.Controls.Add(button1);
            YimMenu_Tab.ForeColor = SystemColors.Desktop;
            YimMenu_Tab.Location = new Point(4, 44);
            YimMenu_Tab.Name = "YimMenu_Tab";
            YimMenu_Tab.Padding = new Padding(3);
            YimMenu_Tab.Size = new Size(1087, 518);
            YimMenu_Tab.TabIndex = 0;
            YimMenu_Tab.Text = "YimMenu";
            YimMenu_Tab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "test";
            button1.UseVisualStyleBackColor = true;
            // 
            // LuaScripts_Tab
            // 
            LuaScripts_Tab.Location = new Point(4, 44);
            LuaScripts_Tab.Name = "LuaScripts_Tab";
            LuaScripts_Tab.Size = new Size(1087, 518);
            LuaScripts_Tab.TabIndex = 1;
            LuaScripts_Tab.Text = "Lua Script (Addons)";
            LuaScripts_Tab.UseVisualStyleBackColor = true;
            // 
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = YimMenu_Updater.Properties.Resources.titlebar_buttons;
            ClientSize = new Size(1118, 628);
            Controls.Add(guna2TabControl1);
            Controls.Add(minBtn);
            Controls.Add(CloseBtn);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(1118, 628);
            MinimizeBox = false;
            MinimumSize = new Size(1118, 628);
            Name = "MainGUI";
            ShowIcon = false;
            Text = "MainGUI";
            Load += MainGUI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2TabControl1.ResumeLayout(false);
            YimMenu_Tab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button CloseBtn;
        private Button minBtn;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage YimMenu_Tab;
        private Button button1;
        private TabPage LuaScripts_Tab;
    }
}