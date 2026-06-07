using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class UInt32XmlSerializer : UnityXmlAttributeSerializer<uint>
	{
		public override bool SupportsCollections => true;

		public override uint ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (uint)attribute;
		}

		public override IEnumerable<uint> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToUInt32, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, uint value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
