using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Repositories
{
    internal class Step2 : IExample
    {
        /// <summary>
        /// Returns hardcoded data
        /// </summary>
        public List<Horse> getAllHorses()
        {
            List<Horse> result = new List<Horse>();
            result.Add(new Horse { Id = 10, Name = "Black Lightning"}); //initializer
            result.Add(new Horse { Id = 20, Name = "Black Spot" });
            result.Add(new Horse { Id = 30, Name = "Phantom" });
            return result;
        }
    }
}
