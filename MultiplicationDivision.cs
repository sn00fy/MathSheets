namespace MathSheets;

internal class MultiplicationDivision
{
    private static readonly Random Rng = new();

    public static string RandomMultiplicationOrDivision(int max)
    {
        int type = Rng.Next(6);

        return type switch
        {
            0 => FindProduct(max),
            1 => FindFirstFactor(max),
            2 => FindSecondFactor(max),
            3 => FindQuotient(max),
            4 => FindDividend(max),
            5 => FindDivisor(max),
            _ => throw new NotSupportedException(),
        };
    }

    public static string FindProduct(int max)
    {
        var data = new Data(max);
        return $"{data.Factor1} * {data.Factor2} = ____";
    }

    public static string FindFirstFactor(int max)
    {
        var data = new Data(max);
        return $"____ * {data.Factor2} = {data.Product}";
    }

    public static string FindSecondFactor(int max)
    {
        var data = new Data(max);
        return $"{data.Factor1} * ____ = {data.Product}";
    }

    public static string FindQuotient(int max)
    {
        var data = new Data(max);
        return $"{data.Product} : {data.Factor1} = ____";
    }

    public static string FindDividend(int max)
    {
        var data = new Data(max);
        return $"____ : {data.Factor1} = {data.Factor2}";
    }

    public static string FindDivisor(int max)
    {
        var data = new Data(max);
        return $"{data.Product} : ____ = {data.Factor2}";
    }

    private class Data
    {
        public string Factor1 { get; private set; }
        public string Factor2 { get; private set; }
        public string Product { get; private set; }

        public Data(int max)
        {
            int factor1 = Rng.Next(max) + 1;
            int factor2 = Rng.Next(9) + 1;
            int product = factor1 * factor2;

            Factor1 = factor1.Pad(2);
            Factor2 = factor2.Pad(2);
            Product = product.Pad(2);
        }
    }
}
