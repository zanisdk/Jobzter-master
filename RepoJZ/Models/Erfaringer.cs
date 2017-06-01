using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class Erfaringer
    {
        public int ID { get; set; }
        public int CVID { get; set; }
        public int ErhvervtypeID { get; set; }
        public string Firmanavn { get; set; }
        public string Stilling { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }

    }
}
