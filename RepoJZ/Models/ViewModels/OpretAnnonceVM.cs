using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class OpretAnnonceVm
    {
        public List<ErhvervKat> Erhvervkat { get; set; }
        public List<AgAlder> Alder { get; set; }
        public List<Jobtype> Jobtype { get; set; }
    }
}
