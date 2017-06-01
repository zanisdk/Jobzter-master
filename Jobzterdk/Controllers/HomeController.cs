using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoJZ;
using System.Web.Helpers;
using System.Web.UI.WebControls.WebParts;

namespace Jobzterdk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BrugerFac brF = new BrugerFac();
        ErhvervtypeFac ertF = new ErhvervtypeFac();
        ErhvervKatFac erkF = new ErhvervKatFac();
        UdtypeFac udtF = new UdtypeFac();
        UdkatFac udkF = new UdkatFac();
        ArbejdsgiverFac argf = new ArbejdsgiverFac();



        public ActionResult Index()
        {
            ViewBag.MSG = TempData["login"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(string brugernavn, string adgangskode)
        {
            if (argf.Login(brugernavn, adgangskode).Email != null)
            {
                TempData["login"] = "Du er nu logget på";
                return Redirect("/Firm/Firm/MineAnnoncer/");
            }
            else
            {
                TempData["login"] = "brugeren findes ikke";
                return RedirectToAction("Index");
            }






        }


        public ActionResult GetUdkat()
        {

            List<UdtypeVM> list = new List<UdtypeVM>();
            foreach (var t in udkF.GetAll())
            {
                UdtypeVM udVM = new UdtypeVM();
                udVM.Udkat = udkF.Get(t.ID);
                udVM.Udtype = udtF.GetBy("UdkatID", t.ID);
                udVM.Count = udtF.Countid(t.ID);
                list.Add(udVM);
            }

            return View(list);
        }

        public ActionResult MereOmApp()
        {
            return View();
        }
        public ActionResult MereOmVirk()
        {
            return View();
        }

        public ActionResult OpretVirk()
        {

            ViewBag.MSG = TempData["MSG"];
            return View(erkF.GetAll());
        }
        [HttpPost]
        public ActionResult OpretVirk(HttpPostedFileBase img, int post, int erkatid, string firma, string cvr, string sted, string vej, string kontakt, string tlf, string hjemmeside, string email, string adgangskode, string kode)
        {
            if (img != null)
            {
                if (adgangskode == kode)
                {
                    int w = 500;
                    Uploader up = new Uploader();
                    Arbejdsgiver a = new Arbejdsgiver();
                    string path = Request.PhysicalApplicationPath + "Content/imgtest/";
                    string fil = up.UploadImage(img, path, w, true);
                    a.FirmaB = Path.GetFileName(fil);
                    a.Firmanavn = firma;
                    a.CVR = cvr;
                    a.KontaktPerson = kontakt;
                    a.Email = email;
                    a.Adgangskode = adgangskode;
                    a.Tlf = tlf;
                    a.Postnr = post;
                    a.Sted = sted;
                    a.Vejnavn = vej;
                    a.Hjemmeside = hjemmeside;
                    a.ErKatID = erkatid;
                    int id = argf.Insert(a);
                    TempData["MSG"] = "Din virkesomhed er nu oprette";
                }
                else
                {
                    TempData["MSG"] = "Adgangskode er ikke enes";
                }
            }
            else
            {
                TempData["MSG"] = "Vælge et logo";
            }


            return RedirectToAction("MineAnnoncer", "Firm", new { area = "Firm" });
        }

    }

}
