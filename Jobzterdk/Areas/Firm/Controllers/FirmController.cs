﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoJZ;

namespace Jobzterdk.Areas.Firm.Controllers
{
    
    public class FirmController : Controller
    {
        AgAlderFac aaf = new AgAlderFac();
        JobtypeFac jbf = new JobtypeFac();
        ErhvervKatFac erkf = new ErhvervKatFac();
        ErhvervtypeFac ertf = new ErhvervtypeFac();
        // GET: Firm/Firm
        public ActionResult MineAnnoncer()
        {
            return View();
        }
        public ActionResult OpretAnnonce()
        {
            OpretAnnonceVm opvm = new OpretAnnonceVm();
            opvm.Alder = aaf.GetAll();
            opvm.Jobtype = jbf.GetAll();
            opvm.Erhvervkat = erkf.GetAll();
            ViewBag.MSG = TempData["opmsg"];
            return View(opvm);
        }
        [HttpPost]
        public ActionResult OpretAnnonce(int min, int max)
        {
            TempData["opmsg"] = min + "" + max;
            return RedirectToAction("OpretAnnonce");
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}