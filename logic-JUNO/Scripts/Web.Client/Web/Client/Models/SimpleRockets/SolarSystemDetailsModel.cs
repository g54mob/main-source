using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class SolarSystemDetailsModel
	{
		public class PlanetDetailsModel
		{
			public double AngularVelocity { get; private set; }

			public double AtmosphereDensity { get; private set; }

			public double EscapeVelocity { get; private set; }

			public bool HasWater { get; private set; }

			public double Mass { get; private set; }

			public string Name { get; private set; }

			public string Parent { get; private set; }

			public double Radius { get; private set; }

			public double SurfaceGravity { get; private set; }

			public PlanetDetailsModel()
			{
			}

			public PlanetDetailsModel(XElement xml)
			{
				AngularVelocity = double.Parse(xml.Attribute("AngularVelocity").Value);
				AtmosphereDensity = double.Parse(xml.Attribute("AtmosphereDensity").Value);
				EscapeVelocity = double.Parse(xml.Attribute("EscapeVelocity").Value);
				HasWater = bool.Parse(xml.Attribute("HasWater").Value);
				Mass = double.Parse(xml.Attribute("Mass").Value);
				Name = xml.Attribute("Name").Value;
				Parent = xml.Attribute("Name").Value;
				Radius = double.Parse(xml.Attribute("Radius").Value);
				SurfaceGravity = double.Parse(xml.Attribute("SurfaceGravity").Value);
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Planet");
				xElement.SetAttributeValue("AngularVelocity", AngularVelocity);
				xElement.SetAttributeValue("AtmosphereDensity", AtmosphereDensity);
				xElement.SetAttributeValue("EscapeVelocity", EscapeVelocity);
				xElement.SetAttributeValue("HasWater", HasWater);
				xElement.SetAttributeValue("Mass", Mass);
				xElement.SetAttributeValue("Name", Name);
				xElement.SetAttributeValue("Parent", Parent);
				xElement.SetAttributeValue("Radius", Radius);
				xElement.SetAttributeValue("SurfaceGravity", SurfaceGravity);
				return xElement;
			}
		}

		public const int CurrentVersion = 1;

		public List<PlanetDetailsModel> Planets { get; private set; }

		public int Version { get; set; }

		public SolarSystemDetailsModel()
		{
			Version = 1;
			Planets = new List<PlanetDetailsModel>();
		}

		public SolarSystemDetailsModel(string xmlString)
			: this()
		{
			XElement xElement = XDocument.Parse(xmlString).Element("SolarSystemDetails");
			Version = int.Parse(xElement.Attribute("Version").Value);
			foreach (XElement item2 in xElement.Element("Planets").Elements("Planet"))
			{
				PlanetDetailsModel item = new PlanetDetailsModel(item2);
				Planets.Add(item);
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("SolarSystemDetails");
			xElement.SetAttributeValue("Version", Version);
			XElement xElement2 = new XElement("Planets");
			xElement.Add(xElement2);
			foreach (PlanetDetailsModel planet in Planets)
			{
				xElement2.Add(planet.GenerateXml());
			}
			return xElement.ToString();
		}
	}
}
