using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class PlanetarySystemDetailsModel
	{
		public class OrbitingBody
		{
			public class OrbitDetailsModel
			{
				public double ApoapsisDistance { get; set; }

				public double Eccentricity { get; set; }

				public double Inclination { get; set; }

				public double PeriapsisAngle { get; set; }

				public double PeriapsisDistance { get; set; }

				public double Period { get; set; }

				public double PrimaryMass { get; set; }

				public bool Prograde { get; set; }

				public double RightAscensionOfAscendingNode { get; set; }

				public double SemiMajorAxis { get; set; }

				public double TrueAnomaly { get; set; }

				public OrbitDetailsModel()
				{
				}

				public OrbitDetailsModel(XElement xml)
				{
					ApoapsisDistance = double.Parse(xml.Attribute("ApoapsisDistance").Value);
					Eccentricity = double.Parse(xml.Attribute("Eccentricity").Value);
					Inclination = double.Parse(xml.Attribute("Inclination").Value);
					PeriapsisAngle = double.Parse(xml.Attribute("PeriapsisAngle").Value);
					PeriapsisDistance = double.Parse(xml.Attribute("PeriapsisDistance").Value);
					Period = double.Parse(xml.Attribute("Period").Value);
					PrimaryMass = double.Parse(xml.Attribute("PrimaryMass").Value);
					Prograde = bool.Parse(xml.Attribute("Prograde").Value);
					RightAscensionOfAscendingNode = double.Parse(xml.Attribute("RightAscensionOfAscendingNode").Value);
					SemiMajorAxis = double.Parse(xml.Attribute("SemiMajorAxis").Value);
					TrueAnomaly = double.Parse(xml.Attribute("TrueAnomaly").Value);
				}

				public XElement GenerateXml()
				{
					XElement xElement = new XElement("Orbit");
					xElement.SetAttributeValue("ApoapsisDistance", ApoapsisDistance);
					xElement.SetAttributeValue("Eccentricity", Eccentricity);
					xElement.SetAttributeValue("Inclination", Inclination);
					xElement.SetAttributeValue("PeriapsisAngle", PeriapsisAngle);
					xElement.SetAttributeValue("PeriapsisDistance", PeriapsisDistance);
					xElement.SetAttributeValue("Period", Period);
					xElement.SetAttributeValue("PrimaryMass", PrimaryMass);
					xElement.SetAttributeValue("Prograde", Prograde);
					xElement.SetAttributeValue("RightAscensionOfAscendingNode", RightAscensionOfAscendingNode);
					xElement.SetAttributeValue("SemiMajorAxis", SemiMajorAxis);
					xElement.SetAttributeValue("TrueAnomaly", TrueAnomaly);
					return xElement;
				}
			}

			public double AngularVelocity { get; set; }

			public double AtmosphereHeight { get; set; }

			public double EscapeVelocity { get; set; }

			public bool HasRings { get; set; }

			public bool HasWater { get; set; }

			public double Mass { get; set; }

			public string Name { get; set; }

			public OrbitDetailsModel Orbit { get; set; }

			public string ParentName { get; set; }

			public double Radius { get; set; }

			public string ResourceHash { get; set; }

			public double SeaLevel { get; set; }

			public double SurfaceGravity { get; set; }

			public OrbitingBody()
			{
			}

			public OrbitingBody(XElement element)
			{
				Name = element.Attribute("Name").Value;
				ParentName = element.Attribute("ParentName")?.Value;
				ResourceHash = element.Attribute("ResourceHash").Value;
				AngularVelocity = double.Parse(element.Attribute("AngularVelocity").Value);
				AtmosphereHeight = double.Parse(element.Attribute("AtmosphereHeight").Value);
				EscapeVelocity = double.Parse(element.Attribute("EscapeVelocity").Value);
				HasRings = bool.Parse(element.Attribute("HasRings").Value);
				HasWater = bool.Parse(element.Attribute("HasWater").Value);
				Mass = double.Parse(element.Attribute("Mass").Value);
				Radius = double.Parse(element.Attribute("Radius").Value);
				SeaLevel = double.Parse(element.Attribute("SeaLevel").Value);
				SurfaceGravity = double.Parse(element.Attribute("SurfaceGravity").Value);
				Orbit = ((element.Element("Orbit") == null) ? null : new OrbitDetailsModel(element.Element("Orbit")));
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("OrbitingBody");
				xElement.Add(Orbit?.GenerateXml());
				xElement.SetAttributeValue("Name", Name);
				xElement.SetAttributeValue("ParentName", ParentName);
				xElement.SetAttributeValue("ResourceHash", ResourceHash);
				xElement.SetAttributeValue("AngularVelocity", AngularVelocity);
				xElement.SetAttributeValue("AtmosphereHeight", AtmosphereHeight);
				xElement.SetAttributeValue("EscapeVelocity", EscapeVelocity);
				xElement.SetAttributeValue("HasRings", HasRings);
				xElement.SetAttributeValue("HasWater", HasWater);
				xElement.SetAttributeValue("Mass", Mass);
				xElement.SetAttributeValue("Radius", Radius);
				xElement.SetAttributeValue("SeaLevel", SeaLevel);
				xElement.SetAttributeValue("SurfaceGravity", SurfaceGravity);
				return xElement;
			}
		}

		public const int CurrentVersion = 1;

		public List<OrbitingBody> OrbitingBodies { get; private set; }

		public Version PlanetarySystemVersion { get; set; }

		public string PlanetarySystemVersionTag { get; set; }

		public int Version { get; set; }

		public PlanetarySystemDetailsModel()
		{
			Version = 1;
			PlanetarySystemVersion = new Version(1, 0);
			PlanetarySystemVersionTag = null;
			OrbitingBodies = new List<OrbitingBody>();
		}

		public PlanetarySystemDetailsModel(string xmlString)
			: this()
		{
			XElement xElement = XDocument.Parse(xmlString).Element("PlanetarySystemDetails");
			Version = int.Parse(xElement.Attribute("Version").Value);
			string text = (string)xElement.Attribute("psVersion");
			PlanetarySystemVersion = (string.IsNullOrWhiteSpace(text) ? new Version(1, 0) : new Version(text));
			PlanetarySystemVersionTag = (string)xElement.Attribute("psVersionTag");
			IEnumerable<XElement> enumerable = xElement.Element("OrbitingBodies")?.Elements("OrbitingBody");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item2 in enumerable)
			{
				OrbitingBody item = new OrbitingBody(item2);
				OrbitingBodies.Add(item);
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("PlanetarySystemDetails");
			xElement.SetAttributeValue("Version", Version);
			if (PlanetarySystemVersion != null)
			{
				xElement.SetAttributeValue("psVersion", PlanetarySystemVersion.ToString());
			}
			if (!string.IsNullOrWhiteSpace(PlanetarySystemVersionTag))
			{
				xElement.SetAttributeValue("psVersionTag", PlanetarySystemVersionTag);
			}
			XElement xElement2 = new XElement("OrbitingBodies");
			xElement.Add(xElement2);
			foreach (OrbitingBody orbitingBody in OrbitingBodies)
			{
				xElement2.Add(orbitingBody.GenerateXml());
			}
			return xElement.ToString();
		}
	}
}
