using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form6 : Form
    {
        Form5 ownerForm;
        public Form6(Form5 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }
        DateTime DT = DateTime.UtcNow;
        TimeSpan UTCTZ;
        public void PassWorldTimeData(TimeSpan PassTZ,string PassStringUTC)
        {
            label5.Text = PassStringUTC;
            DT = DT.AddHours(-UTCTZ.Hours);
            DT = DT.AddHours(PassTZ.Hours);
            UTCTZ = PassTZ;
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label1.Text = "";
            label3.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DT = DateTime.UtcNow;
            DT = DT.AddHours(UTCTZ.Hours);
            label2.Text = DT.ToString("yyyy/MM/dd");
            label1.Text = DT.ToString("HH:mm:ss");
            label3.Text = "("+ UTCTZ.Hours.ToString() +" GMT)";
        }
    }
}
