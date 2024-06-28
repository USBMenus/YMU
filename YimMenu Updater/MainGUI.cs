using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace YimUpdater
{

    public partial class MainGUI : Form
    {
        public bool drag;
        public MainGUI()
        {
            InitializeComponent();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            var rm = new ResourceManager("Images", this.GetType().Assembly);
            CloseBtn.MouseLeave += CloseBtn_Leave;
            CloseBtn.MouseHover += CloseBtn_Hover;
            CloseBtn.Click += CloseBtn_Click;
            minBtn.MouseLeave += MinBtn_Leave;
            minBtn.MouseHover += MinBtn_Hover;
            minBtn.Click += MinBtn_Click;
            pictureBox1.MouseUp += TitleBarMouseUp;
            pictureBox1.MouseMove += TitleBarDrag;
            pictureBox1.MouseDown += TitleBarMouseDown;
        }

        private void CloseBtn_Click(object? sender, EventArgs e)
        {
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_a;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (object? sender, EventArgs e) =>
            {
                CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_h;
                Environment.Exit(0);
            };
            timer.Start();
        }

        private void CloseBtn_Hover(object? sender, EventArgs e)
        {
            //CloseBtn.BackgroundImage = ResourceReader
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn_h;
        }

        private void CloseBtn_Leave(object? sender, EventArgs e)
        {
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn;
        }
        private void MinBtn_Click(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_a;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (object? sender, EventArgs e) =>
            {
                minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_h;
                this.WindowState = FormWindowState.Minimized;
                timer.Stop();
            };
            timer.Start();
        }

        private void MinBtn_Hover(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn_h;
        }

        private void MinBtn_Leave(object? sender, EventArgs e)
        {
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn;
        }

        public static int calcposy;
        public static int calcposx;
        private void TitleBarMouseDown(object? sender, MouseEventArgs e)
        {
            drag = true;
            var mousestartposx = Cursor.Position.X;
            var mousestartposy = Cursor.Position.Y;
            var windowstartposx = this.Location.X;
            var windowstartposy = this.Location.Y;
            calcposx = mousestartposx - windowstartposx;
            calcposy = mousestartposy - windowstartposy;
        }

        private void TitleBarDrag(object? sender, MouseEventArgs e)
        {
            if (drag == true)
            {
                var newmouseposx = Cursor.Position.X;
                var newmouseposy = Cursor.Position.Y;
                var newposx = newmouseposx - calcposx;
                var newposy = newmouseposy - calcposy;
                Point location = new Point(newposx, newposy);
                this.Location = location;
            }
        }

        private void TitleBarMouseUp(object? sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
