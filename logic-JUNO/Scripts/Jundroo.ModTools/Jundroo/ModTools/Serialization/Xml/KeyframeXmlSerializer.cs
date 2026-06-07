using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class KeyframeXmlSerializer : UnityXmlAttributeSerializer<Keyframe>
	{
		public override Keyframe ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new Keyframe(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public override void WriteValue(XAttribute attribute, Keyframe value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.time) + "," + DataIO.ToString(value.value) + "," + DataIO.ToString(value.inTangent) + "," + DataIO.ToString(value.outTangent));
		}
	}
}
