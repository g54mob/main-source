using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.ModTools.Serialization.Xml
{
	internal class AnimationCurveXmlSerializer : UnityXmlElementSerializer<AnimationCurve>
	{
		public override AnimationCurve ReadValue(XElement element, Type type, UnityXmlSerializerContext context)
		{
			Keyframe[] array = new Keyframe[(int)element.Attribute("length")];
			List<XElement> list = element.Elements().ToList();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = context.Serializer.Deserialize<Keyframe>(list[i]);
			}
			return new AnimationCurve(array);
		}

		public override void WriteValue(XElement element, AnimationCurve value, UnityXmlSerializerContext context)
		{
			element.Add(new XAttribute("length", value.length));
			Keyframe[] keys = value.keys;
			foreach (Keyframe obj in keys)
			{
				XElement xElement = new XElement("Keyframe");
				context.Serializer.Serialize(xElement, obj);
				element.Add(xElement);
			}
		}
	}
}
