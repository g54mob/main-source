using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.Resources
{
	public class ResourcePileController : MonoSingleton<ResourcePileController>
	{
		private readonly HashSet<Resource> countChangedResourcesCache = new HashSet<Resource>();

		private bool enableResourceCountCache;

		public event Action<ResourcePileInstance> PreSpawnPileEvent;

		public event Action<ResourcePileInstance> SpawnPileEvent;

		public event Action<ResourcePileInstance> DestroyPileEvent;

		public event Action AllSavedPilesSpawnedEvent;

		public event Action<Resource, ResourcePileCount> ResourceCountChangeEvent;

		public event Action<ResourcePileInstance, HumanoidInstance, bool> EquipOrderUpdateEvent;

		public event Action<ResourcePileInstance> ResourcePileSelectedEvent;

		public event Action AllPilesCountEvent;

		public event Action<ResourcePileInstance> PileRottenEvent;

		public event Action<BaseBuildingInstance> InstallBuildingCanceledEvent;

		public void OnPileRotten(ResourcePileInstance pileInstance)
		{
			this.PileRottenEvent?.Invoke(pileInstance);
		}

		public void EquipOrderUpdate(ResourcePileInstance pile, HumanoidInstance humanoid, bool active)
		{
			this.EquipOrderUpdateEvent?.Invoke(pile, humanoid, active);
		}

		internal void EnableResourceCountCache()
		{
			enableResourceCountCache = true;
		}

		public void OnPileSelected(ResourcePileInstance pileInstance)
		{
			this.ResourcePileSelectedEvent?.Invoke(pileInstance);
		}

		public void InstallBuildingCancelled(BaseBuildingInstance buildingInstance)
		{
			this.InstallBuildingCanceledEvent?.Invoke(buildingInstance);
		}

		internal void OnPilePreSpawnEvent(ResourcePileInstance pile)
		{
			this.PreSpawnPileEvent?.Invoke(pile);
		}

		internal void OnPileSpawned(ResourcePileInstance pile)
		{
			this.SpawnPileEvent?.Invoke(pile);
		}

		internal void OnPileDestroyed(ResourcePileInstance pile)
		{
			this.DestroyPileEvent?.Invoke(pile);
		}

		internal void OnSavePilesLoaded()
		{
			this.AllSavedPilesSpawnedEvent?.Invoke();
			this.AllSavedPilesSpawnedEvent = null;
		}

		internal void OnResourceCountChanged(Resource resource, ResourcePileCount counter)
		{
			if (enableResourceCountCache)
			{
				countChangedResourcesCache.Add(resource);
			}
			else
			{
				this.ResourceCountChangeEvent?.Invoke(resource, counter);
			}
		}

		internal void AllPilesRecounted()
		{
			this.AllPilesCountEvent?.Invoke();
		}

		private void LateUpdate()
		{
			if (countChangedResourcesCache.Count == 0)
			{
				return;
			}
			ResourcePileTracker resourcePileTracker = MonoSingleton<ResourcePileTracker>.Instance;
			foreach (Resource item in countChangedResourcesCache)
			{
				this.ResourceCountChangeEvent?.Invoke(item, resourcePileTracker.GetCount(item));
			}
			countChangedResourcesCache.Clear();
			enableResourceCountCache = false;
		}
	}
}
