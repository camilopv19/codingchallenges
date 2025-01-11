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

        int[] nums = new int[11]{1,2,5,6,4,10,9,3,33,8,7}; // O(1)

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
