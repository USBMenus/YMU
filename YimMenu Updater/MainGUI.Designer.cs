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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1118, 628);
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
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button CloseBtn;
        private Button minBtn;
    }
}