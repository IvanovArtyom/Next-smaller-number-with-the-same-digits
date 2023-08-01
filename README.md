## Description:
Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.

For example:
```C#
nextSmaller(21) == 12
nextSmaller(531) == 513
nextSmaller(2071) == 2017
```
Return ```-1``` (for Haskell: return ```Nothing```, for Rust: return ```None```), when there is no smaller number that contains the same digits. Also return ```-1``` when the next smaller number with the same digits would require the leading digit to be zero.
```C#
nextSmaller(9) == -1
nextSmaller(111) == -1
nextSmaller(135) == -1
nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
```
- Some tests will include very large numbers.
- Test data only employs positive integers.
  
*The function you write for this challenge is the inverse of this kata: "[Next bigger number with the same digits](https://www.codewars.com/kata/next-bigger-number-with-the-same-digits)."*
### My solution
```C#
using System.Linq;

public class Kata
{
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
```
