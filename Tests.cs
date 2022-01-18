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
        int errorCounter = 0;

        foreach (var item in textToPattern)
        {
            if (!Assert(MatchOne(item.Item2, item.Item3), item.Item1)) {
                Console.WriteLine("Failed with: text'{0}', pattern='{1}', expected_result={2}",
                    item.Item2, item.Item3, item.Item1);
            }
        }

        if (errorCounter == 0) {
            Console.WriteLine("MatchOne's tests passed!");
        }
    }

}