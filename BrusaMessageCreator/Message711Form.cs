using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrusaMessageCreator
{
    public partial class Message711Form : Form
    {
        CANMessage711 message711 = new CANMessage711();
        public Message711Form()
        {
            InitializeComponent();
            //mtbDCVoltageMax.Text = "400";
            comboStateDem.SelectedIndex = 0;
            comboLEDState.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboStateDem.SelectedText = comboStateDem.;
        }

        private void btnCalcMsg_Click(object sender, EventArgs e)
        {
            string[] param = new string[13];
            param[0] = cbClearError.Checked ? "1" : "0";    //("NLG_C_ClrError", 0, 0, 1);
            param[1] = cbUnlockConReq.Checked ? "1" : "0";  //("NLG_C_UnlockConRq", 0, 1, 1);
            param[2] = cbVentiRq.Checked ? "1" : "0";       //("NLG_C_VentiRq", 0, 2, 1);
            param[3] = mtbDCVoltageMax.Text; //("NLG_DcHvVoltLimMax", 0, 3, 13);
            param[4] = Convert.ToString(comboStateDem.SelectedIndex);//("NLG_StateDem", 0, 16, 3);
            param[5] = "0"; //("NOT_USED", 0, 19, 2); // NOT USED
            param[6] = mtbHvCurMax.Text;    // ("NLG_DcHvCurrLimMax", 0, 21, 11);
            param[7] = Convert.ToString(comboLEDState.SelectedIndex); //("NLG_LedDem", 0, 32, 4);
            param[8] = "0"; //("NOT_USED", 0, 36, 1); // NOT USED
            param[9] = mtbACCurMax.Text;    //("NLG_AcCurrLimMax", 0, 37, 11);
            param[10] = "0"; //("NOT_USED", 0, 48, 3); // NOT USED
            param[11] = "0"; //("NLG_C_EnPhaseShift", 0, 51, 1);
            param[12] = "0"; //("NLG_AcPhaseShift", 0, 52, 12);

            message711.Create(param);
            tbResult.Text = message711.ToString();
        }
    }
}
