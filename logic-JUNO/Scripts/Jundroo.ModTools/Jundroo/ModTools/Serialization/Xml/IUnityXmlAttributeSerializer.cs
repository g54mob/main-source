using System;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	public interface IUnityXmlAttributeSerializer
	{
		bool SupportsCollections { get; }

		object ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context);

		object ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context);

		void WriteValue(XAttribute attribute, object value, UnityXmlSerializerContext context);

		void WriteValues(XAttribute attribute, object values, UnityXmlSerializerContext context);
	}
}
