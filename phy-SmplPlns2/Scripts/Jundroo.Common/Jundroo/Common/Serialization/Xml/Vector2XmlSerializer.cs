using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class Vector2XmlSerializer : UnityXmlAttributeSerializer<Vector2>
	{
		public override Vector2 ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Vector2(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]));
		}

		public override void WriteValue(XAttribute attribute, Vector2 value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}
	}
}
