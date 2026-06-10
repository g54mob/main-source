using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.Model
{
	public class AnimalPenInstance
	{
		private readonly HashSet<Region> regions = new HashSet<Region>();

		private readonly List<PenMarkerComponentInstance> penMarkersCache = new List<PenMarkerComponentInstance>();

		public IEnumerable<Region> Regions => regions;

		public List<PenMarkerComponentInstance> PenMarkers
		{
			get
			{
				if (!penMarkersCache.Any())
				{
					CreatePenMarkersCache();
				}
				return penMarkersCache;
			}
		}

		public AnimalPenInstance(IEnumerable<Region> regions)
		{
			this.regions.UnionWith(regions);
		}

		public bool ContainsRegion(Region region)
		{
			return regions.Contains(region);
		}

		public int GetPenSize()
		{
			int num = 0;
			foreach (Region region in regions)
			{
				num += region.Nodes.Count;
			}
			return num;
		}

		public bool CanTakeAnimal(AnimalInstance animal)
		{
			List<PenMarkerComponentInstance> penMarkers = PenMarkers;
			if (penMarkers == null || !penMarkers.Any())
			{
				return false;
			}
			return penMarkers.Any((PenMarkerComponentInstance penMarker) => penMarker.IsAnimalAllowed(animal.Blueprint));
		}

		public void ReplaceRegions(IEnumerable<Region> newRegions)
		{
			regions.Clear();
			regions.UnionWith(newRegions);
			penMarkersCache.Clear();
			List<PenMarkerComponentInstance> penMarkers = PenMarkers;
			HashSet<string> hashSet = new HashSet<string>();
			foreach (PenMarkerComponentInstance item in penMarkers)
			{
				hashSet.UnionWith(item.Animals);
			}
			foreach (PenMarkerComponentInstance item2 in penMarkers)
			{
				item2.SetAnimalsAllowed(hashSet, allowed: true);
			}
			string name = string.Empty;
			for (int i = 0; i < penMarkers.Count; i++)
			{
				if (i == 0)
				{
					name = penMarkers[i].Name;
				}
				else
				{
					penMarkers[i].SetName(name);
				}
			}
		}

		public void OnMarkerAdded(PenMarkerComponentInstance building)
		{
			penMarkersCache.Clear();
		}

		public void OnMarkerDeleted(PenMarkerComponentInstance building)
		{
			penMarkersCache.Clear();
		}

		public void OnAnimalsChanged()
		{
			MonoSingleton<AnimalManager>.Instance.RefreshAllMarkForRoping();
		}

		public List<AnimalInstance> GetAnimalsInPen()
		{
			List<AnimalInstance> list = new List<AnimalInstance>();
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				Region region = key?.GetNode()?.Region;
				if (region != null && regions.Contains(region))
				{
					list.Add(key);
				}
			}
			return list;
		}

		public bool IsInPen(AnimalInstance animalInstance, out AnimalPenInstance penInstance)
		{
			penInstance = this;
			Region region = animalInstance?.GetNode()?.Region;
			if (region == null)
			{
				return false;
			}
			if (regions.Contains(region))
			{
				return true;
			}
			return false;
		}

		private void CreatePenMarkersCache()
		{
			penMarkersCache.Clear();
			foreach (Region region in regions)
			{
				foreach (MapNode node in region.Nodes)
				{
					foreach (WorldObject worldObject in node.WorldObjects)
					{
						PenMarkerComponentInstance componentInstance = worldObject.Map.PenMarkerComponentManager.GetComponentInstance(worldObject);
						if (componentInstance != null && !componentInstance.Underwater)
						{
							penMarkersCache.Add(componentInstance);
						}
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MapNode GetNodeWithMinPenalty(VillageMap map, PathfindingPenalty pathfindingPenalty, int iterations)
		{
			List<Region> list = regions.Where((Region region2) => !region2.IsBridge).ToList();
			int num = int.MaxValue;
			MapNode result = null;
			TemperatureManager temperatureManager = map.TemperatureManager;
			Random random = new Random();
			for (int num2 = 0; num2 < iterations; num2++)
			{
				Region region = list[random.Next(0, list.Count())];
				MapNode mapNode = region.Nodes[random.Next(0, region.Nodes.Count)];
				if ((mapNode.Tag & MapNodeTags.IdleTargetForbidden) == 0)
				{
					float temperature = temperatureManager.GetTemperature(mapNode.Position);
					int num3 = PathfindingPenalty.GetPathfindingPenalty(pathfindingPenalty, mapNode, map) + (temperatureManager.IsTemperatureOutOfRange(temperature) ? 65535 : 0);
					if (mapNode.CreaturesCount > 0)
					{
						num3 = Math.Min(num3 + 500, int.MaxValue);
					}
					if (num3 < num)
					{
						num = num3;
						result = mapNode;
					}
				}
			}
			return result;
		}

		public string GetPenName()
		{
			if (PenMarkers != null && PenMarkers.Count > 0)
			{
				return PenMarkers.First().Name;
			}
			return string.Empty;
		}

		public bool AllMarkersValid()
		{
			CreatePenMarkersCache();
			if (PenMarkers.Count == 0)
			{
				return false;
			}
			foreach (PenMarkerComponentInstance penMarker in PenMarkers)
			{
				Region region = penMarker?.GetNode()?.Region;
				if (region == null || !regions.Contains(region))
				{
					return false;
				}
			}
			return true;
		}
	}
}
