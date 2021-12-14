using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_App
{
    public class User : IComparable
    {
        string firstName;
        string lastName;
        int yearOfBirth;
        string mail;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public User(string firstName, string lastName, int yearOfBirth, string mail)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.YearOfBirth = yearOfBirth;
            this.Mail = mail;
        }


        public int CompareTo(object? obj)
        {
            User user = (User)obj;
            if (this.YearOfBirth > user.YearOfBirth) return -1;
            if (this.YearOfBirth < user.YearOfBirth) return 1;
            return 0;
        }
        public static void ActionUser()
        {
            switch (UserNum())
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    EditFile();
                    break;
                case 3:
                    DeleteFromFile();
                    break;
                case 4:
                    GetNameNStream();
                    break;
            }
        }

        static int UserNum()
        {
            try
            {
                Console.WriteLine("Hello what you want to do?");
                Console.WriteLine("For add user to file - press 1");
                Console.WriteLine("For edit user from file- press 2");
                Console.WriteLine("For deiete user from file- press 3");
                Console.WriteLine("For display user details- press 4");
                int userNum = int.Parse(Console.ReadLine());
                return userNum;
            }
            catch (FormatException)
            {
                Console.WriteLine("Choose number please");
                return UserNum();
            }
        }//swith case

        static void CreateUser()
        {
            Console.WriteLine("put your first name");
            string fName = Console.ReadLine();
            Console.WriteLine("put your last name");
            string lName = Console.ReadLine();
            Console.WriteLine("put your year of birth");
            int yearOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine("put your mail");
            string mail = Console.ReadLine();
            User user = new User(fName, lName, yearOfBirth, mail);
            AddUserToFile(user);
        }//first case
        public static void AddUserToFile(User user)
        {
            FileStream fs = new FileStream($@"C:\test\users\{user.FirstName}.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"{user.FirstName} { user.LastName} { user.YearOfBirth} { user.Mail}");
            }
        }//first case
        public virtual void PrintDetails()
        {
            Console.WriteLine(this.FirstName);
            Console.WriteLine(this.LastName);
            Console.WriteLine(this.YearOfBirth);
            Console.WriteLine(this.Mail);
        }//not belong to switch case

        public static void GetUsers(List<User> list)
        {
            try
            {


                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Hello user.");
                    Console.WriteLine("put your first name");
                    string fName = Console.ReadLine();
                    Console.WriteLine("put your last name");
                    string lName = Console.ReadLine();
                    Console.WriteLine("put your year of birth");
                    int yearOfBirth = int.Parse(Console.ReadLine());
                    Console.WriteLine("put your mail");
                    string mail = Console.ReadLine();
                    User user = new User(fName, lName, yearOfBirth, mail);

                    list.Add(user);
                }

                list.Sort();
                foreach (User user in list)
                {
                    Console.WriteLine(user.YearOfBirth);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("put please answer");
                GetUsers(list);
            }
            catch (FormatException)
            {
                Console.WriteLine("put please answer");
                GetUsers(list);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("put please answer");
                GetUsers(list);
            }
        }//not belong to switch case

        public static void GetListNStresmToFile(List<User> list)
        {
            FileStream fs = new FileStream(@"C:\test\users\users.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (User user in list)
                {
                    sw.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth}, {user.Mail}");

                }
            }
        }//not belong to switch case

        public static void PrintFromFile()
        {
            FileStream fs = new FileStream(@"C:\test\users\users.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader sw = new StreamReader(fs))
            {
                Console.Write(sw.ReadToEnd());
            }
        }//not belong to switch case

        public static void GetListNStresmToFiles(List<User> list)
        {
            foreach (User user in list)
            {
                FileStream fs = new FileStream($@"C:\test\users\{user.FirstName} {user.LastName}.txt", FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth}, {user.Mail}");
                }
            }
        }//not belong to switch case

        static void DeleteFromFile()
        {
            try
            {
                Console.WriteLine("put a name you choose");
                string name = Console.ReadLine();
                File.Delete($@"C:\test\users\{name}.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("ther is no such as name");
                ActionUser();
            }

        }//third case

        public static void GetNameNStream()
        {
            try
            {
                Console.WriteLine("put a name you choose");
                string nameUser = Console.ReadLine();

                FileStream fs = new FileStream($@"C:\test\users\{nameUser}.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader sw = new StreamReader(fs))
                {
                    Console.WriteLine(sw.ReadToEnd());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ther is no such as name");
                ActionUser();
            }
        }//forth case

        public static void  EditFile()
        {
            Console.WriteLine("put a name you choose");
            string name = Console.ReadLine();
            FileStream fs = new FileStream($@"C:\test\users\{name}.txt", FileMode.Create, FileAccess.Write);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(Console.ReadLine());
            }
        }//second case
    }
}
