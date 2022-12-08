using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Model
{
    internal interface IHorse
    {
        public List<Horse> getAllHorses();
        public Horse getHorse(int horseId);
        public void create(Horse horse);
        public void update(Horse horse); // tja ved jeg egentligt hvad retur ?? og parameter
        public void delete(int horseId);
    }
}
