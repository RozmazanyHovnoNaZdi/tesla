using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tesla;
using ConsoleApp;

namespace tesla
{
    internal class Továrna
    {
        Dictionary<string, string> TeslaIndustries = new Dictionary<string, string>()
        {
            {"Model 3",   " https://i.ytimg.com/vi/ArKckzLPM0M/maxresdefault.jpg" },
            {"Model S", "https://img.youtube.com/vi/RwWWiDuzvo4/hqdefault.jpg" },         
            {"Model X", "https://www.orcad.com/sites/default/files/Googel%20car.jpg" },
            {"Model Y", "https://www.drivespark.com/images/2020-11/mini-vision-urbanaut-concept-exterior-2.jpg" },
            {"cybertruck", "https://img.maxikovy-hracky.cz/Images/maxik/roblox-sada-auto-a-figurka-neighborhood-of-robloxia/238287/d1c218c3956c0fe82e9c98cfeab582-detail.jpg" }
        };

        public string Menu()
        {
            Console.WriteLine("Vítejte v továrně Tesla");
            Console.WriteLine("V nabidce máme");

            Console.WriteLine("------------------------------");

            Console.WriteLine("Model S");
            Console.WriteLine("Model 3");
            Console.WriteLine("Model X");
            Console.WriteLine("Model Y");
            Console.WriteLine("Cybertruck");

            Console.WriteLine("------------------------------");

            Console.WriteLine("1.Chci zobrazit poslední vytvořené auto");
            Console.WriteLine("2.Chci vytvořit nové auto");

            string input = Console.ReadLine();
            return input;
        }

        public Auto VytvorAuto()
        {
            Console.Clear();

            Auto vyrabeneAuto = new Auto();

            while (true)
            {
                Console.WriteLine("Zadej model : (zadejte přesný název)");


                vyrabeneAuto.Model = Console.ReadLine();
                if (this.TeslaIndustries.ContainsKey(vyrabeneAuto.Model))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tenhle model nevedeme.");
                Console.ForegroundColor = ConsoleColor.White;
            }


            while (true)
            {
                Console.WriteLine("Zadej počet sedadel");

                Console.ForegroundColor = ConsoleColor.White;

                vyrabeneAuto.PocetSedadel = Convert.ToInt32(Console.ReadLine());

                if (vyrabeneAuto.PocetSedadel >= 1 && vyrabeneAuto.PocetSedadel <= 114444444)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("To kolik si chtěl sedadel vyber si jich aspoň pod tohle číslo 114444444 ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Zadej druh pohonu");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Elektrický/Hybridní");

                vyrabeneAuto.DruhPohonu = Console.ReadLine();

                if (vyrabeneAuto.DruhPohonu == "Elektrický" || vyrabeneAuto.DruhPohonu == "Hybridní")
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mám pocit že neumíš psát");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Zadejte požadovanou Cenu:  (des. čísla = čárka");
            vyrabeneAuto.Cena = Convert.ToInt32(Console.ReadLine());

            vyrabeneAuto.Obrazek = TeslaIndustries[vyrabeneAuto.Model];

            return vyrabeneAuto;
        }


        public void VytvorStranku(Auto vyrobeneAuto)
        {
            string html = $@"
            <html>
            <body>
            <h1>Továrna na auta</h1>
            <h2 style='color:blue;'>{vyrobeneAuto.Znacka}</h2>
            <h2>{vyrobeneAuto.Model}</h2>
            <h2>Počet sedaček: {vyrobeneAuto.PocetSedadel}</h2>
            <h2>Druh pohonu: {vyrobeneAuto.DruhPohonu}</h2>
            <img  src='{vyrobeneAuto.Obrazek}'>
            <h3>Rok výroby: {vyrobeneAuto.RokVyroby}</h3>
            <hr>
            <div>
            Cena: <h4 style=' color: orange';>{vyrobeneAuto.Cena}  </h4>
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }



        public void ZobrazStranku(string adresaSouboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;

            process.FileName = adresaSouboru;
            System.Diagnostics.Process.Start(process);
        }
    }
}