using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
public void RemoveHead()
{
    // If the list is empty, just return
    if (_head == null)
    {
        return;
    }

    // If there's only one node in the list
    if (_head == _tail)
    {
        _head = null;
        _tail = null;
    }
    else
    {
        // Remove the head by updating the pointers
        if (_head.Next != null)//+
        {//+
            _head.Next.Prev = null;  // Disconnect the old head's next node from it//+
        }//+
        _head = _head.Next;       // Move the head pointer to the next node
    }
}


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
public void RemoveTail()
{
    if (_head == _tail) // If only one element exists
    {
        _head = null;
        _tail = null;
    }
    else if (_tail != null) // Check if tail is not null
    {
        _tail = _tail.Prev; // Move tail back
        if (_tail != null) // Ensure that tail is not null before accessing Next
        {
            _tail.Next = null;  // Nullify the new tail's Next pointer
        }
    }
}

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
public void Remove(int value)
{
    Node? curr = _head;
    while (curr != null)
    {
        if (curr.Data == value)
        {
            if (curr == _head)
            {
                RemoveHead(); // Remove head if it matches
            }
            else if (curr == _tail)
            {
                RemoveTail(); // Remove tail if it matches
            }
            else
            {
                // Ensure prev and next are not null before updating their pointers
                if (curr.Prev != null && curr.Next != null)
                {
                    curr.Prev.Next = curr.Next;   // Link the previous node's Next to the next node
                    curr.Next.Prev = curr.Prev;   // Link the next node's Prev to the previous node
                }
            }
            return; // Exit after removal
        }
        curr = curr.Next; // Move to the next node
    }
}

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
public void Replace(int oldValue, int newValue)
{
    Node? curr = _head;
    while (curr != null)
    {
        if (curr.Data == oldValue)
        {
            curr.Data = newValue;
        }
        curr = curr.Next; // Move to the next node
    }
}


    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        var curr = _tail; // Start from the tail of the list.
        while (curr != null)
        {
            yield return curr.Data; // Yield the data of the current node.
            curr = curr.Prev; // Move backward in the linked list.
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    // Helper class for the Node
    private class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
