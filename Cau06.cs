﻿using System;
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
    public partial class Cau06 : Form
    {
        public Cau06()
        {
            InitializeComponent();
        }
        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";
            this.Size = new Size(500,500);
        }

    }
}
