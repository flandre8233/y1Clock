using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;


namespace Clock
{
    public partial class Form4 : Form
    {
        Form2 ownerForm;
        Form1 ownerForm1;
        public Form4(Form2 ownerForm,Form1 ownerForm1)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            this.ownerForm1 = ownerForm1;
        }
        TimeSpan AlarmClock = new TimeSpan();
        TimeSpan CountdownTimer = new TimeSpan();
        SoundPlayer Sound = new SoundPlayer(Clock.Properties.Resources.Hitmarker_sound_shit);
        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Text = "Set the Alarm";
            button2.Text = "Reset the Alarm";
            button3.Text = "Set the Countdown Timer";
            button4.Text = "Back to setting";
            button5.Text = "Reset the CountTimer";
            label1.Text = "Ready to Set the Alarm";
            label2.Text = "Alarm Clock";
            label3.Text = "Countdown Timer";
            label5.Text = "Minute";
            label6.Text = "Hour";
            label4.Text = "Hour";
            label7.Text = "Minute";
            label8.Text = "Second";
            label9.Text = "Ready to START";

            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i);
                comboBox4.Items.Add(i);
                comboBox5.Items.Add(i);
                if (i < 24)
                {
                    comboBox3.Items.Add(i);
                    comboBox1.Items.Add(i);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ownerForm.From4Command();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                AlarmClock = new TimeSpan((int)comboBox3.SelectedItem, (int)comboBox2.SelectedItem, 00);
                label1.Text = AlarmClock.ToString() + "  Will be alarm";
                ownerForm1.PassSettingDataAlarmClock(AlarmClock);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sound.Stop();
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            ownerForm1.PassSettingDataAlarmClock(new TimeSpan());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null)
            {
                CountdownTimer = new TimeSpan((int)comboBox1.SelectedItem, (int)comboBox4.SelectedItem, (int)comboBox5.SelectedItem);
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CountdownTimer >= new TimeSpan())
            {
                label9.Text = CountdownTimer.ToString();
                CountdownTimer = CountdownTimer.Add(-(new TimeSpan(00, 00, 01)));
            }
            else
            {
                Sound.PlayLooping();
                timer1.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sound.Stop();
            label9.Text = "Ready to START";
            timer1.Enabled = false ;
        }
    }
}
