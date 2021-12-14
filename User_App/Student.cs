using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_App
{
    public class Student:User
    {
        public string studentClass;

        public Student(string firstName, string lastName, int yearOfBirth, string mail, string studentClass) : base(firstName, lastName, yearOfBirth, mail)
        {
            this.studentClass = studentClass;
        }

        public override void PrintDetails()
        {
            Console.WriteLine(this.FirstName);
            Console.WriteLine(this.LastName);
            Console.WriteLine(this.YearOfBirth);
            Console.WriteLine(this.Mail);
            Console.WriteLine(this.studentClass);
        }


    }
}
