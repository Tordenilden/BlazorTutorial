using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Model
{
    internal interface ISamurai
    {
        public void create(Samurai samurai);
        public void update(Samurai samurai);
        public void delete(int samuraiId);
        public List<Samurai> getAllSamurais();
        public Samurai getSamurai(int samuraiId);
        public Samurai getSamurai(string name);
        public Samurai getSamuraiWithHorse(int samuraiId); // Jeg vil gerne have data med om begge, hvad søren gør jeg??
        public Samurai getSamuraiWithHorse(string samuraiName);   // Jeg vil gerne have data med om begge, hvad søren gør jeg??
        public bool isLoggedin(string p, string u);
 
    }
}
