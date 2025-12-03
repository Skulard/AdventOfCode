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

    //44854383294
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
        List<string> ranges=allFiles.DayTwo.Split(",").ToList();
        foreach(var range in ranges)
        {
            List<string> items = range.Split("-").ToList();
            long begin = Convert.ToInt64(items[0]);
            long end = Convert.ToInt64(items[1]);
            string beginstring = begin.ToString();
            string endstring = end.ToString();
            for(; begin <= end; begin++)
            {
                beginstring = begin.ToString();
                var beginchar = beginstring.ToCharArray();
                
                if(beginstring.Length > 1)
                {
                    long a = Convert.ToInt64(beginstring.Substring(0, beginstring.Length / 2));
                    long b = Convert.ToInt64(beginstring.Substring((beginstring.Length - (beginstring.Length / 2)), (beginstring.Length / 2)));
                    
                }
            }
        }
    }
}
