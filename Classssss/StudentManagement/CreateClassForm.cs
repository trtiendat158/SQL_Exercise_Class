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
    public partial class CreateClassForm : Form
    {
        private ClassManagement Business;
        public CreateClassForm()
        {
            InitializeComponent();
            this.Business = new ClassManagement();    
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;  
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtClassName.Text;
            var description = this.txtDescription.Text;
            this.Business.AddClass(name, description);
            MessageBox.Show("Add Sucessfully");
            this.Dispose();
        }
    }
}
