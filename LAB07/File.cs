namespace LAB07;

public class File
{
    public string FileName { get; }
    public long Size { get; }
    public string Extension { get; }
    public DateTime CreationDate { get; }
    public DateTime LastAccessDate { get; private set; }
    public bool IsOpen { get; private set; }

    public File(string fileName, long size, string extension, DateTime creationDate, DateTime lastAccessDate)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("Имя файла не может быть пустым.", nameof(fileName));
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Размер файла не может быть отрицательным.");
        if (string.IsNullOrWhiteSpace(extension))
            throw new ArgumentException("Расширение не может быть пустым.", nameof(extension));

        FileName = fileName;
        Size = size;
        Extension = extension.StartsWith('.') ? extension : $".{extension}";
        CreationDate = creationDate;
        LastAccessDate = lastAccessDate;
    }

    public virtual void Open()
    {
        IsOpen = true;
        LastAccessDate = DateTime.Now;
        Console.WriteLine($"Файл \"{FileName}\" открыт.");
    }

    public virtual void Close()
    {
        IsOpen = false;
        Console.WriteLine($"Файл \"{FileName}\" закрыт.");
    }

    public virtual string GetInfo()
    {
        return $"{FileName}{Extension}, размер: {Size} байт, " +
               $"создан: {CreationDate:dd.MM.yyyy}, открыт: {IsOpen}";
    }

    public override string ToString() => GetInfo();
}
