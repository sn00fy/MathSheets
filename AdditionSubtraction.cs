using System.Text;

namespace MathSheets;

internal static class AdditionSubtraction
{
    private static readonly Random Rng = new();

    public static string RandomAdditionOrSubtraction(int max)
    {
        var result = new StringBuilder();
        
        for (var i = 0; i < 10; i++)
        {
            var type = Rng.Next(6);

            result.AppendLine(type switch
            {
                0 => FindSum(max),
                1 => FindFirstSummand(max),
                2 => FindSecondSummand(max),
                3 => FindDifference(max),
                4 => FindMinuend(max),
                5 => FindSubtrahend(max),
                _ => throw new NotSupportedException()
            });
        }

        return result.ToString();
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

        public Data(int max)
        {
            int summand1 = Rng.Next((int)(0.9 * max)) + (int)(0.05 * max);
            int summand2 = Rng.Next((int)(0.95 * max) - summand1) + (int)(0.03 * max);
            int sum = summand1 + summand2;

            var (a, b) = TwoFactors(summand1);
            
            Summand1 = a != 1 && b != 1 && Rng.Next(2) == 0
                ? $"{a} \u22c5 {b}"
                : summand1.ToString();

            var (x, y) = TwoFactors(summand2);
            
            Summand2 = x != 1 && y != 1 && Rng.Next(2) == 0
                ? $"{x} \u22c5 {y}"
                : summand2.ToString();

            Sum = sum.ToString();
        }
        
        private static (int, int) TwoFactors(int number)
        {
            var primeFactors = GetPrimeFactors(number);
            
            int factor1 = 1;
            int factor2 = 1;

            // Shuffle and split prime factors into two groups
            foreach (int primeFactor in primeFactors)
            {
                if (Rng.Next(2) == 0)
                {
                    factor1 *= primeFactor;
                }
                else
                {
                    factor2 *= primeFactor;
                }
            }

            return (factor1, factor2);
        }
        
        private static List<int> GetPrimeFactors(int number)
        {
            var primeFactors = new List<int>();
        
            // Divide the number by 2 as long as it's even
            while (number % 2 == 0)
            {
                primeFactors.Add(2);
                number /= 2;
            }
        
            // Now the number must be odd, start checking from 3
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                // While i divides number, add i and divide the number
                while (number % i == 0)
                {
                    primeFactors.Add(i);
                    number /= i;
                }
            }
        
            // If number is still greater than 2, then it's a prime factor
            if (number > 2)
            {
                primeFactors.Add(number);
            }
        
            return primeFactors;
        }
    }
}
