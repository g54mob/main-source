using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetRingsData : IPlanetRingsData
	{
		public bool HasRings { get; set; }

		public double InnerRadius { get; private set; }

		public double InnerRadiusScaled { get; set; }

		public double OuterRadius { get; private set; }

		public double OuterRadiusScaled { get; set; }

		public Vector3 Rotation { get; set; }

		public string Texture { get; set; }

		private PlanetRingsData()
		{
			InnerRadiusScaled = 1.5;
			OuterRadiusScaled = 2.5;
		}

		public static PlanetRingsData CreateFromXml(XElement xml, PlanetDataScript script)
		{
			PlanetRingsData planetRingsData = new PlanetRingsData();
			if (xml != null)
			{
				planetRingsData.HasRings = true;
				planetRingsData.InnerRadiusScaled = xml.GetDoubleAttribute("innerRadius");
				planetRingsData.OuterRadiusScaled = xml.GetDoubleAttribute("outerRadius");
				planetRingsData.Rotation = xml.GetVector3Attribute("rotation");
				planetRingsData.Texture = xml.GetStringAttribute("texture");
				planetRingsData.InnerRadius = planetRingsData.InnerRadiusScaled * script.Radius;
				planetRingsData.OuterRadius = planetRingsData.OuterRadiusScaled * script.Radius;
			}
			else
			{
				planetRingsData.HasRings = false;
			}
			return planetRingsData;
		}

		public XElement SaveXml(XElement xml)
		{
			if (HasRings)
			{
				xml.SetAttributeValue("innerRadius", InnerRadiusScaled);
				xml.SetAttributeValue("outerRadius", OuterRadiusScaled);
				xml.SetAttribute("rotation", Rotation);
				xml.SetAttributeValue("texture", Texture);
				return xml;
			}
			return null;
		}
	}
}
