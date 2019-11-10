namespace ScottPlotMicrophoneFFT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer double[]iable.
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
            this.timerReplot = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.scottPlotUC2 = new ScottPlot.ScottPlotUC();
            this.scottPlotUC3 = new ScottPlot.ScottPlotUC();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scottPlotUC5 = new ScottPlot.ScottPlotUC();
            this.scottPlotUC4 = new ScottPlot.ScottPlotUC();
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.scottPlotUC6 = new ScottPlot.ScottPlotUC();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerReplot
            // 
            this.timerReplot.Interval = 2;
            this.timerReplot.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "cal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // scottPlotUC2
            // 
            this.scottPlotUC2.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC2.Location = new System.Drawing.Point(3, 226);
            this.scottPlotUC2.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC2.Name = "scottPlotUC2";
            this.scottPlotUC2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.scottPlotUC2.Size = new System.Drawing.Size(1336, 241);
            this.scottPlotUC2.TabIndex = 1;
            // 
            // scottPlotUC3
            // 
            this.scottPlotUC3.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC3.Location = new System.Drawing.Point(3, 3);
            this.scottPlotUC3.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC3.Name = "scottPlotUC3";
            this.scottPlotUC3.Size = new System.Drawing.Size(1336, 223);
            this.scottPlotUC3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(255, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(486, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Auto scale";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1350, 740);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.scottPlotUC5);
            this.tabPage2.Controls.Add(this.scottPlotUC4);
            this.tabPage2.Controls.Add(this.scottPlotUC1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1342, 714);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "A(j)-B(j) normal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // scottPlotUC5
            // 
            this.scottPlotUC5.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC5.Location = new System.Drawing.Point(3, 505);
            this.scottPlotUC5.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC5.Name = "scottPlotUC5";
            this.scottPlotUC5.Size = new System.Drawing.Size(1336, 247);
            this.scottPlotUC5.TabIndex = 3;
            // 
            // scottPlotUC4
            // 
            this.scottPlotUC4.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC4.Location = new System.Drawing.Point(3, 258);
            this.scottPlotUC4.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC4.Name = "scottPlotUC4";
            this.scottPlotUC4.Size = new System.Drawing.Size(1336, 247);
            this.scottPlotUC4.TabIndex = 2;
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC1.Location = new System.Drawing.Point(3, 3);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.scottPlotUC1.Size = new System.Drawing.Size(1336, 255);
            this.scottPlotUC1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scottPlotUC6);
            this.tabPage1.Controls.Add(this.scottPlotUC2);
            this.tabPage1.Controls.Add(this.scottPlotUC3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1342, 714);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "A(j)-B(j) gauss";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scottPlotUC6
            // 
            this.scottPlotUC6.Dock = System.Windows.Forms.DockStyle.Top;
            this.scottPlotUC6.Location = new System.Drawing.Point(3, 467);
            this.scottPlotUC6.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC6.Name = "scottPlotUC6";
            this.scottPlotUC6.Size = new System.Drawing.Size(1336, 247);
            this.scottPlotUC6.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1367, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScottPlot Microphone FFT Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerReplot;
        private System.Windows.Forms.Button button1;
        private ScottPlot.ScottPlotUC scottPlotUC2;
        private ScottPlot.ScottPlotUC scottPlotUC3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private ScottPlot.ScottPlotUC scottPlotUC1;
        private ScottPlot.ScottPlotUC scottPlotUC4;
        private ScottPlot.ScottPlotUC scottPlotUC5;
        private ScottPlot.ScottPlotUC scottPlotUC6;
    }
}

