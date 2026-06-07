using System;
using System.Collections;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class DictionaryXmlSerializer : IUnityXmlElementSerializer
	{
		public object ReadValue(XElement element, Type type, UnityXmlSerializerContext context)
		{
			Type type2 = type.GetGenericArguments()[0];
			Type type3 = type.GetGenericArguments()[1];
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(type, (int)element.Attribute("count"));
			foreach (XElement item in element.Elements("Entry"))
			{
				object key = context.Serializer.Deserialize(item.Element("Key"), type2);
				object value = context.Serializer.Deserialize(item.Element("Value"), type3);
				dictionary.Add(key, value);
			}
			return dictionary;
		}

		public void WriteValue(XElement element, object value, UnityXmlSerializerContext context)
		{
			Type type = value.GetType();
			Type type2 = type.GetGenericArguments()[0];
			Type type3 = type.GetGenericArguments()[1];
			IDictionary dictionary = (IDictionary)value;
			element.Add(new XAttribute("count", dictionary.Count));
			foreach (DictionaryEntry item in dictionary)
			{
				XElement xElement = new XElement("Key");
				context.Serializer.Serialize(xElement, type2, item.Key);
				XElement xElement2 = new XElement("Value");
				context.Serializer.Serialize(xElement2, type3, item.Value);
				element.Add(new XElement("Entry", xElement, xElement2));
			}
		}
	}
}
