using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class UdtypeFac: AutoFac<Udtype>
    {
        public int Countid(int id)
        {
            using (var cmd = new SqlCommand("SELECT COUNT(ID) as antal FROM Udtype WHERE UdkatID = " + id + " ", Conn.CreateConnection()))
            {
                int counter = 0;
                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    counter = int.Parse(r["antal"].ToString());
                }

                r.Close();
                cmd.Connection.Close();
                return counter;
            }
        }
    }
}
