public class Node
{
    public int Value { get; set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        Value = data;  
        Left = null;
        Right = null;
    }

    public void Insert(int value)
    {
        if (value < Value)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Value) // Prevents duplicate values
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // No action is taken if value == Value, so duplicates are ignored
    }

    public bool Contains(int value)
    {
        if (value == Value)
            return true;
        else if (value < Value)
            return Left?.Contains(value) ?? false;
        else
            return Right?.Contains(value) ?? false;
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight); // The height is 1 + the largest subtree height
    }
}
