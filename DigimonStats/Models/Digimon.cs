using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigimonStats.Models
{
    public class Digimon
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Rank { get; set; }
        public int HP { get; set; }
        public int SP { get; set; }
        public int Atk { get; set; }
        public int Int { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public String Skill { get; set; }


        public int TotalStats
        {
            get
            {
                int hp = HP > 0 ? (HP / 10) : 0;
                return hp + SP + Atk + Int + Def + Spd;
            }
        }

        public DigimonTier Tier
        {
            get
            {
                if (TotalStats > 1234)
                {
                    return DigimonTier.MegaTier8;
                }
                if (TotalStats > 1215)
                {
                    return DigimonTier.MegaTier7;
                }
                if (TotalStats > 1204)
                {
                    return DigimonTier.MegaTier6;
                }
                if (TotalStats > 1189)
                {
                    return DigimonTier.MegaTier5;
                }
                if (TotalStats > 1163)
                {
                    return DigimonTier.MegaTier4;
                }
                if (TotalStats > 1152)
                {
                    return DigimonTier.MegaTier3;
                }
                if (TotalStats > 1134)
                {
                    return DigimonTier.MegaTier2;
                }
                if (TotalStats > 1124)
                {
                    return DigimonTier.MegaTier1;
                }
                return DigimonTier.None;
            }
        }
    }

    public class DigimonHandler
    {
        public List<Digimon> AllDigimons = new List<Digimon>();
    }

    public enum DigimonTier
    {
        None = 0,
        MegaTier1 = 1,
        MegaTier2 = 2,
        MegaTier3 = 3,
        MegaTier4 = 4,
        MegaTier5 = 5,
        MegaTier6 = 6,
        MegaTier7 = 7,
        MegaTier8 = 8,
    }
}