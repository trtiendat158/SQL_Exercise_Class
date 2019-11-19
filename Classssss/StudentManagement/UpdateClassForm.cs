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
    public partial class UpdateClassForm : Form
    {
        private ClassManagement Business;
        private int ClassId;
        public UpdateClassForm(int id)
        {
            InitializeComponent();
            this.ClassId = id;
            this.Business = new ClassManagement();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.Load += UpdateClassForm_Load;
        }

        private void UpdateClassForm_Load(object sender, EventArgs e)
        {
            var oldclass = this.Business.GetClass(this.ClassId);
            this.txtClassName.Text = oldclass.Name;
            this.txtDescription.Text = oldclass.Description;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtClassName.Text;
            var description = this.txtDescription.Text;
            this.Business.EditClass(this.ClassId, name, description);
        }
    }
}
