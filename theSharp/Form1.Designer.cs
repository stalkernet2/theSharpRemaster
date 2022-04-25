
namespace theSharp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OutPutBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.OutPutTimer = new System.Windows.Forms.Timer(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ResumeButton = new System.Windows.Forms.Button();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FontSizeBar = new System.Windows.Forms.TrackBar();
            this.AdvGraphicBox = new System.Windows.Forms.CheckBox();
            this.BaseGraphicBox = new System.Windows.Forms.CheckBox();
            this.BrightnessBar = new System.Windows.Forms.TrackBar();
            this.DetailsBar = new System.Windows.Forms.TrackBar();
            this.InversionBox = new System.Windows.Forms.CheckBox();
            this.DetailsBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.LoadButton = new System.Windows.Forms.Button();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutPutBox
            // 
            this.OutPutBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutPutBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OutPutBox.Location = new System.Drawing.Point(12, 12);
            this.OutPutBox.Multiline = true;
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutPutBox.Size = new System.Drawing.Size(784, 637);
            this.OutPutBox.TabIndex = 8;
            this.OutPutBox.WordWrap = false;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 11);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(88, 23);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "▶";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OutPutTimer
            // 
            this.OutPutTimer.Enabled = true;
            this.OutPutTimer.Tick += new System.EventHandler(this.OutPutTimer_Tick);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(104, 11);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(88, 23);
            this.StopButton.TabIndex = 17;
            this.StopButton.Text = "◼";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 33;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ResumeButton
            // 
            this.ResumeButton.Location = new System.Drawing.Point(10, 40);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(88, 23);
            this.ResumeButton.TabIndex = 18;
            this.ResumeButton.Text = "▷";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 8;
            this.trackBar3.Location = new System.Drawing.Point(75, 129);
            this.trackBar3.Maximum = 16;
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(126, 45);
            this.trackBar3.TabIndex = 23;
            this.trackBar3.Value = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Этого текста не существует";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 477);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 144);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дебах панель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Этого тоже";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 26;
            this.label6.Text = "Размер\r\nсимволов";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.FontSizeBar);
            this.groupBox3.Controls.Add(this.AdvGraphicBox);
            this.groupBox3.Controls.Add(this.trackBar3);
            this.groupBox3.Controls.Add(this.BaseGraphicBox);
            this.groupBox3.Controls.Add(this.BrightnessBar);
            this.groupBox3.Controls.Add(this.DetailsBar);
            this.groupBox3.Controls.Add(this.InversionBox);
            this.groupBox3.Controls.Add(this.DetailsBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(6, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 181);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройки вывода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Размер символов при сохранении";
            // 
            // FontSizeBar
            // 
            this.FontSizeBar.Location = new System.Drawing.Point(15, 83);
            this.FontSizeBar.Maximum = 20;
            this.FontSizeBar.Minimum = 1;
            this.FontSizeBar.Name = "FontSizeBar";
            this.FontSizeBar.Size = new System.Drawing.Size(196, 45);
            this.FontSizeBar.TabIndex = 30;
            this.FontSizeBar.Value = 2;
            // 
            // AdvGraphicBox
            // 
            this.AdvGraphicBox.AutoSize = true;
            this.AdvGraphicBox.Location = new System.Drawing.Point(211, 49);
            this.AdvGraphicBox.Name = "AdvGraphicBox";
            this.AdvGraphicBox.Size = new System.Drawing.Size(59, 17);
            this.AdvGraphicBox.TabIndex = 29;
            this.AdvGraphicBox.Text = "▓▒░";
            this.AdvGraphicBox.UseVisualStyleBackColor = true;
            // 
            // BaseGraphicBox
            // 
            this.BaseGraphicBox.AutoSize = true;
            this.BaseGraphicBox.Location = new System.Drawing.Point(211, 32);
            this.BaseGraphicBox.Name = "BaseGraphicBox";
            this.BaseGraphicBox.Size = new System.Drawing.Size(47, 17);
            this.BaseGraphicBox.TabIndex = 28;
            this.BaseGraphicBox.Text = "█▓";
            this.BaseGraphicBox.UseVisualStyleBackColor = true;
            // 
            // BrightnessBar
            // 
            this.BrightnessBar.Location = new System.Drawing.Point(15, 35);
            this.BrightnessBar.Name = "BrightnessBar";
            this.BrightnessBar.Size = new System.Drawing.Size(90, 45);
            this.BrightnessBar.TabIndex = 16;
            this.BrightnessBar.Value = 5;
            this.BrightnessBar.Scroll += new System.EventHandler(this.BrightnessBar_Scroll);
            // 
            // DetailsBar
            // 
            this.DetailsBar.Location = new System.Drawing.Point(111, 35);
            this.DetailsBar.Minimum = 1;
            this.DetailsBar.Name = "DetailsBar";
            this.DetailsBar.Size = new System.Drawing.Size(90, 45);
            this.DetailsBar.TabIndex = 20;
            this.DetailsBar.Value = 5;
            this.DetailsBar.Scroll += new System.EventHandler(this.DetailsBar_Scroll);
            // 
            // InversionBox
            // 
            this.InversionBox.AutoSize = true;
            this.InversionBox.Location = new System.Drawing.Point(211, 15);
            this.InversionBox.Name = "InversionBox";
            this.InversionBox.Size = new System.Drawing.Size(76, 17);
            this.InversionBox.TabIndex = 14;
            this.InversionBox.Text = "Инверсия";
            this.InversionBox.UseVisualStyleBackColor = true;
            // 
            // DetailsBox
            // 
            this.DetailsBox.AutoSize = true;
            this.DetailsBox.Location = new System.Drawing.Point(111, 15);
            this.DetailsBox.Name = "DetailsBox";
            this.DetailsBox.Size = new System.Drawing.Size(64, 17);
            this.DetailsBox.TabIndex = 21;
            this.DetailsBox.Text = "Детали";
            this.DetailsBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Яркость";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SizeBar);
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Controls.Add(this.HeightBox);
            this.groupBox2.Controls.Add(this.SizeBox);
            this.groupBox2.Controls.Add(this.WidthBox);
            this.groupBox2.Controls.Add(this.PathBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 97);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки размеров";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(9, 45);
            this.SizeBar.Maximum = 20;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(109, 45);
            this.SizeBar.TabIndex = 30;
            this.SizeBar.Value = 20;
            this.SizeBar.Scroll += new System.EventHandler(this.SizeBar_Scroll);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(263, 71);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(26, 20);
            this.LoadButton.TabIndex = 29;
            this.LoadButton.Text = "...";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // HeightBox
            // 
            this.HeightBox.Enabled = false;
            this.HeightBox.Location = new System.Drawing.Point(227, 39);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(62, 20);
            this.HeightBox.TabIndex = 2;
            this.HeightBox.TextChanged += new System.EventHandler(this.WidthHeight_TextChanged);
            this.HeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextCheck);
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(58, 19);
            this.SizeBox.MaxLength = 3;
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(60, 20);
            this.SizeBox.TabIndex = 0;
            this.SizeBox.Text = "100";
            this.SizeBox.TextChanged += new System.EventHandler(this.SizeBox_TextChanged);
            this.SizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextCheck);
            // 
            // WidthBox
            // 
            this.WidthBox.Enabled = false;
            this.WidthBox.Location = new System.Drawing.Point(159, 39);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(62, 20);
            this.WidthBox.TabIndex = 1;
            this.WidthBox.TextChanged += new System.EventHandler(this.WidthHeight_TextChanged);
            this.WidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextCheck);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(159, 71);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(98, 20);
            this.PathBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Размер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ширина         Высота";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Файл";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(104, 40);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(88, 23);
            this.SaveButton.TabIndex = 34;
            this.SaveButton.Text = "save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(802, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(304, 637);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Меню";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 460);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResumeButton);
            this.panel1.Controls.Add(this.StopButton);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Location = new System.Drawing.Point(50, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 78);
            this.panel1.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 661);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.OutPutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ascii";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox OutPutBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer OutPutTimer;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar FontSizeBar;
        private System.Windows.Forms.CheckBox AdvGraphicBox;
        private System.Windows.Forms.CheckBox BaseGraphicBox;
        private System.Windows.Forms.TrackBar BrightnessBar;
        private System.Windows.Forms.TrackBar DetailsBar;
        private System.Windows.Forms.CheckBox InversionBox;
        private System.Windows.Forms.CheckBox DetailsBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
    }
}

