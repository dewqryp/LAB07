namespace LAB07;

public sealed class AudioFile : File
{
    public int Duration { get; }
    public int Bitrate { get; }

    public AudioFile(string fileName, long size, DateTime creationDate, DateTime lastAccessDate,
        int duration, int bitrate)
        : base(fileName, size, ".mp3", creationDate, lastAccessDate)
    {
        if (duration < 0)
            throw new ArgumentOutOfRangeException(nameof(duration));
        if (bitrate < 0)
            throw new ArgumentOutOfRangeException(nameof(bitrate));

        Duration = duration;
        Bitrate = bitrate;
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine($"Аудиоданные: длительность {Duration} сек., битрейт {Bitrate} кбит/с.");
    }

    public void Play() => Console.WriteLine($"Воспроизводится аудиофайл \"{FileName}\".");
    public int GetDuration() => Duration;

    public override string GetInfo() =>
        $"{base.GetInfo()}, длительность: {Duration} сек., битрейт: {Bitrate} кбит/с";
}
