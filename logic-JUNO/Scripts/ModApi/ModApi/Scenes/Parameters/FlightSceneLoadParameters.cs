using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.State;

namespace ModApi.Scenes.Parameters
{
	public class FlightSceneLoadParameters
	{
		public bool AutoEnableCheats { get; set; }

		public Func<IFlightStateData> FlightStateDataLoader { get; set; }

		public bool? HeatDamage { get; set; }

		public long LaunchCost { get; set; }

		public string LaunchCraftId { get; set; }

		public string LaunchCraftNodeName { get; set; }

		public LaunchLocation LaunchLocation { get; set; }

		public string LoadingScreen { get; set; }

		public int? ResumeCraftNodeId { get; set; }

		public static FlightSceneLoadParameters NewCraft(string craftId, string craftNodeName, LaunchLocation launchLocation, long launchCost)
		{
			return new FlightSceneLoadParameters
			{
				LaunchCost = launchCost,
				LaunchCraftId = craftId,
				LaunchCraftNodeName = craftNodeName,
				LaunchLocation = launchLocation,
				LoadingScreen = launchLocation?.PlanetName
			};
		}

		public static FlightSceneLoadParameters RestorePreflightData(XElement xml, IGameState gameState)
		{
			if (xml == null)
			{
				return null;
			}
			XElement xElement = xml.Element("LaunchLocation");
			LaunchLocation launchLocation;
			if (xElement != null)
			{
				launchLocation = new LaunchLocation(xElement);
			}
			else
			{
				string launchLocationName = (string)xml.Attribute("LaunchLocationName");
				launchLocation = gameState.LaunchLocations.FirstOrDefault((LaunchLocation x) => x.Name == launchLocationName);
			}
			return new FlightSceneLoadParameters
			{
				LaunchCraftId = (string)xml.Attribute("LaunchCraftId"),
				LaunchCraftNodeName = (string)xml.Attribute("LaunchCraftNodeName"),
				LaunchLocation = launchLocation,
				ResumeCraftNodeId = (int?)xml.Attribute("ResumeCraftNodeId"),
				LoadingScreen = (string)xml.Attribute("LoadingScreen"),
				LaunchCost = ((long?)xml.Attribute("LaunchCost")).GetValueOrDefault()
			};
		}

		public static FlightSceneLoadParameters ResumeCraft(int? craftNodeId = null, string loadingScreen = null)
		{
			return new FlightSceneLoadParameters
			{
				ResumeCraftNodeId = craftNodeId,
				LoadingScreen = loadingScreen
			};
		}

		public XElement SavePreflightData(string elementName)
		{
			return new XElement(elementName, (LaunchCraftId == null) ? null : new XAttribute("LaunchCraftId", LaunchCraftId), (LaunchCraftNodeName == null) ? null : new XAttribute("LaunchCraftNodeName", LaunchCraftNodeName), (LaunchLocation == null) ? null : LaunchLocation.GenerateXml(savePlanetName: true, basicPropertiesOnly: true), (!ResumeCraftNodeId.HasValue) ? null : new XAttribute("ResumeCraftNodeId", ResumeCraftNodeId.Value), (LoadingScreen == null) ? null : new XAttribute("LoadingScreen", LoadingScreen), new XAttribute("LaunchCost", LaunchCost));
		}
	}
}
