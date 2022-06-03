namespace Movie_App.Models;
public enum Actions
{
    Action,
    Horror,
    Adventure,
    Science
}
public class Movie
{

    public string Title { get; set; } = default!;
    public int Duration { get; set; }
    public string Subtitle { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public string Language { get; set; } = default!;
    public Actions MovieType { get; set; }
}
