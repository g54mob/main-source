using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class DoubleXmlSerializer : UnityXmlAttributeSerializer<double>
	{
		public override bool SupportsCollections => true;

		public override double ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (double)attribute;
		}

		public override IEnumerable<double> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToDouble, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, double value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
