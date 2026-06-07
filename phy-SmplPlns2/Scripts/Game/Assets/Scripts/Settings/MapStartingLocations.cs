using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.Demo;
using Assets.Scripts.Flight.StartLocations;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class MapStartingLocations
	{
		public string MapId { get; private set; }

		public string SelectedLocationId { get; set; }

		public List<StartLocationData> StartingLocations { get; private set; }

		public List<string> UnregisteredDiscoverableLocations { get; }

		public MapStartingLocations(string mapId, IEnumerable<StartLocationData> startingLocations)
		{
			MapId = mapId;
			SelectedLocationId = startingLocations?.FirstOrDefault()?.Id;
			StartingLocations = new List<StartLocationData>(startingLocations ?? new StartLocationData[0]);
			UnregisteredDiscoverableLocations = new List<string>();
		}

		public MapStartingLocations(XElement mapStartingLocations)
		{
			MapId = mapStartingLocations.GetStringAttribute("mapId");
			SelectedLocationId = mapStartingLocations.GetStringAttribute("selected");
			StartingLocations = new List<StartLocationData>();
			UnregisteredDiscoverableLocations = new List<string>();
			foreach (XElement item in mapStartingLocations.Elements("DiscoveredLocations").Elements("Location"))
			{
				string text = (string)item.Attribute("id");
				if (!string.IsNullOrEmpty(text))
				{
					UnregisteredDiscoverableLocations.Add(text);
				}
			}
			foreach (XElement item2 in mapStartingLocations.Elements("CustomLocations").Elements("Location"))
			{
				AddStartingLocation(StartLocationType.Custom, item2);
			}
		}

		public MapStartingLocations(XElement mapStartingLocations, StartLocationType locationType)
		{
			MapId = mapStartingLocations.GetStringAttribute("mapId");
			SelectedLocationId = mapStartingLocations.GetStringAttribute("selected");
			StartingLocations = new List<StartLocationData>();
			UnregisteredDiscoverableLocations = new List<string>();
			foreach (XElement item in mapStartingLocations.Elements("Location"))
			{
				AddStartingLocation(locationType, item);
			}
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Map", new XAttribute("mapId", MapId));
			if (!string.IsNullOrEmpty(SelectedLocationId))
			{
				xElement.Add(new XAttribute("selected", SelectedLocationId));
			}
			XElement xElement2 = new XElement("DiscoveredLocations");
			XElement xElement3 = new XElement("CustomLocations");
			foreach (StartLocationData startingLocation in StartingLocations)
			{
				if (startingLocation.LocationType == StartLocationType.Discoverable)
				{
					xElement2.Add(new XElement("Location", new XAttribute("id", startingLocation.Id)));
				}
				else if (startingLocation.LocationType == StartLocationType.Custom)
				{
					xElement3.Add(startingLocation.GenerateXml());
				}
			}
			foreach (string unregisteredDiscoverableLocation in UnregisteredDiscoverableLocations)
			{
				xElement2.Add(new XElement("Location", new XAttribute("id", unregisteredDiscoverableLocation)));
			}
			if (xElement2.HasElements)
			{
				xElement.Add(xElement2);
			}
			if (xElement3.HasElements)
			{
				xElement.Add(xElement3);
			}
			if (!xElement.HasElements && xElement.Attributes().Count() <= 1)
			{
				return null;
			}
			return xElement;
		}

		private void AddStartingLocation(StartLocationType locationType, XElement location)
		{
			try
			{
				StartLocationData startLocationData = new StartLocationData(location, locationType);
				if (!Device.IsDemoBuild || (!startLocationData.IsDynamicLocation && IsWithinDemoBounds(startLocationData.Position)) || (startLocationData.IsDynamicLocation && startLocationData.AreaName == "USS Beast"))
				{
					StartingLocations.Add(startLocationData);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Could not create starting location from XML: " + location.ToString() + ".");
			}
			static bool IsWithinDemoBounds(Vector3 position)
			{
				DemoData[] demoData = Game.Instance.DemoData;
				for (int i = 0; i < demoData.Length; i++)
				{
					if (demoData[i].BoundsWarning.Contains(position))
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
