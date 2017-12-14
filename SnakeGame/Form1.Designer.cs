namespace SnakeGame
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbGameScr = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.snakeTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.blueTimer = new System.Windows.Forms.Timer(this.components);
            this.greenTimer = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameScr)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameScr
            // 
            this.pbGameScr.BackColor = System.Drawing.Color.LightGray;
            this.pbGameScr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbGameScr.BackgroundImage")));
            this.pbGameScr.Location = new System.Drawing.Point(12, 12);
            this.pbGameScr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbGameScr.Name = "pbGameScr";
            this.pbGameScr.Size = new System.Drawing.Size(960, 640);
            this.pbGameScr.TabIndex = 0;
            this.pbGameScr.TabStop = false;
            this.pbGameScr.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameScr_Paint);
            // 
            // snakeTimer
            // 
            this.snakeTimer.Tick += new System.EventHandler(this.snakeTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(404, 656);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Snake by Korneliusz Barwinski";
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Tw Cen MT Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Image = ((System.Drawing.Image)(resources.GetObject("lblScore.Image")));
            this.lblScore.Location = new System.Drawing.Point(908, 12);
            this.lblScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(64, 64);
            this.lblScore.TabIndex = 3;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStart
            // 
            this.buttonStart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonStart.AutoEllipsis = true;
            this.buttonStart.CausesValidation = false;
            this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Tw Cen MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(398, 364);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(186, 62);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "GRAJ";
            this.buttonStart.UseMnemonic = false;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // blueTimer
            // 
            this.blueTimer.Interval = 5000;
            this.blueTimer.Tick += new System.EventHandler(this.blueTimer_Tick);
            // 
            // greenTimer
            // 
            this.greenTimer.Interval = 2500;
            this.greenTimer.Tick += new System.EventHandler(this.greenTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 677);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGameScr);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameScr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameScr;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer snakeTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer blueTimer;
        private System.Windows.Forms.Timer greenTimer;
        private System.Windows.Forms.Timer timer3;
    }
}

