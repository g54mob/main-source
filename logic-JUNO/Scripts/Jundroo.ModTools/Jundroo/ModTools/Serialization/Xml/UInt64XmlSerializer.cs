using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class UInt64XmlSerializer : UnityXmlAttributeSerializer<ulong>
	{
		public override bool SupportsCollections => true;

		public override ulong ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (ulong)attribute;
		}

		public override IEnumerable<ulong> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToUInt64, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, ulong value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
