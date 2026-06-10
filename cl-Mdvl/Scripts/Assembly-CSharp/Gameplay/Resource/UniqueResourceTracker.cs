using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Objectives;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.WorldMap;
using Objectives;

namespace Gameplay.Resource
{
	public class UniqueResourceTracker
	{
		[Flags]
		public enum Occurence
		{
			None = 0,
			ResourcePileInstance = 1,
			CreatureStorage = 2,
			LootStash = 4,
			WorldMapMarker = 8,
			CaravanStorage = 0x10,
			Plant = 0x20,
			WorkerStorage = 0x40,
			TraderStorage = 0x80,
			InPlayersPossession = 0x51
		}

		private readonly Dictionary<string, int> uniqueResourceCount;

		private Dictionary<string, int> uniqueResourceCountPrev;

		private readonly Dictionary<string, HashSet<PlantMapResourceInstance>> plantUniqueResources;

		private readonly Dictionary<string, Occurence> uniqueResourceOccurence;

		private bool recountScheduled;

		public IReadOnlyDictionary<string, int> UniqueResourceCount => uniqueResourceCount;

		public UniqueResourceTracker()
		{
			plantUniqueResources = new Dictionary<string, HashSet<PlantMapResourceInstance>>();
			uniqueResourceCount = new Dictionary<string, int>();
			uniqueResourceOccurence = new Dictionary<string, Occurence>();
			MonoSingleton<FloraController>.Instance.ChangeLifePhaseEvent += OnPlantChangeLifePhase;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent += OnPlantDestroy;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent += OnResourceCountChangeEvent;
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnSpawnPile;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
			MonoSingleton<ResourceCommonController>.Instance.ResourceAddedToStorageEvent += OnResourceAddedToStorage;
			MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorageEvent += OnResourceRemovedFromStorage;
			MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerCreatedEvent += OnMarkerCreatedEvent;
			MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent += OnMarkerDestroyedEvent;
		}

		public void Dispose()
		{
			if (MonoSingleton<FloraController>.IsInstantiated())
			{
				MonoSingleton<FloraController>.Instance.ChangeLifePhaseEvent -= OnPlantChangeLifePhase;
				MonoSingleton<FloraController>.Instance.DestroyResourceEvent -= OnPlantDestroy;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnResourceCountChangeEvent;
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnSpawnPile;
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceAddedToStorageEvent -= OnResourceAddedToStorage;
				MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorageEvent -= OnResourceRemovedFromStorage;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (MonoSingleton<WorldMap>.IsInstantiated())
			{
				MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerCreatedEvent -= OnMarkerCreatedEvent;
				MonoSingleton<WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent -= OnMarkerDestroyedEvent;
			}
			foreach (KeyValuePair<string, HashSet<PlantMapResourceInstance>> plantUniqueResource in plantUniqueResources)
			{
				plantUniqueResource.Value.Clear();
			}
			plantUniqueResources.Clear();
		}

		public void RecountAllImmediate()
		{
			uniqueResourceCountPrev?.Clear();
			uniqueResourceCountPrev = new Dictionary<string, int>(uniqueResourceCount);
			uniqueResourceCount.Clear();
			uniqueResourceOccurence.Clear();
			RecountResourcePiles();
			RecountFromCreatureStorage();
			RecountFromWorldMapMarkers();
			RecountFromCaravanStorage();
			RecountFromPlants();
			uniqueResourceCount.RemoveWhere((KeyValuePair<string, int> pair) => pair.Value == 0);
			if (!uniqueResourceCount.Keys.AllNonAlloc(uniqueResourceCountPrev.ContainsKey) | !uniqueResourceCountPrev.Keys.AllNonAlloc(uniqueResourceCount.ContainsKey))
			{
				MonoSingleton<ObjectiveManager>.Instance.ScheduleCheckObjective(ObjectiveTaskRequirementType.HaveResource);
			}
		}

		public int GetUniqueResourceCount(string resourceId)
		{
			return uniqueResourceCount.GetValueOrDefault(resourceId);
		}

		public Occurence GetUniqueResourceOccurence(string resourceId)
		{
			return uniqueResourceOccurence.GetValueOrDefault(resourceId, Occurence.None);
		}

		private void OnResourceAddedToStorage(ResourceInstance resourceInstance, Storage storage)
		{
			if (resourceInstance != null && resourceInstance.Blueprint.UniqueResource)
			{
				ScheduleRecount();
			}
		}

		private void OnResourceRemovedFromStorage(ResourceInstance resourceInstance, Storage storage)
		{
			if (resourceInstance != null && resourceInstance.Blueprint.UniqueResource)
			{
				ScheduleRecount();
			}
		}

		private void ScheduleRecount()
		{
			recountScheduled = true;
		}

		private void OnTick(float dt)
		{
			if (recountScheduled)
			{
				recountScheduled = false;
				if (LoadingController.IsLoadingComplete)
				{
					RecountAllImmediate();
				}
			}
		}

		private void OnMarkerCreatedEvent(WorldMapMarkerPlace marker)
		{
			ScheduleRecount();
		}

		private void OnMarkerDestroyedEvent(WorldMapMarkerPlace marker)
		{
			ScheduleRecount();
		}

		private void OnResourceCountChangeEvent(NSMedieval.Model.Resource resource, ResourcePileCount count)
		{
			if (resource.UniqueResource)
			{
				ScheduleRecount();
			}
		}

		private void OnSpawnPile(ResourcePileInstance resourcePileInstance)
		{
			if (resourcePileInstance != null && resourcePileInstance.Blueprint.UniqueResource)
			{
				ScheduleRecount();
			}
		}

		private void OnPlantDestroy(PlantMapResourceInstance resource)
		{
			PlantMapResource blueprint = resource.Blueprint;
			if (blueprint.UniqueResource && plantUniqueResources.TryGetValue(blueprint.GetID(), out var value))
			{
				value.Remove(resource);
				ScheduleRecount();
			}
		}

		private void OnPlantChangeLifePhase(PlantMapResourceInstance resource)
		{
			if (!resource.Blueprint.UniqueResource)
			{
				return;
			}
			HashSet<PlantMapResourceInstance> value2;
			if (resource.Blueprint.UniqueResourceActiveLifePhases == null || resource.Blueprint.UniqueResourceActiveLifePhases.Contains(resource.CurrentPhase))
			{
				string blueprintId = resource.BlueprintId;
				if (!plantUniqueResources.TryGetValue(blueprintId, out var value))
				{
					value = new HashSet<PlantMapResourceInstance>();
					plantUniqueResources.Add(blueprintId, value);
				}
				value.Add(resource);
				ScheduleRecount();
			}
			else if (plantUniqueResources.TryGetValue(resource.BlueprintId, out value2))
			{
				value2.Remove(resource);
				ScheduleRecount();
			}
		}

		private void OnLoadingComplete()
		{
			RecountAllImmediate();
		}

		private void AddToUniqueResourceCount(NSMedieval.Model.Resource resource, int count)
		{
			string iD = resource.GetID();
			if (!uniqueResourceCount.TryAdd(iD, count))
			{
				uniqueResourceCount[iD] += count;
			}
		}

		private void AddToUniqueResourceCount(string resourceId, int count)
		{
			if (!uniqueResourceCount.TryAdd(resourceId, count))
			{
				uniqueResourceCount[resourceId] += count;
			}
		}

		private void AddToOccurence(string resourceId, Occurence occurence)
		{
			if (!uniqueResourceOccurence.TryAdd(resourceId, occurence))
			{
				uniqueResourceOccurence[resourceId] |= occurence;
			}
		}

		private void RecountFromPlants()
		{
			foreach (KeyValuePair<string, HashSet<PlantMapResourceInstance>> plantUniqueResource in plantUniqueResources)
			{
				string key = plantUniqueResource.Key;
				int count = plantUniqueResource.Value.Count;
				if (count > 0)
				{
					AddToUniqueResourceCount(key, count);
					AddToOccurence(key, Occurence.Plant);
				}
			}
		}

		private void RecountFromCaravanStorage()
		{
			foreach (CaravanInstance caravan in MonoSingleton<WorldMap>.Instance.Data.Caravans)
			{
				foreach (ResourceInstance resource in caravan.Storage.Resources)
				{
					if (!resource.HasDisposed && resource.Blueprint.UniqueResource)
					{
						AddToUniqueResourceCount(resource.Blueprint, resource.Amount);
						AddToOccurence(resource.BlueprintId, Occurence.CaravanStorage);
					}
				}
			}
		}

		private void RecountFromWorldMapMarkers()
		{
			foreach (WorldMapMarkerPlace marker in MonoSingleton<WorldMap>.Instance.Data.Markers)
			{
				if (marker.LootableStorage != null)
				{
					foreach (ResourceInstance resource in marker.LootableStorage.Resources)
					{
						if (resource.Blueprint.UniqueResource)
						{
							AddToUniqueResourceCount(resource.Blueprint, resource.Amount);
							AddToOccurence(resource.BlueprintId, Occurence.LootStash);
						}
					}
				}
				if (marker.CachedMapInfo?.HasUniqueResources != null)
				{
					string[] hasUniqueResources = marker.CachedMapInfo.HasUniqueResources;
					foreach (string resourceId in hasUniqueResources)
					{
						AddToUniqueResourceCount(resourceId, 1);
						AddToOccurence(resourceId, Occurence.WorldMapMarker);
					}
				}
			}
		}

		private void RecountResourcePiles()
		{
			foreach (KeyValuePair<NSMedieval.Model.Resource, ResourcePileCount> item in MonoSingleton<ResourcePileTracker>.Instance.UniqueResourcesCount())
			{
				AddToUniqueResourceCount(item.Key, item.Value.TotalCount);
				AddToOccurence(item.Key.GetID(), Occurence.ResourcePileInstance);
			}
		}

		private void RecountFromCreatureStorage()
		{
			foreach (CreatureBase creature in MonoSingleton<CreatureManager>.Instance.Creatures)
			{
				if (creature.HasDied || creature.HasDisposed)
				{
					continue;
				}
				HumanoidInstance humanoidInstance = creature as HumanoidInstance;
				foreach (ResourceInstance resource in creature.Storage.Resources)
				{
					if (resource != null && !resource.HasDisposed && resource.Blueprint.UniqueResource)
					{
						AddToUniqueResourceCount(resource.Blueprint, resource.Amount);
						AddToOccurence(resource.BlueprintId, Occurence.CreatureStorage);
						if (humanoidInstance != null && humanoidInstance.IsWorker())
						{
							AddToOccurence(resource.BlueprintId, Occurence.WorkerStorage);
						}
						if (humanoidInstance != null && humanoidInstance.IsTrader())
						{
							AddToOccurence(resource.BlueprintId, Occurence.TraderStorage);
						}
					}
				}
			}
		}
	}
}
