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
    public partial class Form5 : Form
    {
        Form2 ownerForm;
        Form1 ownerForm1;
        public Form5(Form2 ownerForm,Form1 ownerForm1)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            this.ownerForm1 = ownerForm1;
        }
        string StringUTC;
        TimeSpan TZ = new TimeSpan();
        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = "The (GMT) Time now is ";
            label2.Text = "warning:This World Time only take your \r\n      computer time setting";
            button4.Text = "Back to Setting";
            button5.Text = "create a time";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ownerForm.From5Command();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        TZ = new TimeSpan(00, 00, 00);
                        StringUTC = "Greenwich Mean Time(GMT";
                        break;
                    case 1:
                        TZ = new TimeSpan(01, 00, 00);
                        StringUTC = "European Central Time(GMT+1:00";
                        break;
                    case 2:
                        TZ = new TimeSpan(02, 00, 00);
                        StringUTC = "Eastern European Time(GMT+2:00";
                        break;
                    case 3:
                        TZ = new TimeSpan(02, 00, 00);
                        StringUTC = "(Arabic) Egypt Standard Time(GMT+2:00";
                        break;
                    case 4:
                        TZ = new TimeSpan(03, 00, 00);
                        StringUTC = "Eastern African Time(GMT+3:00";
                        break;
                    case 5:
                        TZ = new TimeSpan(03, 30, 00);
                        StringUTC = "Middle East Time(GMT+3:30";
                        break;
                    case 6:
                        TZ = new TimeSpan(04, 00, 00);
                        StringUTC = "Near East Time(GMT+4:00";
                        break;
                    case 7:
                        TZ = new TimeSpan(05, 00, 00);
                        StringUTC = "Pakistan Lahore Time(GMT+5:00";
                        break;
                    case 8:
                        TZ = new TimeSpan(05, 30, 00);
                        StringUTC = "India Standard Time(GMT+5:30";
                        break;
                    case 9:
                        TZ = new TimeSpan(06, 00, 00);
                        StringUTC = "Bangladesh Standard Time(GMT+6:00";
                        break;
                    case 10:
                        TZ = new TimeSpan(07, 00, 00);
                        StringUTC = "Vietnam Standard Time(GMT+7:00";
                        break;
                    case 11:
                        TZ = new TimeSpan(08, 00, 00);
                        StringUTC = "China Taiwan Time(GMT+8:00";
                        break;
                    case 12:
                        TZ = new TimeSpan(09, 00, 00);
                        StringUTC = "Japan Standard Time(GMT+9:00";
                        break;
                    case 13:
                        TZ = new TimeSpan(09, 30, 00);
                        StringUTC = "Australia Central Time(GMT+9:30";
                        break;
                    case 14:
                        TZ = new TimeSpan(10, 00, 00);
                        StringUTC = "Australia Eastern Time(GMT+10:00";
                        break;
                    case 15:
                        TZ = new TimeSpan(11, 00, 00);
                        StringUTC = "Solomon Standard Time(GMT+11:00";
                        break;
                    case 16:
                        TZ = new TimeSpan(12, 00, 00);
                        StringUTC = "New Zealand Standard Time(GMT+12:00";
                        break;
                    case 17:
                        TZ = new TimeSpan(-11, 00, 00);
                        StringUTC = "Midway Islands Time(GMT-11:00";
                        break;
                    case 18:
                        TZ = new TimeSpan(-10, 00, 00);
                        StringUTC = "Hawaii Standard Time(GMT-10:00";
                        break;
                    case 19:
                        TZ = new TimeSpan(-09, 00, 00);
                        StringUTC = "Alaska Standard Time(GMT-9:00";
                        break;
                    case 20:
                        TZ = new TimeSpan(-08, 00, 00);
                        StringUTC = "Pacific Standard Time(GMT-8:00";
                        break;
                    case 21:
                        TZ = new TimeSpan(-07, 00, 00);
                        StringUTC = "Phoenix Standard Time(GMT-7:00";
                        break;
                    case 22:
                        TZ = new TimeSpan(-07, 00, 00);
                        StringUTC = "Mountain Standard Time(GMT-7:00";
                        break;
                    case 23:
                        TZ = new TimeSpan(-06, 00, 00);
                        StringUTC = "Central Standard Time(GMT-6:00";
                        break;
                    case 24:
                        TZ = new TimeSpan(-05, 00, 00);
                        StringUTC = "Eastern Standard Time(GMT-5:00";
                        break;
                    case 25:
                        TZ = new TimeSpan(-05, 00, 00);
                        StringUTC = "Indiana Eastern Standard Time(GMT-5:00";
                        break;
                    case 26:
                        TZ = new TimeSpan(-04, 00, 00);
                        StringUTC = "Puerto Rico and US Virgin Islands Time(GMT-4:00";
                        break;
                    case 27:
                        TZ = new TimeSpan(-03, 30, 00);
                        StringUTC = "Canada Newfoundland Time(GMT-3:30";
                        break;
                    case 28:
                        TZ = new TimeSpan(-03, 00, 00);
                        StringUTC = "Argentina Standard Time(GMT-3:00";
                        break;
                    case 29:
                        TZ = new TimeSpan(-03, 00, 00);
                        StringUTC = "Brazil Eastern Time(GMT-3:00";
                        break;
                    case 30:
                        TZ = new TimeSpan(-01, 00, 00);
                        StringUTC = "Central African Time(GMT-1:00";
                        break;
                }
                Form6 GoToWorldTime = new Form6(this);
                GoToWorldTime.PassWorldTimeData(TZ, StringUTC);
                GoToWorldTime.Show();
                comboBox4.SelectedItem = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "The (GMT) Time now is  " +DateTime.UtcNow.ToString();
        }
    }
}
