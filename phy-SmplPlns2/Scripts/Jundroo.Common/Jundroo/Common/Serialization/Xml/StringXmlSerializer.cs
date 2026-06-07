using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class StringXmlSerializer : UnityXmlAttributeSerializer<string>
	{
		public override bool SupportsCollections => true;

		public override string ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (string)attribute;
		}

		public override IEnumerable<string> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues((string x, IFormatProvider format) => x.ToString(format), attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, string value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
