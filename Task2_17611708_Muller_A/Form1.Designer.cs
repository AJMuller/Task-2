namespace Task2_17611708_Muller_A
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
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labTime = new System.Windows.Forms.Label();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(78, 27);
            this.mapBox.Margin = new System.Windows.Forms.Padding(4);
            this.mapBox.Name = "mapBox";
            this.mapBox.Padding = new System.Windows.Forms.Padding(4);
            this.mapBox.Size = new System.Drawing.Size(854, 745);
            this.mapBox.TabIndex = 1;
            this.mapBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(1020, 69);
            this.labTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(0, 17);
            this.labTime.TabIndex = 8;
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(1020, 69);
            this.butStop.Margin = new System.Windows.Forms.Padding(4);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(100, 28);
            this.butStop.TabIndex = 7;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click_1);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(1020, 37);
            this.butStart.Margin = new System.Windows.Forms.Padding(4);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(100, 28);
            this.butStart.TabIndex = 6;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click_1);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(1020, 105);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(132, 62);
            this.txtDisplay.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1020, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1020, 265);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 793);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.mapBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

