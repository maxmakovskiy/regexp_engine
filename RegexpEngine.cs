public static class RegexpEngine
{
    public static bool MatchOne(char text, char pattern)
    {
        if (pattern == '.') return true;
        if (pattern != text) return false;

        return pattern.Equals(text);
    }

    public static bool Match(string text, string pattern)
    {
        if (pattern.Length == 0) {
            return true;
        } else {
            return MatchOne(text[0], pattern[0]) && Match(text.Substring(1), pattern.Substring(1));
        }
    }

}