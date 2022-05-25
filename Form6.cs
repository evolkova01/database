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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db22207DataSet.DataTable2". При необходимости она может быть перемещена или удалена.
            this.DataTable2TableAdapter.Fill(this.db22207DataSet.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
