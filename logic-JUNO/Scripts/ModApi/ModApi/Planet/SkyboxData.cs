using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class SkyboxData
	{
		public float Exposure { get; private set; }

		public float Rotation { get; private set; }

		public Color Tint { get; private set; }

		public string XNegativeTextureId { get; private set; }

		public string XPositiveTextureId { get; private set; }

		public string YNegativeTextureId { get; private set; }

		public string YPositiveTextureId { get; private set; }

		public string ZNegativeTextureId { get; private set; }

		public string ZPositiveTextureId { get; private set; }

		public SkyboxData()
		{
			Exposure = 1f;
			Rotation = 0f;
			Tint = Color.white;
		}

		public static SkyboxData LoadFromXml(XElement xml)
		{
			if (xml == null)
			{
				return null;
			}
			return new SkyboxData
			{
				XPositiveTextureId = (string)xml.Attribute("xpositiveTextureId"),
				XNegativeTextureId = (string)xml.Attribute("xnegativeTextureId"),
				YPositiveTextureId = (string)xml.Attribute("ypositiveTextureId"),
				YNegativeTextureId = (string)xml.Attribute("ynegativeTextureId"),
				ZPositiveTextureId = (string)xml.Attribute("zpositiveTextureId"),
				ZNegativeTextureId = (string)xml.Attribute("znegativeTextureId"),
				Exposure = (((float?)xml.Attribute("exposure")) ?? 1f),
				Rotation = ((float?)xml.Attribute("rotation")).GetValueOrDefault(),
				Tint = xml.GetColorAttribute("tint", Color.white, XmlColorFormat.HexRGB)
			};
		}

		public XElement GenerateXml(string xmlElementName)
		{
			if (string.IsNullOrEmpty(XPositiveTextureId) && string.IsNullOrEmpty(XNegativeTextureId) && string.IsNullOrEmpty(YPositiveTextureId) && string.IsNullOrEmpty(YNegativeTextureId) && string.IsNullOrEmpty(ZPositiveTextureId) && string.IsNullOrEmpty(ZNegativeTextureId))
			{
				return null;
			}
			return new XElement(xmlElementName, new XAttribute("xpositiveTextureId", XPositiveTextureId ?? string.Empty), new XAttribute("xnegativeTextureId", XNegativeTextureId ?? string.Empty), new XAttribute("ypositiveTextureId", YPositiveTextureId ?? string.Empty), new XAttribute("ynegativeTextureId", YNegativeTextureId ?? string.Empty), new XAttribute("zpositiveTextureId", ZPositiveTextureId ?? string.Empty), new XAttribute("znegativeTextureId", ZNegativeTextureId ?? string.Empty), new XAttribute("exposure", Exposure), new XAttribute("rotation", Rotation), new XAttribute("tint", Tint.ToXAttributeValue(XmlColorFormat.HexRGB)));
		}
	}
}
