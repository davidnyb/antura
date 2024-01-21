using System.Text;

namespace Antura.Files;

public class FileWrapper
{
    private readonly string path;

    public FileWrapper(string path)
    {
        this.path = path ?? throw new ArgumentNullException(nameof(path));
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found: ", nameof(path));
        }
    }

    public string GetFileNameWithoutExtension()
    {
        return Path.GetFileNameWithoutExtension(path);
    }

    public string ReadAllText()
    {
        var encoding = Encoding.UTF8;
        using (var reader = new StreamReader(path, encoding, true))
        {
            reader.Peek();
            encoding = reader.CurrentEncoding;
        }

        var text = File.ReadAllText(path, encoding);

        return text;
    }
}