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
            new Tuple<bool, char, char>(true, 'a', 'a'),
            new Tuple<bool, char, char>(true, 'a', '.'),
            new Tuple<bool, char, char>(false, 'a', 'b'),
        };

        Test(MatchOne, textToPattern);
    }

    public static void TestMatch()
    {
        var textToPattern = new List<Tuple<bool, string, string>>()
        {
            Tuple.Create(true, "abc", "abc"),
            Tuple.Create(true, "abc", "a.c"),
            Tuple.Create(false, "abc", "bbb"),
        };

        Test(Match, textToPattern);
    }

    private static void Test<T>(Func<T, T, bool> func, List<Tuple<bool, T, T>> textToPattern)
    {
        int errorCounter = 0;

        foreach (var item in textToPattern)
        {
            if (!Assert(func(item.Item2, item.Item3), item.Item1)) {
                Console.WriteLine("Failed with: text'{0}', pattern='{1}', expected_result={2}",
                    item.Item2, item.Item3, item.Item1);
            }
        }

        if (errorCounter == 0) {
            Console.WriteLine(func.Method.Name + "'s tests passed!");
        }        
    }

}