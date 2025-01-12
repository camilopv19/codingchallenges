using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;

/**************************************************************
* Linked list must have nodes, which define their next or previous item 
* Singly-linked list only have one node direction: Next
* Doubly-linked list both node directions: Next and Previous
* 
* Linked list must satisfy these node actions:
* - Insert
* - Delete
* - Search
*/
public class LinkedLists
{
    public static void Main(string[] args)
    {
        LinkedList L1 = new();
        L1.Add(4);
        L1.Add(99);
        L1.Add(9);
        L1.Add(3);
        L1.Show();
        
        var search = L1.Search(1);
        Console.WriteLine(search != null ? search._value : "Not found");
        var search1 = L1.Search(99);
        Console.WriteLine(search1 != null ? search1._value : "Not found");
        
        L1.Insert(1, 0);
        L1.Insert(44, 3);
        L1.Insert(666, 15);
        L1.Show();
        L1.Delete(1);
        L1.Show();
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
            if(current._value == value){                
                return current;
            }else
            {
                current = current.Next;
            }
        }
        return null;
    }
    
    
    // O(n) time
    public Node Insert(int value, int index)
    {
        /* Approach: Traverse the list by setting a position = index, which decrements on
        * each iteration and finds the node at that index. 
        */

        // Simple Add when the insert is at the Head
        if(index == 0) {
            this.Add(value); 
            return new Node(value);
        }
        
         // Adding everything "else"
        if(index > 0){
            var newNode = new Node(value);
            
            // Set ceiling if index exceeds size
            if(index >= this.Size()) {
                index = this.Size();
            }
            var position = index;
            var current = this.Head;
            
            
            /* We know index > 0, so we need to start storing the next node until
            * we reach position = 1, which means we are at the Node before our 
            * position.
            */
            while (position > 1)
            {
                current = current.Next;    
                //Console.WriteLine($"Current {current._value} in position {position}");
                position--;
            }
            
            /* On that position we define the new nodes references: 
            * [current]   --------------->  [current.next]
                  ||                              ||
            * [previous]------>[newNode]------>[nextNode]
            *            Next            Next
            */
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
        // Search for the position and dereference both ends
        var current = this.Head;
        var previous = current;
        bool found = false;
        
        while(!found && current != null){
            // Head has the found value
            if(current._value == value && current == this.Head){
                found = true;
                this.Head = current.Next;
            }  
            
            /**                              value found
            **    [..]-->[previous]-->[current to be dereferenced]-->[previous.next] 
            **
            **  previous is defined in the last else block, when value is not found
            */
            else if(current._value == value){
                found = true;
                previous.Next = current.Next;
            }
            //    [..]-->[previous=current]-->[current.next]        
            else{
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
}
