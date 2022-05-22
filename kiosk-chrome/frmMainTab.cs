using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;
using Microsoft.Win32;

namespace kiosk_chrome
{
    public partial class frmMainTab : Form
    {
        public frmMainTab()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            Gecko.CertOverrideService.GetService().ValidityOverride += geckoWeb_ValidityOverride;
        }
        private void geckoWeb_ValidityOverride(object sender, Gecko.Events.CertOverrideEventArgs e)
        {
            e.OverrideResult = Gecko.CertOverride.Mismatch | Gecko.CertOverride.Time | Gecko.CertOverride.Untrusted;
            e.Temporary = true;
            e.Handled = true;
        }
        private void frmMainTab_Load(object sender, EventArgs e)
        {
            geckoWeb.Navigate(ConfigFile.readSettings("tab1-value"));
            cmdPortal.Text = ConfigFile.readSettings("tab1-name");
            cmdErv.Text = ConfigFile.readSettings("tab2-name");
            cmdWeb.Text = ConfigFile.readSettings("tab3-name");
            if (ConfigFile.readSettings("") == "1")
                AppAutorun.setAppInAutoRun();
            else
                AppAutorun.removeAppFromAutoRun();
        }
        public void openForm(string formName)
        {
            try
            {
                Form fo = Application.OpenForms[formName];
                if (fo == null)
                {
                    var type = Type.GetType("kiosk_chrome." + formName);
                    var form = Activator.CreateInstance(type) as Form;
                    if (form != null)
                    {                  
                        form.Show();
                    }
                }
            }
            catch { }
        }
        private void cmdPortal_Click(object sender, EventArgs e)
        {
            geckoWeb.Navigate(ConfigFile.readSettings("tab1-value"));
        }
        private void cmdErv_Click(object sender, EventArgs e)
        {
            geckoWeb.Navigate(ConfigFile.readSettings("tab2-value"));
        }
        private void cmdWeb_Click(object sender, EventArgs e)
        {
            geckoWeb.Navigate(ConfigFile.readSettings("tab3-value"));
        }
        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm("frmUnlock");
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTimeHelper.getDateTime();
        }
        private void frmMainTab_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void frmMainTab_Deactivate(object sender, EventArgs e)
        {
            Activate();
            BringToFront();
            Focus();
        }
        public void terminateApp()
        {
            killApp(Process.GetCurrentProcess().ProcessName);
        }
        private static void killApp(string processName)
        {
            Process.Start("cmd.exe", "/c taskkill /F /IM " + processName + ".exe /T");
        }
        private void frmMainTab_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
                WindowState = this.WindowState = FormWindowState.Maximized;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it@savacoop.rs - 2022. V1.0");
        }
    }
}
