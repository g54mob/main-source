using System;
using System.Xml.Linq;
using ModApi.Craft;
using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.State.MapView
{
	public class MapItemData
	{
		private static class XNodeNames
		{
			public const string Id = "id";

			public const string ShowIconsAttribute = "showIcons";

			public const string ShowOrbitAttribute = "showOrbit";

			public const string ShowSphereOfInfluenceAttribute = "showSphereOfInfluence";

			public const string Type = "type";
		}

		private ICraftNode _craftNode;

		private MapItemDataDefaults _defaults;

		private bool _destroyed;

		private bool? _showIconsRaw;

		private bool? _showOrbitLineRaw;

		private bool? _showSphereOfInfluenceRaw;

		public bool ShowIcons
		{
			get
			{
				bool result = IsPlayerCraft || _defaults.ShowIcons;
				if (!ShowIconsRaw.HasValue)
				{
					return result;
				}
				return ShowIconsRaw.Value;
			}
		}

		public bool? ShowIconsRaw
		{
			get
			{
				return _showIconsRaw;
			}
			set
			{
				bool showIcons = ShowIcons;
				_showIconsRaw = value;
				bool showIcons2 = ShowIcons;
				if (showIcons2 != showIcons)
				{
					this.ShowIconsChanged?.Invoke(showIcons2);
				}
				this.ShowIconsRawChanged?.Invoke(ShowIconsRaw);
				this.AnyPropertyChanged?.Invoke();
			}
		}

		public bool ShowOrbitLine
		{
			get
			{
				bool result = IsPlayerCraft || _defaults.ShowOrbitLines;
				if (!ShowOrbitLineRaw.HasValue)
				{
					return result;
				}
				return ShowOrbitLineRaw.Value;
			}
		}

		public bool? ShowOrbitLineRaw
		{
			get
			{
				return _showOrbitLineRaw;
			}
			set
			{
				if (SupportsOrbitLines)
				{
					bool showOrbitLine = ShowOrbitLine;
					_showOrbitLineRaw = value;
					bool showOrbitLine2 = ShowOrbitLine;
					if (showOrbitLine2 != showOrbitLine)
					{
						this.ShowOrbitLineChanged?.Invoke(showOrbitLine2);
					}
					this.ShowOrbitLineRawChanged?.Invoke(ShowOrbitLineRaw);
					this.AnyPropertyChanged?.Invoke();
				}
				else
				{
					_showOrbitLineRaw = false;
				}
			}
		}

		public bool ShowSphereOfInfluence
		{
			get
			{
				bool flag = (_defaults as MapItemDataPlanetDefaults)?.ShowSpheresOfInfluence ?? false;
				return ShowSphereOfInfluenceRaw ?? flag;
			}
		}

		public bool? ShowSphereOfInfluenceRaw
		{
			get
			{
				return _showSphereOfInfluenceRaw;
			}
			set
			{
				bool showSphereOfInfluence = ShowSphereOfInfluence;
				_showSphereOfInfluenceRaw = value;
				bool showSphereOfInfluence2 = ShowSphereOfInfluence;
				if (showSphereOfInfluence2 != showSphereOfInfluence)
				{
					this.ShowSphereOfInfluenceChanged?.Invoke(showSphereOfInfluence2);
				}
				this.ShowSphereOfInfluenceRawChanged?.Invoke(ShowSphereOfInfluenceRaw);
				this.AnyPropertyChanged?.Invoke();
			}
		}

		public bool SupportsOrbitLines { get; set; } = true;

		public MapItemType Type { get; private set; }

		private string Id { get; set; }

		private bool IsPlayerCraft
		{
			get
			{
				if (_craftNode != null)
				{
					return _craftNode.IsPlayer;
				}
				return false;
			}
		}

		public event AnyPropertyChangedHandler AnyPropertyChanged;

		public event PropertyChangedHandler<bool> ShowIconsChanged;

		public event PropertyChangedHandler<bool?> ShowIconsRawChanged;

		public event PropertyChangedHandler<bool> ShowOrbitLineChanged;

		public event PropertyChangedHandler<bool?> ShowOrbitLineRawChanged;

		public event PropertyChangedHandler<bool> ShowSphereOfInfluenceChanged;

		public event PropertyChangedHandler<bool?> ShowSphereOfInfluenceRawChanged;

		public MapItemData(MapItemDataDefaults defaults, IOrbitNode orbitNode)
		{
			Create(defaults, GetId(orbitNode), GetType(orbitNode), null, null, null);
			SetNode(orbitNode);
		}

		public MapItemData(MapItemDataDefaults defaults, XElement nodeState)
		{
			try
			{
				Create(defaults, nodeState.Attribute("id")?.Value, GetType(nodeState), Utilities.GetBoolNullableAttribute(nodeState, "showOrbit", null), Utilities.GetBoolNullableAttribute(nodeState, "showIcons", null), Utilities.GetBoolNullableAttribute(nodeState, "showSphereOfInfluence", null));
			}
			catch (Exception innerException)
			{
				new ArgumentException("MapItemData item is invalid and will be discarded", innerException);
			}
		}

		public MapItemData(MapItemDataDefaults defaults, string id, MapItemType type)
		{
			Create(defaults, id, type, null, null, null);
		}

		public static MapItemType GetType(XElement nodeElement)
		{
			return (MapItemType)Enum.Parse(typeof(MapItemType), nodeElement.Attribute("type")?.Value);
		}

		public static MapItemType GetType(IOrbitNode orbitNode)
		{
			if (orbitNode is IPlanetNode)
			{
				return MapItemType.Planet;
			}
			if (orbitNode is ICraftNode)
			{
				return MapItemType.Craft;
			}
			if (orbitNode is IStructureNode)
			{
				return MapItemType.Structure;
			}
			Debug.LogError("Unsupported orbit type for NodeData: " + orbitNode.GetType().Name);
			return MapItemType.Craft;
		}

		public static bool IsMatch(MapItemData itemData, IOrbitNode node)
		{
			return IsMatch(itemData, GetId(node), GetType(node));
		}

		public static bool IsMatch(MapItemData itemData, string nodeId, MapItemType type)
		{
			if (itemData.Id == nodeId)
			{
				return itemData.Type == type;
			}
			return false;
		}

		public void Destroy()
		{
			if (_destroyed)
			{
				return;
			}
			_destroyed = true;
			if (_defaults != null)
			{
				_defaults.ShowIconsChanged -= OnDefaultShowIconsChanged;
				_defaults.ShowOrbitLineChanged -= OnDefaultShowOrbitLineChanged;
				if (_defaults is MapItemDataPlanetDefaults mapItemDataPlanetDefaults)
				{
					mapItemDataPlanetDefaults.ShowSpheresOfInfluenceChanged -= OnDefaultShowSpheresOfInfluenceChanged;
				}
			}
		}

		public XElement GenerateXml()
		{
			XElement result = null;
			if (!HasOnlyDefaultData())
			{
				result = new XElement("MapItem", new XAttribute("id", Id), new XAttribute("type", Type.ToString()), ShowOrbitLineRaw.HasValue ? new XAttribute("showOrbit", ShowOrbitLineRaw) : null, ShowIconsRaw.HasValue ? new XAttribute("showIcons", ShowIconsRaw) : null, ShowSphereOfInfluenceRaw.HasValue ? new XAttribute("showSphereOfInfluence", ShowSphereOfInfluenceRaw) : null);
			}
			return result;
		}

		public void SetNode(IOrbitNode node)
		{
			GetType(node);
			_ = Type;
			_craftNode = node as ICraftNode;
		}

		private static string GetId(IOrbitNode orbitNode)
		{
			MapItemType type = GetType(orbitNode);
			switch (type)
			{
			case MapItemType.Craft:
				return (orbitNode as ICraftNode).NodeId.ToString();
			case MapItemType.Planet:
				return orbitNode.Name;
			case MapItemType.Structure:
				return ((IStructureNode)orbitNode).Id.ToString();
			default:
				Debug.LogError($"Unsupported type: {type}");
				return orbitNode.Name;
			}
		}

		private void Create(MapItemDataDefaults defaults, string id, MapItemType type, bool? showOrbitLine, bool? showIcons, bool? showSphereOfInfluence)
		{
			_defaults = defaults;
			Id = id;
			Type = type;
			ShowOrbitLineRaw = showOrbitLine;
			ShowIconsRaw = showIcons;
			_showSphereOfInfluenceRaw = showSphereOfInfluence;
			_defaults.ShowIconsChanged += OnDefaultShowIconsChanged;
			_defaults.ShowOrbitLineChanged += OnDefaultShowOrbitLineChanged;
			if (defaults is MapItemDataPlanetDefaults mapItemDataPlanetDefaults)
			{
				mapItemDataPlanetDefaults.ShowSpheresOfInfluenceChanged += OnDefaultShowSpheresOfInfluenceChanged;
			}
			Validate();
		}

		private bool HasOnlyDefaultData()
		{
			if (!ShowOrbitLineRaw.HasValue && !ShowIconsRaw.HasValue)
			{
				return !ShowSphereOfInfluenceRaw.HasValue;
			}
			return false;
		}

		private void OnDefaultShowIconsChanged(bool newVal)
		{
			if (!ShowIconsRaw.HasValue)
			{
				this.ShowIconsChanged?.Invoke(ShowIcons);
			}
		}

		private void OnDefaultShowOrbitLineChanged(bool newVal)
		{
			if (!ShowOrbitLineRaw.HasValue)
			{
				this.ShowOrbitLineChanged?.Invoke(ShowOrbitLine);
			}
		}

		private void OnDefaultShowSpheresOfInfluenceChanged(bool newVal)
		{
			if (!ShowSphereOfInfluenceRaw.HasValue)
			{
				this.ShowSphereOfInfluenceChanged?.Invoke(ShowSphereOfInfluence);
			}
		}

		private void SetType(IOrbitNode orbitNode)
		{
			Type = GetType(orbitNode);
		}

		private void Validate()
		{
			if (Id == null)
			{
				throw new ArgumentException("MapItemData item is invalid and will be discarded");
			}
		}
	}
}
