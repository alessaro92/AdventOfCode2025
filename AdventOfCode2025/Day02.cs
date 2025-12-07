namespace AdventOfCode2025;

public static class Day02
{
    public static long Part1(string inputFilePath)
    {
        string content = File.ReadAllText(inputFilePath);
        string[] ranges = content.Split(',');

        long sum = 0;

        foreach (string range in ranges)
        {
            string[] rangeNumbers = range.Split('-');
            long rangeStart = long.Parse(rangeNumbers[0]);
            long rangeEnd = long.Parse(rangeNumbers[1]);

            // Check for each number inside the range if the number of its digits is even and then compare the first half with the second
            for (long i = rangeStart; i <= rangeEnd; i++)
            {
                string currentNumberStr = i.ToString();
                if (currentNumberStr.Length % 2 != 0) continue;

                string firstHalf = currentNumberStr.Substring(0, currentNumberStr.Length / 2);
                string secondHalf = currentNumberStr.Substring(currentNumberStr.Length / 2);

                if (firstHalf == secondHalf) sum += i;
            }
        }

        return sum;
    }

    public static long Part2(string inputFilePath)
    {
        string content = File.ReadAllText(inputFilePath);
        string[] ranges = content.Split(',');

        long sum = 0;

        foreach (string range in ranges)
        {
            string[] rangeNumbers = range.Split('-');
            long rangeStart = long.Parse(rangeNumbers[0]);
            long rangeEnd = long.Parse(rangeNumbers[1]);

            // Same, but check if the string can be subdivided evenly for each possible substring size from its length to 2
            for (long i = rangeStart; i <= rangeEnd; i++)
            {
                string currentNumberStr = i.ToString();
                int currentNumberLength = currentNumberStr.Length;
                for (int j = currentNumberLength; j >= 2; j--)
                {
                    if (currentNumberStr.Length % j != 0) continue;

                    string[] chunks = currentNumberStr.Chunk(currentNumberStr.Length / j).Select(s => new string(s)).ToArray();

                    bool equal = true;
                    for (int k = 0; k < chunks.Length - 1; k++)
                    {
                        if (chunks[k] != chunks[k + 1])
                        {
                            equal = false;
                            break;
                        }
                    }

                    if (equal)
                    {
                        sum += i;
                        break;
                    }
                }
            }
        }

        return sum;
    }
}
