namespace HospitalClient
{
    partial class AnalyticsForm
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
            this.btn_back = new System.Windows.Forms.Button();
            this.label_avgAge = new System.Windows.Forms.Label();
            this.label_totalPatients = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(98, 175);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(114, 23);
            this.btn_back.TabIndex = 22;
            this.btn_back.Text = "Back to Main Menu";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label_avgAge
            // 
            this.label_avgAge.AutoSize = true;
            this.label_avgAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_avgAge.Location = new System.Drawing.Point(6, 51);
            this.label_avgAge.Name = "label_avgAge";
            this.label_avgAge.Size = new System.Drawing.Size(84, 13);
            this.label_avgAge.TabIndex = 24;
            this.label_avgAge.Text = "Average Age:";
            // 
            // label_totalPatients
            // 
            this.label_totalPatients.AutoSize = true;
            this.label_totalPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalPatients.Location = new System.Drawing.Point(6, 29);
            this.label_totalPatients.Name = "label_totalPatients";
            this.label_totalPatients.Size = new System.Drawing.Size(90, 13);
            this.label_totalPatients.TabIndex = 25;
            this.label_totalPatients.Text = "Total Patients:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label_totalPatients);
            this.groupBox1.Controls.Add(this.label_avgAge);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 146);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hospital Analytics";
            // 
            // AnalyticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_back);
            this.Name = "AnalyticsForm";
            this.Text = "DataForm";
            this.Load += new System.EventHandler(this.AnalyticsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label_avgAge;
        private System.Windows.Forms.Label label_totalPatients;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}