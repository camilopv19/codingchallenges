// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;

public class MergeSort
{
    public static void Main(string[] args)
    {
        /********************* TODO implement Get with start and end
        */
        int[] nums = new int[11] { 2, 1, 25, 6, 4, 10, 9, 3, 33, 8, 7 };
        var unsorted = nums2LList(nums);
        var sorted = MSort(unsorted);
        sorted.Show();

        /*print( nameof(nums) + " array is " + (ValidateSort(nums) ? "Sorted" : "Not sorted"));
        print( nameof(sorted) + " array is " + (ValidateSort(sorted) ? "Sorted" : "Not sorted"));*/
    }

    public static LinkedList MSort(LinkedList list)
    {
        if (list.Head == null || list.Size() == 1) return list;

        var (left, right) = Split(list);
        var leftList = MSort(left);
        var rightList = MSort(right);
        return Merge(leftList, rightList);
    }

    private static LinkedList Merge(LinkedList left, LinkedList right)
    {
        int i = 0, j = 0;
        var merged = new LinkedList();
        merged.Add(0);                       // Init a head to be discarded later
        Node current = merged.Head;         // Get all heads
        Node leftHead = left.Head;
        Node rightHead = right.Head;

        // Iterate through both lists until reaching the tail of anyone
        while (rightHead != null || leftHead != null)
        {
            // If the leftHead is null, the tail was reached, so rightHead should be added to the list
            if (leftHead == null)
            {
                current.Next = rightHead;
                rightHead = rightHead.Next;  // Calling next for loop stopping condition
            }
            // If the rightHead is null, the tail was reached, so leftHead should be added to the list
            else if (rightHead == null)
            {
                current.Next = leftHead;
                leftHead = leftHead.Next;  // Calling next for loop stopping condition
            }
            else
            {
                // No tail reached: Compare node values
                var leftValue = leftHead._value;
                var rightValue = rightHead._value;
                if (leftValue < rightValue)
                {
                    current.Next = leftHead;
                    // Move leftHead to next node
                    leftHead = leftHead.Next;
                }
                else
                {
                    current.Next = rightHead;
                    // Move rightHead to next node
                    rightHead = rightHead.Next;
                }
            }
            current = current.Next;
        }

        // Discard fake Head and set first merged node as head
        // As current was initialized with the head, the merging while loop set Next node as the beginning of all merge
        // so by reference laws, merged.Head.Next should point to the same merged list
        var head = merged.Head.Next; 
        merged.Head = head;             // Actual Head replacement with the merged list
        return merged;
    }

    public static LinkedList nums2LList(int[] arr)
    {
        var list = new LinkedList();
        foreach (int num in arr)
        {
            list.Add(num);
        }
        return list;
    }

    public static (LinkedList left, LinkedList right) Split(LinkedList list)
    {
        if (list.Size() <= 1) return (list, null);

        int mid = (int)(Math.Floor((double)(list.Size() / 2)));
        Node midNode = list.GetAt(mid - 1);     // this is a reference to the list
        var left = list;                        // now this is another reference
        var right = new LinkedList();
        right.Head = midNode.Next;
        midNode.Next = null;                    // list hence left have been resized
        return (left, right);
    }
}

public class Node
{
    public int _value;
    public Node Next = null;

    public Node(int value)
    {
        this._value = value;
    }

    public bool HasValue()
    {
        return this._value != 0;
    }
}

public class LinkedList
{
    public Node Head = null;

    public bool IsEmpty()
    {
        return this.Head == null;
    }

    // O(n) time
    public int Size()
    {
        Node current = this.Head;
        int count = 0;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    // O(n) time
    public Node Search(int value)
    {
        Node current = this.Head;
        while (current != null)
        {
            if (current._value == value)
            {
                return current;
            }
            else
            {
                current = current.Next;
            }
        }
        return null;
    }


    // O(n) time
    public Node Insert(int value, int index)
    {
        if (index == 0)
        {
            this.Add(value);
            return new Node(value);
        }

        if (index > 0)
        {
            var newNode = new Node(value);
            if (index >= this.Size())
            {
                index = this.Size();
            }
            var position = index;
            var current = this.Head;

            while (position > 1)
            {
                current = current.Next;
                position--;
            }
            var previous = current;
            var nextNode = current.Next;
            previous.Next = newNode;
            newNode.Next = nextNode;
            return newNode;
        }
        return null;
    }

    // O(n) time
    public Node Delete(int value)
    {
        var current = this.Head;
        var previous = current;
        bool found = false;

        while (!found && current != null)
        {
            if (current._value == value && current == this.Head)
            {
                found = true;
                this.Head = current.Next;
            }
            else if (current._value == value)
            {
                found = true;
                previous.Next = current.Next;
            }
            else
            {
                previous = current;
                current = current.Next;
            }
        }
        return current;
    }

    // O(1) time
    public void Add(int value)
    {
        var newNode = new Node(value);
        newNode.Next = this.Head;
        this.Head = newNode;
    }

    // O(n) time
    public void Show()
    {
        Node current = this.Head;
        List<string> nodes = new();
        while (current != null)
        {
            if (current == this.Head)
            {
                nodes.Add($"[Head]:{current._value}");
            }
            else if (current.Next == null)
            {
                nodes.Add($"[Tail]:{current._value}");
            }
            else
            {
                nodes.Add($"{current._value}");
            }
            current = current.Next;
        }

        Console.WriteLine(string.Join("->", nodes));
    }

    // O(n) time
    public Node GetAt(int index)
    {
        Node current = this.Head;
        if (index == 0) return current;

        int position = 0;
        while (position < index)
        {
            current = current.Next;
            position++;
        }
        return current;
    }
}
