using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.Extensions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Components
{
	[Serializable]
	[FVSerializableKey("Storage", "")]
	public class Storage : IGameDisposable, IDisposable, IFVSerializable
	{
		[SerializeField]
		private StorageBase storageBase;

		[SerializeField]
		private List<ResourceInstance> currentResources = new List<ResourceInstance>();

		private readonly object resourcesLock = new object();

		public bool HasDisposed { get; private set; }

		public StorageBase StorageBase => storageBase;

		public ResourceInstance FirstResource
		{
			get
			{
				lock (resourcesLock)
				{
					if (currentResources == null || currentResources.Count == 0)
					{
						return null;
					}
					return currentResources[0];
				}
			}
		}

		public IEnumerable<ResourceInstance> Resources
		{
			get
			{
				lock (resourcesLock)
				{
					if (currentResources == null)
					{
						yield break;
					}
					for (int i = currentResources.Count - 1; i >= 0; i--)
					{
						if (i < currentResources.Count)
						{
							yield return currentResources[i];
						}
					}
				}
			}
		}

		public int ResourceCount
		{
			get
			{
				lock (resourcesLock)
				{
					if (currentResources == null)
					{
						return 0;
					}
					return currentResources.Count;
				}
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<SimpleResourceCount> ResourceTakenEvent;

		public event Action<SimpleResourceCount> ResourceAddedEvent;

		public event Action<ResourceInstance> FreshnessDepletedEvent;

		public event Action<ResourceInstance> HealthDepletedEvent;

		public event Action<ResourceInstance> ResourceDeletedEvent;

		public Storage(StorageBase storageBase)
		{
			this.storageBase = storageBase;
		}

		public Storage(Storage storage)
		{
			storageBase = storage.storageBase;
			lock (resourcesLock)
			{
				foreach (ResourceInstance currentResource in storage.currentResources)
				{
					ResourceInstance resourceInstance = currentResource.Clone();
					currentResources.Add(resourceInstance);
					FreshnessDepletedSubscribe(resourceInstance);
					HealthDepletedSubscribe(resourceInstance);
				}
			}
		}

		public Storage(StorageBase storageBase, ResourceInstance resource)
		{
			this.storageBase = storageBase;
			lock (resourcesLock)
			{
				currentResources.Add(resource);
			}
			FreshnessDepletedSubscribe(resource);
			HealthDepletedSubscribe(resource);
		}

		public void Dispose()
		{
			HasDisposed = true;
			this.ResourceAddedEvent = null;
			this.ResourceTakenEvent = null;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.FreshnessDepletedEvent = null;
			this.HealthDepletedEvent = null;
			this.ResourceDeletedEvent = null;
			foreach (ResourceInstance resource in Resources)
			{
				if (resource != null && !resource.HasDisposed)
				{
					resource.Dispose();
				}
			}
			lock (resourcesLock)
			{
				currentResources?.Clear();
				currentResources = null;
			}
			this.OnDisposedEvent = null;
		}

		public void SetStorageCapacity(int newCapacity)
		{
			if (!HasDisposed)
			{
				storageBase.SetCapacity(newCapacity);
			}
		}

		public void SetStorageBase(StorageBase storageBase)
		{
			this.storageBase = storageBase;
		}

		public void ClearResources()
		{
			lock (resourcesLock)
			{
				currentResources.Clear();
			}
		}

		public ResourceInstance GetSingleResource()
		{
			if (currentResources == null || ResourceCount == 0)
			{
				return null;
			}
			ResourceInstance resourceInstance = null;
			lock (resourcesLock)
			{
				int i = 0;
				for (int count = currentResources.Count; i < count; i++)
				{
					ResourceInstance resourceInstance2 = currentResources[i];
					if (!resourceInstance2.HasDisposed && resourceInstance2.Amount > 0)
					{
						resourceInstance = resourceInstance2;
						break;
					}
				}
			}
			if (resourceInstance == null)
			{
				ClearAll();
				return null;
			}
			return resourceInstance;
		}

		public ResourceInstance GetById(string id)
		{
			lock (resourcesLock)
			{
				return currentResources.FirstOrDefault((ResourceInstance item) => item.BlueprintId.Equals(id));
			}
		}

		public ResourceInstance GetByFilter(ResourceSearchFilter filter, bool ignoreCount = false)
		{
			lock (resourcesLock)
			{
				return currentResources.FirstOrDefault((ResourceInstance item) => filter.Check(item, ignoreCount));
			}
		}

		public bool HasOneOrMoreResources()
		{
			lock (resourcesLock)
			{
				return currentResources.Any((ResourceInstance item) => item.Amount > 0);
			}
		}

		public float GetFreeSpace()
		{
			return (float)storageBase.Capacity - GetResourceWeight();
		}

		public float GetResourceWeight()
		{
			lock (resourcesLock)
			{
				return currentResources.Sum((ResourceInstance resource) => (float)resource.Amount * (storageBase.IgnoreWeigth ? 1f : resource.Blueprint.Weight));
			}
		}

		public float GetResourceWeight(ResourceInstance resource, bool ignoreAmount = false)
		{
			return (ignoreAmount ? 1f : ((float)resource.Amount)) * (storageBase.IgnoreWeigth ? 1f : resource.Blueprint.Weight);
		}

		public bool IsEmpty()
		{
			lock (resourcesLock)
			{
				return currentResources == null || currentResources.Count == 0 || !currentResources.Any((ResourceInstance item) => item.Amount > 0);
			}
		}

		public bool CanStore(ResourceInstance resource)
		{
			if (resource == null)
			{
				return false;
			}
			if (storageBase.Infinite)
			{
				return true;
			}
			if (storageBase.IgnoreWeigth)
			{
				return GetFreeSpace() > 0f;
			}
			return GetFreeSpace() >= resource.Blueprint.Weight;
		}

		public bool HasExactOrMore(ResourceInstance resource)
		{
			if (resource == null)
			{
				return false;
			}
			lock (resourcesLock)
			{
				return currentResources.Any((ResourceInstance r) => r.BlueprintId.Equals(resource.BlueprintId) && r.Amount >= resource.Amount);
			}
		}

		public bool HasPartialOrMore(List<ResourceInstance> resources)
		{
			foreach (ResourceInstance resource in resources)
			{
				if (HasPartialOrMore(resource))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasPartialOrMore(ResourceInstance resource)
		{
			if (resource == null)
			{
				return false;
			}
			lock (resourcesLock)
			{
				return currentResources.Any((ResourceInstance r) => r.BlueprintId.Equals(resource.BlueprintId) && r.Amount > 0);
			}
		}

		public bool HasPartialOrMore(KeyValuePair<ResourceCategory, int> resource)
		{
			if (resource.Equals(null) || resource.Value == 0)
			{
				return false;
			}
			lock (resourcesLock)
			{
				return currentResources.Any((ResourceInstance r) => (r.Blueprint.Category & resource.Key) != ResourceCategory.None && r.Amount > 0);
			}
		}

		public bool HasPartialOrMore(KeyValuePair<ItemMaterialCategory, int> resource)
		{
			if (resource.Equals(null) || resource.Value == 0)
			{
				return false;
			}
			lock (resourcesLock)
			{
				return currentResources.Any((ResourceInstance r) => r.Blueprint.ItemMaterialCategory.Equals(resource.Key));
			}
		}

		public void ClearAll(bool isSilent = false)
		{
			lock (resourcesLock)
			{
				foreach (ResourceInstance currentResource in currentResources)
				{
					int amount = currentResource.Amount;
					if (amount > 0)
					{
						currentResource.Sub(amount);
						if (MonoSingleton<ResourceCommonController>.IsInstantiated())
						{
							MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorage(currentResource, this);
						}
						if (!isSilent)
						{
							this.ResourceTakenEvent?.Invoke(new SimpleResourceCount(currentResource.Blueprint, amount));
						}
					}
					currentResource.Dispose();
				}
				UnsubscribeAll();
				currentResources.Clear();
			}
		}

		public void DeleteResource(ResourceInstance resourceInstance)
		{
			lock (resourcesLock)
			{
				currentResources.Remove(resourceInstance);
			}
			FreshnessDepletedUnsubscribe(resourceInstance);
			HealthDepletedUnsubscribe(resourceInstance);
			this.ResourceDeletedEvent?.Invoke(resourceInstance);
			resourceInstance.Dispose();
		}

		public int GetTotalStoredCount()
		{
			int num = 0;
			foreach (ResourceInstance resource in Resources)
			{
				num += resource.Amount;
			}
			return num;
		}

		public int GetTotalStoredCount(Resource resource)
		{
			int num = 0;
			foreach (ResourceInstance resource2 in Resources)
			{
				if (!(resource2.Blueprint != resource))
				{
					num += resource2.Amount;
				}
			}
			return num;
		}

		public int GetTotalStoredCount(ResourceCategory category)
		{
			if (category == ResourceCategory.None)
			{
				return 0;
			}
			int num = 0;
			foreach (ResourceInstance resource in Resources)
			{
				Resource blueprint = resource.Blueprint;
				if (!(blueprint == null) && (blueprint.Category & category) != ResourceCategory.None)
				{
					num += resource.Amount;
				}
			}
			return num;
		}

		public ResourceInstance GetResource(ResourceCategory category)
		{
			if (category == ResourceCategory.None)
			{
				return null;
			}
			foreach (ResourceInstance resource in Resources)
			{
				Resource blueprint = resource.Blueprint;
				if (!(blueprint == null) && (blueprint.Category & category) != ResourceCategory.None)
				{
					return resource;
				}
			}
			return null;
		}

		public int GetMaximumStorableCount(Resource resource)
		{
			if (resource == null)
			{
				return 0;
			}
			if (resource.EquipmentBlueprint != null)
			{
				if (!(GetFreeSpace() >= resource.Weight))
				{
					return 0;
				}
				return 1;
			}
			if ((resource.Category & (ResourceCategory.CtgCarcass | ResourceCategory.CtgStructure)) != ResourceCategory.None)
			{
				if (ResourceCount <= 0)
				{
					return 1;
				}
				return 0;
			}
			if (resource.Category == ResourceCategory.None && resource.GetID().Contains("trophy"))
			{
				if (ResourceCount <= 0)
				{
					return 1;
				}
				return 0;
			}
			if (StorageBase.IgnoreWeigth)
			{
				return (int)GetFreeSpace();
			}
			if ((float)(int)GetFreeSpace() < resource.Weight)
			{
				if (ResourceCount <= 0)
				{
					return 1;
				}
				return 0;
			}
			return (int)(GetFreeSpace() / resource.Weight);
		}

		public int Consume(Resource blueprint, int amount)
		{
			int num;
			lock (resourcesLock)
			{
				num = currentResources.FindIndex((ResourceInstance rr) => rr.Blueprint == blueprint);
			}
			if (num < 0)
			{
				return 0;
			}
			ResourceInstance resourceInstance;
			lock (resourcesLock)
			{
				resourceInstance = currentResources[num];
			}
			int amount2 = resourceInstance.Amount;
			if (amount2 <= 0)
			{
				return 0;
			}
			resourceInstance.Sub(amount);
			int amount3 = resourceInstance.Amount;
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorage(resourceInstance, this);
			}
			this.ResourceTakenEvent?.Invoke(new SimpleResourceCount(blueprint, amount2 - resourceInstance.Amount));
			if (!HasDisposed && amount3 <= 0)
			{
				DeleteResource(resourceInstance);
			}
			return amount2 - amount3;
		}

		public ResourceInstance Take(ResourceInstance instance)
		{
			if (instance == null || instance.HasDisposed)
			{
				return null;
			}
			return Take(instance.Blueprint, instance.Amount);
		}

		public ResourceInstance Take()
		{
			ResourceInstance resourceInstance;
			lock (resourcesLock)
			{
				resourceInstance = currentResources.FirstOrDefault();
			}
			if (resourceInstance == null)
			{
				return null;
			}
			return Take(resourceInstance.Blueprint, resourceInstance.Amount);
		}

		public ResourceInstance Take(Resource blueprint, int amount)
		{
			if (HasDisposed)
			{
				return null;
			}
			int num;
			lock (resourcesLock)
			{
				if (currentResources == null)
				{
					return null;
				}
				num = currentResources.FindIndex((ResourceInstance rr) => rr.Blueprint == blueprint);
			}
			if (num < 0 || amount <= 0)
			{
				return null;
			}
			ResourceInstance resourceInstance;
			lock (resourcesLock)
			{
				resourceInstance = currentResources[num];
			}
			int amount2 = resourceInstance.Amount;
			resourceInstance.Sub(amount);
			amount2 -= resourceInstance.Amount;
			ResourceInstance result = resourceInstance.Clone(amount2);
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorage(resourceInstance, this);
			}
			this.ResourceTakenEvent?.Invoke(new SimpleResourceCount(resourceInstance.Blueprint, amount2));
			if (resourceInstance.Amount <= 0 && !HasDisposed)
			{
				DeleteResource(resourceInstance);
			}
			return result;
		}

		public int TransferTo(Storage destination, Resource blueprint, int amount)
		{
			if (destination == this)
			{
				Log.Error("Can not transfer resources to self. 1", "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Storage\\Storage.cs");
				return 0;
			}
			ResourceInstance resourceInstance;
			lock (resourcesLock)
			{
				int num = currentResources.FindIndex((ResourceInstance rr) => rr.Blueprint == blueprint);
				if (num < 0 || currentResources[num].Amount <= 0)
				{
					return 0;
				}
				resourceInstance = currentResources[num];
			}
			int num2 = resourceInstance.TransferTo(destination, amount);
			if (num2 <= 0)
			{
				return 0;
			}
			if (resourceInstance.Amount <= 0)
			{
				DeleteResource(resourceInstance);
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceRemovedFromStorage(resourceInstance, this);
			}
			this.ResourceTakenEvent?.Invoke(new SimpleResourceCount(resourceInstance.Blueprint, num2));
			return num2;
		}

		public int Add(ResourceInstance resourceToAdd, int amount = -1)
		{
			return Transfer(resourceToAdd, amount);
		}

		public void DropAll(Vec3Int gridPos, bool forbid = false)
		{
			if (currentResources == null || ResourceCount == 0)
			{
				return;
			}
			if (ResourceCount == 1)
			{
				ResourceInstance resourceInstance;
				lock (resourcesLock)
				{
					resourceInstance = currentResources.First();
				}
				DropResourceInstance(resourceInstance, gridPos, forbid);
				return;
			}
			using PooledList<ResourceInstance> pooledList = Resources.ToPooledListJanitor();
			foreach (ResourceInstance item in pooledList)
			{
				DropResourceInstance(item, gridPos, forbid);
			}
		}

		public void DropResourceInstance(ResourceInstance resourceInstance, Vec3Int gridPosition, bool forbidDroppedResource = false)
		{
			if (currentResources == null || ResourceCount == 0)
			{
				return;
			}
			lock (resourcesLock)
			{
				if (!currentResources.Contains(resourceInstance))
				{
					return;
				}
			}
			if (resourceInstance.Amount <= 0)
			{
				Log.Warning("Storage spawning pile with zero resources.", "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Storage\\Storage.cs");
			}
			if (resourceInstance.Stats != null && !resourceInstance.Stats.GetStat(StatType.Health).IsAtMinimum() && MonoSingleton<ResourcePileManager>.IsInstantiated())
			{
				if (resourceInstance.FactionOwnership == FactionOwnership.Player)
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance.Clone(), GridUtils.GetWorldPosition(gridPosition), forbidDroppedResource);
				}
				else
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnEnemyPile(resourceInstance.Clone(), GridUtils.GetWorldPosition(gridPosition), forbidDroppedResource);
				}
			}
			DeleteResource(resourceInstance);
		}

		public List<ResourceInstance> GetResourcesWithoutLock()
		{
			return currentResources;
		}

		public void SubscribeAll()
		{
			lock (resourcesLock)
			{
				foreach (ResourceInstance currentResource in currentResources)
				{
					HealthDepletedUnsubscribe(currentResource);
					FreshnessDepletedUnsubscribe(currentResource);
					HealthDepletedSubscribe(currentResource);
					FreshnessDepletedSubscribe(currentResource);
				}
			}
		}

		public bool IsOverweight()
		{
			if (storageBase.Infinite || storageBase.IgnoreWeigth)
			{
				return false;
			}
			return GetFreeSpace() < 0f;
		}

		public void WriteContentsListing(List<string> outLines)
		{
			if (ResourceCount <= 0)
			{
				return;
			}
			foreach (ResourceInstance resource in Resources)
			{
				if (resource.Amount > 0)
				{
					string textIcon = ResourceUtils.GetTextIcon(resource.Blueprint);
					outLines.Add($"{resource.Amount} x {textIcon} {ResourceUtils.GetLocalizedResourceName(resource.BlueprintId)}");
				}
			}
		}

		internal int Transfer(ResourceInstance resourceToAdd, int amount = -1)
		{
			if (resourceToAdd == null || resourceToAdd.Amount <= 0)
			{
				return 0;
			}
			if (amount < 1)
			{
				amount = resourceToAdd.Amount;
			}
			if (amount > resourceToAdd.Amount)
			{
				amount = resourceToAdd.Amount;
			}
			int num;
			lock (resourcesLock)
			{
				num = currentResources.FindIndex((ResourceInstance rr) => rr != null && rr.BlueprintId == resourceToAdd.BlueprintId);
			}
			if (num < 0)
			{
				if (!storageBase.Infinite)
				{
					amount = Mathf.Min(GetMaximumStorableCount(resourceToAdd.Blueprint), amount);
					if (amount <= 0)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(94, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Storage\\Storage.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Can not cary any resources of this type. This should never happen. Check resource parameters. ");
							messageBuilder.AppendFormatted(resourceToAdd.Blueprint.GetID());
						}
						Log.Warning(messageBuilder);
						return 0;
					}
				}
				ResourceInstance resourceInstance = resourceToAdd.Clone(0);
				lock (resourcesLock)
				{
					currentResources.Add(resourceInstance);
				}
				amount = resourceToAdd.TransferTo(resourceInstance, amount);
				FreshnessDepletedSubscribe(resourceInstance);
				HealthDepletedSubscribe(resourceInstance);
				if (MonoSingleton<ResourceCommonController>.IsInstantiated())
				{
					MonoSingleton<ResourceCommonController>.Instance.ResourceAddedToStorage(resourceToAdd, this);
				}
				this.ResourceAddedEvent?.Invoke(new SimpleResourceCount(resourceToAdd.Blueprint, amount));
				return amount;
			}
			float num2 = GetFreeSpace();
			ResourceInstance target;
			lock (resourcesLock)
			{
				target = currentResources[num];
			}
			float resourceWeight = GetResourceWeight(resourceToAdd);
			if (storageBase.Infinite || num2 >= resourceWeight)
			{
				if (resourceWeight <= 0f)
				{
					return 0;
				}
				amount = resourceToAdd.TransferTo(target, amount);
				if (amount <= 0)
				{
					return 0;
				}
				if (MonoSingleton<ResourceCommonController>.IsInstantiated())
				{
					MonoSingleton<ResourceCommonController>.Instance.ResourceAddedToStorage(resourceToAdd, this);
				}
				this.ResourceAddedEvent?.Invoke(new SimpleResourceCount(resourceToAdd.Blueprint, amount));
				return amount;
			}
			if (!storageBase.IgnoreWeigth)
			{
				num2 = (int)(num2 / resourceToAdd.Blueprint.Weight);
			}
			if (num2 <= 0f)
			{
				return 0;
			}
			amount = ((amount < 1) ? ((int)num2) : Mathf.Min(amount, (int)num2));
			amount = resourceToAdd.TransferTo(target, amount);
			if (amount <= 0)
			{
				return 0;
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.ResourceAddedToStorage(resourceToAdd, this);
			}
			this.ResourceAddedEvent?.Invoke(new SimpleResourceCount(resourceToAdd.Blueprint, amount));
			return amount;
		}

		private void FreshnessDepletedSubscribe(IStatsOwner statsOwner)
		{
			Subscribe(statsOwner, StatType.Freshness, OnFreshnessDepleted);
		}

		private void FreshnessDepletedUnsubscribe(IStatsOwner statsOwner)
		{
			statsOwner.Stats?.Controller?.RemoveListener(OnFreshnessDepleted);
		}

		private void HealthDepletedSubscribe(IStatsOwner statsOwner)
		{
			Subscribe(statsOwner, StatType.Health, OnHealthDepleted);
		}

		private void HealthDepletedUnsubscribe(IStatsOwner statsOwner)
		{
			statsOwner?.Stats?.Controller?.RemoveListener(OnHealthDepleted);
		}

		private void Subscribe(IStatsOwner statsOwner, StatType statType, StatsEventController.StatEventCallback method)
		{
			statsOwner.Stats.Controller.RegisterListener(StatEventType.MinimumValueReached, statType, method);
		}

		private void UnsubscribeAll()
		{
			lock (resourcesLock)
			{
				foreach (ResourceInstance currentResource in currentResources)
				{
					HealthDepletedUnsubscribe(currentResource);
					FreshnessDepletedUnsubscribe(currentResource);
				}
			}
		}

		private void OnFreshnessDepleted(object stat)
		{
			if (this.FreshnessDepletedEvent != null)
			{
				ResourceInstance obj = ((StatInstance)stat).Owner.Owner as ResourceInstance;
				this.FreshnessDepletedEvent?.Invoke(obj);
			}
		}

		private void OnHealthDepleted(object stat)
		{
			if (this.HealthDepletedEvent != null)
			{
				ResourceInstance obj = ((StatInstance)stat).Owner.Owner as ResourceInstance;
				this.HealthDepletedEvent?.Invoke(obj);
			}
		}

		public override string ToString()
		{
			return "Resources: " + Resources.ToPrettyString();
		}

		public void SetResourcesOwner(bool initializeStats = false)
		{
			foreach (ResourceInstance resource in Resources)
			{
				resource.Stats.SetOwner(resource);
				resource.Stats.SetOwnerOnStats();
				if (initializeStats)
				{
					resource.Stats.Initialize();
				}
			}
		}

		public void InitResourcesAfterLoad()
		{
			lock (resourcesLock)
			{
				for (int num = ResourceCount - 1; num >= 0; num--)
				{
					ResourceInstance resourceInstance = currentResources[num];
					if (resourceInstance == null)
					{
						currentResources.RemoveAt(num);
					}
					else if (resourceInstance.Blueprint == null)
					{
						currentResources.RemoveAt(num);
						resourceInstance.Dispose();
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Storage\\Storage.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted("InitResourcesAfterLoad");
							messageBuilder.AppendLiteral(": Removing resource ");
							messageBuilder.AppendFormatted(resourceInstance);
						}
						Log.Info(messageBuilder);
					}
					else
					{
						resourceInstance?.InitAfterLoadPile();
					}
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("storageBase", storageBase);
			lock (resourcesLock)
			{
				serializer.Write("currentResources", currentResources);
			}
			serializer.Write("hasDisposed", HasDisposed);
		}

		public Storage(FVDeserializer deserializer)
		{
			storageBase = deserializer.ReadObject<StorageBase>("storageBase");
			currentResources = deserializer.ReadObjectList<ResourceInstance>("currentResources");
			HasDisposed = deserializer.ReadBool("hasDisposed");
		}

		public bool Contains(string resName)
		{
			return Resources.AnyNonAlloc((ResourceInstance res) => res.Amount > 0 && res.BlueprintId == resName);
		}
	}
}
