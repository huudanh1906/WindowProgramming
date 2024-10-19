namespace Ex01
{

    partial class Cau06
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
        private System.Windows.Forms.Button bt_OK;
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.SuspendLayout(); // Pause layout changes

            this.bt_OK = new System.Windows.Forms.Button();
            this.bt_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_OK.Location = new System.Drawing.Point(100, 200); // Ensure it's within visible range
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(80, 25);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "OK";
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            this.Controls.Add(this.bt_OK); // Add the button to the form

            this.Name = "Cau06";
            this.Text = "Cau06";

            this.ResumeLayout(false); // Apply layout changes
        }

    }
    #endregion
}