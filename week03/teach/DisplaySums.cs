﻿using System;
using System.Collections.Generic;

public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        // Should show:
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs(new[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });
        // Should show:
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs(new[] { 5, 11, 2, -4, 6, 8, -1 });
        // Should show:
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time. We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">Array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        var seen = new HashSet<int>();

        foreach (var number in numbers) {
            var complement = 10 - number;

            if (seen.Contains(complement)) {
                Console.WriteLine($"{number} {complement}");
            }

            seen.Add(number);
        }
    }
}
