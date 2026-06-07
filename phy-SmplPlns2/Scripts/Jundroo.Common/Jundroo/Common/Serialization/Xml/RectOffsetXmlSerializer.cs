using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class RectOffsetXmlSerializer : UnityXmlAttributeSerializer<RectOffset>
	{
		public override RectOffset ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new RectOffset(DataIO.ParseInt(array[0]), DataIO.ParseInt(array[1]), DataIO.ParseInt(array[2]), DataIO.ParseInt(array[3]));
		}

		public override void WriteValue(XAttribute attribute, RectOffset value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.left) + "," + DataIO.ToString(value.right) + "," + DataIO.ToString(value.top) + "," + DataIO.ToString(value.bottom));
		}
	}
}
