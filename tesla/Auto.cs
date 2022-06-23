using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Auto
    {
        public string Znacka = "Tesla";
        public int RokVyroby = DateTime.Now.Year;
        public string Model { get; set; }
        public int PocetSedadel { get; set; }
        public string DruhPohonu { get; set; }
        public int Cena { get; set; }
        public string Obrazek { get; set; }
    }
}
