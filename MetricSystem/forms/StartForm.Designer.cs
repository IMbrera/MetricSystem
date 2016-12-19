namespace MetricSystem
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.circular = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // circular
            // 
            this.circular.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("circular.AnimationFunction")));
            this.circular.AnimationSpeed = 500;
            this.circular.BackColor = System.Drawing.SystemColors.InfoText;
            this.circular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circular.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.circular.ForeColor = System.Drawing.Color.Red;
            this.circular.InnerColor = System.Drawing.Color.DarkSlateGray;
            this.circular.InnerMargin = 8;
            this.circular.InnerWidth = -1;
            this.circular.Location = new System.Drawing.Point(0, 0);
            this.circular.MarqueeAnimationSpeed = 2000;
            this.circular.Name = "circular";
            this.circular.OuterColor = System.Drawing.Color.Black;
            this.circular.OuterMargin = -25;
            this.circular.OuterWidth = 26;
            this.circular.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.circular.ProgressWidth = 25;
            this.circular.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circular.Size = new System.Drawing.Size(284, 261);
            this.circular.StartAngle = 270;
            this.circular.Step = 1;
            this.circular.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circular.SubscriptColor = System.Drawing.Color.Red;
            this.circular.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circular.SubscriptText = "";
            this.circular.SuperscriptColor = System.Drawing.Color.Red;
            this.circular.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circular.SuperscriptText = "";
            this.circular.TabIndex = 1;
            this.circular.Text = "Загрузка...";
            this.circular.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circular.UseWaitCursor = true;
            this.circular.Value = 99;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.circular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar circular;
        private System.Windows.Forms.Timer timer1;
    }
}