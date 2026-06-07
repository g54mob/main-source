using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class BoolXmlSerializer : UnityXmlAttributeSerializer<bool>
	{
		public override bool SupportsCollections => true;

		public override bool ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (bool)attribute;
		}

		public override IEnumerable<bool> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToBoolean, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, bool value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}

		public override void WriteValues(XAttribute attribute, IEnumerable<bool> values, UnityXmlSerializerContext context)
		{
			base.WriteValues(attribute, values, context);
			if (attribute.Value != null)
			{
				attribute.Value = attribute.Value.ToLower();
			}
		}
	}
}
