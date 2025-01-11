// WCS: Worst Case Scenario
// BCS: Best Case Scenario
// NF: Best Case Scenario

using System.Diagnostics;
using System;
using System.Linq;

public class BinarySearch
{
    public static void Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();
        int MAX_VALUE = 99_999_999;
        int WCS_VALUE = 100_000_000;
        int BCS_VALUE = 1;
        int[] nums = Enumerable.Range(1, MAX_VALUE).ToArray(); // O(1)
        
        // For BS to work, array must be sorted
        // Array.Sort(nums);   // O(n) time
        // printArr(nums);     // O(n) time
       
        /*                                 
        binarySearch(nums, MAX_VALUE);      // 00:00:00.5987489
        binarySearch(nums, WCS_VALUE);      
        binarySearch(nums, BCS_VALUE);
        */
        /*
        linearSearch(nums, MAX_VALUE);      // 00:00:01.3701052
        linearSearch(nums, WCS_VALUE);      
        linearSearch(nums, BCS_VALUE);
        */
       
        print(binarySearchRecursive(nums, MAX_VALUE));
        print(binarySearchRecursive(nums, WCS_VALUE));
        print(binarySearchRecursive(nums, BCS_VALUE));
        
        stopwatch.Stop();
        
        var elapsed = stopwatch.Elapsed;
        print($"{elapsed.ToString()} time elapsed");
    }
    
    private static void linearSearch(int[] arr, int target){
        bool found = false;
        int idx = 0;
        
        for(int i=0 ; i<arr.Length; i++){
            if(arr[i]==target){
                idx = i;
                found = true;
                break;
            }
        }
        print(found, idx);
    }
    
    private static bool binarySearchRecursive(int[] arr, int target){
        //printArr(arr);
        int last = arr.Length - 1;
        
        // Break condition
        if((arr.Length == 1 && arr[0] != target) || target > arr[last]) {
            return false;
            
        } 
        else{
            int mid = (int)(Math.Floor((double)(arr.Length/2)));
            if(arr[mid] == target) {
                return true;
            }
            else if(target > arr[mid]){
                return binarySearchRecursive(arr[mid..], target);
            }
            else{
                return binarySearchRecursive(arr[..mid], target);
            }
        }
    }
    
    private static void binarySearch(int[] arr, int target){
        int size = arr.Length;
        int start = 0;
        int end = size - 1;
        int idx = 0, mid = 0;
        bool found = false;
        
        while(start <= end){
            mid = (int)(Math.Floor((double)((start + end) /2)));
            
            // First happy path: Target at middle position
            if(arr[mid] == target) {
                idx = mid;
                found = true;
                break;
            }
            else if(target > arr[mid]){
                start = mid + 1;
            }
            else{
                end = mid - 1;
            }
        }
        print(found, idx);
    }
    
    private static void printArr(int[] arrInput){
        //Array.Reverse(arrInput);
        var num = string.Join(",", arrInput.Select(x => x.ToString()).ToArray());
        Console.WriteLine($"{num}");
    }
    
    private static void print(bool found){
        Console.WriteLine(found ? "Value found!" : "Value not found");
    }
    
    private static void print(bool found, int idx){
        Console.WriteLine(found ? "Value found at " + idx : "Value not found");
    }
    
    private static void print(string msg){
        Console.WriteLine($"{msg}");
    }
}
