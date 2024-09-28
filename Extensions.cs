namespace MathSheets;

internal static class Extensions
{
    private static readonly Random Rng = new();

    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = Rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        return list;
    }

    public static int GetDigits(this int value) =>
        value == 0 ? 1 : (value > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)value));

    public static string Pad(this int value, int digits) =>
        value.ToString().PadLeft(digits);
}
