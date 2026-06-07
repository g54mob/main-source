using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class LocationSettings
	{
		private List<MapStartingLocations> _available;

		private List<MapStartingLocations> _default;

		private List<MapStartingLocations> _discoverable;

		public bool HasUnsavedChanges { get; private set; }

		public void AddCustomStartLocation(string mapId, StartLocationData location)
		{
			AddAvailableLocation(mapId, location, StartLocationType.Custom);
			HasUnsavedChanges = true;
		}

		public IReadOnlyList<MapStartingLocations> GetAvailableLocations()
		{
			return _available;
		}

		public MapStartingLocations GetAvailableLocations(string mapId)
		{
			return FindMapById(_available, mapId);
		}

		public StartLocationData GetDiscoverableLocation(string mapId, string locationId)
		{
			return FindLocationById(_discoverable, mapId, locationId);
		}

		public MapStartingLocations GetDiscoverableLocations(string mapId)
		{
			return FindMapById(_discoverable, mapId);
		}

		public StartLocationData GetSelectedLocation(string mapId)
		{
			MapStartingLocations availableLocations = GetAvailableLocations(mapId);
			return GetSelectedLocation(availableLocations);
		}

		public StartLocationData GetSelectedLocation(MapStartingLocations map)
		{
			if (!string.IsNullOrEmpty(map?.SelectedLocationId))
			{
				return FindLocationById(map, map.SelectedLocationId);
			}
			return null;
		}

		public bool HasDiscoveredLocation(string mapId, string locationId)
		{
			return FindLocationById(_available, mapId, locationId) != null;
		}

		public void LoadSettingsFromXml(XElement xml)
		{
			if (_default == null)
			{
				_default = LoadStockLocations(StartLocationType.Default);
			}
			if (_discoverable == null)
			{
				_discoverable = LoadStockLocations(StartLocationType.Discoverable);
			}
			_available = LoadLocationsFromXml(xml);
			AddAvailableLocations(_default);
			AddAvailableLocations(_discoverable);
			HasUnsavedChanges = false;
		}

		public void RegisterDefaultLocation(string mapId, StartLocationData location)
		{
			MapStartingLocations orCreateMapStartLocations = GetOrCreateMapStartLocations(_default, mapId);
			AddLocation(orCreateMapStartLocations, location);
			AddAvailableLocation(mapId, location, StartLocationType.Default);
		}

		public void RegisterDiscoverableLocation(string mapId, StartLocationData location)
		{
			MapStartingLocations orCreateMapStartLocations = GetOrCreateMapStartLocations(_discoverable, mapId);
			AddLocation(orCreateMapStartLocations, location);
			AddAvailableLocation(mapId, location, StartLocationType.Discoverable);
		}

		public void RemoveCustomStartLocation(string mapId, string locationId)
		{
			MapStartingLocations mapStartingLocations = FindMapById(_available, mapId);
			if (mapStartingLocations == null)
			{
				Debug.LogError("Unable to remove custom start location '" + locationId + "' from map '" + mapId + "' because the map could not be found.");
			}
			else if (mapStartingLocations.StartingLocations.RemoveAll((StartLocationData x) => x.Id == locationId && x.LocationType == StartLocationType.Custom) > 0)
			{
				HasUnsavedChanges = true;
			}
		}

		public void SaveIfNecessary()
		{
			Game.Instance.Settings.Cloud.SaveIfNecessary();
		}

		public XElement SaveXml(XElement xml)
		{
			foreach (MapStartingLocations item in _available)
			{
				xml.Add(item.GenerateXml());
			}
			HasUnsavedChanges = false;
			return xml;
		}

		public void SetSelectedLocation(string mapId, string locationId)
		{
			MapStartingLocations availableLocations = GetAvailableLocations(mapId);
			if (availableLocations != null && availableLocations.SelectedLocationId != locationId)
			{
				availableLocations.SelectedLocationId = locationId;
				HasUnsavedChanges = true;
			}
		}

		public void SetSelectedLocation(MapStartingLocations map, string locationId)
		{
			if (map != null && map.SelectedLocationId != locationId)
			{
				map.SelectedLocationId = locationId;
				HasUnsavedChanges = true;
			}
		}

		public void UnlockAllDiscoverableLocations()
		{
			foreach (MapStartingLocations item in _discoverable)
			{
				foreach (StartLocationData startingLocation in item.StartingLocations)
				{
					UnlockDiscoverableLocation(item.MapId, startingLocation.Id);
				}
			}
		}

		public void UnlockDiscoverableLocation(string mapId, string locationId)
		{
			MapStartingLocations map = FindMapById(_discoverable, mapId);
			StartLocationData startLocationData = FindLocationById(map, locationId);
			if (startLocationData == null)
			{
				Debug.LogError("Unable to unlock discoverable location '" + locationId + "' on map '" + mapId + "' because the location could not be found.");
				return;
			}
			map = GetOrCreateMapStartLocations(_available, mapId);
			if (map.UnregisteredDiscoverableLocations.Contains(locationId))
			{
				map.UnregisteredDiscoverableLocations.Remove(locationId);
				Debug.LogError("Location " + locationId + " on map " + mapId + " was in the list of unregistered discoverable locations but the location itself was actually registered.");
			}
			if (FindLocationById(map, locationId) != null)
			{
				Debug.LogError("Discoverable location '" + locationId + "' on map '" + mapId + "' was already unlocked.");
			}
			else
			{
				map.StartingLocations.Add(startLocationData);
				HasUnsavedChanges = true;
			}
		}

		private static List<MapStartingLocations> LoadLocationsFromXml(XElement xml)
		{
			List<MapStartingLocations> list = new List<MapStartingLocations>();
			foreach (XElement item in xml?.Elements("Map") ?? Array.Empty<XElement>())
			{
				list.Add(new MapStartingLocations(item));
			}
			return list;
		}

		private static List<MapStartingLocations> LoadStockLocations(StartLocationType type)
		{
			List<MapStartingLocations> list = new List<MapStartingLocations>();
			foreach (XElement item in XDocument.Parse(Game.Instance.ResourceLoader.LoadText($"Data/StartingLocations_{type}")).Elements("StartingLocations").Elements("Map"))
			{
				list.Add(new MapStartingLocations(item, type));
			}
			return list;
		}

		private void AddAvailableLocation(string mapId, StartLocationData location, StartLocationType type)
		{
			MapStartingLocations orCreateMapStartLocations = GetOrCreateMapStartLocations(_available, mapId);
			switch (type)
			{
			case StartLocationType.Default:
			case StartLocationType.Custom:
				AddLocation(orCreateMapStartLocations, location);
				break;
			case StartLocationType.Discoverable:
				if (orCreateMapStartLocations.UnregisteredDiscoverableLocations.Contains(location.Id))
				{
					orCreateMapStartLocations.UnregisteredDiscoverableLocations.Remove(location.Id);
					AddLocation(orCreateMapStartLocations, location);
				}
				break;
			default:
				throw new NotSupportedException($"Unable to add a location of type '{type}' to the location settings.");
			}
		}

		private void AddAvailableLocations(List<MapStartingLocations> locations)
		{
			foreach (MapStartingLocations location in locations)
			{
				foreach (StartLocationData startingLocation in location.StartingLocations)
				{
					AddAvailableLocation(location.MapId, startingLocation, startingLocation.LocationType);
				}
			}
		}

		private void AddLocation(MapStartingLocations mapStartLocations, StartLocationData location)
		{
			foreach (StartLocationData startingLocation in mapStartLocations.StartingLocations)
			{
				if (startingLocation.Id == location.Id)
				{
					Debug.LogError("Unable to add start location '" + location.Id + "' to map '" + mapStartLocations.MapId + "' because a location with that id already exists.");
					return;
				}
			}
			mapStartLocations.StartingLocations.Add(location);
		}

		private StartLocationData FindLocationById(List<MapStartingLocations> locations, string mapId, string locationId)
		{
			MapStartingLocations map = FindMapById(locations, mapId);
			return FindLocationById(map, locationId);
		}

		private StartLocationData FindLocationById(MapStartingLocations map, string locationId)
		{
			if (map != null)
			{
				for (int i = 0; i < map.StartingLocations.Count; i++)
				{
					StartLocationData startLocationData = map.StartingLocations[i];
					if (startLocationData.Id == locationId)
					{
						return startLocationData;
					}
				}
			}
			return null;
		}

		private MapStartingLocations FindMapById(List<MapStartingLocations> locations, string mapId)
		{
			if (locations != null)
			{
				for (int i = 0; i < locations.Count; i++)
				{
					MapStartingLocations mapStartingLocations = locations[i];
					if (mapStartingLocations.MapId == mapId)
					{
						return mapStartingLocations;
					}
				}
			}
			return null;
		}

		private MapStartingLocations GetOrCreateMapStartLocations(List<MapStartingLocations> mapStartLocations, string mapId)
		{
			foreach (MapStartingLocations mapStartLocation in mapStartLocations)
			{
				if (mapStartLocation.MapId == mapId)
				{
					return mapStartLocation;
				}
			}
			MapStartingLocations mapStartingLocations = new MapStartingLocations(mapId, null);
			mapStartLocations.Add(mapStartingLocations);
			return mapStartingLocations;
		}
	}
}
