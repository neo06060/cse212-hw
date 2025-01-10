using System;

public static class Search {
    public static void Run() {
        var sortedArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine("Searching for 5 using SearchSorted1...");
        int target1 = 5;
        bool result1 = SearchSorted1(sortedArray, target1);
        Console.WriteLine(result1 ? $"Found {target1}!" : $"{target1} not found.");
        Console.WriteLine("Searching for 5 using SearchSorted2...");
        bool result2 = SearchSorted2(sortedArray, target1);
        Console.WriteLine(result2 ? $"Found {target1}!" : $"{target1} not found.");
        int targetNotFound = 11;
        Console.WriteLine("Searching for 11 using SearchSorted1...");
        bool resultNotFound1 = SearchSorted1(sortedArray, targetNotFound);
        Console.WriteLine(resultNotFound1 ? $"Found {targetNotFound}!" : $"{targetNotFound} not found.");
        Console.WriteLine("Searching for 11 using SearchSorted2...");
        bool resultNotFound2 = SearchSorted2(sortedArray, targetNotFound);
        Console.WriteLine(resultNotFound2 ? $"Found {targetNotFound}!" : $"{targetNotFound} not found.");
    }
    public static bool SearchSorted1(int[] sortedArray, int target) {
        for (int i = 0; i < sortedArray.Length; i++) {
            if (sortedArray[i] == target)
                return true;
        }
        return false;
    }
    public static bool SearchSorted2(int[] sortedArray, int target) {
        int left = 0, right = sortedArray.Length - 1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (sortedArray[mid] == target)
                return true;
            else if (sortedArray[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return false;
    }
}
