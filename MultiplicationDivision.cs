using System.Text;

namespace MathSheets;

internal static class MultiplicationDivision
{
    private static readonly Random Rng = new();

    public static string RandomMultiplicationOrDivision(int max)
    {
        var result = new StringBuilder();
        
        for (var i = 0; i < 10; i++)
        {
            var type = Rng.Next(7);

            result.AppendLine(type switch
            {
                0 => FindProduct(max),
                1 => FindFirstFactor(max),
                2 => FindSecondFactor(max),
                3 => FindQuotient(max),
                4 => FindQuotientAndRemains(max),
                5 => FindDividend(max),
                6 => FindDivisor(max),
                _ => throw new NotSupportedException()
            });
        }

        return result.ToString();
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
            
            Factor1 = Rng.Next(4) == 0
                ? $"({string.Join(" + ", TwoSummands(factor1))})"
                : factor1.ToString();
            
            Factor2 = Rng.Next(4) == 0
                ? $"({string.Join(" + ", TwoSummands(factor2))})"
                : factor2.ToString();
            
            Product = product.ToString();
            ProductWithRemains = productWithRemains.ToString();
        }
        
        private static IEnumerable<int> TwoSummands(int number)
        {
            // Generate a random number between 1 and number - 1
            int part1 = Rng.Next(1, number);
            int part2 = number - part1;

            return [part1, part2];
        }
    }
}
