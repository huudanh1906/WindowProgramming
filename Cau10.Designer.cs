namespace Ex01
{
    partial class Cau10
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
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.bt0 = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.btPlus = new System.Windows.Forms.Button();
            this.btMul = new System.Windows.Forms.Button();
            this.btDecimal = new System.Windows.Forms.Button();
            this.btEquals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(12, 13);
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(274, 22);
            this.tbDisplay.TabIndex = 0;
            // 
            // bt0
            // 
            this.bt0.Location = new System.Drawing.Point(12, 55);
            this.bt0.Name = "bt0";
            this.bt0.Size = new System.Drawing.Size(58, 57);
            this.bt0.TabIndex = 1;
            this.bt0.Text = "0";
            this.bt0.UseVisualStyleBackColor = true;
            this.bt0.Click += new System.EventHandler(this.bt0_Click);
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(85, 55);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(58, 57);
            this.bt1.TabIndex = 2;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bt2
            // 
            this.bt2.Location = new System.Drawing.Point(161, 55);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(58, 57);
            this.bt2.TabIndex = 3;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.Location = new System.Drawing.Point(228, 55);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(58, 57);
            this.bt3.TabIndex = 4;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // btPlus
            // 
            this.btPlus.Location = new System.Drawing.Point(12, 127);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(58, 57);
            this.btPlus.TabIndex = 5;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = true;
            this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
            // 
            // btMul
            // 
            this.btMul.Location = new System.Drawing.Point(85, 127);
            this.btMul.Name = "btMul";
            this.btMul.Size = new System.Drawing.Size(58, 57);
            this.btMul.TabIndex = 6;
            this.btMul.Text = "*";
            this.btMul.UseVisualStyleBackColor = true;
            this.btMul.Click += new System.EventHandler(this.btMul_Click);
            // 
            // btDecimal
            // 
            this.btDecimal.Location = new System.Drawing.Point(161, 127);
            this.btDecimal.Name = "btDecimal";
            this.btDecimal.Size = new System.Drawing.Size(58, 57);
            this.btDecimal.TabIndex = 7;
            this.btDecimal.Text = ".";
            this.btDecimal.UseVisualStyleBackColor = true;
            this.btDecimal.Click += new System.EventHandler(this.btDecimal_Click);
            // 
            // btEquals
            // 
            this.btEquals.Location = new System.Drawing.Point(228, 127);
            this.btEquals.Name = "btEquals";
            this.btEquals.Size = new System.Drawing.Size(58, 57);
            this.btEquals.TabIndex = 8;
            this.btEquals.Text = "=";
            this.btEquals.UseVisualStyleBackColor = true;
            this.btEquals.Click += new System.EventHandler(this.btEquals_Click);
            // 
            // Cau10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 196);
            this.Controls.Add(this.btEquals);
            this.Controls.Add(this.btDecimal);
            this.Controls.Add(this.btMul);
            this.Controls.Add(this.btPlus);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.bt0);
            this.Controls.Add(this.tbDisplay);
            this.Name = "Cau10";
            this.Text = "Cau10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button bt0;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button btPlus;
        private System.Windows.Forms.Button btMul;
        private System.Windows.Forms.Button btDecimal;
        private System.Windows.Forms.Button btEquals;
    }
}