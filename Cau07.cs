using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01
{

    public partial class Cau07 : Form
    {
        public Cau07()
        {
            InitializeComponent();
        }
        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            int year = int.Parse(tbYear.Text);
            if (year > 2000)
                e.Cancel = true;
        }
    }
    
}

