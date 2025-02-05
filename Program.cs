public class Solution {
    public void NextPermutation(int[] nums) {
        // Find the next lexicographically greater permutation of a given array of integers.

        if (nums.Length <= 1) return;
        // If the array has 0 or 1 element, it's already its only permutation, so we're done.
        //  [] or [5] -> No change needed

        int i = nums.Length - 2;
        // Start from the second-to-last element and move leftwards.
        // Example: [1, 5, 8, 4, 7, 6, 5, 3, 1]
        //              ^ i starts here

        while (i >= 0 && nums[i] >= nums[i + 1]) {
        // Find the first element from the right that is smaller than the element to its right. This is our "pivot".
        // This loop essentially finds the longest decreasing suffix
        // [1, 5, 8, 4, 7, 6, 5, 3, 1]
        //              ^ i         ^ i+1  (8 >= 4? No, so we stop here, 8 is NOT part of decreasing suffix)
        //              (4 >= 7? No, keep going)
        //                 (7 >= 6? No, keep going)
        //                    (6 >= 5? No, keep going)
        //                       (5 >= 3? No, keep going)
        //                          (3 >= 1? No, keep going)
            i--;
        }

        // Visualization of finding the pivot (decreasing suffix is highlighted):
        // [1, 5, 8, 4, 7, 6, 5, 3, 1]
        //  |     |  |______________ ____|
        //  |     |        decreasing suffix
        //  |     pivot

        if (i >= 0) {
        // If we found a pivot (i.e., the array is not entirely in descending order).
        // In the above example, i will be the index of 4 (the pivot). If the array was [5,4,3,2,1] i would be -1 after the loop.

            int j = nums.Length - 1;
            // Start from the last element.
            // [1, 5, 8, 4, 7, 6, 5, 3, 1]
            //                          ^ j starts here

            while (nums[j] <= nums[i]) {
            // Find the first element from the right that is greater than the pivot. This will be the smallest element in the decreasing suffix that is larger than the pivot
            // [1, 5, 8, 4, 7, 6, 5, 3, 1]
            //                          ^ j (1 <= 4? No, keep going)
            //                       ^ j    (3 <= 4? No, keep going)
            //                    ^ j       (5 <= 4? No, stop here)
                j--;
            }

            // Visualization of finding the element to swap with the pivot:
            // [1, 5, 8, 4, 7, 6, 5, 3, 1]
            //  |     |        |__________|
            //  |     pivot     element to swap (smallest element greater than pivot in the decreasing suffix)

            (nums[i], nums[j]) = (nums[j], nums[i]);
            // Swap the pivot with the element we just found.
            // [1, 5, 8, 5, 7, 6, 4, 3, 1]
            //          ^        ^
            //          i        j  (swap these two)
        }

        // Visualization after the swap:
        // [1, 5, 8, 4, 7, 6, 5, 3, 1]  (before swap)
        //  |     |
        //  |     pivot
        // [1, 5, 8, 5, 7, 6, 4, 3, 1]  (after swap)
        //          |
        //        new pivot position
        //  |     |  |______________ ____|
        //  |     |        still decreasing suffix

        Array.Reverse(nums, i + 1, nums.Length - (i + 1));
        // Reverse the portion of the array to the right of the pivot's original position. This turns the decreasing suffix into an increasing one, making it the smallest possible sequence.
        // This is because we need to find the *next* permutation, so we sort the right side in ascending order after swapping
        // [1, 5, 8, 5, 7, 6, 4, 3, 1]  (reverse from index i+1 to the end)
        //             ^ i+1 (start of the decreasing suffix originally)
        // [1, 5, 8, 5, 1, 3, 4, 6, 7] (after reversing the suffix)

        // Visualization after reversing:
        // [1, 5, 8, 5, 7, 6, 4, 3, 1]  (before reversing)
        //  |     |  |______________ ____|
        //  |     |        decreasing suffix
        // [1, 5, 8, 5, 1, 3, 4, 6, 7] (after reversing)
        //  |     |  |______________ ____|
        //  |     |        increasing suffix (smallest possible sequence)
    }
}
