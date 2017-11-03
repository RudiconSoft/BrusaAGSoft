namespace BrusaMessageCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMessage711 = new System.Windows.Forms.Button();
            this.btnMessage728 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMessage711
            // 
            this.btnMessage711.Location = new System.Drawing.Point(13, 62);
            this.btnMessage711.Name = "btnMessage711";
            this.btnMessage711.Size = new System.Drawing.Size(386, 23);
            this.btnMessage711.TabIndex = 0;
            this.btnMessage711.Text = "Message #711 (NLG_DEM_LIM)";
            this.btnMessage711.UseVisualStyleBackColor = true;
            this.btnMessage711.Click += new System.EventHandler(this.btnMessage711_Click);
            // 
            // btnMessage728
            // 
            this.btnMessage728.Location = new System.Drawing.Point(12, 160);
            this.btnMessage728.Name = "btnMessage728";
            this.btnMessage728.Size = new System.Drawing.Size(386, 23);
            this.btnMessage728.TabIndex = 1;
            this.btnMessage728.Text = "Message #728 (NLG_ACT_LIM)";
            this.btnMessage728.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 547);
            this.Controls.Add(this.btnMessage728);
            this.Controls.Add(this.btnMessage711);
            this.Name = "MainForm";
            this.Text = "BRUSA NLG 6xxx Message Coder/Encoder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMessage711;
        private System.Windows.Forms.Button btnMessage728;
    }
}

