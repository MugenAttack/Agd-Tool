namespace agdDecryptor
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
            this.toXml = new System.Windows.Forms.Button();
            this.toAgd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toXml
            // 
            this.toXml.Location = new System.Drawing.Point(8, 12);
            this.toXml.Name = "toXml";
            this.toXml.Size = new System.Drawing.Size(141, 53);
            this.toXml.TabIndex = 0;
            this.toXml.Text = "agd to xml";
            this.toXml.UseVisualStyleBackColor = true;
            this.toXml.Click += new System.EventHandler(this.toXml_Click);
            // 
            // toAgd
            // 
            this.toAgd.Location = new System.Drawing.Point(155, 12);
            this.toAgd.Name = "toAgd";
            this.toAgd.Size = new System.Drawing.Size(141, 53);
            this.toAgd.TabIndex = 1;
            this.toAgd.Text = "xml to agd";
            this.toAgd.UseVisualStyleBackColor = true;
            this.toAgd.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 74);
            this.Controls.Add(this.toAgd);
            this.Controls.Add(this.toXml);
            this.Name = "Form1";
            this.Text = "Avatar Growth Data XML Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toXml;
        private System.Windows.Forms.Button toAgd;
    }
}

