using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form1
{
    public class Sql
    {
        public SqlConnection myConnection;
        public Sql()
        {
            string connectString =
                "Data Source=127.0.0.1;Initial Catalog=db22207;Persist Security Info=True;User ID=User082;Password=User082**34";
            myConnection = new SqlConnection(connectString);
            myConnection.Open();
        }
        public void Go(Form1 f)
        {
            f.dataGridView1.Rows.Clear();
            string query = "Select txtClientSurname, txtClientName, txtClientSecondName, txtAccountTypeName, datAccountBegin, txtAccountNumber, tblClient.intClientId, tblAccount.intAccountId" +
                "   from tblAccountType, tblAccount, tblClient" +
                "       where (tblAccount.intAccountTypeId = tblAccountType.intAccountTypeId) " +
                " and (tblAccount.intClientId = tblClient.intClientId)";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] str = new string[6];
                str[0] = reader[0].ToString().Replace(" ", "") + " " +
                    reader[1].ToString().Replace(" ", "") + " " + reader[2].ToString().Replace(" ", "");
                str[1] = reader[3].ToString();
                str[2] = reader[4].ToString();
                str[3] = reader[5].ToString();
                str[4] = reader[6].ToString();
                str[5] = reader[7].ToString();
                f.dataGridView1.Rows.Add(str);
            }
            reader.Close();
        }
    }
}
