using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class ColorXmlSerializer : UnityXmlAttributeSerializer<Color>
	{
		public override Color ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			if (array.Length != 3)
			{
				return new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
			}
			return new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
		}

		public override void WriteValue(XAttribute attribute, Color value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a));
		}
	}
}
