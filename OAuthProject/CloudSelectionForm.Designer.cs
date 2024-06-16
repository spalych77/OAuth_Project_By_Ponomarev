namespace OAuthProject
{
    partial class CloudSelectionForm
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
            this.yandexBtn = new System.Windows.Forms.Button();
            this.googleBtn = new System.Windows.Forms.Button();
            this.bybitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yandexBtn
            // 
            this.yandexBtn.Location = new System.Drawing.Point(298, 126);
            this.yandexBtn.Name = "yandexBtn";
            this.yandexBtn.Size = new System.Drawing.Size(200, 100);
            this.yandexBtn.TabIndex = 0;
            this.yandexBtn.Text = "Yandex";
            this.yandexBtn.UseVisualStyleBackColor = true;
            // 
            // googleBtn
            // 
            this.googleBtn.Location = new System.Drawing.Point(298, 232);
            this.googleBtn.Name = "googleBtn";
            this.googleBtn.Size = new System.Drawing.Size(200, 100);
            this.googleBtn.TabIndex = 1;
            this.googleBtn.Text = "Google";
            this.googleBtn.UseVisualStyleBackColor = true;
            // 
            // bybitBtn
            // 
            this.bybitBtn.Location = new System.Drawing.Point(298, 338);
            this.bybitBtn.Name = "bybitBtn";
            this.bybitBtn.Size = new System.Drawing.Size(200, 100);
            this.bybitBtn.TabIndex = 2;
            this.bybitBtn.Text = "Bybit";
            this.bybitBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(301, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose an option";
            // 
            // CloudSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bybitBtn);
            this.Controls.Add(this.googleBtn);
            this.Controls.Add(this.yandexBtn);
            this.Name = "CloudSelectionForm";
            this.Text = "CloudSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yandexBtn;
        private System.Windows.Forms.Button googleBtn;
        private System.Windows.Forms.Button bybitBtn;
        private System.Windows.Forms.Label label1;
    }
}