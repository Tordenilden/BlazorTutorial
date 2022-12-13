using BlazorTutorialConsole.DataModel;
using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole;
/// <summary>
/// Entity Framework
/// 1) install packages
/// microsoft.entityframeworkcore.sqlserver
/// microsoft.entityframeworkcore.tools
/// microsoft.entityframeworkcore
/// 2) create class context :DbContext
/// 2.1) DbSet<ModelName>
/// 2.1) ex: DbSet<Horse> Horse //DML på en database server
/// 2.2) connection string to database etc...
/// 2.3) REALLY IMPORT TO THIS!!! BUILD YOUR PROJECT
/// 3) Define all classes and then add-migration name in console
/// 3.1) update-datebase in console
/// 4) class => metode => ex: readHorse(int Id) , her skal der være context i denne class
/// 5) We talk about 3 ways to use EF
///    code first (all models defined and then migrate)
///    database first (sql script => then generate all classes in c#)
///    design (drag and drop) forget it, I dont want to speak about it.
/// </summary>
public class HorseRepositoryEF
{
    DatabaseContext context;
    public HorseRepositoryEF(DatabaseContext context)
    {
        this.context = context;
    }

    // i want to query on the id to the database
    // should I return it?
    //var horse = context.TabelNavn.LinQMetode(Lambda expression);
    //1) query
    //2) Linq expression
    //3) Execute the query -tolist(), foreach 
    public Horse readHorse(int id)
    {
        var horse = context.Horse.Where(x => x.Id == id).FirstOrDefault();
        var horse1 = context.Horse.Where((horse) => horse.Id == id); // 1 eller flere
        Horse horse2 = context.Horse.FirstOrDefault((horse) => horse.Id == id);
        //foreach (var horse in context.Horse.ToList())
        //{
        //    if(horse.Id == id)
        //}
        return horse2;
    }
    public List<Horse> readAllHorses()
    {
        return context.Horse.ToList();
    }
}
