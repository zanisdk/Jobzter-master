using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Security;
using RepoJZ;

namespace Jobzterdk.Controllers
{
    public class AppController : ApiController
    {
        BrugerFac brF = new BrugerFac();
        ErhvervtypeFac ertF = new ErhvervtypeFac();
        ErhvervKatFac erkF = new ErhvervKatFac();
        JobtypeFac joF = new JobtypeFac();
        UdtypeFac udtF = new UdtypeFac();
        UdkatFac udkF = new UdkatFac();
        SprogFac spF = new SprogFac();


        Mail m = new Mail("smtp.gmail.com", "webitsven1106@gmail.com", "webitsven1106", "tw5mc7z8vc", 587); //ændre til Jobzter Email

        [Route("api/App/Login/{email}/{adgangskode}")]
        [HttpGet]
        public Bruger Login(string email, string adgangskode)
        {
            Bruger b = brF.Login(email, adgangskode);

            return b;
        }

        [Route("api/App/GlemtAdg/{email}")]
        [HttpPost]
        public string GlemtAdg(string email)
        {
            if (brF.UserExist(email))
            {
                Uploader uploader = new Uploader();
                string nyAdgangskode = uploader.GenRnd(8);

                brF.UpdateAdgangskode(email, Crypto.Hash(nyAdgangskode)); //Crypto.Hash()

                m.Send("Ny adgangskode", nyAdgangskode, email);

                return "Du vil om kort tid modtage en mail med en ny adgangskode!";

            }
            else
            {
               return "Brugeren findes ikke";
            }
        }

        [Route("api/App/GetUdkat/")]
        [HttpGet]
        public IEnumerable<UdtypeVM> GetUdkat()
        {

            List<UdtypeVM> list = new List<UdtypeVM>();
            foreach(var t in udkF.GetAll())
            {
                UdtypeVM udVM = new UdtypeVM();
                udVM.Udkat = udkF.Get(t.ID);
                udVM.Udtype = udtF.GetBy("UdkatID", t.ID);
                udVM.Count = udtF.Countid(t.ID);
                list.Add(udVM);
            }
            
            return (IEnumerable<UdtypeVM>)list; 
        }


        [Route("api/App/GetErhverv/")]
        [HttpGet]
        public IEnumerable<ErhvervKatVM> GetErhverv()
        {

            List<ErhvervKatVM> list = new List<ErhvervKatVM>();
            foreach (var t in erkF.GetAll())
            {
                ErhvervKatVM erVM = new ErhvervKatVM();
                erVM.ErhvervKat = erkF.Get(t.ID);
                erVM.Erhvervtype = ertF.GetBy("ErKatID", t.ID);

                list.Add(erVM);
            }

            return (IEnumerable<ErhvervKatVM>)list;
        }




        [Route("api/App/GetSprog")]
        [HttpGet]
        public IEnumerable<Sprog> GetSprog()
        {
            return spF.GetAll();
        }


        [Route("api/App/GetJobtype")]
        [HttpGet]
        public IEnumerable<Jobtype> GetJobtype()
        {
            return joF.GetAll();
        }






        [Route("api/App/GetErfKat")]
        [HttpGet]
        public IEnumerable<ErhvervKat> GetErfKat()
        {
            return erkF.GetAll();
        }

        [Route("api/App/GetErfType/{id}")]
        [HttpGet]
        public IEnumerable<Erhvervtype> GetErfType(int id)
        {

            return ertF.GetBy("ErKatID", id);
        }

    }
}
