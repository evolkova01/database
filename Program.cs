using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{ 
    public static class Program
    {  
        static public void launch2(Sql s)
        {
            var frm2 = new Form2();
            string jkl = "Select txtClientSurname, intClientId, txtClientName " +
                "From tblClient";
            var c = new SqlCommand(jkl, s.myConnection);
            var t = c.ExecuteReader();
            var v = new List<string>();
            while(t.Read())
            {                
                frm2.comboBox1.Items.Add(t[0].ToString()+t[2].ToString());
                v.Add(t[1].ToString());
            }
            t.Close();

            frm2.button1.Click += new EventHandler((x, y) =>
            {
                 try
                {
                    string query =
                    "Insert into tblAccount(intClientId, intAccountTypeId, datAccountBegin, datAccountEnd, txtAccountNumber, fltAccountSum)" +
                    "values (" + v[frm2.comboBox1.SelectedIndex] + ", " + frm2.comboBox2.SelectedIndex + ", \'" + frm2.textBox2.Text + "\', \'" +
                    frm2.textBox3.Text + "\', " + frm2.textBox4.Text + ", " + frm2.textBox5.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, s.myConnection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
                frm2.Close();
            });
            DialogResult dr = frm2.ShowDialog();
            if (dr == DialogResult.Cancel) frm2.Close();                        
        }
        static public void launch4(Sql s, string id, string vid)
        {
            var frm2 = new Form4();

            string q = "Select txtClientSurname, txtClientName, txtClientSecondName, txtAccountNumber, txtAccountTypeName " +
                "From tblClient, tblAccount, tblAccountType " +
                "Where (tblClient.intClientId = " +  id + ") and (tblAccount.intAccountId = " + vid + ") and (tblAccount.intAccountTypeId = tblAccountType.intAccountTypeId)";
            SqlCommand c = new SqlCommand(q, s.myConnection);
            var r = c.ExecuteReader();
            while (r.Read())
            {
                frm2.label9.Text = r[0].ToString().Replace(" ", "") + " " + r[1].ToString().Replace(" ", "") + " " + r[2].ToString().Replace(" ", "");
                frm2.label10.Text = r[3].ToString();
                frm2.label11.Text = r[4].ToString();               
            }
            r.Close();
            frm2.button1.Click += new EventHandler((x, y) =>
            {
                string sel = "Select intOperationTypeId " +
                "From tblOperationType " +
                "Where txtOperationTypeName = \'" + frm2.comboBox1.Text + "\'";
                SqlCommand ss = new SqlCommand(sel, s.myConnection);               
                var rr = ss.ExecuteReader();
                rr.Read();
                string ins = "Insert into tblOperation(intOperationTypeId, intAccountId, fltValue, datOperation) " +
                "values (" + frm2.comboBox1.SelectedIndex + ", " + vid + ", " + frm2.textBox2.Text + ", \'" + frm2.monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd") + "\')";
                rr.Close();
                try
                {
                    SqlCommand cmd = new SqlCommand(ins, s.myConnection);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
                frm2.Close();
            });
            DialogResult dr = frm2.ShowDialog();
            if (dr == DialogResult.Cancel) frm2.Close();
        }
        static public void launch3(Sql s, string id, string vid)
        {
            var frm2 = new Form3();
            frm2.button1.Click += new EventHandler((x, y) =>
            {
                launch4(s, id, vid);
                frm2.Close();
            });
            string q = "Select txtClientSurname, txtClientName, txtClientSecondName, datBirthday, txtClientAddress, datAccountBegin, datAccountEnd, txtAccountNumber, fltAccountSum " +
                "From tblClient, tblAccount " +
                "Where (tblClient.intClientId = " + id + ") and (tblAccount.intAccountId = " + vid + ")";
            SqlCommand c = new SqlCommand(q, s.myConnection);
            var r = c.ExecuteReader();
            while(r.Read())
            {
                frm2.label8.Text = r[0].ToString().Replace(" ", "") + " " + r[1].ToString().Replace(" ", "") + " " + r[2].ToString().Replace(" ", "");
                frm2.label9.Text = r[3].ToString();
                frm2.label10.Text = r[4].ToString();
                frm2.label11.Text = r[5].ToString() + " - " + r[6].ToString();
                frm2.label12.Text = r[7].ToString();
                frm2.label13.Text = r[8].ToString();
            }
            r.Close();
            ///////////////////////
            string query = "SELECT datOperation, txtOperationTypeName, fltValue " +
                "FROM tblOperation, tblOperationType " +
                "WHERE (tblOperationType.intOperationTypeId = tblOperation.intOperationTypeId) " +
                "and (intAccountId = " + vid + ")";
            SqlCommand cmd = new SqlCommand(query, s.myConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] str = new string[3];
                for(int i = 0; i < 3; i++)
                    str[i] = reader[i].ToString();
                frm2.dataGridView1.Rows.Add(str);
            }
            reader.Close();
            DialogResult dr = frm2.ShowDialog();
            if (dr == DialogResult.Cancel) frm2.Close();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form8());
        }
    }
}
