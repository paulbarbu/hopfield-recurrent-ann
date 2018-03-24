namespace hopfield_barbu
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
            this.printArraysBtn = new System.Windows.Forms.Button();
            this.storePatternBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hopfieldDetailsBtn = new System.Windows.Forms.Button();
            this.recallPatternBtn = new System.Windows.Forms.Button();
            this.resetSrcGrid = new System.Windows.Forms.Button();
            this.resetNetworkBtn = new System.Windows.Forms.Button();
            this.recallStatusLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printArraysBtn
            // 
            this.printArraysBtn.Location = new System.Drawing.Point(124, 4);
            this.printArraysBtn.Name = "printArraysBtn";
            this.printArraysBtn.Size = new System.Drawing.Size(75, 23);
            this.printArraysBtn.TabIndex = 0;
            this.printArraysBtn.Text = "Print Grids";
            this.printArraysBtn.UseVisualStyleBackColor = true;
            this.printArraysBtn.Click += new System.EventHandler(this.printArraysBtn_Click);
            // 
            // storePatternBtn
            // 
            this.storePatternBtn.Location = new System.Drawing.Point(12, 38);
            this.storePatternBtn.Name = "storePatternBtn";
            this.storePatternBtn.Size = new System.Drawing.Size(97, 23);
            this.storePatternBtn.TabIndex = 1;
            this.storePatternBtn.Text = "Store Pattern";
            this.storePatternBtn.UseVisualStyleBackColor = true;
            this.storePatternBtn.Click += new System.EventHandler(this.storePatternBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gray button   = -1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Black button = +1";
            // 
            // hopfieldDetailsBtn
            // 
            this.hopfieldDetailsBtn.Location = new System.Drawing.Point(205, 4);
            this.hopfieldDetailsBtn.Name = "hopfieldDetailsBtn";
            this.hopfieldDetailsBtn.Size = new System.Drawing.Size(119, 23);
            this.hopfieldDetailsBtn.TabIndex = 3;
            this.hopfieldDetailsBtn.Text = "Print Hopfield details";
            this.hopfieldDetailsBtn.UseVisualStyleBackColor = true;
            this.hopfieldDetailsBtn.Click += new System.EventHandler(this.hopfieldDetailsBtn_Click);
            // 
            // recallPatternBtn
            // 
            this.recallPatternBtn.Location = new System.Drawing.Point(696, 37);
            this.recallPatternBtn.Name = "recallPatternBtn";
            this.recallPatternBtn.Size = new System.Drawing.Size(108, 23);
            this.recallPatternBtn.TabIndex = 4;
            this.recallPatternBtn.Text = "Recall Pattern";
            this.recallPatternBtn.UseVisualStyleBackColor = true;
            this.recallPatternBtn.Click += new System.EventHandler(this.recallPatternBtn_Click);
            // 
            // resetSrcGrid
            // 
            this.resetSrcGrid.Location = new System.Drawing.Point(115, 38);
            this.resetSrcGrid.Name = "resetSrcGrid";
            this.resetSrcGrid.Size = new System.Drawing.Size(75, 23);
            this.resetSrcGrid.TabIndex = 5;
            this.resetSrcGrid.Text = "Reset Grid";
            this.resetSrcGrid.UseVisualStyleBackColor = true;
            this.resetSrcGrid.Click += new System.EventHandler(this.resetSrcGrid_Click);
            // 
            // resetNetworkBtn
            // 
            this.resetNetworkBtn.Location = new System.Drawing.Point(330, 4);
            this.resetNetworkBtn.Name = "resetNetworkBtn";
            this.resetNetworkBtn.Size = new System.Drawing.Size(99, 23);
            this.resetNetworkBtn.TabIndex = 6;
            this.resetNetworkBtn.Text = "Reset Network";
            this.resetNetworkBtn.UseVisualStyleBackColor = true;
            this.resetNetworkBtn.Click += new System.EventHandler(this.resetNetworkBtn_Click);
            // 
            // recallStatusLbl
            // 
            this.recallStatusLbl.AutoSize = true;
            this.recallStatusLbl.Location = new System.Drawing.Point(696, 13);
            this.recallStatusLbl.Name = "recallStatusLbl";
            this.recallStatusLbl.Size = new System.Drawing.Size(35, 13);
            this.recallStatusLbl.TabIndex = 7;
            this.recallStatusLbl.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Click or hold X && hover to set a cell";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.recallStatusLbl);
            this.Controls.Add(this.resetNetworkBtn);
            this.Controls.Add(this.resetSrcGrid);
            this.Controls.Add(this.recallPatternBtn);
            this.Controls.Add(this.hopfieldDetailsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.storePatternBtn);
            this.Controls.Add(this.printArraysBtn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printArraysBtn;
        private System.Windows.Forms.Button storePatternBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hopfieldDetailsBtn;
        private System.Windows.Forms.Button recallPatternBtn;
        private System.Windows.Forms.Button resetSrcGrid;
        private System.Windows.Forms.Button resetNetworkBtn;
        private System.Windows.Forms.Label recallStatusLbl;
        private System.Windows.Forms.Label label3;
    }
}

