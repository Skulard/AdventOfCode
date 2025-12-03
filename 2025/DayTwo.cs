using System;
using System.ComponentModel;

namespace _2025;

public class DayTwo
{
    AllFiles allFiles = new();
    public DayTwo()
    {
        Console.WriteLine("Welcome to Hell Day Two");
        PartOne();
        PartTwo();
    }

    void PartOne()
    {
        long total = 0;
        var read1 = allFiles.DayTwo.Split(',');
        foreach (var item in read1)
        {
            var range = item.Split("-");
            long begin = Convert.ToInt64(range[0]);
            long end = Convert.ToInt64(range[1]);
            string endString = end.ToString();
            string beginString = begin.ToString();
            for (; begin <= end; begin++)
            {
                beginString = begin.ToString();

                if ((beginString.Length % 2 == 1) && (endString.Length % 2 == 1))
                    break;
                
                int stringHalf = beginString.Length / 2;
                
                if (beginString.Length > 1 && beginString.Length % 2 == 0)
                {
                    long part1 = Convert.ToInt64(beginString.Substring(0,stringHalf));
                    long part2 = Convert.ToInt64(beginString.Substring(beginString.Length - stringHalf, stringHalf));

                    if (part1 == part2) total += begin;
                }

            }
        }
        Console.WriteLine($"Solution is: {total}");
    }

    void PartTwo()
    {
        //ID is invalid if sequence of digits repeated at least twice
        long count = 0;
        List<string> ranges=allFiles.ExampleDayTwo.Split(",").ToList();
        codingGardingTwo(allFiles.DayTwo.Split(","));
        codingGardingTwo(allFiles.DayTwo.Split(','), true);
        //Thank you Coding Garden for the example. i learned lots
        //https://www.youtube.com/watch?v=TD_FwAIEpqI
    }

    void codingGardingTwo(string[] rangeStrings, bool partTwo=false)
    {
        List<long> invalidIds = new();
        rangeStrings.ToList().ForEach((range) =>
        {
            var (one, two) = range.Split('-') switch
            {
                [var eins, var zwei] => (Convert.ToInt64(eins), Convert.ToInt64(zwei)),
                _ => default
            };
            for (long i = one;i <= two; i++)
            {
                if (codingGardenIsInvalidId(i,partTwo))
                    invalidIds.Add(i);
            }
        });
        Console.WriteLine(invalidIds.Aggregate((s,v)=>s+v));
    }
    bool codingGardenIsInvalidId(long value, bool partTwo=false)
    {
        bool isInvalid = false;
        var valueString = value.ToString();
        var (left, right) = (valueString.Substring(0, valueString.Length / 2), valueString.Substring(valueString.Length / 2));

        isInvalid= (left == right);

        if (!isInvalid && partTwo)
        {
            int repeat = 1;
            while(repeat * 2 < valueString.Length)
            {
                var partToRepeat = valueString.Substring(0, repeat);
                var amountToRepeat = valueString.Length / repeat;
                var repeated = string.Concat(Enumerable.Repeat(partToRepeat, amountToRepeat));
                if (repeated == valueString)
                    return true;
                repeat++;
            }
        }
        return isInvalid;
    }
}
