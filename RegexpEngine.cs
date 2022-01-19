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
        } else if (pattern == "$" && text.Length == 0) {
            return true;
        } else if (pattern.Length > 1 && pattern[1] == '?') {
            return matchQuestion(text, pattern);
        } else {
            return MatchOne(text[0], pattern[0]) && Match(text.Substring(1), pattern.Substring(1));
        }
    }

    private static bool matchQuestion(string text, string pattern)
    {
        if (pattern.Length == 2 && text.Length == 0) {
            return true; 
        } else if (text.Length == 0) { 
            return Match(text, pattern.Substring(2));
        } 
        return (MatchOne(text[0], pattern[0]) && Match(text.Substring(1), pattern.Substring(2)))
            || Match(text, pattern.Substring(2));

    }

    public static bool Search(string text, string pattern)
    {
        if (pattern[0] == '^') {
            return Match(text, pattern.Substring(1));
        } else {
            bool result = Match(text, pattern);
            for (int i = 1; i < text.Length; i++) {
                result = result | Match(text.Substring(i), pattern);
            }
            return result;
        }  
    }

}