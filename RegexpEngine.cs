public static class RegexpEngine
{
    public static bool MatchOne(char text, char pattern)
    {
        if (pattern == '.') return true;
        if (pattern != text) return false;

        return pattern.Equals(text);
    }


}