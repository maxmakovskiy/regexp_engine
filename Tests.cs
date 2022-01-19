using static RegexpEngine;
using System.Collections;


public static class Tests
{

    private static bool Assert<T>(T target, T expected)
    {
        return target.Equals(expected);
    }

    public static void TestMatchOne()
    {
        var textToPattern = new List<Tuple<bool, char, char>>()
        {
            Tuple.Create(true, 'a', 'a'),
            Tuple.Create(true, 'a', '.'),
            Tuple.Create(false, 'a', 'b'),
        };

        Test(MatchOne, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public static void TestMatch()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abc", "abc"),
            Tuple.Create(true, "abc", "a.c"),
            Tuple.Create(false, "abc", "bbb"),
        };

        Test(Match, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public static void TestMatchEnd()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abc", "abc$"),
            Tuple.Create(true, "abc", "a.c$"),
            Tuple.Create(false, "abc", "bbb$"),
        };

        Test(Match, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public static void TestMatchBegin()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abc", "^abc"),
            Tuple.Create(true, "abc", "^a.c"),
            Tuple.Create(false, "abc", "^bbb"),
        };

        Test(Search, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public static void TestSearch()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abcdefg", "ab"),
            Tuple.Create(true, "abcdefg", "ef"),
            Tuple.Create(false, "abcdefg", "bbb"),
        };

        Test(Search, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public static void Test0or1Times()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abc", "ab?"),
            Tuple.Create(true, "ab", "ab?"),
            Tuple.Create(true, "abc", "a?b?c?"),
            Tuple.Create(true, "", "a?b?c?"),
        };

        Test(Match, textToPattern, System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    private static void Test<T>(Func<T, T, bool> func, List<Tuple<bool, T, T>> textToPattern, string testName)
    {
        int errorCounter = 0;

        foreach (var item in textToPattern)
        {
            if (!Assert(func(item.Item2, item.Item3), item.Item1)) {
                Console.WriteLine(testName + " failed with: text'{0}', pattern='{1}', expected_result={2}",
                    item.Item2, item.Item3, item.Item1);
                errorCounter++;
            }
        }

        if (errorCounter == 0) {
            Console.WriteLine(testName + " passed!");
        }        
    }

}