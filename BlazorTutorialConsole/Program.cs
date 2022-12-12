// See https://aka.ms/new-console-template for more information
using BlazorTutorialConsole.Model;
using BlazorTutorialConsole.Repositories;

namespace BlazorTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Step2 step2 = new Step2();
            Step3 step3 = new Step3();  
            List<Horse> horses = new List<Horse>();
            List<BlazorTutorialConsole.Model.Horse> horses1 = new List<BlazorTutorialConsole.Model.Horse>();
            horses = step2.getAllHorses();
            horses1 = step3.getAllHorses();
            

            foreach (var item in horses)
            {
                Console.WriteLine(item.Id + item.Name);
            }
            
            foreach (var item in horses1)
            {
                Console.WriteLine(item.Id + item.Name);
            }

            HorseRepository horseRepository = new HorseRepository();
            horseRepository.getHorse(1);

            /** INJECTIONS */
            Horse horse = new Horse() { Name = "FYrsten" };
            horseRepository.createWithInjection(horse);

        }
    }
}