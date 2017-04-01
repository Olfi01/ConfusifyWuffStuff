using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Editor_WuffPad.XMLClasses;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ConfusifyWuffStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Path: ");
            string path = Console.ReadLine();
            string fileString = File.ReadAllText(path, Encoding.UTF8);
            XmlStrings xmlss = readXmlString(fileString);
            List<List<XmlString>> theList = new List<List<XmlString>>();
            theList.Add(new List<XmlString>());
            theList.Add(new List<XmlString>());
            theList.Add(new List<XmlString>());
            theList.Add(new List<XmlString>());
            theList.Add(new List<XmlString>());
            theList.Add(new List<XmlString>());
            List<string> blockedList = new List<string>();
            Console.WriteLine("Blockedlist path: ");
            string blockedlistpath = Console.ReadLine();
            fileString = File.ReadAllText(blockedlistpath);
            string[] array = fileString.Split('\n');
            blockedList = array.ToList();
            Console.WriteLine("Reading values");
            #region foreach
            foreach (XmlString s in xmlss.Strings)
            {
                if (!blockedList.Contains(s.Key) && !s.Isgif && s.DeprecatedString != "true")
                {
                    if (s.Values[0].Contains("{0}"))
                    {
                        if (s.Values[0].Contains("{1}"))
                        {
                            if (s.Values[0].Contains("{2}"))
                            {
                                if (s.Values[0].Contains("{3}"))
                                {
                                    if (s.Values[0].Contains("{4}"))
                                    {
                                        theList[5].Add(s);
                                    }
                                    else
                                    {
                                        theList[4].Add(s);
                                    }
                                }
                                else
                                {
                                    theList[3].Add(s);
                                }
                            }
                            else
                            {
                                theList[2].Add(s);
                            }
                        }
                        else
                        {
                            theList[1].Add(s);
                        }
                    }
                    else
                    {
                        theList[0].Add(s);
                    }
                }
            }
            #endregion
            Console.WriteLine("sorting values");
            List<List<string>> valuezz = new List<List<string>>();
            for (int i = 0; i<6; i++)
            {
                valuezz.Add(new List<string>());
                foreach(XmlString s in theList[i])
                {
                    foreach(string v in s.Values)
                    {
                        valuezz[i].Add(v);
                    }
                }
            }
            Console.WriteLine("Assigning new values");
            foreach(XmlString s in xmlss.Strings)
            {
                int index = 0;
                if (!blockedList.Contains(s.Key) && !s.Isgif && s.DeprecatedString != "true")
                {
                    #region ident
                    if (s.Values[0].Contains("{0}"))
                    {
                        if (s.Values[0].Contains("{1}"))
                        {
                            if (s.Values[0].Contains("{2}"))
                            {
                                if (s.Values[0].Contains("{3}"))
                                {
                                    if (s.Values[0].Contains("{4}"))
                                    {
                                        index = 5;
                                    }
                                    else
                                    {
                                        index = 4;
                                    }
                                }
                                else
                                {
                                    index = 3;
                                }
                            }
                            else
                            {
                                index = 2;
                            }
                        }
                        else
                        {
                            index = 1;
                        }
                    }
                    else
                    {
                        index = 0;
                    }
                    #endregion
                    s.Values.Clear();
                    foreach (string str in valuezz[index])
                    {
                        s.Values.Add(str);
                    }
                }
            }
            Console.WriteLine("Serializing");
            fileString = serializeXmlToString(xmlss);
            Console.WriteLine("Path to: ");
            string pathTo = Console.ReadLine();
            Console.WriteLine("Saving...");
            File.WriteAllText(pathTo, fileString, Encoding.UTF8);
            Console.WriteLine("Finished. Probably everything is broken now.");
            Console.ReadLine();
        }

        private static XmlStrings readXmlString(string fileString)
        {
            string[] splitted = fileString.Split('\n');
            XmlStrings result;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlStrings));
                using (TextReader tr = new StringReader(fileString))
                {
                    result = (XmlStrings)serializer.Deserialize(tr);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        private static string serializeXmlToString(XmlStrings xmlss)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlStrings));
            using (TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, xmlss);
                string[] results = tw.ToString().Split('\n');
                string result = results[0];
                bool firstString = true;
                foreach (string s in results)
                {
                    if (!firstString)
                    {
                        result += "\n" + s;
                    }
                    firstString = false;
                }
                //result = Utf16ToUtf8(result);
                return result.Replace("utf-16", "utf-8");
            }
        }
    }
}
