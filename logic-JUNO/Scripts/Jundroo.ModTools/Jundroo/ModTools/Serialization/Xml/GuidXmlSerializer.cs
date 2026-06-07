using System;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class GuidXmlSerializer : UnityXmlAttributeSerializer<Guid>
	{
		public override Guid ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (Guid)attribute;
		}

		public override void WriteValue(XAttribute attribute, Guid value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
