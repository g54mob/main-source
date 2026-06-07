using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class LayerMaskXmlSerializer : UnityXmlAttributeSerializer<LayerMask>
	{
		public override LayerMask ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			return (int)attribute;
		}

		public override void WriteValue(XAttribute attribute, LayerMask value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(value.value);
		}
	}
}
