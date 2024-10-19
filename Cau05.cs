using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01
{
    public partial class Cau05 : Form
    {
        public Cau05()
        {
            InitializeComponent();
        }

        private void Cau05_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Key_Logger.txt", true);
            sw.Write(e.KeyCode);
            sw.Close();
        }
    }
}
