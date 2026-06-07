using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class Vector3XmlSerializer : UnityXmlAttributeSerializer<Vector3>
	{
		public override Vector3 ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Vector3(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
		}

		public override void WriteValue(XAttribute attribute, Vector3 value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}
	}
}
