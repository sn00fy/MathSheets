namespace MathSheets;

internal static class MultiplicationDivision
{
    private static readonly Random Rng = new();

    public static string RandomMultiplicationOrDivision(int max)
    {
        int type = Rng.Next(7);

        return type switch
        {
            0 => FindProduct(max),
            1 => FindFirstFactor(max),
            2 => FindSecondFactor(max),
            3 => FindQuotient(max),
            4 => FindQuotientAndRemains(max),
            5 => FindDividend(max),
            6 => FindDivisor(max),
            _ => throw new NotSupportedException(),
        };
    }

    private static string FindProduct(int max)
    {
        var data = new Data(max);
        return $"{data.Factor1} \u22c5 {data.Factor2} = ____";
    }

    private static string FindFirstFactor(int max)
    {
        var data = new Data(max);
        return $"____ \u22c5 {data.Factor2} = {data.Product}";
    }

    private static string FindSecondFactor(int max)
    {
        var data = new Data(max);
        return $"{data.Factor1} \u22c5 ____ = {data.Product}";
    }

    private static string FindQuotient(int max)
    {
        var data = new Data(max);
        return $"{data.Product} : {data.Factor1} = ____";
    }

    private static string FindQuotientAndRemains(int max)
    {
        var data = new Data(max);
        return $"{data.ProductWithRemains} : {data.Factor1} = ____";
    }

    private static string FindDividend(int max)
    {
        var data = new Data(max);
        return $"____ : {data.Factor1} = {data.Factor2}";
    }

    private static string FindDivisor(int max)
    {
        var data = new Data(max);
        return $"{data.Product} : ____ = {data.Factor2}";
    }

    private class Data
    {
        public string Factor1 { get; private set; }
        public string Factor2 { get; private set; }
        public string Product { get; private set; }
        public string ProductWithRemains { get; private set; }

        public Data(int max)
        {
            int factor1 = Rng.Next(max - 1) + 2;     // Don't use 1, it's too easy.
            int factor2 = Rng.Next(8) + 2;           // Don't use 1, it's too easy.
            int product = factor1 * factor2;
            int remains = Rng.Next(factor2 - 1) + 1;
            int productWithRemains = product + remains;

            Factor1 = factor1.Pad(2);
            Factor2 = factor2.Pad(2);
            Product = product.Pad(2);
            ProductWithRemains = productWithRemains.Pad(2);
        }
    }
}
