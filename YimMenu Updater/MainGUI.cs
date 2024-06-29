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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Compression;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

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
            howToGuide.Click += howToGuide_Click;
            uninstallYimMenu.Click += uninstallYimMenu_Click;
            deleteCache.Click += deleteCache_Click;
            downloadYimMenu.Click += downloadYimMenu_Click;
            downloadUltimateMenu.Click += downloadUltimateMenu_Click;
            downloadExtras.Click += downloadExtras_Click;
            downloadAnimations.Click += downloadAnimations_Click;
            installXMLs.Click += installXMLs_Click;
            installYimASI.Click += installYimASI_Click;
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
            WebClient client = new WebClient();

            // Subscribe to the DownloadProgressChanged event to update the progress bar
            client.DownloadProgressChanged += (sender, e) =>
            {
                progressBar1.Visible = true;
                // Assuming progressBar1 is your ProgressBar control on the form
                progressBar1.Value = e.ProgressPercentage;
            };

            try
            {
                // Download the file asynchronously
                client.DownloadFileAsync(new Uri(url), path);

                // Display a message when the download completes
                client.DownloadFileCompleted += (sender, e) =>
                {
                    MessageBox.Show(successMessage + path);

                    progressBar1.Visible = false;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                progressBar1.Visible = false;
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

        private void DownloadAndExtractZip(string url, string zipFilePath, string fileName, string extractDirectory)
        {
            WebClient client = new WebClient();

            // Subscribe to the DownloadProgressChanged event to update the progress bar
            client.DownloadProgressChanged += (sender, e) =>
            {
                progressBar1.Visible = true;
                // Assuming progressBar1 is your ProgressBar control on the form
                progressBar1.Value = e.ProgressPercentage;
            };

            try
            {
                // Download the zip file asynchronously
                client.DownloadFileAsync(new Uri(url), zipFilePath);

                // Handle completion of download
                client.DownloadFileCompleted += (sender, e) =>
                {
                    progressBar1.Visible = false;

                    // Extract the zip file to the specified directory
                    try
                    {
                        ZipFile.ExtractToDirectory(zipFilePath, extractDirectory);
                        MessageBox.Show(fileName + " Download completed!\n\n Extracted " + fileName + " to " + extractDirectory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error extracting zip file: " + ex.Message);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message);
                progressBar1.Visible = false;
            }
        }

        private void installXMLs_Click(object sender, EventArgs e)
        {
            // For xml_maps.zip
            string urlMaps = "http://bedrock.root.sx/xml_maps.zip";
            string zipFileNameMaps = "xml_maps";
            string zipFileNameM = "XML Maps";
            string extractDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YimMenu");

            DownloadAndExtractZip(urlMaps, zipFileNameMaps, zipFileNameM, extractDirectory);

            // For xml_vehicles.zip
            string urlVehicles = "http://bedrock.root.sx/xml_vehicles.zip";
            string zipFileNameVehicles = "xml_vehicles";
            string zipFileNameV = "XML Vehicles";

            DownloadAndExtractZip(urlVehicles, zipFileNameVehicles, zipFileNameV, extractDirectory);
        }

        private bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RestartAsAdmin()
        {
            try
            {
                string exeName = Assembly.GetEntryAssembly().Location;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas"; // Run as administrator
                Process.Start(startInfo);
                Application.Exit(); // Exit current instance
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restarting application as administrator: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void installYimASI_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            openFileDialog.Title = "Find & Select GTA5.exe";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string gta5Path = openFileDialog.FileName;

                string yimASIUrl = "https://github.com/xesdoog/YimASI/releases/download/release/WTSAPI32.dll";
                string scriptHookUrl = "http://bedrock.root.sx/ScriptHookV.dll";

                string gtaFolder = Path.GetDirectoryName(gta5Path); // Get the directory where GTA5.exe is located
                string scriptHookFilePath = Path.Combine(gtaFolder, "ScriptHookV.dll");
                string yimASIFilePath = Path.Combine(gtaFolder, "YimASI.dll");

                if (!IsAdministrator())
                {
                    // Prompt user to restart as admin
                    DialogResult result = MessageBox.Show("This operation requires administrative privileges to install to your game path, Restart your application as administrator and try again!",
                                                          "Admin Privileges Required", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                DownloadFile(yimASIUrl, yimASIFilePath, "YimASI downloaded successfully to: ");
                DownloadFile(scriptHookUrl, scriptHookFilePath, "ScriptHookV downloaded successfully to: ");
            }
        }
    }
}
