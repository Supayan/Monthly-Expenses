namespace Monthly_Expense
{
    partial class Homepage
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_mem = new System.Windows.Forms.Button();
            this.btn_exp = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aft Expense Report";
            // 
            // btn_mem
            // 
            this.btn_mem.Location = new System.Drawing.Point(344, 142);
            this.btn_mem.Name = "btn_mem";
            this.btn_mem.Size = new System.Drawing.Size(229, 83);
            this.btn_mem.TabIndex = 1;
            this.btn_mem.Text = "Member Entry";
            this.btn_mem.UseVisualStyleBackColor = true;
            this.btn_mem.Click += new System.EventHandler(this.btn_mem_Click);
            // 
            // btn_exp
            // 
            this.btn_exp.Location = new System.Drawing.Point(344, 308);
            this.btn_exp.Name = "btn_exp";
            this.btn_exp.Size = new System.Drawing.Size(229, 77);
            this.btn_exp.TabIndex = 2;
            this.btn_exp.Text = "Expense Entry";
            this.btn_exp.UseVisualStyleBackColor = true;
            this.btn_exp.Click += new System.EventHandler(this.btn_exp_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(344, 475);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(229, 65);
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "Exit";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 588);
            this.ControlBox = false;
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_exp);
            this.Controls.Add(this.btn_mem);
            this.Controls.Add(this.label1);
            this.Name = "Homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_mem;
        private System.Windows.Forms.Button btn_exp;
        private System.Windows.Forms.Button btn_close;
    }
}