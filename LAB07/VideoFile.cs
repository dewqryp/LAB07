namespace LAB07;

public sealed class VideoFile : File
{
    public int Duration { get; }
    public string Resolution { get; }

    public VideoFile(string fileName, long size, DateTime creationDate, DateTime lastAccessDate,
        int duration, string resolution)
        : base(fileName, size, ".mp4", creationDate, lastAccessDate)
    {
        if (duration < 0)
            throw new ArgumentOutOfRangeException(nameof(duration));
        if (string.IsNullOrWhiteSpace(resolution))
            throw new ArgumentException("Разрешение не может быть пустым.", nameof(resolution));

        Duration = duration;
        Resolution = resolution;
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine($"Видеоданные: длительность {Duration} сек., разрешение {Resolution}.");
    }

    public void Play() => Console.WriteLine($"Воспроизводится видеофайл \"{FileName}\".");
    public string GetResolution() => Resolution;

    public override string GetInfo() =>
        $"{base.GetInfo()}, длительность: {Duration} сек., разрешение: {Resolution}";
}
