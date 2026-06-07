using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class DecimalXmlSerializer : UnityXmlAttributeSerializer<decimal>
	{
		public override bool SupportsCollections => true;

		public override decimal ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (decimal)attribute;
		}

		public override IEnumerable<decimal> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToDecimal, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, decimal value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
