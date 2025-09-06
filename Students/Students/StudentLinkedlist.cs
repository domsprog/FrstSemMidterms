using Students;
using System.ComponentModel.Design;

public class StudentLinkedList
{
    private StudentNode Head;

    private bool IsValidStudent(Student student)
    {
        if ( student.ID <= 0)
        {
            Console.WriteLine("ID is invalid try again");
            return false;
        }
        else if (student.YearLevel<1 || student.YearLevel>5)
        {
            Console.WriteLine("Year level is invalid try again");
            return false;
        }
        else if (student.GPA < 0.0 || student.GPA > 4.0)
        {
            Console.WriteLine("GPA is invalid try again 0.0 - 4.0");
            return false;
        }
        return true;
    }
    private bool IsDuplicateID(int id)
    {
        StudentNode current = Head;
        while (current != null)
        {
            if (current.Data.ID == id)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void InsertAtBeginning(Student newStudent)
    {
        if (IsDuplicateID(newStudent.ID))
        {
            Console.WriteLine("Student ID already exists.");
        }
        else if (!IsValidStudent(newStudent))
        {
            Console.WriteLine(" Student data is not valid. Record not inserted.");
        }
        else
        {
            StudentNode newNode = new StudentNode(newStudent);
            newNode.Next = Head;
            Head = newNode;
            Console.WriteLine(" Student inserted at beginning.");
        }
    }
    public void InsertAtEnd(Student newStudent)
    {
        if (IsDuplicateID(newStudent.ID))
        {
            Console.WriteLine(" Student ID already exists.");
        }
        else if (IsValidStudent(newStudent))
        {
            StudentNode newNode = new StudentNode(newStudent);

            if ( Head == null)
            {
                Head = newNode;
            }
            else
            {
                StudentNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Console.WriteLine(" Student added at end.");
        }
        else
        {
            Console.WriteLine("Invalid student data.");
        }
    }

    public void InsertAtPosition(Student newStudent, int position)
    {
      
        if (IsDuplicateID(newStudent.ID))
        {
            Console.WriteLine("Student ID already exists");
        }
      
        else if (!IsValidStudent(newStudent))
        {
            Console.WriteLine(" Error: Invalid student data.");
        }
       
        else if (position <= 0)
        {
            Console.WriteLine("Position must be greater than0.");
        }
        else
        {
            StudentNode newNode = new StudentNode(newStudent);


            if (position == 1)
            {
                newNode.Next = Head;
                Head = newNode;
                Console.WriteLine(" Student inserted at position 1.");
            }
            else
            {
                StudentNode current = Head;
                int index = 1;

 
                while (current != null && index < position - 1)
                {
                    current = current.Next;
                    index++;
                }

                if (current == null)
                {
                    Console.WriteLine(" Error: Position out of range. Current list is shorter.");
                }
                else
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Console.WriteLine($" Student inserted at position {position}.");
                }
            }
        }
    }

    public void DeleteByID(int id)
    {
        if (Head == null) return;

        if (Head.Data.ID == id)
        {
            Head = Head.Next;
            return;
        }

        StudentNode current = Head;
        while (current.Next != null && current.Next.Data.ID != id)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public Student SearchByID(int id)
    {
        StudentNode current = Head;
        while (current != null)
        {
            if (current.Data.ID == id)
                return current.Data;

            current = current.Next;
        }
        return null;
    }

    public void SearchByName(string name)
    {

        if (Head == null)
        {
            Console.WriteLine(" The list is empty.");
            return  ;
        }
        StudentNode current = Head;
        bool found = false;

        while (current != null)
        {
            if (current.Data.First_name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($" Found: {current.Data.ID} - {current.Data.First_name} {current.Data.Last_name}, GPA: {current.Data.GPA}");
                found = true;
            }
            current = current.Next;
        } 
        if (!found)
        {
            Console.WriteLine($" No student found with the name \"{name}\".");
        }
    }

    public bool UpdateStudent(int id, string newFirstName, string newLastName, string newCourse, int newYear, double newGPA)
    {
        Student student = SearchByID(id);
        if (student != null)
        {
            student.First_name = newFirstName;
            student.Last_name = newLastName;
            student.Course = newCourse;
            student.YearLevel = newYear;
            student.GPA = newGPA;
            return true;
        }
        return false;
    }

    public Student DisplayByRecord()
    {
        if (Head == null)
        {
            Console.WriteLine(" No student records.");
            return null;
        }

        StudentNode current = Head;
        Student lastDisplayed = null;

        while (current != null)
        {
            Console.Clear();

            Console.WriteLine(" Student Record");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"ID: {current.Data.ID}");
            Console.WriteLine($"First Name: {current.Data.First_name}");
            Console.WriteLine($"Last Name: {current.Data.Last_name}");
            Console.WriteLine($"Age: {current.Data.Age}");
            Console.WriteLine($"Gender: {current.Data.Gender}");
            Console.WriteLine($"Contact Number: {current.Data.Contact_number}");
            Console.WriteLine($"Email: {current.Data.Email}");
            Console.WriteLine($"Course: {current.Data.Course}");
            Console.WriteLine($"Year Level: {current.Data.YearLevel}");
            Console.WriteLine($"GPA: {current.Data.GPA}");
            Console.WriteLine("-----------------------------");

            lastDisplayed = current.Data;

            Console.WriteLine(" Press ENTER to view next student (or ESC to exit)...");
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }

            current = current.Next;
        }
        return lastDisplayed;
    }
}
