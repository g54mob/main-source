using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class ByteXmlSerializer : UnityXmlAttributeSerializer<byte>
	{
		public override bool SupportsCollections => true;

		public override byte ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return DataIO.ParseByte(attribute.Value);
		}

		public override IEnumerable<byte> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToByte, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, byte value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value));
		}
	}
}
