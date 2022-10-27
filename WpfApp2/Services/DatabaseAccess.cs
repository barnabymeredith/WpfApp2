using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.Services
{
    public class DatabaseAccess
    {
        private string connectionString;
        private ObservableCollection<Player> _PlayersList;

        public DatabaseAccess()
        {
            connectionString = Properties.Settings.Default.connection_String;
        }

        public void UpdatePlayer(int ID, string FirstName, string LastName, string Club, string Nationality, string Position)
        {
            string queryString = $"UPDATE Players SET FirstName = \'{FirstName}\', LastName = \'{LastName}\', Club = \'{Club}\', Nationality = \'{Nationality}\', Position = \'{Position}\' WHERE ID = {ID};";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public ObservableCollection<Player> CreatePlayer()
        {
            string queryString = $"INSERT INTO Players (FirstName, LastName, Club, Nationality, Position) VALUES (\'\', \'\', \'\', \'\', \'\');";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return ReadPlayers();
        }

        public ObservableCollection<Player> ReadPlayers()
        {
            _PlayersList = new ObservableCollection<Player>();

            string queryString = "SELECT * FROM Players;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryString, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        Player p = new Player();
                        // To avoid unexpected bugs access columns by name.
                        p.PlayerId = reader.GetInt32(reader.GetOrdinal("Id"));
                        p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        p.Club = reader.GetString(reader.GetOrdinal("Club"));
                        p.Nationality = reader.GetString(reader.GetOrdinal("Nationality"));
                        p.Position = reader.GetString(reader.GetOrdinal("Position"));
                        _PlayersList.Add(p);
                    }
                }

                conn.Close();
                return _PlayersList;
            }
        }
    }
}
