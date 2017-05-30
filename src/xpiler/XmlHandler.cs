﻿// Copyright (c) 2017 Jae-jun Kang
// See the file LICENSE for details.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace x2net.xpiler
{
    public class XmlHandler : Handler
    {
        public bool Handle(string path, out Document doc)
        {
            doc = null;

            XmlSerializer serializer = new XmlSerializer(typeof(x2));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                x2 o = (x2)serializer.Deserialize(fs);

                Console.WriteLine(o.Namespace);

                Console.WriteLine(o.Definitions.Count);

                //Console.WriteLine(((Event)o.Definitions[1]).Properties.Count);

                doc = ToDocument(o);
            }

            return true;
        }

        private Document ToDocument(x2 doc)
        {
            Document result = new Document();

            var refs = doc.References;
            if (refs != null && refs.Count != 0)
            {
                foreach (var reference in refs)
                {
                    Console.WriteLine("ref target={0}", reference.Target);
                }
            }
            var defs = doc.Definitions;
            if (refs != null && refs.Count != 0)
            {
                foreach (var def in defs)
                {
                    Console.WriteLine("def name={0}", def.Name);

                    if (def.GetType() == typeof(Consts))
                    {
                        Consts c = (Consts)def;
                        Console.WriteLine(c.Elements.Count);
                    }
                    else
                    {
                        Cell c = (Cell)def;
                        Console.WriteLine(c.Properties.Count);
                    }
                }
            }

            return result;
        }

        [XmlRoot("x2")]
        public class x2
        {
            [XmlAttribute("namespace")]
            public string Namespace { get; set; }

            [XmlArray("references")]
            [XmlArrayItem("reference", Type = typeof(Ref))]
            public List<Ref> References { get; set; }

            [XmlArray("definitions")]
            [XmlArrayItem("consts", Type = typeof(Consts))]
            [XmlArrayItem("cell", Type = typeof(Cell))]
            [XmlArrayItem("event", Type = typeof(Event))]
            public List<Def> Definitions { get; set; }
        }

        public class Ref
        {
            [XmlAttribute("target")]
            public string Target { get; set; }
        }

        public class Def
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
        }

        public class Consts : Def
        {
            [XmlElement("const", Type = typeof(Element))]
            public List<Element> Elements { get; set; }
        }

        public class Cell : Def
        {
            [XmlElement("property", Type = typeof(Property))]
            public List<Property> Properties { get; set; }
        }

        public class Event : Cell
        {
            [XmlAttribute("id")]
            public string Id { get; set; }
        }

        public class Element
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
        }

        public class Property
        {
            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; }
        }
    }
}
