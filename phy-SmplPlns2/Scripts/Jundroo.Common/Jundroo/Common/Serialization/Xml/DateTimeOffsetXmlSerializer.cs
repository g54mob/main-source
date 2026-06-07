using System;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class DateTimeOffsetXmlSerializer : UnityXmlAttributeSerializer<DateTimeOffset>
	{
		public override DateTimeOffset ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (DateTimeOffset)attribute;
		}

		public override void WriteValue(XAttribute attribute, DateTimeOffset value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
