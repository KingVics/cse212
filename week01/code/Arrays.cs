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
        // Plan:
        // 1. Create a new array with the requested length so there is one slot for each multiple.
        // 2. Use a loop that visits each index from 0 up to length - 1.
        // 3. For each position, calculate the multiple by multiplying the original number by
        //    the position number plus 1, since the first result should be 1 * number, not 0 * number.
        // 4. Store that calculated multiple into the matching array index.
        // 5. After the loop finishes, return the completed array.
        double[] newArray = new double[length];

        for (int i = 0; i < length; i++)
        {
            newArray[i] = number * (i + 1);
        }

        return newArray;
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
        // Plan:
        // 1. Save the number of items in the list so it can be reused in the rotation logic.
        // 2. If the list has fewer than 2 items, stop because rotating would not change anything.
        // 3. Reduce the rotation amount with modulus so values equal to the list size wrap correctly.
        // 4. If the adjusted amount is 0, stop because the list would end up unchanged.
        // 5. Reverse the entire list so the items that should move to the front are now at the beginning.
        // 6. Reverse just the first 'amount' items to restore their original order.
        // 7. Reverse the remaining items to restore their original order.
        // 8. The list has now been rotated to the right in place, so no return value is needed.
        int count = data.Count;
        if (count < 2)
            return;

        amount %= count;
        if (amount == 0)
            return;

        data.Reverse();
        data.Reverse(0, amount);
        data.Reverse(amount, count - amount);
    }


}

