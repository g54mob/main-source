using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class UInt16XmlSerializer : UnityXmlAttributeSerializer<ushort>
	{
		public override bool SupportsCollections => true;

		public override ushort ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return DataIO.ParseUShort(attribute.Value);
		}

		public override IEnumerable<ushort> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToUInt16, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, ushort value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value));
		}
	}
}
