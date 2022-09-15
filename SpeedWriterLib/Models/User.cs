namespace SpeedWriterLib.Models;

public class User
{
    public int Id { get; set; } = -1;

    public string Login { get; set; } = "Guest";

    public string Password { get; set; } = "";

    public string Email { get; set; } = "";

    public string Country { get; set; } = "Earth";
}