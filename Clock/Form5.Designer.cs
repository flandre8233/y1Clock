namespace Clock
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(256, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Greenwich Mean Time(GMT +-0:00)",
            "European Central Time(GMT+1:00)",
            "Eastern European Time(GMT+2:00)",
            "(Arabic) Egypt Standard Time(GMT+2:00)",
            "Eastern African Time(GMT+3:00)",
            "Middle East Time(GMT+3:30)",
            "Near East Time(GMT+4:00)",
            "Pakistan Lahore Time(GMT+5:00)",
            "India Standard Time(GMT+5:30)",
            "Bangladesh Standard Time(GMT+6:00)",
            "Vietnam Standard Time(GMT+7:00)",
            "China Taiwan Time(GMT+8:00)",
            "Japan Standard Time(GMT+9:00)",
            "Australia Central Time(GMT+9:30)",
            "Australia Eastern Time(GMT+10:00)",
            "Solomon Standard Time(GMT+11:00)",
            "New Zealand Standard Time(GMT+12:00)",
            "Midway Islands Time(GMT-11:00)",
            "Hawaii Standard Time(GMT-10:00)",
            "Alaska Standard Time(GMT-9:00)",
            "Pacific Standard Time(GMT-8:00)",
            "Phoenix Standard Time(GMT-7:00)",
            "Mountain Standard Time(GMT-7:00)",
            "Central Standard Time(GMT-6:00)",
            "Eastern Standard Time(GMT-5:00)",
            "Indiana Eastern Standard Time(GMT-5:00)",
            "Puerto Rico and US Virgin Islands Time(GMT-4:00)",
            "Canada Newfoundland Time(GMT-3:30)",
            "Argentina Standard Time(GMT-3:00)",
            "Brazil Eastern Time(GMT-3:00)",
            "Central African Time(GMT-1:00)"});
            this.comboBox4.Location = new System.Drawing.Point(12, 24);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(194, 21);
            this.comboBox4.TabIndex = 37;
            this.comboBox4.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(256, 23);
            this.button5.TabIndex = 35;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "label2";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Form5";
            this.ShowIcon = false;
            this.Text = "World Time";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}