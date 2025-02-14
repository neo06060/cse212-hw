using System;

public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        if (sortedNumbers == null || sortedNumbers.Length == 0)
            return bst;

        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of the current range into the binary search tree.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int middle = (first + last) / 2;
        bst.Insert(sortedNumbers[middle]);  // Insert the middle element into the BST

        InsertMiddle(sortedNumbers, first, middle - 1, bst);  // Insert the left half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);   // Insert the right half
    }
}
