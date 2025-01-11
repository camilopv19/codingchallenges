// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
using System.Diagnostics;
using System;
using System.Linq;

public class BinarySearch
{
    public static void Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();

        int[] nums = new int[100]{ 432, 186, 488, 4, 216, 31, 416, 185, 347, 495, 496, 329, 99, 480, 146, 390, 160, 343, 318, 288, 6, 167, 483, 294, 48, 228, 274, 343, 434, 426, 89, 344, 337, 250, 348, 310, 425, 209, 188, 419, 135, 43, 371, 45, 215, 310, 443, 271, 5, 194, 270, 402, 114, 45, 31, 217, 290, 2, 74, 193, 55, 254, 246, 267, 28, 464, 375, 108, 97, 350, 327, 184, 10, 26, 489, 170, 53, 483, 118, 90, 5, 369, 115, 33, 350, 184, 403, 183, 339, 355, 417, 105, 323, 58, 185, 44, 402, 142, 457, 233 }; // O(1)

      // For BS to work proper and correctly, array MUST be sorted.
        Array.Sort(nums);   // O(n) time
        printArr(nums);     // O(n) time
        binarySearch(nums, 2);
        stopwatch.Stop();
        
        var elapsed = stopwatch.Elapsed;
        print($"{elapsed.ToString()} ms elapsed");
    }

        private static bool binarySearch(int[] arr, int target){
            int size = arr.Length;
            int start = 0;
            int end = size - 1;
            int idx = 0, mid = 0;
            
            while(start <= end){
                mid = (int)(Math.Floor((double)((start + end) /2)));
                
                // First happy path: Target at middle position
                if(arr[mid] == target) {
                    print($"Value found at position {mid}");
                    return true;
                }
                else if(target > arr[mid]){
                    start = mid + 1;
                }
                else{
                    end = mid - 1;
                }
            }
            print("Value not found");
            return false;
        }
        
        private static void printArr(int[] arrInput){
            //Array.Reverse(arrInput);
            var num = string.Join(",", arrInput.Select(x => x.ToString()).ToArray());
            // foreach(int num in arrInput){
                Console.WriteLine($"{num}");
            //}
        }
        
        private static void print(double input, string name){
                Console.WriteLine($"{name}: {input}");
        }
        
        private static void print(string msg){
                Console.WriteLine($"{msg}");
        }
}
