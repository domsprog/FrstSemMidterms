
public class Student
{
    public int ID { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Contact_number { get; set; }
    public string Email { get; set; }
    public string Course { get; set; }
    public int YearLevel { get; set; }
    public double GPA { get; set; }

    public Student(int id, string firstName, string lastName, int age, string gender,
                   string contactNumber, string email, string course, int yearLevel, double gpa)
    {
        ID = id;
        First_name = firstName;
        Last_name = lastName;
        Age = age;
        Gender = gender;
        Contact_number = contactNumber;
        Email = email;
        Course = course;
        YearLevel = yearLevel;
        GPA = gpa;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {First_name} {Last_name}, Age: {Age}, Gender: {Gender}, " +
               $"Contact: {Contact_number}, Email: {Email}, Course: {Course}, Year: {YearLevel}, GPA: {GPA}";
    }

    public void DisplayByRecord()
    {
        throw new NotImplementedException();
    }
}