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
    public partial class IndexClassForm : Form
    {
        private ClassManagement Business;

        public IndexClassForm()
        {
            InitializeComponent();
            grdClass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Business = new ClassManagement();
            this.Load += IndexClassForm_Load;
            this.btnAdd.Click += BtnAdd_Click; this.btnDelete.Click += BtnDelete_Click;
            this.grdClass.DoubleClick += GrdClass_DoubleClick;
        }
        private void LoadAllClasses()
        {
            var classes = this.Business.GetClass();
            this.grdClass.DataSource = classes;
        }
        private void GrdClass_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdClass.SelectedRows.Count == 1)
            {
                var @class = (Class)this.grdClass.SelectedRows[0].DataBoundItem;
                var updateForm = new UpdateClassForm(@class.Id);
                updateForm.ShowDialog();
                this.LoadAllClasses();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //var db2 = new OOPCSEntities();
            //db2.Classes.Remove(db2.Classes.Find(int.Parse(grdClass.SelectedRows[0].Cells[0].Value.ToString())));
            //db2.SaveChanges();
            //db2.Dispose();
            //MessageBox.Show("Delete sucessfully");
            //this.LoadAllClasses();
            if (this.grdClass.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you rant to delete this ?",
                    "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var cclass = (Class)this.grdClass.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteClass(cclass.Id);
                    MessageBox.Show("Delete class sucessfully");
                    this.LoadAllClasses();
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var newAdd = new CreateClassForm();
            newAdd.ShowDialog();
            this.LoadAllClasses();
        }

        private void IndexClassForm_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }
    }
}
