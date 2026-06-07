using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class BoundsXmlSerializer : UnityXmlAttributeSerializer<Bounds>
	{
		public override Bounds ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Bounds(new Vector3(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2])), new Vector3(DataIO.ParseFloat(array[3]), DataIO.ParseFloat(array[4]), DataIO.ParseFloat(array[5])));
		}

		public override void WriteValue(XAttribute attribute, Bounds value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.center.x) + "," + DataIO.ToString(value.center.y) + "," + DataIO.ToString(value.center.z) + "," + DataIO.ToString(value.size.x) + "," + DataIO.ToString(value.size.y) + "," + DataIO.ToString(value.size.z));
		}
	}
}
