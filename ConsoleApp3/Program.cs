using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument employees1 =
                new XDocument
                (
                    new XElement("Employees",
                        new XElement("Employee1",
                            new XElement("Name", "Bob"),
                            new XElement("PhoneNumber", "12345-405")),
                        new XElement("Employee2",
                            new XElement("Name", "Sally"),
                            new XElement("PhoneNumber", "10213=405")))
                );
            XElement root = employees1.Element("Employees");
            IEnumerable<XElement> employees = root.Elements();
            foreach (XElement emp in employees)
            {
                XElement empNameNode = emp.Element("Name");
                WriteLine(empNameNode.Value);
                IEnumerable<XElement> empPhone = emp.Elements("PhoneNumber");
                foreach (XElement phone in empPhone)
                {
                    WriteLine($"{phone.Value}");
                }
            }
            WriteLine(employees1);
            WriteLine();
            XElement rt = employees1.Element("Employees");
            rt.Add(new XElement("second",new XElement("second1")));
            rt.Add(new XElement("third"), new XElement("forth"));
            WriteLine(employees1);
            employees1.Save("employees.xml");
            ReadKey();
        }
    }
}
