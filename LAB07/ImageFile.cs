namespace LAB07;

public sealed class ImageFile : File
{
    public int Width { get; }
    public int Height { get; }
    public string Format { get; }

    public ImageFile(string fileName, long size, DateTime creationDate, DateTime lastAccessDate,
        int width, int height, string format)
        : base(fileName, size, ".jpg", creationDate, lastAccessDate)
    {
        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width));
        if (height <= 0)
            throw new ArgumentOutOfRangeException(nameof(height));
        if (string.IsNullOrWhiteSpace(format))
            throw new ArgumentException("Формат изображения не может быть пустым.", nameof(format));

        Width = width;
        Height = height;
        Format = format;
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine($"Изображение: {Width}x{Height}, формат {Format}.");
    }

    public void Show() => Console.WriteLine($"Показывается изображение \"{FileName}\".");
    public string GetSize() => $"{Width}x{Height}";

    public override string GetInfo() =>
        $"{base.GetInfo()}, размер изображения: {GetSize()}, формат: {Format}";
}
