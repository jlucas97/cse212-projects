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
        // This creates a new node
        Node newNode = new(value); 

        // If the list is empty, we set both head and tail into a new node
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        //  Link current tail to new node, Link new node back to current tail and Update tail to the new node
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
    // If the list is empty or contains only one node,
    // removing the head results in an empty list.
    if (_head == _tail)
    {
        _head = null;
        _tail = null;
    }
    // If the list contains more than one node,
    // update the head to the next node.
    else if (_head is not null)
    {
        // Disconnect the current head from the rest of the list
        _head.Next!.Prev = null;

        // Move the head reference to the next node
        _head = _head.Next;
    }
}



    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
{
    // If the list is empty or contains only one node,
    // removing the tail results in an empty list.
    if (_head == _tail)
    {
        _head = null;
        _tail = null;
    }
    // If the list contains more than one node,
    // update the tail to the previous node.
    else if (_tail is not null)
    {
        // Disconnect the current tail from the list
        _tail.Prev!.Next = null;

        // Move the tail reference to the previous node
        _tail = _tail.Prev;
    }
}

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    /// <summary>
/// Insert 'newValue' after the first occurrence of 'value' in the linked list.
/// </summary>
public void InsertAfter(int value, int newValue)
{
    // Start searching from the head of the list
    Node? curr = _head;

    // Traverse the list until the value is found or the end is reached
    while (curr is not null)
    {
        // Check if the current node contains the target value
        if (curr.Data == value)
        {
            // If the matching node is the tail,
            // insert the new value at the end of the list
            if (curr == _tail)
            {
                InsertTail(newValue);
            }
            // Otherwise, insert the new node between two existing nodes
            else
            {
                // Create the new node
                Node newNode = new(newValue);

                // Connect the new node to the current node
                newNode.Prev = curr;

                // Connect the new node to the next node
                newNode.Next = curr.Next;

                // Update the next node to point back to the new node
                curr.Next!.Prev = newNode;

                // Update the current node to point forward to the new node
                curr.Next = newNode;
            }

            // Exit after inserting the new node
            return;
        }

        // Move to the next node in the list
        curr = curr.Next;
    }
}


    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
{
    // Start searching from the head of the list
    Node? curr = _head;

    // Traverse the list until the value is found or the end is reached
    while (curr is not null)
    {
        // Check if the current node contains the value to remove
        if (curr.Data == value)
        {
            // If the node is the head, delegate to RemoveHead
            if (curr == _head)
            {
                RemoveHead();
            }
            // If the node is the tail, delegate to RemoveTail
            else if (curr == _tail)
            {
                RemoveTail();
            }
            // Otherwise, the node is in the middle of the list
            else
            {
                // Link the previous node to the next node
                curr.Prev!.Next = curr.Next;

                // Link the next node back to the previous node
                curr.Next!.Prev = curr.Prev;
            }

            // Exit after removing the first matching node
            return;
        }

        // Move to the next node in the list
        curr = curr.Next;
    }
}

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
{
    // Start traversal from the head of the list
    Node? curr = _head;

    // Traverse the entire linked list
    while (curr is not null)
    {
        // If the current node contains the value to replace
        if (curr.Data == oldValue)
        {
            // Replace the old value with the new value
            curr.Data = newValue;
        }

        // Move to the next node in the list
        curr = curr.Next;
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
    public IEnumerable Reverse()
{
    // Start traversal from the tail of the list
    Node? curr = _tail;

    // Traverse the list backwards using Prev references
    while (curr is not null)
    {
        // Yield the current node's data to the caller
        yield return curr.Data;

        // Move to the previous node in the list
        curr = curr.Prev;
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
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}