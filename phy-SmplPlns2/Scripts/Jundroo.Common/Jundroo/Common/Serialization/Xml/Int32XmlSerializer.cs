using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class Int32XmlSerializer : UnityXmlAttributeSerializer<int>
	{
		public override bool SupportsCollections => true;

		public override int ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (int)attribute;
		}

		public override IEnumerable<int> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToInt32, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, int value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
