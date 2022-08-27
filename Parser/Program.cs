namespace parser;
partial class Programm
{
    static dynamic jsonfile;
    static void Main()
    {
        try
        {
            jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("./config.json"));
            ParserWorker<string[]> parser;
            parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
            Console.WriteLine("От и до");
            int start = Convert.ToInt32(Console.ReadLine());
            int end = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            parser.Settings = new HabraSettings(start, end);
            parser.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    private static void Parser_OnNewData(object arg1, string[] arg2)
    {
        try
        {
            for (int i = 0; i < arg2.Length; i++)
            {
                string[] s10 = arg2[i].Split("/", 7, StringSplitOptions.RemoveEmptyEntries);
                string[] s11 = s10[3].Split(".", 7, StringSplitOptions.RemoveEmptyEntries);
                using (var client = new WebClient())
                {
                    client.DownloadFile("https:/" + arg2[i].Substring(1), $"{jsonfile["Path"]}" + s11[0] + ".jpg");
                }
            }
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.Message);
        }
    }

    private static void Parser_OnCompleted(object obj)
    {
        Console.WriteLine("All works done!");
    }
}