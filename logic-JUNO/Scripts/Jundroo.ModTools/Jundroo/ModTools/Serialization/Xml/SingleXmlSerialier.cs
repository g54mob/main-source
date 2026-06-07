using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class SingleXmlSerialier : UnityXmlAttributeSerializer<float>
	{
		public override bool SupportsCollections => true;

		public override float ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (float)attribute;
		}

		public override IEnumerable<float> ReadValues(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return ReadValues(Convert.ToSingle, attribute, type, context);
		}

		public override void WriteValue(XAttribute attribute, float value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value);
		}
	}
}
