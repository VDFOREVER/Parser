namespace parser.Core.Habra;
class HabraSettings : IParserSettings
{
    public HabraSettings(int start, int end)
    {
        StartPoint = start;
        EndPoint = end;
    }
    static dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("./config.json"));
    public string BaseUrl { get; set; } = jsonfile["URL"];

    public string Prefix { get; set; } = jsonfile["Prefix"];

    public int StartPoint { get; set; }

    public int EndPoint { get; set; }
}