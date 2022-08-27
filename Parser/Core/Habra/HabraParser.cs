namespace parser.Core.Habra;
class HabraParser : IParser<string[]>
{
    public string[] Parse(IHtmlDocument document)
    {
        var list = new List<string>();
        dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("./config.json"));
        var items = document.QuerySelectorAll($"{jsonfile["Tag"]}").Where(item => item.ClassName != null && item.ClassName.Contains($"{jsonfile["Class"]}"));
        foreach (var item in items)
        {
            var itemss = item.QuerySelector($"{jsonfile["UnderTag"]}")?.GetAttribute($"{jsonfile["Content"]}");
            list.Add(itemss);
        }
        return list.ToArray();
    }
}