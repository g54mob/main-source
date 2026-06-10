using System.Collections.Concurrent;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ResourcePileTracker : MonoSingleton<ResourcePileTracker>
	{
		private class ResourceCountData
		{
			public int StoredNutrition;

			public ConcurrentDictionary<Resource, ResourcePileCount> ResourceCount { get; } = new ConcurrentDictionary<Resource, ResourcePileCount>();

			public ConcurrentDictionary<string, ResourcePileCount> ResourceGroupCount { get; } = new ConcurrentDictionary<string, ResourcePileCount>();

			public ConcurrentDictionary<ItemMaterialCategory, ResourcePileCount> ResourceMaterialCategoryCount { get; } = new ConcurrentDictionary<ItemMaterialCategory, ResourcePileCount>();

			public ConcurrentHashSet<ResourcePileInstance> AllAllowed { get; } = new ConcurrentHashSet<ResourcePileInstance>();

			public ConcurrentDictionary<string, HashSet<ResourcePileInstance>> PilesByResourceId { get; } = new ConcurrentDictionary<string, HashSet<ResourcePileInstance>>();

			public ConcurrentHashSet<HumanCarcassPileInstance> CarcassPiles { get; } = new ConcurrentHashSet<HumanCarcassPileInstance>();

			public ConcurrentDictionary<int, HumanCarcassPileInstance> CarcassPilesByUniqueId { get; } = new ConcurrentDictionary<int, HumanCarcassPileInstance>();

			public ConcurrentDictionary<ResourceCategory, ResourcePileCount> ResourceCategoryCount { get; } = new ConcurrentDictionary<ResourceCategory, ResourcePileCount>();

			public void AddToPilesByResourceId(string resourceId, ResourcePileInstance resourcePile)
			{
				if (PilesByResourceId.TryGetValue(resourceId, out var value))
				{
					value.Add(resourcePile);
					return;
				}
				PilesByResourceId.TryAdd(resourceId, new HashSet<ResourcePileInstance>());
				PilesByResourceId[resourceId].Add(resourcePile);
			}

			public void RemoveFromPilesByResourceId(string resourceId, ResourcePileInstance resourcePile)
			{
				if (PilesByResourceId.TryGetValue(resourceId, out var value))
				{
					value.Remove(resourcePile);
				}
			}

			public void Reset()
			{
				foreach (ResourcePileCount value in ResourceCount.Values)
				{
					value.Reset();
				}
				foreach (ResourcePileCount value2 in ResourceCategoryCount.Values)
				{
					value2.Reset();
				}
				foreach (ResourcePileCount value3 in ResourceGroupCount.Values)
				{
					value3.Reset();
				}
				foreach (ResourcePileCount value4 in ResourceMaterialCategoryCount.Values)
				{
					value4.Reset();
				}
				AllAllowed.Clear();
				StoredNutrition = 0;
			}

			public void Dispose()
			{
				Reset();
				foreach (HashSet<ResourcePileInstance> value in PilesByResourceId.Values)
				{
					value.Clear();
				}
				PilesByResourceId.Clear();
				CarcassPiles.Clear();
				CarcassPilesByUniqueId.Clear();
			}
		}

		private ResourceCountData data;

		private ResourceCountData dataCopy;

		private readonly HashSet<ResourcePileInstance> subscribedPiles = new HashSet<ResourcePileInstance>();

		private const long PauseUpdateAfterMillis = 4L;

		private const float AutoRecountIntervalSeconds = 10f;

		private readonly ResourcePileCount zeroCount = new ResourcePileCount();

		private readonly Dictionary<ResourceCategory, ResourcePileCount> countByCategories = new Dictionary<ResourceCategory, ResourcePileCount>();

		private bool isThreadRecountRunning;

		private bool isThreadRecountScheduled;

		private float lastRecountTime;

		public ConcurrentHashSet<ResourcePileInstance> AllAllowed => data.AllAllowed;

		public ConcurrentHashSet<HumanCarcassPileInstance> CarcassPiles => data.CarcassPiles;

		public IReadOnlyDictionary<Resource, ResourcePileCount> AllResourceCount => data.ResourceCount;

		public float LastRecountTime => lastRecountTime;

		private ResourcePileTracker()
		{
			data = new ResourceCountData();
			dataCopy = new ResourceCountData();
		}

		public ISet<ResourcePileInstance> GetPilesByResourceId(string resourceId)
		{
			return data.PilesByResourceId.GetValueOrDefault(resourceId);
		}

		public IReadOnlyDictionary<string, HashSet<ResourcePileInstance>> GetPilesByResourceId()
		{
			return data.PilesByResourceId;
		}

		public ResourcePileCount GetCount(Resource blueprint)
		{
			if (blueprint == null || !data.ResourceCount.TryGetValue(blueprint, out var value))
			{
				return zeroCount;
			}
			return value;
		}

		public IEnumerable<KeyValuePair<Resource, ResourcePileCount>> UniqueResourcesCount()
		{
			foreach (Resource uniqueResource in Repository<ResourceRepository, Resource>.Instance.UniqueResources)
			{
				if (data.ResourceCount.TryGetValue(uniqueResource, out var value) && value.TotalCount > 0)
				{
					yield return new KeyValuePair<Resource, ResourcePileCount>(uniqueResource, value);
				}
			}
		}

		public ResourcePileCount GetCount(ItemMaterialCategory category)
		{
			return data.ResourceMaterialCategoryCount.GetValueOrDefault(category, zeroCount);
		}

		public ResourcePileCount GetCount(ResourceCategory category)
		{
			if (category == ResourceCategory.None)
			{
				return zeroCount;
			}
			if ((category & (category - 1)) == 0)
			{
				return data.ResourceCategoryCount.GetValueOrDefault(category, zeroCount);
			}
			ResourcePileCount resourcePileCount;
			if (!countByCategories.TryGetValue(category, out var value))
			{
				countByCategories.Add(category, new ResourcePileCount());
				resourcePileCount = countByCategories[category];
			}
			else
			{
				resourcePileCount = value;
				resourcePileCount.Reset();
			}
			ResourceCategory[] allResourceCategories = EnumValues.AllResourceCategories;
			foreach (ResourceCategory resourceCategory in allResourceCategories)
			{
				if (category.HasFlag(resourceCategory) && data.ResourceCategoryCount.TryGetValue(resourceCategory, out var value2))
				{
					resourcePileCount.Add(value2);
				}
			}
			return resourcePileCount;
		}

		public ResourcePileCount GetCount(string groupId)
		{
			if (string.IsNullOrEmpty(groupId) || !data.ResourceGroupCount.TryGetValue(groupId, out var value))
			{
				return zeroCount;
			}
			return value;
		}

		public ResourcePileCount GetCountByIdOrCategory(string id)
		{
			if (int.TryParse(id, out var result))
			{
				return GetCount((ResourceCategory)result);
			}
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			if (byID == null)
			{
				return zeroCount;
			}
			return GetCount(byID);
		}

		public CreatureBase GetCarcassOwnerByOwnerCreationId(int creationId)
		{
			if (!data.CarcassPilesByUniqueId.ContainsKey(creationId))
			{
				return null;
			}
			return data.CarcassPilesByUniqueId[creationId].BodyOwner;
		}

		public int GetTotalStockpilePilesNutrition()
		{
			return Mathf.Clamp(data.StoredNutrition, 0, int.MaxValue);
		}

		public void ScheduleRecountPiles()
		{
			Log.Trace("Recount piles scheduled", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileTracker.cs");
			isThreadRecountScheduled = true;
		}

		private bool RecountThread()
		{
			IReadOnlyList<ResourcePileInstance> spawnedPileInstances = MonoSingleton<ResourcePileManager>.Instance.SpawnedPileInstances;
			for (int i = 0; i < spawnedPileInstances.Count; i++)
			{
				ResourcePileInstance pile = spawnedPileInstances[i];
				TrackPileOnSpawn(pile, dataCopy);
			}
			return true;
		}

		private void OnRecountThreadDone(bool result)
		{
			if (LoadingController.IsSceneTransition)
			{
				return;
			}
			isThreadRecountRunning = false;
			lastRecountTime = Time.time;
			ResourceCountData resourceCountData = dataCopy;
			ResourceCountData resourceCountData2 = data;
			data = resourceCountData;
			dataCopy = resourceCountData2;
			ResourcePileController resourcePileController = MonoSingleton<ResourcePileController>.Instance;
			foreach (var (resource2, counter) in data.ResourceCount)
			{
				resourcePileController.OnResourceCountChanged(resource2, counter);
			}
			resourcePileController.AllPilesRecounted();
		}

		private void OnTick(float deltaTime)
		{
			if (!isThreadRecountRunning && (isThreadRecountScheduled || Time.time - lastRecountTime > 10f))
			{
				isThreadRecountScheduled = false;
				isThreadRecountRunning = true;
				MonoSingleton<ResourcePileController>.Instance.EnableResourceCountCache();
				dataCopy.Reset();
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(RecountThread, OnRecountThreadDone);
			}
		}

		public bool SearchForFilterHits(ResourceSearchFilter filter, bool ignoreForbidState = false)
		{
			if (filter.Blueprint != null && IsCountHit(GetCount(filter.Blueprint)))
			{
				return true;
			}
			if (filter.ItemMaterialCategory > ItemMaterialCategory.None && IsCountHit(GetCount(filter.ItemMaterialCategory)))
			{
				return true;
			}
			if (!string.IsNullOrEmpty(filter.BlueprintOrCategoryId))
			{
				int result;
				ResourcePileCount count = ((!int.TryParse(filter.BlueprintOrCategoryId, out result)) ? GetCount(filter.BlueprintOrCategoryId) : GetCount((ResourceCategory)result));
				if (IsCountHit(count))
				{
					return true;
				}
			}
			if (filter.Category != ResourceCategory.None && IsCountHit(GetCount(filter.Category)))
			{
				return true;
			}
			if (filter.Resources == null)
			{
				return false;
			}
			int num = 0;
			foreach (Resource resource in filter.Resources)
			{
				ResourcePileCount count2 = GetCount(resource);
				if (IsCountHit(count2, num))
				{
					return true;
				}
				num += ((!ignoreForbidState && filter.AllowedOnly) ? count2.AllowedCount : count2.TotalCount);
			}
			return false;
			bool IsCountHit(ResourcePileCount resourcePileCount, int additionalCount = 0)
			{
				if (!ignoreForbidState && filter.AllowedOnly)
				{
					return resourcePileCount.AllowedCount + additionalCount >= filter.Count;
				}
				return resourcePileCount.TotalCount + additionalCount > filter.Count;
			}
		}

		public void OnSpawnPile(ResourcePileInstance pile)
		{
			TrackPileOnSpawn(pile, data);
		}

		private void TrackPileOnSpawn(ResourcePileInstance pile, ResourceCountData outData)
		{
			Resource blueprint = pile.Blueprint;
			if (!outData.ResourceCount.ContainsKey(blueprint))
			{
				outData.ResourceCount.TryAdd(blueprint, new ResourcePileCount());
			}
			ItemMaterialCategory itemMaterialCategory = blueprint.ItemMaterialCategory;
			string groupIdentifier = blueprint.GroupIdentifier;
			if (groupIdentifier != null && !outData.ResourceGroupCount.ContainsKey(groupIdentifier))
			{
				outData.ResourceGroupCount.TryAdd(groupIdentifier, new ResourcePileCount());
			}
			if (!outData.ResourceMaterialCategoryCount.ContainsKey(itemMaterialCategory))
			{
				outData.ResourceMaterialCategoryCount.TryAdd(itemMaterialCategory, new ResourcePileCount());
			}
			outData.ResourceCount[blueprint].Add(pile);
			if (groupIdentifier != null)
			{
				outData.ResourceGroupCount[groupIdentifier].Add(pile);
			}
			outData.ResourceMaterialCategoryCount[itemMaterialCategory].Add(pile);
			UpdateCategoryCount(pile, pile.GetStoredResource()?.Amount ?? 0, isAdd: true, outData);
			if (!pile.IsForbidden)
			{
				outData.AllAllowed.Add(pile);
			}
			if (pile is HumanCarcassPileInstance humanCarcassPileInstance && !outData.CarcassPilesByUniqueId.ContainsKey(humanCarcassPileInstance.UniqueId))
			{
				outData.CarcassPiles.Add(humanCarcassPileInstance);
				outData.CarcassPilesByUniqueId.TryAdd(humanCarcassPileInstance.UniqueId, humanCarcassPileInstance);
			}
			if (subscribedPiles.Add(pile))
			{
				pile.OnResourceAddedEvent -= OnPileResourceAdded;
				pile.OnResourceTakenEvent -= OnPileResourceTaken;
				pile.OnResourceAddedEvent += OnPileResourceAdded;
				pile.OnResourceTakenEvent += OnPileResourceTaken;
				pile.ForbidStateWillChangeEvent -= OnPileForbidStateWillChange;
				pile.ForbidChangeEvent -= OnPileForbidStateChanged;
				pile.ForbidStateWillChangeEvent += OnPileForbidStateWillChange;
				pile.ForbidChangeEvent += OnPileForbidStateChanged;
				outData.AddToPilesByResourceId(blueprint.GetID(), pile);
			}
			if (!GlobalSaveController.CurrentVillageData.ExistingResources.Contains(blueprint.GetID()))
			{
				GlobalSaveController.CurrentVillageData.ExistingResources.Add(blueprint.GetID());
			}
			if (blueprint.Category.HasFlag(ResourceCategory.CtgResearch))
			{
				MonoSingleton<TaskController>.Instance.OptimizedCall(this, "pile_ui_recount", delegate
				{
					MonoSingleton<ResourcePileController>.Instance.OnResourceCountChanged(blueprint, outData.ResourceCount[blueprint]);
				});
			}
		}

		public void OnPileDestroyed(ResourcePileInstance pile)
		{
			Resource blueprint = pile.Blueprint;
			UpdateCategoryCount(pile, pile.GetStoredResource()?.Amount ?? 0, isAdd: false, data);
			if (data.ResourceGroupCount.ContainsKey(blueprint.GroupIdentifier))
			{
				data.ResourceGroupCount[blueprint.GroupIdentifier].Subtract(pile);
			}
			if (data.ResourceMaterialCategoryCount.ContainsKey(blueprint.ItemMaterialCategory))
			{
				data.ResourceMaterialCategoryCount[blueprint.ItemMaterialCategory].Subtract(pile);
			}
			if (data.ResourceCount.ContainsKey(blueprint))
			{
				data.ResourceCount[blueprint].Subtract(pile);
				MonoSingleton<ResourcePileController>.Instance.OnResourceCountChanged(pile.Blueprint, data.ResourceCount[pile.Blueprint]);
			}
			if (pile is HumanCarcassPileInstance humanCarcassPileInstance && data.CarcassPilesByUniqueId.ContainsKey(humanCarcassPileInstance.UniqueId))
			{
				data.CarcassPiles.Remove(humanCarcassPileInstance);
				data.CarcassPilesByUniqueId.Remove(humanCarcassPileInstance.UniqueId);
			}
			data.AllAllowed.Remove(pile);
			subscribedPiles.Remove(pile);
			data.RemoveFromPilesByResourceId(blueprint.GetID(), pile);
		}

		public void OnPileResourceTaken(ResourcePileInstance pile, Resource blueprint, int count)
		{
			OnPileResourceTaken(pile, blueprint, count, skipEvents: false);
		}

		public void OnPileResourceTaken(ResourcePileInstance pile, Resource blueprint, int count, bool skipEvents)
		{
			ItemMaterialCategory itemMaterialCategory = blueprint.ItemMaterialCategory;
			string groupIdentifier = blueprint.GroupIdentifier;
			if (!data.ResourceCount.ContainsKey(blueprint))
			{
				data.ResourceCount.TryAdd(blueprint, new ResourcePileCount());
			}
			ResourcePileCount.Subtract(data.ResourceCount[blueprint], pile, count);
			if (!data.ResourceGroupCount.ContainsKey(groupIdentifier))
			{
				data.ResourceGroupCount.TryAdd(groupIdentifier, new ResourcePileCount());
			}
			ResourcePileCount.Subtract(data.ResourceGroupCount[groupIdentifier], pile, count);
			if (!data.ResourceMaterialCategoryCount.ContainsKey(itemMaterialCategory))
			{
				data.ResourceMaterialCategoryCount.TryAdd(itemMaterialCategory, new ResourcePileCount());
			}
			ResourcePileCount.Subtract(data.ResourceMaterialCategoryCount[itemMaterialCategory], pile, count);
			UpdateCategoryCount(pile, count, isAdd: false, data);
			if (!skipEvents && MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.OnResourceCountChanged(blueprint, data.ResourceCount[pile.Blueprint]);
			}
		}

		public void OnPileResourceAdded(ResourcePileInstance pile, Resource blueprint, int count)
		{
			OnPileResourceAdded(pile, blueprint, count, skipEvents: false);
		}

		public void OnPileResourceAdded(ResourcePileInstance pile, Resource blueprint, int count, bool skipEvents)
		{
			ItemMaterialCategory itemMaterialCategory = blueprint.ItemMaterialCategory;
			string groupIdentifier = blueprint.GroupIdentifier;
			if (!data.ResourceCount.ContainsKey(blueprint))
			{
				data.ResourceCount.TryAdd(blueprint, new ResourcePileCount());
			}
			ResourcePileCount.Add(data.ResourceCount[blueprint], pile, count);
			if (!data.ResourceGroupCount.ContainsKey(groupIdentifier))
			{
				data.ResourceGroupCount.TryAdd(groupIdentifier, new ResourcePileCount());
			}
			ResourcePileCount.Add(data.ResourceGroupCount[groupIdentifier], pile, count);
			if (!data.ResourceMaterialCategoryCount.ContainsKey(itemMaterialCategory))
			{
				data.ResourceMaterialCategoryCount.TryAdd(itemMaterialCategory, new ResourcePileCount());
			}
			ResourcePileCount.Add(data.ResourceMaterialCategoryCount[itemMaterialCategory], pile, count);
			UpdateCategoryCount(pile, count, isAdd: true, data);
			if (!skipEvents)
			{
				MonoSingleton<ResourcePileController>.Instance.OnResourceCountChanged(blueprint, data.ResourceCount[pile.Blueprint]);
			}
		}

		public void OnNewPileSpawnedOnStockpile(Resource blueprint, ResourcePileInstance pile)
		{
			MonoSingleton<ResourcePileController>.Instance.OnResourceCountChanged(blueprint, data.ResourceCount[pile.Blueprint]);
		}

		public void OnPileForbidStateWillChange(IForbidable forbidable)
		{
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)forbidable;
			int num = resourcePileInstance.GetStoredResource()?.Amount ?? 0;
			if (num != 0)
			{
				OnPileResourceTaken(resourcePileInstance, resourcePileInstance.Blueprint, num, skipEvents: true);
			}
		}

		public void OnPileForbidStateChanged(IForbidable forbidable)
		{
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)forbidable;
			int num = resourcePileInstance.GetStoredResource()?.Amount ?? 0;
			if (num != 0)
			{
				OnPileResourceAdded(resourcePileInstance, resourcePileInstance.Blueprint, num);
				if (!resourcePileInstance.IsForbidden)
				{
					data.AllAllowed.Add(resourcePileInstance);
				}
				else
				{
					data.AllAllowed.Remove(resourcePileInstance);
				}
			}
		}

		private static void UpdateCategoryCount(ResourcePileInstance pile, int count, bool isAdd, ResourceCountData outData)
		{
			if (count == 0)
			{
				return;
			}
			if (pile.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
			{
				outData.StoredNutrition = (isAdd ? (outData.StoredNutrition + pile.GetNutrition()) : (outData.StoredNutrition - pile.GetNutrition()));
			}
			ResourceCategory[] allResourceCategories = EnumValues.AllResourceCategories;
			foreach (ResourceCategory resourceCategory in allResourceCategories)
			{
				if ((pile.Blueprint.Category & resourceCategory) == resourceCategory)
				{
					if (!outData.ResourceCategoryCount.ContainsKey(resourceCategory))
					{
						outData.ResourceCategoryCount.TryAdd(resourceCategory, new ResourcePileCount());
					}
					if (isAdd)
					{
						ResourcePileCount.Add(outData.ResourceCategoryCount[resourceCategory], pile, count);
					}
					else
					{
						ResourcePileCount.Subtract(outData.ResourceCategoryCount[resourceCategory], pile, count);
					}
				}
			}
		}

		private void OnWorldLoaded(bool wasLoadedFromSave)
		{
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnSpawnPile;
			MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent += OnPileDestroyed;
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (MonoSingleton<ResourcePileTracker>.IsInstantiated())
				{
					ScheduleRecountPiles();
				}
			});
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnWorldLoaded;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnWorldLoaded;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnSpawnPile;
				MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent -= OnPileDestroyed;
			}
			subscribedPiles?.Clear();
			data?.Dispose();
			dataCopy?.Dispose();
			data = null;
			dataCopy = null;
		}
	}
}
