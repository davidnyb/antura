using System.Text.RegularExpressions;

namespace Antura.Files;

public static class StringExtensions
{
    public static int CountMatches(this string s, string pattern)
    {
        return Regex.Matches(s, pattern).Count;
    }
}