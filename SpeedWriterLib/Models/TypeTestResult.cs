namespace SpeedWriterLib.Models;

public class TypeTestResult
{
    public int Id {get; set;}

    public ushort TotalWord { get; set; }

    public ushort CountMistakes { get; set; }

    public User User { get; set; } = new();
}