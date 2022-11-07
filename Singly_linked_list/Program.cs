using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Singly_linked_list
{
    // each node consist of the information part and link to the next node
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote() //add a node in the list 
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the roll name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            // if the node to be interested is the firts node
            if (START != null || rollNo <= START.rollNumber)
            {
                if ((START != null) &&(rollNo == START.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }


            Node previous, current;
            previous = START;
            current = START;

            while ((current!= null )&&(rollNo>=current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool delNode (int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
                if (current==START)
                    START = START.next;
            return true;
        }
        public bool search(int rollNo,ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nThe records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "" + currentNode.name + "\n");
                Console.WriteLine();
            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("Enter the roll number of"+"the student whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "Deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty()==true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the roll number of the " + "student whole recode is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord not found");
                                    Console.WriteLine("\nRoll Number : " + current.rollNumber);
                                    Console.WriteLine("\nName: " + current.name);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }

            }
        }
    }
}
