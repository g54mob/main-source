using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class Int64XmlSerializer : UnityXmlAttributeSerializer<long>
	{
		public override bool SupportsCollections => true;

		public override long ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (long)attribute;
		}

		public override IEnumerable<long> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToInt64, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, long value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
