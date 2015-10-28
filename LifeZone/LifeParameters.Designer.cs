namespace LifeZone
{
    partial class LifeParameters
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaxMoving = new System.Windows.Forms.Label();
            this.MinMoving = new System.Windows.Forms.Label();
            this.MaxRotate = new System.Windows.Forms.Label();
            this.MinRotate = new System.Windows.Forms.Label();
            this.AverageSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AverageRotateSpeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(13, 735);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 56);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.DragOver += new System.Windows.Forms.DragEventHandler(this.trackBar1_DragOver);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 748);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Refresh speed";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.MaxMoving);
            this.groupBox1.Controls.Add(this.MinMoving);
            this.groupBox1.Controls.Add(this.MaxRotate);
            this.groupBox1.Controls.Add(this.MinRotate);
            this.groupBox1.Controls.Add(this.AverageSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AverageRotateSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 631);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 98);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Max/Min/Average";
            // 
            // MaxMoving
            // 
            this.MaxMoving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxMoving.AutoSize = true;
            this.MaxMoving.Location = new System.Drawing.Point(413, 28);
            this.MaxMoving.Name = "MaxMoving";
            this.MaxMoving.Size = new System.Drawing.Size(16, 17);
            this.MaxMoving.TabIndex = 13;
            this.MaxMoving.Text = "0";
            // 
            // MinMoving
            // 
            this.MinMoving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MinMoving.AutoSize = true;
            this.MinMoving.Location = new System.Drawing.Point(413, 45);
            this.MinMoving.Name = "MinMoving";
            this.MinMoving.Size = new System.Drawing.Size(16, 17);
            this.MinMoving.TabIndex = 12;
            this.MinMoving.Text = "0";
            // 
            // MaxRotate
            // 
            this.MaxRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxRotate.AutoSize = true;
            this.MaxRotate.Location = new System.Drawing.Point(126, 28);
            this.MaxRotate.Name = "MaxRotate";
            this.MaxRotate.Size = new System.Drawing.Size(16, 17);
            this.MaxRotate.TabIndex = 11;
            this.MaxRotate.Text = "0";
            // 
            // MinRotate
            // 
            this.MinRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MinRotate.AutoSize = true;
            this.MinRotate.Location = new System.Drawing.Point(126, 45);
            this.MinRotate.Name = "MinRotate";
            this.MinRotate.Size = new System.Drawing.Size(16, 17);
            this.MinRotate.TabIndex = 10;
            this.MinRotate.Text = "0";
            // 
            // AverageSpeed
            // 
            this.AverageSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AverageSpeed.AutoSize = true;
            this.AverageSpeed.Location = new System.Drawing.Point(413, 62);
            this.AverageSpeed.Name = "AverageSpeed";
            this.AverageSpeed.Size = new System.Drawing.Size(16, 17);
            this.AverageSpeed.TabIndex = 9;
            this.AverageSpeed.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Moving speed: ";
            // 
            // AverageRotateSpeed
            // 
            this.AverageRotateSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AverageRotateSpeed.AutoSize = true;
            this.AverageRotateSpeed.Location = new System.Drawing.Point(126, 62);
            this.AverageRotateSpeed.Name = "AverageRotateSpeed";
            this.AverageRotateSpeed.Size = new System.Drawing.Size(16, 17);
            this.AverageRotateSpeed.TabIndex = 7;
            this.AverageRotateSpeed.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rotate speed: ";
            // 
            // LifeParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(563, 803);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(-100, -100);
            this.Name = "LifeParameters";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "LifeParameters";
            this.Load += new System.EventHandler(this.LifeParameters_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LifeParameters_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label AverageSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AverageRotateSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MaxMoving;
        private System.Windows.Forms.Label MinMoving;
        private System.Windows.Forms.Label MaxRotate;
        private System.Windows.Forms.Label MinRotate;

    }
}