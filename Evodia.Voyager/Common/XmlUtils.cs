﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace Evodia.Voyager.Common
{
    public class XmlUtils
    {
        public static T DeserializeFromString<T>(string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        private static object XmlDeserializeFromString(string objectData, Type type)
        {
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                var serializer = new XmlSerializer(type);
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        public static string SerializeToString<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);

                return textWriter.ToString();
            }
        }
    }
}
