using System;
using System.Collections.Generic;
using System.Collections;



namespace _32133
{
   
    interface IDateAndCopy
            {
                object DeepCopy();

                DateTime Date { get; set; }
            }
            public class Person : IDateAndCopy

            {

                private string name;

                private string surnameName;

                private DateTime date;

                public Person(string name, string surnameName, DateTime date)

                {

                    this.name = name;

                    this.surnameName = surnameName;

                    this.date = date;

                }

                public Person()

                {

                    name = "name";

                    surnameName = "surnamename";

                    date = new DateTime(2002, 10, 10);

                }

                public string Name

                {

                    get { return name; }

                    set { name = value; }

                }

                public string SecondName

                {

                    get { return surnameName; }

                    set { surnameName = value; }

                }

                public DateTime Date

                {

                    get { return date; }

                    set { date = value; }

                }

                public int Year

                {

                    get { return date.Year; }

                    set { date = new DateTime(value, date.Month, date.Day); }

                }

                public override string ToString()

                {

                    return "імя: " + name + "\n" + "Фамілія: " + surnameName + "\n" + "дата народження: " + date.ToShortDateString();

                }

                public virtual string ToShortString()

                {

                    return "імя: " + name + "\n" + "Фамілія: " + surnameName;

                }

                public override bool Equals(Object obj)

                {

                    Person person = (Person)obj;

                    bool value = false;

                    if (obj != null)

                        if (name.Equals(person.name))

                            if (surnameName.Equals(person.surnameName))

                                if (date.Equals(person.date))

                                    value = true;

                    return value;

                }

                public override int GetHashCode()

                {

                    return name.Length + surnameName.Length + date.Day + date.Month + date.Year;

                }

                public static bool operator ==(Person p1, Person p2)

                {

                    bool result = false;

                    if (p1.name.Equals(p2.name))

                        if (p1.surnameName.Equals(p2.surnameName))

                            if (p1.date.Equals(p2.date))

                                result = true;

                    return result;

                }

                public static bool operator !=(Person p1, Person p2)

                {

                    bool result = true;

                    if (p1.name.Equals(p2.name))

                        if (p1.surnameName.Equals(p2.surnameName))

                            if (p1.date.Equals(p2.date))

                                result = false;

                    return result;

                }

                public object DeepCopy()

                {

                    Person person = new Person(name, surnameName, date);

                    return person;

                }

            }

            public class Test : IDateAndCopy

            {

                string name;

                bool resultTest;

                DateTime date;

                public Test(string name, bool resultTest, DateTime date)

                {

                    this.name = name;

                    this.resultTest = resultTest;

                    this.date = date;

                }

                public Test()

                {

                    name = "Name";

                    resultTest = true;

                    date = new DateTime(2002, 10, 10);

                }

                public DateTime Date

                {

                    get { return date; }

                    set { date = value; }

                }

                public override string ToString()

                {

                    return "назва заліку: " + name + "\n результат заліку " + resultTest.ToString() + "\n дата " + date.ToShortDateString();

                }

                public object DeepCopy()

                {

                    Test test = new Test(name, resultTest, date);

                    return test;

                }

            }

            public class Exam : IDateAndCopy

            {

                string name;
                int rating;

                DateTime dateExam;

                public Exam(string name, int rating, DateTime dateExam)

                {

                    this.name = name;

                    this.rating = rating;

                    this.dateExam = dateExam;

                }

                public Exam()

                {

                    name = "name";

                    rating = 5;

                    dateExam = new DateTime(2002, 10, 10);

                }

                public string Name

                {

                    get { return name; }

                    set { name = value; }

                }

                public int Rating

                {

                    get { return rating; }

                    set { rating = value; }

                }

                public DateTime Date

                {

                    get { return dateExam; }

                    set { dateExam = value; }

                }

                public override string ToString()

                {

                    return "назва: " + name + "\n оцінка: " + rating.ToString() + "\n дата здачі екзамену: " + dateExam.ToShortDateString();

                }

                public object DeepCopy()

                {

                    Exam exam = new Exam(this.name, this.rating, this.dateExam);

                    return exam;

                }

                public override bool Equals(Object obj)

                {

                    Exam exam = (Exam)obj;

                    bool result = false;

                    if (name == exam.name)

                        if (rating == exam.rating)

                            if (dateExam == exam.dateExam)

                                result = true;

                    return result;

                }

                public static bool operator ==(Exam p1, Exam p2)

                {

                    bool result = false;

                    if (p1.name == p2.name)

                        if (p1.rating == p2.rating)

                            if (p1.dateExam == p2.dateExam)

                                result = true;

                    return result;

                }

                public static bool operator !=(Exam p1, Exam p2)

                {

                    bool result = true;

                    if (p1.name == p2.name)

                        if (p1.rating == p2.rating)

                            if (p1.dateExam == p2.dateExam)

                                result = false;

                    return result;

                }

                public override int GetHashCode()

                {

                    return name.Length + rating + dateExam.Day + dateExam.Month + dateExam.Year;

                }

            }

            public class Student : Person, IDateAndCopy

            {

                private Education education;

                private int numberGroup;

                private ArrayList listTests;

                private Exam[] exams;

                public Student(Person person, Education education, int numberGroup)

                {

                    Person = person;

                    this.education = education;

                    this.numberGroup = numberGroup;

                    exams = new Exam[0];

                    listTests = new ArrayList();

                }

                public Student()

                {

                    Person = new Person();

                    education = Education.Bachelor;

                    numberGroup = 1;

                    exams = new Exam[0];

                    listTests = new ArrayList();

                }

                public Person Person

                {

                    get { return (Person)this; }

                    set

                    {

                        Name = value.Name;

                        SecondName = value.SecondName;

                        Date = value.Date;

                    }

                }

                public ArrayList ListTests

                {

                    get { return listTests; }

                    set { listTests = value; }

                }

                public Exam[] Exams

                {

                    get { return exams; }

                    set { exams = value; }

                }

                public double AverageRating

                {

                    get

                    {

                        int sum = 0;

                        for (int i = 0; i < exams.Length; i++)

                        {

                            sum += exams[i].Rating;

                        }

                        if (exams.Length != 0)

                            return sum / exams.Length;

                        else

                            return 0;

                    }

                }

                public int NumberGroup

                {

                    get { return numberGroup; }

                    set

                    {

                        if (value <= 100 || value > 599)

                            throw new Exception("Номер групи повинен бути менше 599 і не дорівнює 100");

                    }

                }

                public void AddExam(params Exam[] examAdd)

                {

                    int Length = exams.Length;

                    Array.Resize<Exam>(ref exams, Length + examAdd.Length);

                    examAdd.CopyTo(exams, Length);

                }

                public void AddTest(params Test[] tests)

                {

                    listTests.AddRange(tests);

                }


                public override string ToString()

                {
                    string result = base.ToString() + "\n тип освіти: " + education.ToString() + "\n номер группи" + numberGroup.ToString() + "\n";



                    foreach (Exam e in exams)

                    {

                        result += e.ToString() + "\n";

                    }



                    foreach (Test t in listTests)

                    {

                        result += t.ToString() + "\n";

                    }

                    return result;

                }

                new public string ToShortString()

                {

                    string result = base.ToString() + "\n тип освіти: " + education.ToString() + "\n номер группи: " + numberGroup.ToString() + "\n Середній бал: " + AverageRating.ToString();

                    return result;

                }

                public override bool Equals(object obj)

                {

                    Student student = (Student)obj;

                    bool result = false;

                    if (base.Equals(student))

                    {

                        if (exams.Length == student.exams.Length && listTests.Count == student.listTests.Count)

                        {

                            for (int i = 0; i < exams.Length; i++)

                            {

                                if (exams[i] != student.exams[i])

                                    return result;

                            }

                            for (int i = 0; i < listTests.Count; i++)

                            {

                                if (listTests[i] != student.listTests[i])

                                    return result;

                            }

                            if (education == student.education)

                                if (numberGroup == student.numberGroup)

                                    result = true;

                        }

                    }

                    return result;

                }

                public override int GetHashCode()

                {

                    return ToString().Length;

                }

                new public object DeepCopy()

                {

                    Student student = new Student((Person)this, education, numberGroup);

                    for (int i = 0; i < exams.Length; i++)

                    {

                        student.exams[i] = (Exam)exams[i].DeepCopy();

                    }

                    for (int i = 0; i < listTests.Count; i++)

                    {

                        student.listTests[i] = (Test)listTests[i];

                    }

                    return student;

                }

            }

            public enum Education

            {

                Specialist, Bachelor, SecondEducation

            }






        }

        class Program

        {

            static void Main(string[] args)

            {



                Console.WriteLine("1");

                Console.WriteLine();

                Student student = new Student();

                Console.WriteLine(student.ToShortString());

                Console.WriteLine();



                Console.WriteLine("2,3");

                Console.WriteLine();

                student.AddExam(new Exam());

                student.AddTest(new Test());

                student.NumberGroup = 120;

                student.SecondName = "petrov";

                student.Name = "petro";

                Console.WriteLine(student.ToString());

                Console.WriteLine();



                Console.WriteLine("4");

                Console.WriteLine();

                Person a = new Person();

                Person b = new Person();

                Console.WriteLine(a.GetHashCode() + " " + b.GetHashCode());

                Console.WriteLine();



                Console.WriteLine("5");

                Console.WriteLine();

                Student student2 = new Student();

                student.AddExam(new Exam("Physik", 3, new DateTime(2014, 01, 15)));

                student.AddExam(new Exam("Math", 4, new DateTime(2014, 01, 10)));

                student.AddExam(new Exam("Chemi", 4, new DateTime(2014, 01, 10)));

                Console.WriteLine(student2.ToString());

                Console.WriteLine();



                Console.WriteLine("6");

                Console.WriteLine();

                Console.WriteLine(student2.Person.ToString());

                Console.WriteLine();



                Console.WriteLine("7");

                Console.WriteLine();

                Student student3 = (Student)student2.DeepCopy();

                student2.Name = "Sasha";

                Console.WriteLine(student2.ToString());

                Console.WriteLine(student3.ToString());

                Console.WriteLine();



                Console.WriteLine("8");

                Console.WriteLine();

                try

                {

                    student.NumberGroup = 90;

                }

                catch (Exception e)

                {

                    Console.WriteLine("\n" + e.Message);

                }

                Console.WriteLine();



                Console.WriteLine("9");

                Console.WriteLine();

                foreach (Exam e in student.Exams)

                {

                    Console.WriteLine(e.ToString());

                }

                foreach (Test t in student.ListTests)

                {

                    Console.WriteLine(t.ToString());

                }

                Console.WriteLine();



                Console.WriteLine("10");

                Console.WriteLine();

                for (int i = 0; i < student.Exams.Length; i++)

                {

                    if (student.Exams[i].Rating > 3)

                        Console.WriteLine(student.Exams[i].ToString());

                }

                Console.Read();

            }
        }


    }

}
