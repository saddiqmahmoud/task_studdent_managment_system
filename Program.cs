namespace task_studdent_managment_system
{
    class Instructor
    {
       public int instructorId;
       public string name;
       public string specialization;
      
        public Instructor(int instructorId, string name, string specialization)
        {
            this.instructorId = instructorId;
            this.name = name;
            this.specialization = specialization;
        }
        public string PrintDetails()
        {
            return $"instructorid = {this.instructorId}\nname = {this.name}\nspecialization = {this.specialization}";
        }
    }
    
    class Course
    {
        public int courseId;
        public string title;
        public Instructor instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.courseId = courseId;
            this.title = title;
            this.instructor = instructor;
        }

        public string PrintDetails()
        {
            return $"courseId = {this.courseId}\nTitle = {this.title}\n" + instructor.PrintDetails();
        }
    }
     
    class Student
    {
        
        public int StudentId;
        public string name;
        public int age;
        public List<Course> Courses;

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            this.name = name;
            this.age = age;
            Courses = new();
            
        }

        public bool Enroll(Course course)
        {
            if(course is not null)
            {
                this.Courses.Add(course);
                return true;
            }
            return false;
        }
        public string PrintDetails()
        {
            return $"StudentId = {this.StudentId}\nname = {this.name}\nage = {this.age}";
            //for(int i=0 ;i<= this.Courses.Count;i++)
            //{
            //    return $"courseId = {this.Courses[i].courseId}\ntitle = {this.Courses[i].title}\n{this.Courses[i].instructor.PrintDetails}";
            //}
        }

    }
    
    class School
    {
        public List<Student> students ;
        public List<Course> courses ;
        public List<Instructor> instructors ;

        public School()
        {
            this.students = new();
            this.courses = new();
            this.instructors = new();
        }

        public bool AddStudent(Student student)
        {
            if (student is not null)
            {
                this.students.Add(student);
                return true;
            }
            else
                return false;
        }
        public bool AddCourse(Course course)
        {
            if (course is not null)
            {
                this.courses.Add(course);
                return true;
            }
            else
                return false;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructor is not null)
            {
                this.instructors.Add(instructor);
                return true;

            }
            else
                return false;
        }
        public Student? FindStudent(int studentId)
        {
            for(int i=0;i<this.students.Count;i++)
            {
                if (this.students[i].StudentId == studentId)
                {
                    return this.students[i];
                }     
            }
            return null;
        }
        public Course? FindCourse(int courseId)
        {
            for(int i=0;i<this.courses.Count;i++)
            {
                if (this.courses[i].courseId==courseId)
                {
                    return this.courses[i];
                }
            }
            return null;
        }
        public Instructor? FindInstructor(int instructorId)
        {
            for(int i=0;i<this.instructors.Count;i++)
            {
                if (this.instructors[i].instructorId==instructorId)
                {
                    return this.instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student? s = this.FindStudent(studentId);
            Course? x = this.FindCourse(courseId);
            if(s is not null && x is not null)
            {
                s.Enroll(x);
                return true;
            }
            else
            {
                return false;
            }
            

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            School manag = new();
            int choice = default;
            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Fine the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter studentId :");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter studentName : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter studentAge : ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Student s = new(id, name, age);
                    manag.AddStudent(s);
                    Console.WriteLine("student add succeffuly");
                }
                else if (choice == 2)
                {

                    Console.WriteLine("Enter InstructorId : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter InstructorName : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter InstructorSpecialization : ");
                    string specialization = Console.ReadLine();
                    Instructor instructor = new(id, name, specialization);
                    manag.AddInstructor(instructor);
                    Console.WriteLine("instructor add succeffuly");


                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter CourseId : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter CourseTitle : ");
                    string title = Console.ReadLine();
                    Console.WriteLine("do you want add new instructor or choice an exist one ?(yes/no)");
                    string choi = Console.ReadLine();
                    if(choi=="yes")
                    {
                        Console.WriteLine("Enter InstructorId : ");
                        int isntructorid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter InstructorName : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter InstructorSpecialization : ");
                        string specialization = Console.ReadLine();
                        Instructor inst = new(isntructorid, name, specialization);
                        Course c = new(id, title, inst);
                        manag.AddCourse(c);
                        Console.WriteLine("course add successffly");

                    }
                    else if(choi=="no")
                    {
                        Console.WriteLine("Enter instructorID : ");
                        int instid = Convert.ToInt32(Console.ReadLine());
                        Instructor ins= manag.FindInstructor(instid);
                        if(ins!=null)
                        {
                            Course c = new(id, title, ins);
                            manag.AddCourse(c);
                            Console.WriteLine("course add successffly");
                        }
                        else
                        {
                            Console.WriteLine("Invalid instructor ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid choice");
                    }


                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter studentId :");
                    int studentid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter CourseId : ");
                    int courseid = Convert.ToInt32(Console.ReadLine());
                    bool x = manag.EnrollStudentInCourse(studentid, courseid);
                    if(x==true)
                        Console.WriteLine("student Enroll successufly");
                    else
                        Console.WriteLine("invalid");
                }
                else if (choice == 5)
                {
                    if(manag.students.Count!=0)
                    {
                        for (int i = 0; i < manag.students.Count; i++)
                        {
                            Console.WriteLine(manag.students[i].StudentId);
                            Console.WriteLine(manag.students[i].name);
                            Console.WriteLine(manag.students[i].age);
                        }
                    }
                    else
                        Console.WriteLine("list is empty");
                    
                }
                else if (choice == 6)
                {
                    if(manag.courses.Count!=0)
                    {
                        for (int i = 0; i < manag.courses.Count; i++)
                        {
                            Console.WriteLine(manag.courses[i].courseId);
                            Console.WriteLine(manag.courses[i].title);
                            Console.WriteLine(manag.courses[i].instructor.instructorId);
                            Console.WriteLine(manag.courses[i].instructor.name);
                            Console.WriteLine(manag.courses[i].instructor.specialization);
                        }
                    }
                    else
                        Console.WriteLine("list is empty");
                    
                }
                else if (choice == 7)
                {
                    if (manag.courses.Count != 0)
                    {
                        for (int i = 0; i < manag.courses.Count; i++)
                        {
                            Console.WriteLine(manag.courses[i].courseId);
                            Console.WriteLine(manag.courses[i].title);
                            Console.WriteLine(manag.courses[i].instructor.instructorId);
                            Console.WriteLine(manag.courses[i].instructor.name);
                            Console.WriteLine(manag.courses[i].instructor.specialization);
                        }
                    }
                    else
                        Console.WriteLine("list is empty");
                }
                else if(choice==8)
                {
                    Console.WriteLine("Enter studentId : ");
                    int id = Convert.ToInt32(Console.ReadLine());
 
                    Student student = manag.FindStudent(id);
                    if(student == null)
                        Console.WriteLine("not find");
                    else
                    {
                        Console.WriteLine("find");
                        Console.WriteLine(student.StudentId);
                        Console.WriteLine(student.name);
                        Console.WriteLine(student.age);
                        if(student.Courses.Count!=0)
                        {
                            for (int i = 0; i < student.Courses.Count; i++)
                            {
                                Console.WriteLine(student.Courses[i].courseId);
                                Console.WriteLine(student.Courses[i].title);
                                Console.WriteLine(student.Courses[i].instructor.instructorId);
                                Console.WriteLine(student.Courses[i].instructor.name);
                                Console.WriteLine(student.Courses[i].instructor.specialization);

                            }
                        }
                        
                    }
                }
                else if(choice==9)
                {
                    Console.WriteLine("Enter CourseId : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Course course = manag.FindCourse(id);
                    if(course == null)
                        Console.WriteLine("not find");
                    else
                    {
                        Console.WriteLine("find");
                        Console.WriteLine(course.courseId);
                        Console.WriteLine(course.title);
                        Console.WriteLine(course.instructor.instructorId);
                        Console.WriteLine(course.instructor.name);
                        Console.WriteLine(course.instructor.specialization);
                    }

                }
            } while (choice!=10);
        }
    }
}
