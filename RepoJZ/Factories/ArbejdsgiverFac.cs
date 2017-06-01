using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace RepoJZ
{
    public class ArbejdsgiverFac: AutoFac<Arbejdsgiver>
    {
        public Arbejdsgiver Login(string email, string adgangskode)
        {
            using (var cmd = new SqlCommand("SELECT * FROM Arbejdsgiver WHERE Email=@Email AND Adgangskode=@Adgangskode", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Adgangskode", adgangskode);

                var mapper = new Mapper<Arbejdsgiver>();
                var r = cmd.ExecuteReader();
                Arbejdsgiver per = new Arbejdsgiver();

                if (r.Read())
                {
                    per = mapper.Map(r);
                }

                r.Close();
                cmd.Connection.Close();
                return per;
            }
        }
    }
}
