namespace ToolUpdateInvoice
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
            this.txPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txNewDomain = new System.Windows.Forms.TextBox();
            this.txNewDataBase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txPath
            // 
            this.txPath.Location = new System.Drawing.Point(79, 42);
            this.txPath.Name = "txPath";
            this.txPath.Size = new System.Drawing.Size(204, 20);
            this.txPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "StartUpdate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txNewDomain
            // 
            this.txNewDomain.Location = new System.Drawing.Point(79, 78);
            this.txNewDomain.Name = "txNewDomain";
            this.txNewDomain.Size = new System.Drawing.Size(204, 20);
            this.txNewDomain.TabIndex = 2;
            // 
            // txNewDataBase
            // 
            this.txNewDataBase.Location = new System.Drawing.Point(79, 113);
            this.txNewDataBase.Name = "txNewDataBase";
            this.txNewDataBase.Size = new System.Drawing.Size(204, 20);
            this.txNewDataBase.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 196);
            this.Controls.Add(this.txNewDataBase);
            this.Controls.Add(this.txNewDomain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txNewDomain;
        private System.Windows.Forms.TextBox txNewDataBase;
    }
}

