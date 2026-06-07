using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class Vector4XmlSerializer : UnityXmlAttributeSerializer<Vector4>
	{
		public override Vector4 ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Vector4(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public override void WriteValue(XAttribute attribute, Vector4 value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}
	}
}
