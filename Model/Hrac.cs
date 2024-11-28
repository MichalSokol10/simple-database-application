using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH1_SEM_SOKOL.Model
{
    // Třída Hrac reprezentuje jednotlivého hráče ve hře
    public class Hrac
    {
        // ID hráče, které je unikátní pro každého hráče
        public int ID { get; set; }
        // Jméno hráče
        public string Jmeno { get; set; }
        // Národ hráče
        public Narod Narod { get; set; }
        // Seznam vesnic, které hráč vlastní
        public List<Vesnice> Vesnice { get; set; } = new List<Vesnice>();
        // Aliance, do které hráč patří
        public Aliance? Aliance { get; set; }
        // Vlastnost, která vrací celkovou populaci všech vesnic hráče
        public int CelkovaPopulace
        {
            get { return Vesnice.Sum(v => v.Populace); }
        }

        // Konstruktor pro vytvoření nového hráče s přiřazeným ID, jménem a národem
        public Hrac(int id, string jmeno, Narod narod)
        {
            ID = id;
            Jmeno = jmeno;
            Narod = narod;
        }
    }
}
