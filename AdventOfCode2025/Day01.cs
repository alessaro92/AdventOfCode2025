namespace AdventOfCode2025;

public static class Day01
{
    public static int Part1(string inputFilePath)
    {
        int startingPoint = 50;

        string[] lines = File.ReadAllLines(inputFilePath);

        int currentPoint = startingPoint;

        int zeroCounter = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line)) break;

            // The dial numbers are from 0 through 99
            int distance = int.Parse(line.Substring(1)) % 100;

            switch (line[0])
            {
                case 'L':
                    currentPoint -= distance;
                    break;
                case 'R':
                    currentPoint += distance;
                    break;
            }

            if (currentPoint >= 100) currentPoint -= 100;
            else if (currentPoint < 0) currentPoint += 100;

            if (currentPoint == 0) zeroCounter++;
        }

        return zeroCounter;
    }
}
