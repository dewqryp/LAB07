namespace LAB07;

public sealed class TextFile : File
{
    private string content;

    public string Encoding { get; }
    public int LineCount => content.Length == 0 ? 0 : content.Split('\n').Length;

    public TextFile(string fileName, long size, DateTime creationDate, DateTime lastAccessDate,
        string encoding, string content)
        : base(fileName, size, ".txt", creationDate, lastAccessDate)
    {
        Encoding = string.IsNullOrWhiteSpace(encoding)
            ? throw new ArgumentException("Кодировка не может быть пустой.", nameof(encoding))
            : encoding;
        this.content = content ?? string.Empty;
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine($"Текстовое содержимое ({Encoding}):");
        Console.WriteLine(content);
    }

    public string GetText() => content;
    public int GetLineCount() => LineCount;

    public override string GetInfo() =>
        $"{base.GetInfo()}, кодировка: {Encoding}, строк: {LineCount}";
}
