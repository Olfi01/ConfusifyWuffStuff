﻿using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace XML_Editor_WuffPad.XMLClasses
{
    public class XmlString
    {
        public XmlString()
        {
            Values = new ObservableCollection<string>();
        }
        [XmlElement("value")]
        public ObservableCollection<string> Values { get; set; }
        [XmlAttribute("deprecated")]
        public string DeprecatedString;
        [XmlAttribute("key")]
        public string Key { get; set; }
        [XmlAttribute("isgif")]
        private string IsgifString;
        public int ValuesCount { get { return Values.Count; } }
        [XmlIgnore]
        public string Description { get; set; }
        [XmlIgnore]
        public bool Isgif
        {
            get
            {
                if (IsgifString == "true") return true;
                else return false;
            }
            set
            {
                if (value)
                {
                    IsgifString = "true";
                }
                else
                {
                    IsgifString = null;
                }
            }
        }
    }
}
