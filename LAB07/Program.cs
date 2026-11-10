namespace LAB07;

internal static class Program
{
    private static void Main()
    {
        File[] files =
        {
            new TextFile("readme", 2400, new DateTime(2024, 1, 15), new DateTime(2024, 2, 1), "UTF-8",
                "Лабораторная работа 7.\nРабота с файлами."),
            new TextFile("notes", 1100, new DateTime(2023, 11, 5), new DateTime(2024, 1, 20), "UTF-16",
                "Список задач."),
            new AudioFile("song", 5000000, new DateTime(2022, 7, 10), new DateTime(2024, 2, 5), 215, 320),
            new AudioFile("podcast", 18000000, new DateTime(2023, 3, 2), new DateTime(2024, 2, 3), 1_800, 128),
            new VideoFile("lesson", 700000000, new DateTime(2021, 9, 12), new DateTime(2024, 2, 8), 3_600, "1920x1080"),
            new VideoFile("clip", 120000000, new DateTime(2024, 1, 3), new DateTime(2024, 2, 9), 180, "1280x720"),
            new VideoFile("lecture", 950000000, new DateTime(2020, 5, 25), new DateTime(2024, 1, 30), 5_400, "3840x2160"),
            new ImageFile("landscape", 3500000, new DateTime(2022, 4, 18), new DateTime(2024, 2, 2), 3840, 2160, "JPEG"),
            new ImageFile("portrait", 2100000, new DateTime(2023, 8, 30), new DateTime(2024, 2, 6), 1080, 1350, "PNG"),
            new ImageFile("icon", 85000, new DateTime(2024, 1, 28), new DateTime(2024, 2, 7), 512, 512, "PNG")
        };

        foreach (File file in files)
            Console.WriteLine(file);

        foreach (File file in files)
        {
            file.Open();

            switch (file)
            {
                case TextFile text:
                    Console.WriteLine($"Получено строк: {text.GetLineCount()}.");
                    break;
                case AudioFile audio:
                    audio.Play();
                    Console.WriteLine($"Длительность: {audio.GetDuration()} сек.");
                    break;
                case VideoFile video:
                    video.Play();
                    Console.WriteLine($"Разрешение: {video.GetResolution()}.");
                    break;
                case ImageFile image:
                    image.Show();
                    Console.WriteLine($"Размер: {image.GetSize()}.");
                    break;
            }

            file.Close();
            Console.WriteLine();
        }

        long totalVideoSize = files.OfType<VideoFile>().Sum(file => file.Size);
        File oldestFile = files.MinBy(file => file.CreationDate)!;

        Console.WriteLine($"Суммарный размер видеофайлов: {totalVideoSize:N0} байт.");
        Console.WriteLine($"Самый старый файл: {oldestFile.FileName}{oldestFile.Extension}, " +
                          $"дата создания: {oldestFile.CreationDate:dd.MM.yyyy}.");
    }
}
