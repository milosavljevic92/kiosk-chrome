using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiosk_chrome
{
    public partial class frmUnlock : Form
    {
        public frmUnlock()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "SavacooP.0210!")   
                (Application.OpenForms["frmMainTab"] as frmMainTab).terminateApp();
        }
    }
}
