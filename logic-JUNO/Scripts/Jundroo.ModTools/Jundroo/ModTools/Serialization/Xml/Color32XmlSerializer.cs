using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class Color32XmlSerializer : UnityXmlAttributeSerializer<Color32>
	{
		public override Color32 ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			if (array.Length != 3)
			{
				return new Color32(DataIO.ParseByte(array[0]), DataIO.ParseByte(array[1]), DataIO.ParseByte(array[2]), DataIO.ParseByte(array[3]));
			}
			return new Color32(DataIO.ParseByte(array[0]), DataIO.ParseByte(array[1]), DataIO.ParseByte(array[2]), byte.MaxValue);
		}

		public override void WriteValue(XAttribute attribute, Color32 value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a));
		}
	}
}
