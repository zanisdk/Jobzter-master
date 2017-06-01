using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoJZ
{
    public class Bruger
    {
        public int ID { get; set; }
        public string Pb { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public int Postnr { get; set; }
        public string Sted { get; set; }
        public string Vejnavn { get; set; }
        public DateTime Fodselsdag { get; set; }
        public Boolean Kon { get; set; }
        public string Tlf { get; set; }
        public Boolean Aktiv { get; set; }
        public string Adgangskode { get; set; }
        public DateTime Dato { get; set; }
    }
}
