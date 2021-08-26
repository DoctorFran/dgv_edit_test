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
    public partial class FrmMain : Form
    {
        private BindingList<SampleObject> _data;
        public FrmMain()
        {
            InitializeComponent();
            _data = new BindingList<SampleObject>();
            load_datagrid();
        }

        private void load_datagrid()
        {
            for(int i = 1; i <= 100; i++)
            {
                SampleObject so = new SampleObject
                {
                    ID = i,
                    Name = string.Format("Sample no. {0}", i),
                    Date = DateTime.Now.AddDays(i)  
                };
                _data.Add(so);
            }
            dataGridView1.DataSource = _data;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            form_resize();
        }

        private void form_resize()
        {
            dataGridView1.Top = pnlTop.Bottom;
            dataGridView1.Height = ClientSize.Height - pnlTop.Height;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Left = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //SampleObject: 0 - ID(int),  1 - Name(string), 2 - Date(DateTime)
                //DataGridView1.SelectedRows[0] - currently selected row
                //.Cells[x] = Cells[0] = ID, Cells[1] = Name = Cells[2] = Date
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string name = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
                DateTime date = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                EditForm edf = new EditForm(id, name, date);
                edf.ShowDialog();
            }
        }
    }
}
