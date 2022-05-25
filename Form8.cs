using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            Sql s = new Sql();
            s.Go(f);
            f.button1.Click += new EventHandler((x, y) => { Program.launch2(s); s.Go(f); });
            f.dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler((x, y) =>
            {
                if (y.ColumnIndex == 2)
                {
                    Program.launch3(s, f.dataGridView1.Rows[y.RowIndex].Cells[0].Value.ToString(), f.dataGridView1.Rows[y.RowIndex].Cells[3].Value.ToString());
                    s.Go(f);
                }
            });
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.Cancel) f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 dlg = new Form5();
            dlg.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 dlg = new Form6();
            dlg.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 dlg = new Form7();
            dlg.Show(this);
        }
    }
}
