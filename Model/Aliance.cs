using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH1_SEM_SOKOL.Model
{
    // Třída Aliance reprezentuje alianci hráčů
    public class Aliance
    {
        // ID aliance, které může být null, pokud není přiřazeno
        public int? ID { get; set; }
        // Zkratka pro alianci, která slouží jako její název nebo identifikátor
        public string Zkratka { get; set; }
        // Seznam hráčů, kteří patří do této aliance
        public List<Hrac> Hraci { get; set; } = new List<Hrac>();
        // Vlastnost, která vrací celkovou populaci všech vesnic hráčů v alianci
        public int PopulaceAliance
        {
            get { return Hraci.SelectMany(h => h.Vesnice).Sum(v => v.Populace); }
        }

        // Konstruktor třídy Aliance, který inicializuje ID a zkratku aliance
        public Aliance(int? id, string zkratka)
        {
            ID = id;
            Zkratka = zkratka;
        }
    }
}
