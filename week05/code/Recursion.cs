using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: If n is 0 or negative, return 0
        if (n <= 0)
        {
            return 0;
        }

        // Recursive case: n^2 + sum of squares of (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if the word length equals the desired size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: iterate over letters, building permutations
        for (int i = 0; i < letters.Length; i++)
        {
            string newLetters = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, newLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb a staircase with 's' steps,
    /// allowing steps of 1, 2, or 3 at a time, using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base Cases
        if (s == 0) return 1;
        if (s < 0) return 0;

        // Check memoized results
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Recursive calculation with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    /// 
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first occurrence of '*'
        int index = pattern.IndexOf('*');

        // Base case: if no '*' is found, add the pattern to results
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace '*' with '0' and '1', then recurse
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, SimpleMaze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Base case: If we reached the end, add the path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(string.Join(" -> ", currPath));
            return;
        }

        // Add current position to path
        currPath.Add((x, y));

        // Try moving in all four directions
        foreach (var (dx, dy) in new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) })
        {
            int newX = x + dx;
            int newY = y + dy;

            if (maze.IsValidMove(newX, newY, currPath))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack by removing the last added position
        currPath.RemoveAt(currPath.Count - 1);
    }
}

public class SimpleMaze
{
    // Dummy implementation for the Maze class
    // Replace with your actual maze logic (e.g., grid, start/end points)

    public bool IsEnd(int x, int y)
    {
        // Example condition for the end: (x, y) == (3, 3)
        return x == 3 && y == 3;
    }

    public bool IsValidMove(int x, int y, List<ValueTuple<int, int>> currPath)
    {
        // Example validation: Ensure (x, y) is within bounds and not already visited
        return x >= 0 && y >= 0 && !currPath.Contains((x, y));
    }
}
