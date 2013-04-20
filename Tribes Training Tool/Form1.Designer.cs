namespace Tribes_Training_Tool
{
    partial class Form1
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
            this.comboBoxGameChosie = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelHealth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBaseGameAdress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelXPos = new System.Windows.Forms.Label();
            this.labelYPos = new System.Windows.Forms.Label();
            this.labelZPos = new System.Windows.Forms.Label();
            this.comboBoxMap = new System.Windows.Forms.ComboBox();
            this.buttonBESpawn1 = new System.Windows.Forms.Button();
            this.buttonBESpawn2 = new System.Windows.Forms.Button();
            this.buttonBESpawn3 = new System.Windows.Forms.Button();
            this.buttonBESpawn4 = new System.Windows.Forms.Button();
            this.buttonDSSpawn1 = new System.Windows.Forms.Button();
            this.buttonDSSpawn2 = new System.Windows.Forms.Button();
            this.buttonDSSpawn3 = new System.Windows.Forms.Button();
            this.buttonDSSpawn4 = new System.Windows.Forms.Button();
            this.buttonSetHealth900 = new System.Windows.Forms.Button();
            this.button2SetHealth1000000 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonPlaybackAI = new System.Windows.Forms.Button();
            this.labelRecordPlayback = new System.Windows.Forms.Label();
            this.buttonPlayback = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.labelAIHealth = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelAIXPos = new System.Windows.Forms.Label();
            this.labelAIYPos = new System.Windows.Forms.Label();
            this.labelAIZPos = new System.Windows.Forms.Label();
            this.labelXSpeed = new System.Windows.Forms.Label();
            this.labelYSpeed = new System.Windows.Forms.Label();
            this.labelZSpeed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxGameChosie
            // 
            this.comboBoxGameChosie.FormattingEnabled = true;
            this.comboBoxGameChosie.Location = new System.Drawing.Point(15, 19);
            this.comboBoxGameChosie.Name = "comboBoxGameChosie";
            this.comboBoxGameChosie.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGameChosie.TabIndex = 0;
            this.comboBoxGameChosie.SelectedIndexChanged += new System.EventHandler(this.comboBoxGameChosie_SelectedIndexChanged);
            this.comboBoxGameChosie.Click += new System.EventHandler(this.comboBoxGameChosie_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelHealth
            // 
            this.labelHealth.AutoSize = true;
            this.labelHealth.Location = new System.Drawing.Point(70, 146);
            this.labelHealth.Name = "labelHealth";
            this.labelHealth.Size = new System.Drawing.Size(35, 13);
            this.labelHealth.TabIndex = 1;
            this.labelHealth.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // labelBaseGameAdress
            // 
            this.labelBaseGameAdress.AutoSize = true;
            this.labelBaseGameAdress.Location = new System.Drawing.Point(160, 8);
            this.labelBaseGameAdress.Name = "labelBaseGameAdress";
            this.labelBaseGameAdress.Size = new System.Drawing.Size(35, 13);
            this.labelBaseGameAdress.TabIndex = 4;
            this.labelBaseGameAdress.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Health";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "X-Pos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Y-Pos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Z-Pos";
            // 
            // labelXPos
            // 
            this.labelXPos.AutoSize = true;
            this.labelXPos.Location = new System.Drawing.Point(70, 175);
            this.labelXPos.Name = "labelXPos";
            this.labelXPos.Size = new System.Drawing.Size(35, 13);
            this.labelXPos.TabIndex = 10;
            this.labelXPos.Text = "label1";
            // 
            // labelYPos
            // 
            this.labelYPos.AutoSize = true;
            this.labelYPos.Location = new System.Drawing.Point(70, 208);
            this.labelYPos.Name = "labelYPos";
            this.labelYPos.Size = new System.Drawing.Size(35, 13);
            this.labelYPos.TabIndex = 11;
            this.labelYPos.Text = "label9";
            // 
            // labelZPos
            // 
            this.labelZPos.AutoSize = true;
            this.labelZPos.Location = new System.Drawing.Point(70, 238);
            this.labelZPos.Name = "labelZPos";
            this.labelZPos.Size = new System.Drawing.Size(41, 13);
            this.labelZPos.TabIndex = 12;
            this.labelZPos.Text = "label10";
            // 
            // comboBoxMap
            // 
            this.comboBoxMap.FormattingEnabled = true;
            this.comboBoxMap.Items.AddRange(new object[] {
            "DryDock",
            "CrossFire"});
            this.comboBoxMap.Location = new System.Drawing.Point(295, 42);
            this.comboBoxMap.Name = "comboBoxMap";
            this.comboBoxMap.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMap.TabIndex = 13;
            // 
            // buttonBESpawn1
            // 
            this.buttonBESpawn1.Location = new System.Drawing.Point(283, 178);
            this.buttonBESpawn1.Name = "buttonBESpawn1";
            this.buttonBESpawn1.Size = new System.Drawing.Size(75, 23);
            this.buttonBESpawn1.TabIndex = 14;
            this.buttonBESpawn1.Text = "BE Spawn 1";
            this.buttonBESpawn1.UseVisualStyleBackColor = true;
            this.buttonBESpawn1.Click += new System.EventHandler(this.buttonBESpawn1_Click);
            // 
            // buttonBESpawn2
            // 
            this.buttonBESpawn2.Location = new System.Drawing.Point(283, 207);
            this.buttonBESpawn2.Name = "buttonBESpawn2";
            this.buttonBESpawn2.Size = new System.Drawing.Size(75, 23);
            this.buttonBESpawn2.TabIndex = 15;
            this.buttonBESpawn2.Text = "BE Spawn 2";
            this.buttonBESpawn2.UseVisualStyleBackColor = true;
            this.buttonBESpawn2.Click += new System.EventHandler(this.buttonBESpawn2_Click);
            // 
            // buttonBESpawn3
            // 
            this.buttonBESpawn3.Location = new System.Drawing.Point(283, 236);
            this.buttonBESpawn3.Name = "buttonBESpawn3";
            this.buttonBESpawn3.Size = new System.Drawing.Size(75, 23);
            this.buttonBESpawn3.TabIndex = 16;
            this.buttonBESpawn3.Text = "BE Spawn 3";
            this.buttonBESpawn3.UseVisualStyleBackColor = true;
            this.buttonBESpawn3.Click += new System.EventHandler(this.buttonBESpawn3_Click);
            // 
            // buttonBESpawn4
            // 
            this.buttonBESpawn4.Location = new System.Drawing.Point(283, 265);
            this.buttonBESpawn4.Name = "buttonBESpawn4";
            this.buttonBESpawn4.Size = new System.Drawing.Size(75, 23);
            this.buttonBESpawn4.TabIndex = 17;
            this.buttonBESpawn4.Text = "BE Spawn 4";
            this.buttonBESpawn4.UseVisualStyleBackColor = true;
            this.buttonBESpawn4.Click += new System.EventHandler(this.buttonBESpawn4_Click);
            // 
            // buttonDSSpawn1
            // 
            this.buttonDSSpawn1.Location = new System.Drawing.Point(364, 178);
            this.buttonDSSpawn1.Name = "buttonDSSpawn1";
            this.buttonDSSpawn1.Size = new System.Drawing.Size(75, 23);
            this.buttonDSSpawn1.TabIndex = 18;
            this.buttonDSSpawn1.Text = "DS Spawn 1";
            this.buttonDSSpawn1.UseVisualStyleBackColor = true;
            this.buttonDSSpawn1.Click += new System.EventHandler(this.buttonDSSpawn1_Click);
            // 
            // buttonDSSpawn2
            // 
            this.buttonDSSpawn2.Location = new System.Drawing.Point(364, 207);
            this.buttonDSSpawn2.Name = "buttonDSSpawn2";
            this.buttonDSSpawn2.Size = new System.Drawing.Size(75, 23);
            this.buttonDSSpawn2.TabIndex = 19;
            this.buttonDSSpawn2.Text = "DS Spawn 2";
            this.buttonDSSpawn2.UseVisualStyleBackColor = true;
            this.buttonDSSpawn2.Click += new System.EventHandler(this.buttonDSSpawn2_Click);
            // 
            // buttonDSSpawn3
            // 
            this.buttonDSSpawn3.Location = new System.Drawing.Point(364, 236);
            this.buttonDSSpawn3.Name = "buttonDSSpawn3";
            this.buttonDSSpawn3.Size = new System.Drawing.Size(75, 23);
            this.buttonDSSpawn3.TabIndex = 20;
            this.buttonDSSpawn3.Text = "DS Spawn 3";
            this.buttonDSSpawn3.UseVisualStyleBackColor = true;
            this.buttonDSSpawn3.Click += new System.EventHandler(this.buttonDSSpawn3_Click);
            // 
            // buttonDSSpawn4
            // 
            this.buttonDSSpawn4.Location = new System.Drawing.Point(364, 265);
            this.buttonDSSpawn4.Name = "buttonDSSpawn4";
            this.buttonDSSpawn4.Size = new System.Drawing.Size(75, 23);
            this.buttonDSSpawn4.TabIndex = 21;
            this.buttonDSSpawn4.Text = "DS Spawn 4";
            this.buttonDSSpawn4.UseVisualStyleBackColor = true;
            this.buttonDSSpawn4.Click += new System.EventHandler(this.buttonDSSpawn4_Click);
            // 
            // buttonSetHealth900
            // 
            this.buttonSetHealth900.Location = new System.Drawing.Point(283, 107);
            this.buttonSetHealth900.Name = "buttonSetHealth900";
            this.buttonSetHealth900.Size = new System.Drawing.Size(75, 23);
            this.buttonSetHealth900.TabIndex = 22;
            this.buttonSetHealth900.Text = "900";
            this.buttonSetHealth900.UseVisualStyleBackColor = true;
            this.buttonSetHealth900.Click += new System.EventHandler(this.buttonSetHealth900_Click);
            // 
            // button2SetHealth1000000
            // 
            this.button2SetHealth1000000.Location = new System.Drawing.Point(364, 107);
            this.button2SetHealth1000000.Name = "button2SetHealth1000000";
            this.button2SetHealth1000000.Size = new System.Drawing.Size(75, 23);
            this.button2SetHealth1000000.TabIndex = 23;
            this.button2SetHealth1000000.Text = "1000000";
            this.button2SetHealth1000000.UseVisualStyleBackColor = true;
            this.button2SetHealth1000000.Click += new System.EventHandler(this.button2SetHealth1000000_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Set Health";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Map";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(310, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Set Spawn";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 546);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.labelZSpeed);
            this.tabPage1.Controls.Add(this.labelYSpeed);
            this.tabPage1.Controls.Add(this.labelXSpeed);
            this.tabPage1.Controls.Add(this.comboBoxGameChosie);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.labelHealth);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button2SetHealth1000000);
            this.tabPage1.Controls.Add(this.labelBaseGameAdress);
            this.tabPage1.Controls.Add(this.buttonSetHealth900);
            this.tabPage1.Controls.Add(this.buttonDSSpawn4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonDSSpawn3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.buttonDSSpawn2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.buttonDSSpawn1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.buttonBESpawn4);
            this.tabPage1.Controls.Add(this.labelXPos);
            this.tabPage1.Controls.Add(this.buttonBESpawn3);
            this.tabPage1.Controls.Add(this.labelYPos);
            this.tabPage1.Controls.Add(this.buttonBESpawn2);
            this.tabPage1.Controls.Add(this.labelZPos);
            this.tabPage1.Controls.Add(this.buttonBESpawn1);
            this.tabPage1.Controls.Add(this.comboBoxMap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonPlaybackAI);
            this.tabPage2.Controls.Add(this.labelRecordPlayback);
            this.tabPage2.Controls.Add(this.buttonPlayback);
            this.tabPage2.Controls.Add(this.buttonRecord);
            this.tabPage2.Controls.Add(this.labelAIHealth);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.labelAIXPos);
            this.tabPage2.Controls.Add(this.labelAIYPos);
            this.tabPage2.Controls.Add(this.labelAIZPos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonPlaybackAI
            // 
            this.buttonPlaybackAI.Location = new System.Drawing.Point(421, 53);
            this.buttonPlaybackAI.Name = "buttonPlaybackAI";
            this.buttonPlaybackAI.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaybackAI.TabIndex = 24;
            this.buttonPlaybackAI.Text = "Playback AI";
            this.buttonPlaybackAI.UseVisualStyleBackColor = true;
            this.buttonPlaybackAI.Click += new System.EventHandler(this.buttonPlaybackAI_Click);
            // 
            // labelRecordPlayback
            // 
            this.labelRecordPlayback.AutoSize = true;
            this.labelRecordPlayback.Location = new System.Drawing.Point(270, 99);
            this.labelRecordPlayback.Name = "labelRecordPlayback";
            this.labelRecordPlayback.Size = new System.Drawing.Size(27, 13);
            this.labelRecordPlayback.TabIndex = 23;
            this.labelRecordPlayback.Text = "asdf";
            // 
            // buttonPlayback
            // 
            this.buttonPlayback.Location = new System.Drawing.Point(319, 52);
            this.buttonPlayback.Name = "buttonPlayback";
            this.buttonPlayback.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayback.TabIndex = 22;
            this.buttonPlayback.Text = "Playback";
            this.buttonPlayback.UseVisualStyleBackColor = true;
            this.buttonPlayback.Click += new System.EventHandler(this.buttonPlayback_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(194, 53);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonRecord.TabIndex = 21;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // labelAIHealth
            // 
            this.labelAIHealth.AutoSize = true;
            this.labelAIHealth.Location = new System.Drawing.Point(73, 124);
            this.labelAIHealth.Name = "labelAIHealth";
            this.labelAIHealth.Size = new System.Drawing.Size(35, 13);
            this.labelAIHealth.TabIndex = 13;
            this.labelAIHealth.Text = "label1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Health";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "X-Pos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Y-Pos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Z-Pos";
            // 
            // labelAIXPos
            // 
            this.labelAIXPos.AutoSize = true;
            this.labelAIXPos.Location = new System.Drawing.Point(73, 153);
            this.labelAIXPos.Name = "labelAIXPos";
            this.labelAIXPos.Size = new System.Drawing.Size(35, 13);
            this.labelAIXPos.TabIndex = 18;
            this.labelAIXPos.Text = "label1";
            // 
            // labelAIYPos
            // 
            this.labelAIYPos.AutoSize = true;
            this.labelAIYPos.Location = new System.Drawing.Point(73, 186);
            this.labelAIYPos.Name = "labelAIYPos";
            this.labelAIYPos.Size = new System.Drawing.Size(35, 13);
            this.labelAIYPos.TabIndex = 19;
            this.labelAIYPos.Text = "label9";
            // 
            // labelAIZPos
            // 
            this.labelAIZPos.AutoSize = true;
            this.labelAIZPos.Location = new System.Drawing.Point(73, 216);
            this.labelAIZPos.Name = "labelAIZPos";
            this.labelAIZPos.Size = new System.Drawing.Size(41, 13);
            this.labelAIZPos.TabIndex = 20;
            this.labelAIZPos.Text = "label10";
            // 
            // labelXSpeed
            // 
            this.labelXSpeed.AutoSize = true;
            this.labelXSpeed.Location = new System.Drawing.Point(70, 265);
            this.labelXSpeed.Name = "labelXSpeed";
            this.labelXSpeed.Size = new System.Drawing.Size(41, 13);
            this.labelXSpeed.TabIndex = 27;
            this.labelXSpeed.Text = "label10";
            // 
            // labelYSpeed
            // 
            this.labelYSpeed.AutoSize = true;
            this.labelYSpeed.Location = new System.Drawing.Point(70, 291);
            this.labelYSpeed.Name = "labelYSpeed";
            this.labelYSpeed.Size = new System.Drawing.Size(41, 13);
            this.labelYSpeed.TabIndex = 28;
            this.labelYSpeed.Text = "label10";
            // 
            // labelZSpeed
            // 
            this.labelZSpeed.AutoSize = true;
            this.labelZSpeed.Location = new System.Drawing.Point(70, 321);
            this.labelZSpeed.Name = "labelZSpeed";
            this.labelZSpeed.Size = new System.Drawing.Size(41, 13);
            this.labelZSpeed.TabIndex = 29;
            this.labelZSpeed.Text = "label10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "X Speed";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 291);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Y Speed";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 321);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Z Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 546);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGameChosie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelHealth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBaseGameAdress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelXPos;
        private System.Windows.Forms.Label labelYPos;
        private System.Windows.Forms.Label labelZPos;
        private System.Windows.Forms.ComboBox comboBoxMap;
        private System.Windows.Forms.Button buttonBESpawn1;
        private System.Windows.Forms.Button buttonBESpawn2;
        private System.Windows.Forms.Button buttonBESpawn3;
        private System.Windows.Forms.Button buttonBESpawn4;
        private System.Windows.Forms.Button buttonDSSpawn1;
        private System.Windows.Forms.Button buttonDSSpawn2;
        private System.Windows.Forms.Button buttonDSSpawn3;
        private System.Windows.Forms.Button buttonDSSpawn4;
        private System.Windows.Forms.Button buttonSetHealth900;
        private System.Windows.Forms.Button button2SetHealth1000000;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelAIHealth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelAIXPos;
        private System.Windows.Forms.Label labelAIYPos;
        private System.Windows.Forms.Label labelAIZPos;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonPlayback;
        private System.Windows.Forms.Label labelRecordPlayback;
        private System.Windows.Forms.Button buttonPlaybackAI;
        private System.Windows.Forms.Label labelXSpeed;
        private System.Windows.Forms.Label labelZSpeed;
        private System.Windows.Forms.Label labelYSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
    }
}

