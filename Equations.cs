using System.Text;

namespace MathSheets;

public static class Equations
{
    private static readonly Random Rng = new();
    
    public static string RandomEquations(int max, int level)
    {
        var result = new StringBuilder();
        
        for (var i = 0; i < 10; i++)
        {
            var type = Rng.Next(level);

            result.AppendLine(type switch
            {
                0 => OneUnknownAxEqualsC(max),
                1 => OneUnknownAxPlusBEqualsC(max),
                2 => OneUnknownAxPlusBEqualsCxPlusD(max),
                _ => throw new NotSupportedException()
            });
        }

        return result.ToString();
    }

    private static string OneUnknownAxEqualsC(int max)
    {
        var x = Rng.Next(2, max + 1);
        var a = Rng.Next(2, 10);
        var c = a * x;
        return $"{a}x = {c} \u21d2";
    }

    private static string OneUnknownAxPlusBEqualsC(int max)
    {
        var x = Rng.Next(2, max + 1);
        var a = Rng.Next(2, 10);
        var b = Rng.Next(-9, 10);
        var sign = b < 0 ? " - " : " + ";
        var c = a * x + b;
        return $"{a}x{sign}{Math.Abs(b)} = {c} \u21d2";
    }

    private static string OneUnknownAxPlusBEqualsCxPlusD(int max)
    {
        // x = c1
        var c1 = Rng.Next(2, max + 1);
        
        // | * c2 => c2 * x = c2 * c1
        var c2 = Rng.Next(2, 10);
        
        // | + c3 * x => (c2 + c3) * x = c3 * x + c2 * c1
        var c3 = Rng.Next(2, 10);
        
        // | + c4 => (c2 + c3) * x + c4 = c3 * x + c2 * c1 + c4
        var c4 = Rng.Next(2, 10);

        return $"{c2 + c3}x + {c4} = {c3}x + {c2 * c1 + c4} \u21d2";
    }
}