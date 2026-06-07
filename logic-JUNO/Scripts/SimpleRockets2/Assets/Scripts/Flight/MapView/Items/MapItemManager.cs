using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapItemManager : MonoBehaviour, IItemRegistry
	{
		private List<MapItem> _allCrafts = new List<MapItem>();

		private List<MapCraft> _mapDynamicCrafts = new List<MapCraft>();

		private List<MapItem> _mapItems = new List<MapItem>();

		private List<MapOrbitLine> _mapOrbitLines = new List<MapOrbitLine>();

		private List<MapPlanet> _mapPlanets = new List<MapPlanet>();

		private List<MapPlayerCraft> _mapPlayerCrafts = new List<MapPlayerCraft>();

		private List<MapStaticOrbitItem> _mapStaticOrbits = new List<MapStaticOrbitItem>();

		private List<MapSurfaceItem> _mapSurfaceItem = new List<MapSurfaceItem>();

		private List<MapOrbitNode> _orbitNodes = new List<MapOrbitNode>();

		private MapPlanet _rootPlanet;

		IReadOnlyList<MapItem> IItemRegistry.Crafts => _allCrafts;

		IReadOnlyList<MapCraft> IItemRegistry.DynamicCrafts => _mapDynamicCrafts;

		IReadOnlyList<MapItem> IItemRegistry.Items => _mapItems;

		IReadOnlyList<MapOrbitLine> IItemRegistry.OrbitLines => _mapOrbitLines;

		IReadOnlyList<MapOrbitNode> IItemRegistry.OrbitNodes => _orbitNodes;

		IReadOnlyList<MapPlanet> IItemRegistry.Planets => _mapPlanets;

		IReadOnlyList<MapPlayerCraft> IItemRegistry.PlayerCrafts => _mapPlayerCrafts;

		MapPlanet IItemRegistry.RootPlanet => _rootPlanet;

		public event ItemRegistryHandler MapItemAdded;

		public event ItemRegistryHandler MapItemRemoved;

		public static MapItemManager Create(GameObject parent)
		{
			return parent.AddComponent<MapItemManager>();
		}

		ITargetableItem IItemRegistry.FindTargetableItem(IOrbitNode orbitNode)
		{
			foreach (MapItem mapItem in _mapItems)
			{
				if (mapItem is ITargetableItem targetableItem && targetableItem.OrbitInfo?.OrbitNode == orbitNode)
				{
					return targetableItem;
				}
			}
			return null;
		}

		MapCraft IItemRegistry.GetCraft(ICraftNode craftNode)
		{
			MapCraft result = null;
			for (int i = 0; i < _mapItems.Count; i++)
			{
				MapCraft mapCraft = _mapItems[i] as MapCraft;
				if (mapCraft != null && mapCraft.OrbitInfo.OrbitNode == craftNode)
				{
					result = mapCraft;
				}
			}
			return result;
		}

		MapItem IItemRegistry.GetItem(IOrbitNode node)
		{
			MapItem result = null;
			for (int i = 0; i < _mapItems.Count; i++)
			{
				MapItem mapItem = _mapItems[i];
				if (mapItem.OrbitInfo.OrbitNode == node)
				{
					result = mapItem;
				}
			}
			return result;
		}

		MapOrbitLine IItemRegistry.GetOrbitLine(IOrbitNode orbitNode)
		{
			MapOrbitLine result = null;
			for (int i = 0; i < _mapOrbitLines.Count; i++)
			{
				MapOrbitLine mapOrbitLine = _mapOrbitLines[i];
				if (mapOrbitLine.OrbitInfo.OrbitNode == orbitNode)
				{
					result = mapOrbitLine;
				}
			}
			return result;
		}

		MapOrbitNode IItemRegistry.GetOrbitNode(IOrbitNode node)
		{
			MapOrbitNode result = null;
			for (int i = 0; i < _orbitNodes.Count; i++)
			{
				MapOrbitNode mapOrbitNode = _orbitNodes[i];
				if (mapOrbitNode.OrbitInfo.OrbitNode == node)
				{
					result = mapOrbitNode;
				}
			}
			return result;
		}

		MapPlanet IItemRegistry.GetPlanet(IPlanetNode planetNode)
		{
			MapPlanet result = null;
			if (planetNode != null)
			{
				for (int i = 0; i < _mapPlanets.Count; i++)
				{
					MapPlanet mapPlanet = _mapPlanets[i];
					if (MapUtils.SamePlanet(mapPlanet.OrbitInfo.OrbitNode as PlanetNode, planetNode))
					{
						result = mapPlanet;
					}
				}
			}
			return result;
		}

		void IItemRegistry.PerformMapItemAction(Action<MapItem> action)
		{
			List<MapItem> mapItems = _mapItems;
			for (int i = 0; i < mapItems.Count; i++)
			{
				MapItem mapItem = mapItems[i];
				if (mapItem == null)
				{
					Debug.LogError("A null item as found in the item registry...removing.");
					_mapItems.RemoveAt(i);
					i--;
				}
				else if (mapItem.isActiveAndEnabled)
				{
					action(mapItem);
				}
			}
		}

		void IItemRegistry.RegisterItem(MapItem mapItem)
		{
			if (mapItem is MapOrbitLine)
			{
				_mapOrbitLines.Add(mapItem as MapOrbitLine);
			}
			else if (mapItem is MapPlanet)
			{
				MapPlanet mapPlanet = mapItem as MapPlanet;
				_mapPlanets.Add(mapPlanet);
				if (mapPlanet.OrbitInfo.OrbitNode.Parent == null)
				{
					_rootPlanet = mapPlanet;
				}
			}
			else if (mapItem is MapPlayerCraft)
			{
				_mapPlayerCrafts.Add(mapItem as MapPlayerCraft);
			}
			else if (mapItem is MapStaticOrbitItem)
			{
				_mapStaticOrbits.Add(mapItem as MapStaticOrbitItem);
			}
			else if (mapItem is MapCraft)
			{
				_mapDynamicCrafts.Add(mapItem as MapCraft);
			}
			else if (mapItem is MapSurfaceItem)
			{
				_mapSurfaceItem.Add(mapItem as MapSurfaceItem);
			}
			if (mapItem is MapOrbitNode)
			{
				_orbitNodes.Add(mapItem as MapOrbitNode);
			}
			if (IsCraft(mapItem))
			{
				_allCrafts.Add(mapItem);
			}
			_mapItems.Add(mapItem);
			this.MapItemAdded?.Invoke(mapItem);
		}

		void IItemRegistry.UnregisterItem(MapItem mapItem)
		{
			if (mapItem is MapOrbitLine)
			{
				_mapOrbitLines.Remove(mapItem as MapOrbitLine);
			}
			else if (mapItem is MapPlanet)
			{
				_mapPlanets.Remove(mapItem as MapPlanet);
			}
			else if (mapItem is MapPlayerCraft)
			{
				_mapPlayerCrafts.Remove(mapItem as MapPlayerCraft);
			}
			else if (mapItem is MapStaticOrbitItem)
			{
				_mapStaticOrbits.Remove(mapItem as MapStaticOrbitItem);
			}
			else if (mapItem is MapCraft)
			{
				_mapDynamicCrafts.Remove(mapItem as MapCraft);
			}
			else if (mapItem is MapSurfaceItem)
			{
				_mapSurfaceItem.Remove(mapItem as MapSurfaceItem);
			}
			if (mapItem is MapOrbitNode)
			{
				_orbitNodes.Remove(mapItem as MapOrbitNode);
			}
			if (IsCraft(mapItem))
			{
				_allCrafts.Remove(mapItem);
			}
			_mapItems.Remove(mapItem);
			this.MapItemRemoved?.Invoke(mapItem);
		}

		protected virtual void OnDestroy()
		{
			MapItem.OnMapItemManagerDestroyed(this);
		}

		private static bool IsCraft(MapItem item)
		{
			if (!(item is MapPlayerCraft) && !(item is MapCraft))
			{
				if (item is MapStaticOrbitItem)
				{
					return item.OrbitInfo.OrbitNode is CraftNode;
				}
				return false;
			}
			return true;
		}
	}
}
