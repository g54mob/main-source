using System;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	public interface IUnityXmlElementSerializer
	{
		object ReadValue(XElement element, Type type, UnityXmlSerializerContext context);

		void WriteValue(XElement element, object value, UnityXmlSerializerContext context);
	}
}
