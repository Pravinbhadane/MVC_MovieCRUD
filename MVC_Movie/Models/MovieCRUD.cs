using System.Data.SqlClient;

namespace MVC_Movie.Models
{
    public class MovieCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public MovieCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> list = new List<Movie>();
            string qry = "select * from Movie where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Movie b = new Movie();
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Mname = dr["Mname"].ToString();
                    b.ReleaseDate = dr["ReleaseDate"].ToString();
                    b.Genre = dr["Genre"].ToString();
                    b.StarCast = dr["StarCast"].ToString();
               
                    list.Add(b);
                }
            }
            con.Close();
            return list;
        }
        public Movie GetMovieById(int id)
        {
            Movie b = new Movie();
            string qry = "select * from Movie where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    b.Id = Convert.ToInt32(dr["Id"]);
                    b.Mname = dr["Mname"].ToString();
                    b.ReleaseDate = dr["ReleaseDate"].ToString();
                    b.Genre = dr["Genre"].ToString();
                    b.StarCast = dr["StarCast"].ToString();
                }
            }
            con.Close();
            return b;
        }
        public int AddMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "insert into Movie values(@Mname,@ReleaseDate,@Genre,@StarCast,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarCast", movie.StarCast );
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateMovieDetails(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "update Movie set Mname=@Mname,ReleaseDate=@ReleaseDate,Genre=@Genre,StarCast=@StarCast,isActive=@isActive where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarCast", movie.StarCast);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            cmd.Parameters.AddWithValue("@Id", movie.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteMovie(int id)
        {
            int result = 0;
            string qry = "update Movie set isActive=0 where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
