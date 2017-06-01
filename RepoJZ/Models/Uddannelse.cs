using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class Uddannelse
    {
        public int ID { get; set; }
        public int CVID { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public int UdtypeID { get; set; }
        public bool Afsluttet { get; set; }
    }
}
