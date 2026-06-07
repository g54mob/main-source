using System;
using System.Collections;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class ListXmlSerializer : IUnityXmlElementSerializer
	{
		public object ReadValue(XElement element, Type type, UnityXmlSerializerContext context)
		{
			Type type2 = type.GetGenericArguments()[0];
			IList list = (IList)Activator.CreateInstance(type, (int)element.Attribute("count"));
			foreach (XElement item in element.Elements("Item"))
			{
				object value = context.Serializer.Deserialize(item, type2);
				list.Add(value);
			}
			return list;
		}

		public void WriteValue(XElement element, object value, UnityXmlSerializerContext context)
		{
			Type type = value.GetType().GetGenericArguments()[0];
			IList list = (IList)value;
			element.Add(new XAttribute("count", list.Count));
			foreach (object item in list)
			{
				XElement xElement = new XElement("Item");
				context.Serializer.Serialize(xElement, type, item);
				element.Add(xElement);
			}
		}
	}
}
