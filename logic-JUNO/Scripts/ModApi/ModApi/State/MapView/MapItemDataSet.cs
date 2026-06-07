using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Flight.Sim;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace ModApi.State.MapView
{
	public class MapItemDataSet
	{
		public static class XNodeNames
		{
			public const string CraftDefaultsElement = "CraftDefaults";

			public const string MapItemElement = "MapItem";

			public const string MapItemsElement = "MapItems";

			public const string PlanetDefaultsElement = "PlanetDefaults";

			public const string StructureDefaultsElement = "StructureDefaults";
		}

		private Func<IEnumerable<MapItemData>> _getDataItems;

		private List<MapItemData> _itemsFromXml = new List<MapItemData>();

		public MapItemDataDefaults CraftDefaults { get; private set; }

		public MapItemDataPlanetDefaults PlanetDefaults { get; private set; }

		public MapItemDataDefaults StructureDefaults { get; private set; }

		public MapItemDataSet(XElement element)
		{
			IGameStateValidator gameStateValidator = Game.Instance.GameState?.Validator;
			CraftDefaults = new MapItemDataDefaults(element?.Element("CraftDefaults"), defaultShowOrbitLines: false, defaultShowIcons: true);
			PlanetDefaults = new MapItemDataPlanetDefaults(element?.Element("PlanetDefaults"), gameStateValidator?.IsItemAvailable("Map.Lines") ?? true, defaultShowIcons: true, defaultShowSpheresOfInfluence: false);
			StructureDefaults = new MapItemDataDefaults(element?.Element("StructureDefaults"), defaultShowOrbitLines: true, defaultShowIcons: true);
			StructureDefaults.ShowOrbitLines = false;
			if (element == null)
			{
				return;
			}
			foreach (XElement item in element.Elements("MapItem"))
			{
				_itemsFromXml.Add(new MapItemData(GetDefaults(item), item));
			}
		}

		public XElement GenerateXml()
		{
			IEnumerable<MapItemData> source = _getDataItems();
			XElement xElement = new XElement("MapItems", source.Select((MapItemData x) => x.GenerateXml()));
			xElement.AddFirst(PlanetDefaults.GenerateXml("PlanetDefaults"));
			xElement.AddFirst(CraftDefaults.GenerateXml("CraftDefaults"));
			xElement.AddFirst(StructureDefaults.GenerateXml("StructureDefaults"));
			return xElement;
		}

		public MapItemData GetItem(IOrbitNode node, bool createIfNecessary)
		{
			MapItemData mapItemData = _itemsFromXml.Where((MapItemData x) => MapItemData.IsMatch(x, node)).FirstOrDefault();
			if (mapItemData == null && createIfNecessary)
			{
				mapItemData = new MapItemData(GetDefaults(node), node);
			}
			mapItemData.SetNode(node);
			return mapItemData;
		}

		public void ResetAllNodesToDefaults()
		{
			foreach (MapItemData item in _getDataItems())
			{
				item.ShowIconsRaw = null;
				item.ShowOrbitLineRaw = null;
				item.ShowSphereOfInfluenceRaw = null;
			}
		}

		public void ResetDefaults()
		{
			CraftDefaults.ResetToDefault();
			PlanetDefaults.ResetToDefault();
			StructureDefaults.ResetToDefault();
			StructureDefaults.ShowOrbitLines = false;
		}

		public void SetDataItemsAccessor(Func<IEnumerable<MapItemData>> getDataItems)
		{
			_getDataItems = getDataItems;
		}

		private MapItemDataDefaults GetDefaults(IOrbitNode node)
		{
			return GetDefaults(MapItemData.GetType(node));
		}

		private MapItemDataDefaults GetDefaults(XElement nodeState)
		{
			return GetDefaults(MapItemData.GetType(nodeState));
		}

		private MapItemDataDefaults GetDefaults(MapItemType type)
		{
			MapItemDataDefaults result;
			switch (type)
			{
			case MapItemType.Craft:
				result = CraftDefaults;
				break;
			case MapItemType.Planet:
				result = PlanetDefaults;
				break;
			case MapItemType.Structure:
				result = StructureDefaults;
				break;
			default:
				result = CraftDefaults;
				Debug.LogError($"Unsupported type: {type}");
				break;
			}
			return result;
		}
	}
}
