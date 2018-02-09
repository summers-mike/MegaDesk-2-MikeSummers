namespace MegaDesk_4_MikeSummers
{
    partial class SearchQuotes
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
            this.CancelSearchQuotes = new System.Windows.Forms.Button();
            this.ViewQuoteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.materialSelector = new System.Windows.Forms.ComboBox();
            this.readText = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CancelSearchQuotes
            // 
            this.CancelSearchQuotes.Location = new System.Drawing.Point(249, 226);
            this.CancelSearchQuotes.Name = "CancelSearchQuotes";
            this.CancelSearchQuotes.Size = new System.Drawing.Size(75, 23);
            this.CancelSearchQuotes.TabIndex = 0;
            this.CancelSearchQuotes.Text = "Close";
            this.CancelSearchQuotes.UseVisualStyleBackColor = true;
            this.CancelSearchQuotes.Click += new System.EventHandler(this.CancelSearchQuotes_Click);
            // 
            // ViewQuoteButton
            // 
            this.ViewQuoteButton.Location = new System.Drawing.Point(249, 73);
            this.ViewQuoteButton.Name = "ViewQuoteButton";
            this.ViewQuoteButton.Size = new System.Drawing.Size(75, 23);
            this.ViewQuoteButton.TabIndex = 1;
            this.ViewQuoteButton.Text = "View Quotes";
            this.ViewQuoteButton.UseVisualStyleBackColor = true;
            this.ViewQuoteButton.Click += new System.EventHandler(this.ViewQuoteButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find all quotes with specified material:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // materialSelector
            // 
            this.materialSelector.FormattingEnabled = true;
            this.materialSelector.Items.AddRange(new object[] {
            "Oak",
            "Laminate",
            "Pine",
            "Rosewood",
            "Veneer"});
            this.materialSelector.Location = new System.Drawing.Point(220, 46);
            this.materialSelector.Name = "materialSelector";
            this.materialSelector.Size = new System.Drawing.Size(121, 21);
            this.materialSelector.TabIndex = 4;
            // 
            // readText
            // 
            this.readText.FormattingEnabled = true;
            this.readText.Location = new System.Drawing.Point(12, 125);
            this.readText.Name = "readText";
            this.readText.Size = new System.Drawing.Size(542, 95);
            this.readText.TabIndex = 5;
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 261);
            this.Controls.Add(this.readText);
            this.Controls.Add(this.materialSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ViewQuoteButton);
            this.Controls.Add(this.CancelSearchQuotes);
            this.Name = "SearchQuotes";
            this.Text = "SearchQuotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelSearchQuotes;
        private System.Windows.Forms.Button ViewQuoteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox materialSelector;
        private System.Windows.Forms.ListBox readText;
    }
}