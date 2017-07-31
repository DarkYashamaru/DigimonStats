using DigimonStats.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigimonStats.Models
{
    public static class LoadDataFromCVS
    {
        public static HttpServerUtilityBase Server;
        public static DigimonHandler DigimonHandler = new DigimonHandler();

        public static void Init (String file)
        {
            if(DigimonHandler.AllDigimons.Count==0)
            {
                using (StringReader sr = new StringReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        Digimon d = FromCVS(values);
                        DigimonHandler.AllDigimons.Add(d);
                    }
                }
            }
        }

        public static Digimon GetById (int id)
        {
            Digimon result = DigimonHandler.AllDigimons.Find(x => x.Id == id);
            return result;
        }

        public static List<Digimon> GetByTier(DigimonTier tier)
        {
            List<Digimon> result = new List<Digimon>();
            Debug.WriteLine(String.Format("Searching in {0} Digimons", DigimonHandler.AllDigimons.Count));
            foreach(Digimon d in DigimonHandler.AllDigimons)
            {
                if(d.Tier == tier)
                {
                    result.Add(d);
                }
            }
            return result;
        }

        public static Digimon FromCVS(String[] values)
        {
            Digimon digimon = new Digimon();
            try
            {
                digimon.Id = int.Parse(values[0]);
                digimon.Name = values[1];
                digimon.Rank = values[2];
                digimon.HP = int.Parse(values[3]);
                digimon.SP = int.Parse(values[4]);
                digimon.Atk = int.Parse(values[5]);
                digimon.Int = int.Parse(values[6]);
                digimon.Def = int.Parse(values[7]);
                digimon.Spd = int.Parse(values[8]);
                for(int i = 9; i < values.Length; i++)
                {
                    if(i>9)
                    {
                        digimon.Skill += ",";
                    }
                    digimon.Skill += values[i];
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return digimon;
        }

        public static Digimon GetByName(string name)
        {
            foreach(Digimon d in DigimonHandler.AllDigimons)
            {
                if(d.Name.Equals(name))
                {
                    return d;
                }
                if(d.Name.Contains(name))
                {
                    return d;
                }
            }
            return null;
        }
    }
}