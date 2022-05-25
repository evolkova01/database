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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            button2.Click += new EventHandler((x, y) => this.Close());
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
