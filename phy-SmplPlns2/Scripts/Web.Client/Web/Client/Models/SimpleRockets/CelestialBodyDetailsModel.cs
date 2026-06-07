using System;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class CelestialBodyDetailsModel
	{
		public class AtmosphereDetailsModel
		{
			public double CrushAltitude { get; set; }

			public string Description { get; set; }

			public bool HasPhysicsAtmosphere { get; set; }

			public double Height { get; set; }

			public double MeanGamma { get; set; }

			public double MeanMassPerMolecule { get; set; }

			public double MeanSurfaceTemperature { get; set; }

			public double MeanSurfaceTemperatureDay { get; set; }

			public double MeanSurfaceTemperatureNight { get; set; }

			public double ScaleHeight { get; set; }

			public double SurfaceAirDensity { get; set; }

			public AtmosphereDetailsModel()
			{
			}

			public AtmosphereDetailsModel(XElement xml)
			{
				CrushAltitude = double.Parse(xml.Attribute("CrushAltitude").Value);
				Description = xml.Attribute("Description").Value;
				HasPhysicsAtmosphere = bool.Parse(xml.Attribute("HasPhysicsAtmosphere").Value);
				MeanMassPerMolecule = double.Parse(xml.Attribute("MeanMassPerMolecule").Value);
				MeanSurfaceTemperatureNight = double.Parse(xml.Attribute("MeanSurfaceTemperatureNight").Value);
				MeanSurfaceTemperatureDay = double.Parse(xml.Attribute("MeanSurfaceTemperatureDay").Value);
				MeanGamma = double.Parse(xml.Attribute("MeanGamma").Value);
				ScaleHeight = double.Parse(xml.Attribute("ScaleHeight").Value);
				SurfaceAirDensity = double.Parse(xml.Attribute("SurfaceAirDensity").Value);
				Height = double.Parse(xml.Attribute("Height").Value);
				MeanSurfaceTemperature = double.Parse(xml.Attribute("MeanSurfaceTemperature").Value);
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Atmosphere");
				xElement.SetAttributeValue("CrushAltitude", CrushAltitude);
				xElement.SetAttributeValue("Description", Description);
				xElement.SetAttributeValue("HasPhysicsAtmosphere", HasPhysicsAtmosphere);
				xElement.SetAttributeValue("MeanMassPerMolecule", MeanMassPerMolecule);
				xElement.SetAttributeValue("MeanSurfaceTemperatureNight", MeanSurfaceTemperatureNight);
				xElement.SetAttributeValue("MeanSurfaceTemperatureDay", MeanSurfaceTemperatureDay);
				xElement.SetAttributeValue("MeanGamma", MeanGamma);
				xElement.SetAttributeValue("ScaleHeight", ScaleHeight);
				xElement.SetAttributeValue("SurfaceAirDensity", SurfaceAirDensity);
				xElement.SetAttributeValue("Height", Height);
				xElement.SetAttributeValue("MeanSurfaceTemperature", MeanSurfaceTemperature);
				return xElement;
			}
		}

		public const int CurrentVersion = 1;

		public double AngularVelocity { get; set; }

		public AtmosphereDetailsModel Atmosphere { get; set; }

		public Version CelestialBodyVersion { get; set; }

		public string CelestialBodyVersionTag { get; set; }

		public double EscapeVelocity { get; set; }

		public bool HasRings { get; set; }

		public bool HasTerrainPhysics { get; set; }

		public bool HasWater { get; set; }

		public double Mass { get; set; }

		public double Radius { get; set; }

		public double SeaLevel { get; set; }

		public double SurfaceGravity { get; set; }

		public int Version { get; set; }

		public CelestialBodyDetailsModel()
		{
			Version = 1;
			CelestialBodyVersion = new Version(1, 0);
			CelestialBodyVersionTag = null;
			Atmosphere = new AtmosphereDetailsModel();
		}

		public CelestialBodyDetailsModel(string xmlString)
			: this()
		{
			XElement element = XDocument.Parse(xmlString).Element("CelestialBodyDetails");
			RestoreFromXml(element);
		}

		public CelestialBodyDetailsModel(XElement element)
		{
			RestoreFromXml(element);
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("CelestialBodyDetails");
			xElement.SetAttributeValue("Version", Version);
			if (CelestialBodyVersion != null)
			{
				xElement.SetAttributeValue("cbVersion", CelestialBodyVersion.ToString());
			}
			if (!string.IsNullOrWhiteSpace(CelestialBodyVersionTag))
			{
				xElement.SetAttributeValue("cbVersionTag", CelestialBodyVersionTag);
			}
			xElement.Add(Atmosphere.GenerateXml());
			xElement.SetAttributeValue("AngularVelocity", AngularVelocity);
			xElement.SetAttributeValue("EscapeVelocity", EscapeVelocity);
			xElement.SetAttributeValue("HasRings", HasRings);
			xElement.SetAttributeValue("HasTerrainPhysics", HasTerrainPhysics);
			xElement.SetAttributeValue("HasWater", HasWater);
			xElement.SetAttributeValue("Mass", Mass);
			xElement.SetAttributeValue("Radius", Radius);
			xElement.SetAttributeValue("SeaLevel", SeaLevel);
			xElement.SetAttributeValue("SurfaceGravity", SurfaceGravity);
			return xElement.ToString();
		}

		public void RestoreFromXml(XElement element)
		{
			Version = int.Parse(element.Attribute("Version").Value);
			string text = (string)element.Attribute("cbVersion");
			CelestialBodyVersion = (string.IsNullOrWhiteSpace(text) ? new Version(1, 0) : new Version(text));
			CelestialBodyVersionTag = (string)element.Attribute("cbVersionTag");
			Atmosphere = new AtmosphereDetailsModel(element.Element("Atmosphere"));
			AngularVelocity = double.Parse(element.Attribute("AngularVelocity").Value);
			EscapeVelocity = double.Parse(element.Attribute("EscapeVelocity").Value);
			HasRings = bool.Parse(element.Attribute("HasRings").Value);
			HasTerrainPhysics = bool.Parse(element.Attribute("HasTerrainPhysics").Value);
			HasWater = bool.Parse(element.Attribute("HasWater").Value);
			Mass = double.Parse(element.Attribute("Mass").Value);
			Radius = double.Parse(element.Attribute("Radius").Value);
			SeaLevel = double.Parse(element.Attribute("SeaLevel").Value);
			SurfaceGravity = double.Parse(element.Attribute("SurfaceGravity").Value);
		}
	}
}
