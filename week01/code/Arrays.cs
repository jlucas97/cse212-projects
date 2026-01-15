public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1) A new array of doubles is created with the requested size (length).
        // 2) Loop from 0 up to array length.
        // 3) For each index i, the number is multiplied by (i + 1).
        // 4) Store the value into the array at position i add it to the array and return the loop ends.

        var result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1) Find out how many items are in the list (n = data.Count).
        // 2) Find the index where we "cut" the list so the last 'amount' elements move to the front:
        //      cutIndex = n - amount
        // 3) Slice the list into two parts:
        //      left  = data[0..cutIndex-1]   (the first n-amount items)
        //      right = data[cutIndex..end]  (the last amount items)
        // 4) Clear the original list (because we must modify it in-place).
        // 5) Add the 'right' part first, then add the 'left' part.
        // 6) Data is now rotated to the right by 'amount'.


        int n = data.Count;
        int cutIndex = n - amount;

        List<int> left = data.GetRange(0, cutIndex);
        List<int> right = data.GetRange(cutIndex, amount);

        data.Clear();
        data.AddRange(right);
        data.AddRange(left);
    }
}
