using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.Common.Serialization.Xml
{
	internal class SByteXmlSerializer : UnityXmlAttributeSerializer<sbyte>
	{
		public override bool SupportsCollections => true;

		public override sbyte ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return DataIO.ParseSByte(attribute.Value);
		}

		public override IEnumerable<sbyte> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToSByte, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, sbyte value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value));
		}
	}
}
