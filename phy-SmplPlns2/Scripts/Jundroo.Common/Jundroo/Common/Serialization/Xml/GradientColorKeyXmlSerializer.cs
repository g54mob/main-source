using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class GradientColorKeyXmlSerializer : UnityXmlAttributeSerializer<GradientColorKey>
	{
		public override GradientColorKey ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new GradientColorKey(new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2])), DataIO.ParseFloat(array[3]));
		}

		public override void WriteValue(XAttribute attribute, GradientColorKey value, UnityXmlSerializerContext context)
		{
			Color color = value.color;
			attribute.SetValue(DataIO.ToString(color.r) + "," + DataIO.ToString(color.g) + "," + DataIO.ToString(color.b) + "," + DataIO.ToString(value.time));
		}
	}
}
