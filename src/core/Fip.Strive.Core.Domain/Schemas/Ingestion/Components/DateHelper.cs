namespace Fip.Strive.Core.Domain.Schemas.Ingestion.Components;

public static class DateHelper
{
    public static DateTime GetDateFromMyCollectionDirectory(DirectoryInfo? directory)
    {
        if (directory is not { Exists: true })
            throw new DirectoryNotFoundException(
                $"The directory {directory?.FullName} could not be found."
            );

        var dirName = directory.Name;
        var parts = dirName.Split(" - ");
        var dateString = parts[0].Replace(".", "-");
        var timeString = parts[1];
        return DateTime.Parse(
            $"{dateString} {timeString.Substring(0, 2)}:{timeString.Substring(2, 2)}"
        );
    }

    public static DateTime GetDateFromCsvLine(string line, string separator, int index)
    {
        var cells = line.Split(separator);
        var value = cells[index];
        value = value.Replace("\"", string.Empty);
        return DateTime.Parse(value);
    }

    public static string FsMillisecondFormat => "yyyy-MM-ddTHH-mm-ss-fff";
    public static string MillisecondFormat => "yyyy-MM-ddTHH:mm:ss.fff";
    public static string SecondFormat => "s";
    public static string UiDayFormat => "dd.MM.yyyy";
    public static string UiSecondFormat => "dd.MM.yyyy HH:mm:ss";
    public static string MinuteFormat => "yyyy-MM-ddTHH:mm";
    public static string UiMinuteFormat => "dd.MM.yyyy HH:mm";
    public static string DayFormat => "yyyy-MM-dd";
    public static string MonthFormat => "yyyy-MM";
}
