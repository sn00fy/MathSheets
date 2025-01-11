namespace MathSheets.Configuration;

public class AdditionConfig
{
    public bool IsEnabled { get; set; }
    public int MaxSum { get; set; }
    public bool CanContainSum { get; set; }
    public bool CanContainDifference { get; set; }
    public bool CanContainProduct { get; set; }
    public bool CanContainQuotient { get; set; }
    public bool CanSumBeUnknown { get; set; }
    public bool CanSummandBeUnknown { get; set; }
}