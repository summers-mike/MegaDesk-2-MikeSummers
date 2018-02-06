namespace MegaDesk_4_MikeSummers
{
    partial class ViewAllQuotes
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
            this.CancelViewAllQuotes = new System.Windows.Forms.Button();
            this.showAllQuotes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CancelViewAllQuotes
            // 
            this.CancelViewAllQuotes.Location = new System.Drawing.Point(232, 226);
            this.CancelViewAllQuotes.Name = "CancelViewAllQuotes";
            this.CancelViewAllQuotes.Size = new System.Drawing.Size(75, 23);
            this.CancelViewAllQuotes.TabIndex = 0;
            this.CancelViewAllQuotes.Text = "Close";
            this.CancelViewAllQuotes.UseVisualStyleBackColor = true;
            this.CancelViewAllQuotes.Click += new System.EventHandler(this.CancelViewAllQuotes_Click);
            // 
            // showAllQuotes
            // 
            this.showAllQuotes.FormattingEnabled = true;
            this.showAllQuotes.Location = new System.Drawing.Point(12, 12);
            this.showAllQuotes.Name = "showAllQuotes";
            this.showAllQuotes.Size = new System.Drawing.Size(520, 199);
            this.showAllQuotes.TabIndex = 1;
            // 
            // ViewAllQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 261);
            this.Controls.Add(this.showAllQuotes);
            this.Controls.Add(this.CancelViewAllQuotes);
            this.Name = "ViewAllQuotes";
            this.Text = "ViewAllQuotes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelViewAllQuotes;
        private System.Windows.Forms.ListBox showAllQuotes;
    }
}