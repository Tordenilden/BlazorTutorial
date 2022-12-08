using BlazorTutorialConsole.Model;
using System.Data.SqlClient;


namespace BlazorTutorialConsole.Repositories
{
    /// <summary>
    /// Returns data from the database
    /// </summary>
    internal class Step3 : IExample
    {
        public List<Horse> getAllHorses()
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from horse", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Horse> horses = new List<Horse>();
            while (reader.Read())
            {
                Horse horse = new Horse();
                horse.Name = reader["Name"].ToString();
                horse.Id = Convert.ToInt32(reader["Id"]);
                horses.Add(horse);
            }
            return horses;
        }
    }
}
