using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Serialization.Xml
{
	internal class GradientXmlSerializer : UnityXmlElementSerializer<Gradient>
	{
		public override Gradient ReadValue(XElement element, Type type, UnityXmlSerializerContext context)
		{
			XElement xElement = element.Element("ColorKeys");
			List<XElement> list = xElement.Elements().ToList();
			GradientColorKey[] array = new GradientColorKey[(int)xElement.Attribute("length")];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = context.Serializer.Deserialize<GradientColorKey>(list[i]);
			}
			XElement xElement2 = element.Element("AlphaKeys");
			List<XElement> list2 = xElement2.Elements().ToList();
			GradientAlphaKey[] array2 = new GradientAlphaKey[(int)xElement2.Attribute("length")];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = context.Serializer.Deserialize<GradientAlphaKey>(list2[j]);
			}
			Gradient gradient = new Gradient();
			gradient.SetKeys(array, array2);
			return gradient;
		}

		public override void WriteValue(XElement element, Gradient value, UnityXmlSerializerContext context)
		{
			XElement xElement = new XElement("ColorKeys", new XAttribute("length", value.colorKeys.Length));
			GradientColorKey[] colorKeys = value.colorKeys;
			foreach (GradientColorKey obj in colorKeys)
			{
				XElement xElement2 = new XElement("Item");
				context.Serializer.Serialize(xElement2, obj);
				xElement.Add(xElement2);
			}
			XElement xElement3 = new XElement("AlphaKeys", new XAttribute("length", value.alphaKeys.Length));
			GradientAlphaKey[] alphaKeys = value.alphaKeys;
			foreach (GradientAlphaKey obj2 in alphaKeys)
			{
				XElement xElement4 = new XElement("Item");
				context.Serializer.Serialize(xElement4, obj2);
				xElement3.Add(xElement4);
			}
			element.Add(xElement, xElement3);
		}
	}
}
