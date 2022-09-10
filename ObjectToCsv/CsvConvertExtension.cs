using System.Text;

namespace ObjectToCsv;

public static class CsvConvertExtension
{
    public static string ToCsv(this object item)
    {
        var type = item.GetType();
        var properties = type.GetProperties().Select(x => x.Name);
        var header = string.Join(";", properties);
        var csv = new StringBuilder();
        csv.AppendLine(header);

        var values = properties.Select(property => type.GetProperty(property)!.GetValue(item, null)?.ToString());

        csv.AppendLine(string.Join(";", values));
        return csv.ToString();
    }

    public static string ToCsv(this IEnumerable<object> items)
    {
        var type = items.First().GetType();
        var properties = type.GetProperties().Select(x => x.Name);
        var header = string.Join(";", properties);
        var csv = new StringBuilder();
        csv.AppendLine(header);

        foreach (var item in items)
        {
            var values = properties.Select(property => type.GetProperty(property)!.GetValue(item, null)?.ToString());

            csv.AppendLine(string.Join(";", values));
        }
        return csv.ToString();
    }
}