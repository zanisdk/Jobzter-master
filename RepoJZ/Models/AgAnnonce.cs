using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class AgAnnonce
    {
        public int ID { get; set; }
        public int AgID { get; set; }
        public string LBeskrivelse { get; set; }
        public int ErhvervtypeID { get; set; }
        public DateTime Dato { get; set; }
        public int Timer { get; set; }
        public int AlderID { get; set; }
        public int AgTidID { get; set; }
        public string Overskrift { get; set; }
        public int JobtypeID { get; set; }
    }
}
