using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSH1_SEM_SOKOL.Model
{
    // Třída reprezentující vesnici v rámci hry
    public class Vesnice
    {
        // Unikátní identifikátor vesnice
        public int ID { get; set; }
        // Souřadnice X vesnice na herní mapě
        public int X { get; set; }
        // Souřadnice Y vesnice na herní mapě
        public int Y { get; set; }
        // Název vesnice
        public string Jmeno { get; set; }
        // Hráč, který je vlastníkem této vesnice
        public Hrac Vlastnik { get; set; }
        // Počet obyvatel vesnice
        public int Populace { get; set; }

        // Konstruktor pro vytvoření nové vesnice
        public Vesnice(int id, int x, int y, string jmeno, Hrac vlastnik, int populace)
        {
            ID = id;
            X = x;
            Y = y;
            Jmeno = jmeno;
            Vlastnik = vlastnik;
            Populace = populace;
        }
    }
}
