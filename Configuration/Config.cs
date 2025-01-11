namespace MathSheets.Configuration;

public class Config
{
    private Random random = new Random();
    
    public int BlockCount { get; set; }
    public AdditionConfig AdditionConfig { get; set; } = new();

    public string CreateBlock()
    {
        return "";
    }

    public static Config Level1() => new()
    {
        BlockCount = 2,
        AdditionConfig = new AdditionConfig
        {
            IsEnabled = true,
            MaxSum = 10
        }
    };
}