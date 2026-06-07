using System;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	public abstract class UnityXmlElementSerializer<T> : IUnityXmlElementSerializer
	{
		object IUnityXmlElementSerializer.ReadValue(XElement element, Type type, UnityXmlSerializerContext context)
		{
			return ReadValue(element, type, context);
		}

		public abstract T ReadValue(XElement element, Type type, UnityXmlSerializerContext context);

		void IUnityXmlElementSerializer.WriteValue(XElement element, object value, UnityXmlSerializerContext context)
		{
			WriteValue(element, (T)value, context);
		}

		public abstract void WriteValue(XElement element, T value, UnityXmlSerializerContext context);
	}
}
