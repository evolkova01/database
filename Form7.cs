using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace form1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            string connectionString =
                "Data Source=127.0.0.1;Initial Catalog=db22207;Persist Security Info=True;User ID=User082;Password=User082**34";
            InitializeComponent();

            using (var conn = new SqlConnection(connectionString))
            {
                DataTable table = new DataTable();
                string command = "SELECT txtAccountNumber FROM tblAccount";

                using (var cmd = new SqlCommand(command, conn))
                {
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapt.Fill(table);
                    conn.Close();
                }

                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "txtAccountNumber";
                comboBox1.ValueMember = "txtAccountNumber";
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db22207DataSet.DataTable3". При необходимости она может быть перемещена или удалена.
            this.DataTable3TableAdapter.Fill(this.db22207DataSet.DataTable3, comboBox1.Text);

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataTable3TableAdapter.Fill(this.db22207DataSet.DataTable3, comboBox1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
