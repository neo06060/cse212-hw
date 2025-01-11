using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Initialize an array to store the multiples of 'number'.
        double[] multiples = new double[length];

        // Step 2: Loop through the array and fill it with multiples of the 'number'.
        for (int i = 0; i < length; i++)
        {
            // Step 3: For each index, the value will be 'number' multiplied by (i + 1)
            multiples[i] = number * (i + 1); // This gives us the multiples.
        }

        // Step 4: Return the filled array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Ensure that the rotation amount is within the valid range (1 to data.Count).
        amount = amount % data.Count; // If amount exceeds data.Count, only rotate by the remainder.

        // Step 2: Slice the list into two parts.
        // - 'rightPart' contains the last 'amount' elements of the list.
        // - 'leftPart' contains the remaining elements of the list.
        List<int> rightPart = data.GetRange(data.Count - amount, amount); // Get last 'amount' elements
        List<int> leftPart = data.GetRange(0, data.Count - amount); // Get the rest of the list

        // Step 3: Clear the original list and add the parts in the correct order.
        data.Clear(); // Clear the existing data in the list.
        data.AddRange(rightPart); // Add the 'rightPart' (the last 'amount' elements) at the front.
        data.AddRange(leftPart); // Add the 'leftPart' (the remaining elements) after the 'rightPart'.
    }
}
