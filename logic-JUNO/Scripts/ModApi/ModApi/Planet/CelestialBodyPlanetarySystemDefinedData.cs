using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class CelestialBodyPlanetarySystemDefinedData
	{
		[SerializeField]
		private double _initialRotation;

		[SerializeField]
		private OrbitData _orbit;

		[SerializeField]
		private string _overrideDescription;

		[SerializeField]
		private string _overrideName;

		[SerializeField]
		private CelestialBodyScaleData _scale;

		public double? AngularVelocity { get; set; }

		public double InitialRotation
		{
			get
			{
				return _initialRotation;
			}
			set
			{
				_initialRotation = value;
			}
		}

		public Color? NavballBottomColorOverride { get; set; }

		public Color? NavballTopColorOverride { get; set; }

		public OrbitData Orbit
		{
			get
			{
				return _orbit;
			}
			set
			{
				_orbit = value;
			}
		}

		public Color OrbitColor { get; set; }

		public string OverrideDescription
		{
			get
			{
				return _overrideDescription;
			}
			set
			{
				_overrideDescription = value;
			}
		}

		public string OverrideName
		{
			get
			{
				return _overrideName;
			}
			set
			{
				_overrideName = value;
			}
		}

		public CelestialBodyScaleData Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public double? SphereOfInfluence { get; set; }

		public CelestialBodyPlanetarySystemDefinedData()
		{
			Orbit = null;
			InitialRotation = 0.0;
			OverrideName = null;
			OverrideDescription = null;
			Scale = new CelestialBodyScaleData();
			OrbitColor = GenerateColor();
		}

		public CelestialBodyPlanetarySystemDefinedData(XElement xml)
		{
			if (xml != null)
			{
				InitialRotation = ((double?)xml.Attribute("initialRotation")).GetValueOrDefault();
				Orbit = ((xml.Element("Orbit") == null) ? null : new OrbitData(xml.Element("Orbit")));
				Scale = CelestialBodyScaleData.CreateFromXml(xml.Element("Scale"));
				SphereOfInfluence = (double?)xml.Attribute("sphereOfInfluence");
				AngularVelocity = (double?)xml.Attribute("angularVelocity");
				OrbitColor = xml.GetColorAttribute("orbitColor", XmlColorFormat.HexRGB) ?? GenerateColor();
				NavballBottomColorOverride = xml.GetColorAttribute("navballBottomColor", XmlColorFormat.HexRGBA);
				NavballTopColorOverride = xml.GetColorAttribute("navballTopColor", XmlColorFormat.HexRGBA);
				XElement xElement = xml.Element("Overrides");
				if (xElement != null)
				{
					OverrideName = xElement.GetStringAttributeOrNullIfEmpty("name");
					OverrideDescription = xElement.GetStringElementOrNullIfEmpty("Description");
				}
			}
		}

		public XElement GenerateXml(string xmlElementName, bool saveOrbit = true)
		{
			bool flag = !string.IsNullOrEmpty(OverrideName);
			bool flag2 = !string.IsNullOrEmpty(OverrideDescription);
			bool flag3 = !flag && !flag2;
			return new XElement(xmlElementName, (InitialRotation == 0.0) ? null : new XAttribute("initialRotation", InitialRotation), SphereOfInfluence.HasValue ? new XAttribute("sphereOfInfluence", SphereOfInfluence.Value) : null, AngularVelocity.HasValue ? new XAttribute("angularVelocity", AngularVelocity.Value) : null, (Orbit == null || !saveOrbit) ? null : Orbit.GenerateXml(), new XAttribute("orbitColor", "#" + OrbitColor.ToXAttributeValue(XmlColorFormat.HexRGB)), NavballBottomColorOverride.HasValue ? new XAttribute("navballBottomColor", "#" + NavballBottomColorOverride.Value.ToXAttributeValue(XmlColorFormat.HexRGBA)) : null, NavballTopColorOverride.HasValue ? new XAttribute("navballTopColor", "#" + NavballTopColorOverride.Value.ToXAttributeValue(XmlColorFormat.HexRGBA)) : null, (Scale == null || Scale.IsOne()) ? null : Scale.GenerateXml("Scale"), flag3 ? null : new XElement("Overrides", flag ? null : new XAttribute("name", OverrideName), flag2 ? null : new XElement("Description", OverrideDescription)));
		}

		private static Color GenerateColor()
		{
			return UnityEngine.Random.ColorHSV(0f, 1f, 0.4f, 0.6f, 0.4f, 0.6f);
		}
	}
}
