using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace ModApi.State
{
	public class InitialCraftNodeData
	{
		public int InitialCrewCount { get; private set; }

		public string LaunchLocationName { get; private set; }

		public LaunchLocationType LaunchLocationType { get; private set; }

		public float LaunchMass { get; private set; }

		public string LaunchPlanetName { get; private set; }

		public long LaunchPrice { get; private set; }

		public double LaunchTime { get; private set; }

		public string Name { get; private set; }

		public int NodeId { get; }

		public InitialCraftNodeData(int craftNodeId)
		{
			NodeId = craftNodeId;
		}

		public InitialCraftNodeData(ICraftNode craftNode, LaunchLocation launchLocation, double launchTime)
			: this(craftNode.NodeId)
		{
			Name = craftNode.Name;
			LaunchPlanetName = launchLocation.PlanetName;
			LaunchLocationName = launchLocation.Name;
			LaunchLocationType = launchLocation.LocationType;
			LaunchTime = launchTime;
		}

		public InitialCraftNodeData(XElement xml)
		{
			NodeId = xml.GetIntAttributeOrNull("nodeId") ?? throw new Exception("Unable to read the craft node ID for the initial craft node data XML.");
			Name = xml.GetStringAttribute("name");
			LaunchPlanetName = xml.GetStringAttribute("launchPlanetName");
			LaunchLocationName = xml.GetStringAttribute("launchLocationName");
			LaunchLocationType = xml.GetEnumAttribute("launchLocationType", LaunchLocationType.SurfaceLockedGround);
			LaunchTime = xml.GetDoubleAttribute("launchTime");
			LaunchMass = xml.GetFloatAttribute("launchMass");
			LaunchPrice = xml.GetLongAttribute("launchPrice", 0L);
			InitialCrewCount = xml.GetIntAttribute("initialCrewCount");
		}

		public InitialCraftNodeData Clone()
		{
			return new InitialCraftNodeData(NodeId)
			{
				Name = Name,
				LaunchPlanetName = LaunchPlanetName,
				LaunchLocationName = LaunchLocationName,
				LaunchLocationType = LaunchLocationType,
				LaunchTime = LaunchTime,
				LaunchMass = LaunchMass,
				LaunchPrice = LaunchPrice,
				InitialCrewCount = InitialCrewCount
			};
		}

		public XElement GenerateXml()
		{
			return new XElement("InitialCraft", new XAttribute("nodeId", NodeId), new XAttribute("name", Name), new XAttribute("launchPlanetName", LaunchPlanetName), new XAttribute("launchLocationName", LaunchLocationName), new XAttribute("launchLocationType", LaunchLocationType), new XAttribute("launchTime", LaunchTime), new XAttribute("launchMass", LaunchMass), new XAttribute("launchPrice", LaunchPrice), new XAttribute("initialCrewCount", InitialCrewCount));
		}

		public void SetupCraftScriptData(ICraftScript craftScript)
		{
			LaunchMass = craftScript.Mass * 100f;
			LaunchPrice = craftScript.Data.Price;
			InitialCrewCount = craftScript.NumAstronauts;
		}
	}
}
