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
    public partial class Form3 : Form
    {
        Form2 ownerForm = null;
        public Form3(Form2 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        TimeSpan Timer = new TimeSpan();
        bool IsStartTimer = false;
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button4.Text = "Back to setting";
            button1.Text = "Start";
            button2.Text = "Reset";
            button3.Text = "Make one turn";
            label1.Text = "Ready to START";
            label1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer = Timer.Add(new TimeSpan(00,00,00,00,100));
            label1.Text = Timer.Days.ToString() + " " + Timer.Hours.ToString() + ":" + Timer.Minutes.ToString() + ":" + Timer.Seconds.ToString() + ":" + (Timer.Milliseconds /100).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsStartTimer == false)
            {
                timer1.Enabled = true;
                IsStartTimer = true;
                button1.Text = "Stop";
            }
            else
            {
                timer1.Enabled = false;
                IsStartTimer = false;
                button1.Text = "Start";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Ready to START";
            Timer = new TimeSpan();
            timer1.Enabled = false;
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled==true)
            listBox1.Items.Add((listBox1.Items.Count + 1).ToString() + ":   " + label1.Text);
        }
    }
}
