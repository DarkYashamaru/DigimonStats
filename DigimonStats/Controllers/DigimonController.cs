using DigimonStats.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigimonStats.Controllers
{
    public class DigimonController : Controller
    {
        // GET: Digimon
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                id = 0;
            }
            Digimon digimon = GetById(id.Value);
            if(digimon!=null)
            {
                return View(digimon);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult Tier(int? id)
        {
            InitLoadData();
            if (!id.HasValue)
            {
                id = 0;
            }
            DigimonTier selectedTier = (DigimonTier)id.Value;
            DigimonHandler dh = new DigimonHandler();
            dh.AllDigimons = LoadDataFromCVS.GetByTier(selectedTier);
            Debug.WriteLine(String.Format("Result {0} Digimons in tier {1}", dh.AllDigimons.Count, selectedTier.ToString()));
            return View(dh);
        }

        [HttpPost]
        public ActionResult Find (String name)
        {

            Digimon digimon = GetByName(name);
            if (digimon != null)
            {
                return View("Index", digimon);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public Digimon GetById(int id)
        {
            InitLoadData();
            return LoadDataFromCVS.GetById(id);
        }

        public Digimon GetByName(String name)
        {
            InitLoadData();
            return LoadDataFromCVS.GetByName(name);
        }

        public void InitLoadData ()
        {
            string path = Server.MapPath("~/Data/DigimonData.csv");
            string data = System.IO.File.ReadAllText(path);
            LoadDataFromCVS.Init(data);
        }
    }
}