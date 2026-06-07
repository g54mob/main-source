using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class QuaternionXmlSerializer : UnityXmlAttributeSerializer<Quaternion>
	{
		public override Quaternion ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Quaternion(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public override void WriteValue(XAttribute attribute, Quaternion value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}
	}
}
