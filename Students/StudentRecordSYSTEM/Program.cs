using System;
using Students;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StudentLinkedList studentList = new StudentLinkedList();
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("   STUDENT RECORD SYSTEM");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by ID");
            Console.WriteLine("3. Search Student by Name");
            Console.WriteLine("4. Display Students By Record");
            Console.WriteLine("5. Update Student");
            Console.WriteLine("6. Delete Student by ID");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            bool validInput = int.TryParse(Console.ReadLine(), out choice);

            if (!validInput)
            {
                Console.WriteLine("Invalid input. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            Console.Clear();
            switch (choice)
            {
                case 1:
                    while (true)
                    {
                        int id;
                        while (true)
                        {
                            Console.Write("Enter ID: ");
                            if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                            {
                                Console.WriteLine("Invalid ID. Try again.");
                                continue;
                            }
                            if (studentList.SearchByID(id) != null)
                            {
                                Console.WriteLine("ID already exists. Enter a different ID.");
                                continue;
                            }
                            break;
                        }

                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(firstName) || !firstName.All(char.IsLetter))
                        {
                            Console.WriteLine("First Name cannot be empty and must only contain letters.");
                            Console.Write("Enter First Name: ");
                            firstName = Console.ReadLine();
                        }

                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(lastName) || !lastName.All(char.IsLetter))
                        {
                            Console.WriteLine("Last Name cannot be empty and must only contain letters.");
                            Console.Write("Enter Last Name: ");
                            lastName = Console.ReadLine();
                        }

                        int age;
                        while (true)
                        {
                            Console.Write("Enter Age: ");
                            if (!int.TryParse(Console.ReadLine(), out age) || age < 0 || age > 120)
                            {
                                Console.WriteLine("Invalid Age. Try again.");
                                continue;
                            }
                            break;
                        }

                        Console.Write("Enter Gender: ");
                        string gender = Console.ReadLine();

                        Console.Write("Enter Contact Number: ");
                        string contactNumber = Console.ReadLine();

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(course))
                        {
                            Console.WriteLine("Course cannot be empty.");
                            Console.Write("Enter Course: ");
                            course = Console.ReadLine();
                        }

                        int yearLevel;
                        while (true)
                        {
                            Console.Write("Enter Year Level (1-5): ");
                            if (!int.TryParse(Console.ReadLine(), out yearLevel) || yearLevel < 1 || yearLevel > 5)
                            {
                                Console.WriteLine("Invalid Year Level. Try again.");
                                continue;
                            }
                            break;
                        }

                        double gpa;
                        while (true)
                        {
                            Console.Write("Enter GPA (1.0 - 4.0): ");
                            if (!double.TryParse(Console.ReadLine(), out gpa) || gpa < 1.0 || gpa > 4.0)
                            {
                                Console.WriteLine("Invalid GPA. Try again.");
                                continue;
                            }
                            break;
                        }
                        Student student = new Student(id, firstName, lastName, age, gender, contactNumber, email, course, yearLevel, gpa);

                        
                        Console.WriteLine("\nWhere do you want to insert the student?");
                        Console.WriteLine("1. Beginning");
                        Console.WriteLine("2. End");
                        Console.WriteLine("3.  Specific Position");
                        Console.Write("Choose: ");
                        int insertChoice;
                        if (!int.TryParse(Console.ReadLine(), out insertChoice))
                        {
                            Console.WriteLine("Invalid choice. Defaulting to End.");
                            insertChoice = 2;
                        }

                        if (insertChoice == 1)
                        {
                            studentList.InsertAtBeginning(student);
                        }
                        else if (insertChoice == 2)
                        {
                            studentList.InsertAtEnd(student);
                        }
                        else if (insertChoice == 3)
                        {
                            Console.Write("Enter position: ");
                            int pos;
                            if (int.TryParse(Console.ReadLine(), out pos))
                            {
                                studentList.InsertAtPosition(student, pos);
                            }
                            else
                            {
                                Console.WriteLine("Invalid position. Adding at End instead.");
                                studentList.InsertAtEnd(student);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Adding at End instead.");
                            studentList.InsertAtEnd(student);
                        }

                        Console.WriteLine("Student added successfully.");
                        break;
                    }
                    break;

                case 2:
                    Console.Write("Enter ID to search: ");
                    if (int.TryParse(Console.ReadLine(), out int searchId))
                    {
                        Student foundById = studentList.SearchByID(searchId);
                        Console.WriteLine(foundById != null ? foundById.ToString() : "Student not found.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;

                case 3:
                    Console.Write("Enter First Name to search: ");
                    string searchName = Console.ReadLine();
                    studentList.SearchByName(searchName); 
                    break;

                case 4:
                    Student displayedStudent = studentList.DisplayByRecord();
                    break;

                case 5:
                    Console.Write("Enter ID to update: ");
                    if (!int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }
                    Console.Write("Enter new First Name: ");
                    string newFirstName = Console.ReadLine();
                    Console.Write("Enter new Last Name: ");
                    string newLastName = Console.ReadLine();
                    Console.Write("Enter new Course: ");
                    string newCourse = Console.ReadLine();

                    int newYearLevel;
                    while (true)
                    {
                        Console.Write("Enter new Year Level (1-5): ");
                        if (!int.TryParse(Console.ReadLine(), out newYearLevel) || newYearLevel < 1 || newYearLevel > 5)
                        {
                            Console.WriteLine("Invalid Year Level. Try again.");
                            continue;
                        }
                        break;
                    }

                    double newGPA;
                    while (true)
                    {
                        Console.Write("Enter new GPA (1.0 - 4.0): ");
                        if (!double.TryParse(Console.ReadLine(), out newGPA) || newGPA < 1.0 || newGPA > 4.0)
                        {
                            Console.WriteLine("Invalid GPA. Try again.");
                            continue;
                        }
                        break;
                    }

                    bool updated = studentList.UpdateStudent(updateId, newFirstName, newLastName, newCourse, newYearLevel, newGPA);
                    Console.WriteLine(updated ? "Student updated successfully." : "Student not found.");
                    break;

                case 6:
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        studentList.DeleteByID(deleteId);
                        Console.WriteLine("Delete operation completed (if ID existed).");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;

                case 7:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        } while (choice != 7);
    }
}
