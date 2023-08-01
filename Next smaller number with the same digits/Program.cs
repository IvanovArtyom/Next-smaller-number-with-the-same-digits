using System.Linq;

public class Kata
{
    public static void Main()
    {
        // Test
        var t = NextSmaller(153);
        // ...should return 135
    }

    public static long NextSmaller(long n)
    {
        string nAsStr = n.ToString();

        for (int i = nAsStr.Length - 1; i > 0; i--)
        {
            if (nAsStr[i] >= nAsStr[i - 1])
                continue;

            char nextNumber = nAsStr.Last(c => c < nAsStr[i - 1]);
            var lastNumbers = nAsStr[(i - 1)..].OrderByDescending(c => c).ToList();
            lastNumbers.Remove(nextNumber);
            long result = long.Parse(string.Join("", nAsStr[0..(i - 1)], nextNumber, string.Join("", lastNumbers)));

            if (result.ToString().Length == nAsStr.Length)
                return result;
        }

        return -1;
    }
}