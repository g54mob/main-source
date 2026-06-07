using System;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class DateTimeXmlSerializer : UnityXmlAttributeSerializer<DateTime>
	{
		public override DateTime ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (DateTime)attribute;
		}

		public override void WriteValue(XAttribute attribute, DateTime value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
