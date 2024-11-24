using C__LAB7_LIBRARY;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace ClassDiagramGenerator
{
    class Program
    {
        static void Main()
        {
            string outputFileName = "ClassDiagram.xml";
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            XmlElement root = xmlDoc.CreateElement("ClassDiagram");
            xmlDoc.AppendChild(root);
            Assembly assembly = Assembly.Load("C#_LAB7_LIBRARY");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                XmlElement classElement = xmlDoc.CreateElement("Class");
                classElement.SetAttribute("name", type.Name);
                object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), false);
                if (attributes.Length > 0)
                {
                    MyAttribute customAttribute = (MyAttribute)attributes[0];
                    classElement.SetAttribute("comment", customAttribute.Comment);
                }
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    XmlElement propertyElement = xmlDoc.CreateElement("property");
                    propertyElement.SetAttribute("name", property.Name);
                    propertyElement.SetAttribute("type", property.PropertyType.Name);
                    classElement.AppendChild(propertyElement);
                }
                root.AppendChild(classElement);
            }
            xmlDoc.Save(outputFileName);
        }
    }
}