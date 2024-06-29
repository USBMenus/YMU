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
using System.IO;
using System.Net.Http;
using System.Net;

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

        private void downloadYimMenu_Click(object sender, EventArgs e)
        {
            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string dllUrl = "https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll";
            string dllPath = Path.Combine(downloadsFolder, "YimMenu.dll");

            DownloadFile(dllUrl, dllPath, "YimMenu.dll downloaded to ");
        }

        private void uninstallYimMenu_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu");

            DeleteDirectory(yimMenuFolder, "YimMenu has been uninstalled.");
        }

        private void deleteCache_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cacheFolder = Path.Combine(appDataFolder, "YimMenu", "cache");

            DeleteDirectory(cacheFolder, "YimMenu's Cache has been deleted.");
        }

        private void howToGuide_Click(object sender, EventArgs e)
        {
            ShowHowToGuide();
        }

        private void DownloadFile(string url, string path, string successMessage)
        {
            try
            {
                new WebClient().DownloadFile(url, path);
                MessageBox.Show(successMessage + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteDirectory(string path, string successMessage)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    MessageBox.Show(successMessage);
                }
                else
                {
                    MessageBox.Show("Directory not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowHowToGuide()
        {
            string guide = "How to Download/Install YimMenu:\n\n" +
                           "1. To download YimMenu, click the 'Download YimMenu' button.\n" +
                           "2. Load into GTA5\n" +
                           "3. Go to the Tools tab, type GTA5 into the input box.\n" +
                           "4. Click Inject DLL and navigate to your Downloads folder, then select YimMenu.dll\n" +
                           "5. The program should automatically inject YimMenu into GTA\n\n" +
                           "Use the INSERT key to Open/Close the menu, IF you do not have an insert key and you are\n" +
                           "a first time YimMenu user, click VK_INSERT on the first popup screen and change it to J\n" +
                           "This will set the menu keybind to J for Opening/Closing the menu.";
            MessageBox.Show(guide, "How to Guide");
        }

        // Lua Scripts Tab Buttons

        private void downloadExtras_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu", "scripts");

            // Download each file using the DownloadFile method
            DownloadFile("https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/Extras-Addon.lua",
                         Path.Combine(yimMenuFolder, "Extras-Addon.lua"),
                         "Extras-Addon.lua downloaded successfully to ");

            DownloadFile("https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/Extras-data.lua",
                         Path.Combine(yimMenuFolder, "Extras-data.lua"),
                         "Extras-data.lua downloaded successfully to ");

            DownloadFile("https://raw.githubusercontent.com/Deadlineem/Extras-Addon-for-YimMenu/main/json.lua",
                         Path.Combine(yimMenuFolder, "json.lua"),
                         "json.lua downloaded successfully to ");
        }

        private void downloadUltimateMenu_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu", "scripts");

            DownloadFile("https://raw.githubusercontent.com/L7NEG/Ultimate-Menu/main/YimMenu/Ultimate_Menu%20For%20YimMenu%20V2.1%201.68.lua",
                         Path.Combine(yimMenuFolder, "UltimateMenu-v2.1.lua"),
                         "Ultimate Menu downloaded successfully to ");
        }

        private void downloadAnimations_Click(object sender, EventArgs e)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string yimMenuFolder = Path.Combine(appDataFolder, "YimMenu");

            DownloadFile("https://raw.githubusercontent.com/L7NEG/Ultimate-Menu/main/YimMenu/Ultimate_Menu%20For%20YimMenu%20V2.1%201.68.lua",
                         Path.Combine(yimMenuFolder, "animDictsCompact.json"),
                         "Animations Dictionary downloaded successfully to ");
        }
    }
}
