using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class CraftDetailsModel
	{
		public class StageDetailsModel
		{
			public float BurnTime { get; set; }

			public float DeltaV { get; set; }

			public float EndingMass { get; set; }

			public int NumEngines { get; set; }

			public int NumParts { get; set; }

			public int StageNumber { get; set; }

			public float StartingMass { get; set; }

			public float TotalThrust { get; set; }

			public StageDetailsModel()
			{
			}

			public StageDetailsModel(XElement xml)
			{
				BurnTime = float.Parse(xml.Attribute("BurnTime").Value);
				DeltaV = float.Parse(xml.Attribute("DeltaV").Value);
				EndingMass = float.Parse(xml.Attribute("EndingMass").Value);
				NumEngines = int.Parse(xml.Attribute("NumEngines").Value);
				NumParts = int.Parse(xml.Attribute("NumParts").Value);
				StageNumber = int.Parse(xml.Attribute("StageNumber").Value);
				StartingMass = float.Parse(xml.Attribute("StartingMass").Value);
				TotalThrust = float.Parse(xml.Attribute("TotalThrust").Value);
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Stage");
				xElement.SetAttributeValue("BurnTime", BurnTime);
				xElement.SetAttributeValue("DeltaV", DeltaV);
				xElement.SetAttributeValue("EndingMass", EndingMass);
				xElement.SetAttributeValue("NumEngines", NumEngines);
				xElement.SetAttributeValue("NumParts", NumParts);
				xElement.SetAttributeValue("StageNumber", StageNumber);
				xElement.SetAttributeValue("StartingMass", StartingMass);
				xElement.SetAttributeValue("TotalThrust", TotalThrust);
				return xElement;
			}
		}

		public const int CurrentVersion = 1;

		public float DeltaV { get; set; }

		public float DryMass { get; set; }

		public int NumEngines { get; set; }

		public long Price { get; set; }

		public float SizeX { get; set; }

		public float SizeY { get; set; }

		public float SizeZ { get; set; }

		public List<StageDetailsModel> Stages { get; set; }

		public float TotalThrust { get; set; }

		public int Version { get; set; }

		public float WetMass { get; set; }

		public CraftDetailsModel()
		{
			Version = 1;
			Stages = new List<StageDetailsModel>();
		}

		public CraftDetailsModel(string xmlString)
			: this()
		{
			XElement xElement = XDocument.Parse(xmlString).Element("CraftDetails");
			Version = int.Parse(xElement.Attribute("Version").Value);
			DeltaV = float.Parse(xElement.Attribute("DeltaV").Value);
			DryMass = float.Parse(xElement.Attribute("DryMass").Value);
			WetMass = float.Parse(xElement.Attribute("WetMass").Value);
			TotalThrust = float.Parse(xElement.Attribute("TotalThrust").Value);
			NumEngines = int.Parse(xElement.Attribute("NumEngines").Value);
			Price = long.Parse(xElement.Attribute("Price").Value);
			SizeX = float.Parse(xElement.Attribute("SizeX").Value);
			SizeY = float.Parse(xElement.Attribute("SizeY").Value);
			SizeZ = float.Parse(xElement.Attribute("SizeZ").Value);
			foreach (XElement item2 in xElement.Element("Stages").Elements("Stage"))
			{
				StageDetailsModel item = new StageDetailsModel(item2);
				Stages.Add(item);
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("CraftDetails");
			xElement.SetAttributeValue("Version", Version);
			xElement.SetAttributeValue("DeltaV", DeltaV);
			xElement.SetAttributeValue("DryMass", DryMass);
			xElement.SetAttributeValue("WetMass", WetMass);
			xElement.SetAttributeValue("TotalThrust", TotalThrust);
			xElement.SetAttributeValue("NumEngines", NumEngines);
			xElement.SetAttributeValue("Price", Price);
			xElement.SetAttributeValue("SizeX", SizeX);
			xElement.SetAttributeValue("SizeY", SizeY);
			xElement.SetAttributeValue("SizeZ", SizeZ);
			XElement xElement2 = new XElement("Stages");
			xElement.Add(xElement2);
			foreach (StageDetailsModel stage in Stages)
			{
				xElement2.Add(stage.GenerateXml());
			}
			return xElement.ToString();
		}
	}
}
