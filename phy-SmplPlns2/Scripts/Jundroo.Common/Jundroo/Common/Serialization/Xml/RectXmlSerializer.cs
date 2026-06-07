using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class RectXmlSerializer : UnityXmlAttributeSerializer<Rect>
	{
		public override Rect ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Rect(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public override void WriteValue(XAttribute attribute, Rect value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.xMin) + "," + DataIO.ToString(value.yMin) + "," + DataIO.ToString(value.width) + "," + DataIO.ToString(value.height));
		}
	}
}
