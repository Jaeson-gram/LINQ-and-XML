using System;
using System.Linq;
using System.Xml.Linq;



namespace LinqAndXML
{
    class program
    {
        static void Main(string[] args)
        {
            //We simply apply our Student - Structure to XML
            string studentsXML =
                @"<Students>
                    <Student>
                       <Name>Toni</Name>
                       <Age>21</Age>
                       <University>Yale</University>
                       <Program>Constrols Engineering</Program>
                    </Student>
                    <Student>
                       <Name>Uk</Name>
                       <Age>19</Age>
                       <University>Bristol</University>
                       <Program>Electronics Engineering</Program>
                    </Student>
                    <Student>
                       <Name>April</Name>
                       <Age>21</Age>
                       <University>Vilanova</University> 
                       <Program>Electronics Engineering</Program>
                    </Student>
                    <Student>
                       <Name>Jamal</Name>
                       <Age>20</Age>
                       <University>Bristol</University> 
                       <Program>Computer Science</Program>
                    </Student>
                  </Students>";


            XDocument studentsXDocument = new XDocument();
            studentsXDocument = XDocument.Parse(studentsXML);

            //XML is powerful in itself, but with LINQ, it gets even more powerful,
            //and with LINQ it doesn't matter if it's just an object in C#, a database or SQL file, or XML, we just have to give it the data

            var students = from student in studentsXDocument.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Program = student.Element("Program").Value
                           };


            Console.WriteLine("Profiles:");
            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}\nAge: {1}\nUniversity: {2}\nProgram: {3}\n", student.Name, student.Age, student.University, student.Program);
            }

            var sortstudentsByname = from student in students
                                     orderby student.Age descending
                                     select student;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted By Age (Descending)");
            foreach (var student in sortstudentsByname)
            {
                Console.WriteLine("Name: {0}, of age {1} from {2} University, studying {3}", student.Name, student.Age, student.University, student.Program);
            }
                 
        }
    }
}