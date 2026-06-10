using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	[Serializable]
	[FVSerializableKey("UniversalStorage", "")]
	public class UniversalStorage : IGoapTargetable, IGameDisposable, IDisposable, IFVSerializable
	{
		[SerializeField]
		private string universalStorageID;

		[SerializeField]
		private ResourcesFilter resourcesFilter;

		[SerializeField]
		private StorageSlot[] storageSlots;

		[SerializeField]
		private Vector3 position;

		[SerializeField]
		private bool isForbidden;

		[SerializeField]
		private ZonePriority priority;

		[NonSerialized]
		private UniversalStorageBlueprint blueprint;

		[NonSerialized]
		private HashSet<Resource> defaultAllowed;

		private IStorage owner;

		[NonSerialized]
		private int uniqueId;

		public IStorage GetOwner => owner;

		public UniversalStorageBlueprint UniversalStorageBlueprint => blueprint;

		public string UniversalStorageID => universalStorageID;

		public ResourcesFilter ResourcesFilter => resourcesFilter;

		public Vector3 Position => position;

		public StorageSlot[] StorageSlots => storageSlots;

		public bool IsForbidden => isForbidden;

		public ZonePriority Priority => priority;

		public bool HasDisposed { get; protected set; }

		public int UniqueId
		{
			get
			{
				if (uniqueId == 0)
				{
					uniqueId = GetHashCode();
				}
				return uniqueId;
			}
		}

		public bool IsOnFire => owner.IsOnFire;

		public event Action<int, StorageSlot> PileStoredEvent;

		public event Action<int, StorageSlot> PileStoredNoViewUpdateEvent;

		public event Action<int, StorageSlot> PileTakenEvent;

		public event Action<int> PileDurabilityDepletedEvent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<bool> StorageForbidEvent;

		public UniversalStorage(IStorage owner, UniversalStorageBlueprint blueprint, Vector3 position)
		{
			this.owner = owner;
			universalStorageID = blueprint.GetID();
			this.blueprint = blueprint;
			resourcesFilter = new ResourcesFilter();
			InitializeAllowedResources(blueprint);
			this.position = position;
			priority = blueprint.ZonePriority;
			storageSlots = new StorageSlot[blueprint.MaxPileCount];
			for (int i = 0; i < storageSlots.Length; i++)
			{
				storageSlots[i] = new StorageSlot();
			}
			resourcesFilter.OnParamsChangedEvent += OnStorageParamsChanged;
		}

		public Vector3 GetPosition()
		{
			return Position;
		}

		public virtual Vec3Int GetGridPosition()
		{
			return GridUtils.GetGridPosition(position);
		}

		public void SetPriority(ZonePriority priority)
		{
			this.priority = priority;
		}

		public bool ContainsPile(ResourcePileInstance pile)
		{
			StorageSlot[] array = storageSlots;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i]?.Pile == pile)
				{
					return true;
				}
			}
			return false;
		}

		public void FreezePiles(bool frozen)
		{
			StorageSlot[] array = storageSlots;
			for (int i = 0; i < array.Length; i++)
			{
				ResourcePileInstance pile = array[i].Pile;
				if (pile != null)
				{
					pile.Frozen = frozen;
				}
			}
		}

		public void SetupAfterLoading(IStorage owner)
		{
			this.owner = owner;
			blueprint = Repository<UniversalStorageRepository, UniversalStorageBlueprint>.Instance.GetByID(universalStorageID);
			resourcesFilter.OnParamsChangedEvent += OnStorageParamsChanged;
			SetupDefaultAllowedByBlueprint(blueprint);
			for (int i = 0; i < storageSlots.Length; i++)
			{
				StorageSlot storageSlot = storageSlots[i];
				if (storageSlot == null)
				{
					storageSlots[i] = new StorageSlot();
					continue;
				}
				storageSlot.SetupAfterLoading();
				if (storageSlot.Pile == null)
				{
					continue;
				}
				Storage storage = storageSlot.Pile.GetStorage();
				if (storage != null)
				{
					foreach (ResourceInstance resource in storage.Resources)
					{
						resource.InitAfterLoadPile();
					}
				}
				storageSlot.Pile.SetPlacedOnStorage(this.owner, this);
				storageSlot.Pile.SetIsStoredOnStockpile(resourcesFilter.IsValid(storageSlot.Pile.GetStoredResource()), this);
				storageSlot.PileTakenEvent += OnPileTaken;
				storageSlot.PileHealthDepletedEvent += OnPileDurabilityDepleted;
				if (!storageSlot.HasVisuals)
				{
					storageSlot.Pile.DoNotCreateView = true;
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(storageSlot.Pile);
					this.PileStoredNoViewUpdateEvent?.Invoke(Array.IndexOf(storageSlots, storageSlot), storageSlot);
				}
			}
			if (defaultAllowed == null)
			{
				defaultAllowed = new HashSet<Resource>();
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (allItem != null && blueprint.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup))
				{
					defaultAllowed.Add(allItem);
				}
			}
		}

		public void SetForbidden(bool isForbidden)
		{
			this.isForbidden = isForbidden;
			this.StorageForbidEvent?.Invoke(this.isForbidden);
			StorageSlot[] array = storageSlots;
			for (int i = 0; i < array.Length; i++)
			{
				ResourcePileInstance resourcePileInstance = array[i]?.Pile;
				if (resourcePileInstance != null)
				{
					resourcePileInstance.IsForbidden = isForbidden;
				}
			}
			ResourcesFilter.ParametersChanged();
		}

		public int GetStoredCount(Resource blueprint)
		{
			return CountStoredResources((ResourceInstance res) => res.Blueprint == blueprint);
		}

		public int GetStoredGroupCount(string groupId)
		{
			return CountStoredResources((ResourceInstance res) => res.Blueprint.GroupIdentifier.Equals(groupId));
		}

		public int GetStoredCategoryCount(ResourceCategory category)
		{
			return CountStoredResources((ResourceInstance res) => res.Blueprint.Category.HasFlag(category));
		}

		public int CountStoredResources(Func<ResourceInstance, bool> condition)
		{
			int num = 0;
			if (storageSlots == null)
			{
				return 0;
			}
			StorageSlot[] array = storageSlots;
			for (int i = 0; i < array.Length; i++)
			{
				ResourceInstance resourceInstance = array[i]?.Pile?.GetStoredResource();
				if (resourceInstance != null && condition(resourceInstance))
				{
					num += resourceInstance.Amount;
				}
			}
			return num;
		}

		public int GetFreeSpace(Resource blueprint)
		{
			int num = 0;
			if (storageSlots == null)
			{
				return 0;
			}
			StorageSlot[] array = storageSlots;
			for (int i = 0; i < array.Length; i++)
			{
				ResourceInstance resourceInstance = array[i]?.Pile?.GetStoredResource();
				if (resourceInstance == null)
				{
					num = (this.blueprint.OverrideStackingLimit ? (num + this.blueprint.MaxAmount) : (num + blueprint.StackingLimit));
				}
				else if (!(resourceInstance.Blueprint != blueprint))
				{
					num = (this.blueprint.OverrideStackingLimit ? (num + (resourceInstance.StackingLimit - resourceInstance.Amount)) : (num + (blueprint.StackingLimit - resourceInstance.Amount)));
				}
			}
			return num;
		}

		public List<ResourcePileInstance> GetStoredPiles()
		{
			List<ResourcePileInstance> list = new List<ResourcePileInstance>();
			StorageSlot[] array = storageSlots;
			foreach (StorageSlot storageSlot in array)
			{
				if (storageSlot?.Pile?.GetStoredResource() != null)
				{
					list.Add(storageSlot.Pile);
				}
			}
			return list;
		}

		private void OnPileTaken(StorageSlot storageSlot, int remainingAmount)
		{
			int arg = Array.IndexOf(storageSlots, storageSlot);
			this.PileTakenEvent?.Invoke(arg, storageSlot);
		}

		private void OnPileDurabilityDepleted(StorageSlot storageSlot)
		{
			int obj = Array.IndexOf(storageSlots, storageSlot);
			this.PileDurabilityDepletedEvent?.Invoke(obj);
		}

		private void InitializeAllowedResources(UniversalStorageBlueprint blueprint)
		{
			if (blueprint == null)
			{
				return;
			}
			if (defaultAllowed == null)
			{
				defaultAllowed = new HashSet<Resource>();
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (allItem != null && blueprint.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup))
				{
					resourcesFilter.AddAllowedResource(allItem);
					defaultAllowed.Add(allItem);
					resourcesFilter.CacheDefaultAllowedResources(allItem);
				}
			}
		}

		private void SetupDefaultAllowedByBlueprint(UniversalStorageBlueprint blueprint)
		{
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (allItem != null && blueprint.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup))
				{
					resourcesFilter.CacheDefaultAllowedResources(allItem);
				}
			}
		}

		public int GetStorageAmountForOverridenStackingLimit()
		{
			if (!blueprint.OverrideStackingLimit)
			{
				return -1;
			}
			int num = 0;
			StorageSlot[] array = storageSlots;
			foreach (StorageSlot storageSlot in array)
			{
				if (storageSlot != null)
				{
					if (storageSlot.Pile == null)
					{
						num += blueprint.MaxAmount;
						continue;
					}
					ResourceInstance storedResource = storageSlot.Pile.GetStoredResource();
					num = ((storedResource != null && storedResource.Amount != 0) ? (num + (storedResource.StackingLimit - storedResource.Amount)) : (num + blueprint.MaxAmount));
				}
			}
			return num;
		}

		public int GetFreeSpace()
		{
			int num = 0;
			StorageSlot[] array = storageSlots;
			foreach (StorageSlot storageSlot in array)
			{
				if (storageSlot == null)
				{
					num++;
					continue;
				}
				ResourcePileInstance pile = storageSlot.Pile;
				if (pile == null)
				{
					num++;
					continue;
				}
				ResourceInstance storedResource = pile.GetStoredResource();
				if (storedResource == null)
				{
					num++;
				}
				else if (!blueprint.OverrideStackingLimit)
				{
					if (storedResource.Blueprint.StackingLimit - storedResource.Amount > 0)
					{
						num++;
					}
				}
				else if (storedResource.StackingLimit - storedResource.Amount > 0)
				{
					num++;
				}
			}
			return num;
		}

		public void PasteStorageSettings(IStorage original)
		{
			if (original is StockpileInstance)
			{
				HashSet<Resource> resourcesFromOriginal = new HashSet<Resource>(original.ResourcesFilter.AllowedResourceTypes);
				PasteResourceFilter(original, resourcesFromOriginal);
			}
			else if (original is ShelfComponentInstance shelfComponentInstance)
			{
				PasteResourceFilter(original, shelfComponentInstance.AllStorage);
			}
		}

		public void PasteStorageSettings(ShelfCopySettingsData shelfCopyData, int index)
		{
			PasteResourceFilter(shelfCopyData, index);
			priority = shelfCopyData.Priority;
			isForbidden = shelfCopyData.IsForbidden;
		}

		private void PasteResourceFilter(ShelfCopySettingsData shelfCopyData, int index)
		{
			using PooledHashSet<Resource> pooledHashSet = HashSetPool<Resource>.GetJanitor();
			resourcesFilter.ClearAllowedResourceTypes();
			for (int i = 0; i < shelfCopyData.ResourceFilters.Count; i++)
			{
				if (i == index)
				{
					pooledHashSet.UnionWith(shelfCopyData.ResourceFilters[i].AllowedResourceTypes);
					resourcesFilter.SetQuality(shelfCopyData.ResourceFilters[i].Quality);
					resourcesFilter.SetHitPointsPercent(shelfCopyData.ResourceFilters[i].HitPointsPercent);
				}
			}
			foreach (Resource item in pooledHashSet)
			{
				if (defaultAllowed.Contains(item))
				{
					resourcesFilter.AddAllowedResource(item);
				}
			}
		}

		private void PasteResourceFilter(IStorage original, List<UniversalStorage> originalStorages)
		{
			HashSet<Resource> hashSet = new HashSet<Resource>();
			this.resourcesFilter.SetAllowedResourceTypes(hashSet);
			foreach (UniversalStorage originalStorage in originalStorages)
			{
				ResourcesFilter resourcesFilter = originalStorage.ResourcesFilter;
				hashSet.UnionWith(resourcesFilter.AllowedResourceTypes);
			}
			this.resourcesFilter.SetQuality(original.ResourcesFilter.Quality);
			this.resourcesFilter.SetHitPointsPercent(original.ResourcesFilter.HitPointsPercent);
			foreach (Resource item in hashSet)
			{
				if (defaultAllowed.Contains(item))
				{
					this.resourcesFilter.AddAllowedResource(item);
				}
			}
		}

		private void PasteResourceFilter(IStorage original, HashSet<Resource> resourcesFromOriginal)
		{
			resourcesFromOriginal.RemoveWhere((Resource resource) => !defaultAllowed.Contains(resource));
			resourcesFilter.SetAllowedResourceTypes(resourcesFromOriginal);
			resourcesFilter.SetQuality(original.ResourcesFilter.Quality);
			resourcesFilter.SetHitPointsPercent(original.ResourcesFilter.HitPointsPercent);
		}

		public void AllowResource(Resource resource, bool allowed)
		{
			bool flag = false;
			foreach (ResourceGroups resourceGroup in blueprint.ResourceGroups)
			{
				if (resourceGroup.GetID() == resource.SortingGroup)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			if (allowed)
			{
				resourcesFilter.AddAllowedResource(resource);
				return;
			}
			resourcesFilter.RemoveAllowedResource(resource);
			if (owner != null && owner.AnimalFeeder)
			{
				DropResource(resource);
			}
		}

		public bool CanStore(ResourceInstance resource, CreatureBase creatureBase = null)
		{
			if (resource == null || storageSlots == null)
			{
				return false;
			}
			if (isForbidden)
			{
				return false;
			}
			if (!resourcesFilter.IsValid(resource))
			{
				return false;
			}
			for (int i = 0; i < storageSlots.Length; i++)
			{
				if (CanStore(resource, storageSlots[i], creatureBase))
				{
					return true;
				}
			}
			return false;
		}

		internal bool CanStore(ResourceInstance resource, StorageSlot storageSlot, CreatureBase creatureBase = null)
		{
			if (storageSlot == null)
			{
				return false;
			}
			if (storageSlot.HasReservation())
			{
				if (creatureBase != storageSlot.ReservationInfo.Agent)
				{
					return false;
				}
				return storageSlot.ReservationInfo.Blueprint == resource.Blueprint;
			}
			ResourceInstance resourceInstance = storageSlot.Pile?.GetStoredResource();
			if (resourceInstance == null || resourceInstance.BlueprintId == null)
			{
				return true;
			}
			if (resourceInstance.Blueprint != resource.Blueprint)
			{
				return false;
			}
			if (!blueprint.OverrideStackingLimit)
			{
				return resourceInstance.Amount < resource.Blueprint.StackingLimit;
			}
			return resourceInstance.Amount < resourceInstance.StackingLimit;
		}

		public int StoreResourcePile(CreatureBase agent, Resource blueprint, int amount)
		{
			if (agent == null || agent.HasDisposed)
			{
				return 0;
			}
			int num = 0;
			ResourceInstance resourceInstance = agent.Storage.Take(blueprint, amount);
			if (resourceInstance.Amount <= 0)
			{
				return 0;
			}
			int num2 = amount;
			for (int i = 0; i < storageSlots.Length; i++)
			{
				StorageSlot storageSlot = storageSlots[i];
				if (storageSlot.ReservationInfo.Agent == agent && (storageSlot.Pile == null || storageSlot.Pile.Blueprint == blueprint))
				{
					int num3 = StoreResourcePile(resourceInstance, storageSlot);
					num += num3;
					num2 -= num3;
					if (num2 <= 0)
					{
						break;
					}
				}
			}
			if (num2 > 0)
			{
				resourceInstance?.TransferTo(agent.Storage);
			}
			return num;
		}

		public int StoreResourcePile(ResourceInstance resource)
		{
			int num = 0;
			if (resource.Amount <= 0)
			{
				return 0;
			}
			int num2 = resource.Amount;
			StorageSlot[] array = storageSlots;
			foreach (StorageSlot storageSlot in array)
			{
				if (storageSlot.Pile == null || storageSlot.Pile.Blueprint == resource.Blueprint)
				{
					int num3 = StoreResourcePile(resource, storageSlot);
					num += num3;
					num2 -= num3;
					if (num2 <= 0)
					{
						break;
					}
				}
			}
			return num;
		}

		public int StoreResourcePile(ResourceInstance resource, StorageSlot storageSlot)
		{
			if (resource == null || resource.Amount <= 0)
			{
				return 0;
			}
			if (storageSlot.Pile != null && storageSlot.Pile.Blueprint != resource.Blueprint)
			{
				string blueprintId = resource.BlueprintId;
				Vector3 vector = position;
				Log.Error("ERROR! Tried to store multiple resource types on same ResourcePile " + blueprintId + " POS: " + vector.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\UniversalStorage.cs");
				return 0;
			}
			if (storageSlot.Pile != null)
			{
				int num = resource.TransferTo(storageSlot.Pile.GetStorage());
				if (num > 0)
				{
					Action<int, StorageSlot> action = this.PileStoredEvent;
					if (action == null)
					{
						return num;
					}
					action(Array.IndexOf(storageSlots, storageSlot), storageSlot);
				}
				return num;
			}
			ResourcePileInstance resourcePileInstance = null;
			int num2 = resource.Blueprint.StackingLimit;
			if (blueprint.OverrideStackingLimit)
			{
				num2 = blueprint.MaxAmount;
			}
			if (resource.Amount <= num2)
			{
				ResourceInstance resourceInstance = resource.Clone();
				resourcePileInstance = ResourcePileFactory.ProducePile(resourceInstance, position);
				resource.Sub(resourceInstance);
			}
			else
			{
				ResourceInstance resourceInstance2 = resource.Clone(0);
				resource.TransferTo(resourceInstance2, num2);
				resourcePileInstance = ResourcePileFactory.ProducePile(resourceInstance2, position);
			}
			resourcePileInstance.SetPlacedOnStorage(owner, this);
			resourcePileInstance.SetIsStoredOnStockpile(resourcesFilter.IsValid(resourcePileInstance.GetStoredResource()), this);
			storageSlot.SetStoredPile(resourcePileInstance);
			storageSlot.PileTakenEvent += OnPileTaken;
			storageSlot.PileHealthDepletedEvent += OnPileDurabilityDepleted;
			if (!storageSlot.HasVisuals)
			{
				resourcePileInstance.DoNotCreateView = true;
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourcePileInstance);
				this.PileStoredNoViewUpdateEvent?.Invoke(Array.IndexOf(storageSlots, storageSlot), storageSlot);
			}
			else
			{
				this.PileStoredEvent?.Invoke(Array.IndexOf(storageSlots, storageSlot), storageSlot);
			}
			return resourcePileInstance.GetStoredResource().Amount;
		}

		public void Dispose()
		{
			if (!HasDisposed)
			{
				resourcesFilter.OnParamsChangedEvent -= OnStorageParamsChanged;
				if (LoadingController.IsSceneTransition)
				{
					DisposeStorage();
				}
				else
				{
					DropStorage();
				}
				owner = null;
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				this.PileStoredNoViewUpdateEvent = null;
				this.PileStoredEvent = null;
				this.PileTakenEvent = null;
				this.PileDurabilityDepletedEvent = null;
				this.StorageForbidEvent = null;
				defaultAllowed.Clear();
			}
		}

		public void DisposeStorage()
		{
			for (int i = 0; i < storageSlots.Length; i++)
			{
				storageSlots[i]?.Pile?.Dispose();
				storageSlots[i] = null;
			}
			storageSlots = null;
		}

		public void DropStorage(bool spill = false)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
			Resource iceBlockBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID("ice_block");
			ShelfComponentInstance shelfComponentInstance = owner as ShelfComponentInstance;
			bool valueOrDefault = shelfComponentInstance?.OwnerBuilding?.HealthDepleted == true;
			bool flag = shelfComponentInstance?.Frozen ?? false;
			for (int i = 0; i < storageSlots.Length; i++)
			{
				ResourcePileInstance resourcePileInstance = storageSlots[i]?.Pile;
				if (!spill)
				{
					storageSlots[i] = null;
				}
				ResourceInstance resourceInstance = resourcePileInstance?.GetStoredResource();
				if (resourceInstance == null)
				{
					continue;
				}
				Vec3Int gridPosition = GetGridPosition();
				if (MonoSingleton<GroundManager>.Instance.GroundExists(gridPosition))
				{
					if (resourceInstance.Blueprint != byID)
					{
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance.Clone(), position);
					}
					else
					{
						if (!valueOrDefault && !spill)
						{
							if (!flag)
							{
								MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance.Clone(), position);
							}
							else
							{
								SpawnIceBlock(resourceInstance, shelfComponentInstance);
							}
						}
						else if (!flag)
						{
							SpawnWater(shelfComponentInstance, resourceInstance);
						}
						else
						{
							SpawnIceBlock(resourceInstance, shelfComponentInstance);
						}
						resourcePileInstance.GetStorage().DeleteResource(resourceInstance);
						if (spill)
						{
							this.PileTakenEvent?.Invoke(i, storageSlots[i]);
						}
					}
				}
				else
				{
					MapNode node = VillageManager.ActiveVillage.Map.GetNode(GetGridPosition());
					if (node != null)
					{
						if (resourceInstance.Blueprint != byID)
						{
							MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourcePileInstance.GetStorage().Take(), node.WorldPosition);
						}
						else
						{
							if (!valueOrDefault && !spill)
							{
								if (!flag)
								{
									MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance.Clone(), position);
								}
								else
								{
									SpawnIceBlock(resourceInstance, shelfComponentInstance);
								}
							}
							else if (!flag)
							{
								SpawnWater(shelfComponentInstance, resourceInstance);
							}
							else
							{
								SpawnIceBlock(resourceInstance, shelfComponentInstance);
							}
							resourcePileInstance.GetStorage().DeleteResource(resourceInstance);
							if (spill)
							{
								this.PileTakenEvent?.Invoke(i, storageSlots[i]);
							}
						}
					}
					else
					{
						Log.Warning("Could not find closest walkable node for pile spawning!", "C:\\GIT\\dev\\Assets\\Scripts\\UniversalStorage\\UniversalStorage.cs");
					}
				}
				resourcePileInstance.Dispose();
			}
			void SpawnIceBlock(ResourceInstance waterBucket, ShelfComponentInstance shelf)
			{
				if (waterBucket != null && shelf != null && !shelf.HasDisposed)
				{
					int num = ((shelf.Blueprint.ShelfSize == ShelfSize.Normal) ? 5 : 10);
					int num2 = (int)UnitIntervalRange(0f, waterBucket.StackingLimit, 0f, num, waterBucket.Amount);
					for (int j = 0; j < num2; j++)
					{
						ResourceInstance resource = new ResourceInstance(iceBlockBlueprint, iceBlockBlueprint.StackingLimit);
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource, position);
					}
				}
			}
			static void SpawnWater(ShelfComponentInstance shelf, ResourceInstance resource)
			{
				int count = shelf.Positions.Count;
				int num = resource.Amount / (count * 2);
				float num2 = Mathf.InverseLerp(0f, 1f, num);
				float num3 = 0f;
				num3 = ((num2 >= 0f && num2 < 0.3f) ? 0.3f : ((!(num2 >= 0.3f) || !(num2 < 0.6f)) ? 1f : 0.6f));
				foreach (Vec3Int position in shelf.Positions)
				{
					int index = shelf.Map.GetNode(position).Index;
					shelf.Map.WaterManager.WaterSimLogic.SetWaterAt(index, num3);
				}
			}
			static float UnitIntervalRange(float stageStartRange, float stageFinishRange, float newStartRange, float newFinishRange, float floatingValue)
			{
				float num = Mathf.Abs(newFinishRange - newStartRange);
				float num2 = Mathf.Abs(stageFinishRange - stageStartRange);
				float num3 = num / num2;
				return newStartRange + num3 * (floatingValue - stageStartRange);
			}
		}

		private void DropResource(Resource blueprint)
		{
			for (int i = 0; i < storageSlots.Length; i++)
			{
				if (storageSlots[i] != null)
				{
					ResourcePileInstance pile = storageSlots[i].Pile;
					ResourceInstance resourceInstance = pile?.GetStoredResource();
					if (resourceInstance != null && !(resourceInstance.Blueprint != blueprint))
					{
						Vec3Int gridPosition = GetGridPosition();
						MapNode node = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance.Clone(), node.WorldPosition);
						VillageManager.ActiveVillage.Map.RemoveFromWorld(pile);
						storageSlots[i].SetStoredPile(null);
						OnPileTaken(storageSlots[i], 0);
					}
				}
			}
		}

		private void OnStorageParamsChanged()
		{
			StorageSlot[] array = storageSlots;
			foreach (StorageSlot storageSlot in array)
			{
				if (storageSlot != null)
				{
					if (storageSlot.HasReservation() && resourcesFilter.IsBlueprintAllowed(storageSlot.ReservationInfo.Blueprint))
					{
						storageSlot.ClearReservations();
					}
					storageSlot.Pile?.SetIsStoredOnStockpile(resourcesFilter.IsValid(storageSlot?.Pile?.GetStoredResource()), this);
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("universalStorageID", universalStorageID);
			serializer.Write("resourcesFilter", resourcesFilter);
			serializer.Write("storageSlots", storageSlots);
			serializer.Write("position", position);
			serializer.Write("isForbidden", isForbidden);
			serializer.WriteEnum("priority", priority);
		}

		public UniversalStorage(FVDeserializer deserializer)
		{
			universalStorageID = deserializer.ReadString("universalStorageID");
			resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
			storageSlots = deserializer.ReadObjectArray<StorageSlot>("storageSlots");
			position = deserializer.ReadVector3("position");
			isForbidden = deserializer.ReadBool("isForbidden");
			priority = deserializer.ReadEnum("priority", ZonePriority.None);
		}
	}
}
