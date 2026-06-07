using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class GradientAlphaKeyXmlSerializer : UnityXmlAttributeSerializer<GradientAlphaKey>
	{
		public override GradientAlphaKey ReadValue(XAttribute attribute, Type type, UnityXmlSerializerContext context)
		{
			string[] array = attribute.Value.Split(',');
			return new GradientAlphaKey(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]));
		}

		public override void WriteValue(XAttribute attribute, GradientAlphaKey value, UnityXmlSerializerContext context)
		{
			attribute.SetValue(DataIO.ToString(value.alpha) + "," + DataIO.ToString(value.time));
		}
	}
}
