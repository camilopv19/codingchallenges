using System;
using System.Collections.Generic;
using System.Linq;

public class MergeSort
{
    public static void Main(string[] args)
    {
        int[] nums = new int[11] { 2, 1, 25, 6, 4, 10, 9, 3, 33, 8, 7 };
        var unsorted = nums2LList(nums);
        var sorted = MSort(unsorted);
        sorted.Show();
    }

    // Worst case scenario: O( n k log(n))
    public static LinkedList MSort(LinkedList list)
    {
        if (list.IsEmpty() || list.Size() == 1) return list;

        var (left, right) = Split(list);    // O(k log(n))
        var leftList = MSort(left);         // Split + Sort
        var rightList = MSort(right);       // Split + Sort
        return Merge(leftList, rightList);  // O(n)
    }

    // O(n)
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

    // O( k log(n)) as k being the size of the sublist or "k times the split operations"
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
