using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Media;

namespace Clock
{
    public partial class Form1 : Form
    {

        string ClockVersion = "1.32 Beta";
        /*
                    LOG
         * 1.02
         * 改變了設定的運送資料方法,由一個Button負責改為兩個.
         * 修正了小遊戲能拿到10000分獎勵的方法,難度向上修正.
         * 重新設計setting頁面的版面.
         * 烏龍茶好難喝
         * 1.03
         * Fixed設定時區和設定時間會出現的衝突問題.
         * DT = DT.AddHours(-UTCTZ.Hours);
            DT = DT.AddHours(PassTZ.Hours);
            UTCTZ = PassTZ;
         * 限制了小遊戲的觸發條件,現在只能在未自行設定時間和本機時間一樣的情況下才能玩.
         * 更改了Timer初始顯示的名字.
         * 1.04
         * 修正了Timer1處理事件先後次序.
         * 鬧鐘開發中...
         * 1.05
         * 小遊戲新增擊中音效.COD化.
         * 1.10
         * 鬧鐘功能成功開發!
         * 終於喝完個烏龍茶,真的好難喝
         * 1.11
         * 修改Timer1遲緩.
         * 修正判定設定鬧鐘方法
         * 在鬧鐘裡移除了秒設定欄位.
         * 1.12
         * 更改判定鬧鐘方法
         * 令鬧鐘頁面更user-friendly
         * 補回管理員權限需求的程式,這是為了讓存檔機制成功被執行而設
         * 1.13
         * 更新Timer1執行程序,大複改良Timer1的遲緩問題.
         * 倒數計時器開發中...
         * 世界時間區計畫中...
         * 1.131
         * HotFixed顯示小時問題.
         * Fixed Reset All 時區問題.
         * HotFixed Array 過細問題.
         * 去除部份已經沒用的變數.
         * 1.20
         * 倒數計時器功能成功開發!
         * 世界時間區開發中...
         * 1.21
         * 更變計時器的變數設定.
         * 新增計時器的暫停功能.
         * 1.30
         * 世界時間區開發完成!
         * 1.31 BETA
         * 增設隱藏最小化視窗功能.
         * 雙擊圖示可重新顯示程式.
         * 右鍵圖示也能看到重新顯示程式的按鈕.
         * 1.32
         * HotFixed不能正常開啓Setting問題.
         * HotFixed不能正常雙擊的問題.
         * HotFixed世界時間的顯示問題.
         * HotFixed世界時間的顯示,增加一個時鐘(GMT).
         * HotFixed增加警告字眼.
         * HotFixed計時器圈數視覺問題.
         * Clock 1.32 BETA F.
        */
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
        }
        bool Bool01 = false;
        bool Bool02 = false;
        bool IsSetAlarm = false;
        bool IsHide = false;

        DateTime DT = new DateTime();
        TimeSpan UTCTZ = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
        TimeSpan AlarmClock = new TimeSpan();
        Point ClockMid = new Point();
        Point Obj = new Point();

        Point[,] ClockPointLocation = new Point[3,70];
        Point SecondPoint = new Point();
        Point MinutesPoint = new Point();
        Point HourPoint = new Point();
        int Radius = 90;
        Pen RedPen = new Pen(Color.Red, 2);
        Pen BluePen = new Pen(Color.Blue, 3);
        Pen BlackPen01 = new Pen(Color.Black, 3);
        Pen BlackPen02 = new Pen(Color.Black, 5);
        Point point01 = new Point();
        SoundPlayer Sound = new SoundPlayer(Clock.Properties.Resources.Hitmarker_sound_shit);
        int Score = 0;

        public void PassSettingDataAlarmClock(TimeSpan PassAlarmClock)
        {
            AlarmClock = PassAlarmClock;
            if (PassAlarmClock != new TimeSpan())
            {
                IsSetAlarm = true;
                label7.Text = AlarmClock.ToString() + " Will be Alarm";
                label7.Visible = true;
                button2.Visible = true;
            }
            else
            {
                IsSetAlarm = false;
                label7.Visible = false;
                button2.Visible = false;
            }
        }

        public void PassSettingDataDT(bool PassBool02,DateTime PassDT)
        {
            Bool02 = PassBool02;
            DT = PassDT ;
        }

        public void PassSettingDataTZ(TimeSpan PassTZ, string PassStringUTC)
        {
            label5.Text = PassStringUTC;
            DT = DT.AddHours(-UTCTZ.Hours);
            DT = DT.AddHours(PassTZ.Hours);
            UTCTZ = PassTZ;
        }

        public void PassResetSettingData()
        {
            Bool02 = false;
            label5.Text = TimeZoneInfo.Local.DisplayName;
            UTCTZ = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Bool01 == false)
            {
                Graphics graphics01 = this.CreateGraphics();

                // graphics01.FillEllipse(Brushes.Red,PendulumMid.X -5/2,PendulumMid.Y-5/2,5,5);

                //graphics01.DrawLine(Pens.Red, PendulumPoint01, PendulumPoint02);
                graphics01.DrawLine(RedPen, ClockMid, SecondPoint);
                graphics01.DrawLine(BlackPen01, ClockMid, MinutesPoint);
                graphics01.DrawLine(BlackPen02, ClockMid, HourPoint);
                DrawIt();
            }
        }

        void DrawIt()
        {
            Graphics graphics01 = this.CreateGraphics();
            for (int i = 0; i < 360; i += 6)
            {
                Obj = new Point((int)(ClockMid.X + Radius * Math.Cos(i * (Math.PI / 180))),(int)(ClockMid.Y + Radius * Math.Sin(i * (Math.PI / 180))));
                graphics01.FillRectangle(Brushes.Black, Obj.X - 5 / 2, Obj.Y - 5 / 2, 5, 5);
                if (i % 30 == 0)
                    graphics01.FillEllipse(Brushes.Red, Obj.X - 15 / 2, Obj.Y - 15 / 2, 15, 15);
            }
            graphics01.FillEllipse(Brushes.Red, ClockMid.X - 20 / 2, ClockMid.Y - 20 / 2, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SecondPoint = ClockPointLocation[0,DT.Second];
            MinutesPoint = ClockPointLocation[1,DT.Minute];
            HourPoint = ClockPointLocation[2,DT.Hour];

            Invalidate();
            if (Bool02 == false)
            {
                DT = DateTime.UtcNow;
                DT = DT.AddHours(UTCTZ.Hours);
            }
            else
            {
                DT = DT.AddSeconds(1);
            }
            if (DT == DateTime.Now)
            {
                button1.Enabled = true;
                label4.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                label4.Visible = false;
            }
            label3.Text = DT.ToString("HH:mm:ss");
            label1.Text = DT.ToString("yyyy/MM/dd");
            if (DT.Minute % 5 == 0 && DT.Second == 10)
            {
                System.IO.File.WriteAllText(@"C:\ClockScore.txt", Score.ToString());
            }
            if ((int)DT.TimeOfDay.TotalMinutes == AlarmClock.TotalMinutes && IsSetAlarm == true)
            {
                Sound.PlayLooping();
            }
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Bool01 == false)
            {
                Bool01 = true;
                label3.Visible = true;
                button3.Visible = true;
                button3.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                label3.Visible = false;
                button3.Visible = false;
                button3.Enabled = false;
                Bool01 = false;
                Bool01 = false;
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
            workingArea.Bottom - Size.Height);
            BackColor = Color.Maroon;
            TransparencyKey = Color.Maroon;

            if (System.IO.File.Exists(@"C:\ClockScore.txt"))
            {
                Score = Convert.ToInt32(System.IO.File.ReadAllText(@"C:\ClockScore.txt"));
            }

            button2.Text = "Click to stop Alarm";
            button3.Text = "Exit";
            button4.Text = "Setting";
            button5.Text = "Hide this Clock";
            button1.Text = "Hit Or Not";
            label3.Width = 100;
            label3.Height = 20;
            label1.Text = "yyyy/MM/dd";
            label4.Text = "Score = " + Score;
            label5.Text = TimeZoneInfo.Local.DisplayName;
            button2.Visible = false;
            label7.Visible = false;
            notifyIcon1.ShowBalloonTip(3000, "Clock", "The time is " + DateTime.Now.ToString() , ToolTipIcon.Info);
            ToolStripMenuItem01.Text = "ClockVersion : " + ClockVersion ;
            ToolStripMenuItem02.Text = "What is Score";
            ToolStripMenuItem0201.Text = "這是一個小遊戲,用來打發時間的點擊遊戲\r\n按下" + button1.Text + "就可以遊玩\r\n減分時是沒能按中所指定時間就倒扣100分\r\n而指定會加分時間就加分\r\n每五分鐘就會自動存下你的分數";
            ToolStripMenuItem03.Text = "Show Clock Program";
            ToolStripMenuItem04.Text = "Exit Clock Program";
            DrawIt();

            ClockMid = new Point(this.ClientSize.Width - Radius - 10,this.ClientSize.Height / 2);
            Obj = ClockMid;
            SecondPoint = ClockMid;
            MinutesPoint = ClockMid;
            HourPoint = ClockMid;
            point01 = new Point(ClockMid.X - label3.Width /2 + 10, label1.Location.Y - label3.Height/2 );   
            label3.Location = point01;

            for (int i = 0; i <= 60; i++)
            {
                ClockPointLocation[0,i] = new Point((int)(ClockMid.X + Radius * Math.Cos((i * 6 - 84) * (Math.PI / 180))), (int)(ClockMid.Y + Radius * Math.Sin((i * 6 - 84) * (Math.PI / 180))));
                ClockPointLocation[1, i] = new Point((int)(ClockMid.X + (Radius - 20) * Math.Cos((i * 6 - 90) * (Math.PI / 180))), (int)(ClockMid.Y + (Radius - 20) * Math.Sin((i * 6 - 90) * (Math.PI / 180))));
                ClockPointLocation[2, i] = new Point((int)(ClockMid.X + (Radius - 50) * Math.Cos((i * 30 - 90) * (Math.PI / 180))), (int)(ClockMid.Y + (Radius - 50) * Math.Sin((i * 30 - 90) * (Math.PI / 180))));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 GoToNextForm = new Form2(this);
            GoToNextForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DT.Second % 15 == 0)
            {
                Sound.Play();
                Score += 100;
                this.CreateGraphics().DrawLine(BluePen, ClockMid, SecondPoint);
            }

            if (DT.Minute % 15 == 0)
            {
                Sound.Play();
                Score += 10;
                this.CreateGraphics().DrawLine(BluePen, ClockMid, MinutesPoint);
            }

            if (DT.Hour % 3 == 0)
            {
                Sound.Play();
                Score ++;
                this.CreateGraphics().DrawLine(BluePen, ClockMid, HourPoint);
            }

            if (DT.Second == 0 && DT.Minute == 0 && DT.Hour == 0)
            {
                this.CreateGraphics().FillEllipse(Brushes.Blue, ClockMid.X - 30 / 2, ClockMid.Y - 30 / 2, 30, 30);
                Score += 10000;
                Sound.Play();
            }

            if (DT.Second % 15 != 0 && DT.Minute % 15 != 0 && DT.Hour % 3 != 0)
            {
                this.CreateGraphics().FillEllipse(Brushes.DarkRed, ClockMid.X - 30 / 2, ClockMid.Y - 30 / 2, 30, 30);
                Score -= 100;
            }
            label4.Text = "Score = " + Score;
        }

        private void ToolStripMenuItem03_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlarmClock = new TimeSpan();
            IsSetAlarm = false;
            label7.Visible = false;
            button2.Visible = false;
            Sound.Stop();
        }

        private void ToolStripMenuItem04_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (IsHide != false)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                IsHide = false;
            }
            else
            {
                this.Hide();
                IsHide = true;
            }
        }
    }
}