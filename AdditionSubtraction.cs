namespace MathSheets;

internal static class AdditionSubtraction
{
    private static readonly Random Rng = new();

    public static string RandomAdditionOrSubtraction(int max)
    {
        int type = Rng.Next(6);

        return type switch
        {
            0 => FindSum(max),
            1 => FindFirstSummand(max),
            2 => FindSecondSummand(max),
            3 => FindDifference(max),
            4 => FindMinuend(max),
            5 => FindSubtrahend(max),
            _ => throw new NotSupportedException(),
        };
    }

    private static string FindSum(int max)
    {
        var data = new Data(max);
        return $"{data.Summand1} + {data.Summand2} = ____";
    }

    private static string FindFirstSummand(int max)
    {
        var data = new Data(max);
        return $"____ + {data.Summand2} = {data.Sum}";
    }

    private static string FindSecondSummand(int max)
    {
        var data = new Data(max);
        return $"{data.Summand1} + ____ = {data.Sum}";
    }

    private static string FindDifference(int max)
    {
        var data = new Data(max);
        return $"{data.Sum} - {data.Summand1} = ____";
    }

    private static string FindMinuend(int max)
    {
        var data = new Data(max);
        return $"____ - {data.Summand1} = {data.Summand2}";
    }

    private static string FindSubtrahend(int max)
    {
        var data = new Data(max);
        return $"{data.Sum} - ____ = {data.Summand2}";
    }

    private class Data
    {
        public string Summand1 { get; private set; }
        public string Summand2 { get; private set; }
        public string Sum { get; private set; }
        private int Digits { get; set; }

        public Data(int max)
        {
            int summand1 = Rng.Next((int)(0.9 * max)) + (int)(0.05 * max);
            int summand2 = Rng.Next((int)(0.95 * max) - summand1) + (int)(0.03 * max);
            int sum = summand1 + summand2;
            Digits = (max - 1).GetDigits();

            Summand1 = summand1.Pad(Digits);
            Summand2 = summand2.Pad(Digits);
            Sum = sum.Pad(Digits);
        }
    }
}
