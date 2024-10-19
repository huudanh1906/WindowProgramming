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
    public partial class Cau09 : Form
    {
        public Cau09()
        {
            InitializeComponent();
        }

        private void btCong_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x + y;
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " + " + y.ToString() 
                + " = " + kq.ToString() + "\r\n";
        }
        private void btNhan_Click(object sender, EventArgs e)
        {
            int x = int.Parse(tbSoX.Text);
            int y = int.Parse(tbSoY.Text);
            int kq = x * y;
            tbKetQua.Text = tbKetQua.Text + x.ToString() + " * " + y.ToString()
                + " = " + kq.ToString() + "\r\n";
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Caculator.txt", true); 
            sw.Write(tbKetQua.Text);
            sw.Close();
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
