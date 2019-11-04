using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09Travel
{
    class Database
    {
        const string CONN_STRING = "Data Source=DESKTOP-19066HG;Initial Catalog=Travels;Integrated Security=True";

        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        public List<Travel> GetAllPeople()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Travel2", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Travel> result = new List<Travel>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];                    
                        string destination = (string)reader["Destination"];
                        string name = (string)reader["Name"];
                        string passportNo = (string)reader["PassportNO"];
                        DateTime departure = (DateTime)reader["Departure"];
                        DateTime returnDate = (DateTime)reader["ReturnDate"];

                        string methodOfTravelStr = (string)reader["MethodOfTravel"];
                        Travel.TravelEnum methodOfTravel;
                        if (!Enum.TryParse<Travel.TravelEnum>(methodOfTravelStr, out methodOfTravel))
                        {
                            throw new InvalidCastException("Enum value invalid: " + methodOfTravelStr);
                        }

                        Travel t = new Travel( destination, name , passportNo , departure , returnDate,  methodOfTravel );
                        t.Id = id;
                        result.Add(t);
                    }
                    return result;
                }
            }
        }
        public void AddTraveller(Travel t)
        {
            using (SqlCommand insertCommand = new SqlCommand(
              "INSERT INTO Travel2 (Destination, Name , PassportNO , Departure , ReturnDate , MethodOfTravel )  VALUES" + "(@Destination, @TravellerName , @TravellerPassport , @DepartureDate , @ReturnDate , @MethodOfTravel ) ", conn))
            {
                insertCommand.Parameters.AddWithValue("@Destination", t.Destination);
                insertCommand.Parameters.AddWithValue("@TravellerName", t.TravellerName);
                insertCommand.Parameters.AddWithValue("@TravellerPassport", t.TravellerPassport);
                insertCommand.Parameters.AddWithValue("@DepartureDate", t.DepartureDate.ToString("MM-dd-yyyy"));
                insertCommand.Parameters.AddWithValue("@ReturnDate", t.ReturnDate.ToString("MM-dd-yyyy"));
                insertCommand.Parameters.AddWithValue("@MethodOfTravel", t.MethodOfTravel.ToString());
                insertCommand.ExecuteNonQuery();
            }

        }
       
    }
}
