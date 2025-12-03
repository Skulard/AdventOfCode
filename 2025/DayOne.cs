namespace _2025;

public class DayOne
{
    AllFiles allFiles = new();
    public DayOne()
    {
        Console.WriteLine("Welcome to hell of Day ONE");
        PartOne();
        PartTwo();
    }

    void PartOne()
    {
        int dial = 50;
        int counter = 0;
        var input = allFiles.DayOne.Split("\n");
        Console.WriteLine("This one should only count when it hits 0");

        //a foreach with switch with counting
        foreach (var line in input)
        {
            char direction = line.ToCharArray()[0];
            switch (direction)
            {
                case 'L':
                    dial -= Convert.ToInt32(line.Substring(1));
                    break;
                case 'R':
                    dial += Convert.ToInt32(line.Substring(1));
                    break;
            }
            if (dial%100 == 0) counter++;
        }
        Console.WriteLine($"It hit {counter} times");
    }
    void PartTwo()
    {
        int dial = 50;
        int counter = 0;
        var input = allFiles.DayOne.Split('\n');
        Console.WriteLine("This one should count when it goes beyond 0 and when it hits 0");
        bool startedAtZero = false;
        //like part one. but this time with divide 100 to count every variation and then ?
        foreach (var line in input)
        {
            char direction = line.ToCharArray()[0];
            switch (direction)
            {
                case 'L':
                    dial -= Convert.ToInt32(line.Substring(1));
                    break;
                case 'R':
                    dial += Convert.ToInt32(line.Substring(1));
                    break;
            }
            counter += Convert.ToInt32(Math.Floor(Convert.ToDouble(Math.Abs(dial) / 100)));
            if(dial < 0 && !startedAtZero)counter++;
            if (dial == 0) counter++;

            dial = dial % 100;
            if (dial == 0) startedAtZero = true; else startedAtZero= false;
            if (dial < 0) dial += 100;
        }
        Console.WriteLine($"It counts: {counter}");
    }
}
