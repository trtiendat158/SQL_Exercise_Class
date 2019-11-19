using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnShow.Click += BtnShow_Click;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            var runnn = new IndexClassForm();
            runnn.ShowDialog();
        }
    }
}
