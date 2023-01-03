using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Repositories
{
    public class HorseRepository : IHorse
    {
        public void create(Horse horse)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"Insert into horse (age,name,samuraiId) " +
                $"values ({horse.Age},'{horse.Name}',{horse.SamuraiId})",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void createHardcoded()
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand("Insert into horse values ('beauty')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// 1) Minimum 1 Insert
        /// 2) Minimum 2 Select
        /// 3) Hvordan var det nu vi beskyttede os mod dem? Er der mere end en mulighed??
        /// </summary>
        /// <param name="horse"></param>
        public void createWithInjection(Horse horse)
        {
            string horsename = "'); truncate table test; --";
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"Insert into horse (age, samuraiId, name) values (1, 1,'{horsename}' )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void createWithInjectionVer2(Horse horse)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"Insert into horse (age, samuraiId, name) " +
                $"values (1, 1,'{horse.Name}' )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void createAvoid(Horse horse)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"Insert into horse values (@age, @name, @id)", con);
            cmd.Parameters.AddWithValue("@age", horse.Age);
            cmd.Parameters.AddWithValue("@name", horse.Name+"'");
            cmd.Parameters.AddWithValue("@id", horse.SamuraiId); // foreign key
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int horseId)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"delete from horse where id = {horseId}",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Horse> getAllHorses()
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from horse",con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Horse> horses = new List<Horse>();
            while (reader.Read())
            {
                Horse horse = new Horse();
                horse.Name = reader["Name"].ToString();
                horse.Id = Convert.ToInt32(reader["Id"]);
                horse.Age = Convert.ToInt32(reader["Age"]);
                horse.SamuraiId = Convert.ToInt32(reader["SamuraiId"]);
                horses.Add(horse);
            }
            con.Close();
            return horses;
        }

        public Horse getHorse(int horseid)
        {
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"select * from horse where id = {horseid}",con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Horse horse = new Horse();
                horse.Name = reader["Name"].ToString();
                horse.Id = Convert.ToInt32(reader["Id"]);
                con.Close();
                return horse;
            }
            con.Close();
            return new Horse(); // snakke med palle om det...
        }

        public void update(Horse horse)
        {
            Horse temp = getHorse(horse.Id);
            if (temp == null) return;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            SqlCommand cmd = new SqlCommand($"update horse set Name = '{horse.Name}' where Id= {horse.Id}",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
