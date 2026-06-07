using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class Int16XmlSerializer : UnityXmlAttributeSerializer<short>
	{
		public override bool SupportsCollections => true;

		public override short ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (short)(int)attribute;
		}

		public override IEnumerable<short> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToInt16, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, short value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
