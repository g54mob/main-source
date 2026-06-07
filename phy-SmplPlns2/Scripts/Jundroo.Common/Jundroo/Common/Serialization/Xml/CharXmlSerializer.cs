using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class CharXmlSerializer : UnityXmlAttributeSerializer<char>
	{
		public override bool SupportsCollections => true;

		public override char ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return DataIO.ParseChar(attribute.Value);
		}

		public override IEnumerable<char> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToChar, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, char value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value));
		}
	}
}
