using System;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class TimeSpanXmlSerializer : UnityXmlAttributeSerializer<TimeSpan>
	{
		public override TimeSpan ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (TimeSpan)attribute;
		}

		public override void WriteValue(XAttribute attribute, TimeSpan value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
