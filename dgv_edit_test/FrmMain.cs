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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //「SelectedRows.Count」は選択された行の数を返します
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //「SelectedRows[0].Cells[1]」は重要な部分です! 0, 1 ,2 ,3...

                
                //"(string)dataGridView1.SelectedRows[0].Cells[1].Value"
                //は最初に選択された列から2番目のセルを取得します。2つ目の値は
                //「Name」という名前で「String」型であることがわかっているので「String」にキャストします。
                txtEdit.Text = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
            }
        }
    }
}
