using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace RepoJZ
{
    public class BrugerFac: AutoFac<Bruger>
    {
        public Bruger Login(string email, string adgangskode)
        {
            using (var cmd = new SqlCommand("SELECT * FROM Bruger WHERE Email=@Email AND Adgangskode=@Adgangskode", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Adgangskode", Crypto.Hash(adgangskode));

                var mapper = new Mapper<Bruger>();
                var r = cmd.ExecuteReader();
                Bruger per = new Bruger();

                if (r.Read())
                {
                    per = mapper.Map(r);
                }

                r.Close();
                cmd.Connection.Close();
                return per;
            }
        }

        public void UpdateAdgangskode(string email, string adgangskode)
        {
            using (var CMD = new SqlCommand("update Bruger set Adgangskode=@adgangskode where Email=@email", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@adgangskode", adgangskode);
                CMD.Parameters.AddWithValue("@email", email);

                CMD.ExecuteNonQuery();
                CMD.Connection.Close();
            }
        }

        public bool UserExist(string email)
        {
            if (GetBy("Email", email).Count > 0) //GetBy(Feltet, Værdi) Count tæller hvor mange rækker der er i listen.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
