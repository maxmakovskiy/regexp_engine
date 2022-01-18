public static class RegexpEngine
{
    public static bool MatchOne(string text, string pattern)
    {
        if (pattern.Length == 0) return true;
        if (text.Length == 0) return false;
        if (pattern == ".") return true;
        if (pattern != text) return false;

        return pattern.Equals(text);
    }

}