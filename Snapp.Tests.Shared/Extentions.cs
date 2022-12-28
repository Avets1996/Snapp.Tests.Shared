//using System;
//using System.IO;
//using System.Xml.Serialization;

//namespace Snapp.Tests.Shared
//{
//    public static class DeepCopy
//    {
//        public static T Clone<T>(T source)
//        {
//            if (Object.ReferenceEquals(source, null))
//            {
//                return default(T);
//            }

//            var formatter = new XmlSerializer(typeof(T));

//            using (Stream stream = new MemoryStream())
//            {
//                formatter.Serialize(stream, source);
//                stream.Seek(0, SeekOrigin.Begin);
//                return (T)formatter.Deserialize(stream);
//            }
//        }
//    }


//    public static class Extentions
//    {
//        public static T CreateCopy<T>(this T obj)
//        {
//            return (T)DeepCopy.Clone(obj);
//        }
//    }
//}
