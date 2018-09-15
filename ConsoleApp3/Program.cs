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
                            new XAttribute("sex","man"),
                            new XElement("Name", "Bob"),
                            new XElement("PhoneNumber", "12345-405")),
                        new XElement("Employee2",
                            new XAttribute("sew","woman"),
                            new XElement("Name", "Sally"),
                            new XElement("PhoneNumber", "10213=405")))
                );
            XElement ro = employees1.Element("Employees");
            XElement ro2 = ro.Element("Employee1");//注意嵌套调用
            XAttribute sex = ro2.Attribute("sex");
            WriteLine($"sex is {sex.Value}");
            WriteLine();
            //ro2.Attribute("sex").Remove();移除特性
            //ro2.SetAttributeValue("sex", null);
            //ro2.SetAttributeValue("新特性"，"值");可添加新特性
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
            WriteLine();
            employees1.Save("employees.xml");
            /* XComment xd = new XDocument(
                 new XDeclaration("1.0", "utf-8", "yes"),
                 new XComment("This is comment"),
                 new XProcessingInstruction("xm;-stylesheeet", @"href=""stories.css"));*/
            XDocument cd = XDocument.Load("employees.xml");
            XElement rr = cd.Element("Employees");
            var xyz = from e in rr.Elements()
                      where e.Name.ToString().Length == 5
                      select e;
            foreach(XElement x in xyz)
            {
                WriteLine(x.Name.ToString());
            }
            WriteLine();
            ReadKey();
        }
    }
}

