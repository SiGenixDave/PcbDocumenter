﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace PCB_Documenter
{
    public class PCBSettings
    {
        public String name
        { get; set; }

        public String phoneOffice
        { get; set; }

        public String phoneCell
        { get; set; }

        public String pcbEnabled
        { get; set; }

        public String pcbTitle
        { get; set; }

        public String pcbPartNumber
        { get; set; }

        public String pcbRevision
        { get; set; }

        public String assemblyEnabled
        { get; set; }

        public String assemblyTitle
        { get; set; }

        public String assemblyPartNumber
        { get; set; }

        public String assemblyRevision
        { get; set; }

        public String dimX
        { get; set; }

        public String dimY
        { get; set; }

        public String PCBThickness
        { get; set; }

        public String layerCount
        { get; set; }

        public String inputFolder
        { get; set; }

        public String outputFolder
        { get; set; }
    }

    static public class XMLInterface
    {
        static public void SerializeToXML(PCBSettings aParamList, String aFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PCBSettings));
            TextWriter textWriter = new StreamWriter(aFileName);
            serializer.Serialize(textWriter, aParamList);
            textWriter.Close();
        }

        static public PCBSettings DeserializeFromXML(String aFileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(PCBSettings));
            TextReader textReader = new StreamReader(aFileName);
            PCBSettings paramList;
            paramList = (PCBSettings)deserializer.Deserialize(textReader);
            textReader.Close();

            return paramList;
        }
    }
}