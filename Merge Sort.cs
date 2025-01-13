// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;

public class MergeSort
{
    public static void Main(string[] args)
    {
        int[] nums = new int[11]{2,1,25,6,4,10,9,3,33,8,7};
        int[] sorted = MSort(nums);
        print(sorted);
        print( nameof(nums) + " array is " + (ValidateSort(nums) ? "Sorted" : "Not sorted"));
        print( nameof(sorted) + " array is " + (ValidateSort(sorted) ? "Sorted" : "Not sorted"));
    }
    
    // Time C : O(k * nLog(n))
    // Space C : O(n) The biggest part in size are the inital and final step of the merge.
    // With a more efficient way of splitting the arrays, the standard time C. would be:
    // O(nLog(n))
    public static int[] MSort(int[] arr){
        if(arr.Length <= 1) return arr;
        
        var result = Split(arr);            // O(k)
        var left = MSort(result.Left);      // O(n)
        var right = MSort(result.Right);    // O(n)
        return Merge(left, right);          // O(n * Log(n))
    }
    
    // The split on the array introduces k constant as the size of the new array.
    // O(k)
    private static SplitModel Split(int[] arr){
        int mid = (int)(Math.Floor((double)(arr.Length/2)));
        var result = new SplitModel();
        result.Right = arr[mid..];          // O(k)
        result.Left = arr[..mid];           // O(k)
        return result;
    }
    
    // O(nlog(n)) : Takes n times to merge the divided array with O(log(n))
    private static int[] Merge(int[] left, int[] right){
        int i = 0, j= 0;
        List<int> list = new List<int>(left.Length + right.Length);
        
        while(i < right.Length && j < left.Length){
            if(left[j] < right[i]){
                list.Add(left[j]);
                j++;
            }else{
                list.Add(right[i]);
                i++;
            }
        }
        
        // Handle when last while loop leaves behind any (R or L) branch with more elements
        // with the next 2 loops
        while(i < right.Length){
            list.Add(right[i]);
            i++;
        }
        while(j < left.Length){
            list.Add(left[j]);
            j++;
        }
        return list.ToArray();
    }
    
    // O(n)
    private static bool ValidateSort(int[] arr){
        if(arr.Length <= 1) return true;
        return arr[0] < arr[1] && ValidateSort(arr[1..]);   // Recursive method from second element
    }
    
    private static void print(int[] arr){
        Console.WriteLine(string.Join(",",arr.Select(x => x.ToString())));
    }
    private static void print(string msg){
        Console.WriteLine(msg);
    }
}
    
public struct SplitModel{
    public int[] Right;
    public int[] Left;
}
