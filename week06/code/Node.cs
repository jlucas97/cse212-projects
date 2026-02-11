public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If value is equal, do nothing (no duplicates allowed)
        if (value == Data)
        {
            return;
        }

        // If value is smaller, insert in left subtree
        if (value < Data)
        {
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }



    public bool Contains(int value)
    {
        // If the current node matches the value, return true
        if (value == Data)
        {
            return true;
        }

        // If the value is smaller, search in the left subtree
        if (value < Data)
        {
            // If there is no left child, the value is not in the tree
            if (Left is null)
            {
                return false;
            }

            return Left.Contains(value);
        }

        // Otherwise, search in the right subtree
        // If there is no right child, the value is not in the tree
        if (Right is null)
        {
            return false;
        }

        return Right.Contains(value);
    }


    public int GetHeight()
    {
        // Height of left subtree (0 if null)
        int leftHeight = Left is null ? 0 : Left.GetHeight();

        // Height of right subtree (0 if null)
        int rightHeight = Right is null ? 0 : Right.GetHeight();

        // Current node adds 1 to the taller subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }

}