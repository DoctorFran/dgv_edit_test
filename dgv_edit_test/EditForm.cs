using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dgv_edit_test
{
    public partial class EditForm : Form
    {
        public EditForm(int ID, string Name, DateTime Date)
        {
            InitializeComponent();

            txtID.Text = ID.ToString();
            txtName.Text = Name;
            txtDate.Value = Date;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
