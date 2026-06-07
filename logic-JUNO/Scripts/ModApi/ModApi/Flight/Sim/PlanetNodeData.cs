using System.Xml.Linq;
using ModApi.Planet;

namespace ModApi.Flight.Sim
{
	public class PlanetNodeData
	{
		public string Name { get; set; }

		public double RotationAngle { get; set; }

		public double TrueAnomaly { get; set; }

		public double WaterWaveOffsetTime { get; set; }

		public PlanetNodeData()
		{
		}

		public PlanetNodeData(PlanetDataScript dataScript)
		{
			Name = dataScript.Name;
			RotationAngle = dataScript.PlanetarySystemDefinedData.InitialRotation + dataScript.AngularVelocity * (dataScript.OrbitData?.Time ?? 0.0);
			TrueAnomaly = dataScript.OrbitData?.TrueAnomaly ?? 0.0;
		}

		public PlanetNodeData(XElement xml)
		{
			Name = (string)xml.Attribute("name");
			RotationAngle = ((double?)xml.Attribute("rotation")).GetValueOrDefault();
			TrueAnomaly = ((double?)xml.Attribute("trueAnomaly")).GetValueOrDefault();
			WaterWaveOffsetTime = ((double?)xml.Attribute("waterWaveOffsetTime")).GetValueOrDefault();
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Planet");
			xElement.SetAttributeValue("name", Name);
			xElement.SetAttributeValue("rotation", RotationAngle);
			xElement.SetAttributeValue("trueAnomaly", TrueAnomaly);
			if (WaterWaveOffsetTime != 0.0)
			{
				xElement.SetAttributeValue("waterWaveOffsetTime", WaterWaveOffsetTime);
			}
			return xElement;
		}
	}
}
