using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;

public class LinkedLists
{
    public static void Main(string[] args)
    {
        LinkedList L1 = new ();
        L1.Add(4);
        L1.Add(99);
        L1.Add(9);
        L1.Add(3);
        L1.Size();
        L1.Show();
    }
}

public class Node{
    public int _value;
    public Node Next = null;
    
    public Node (int value){
        this._value = value;    
    }
}

public class LinkedList{
    public Node Head = null;
    
    public bool IsEmpty(){
        return this.Head == null;
    }
    
    // O(n) time
    public void Size(){
        Node _current = this.Head;
        int count = 0;
        while(_current != null){
            count++;
            _current = _current.Next;
        }
        Console.WriteLine(count);
    }
    
    // O(1) time
    public void Add(int value){
        var newNode = new Node(value);
        newNode.Next = this.Head;
        this.Head = newNode;
    }
    
    // O(n) time
    public void Show(){
        Node current = this.Head;
        List<string> nodes = new();
        while(current != null){
            if(current == this.Head) {
                nodes.Add($"[Head]:{current._value}");
            }
            else if(current.Next == null) {
                nodes.Add($"[Tail]:{current._value}");
            }
            else{
                nodes.Add($"{current._value}");
            }
            current = current.Next;
        }
        
        Console.WriteLine(string.Join("->",nodes));
    }
}
