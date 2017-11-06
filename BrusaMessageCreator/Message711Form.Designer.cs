namespace BrusaMessageCreator
{
    partial class Message711Form
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
            this.cbClearError = new System.Windows.Forms.CheckBox();
            this.cbUnlockConReq = new System.Windows.Forms.CheckBox();
            this.cbVentiRq = new System.Windows.Forms.CheckBox();
            this.mtbDCVoltageMax = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboStateDem = new System.Windows.Forms.ComboBox();
            this.btnCalcMsg = new System.Windows.Forms.Button();
            this.mtbHvCurMax = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbACCurMax = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLEDState = new System.Windows.Forms.ComboBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbClearError
            // 
            this.cbClearError.AutoSize = true;
            this.cbClearError.Location = new System.Drawing.Point(13, 12);
            this.cbClearError.Name = "cbClearError";
            this.cbClearError.Size = new System.Drawing.Size(100, 17);
            this.cbClearError.TabIndex = 0;
            this.cbClearError.Text = "Clear error latch";
            this.cbClearError.UseVisualStyleBackColor = true;
            // 
            // cbUnlockConReq
            // 
            this.cbUnlockConReq.AutoSize = true;
            this.cbUnlockConReq.Location = new System.Drawing.Point(13, 36);
            this.cbUnlockConReq.Name = "cbUnlockConReq";
            this.cbUnlockConReq.Size = new System.Drawing.Size(149, 17);
            this.cbUnlockConReq.TabIndex = 1;
            this.cbUnlockConReq.Text = "Unlock connector request";
            this.cbUnlockConReq.UseVisualStyleBackColor = true;
            // 
            // cbVentiRq
            // 
            this.cbVentiRq.AutoSize = true;
            this.cbVentiRq.Location = new System.Drawing.Point(13, 60);
            this.cbVentiRq.Name = "cbVentiRq";
            this.cbVentiRq.Size = new System.Drawing.Size(170, 17);
            this.cbVentiRq.TabIndex = 2;
            this.cbVentiRq.Text = "Control pilot ventilation request";
            this.cbVentiRq.UseVisualStyleBackColor = true;
            // 
            // mtbDCVoltageMax
            // 
            this.mtbDCVoltageMax.Location = new System.Drawing.Point(13, 83);
            this.mtbDCVoltageMax.Mask = "000";
            this.mtbDCVoltageMax.Name = "mtbDCVoltageMax";
            this.mtbDCVoltageMax.Size = new System.Drawing.Size(29, 20);
            this.mtbDCVoltageMax.TabIndex = 4;
            this.mtbDCVoltageMax.Text = "400";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "(В) Maximum HV voltage 8191:SNA ";
            // 
            // comboStateDem
            // 
            this.comboStateDem.FormattingEnabled = true;
            this.comboStateDem.Items.AddRange(new object[] {
            "0:Standby",
            "1:Charge",
            "6:Sleep",
            "7:SNA"});
            this.comboStateDem.Location = new System.Drawing.Point(12, 163);
            this.comboStateDem.MaxLength = 30;
            this.comboStateDem.Name = "comboStateDem";
            this.comboStateDem.Size = new System.Drawing.Size(248, 21);
            this.comboStateDem.TabIndex = 6;
            this.comboStateDem.Text = "Select NLG_StateDem...";
            this.comboStateDem.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCalcMsg
            // 
            this.btnCalcMsg.Location = new System.Drawing.Point(12, 331);
            this.btnCalcMsg.Name = "btnCalcMsg";
            this.btnCalcMsg.Size = new System.Drawing.Size(247, 23);
            this.btnCalcMsg.TabIndex = 7;
            this.btnCalcMsg.Text = "Calculate Message";
            this.btnCalcMsg.UseVisualStyleBackColor = true;
            this.btnCalcMsg.Click += new System.EventHandler(this.btnCalcMsg_Click);
            // 
            // mtbHvCurMax
            // 
            this.mtbHvCurMax.Location = new System.Drawing.Point(13, 111);
            this.mtbHvCurMax.Mask = "00";
            this.mtbHvCurMax.Name = "mtbHvCurMax";
            this.mtbHvCurMax.Size = new System.Drawing.Size(29, 20);
            this.mtbHvCurMax.TabIndex = 4;
            this.mtbHvCurMax.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "(A) Maximum HV current 2047:SNA";
            // 
            // mtbACCurMax
            // 
            this.mtbACCurMax.Location = new System.Drawing.Point(13, 137);
            this.mtbACCurMax.Mask = "00";
            this.mtbACCurMax.Name = "mtbACCurMax";
            this.mtbACCurMax.Size = new System.Drawing.Size(29, 20);
            this.mtbACCurMax.TabIndex = 4;
            this.mtbACCurMax.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(A) Maximum AC current 2047:SNA";
            // 
            // comboLEDState
            // 
            this.comboLEDState.FormattingEnabled = true;
            this.comboLEDState.Items.AddRange(new object[] {
            "0:all LED off",
            "1:Red pulsating, 0.5Hz",
            "2:Constant Red",
            "3:Green pulsating, 0.5Hz",
            "4:Constant Green",
            "5:Yellow pulsating, 0.5Hz",
            "6:Constant Yellow",
            "7:all LED off",
            "8:Blue/White LED on only",
            "9:White, Red pulsating, 0.5Hz",
            "10:White, Constant Red",
            "11:White, Green pulsating, 0.5Hz",
            "12:White, Constant Green",
            "13:White, Yellow pulsating, 0.5Hz",
            "14:White, Constant Yellow",
            "15:Blue/White LED on only"});
            this.comboLEDState.Location = new System.Drawing.Point(12, 191);
            this.comboLEDState.Name = "comboLEDState";
            this.comboLEDState.Size = new System.Drawing.Size(248, 21);
            this.comboLEDState.TabIndex = 8;
            this.comboLEDState.Text = "Select LED states...";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(11, 293);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(248, 20);
            this.tbResult.TabIndex = 9;
            this.tbResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Message Bytes";
            // 
            // Message711Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.comboLEDState);
            this.Controls.Add(this.btnCalcMsg);
            this.Controls.Add(this.comboStateDem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtbACCurMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtbHvCurMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtbDCVoltageMax);
            this.Controls.Add(this.cbVentiRq);
            this.Controls.Add(this.cbUnlockConReq);
            this.Controls.Add(this.cbClearError);
            this.Name = "Message711Form";
            this.Text = "Message 711 (NLG_DEM_LIM) ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbClearError;
        private System.Windows.Forms.CheckBox cbUnlockConReq;
        private System.Windows.Forms.CheckBox cbVentiRq;
        private System.Windows.Forms.MaskedTextBox mtbDCVoltageMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboStateDem;
        private System.Windows.Forms.Button btnCalcMsg;
        private System.Windows.Forms.MaskedTextBox mtbHvCurMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbACCurMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboLEDState;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label4;
    }
}