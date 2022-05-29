using Microsoft.AspNetCore.Mvc;
using Movie_App.Models;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Movie_App.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Movie> moviesList = new List<Movie>();
        SqlConnection connection = connectDB();

        connection.Open();

        String sql = "SELECT * FROM Movie";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    moviesList.Add(
                        new Movie()
                        {
                            Title = reader.GetString(0),
                            Duration = reader.GetInt32(1),
                            Subtitle = reader.GetString(2),
                            ReleaseDate = reader.GetDateTime(3),
                            Language = reader.GetString(4),
                            MovieType = (Actions)Enum.Parse<Actions>(reader.GetString(5))
                        }
                    );
                }
            }
        }

        ViewData["MovieList"] = moviesList;
        return View();
    }

    public IActionResult Add(string Title, int Duration, string Subtitle, string ReleaseDateString, string Language, Actions MovieType)
    {
        SqlConnection connection = connectDB();
        connection.Open();
        String sqlStatement = "INSERT INTO Movie (\"Title\", \"Duration\", \"Subtitle\", \"ReleaseDate\", \"Language\", \"MovieType\") VALUES ('"+ Title +"',"+ Duration +",'" + Subtitle + "','"+ ReleaseDateString +"','"+ Language +"','"+ MovieType +"');";
        using (SqlCommand cmd = new SqlCommand(sqlStatement, connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        return Redirect("/");
    }

    public IActionResult Edit(string OldTitle, string Title, int Duration, string Subtitle, string ReleaseDateString, string Language, Actions MovieType)
    {
        SqlConnection connection = connectDB();
        connection.Open();
        String sqlStatement = "UPDATE Movie SET Title='"+ Title +"', Duration='"+ Duration +"', Subtitle='" + Subtitle + "', ReleaseDate='"+ ReleaseDateString +"', Language='"+ Language +"', MovieType='"+ MovieType +"' WHERE Title='"+ OldTitle +"';";
        using (SqlCommand cmd = new SqlCommand(sqlStatement, connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        return Redirect("/");
    }

    public IActionResult Delete(string Title)
    {
        SqlConnection connection = connectDB();
        connection.Open();
        String sqlStatement = "DELETE FROM Movie WHERE Title='"+ Title +"';";
        using (SqlCommand cmd = new SqlCommand(sqlStatement, connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        return Redirect("/");
    }



    SqlConnection connectDB()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "localhost";
        builder.UserID = "sa";
        builder.Password = "Chheangmai@443";
        builder.InitialCatalog = "ChheangmaiDB";

        SqlConnection connection = new SqlConnection(builder.ConnectionString);

        return connection;
    }
}
