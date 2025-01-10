using System;
using System.Collections.Generic;

public static class Divisors {
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}");
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); 
    }
    private static List<int> FindDivisors(int number) {
        List<int> results = new List<int>();
        for (int i = 1; i < number; i++) {
            if (number % i == 0) {
                results.Add(i);
            }
        }

        return results;
    }
}
