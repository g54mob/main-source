using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace NGenerics.Extensions
{
	public static class ObjectExtensions
	{
		public static T ConvertTo<T>(this object value)
		{
			return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
		}

		public static string Serialize<T>(this T obj)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, obj);
				return stringWriter.ToString();
			}
		}

		public static T Deserialize<T>(string xml)
		{
			using (StringReader textReader = new StringReader(xml))
			{
				return (T)new XmlSerializer(typeof(T)).Deserialize(textReader);
			}
		}

		public static T DeepCopy<T>(this T obj)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, obj);
				memoryStream.Position = 0L;
				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}

		[Obsolete("Made obsolete to stop conflicting with Enumerable.ToList. Use ObjectExtensions.ToIList instead.", true)]
		public static List<T> ToList<T>(this T obj)
		{
			return new List<T> { obj };
		}

		public static List<T> ToIList<T>(this T obj)
		{
			return new List<T> { obj };
		}
	}
}
