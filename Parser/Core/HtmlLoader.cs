namespace parser.Core;
class HtmlLoader
{
    readonly HttpClient client;
    readonly string url;
    public HtmlLoader(IParserSettings settings)
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# App");
        url = $"{settings.BaseUrl}/{settings.Prefix}";
    }

    public async Task<string> GetSourceByPageId(int id)
    {
        string currentUrl = url.Replace("{CurrentId}", id.ToString());
        HttpResponseMessage responce = await client.GetAsync(currentUrl);
        string source = null;
        
        if (responce != null && responce.StatusCode == HttpStatusCode.OK)
        {
            source = await responce.Content.ReadAsStringAsync();
        }
        return source;
    }
}