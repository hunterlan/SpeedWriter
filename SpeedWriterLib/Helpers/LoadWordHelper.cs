using System.Reflection;

namespace SpeedWriterLib.Helpers;

public class LoadWordHelper
{
    public IEnumerable<string> Words { get; }

    private readonly string PathToWords;

    public LoadWordHelper()
    {
        PathToWords = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)}{Path.DirectorySeparatorChar}Assets{Path.DirectorySeparatorChar}words.txt" ?? string.Empty;
        Words = LoadAllWords();
    }

    private IEnumerable<string> LoadAllWords()
    {
        List<string> sortedWords = new();
        using StreamReader sr = new(PathToWords);

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine() ?? string.Empty;
            if (line.Length >= 4 && !line.All(char.IsDigit))
            {
                sortedWords.Add(line);
            }
        }

        return sortedWords.AsEnumerable();
    }
}