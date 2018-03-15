using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syndic
{
    public partial class frmRapport : Form
    {
        public frmRapport()
        {
            InitializeComponent();
        }

        private void frmRapport_Load(object sender, EventArgs e)
        {
            rptRecu r = new rptRecu();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
