using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class SandboxDetailsModel
	{
		public class ActiveCraftDetailsModel
		{
			public long Altitude { get; set; }

			public int CraftMass { get; set; }

			public int CraftPartCount { get; set; }

			public bool Grounded { get; set; }

			public string Name { get; set; }

			public string Planet { get; set; }

			public long Velocity { get; set; }

			public ActiveCraftDetailsModel()
			{
			}

			public ActiveCraftDetailsModel(XElement xml)
			{
				Name = xml.Attribute("Name").Value;
				Altitude = long.Parse(xml.Attribute("Altitude").Value);
				CraftMass = int.Parse(xml.Attribute("CraftMass").Value);
				CraftPartCount = int.Parse(xml.Attribute("CraftPartCount").Value);
				Planet = xml.Attribute("Planet").Value;
				Velocity = long.Parse(xml.Attribute("Velocity").Value);
				Grounded = bool.Parse(xml.Attribute("Grounded").Value);
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Craft");
				xElement.SetAttributeValue("Name", Name);
				xElement.SetAttributeValue("Altitude", Altitude);
				xElement.SetAttributeValue("CraftMass", CraftMass);
				xElement.SetAttributeValue("CraftPartCount", CraftPartCount);
				xElement.SetAttributeValue("Planet", Planet);
				xElement.SetAttributeValue("Velocity", Velocity);
				xElement.SetAttributeValue("Grounded", Grounded);
				return xElement;
			}
		}

		public const int CurrentVersion = 1;

		public List<ActiveCraftDetailsModel> Crafts { get; private set; }

		public int PlanetCount { get; set; }

		public string SolarSystemName { get; set; }

		public long Time { get; set; }

		public int Version { get; set; }

		public SandboxDetailsModel()
		{
			Version = 1;
			Crafts = new List<ActiveCraftDetailsModel>();
		}

		public SandboxDetailsModel(string xmlString)
			: this()
		{
			XElement xElement = XDocument.Parse(xmlString).Element("SandboxDetails");
			Version = int.Parse(xElement.Attribute("Version").Value);
			Time = long.Parse(xElement.Attribute("Time").Value);
			PlanetCount = int.Parse(xElement.Attribute("PlanetCount").Value);
			SolarSystemName = xElement.Attribute("SolarSystemName").Value;
			foreach (XElement item2 in xElement.Element("Crafts").Elements("Craft"))
			{
				ActiveCraftDetailsModel item = new ActiveCraftDetailsModel(item2);
				Crafts.Add(item);
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("SandboxDetails");
			xElement.SetAttributeValue("Version", Version);
			xElement.SetAttributeValue("Time", Time);
			xElement.SetAttributeValue("SolarSystemName", SolarSystemName);
			xElement.SetAttributeValue("PlanetCount", PlanetCount);
			XElement xElement2 = new XElement("Crafts");
			xElement.Add(xElement2);
			foreach (ActiveCraftDetailsModel craft in Crafts)
			{
				xElement2.Add(craft.GenerateXml());
			}
			return xElement.ToString();
		}
	}
}
