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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMessage711_Click(object sender, EventArgs e)
        {
            Message711Form m711 = new Message711Form();

            m711.ShowDialog();
        }
    }
}
