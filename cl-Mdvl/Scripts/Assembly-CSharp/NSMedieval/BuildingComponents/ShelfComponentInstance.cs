using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.UI.Utils;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("ShelfComponentInstance", "")]
	public class ShelfComponentInstance : BaseComponentInstance, IStorage, IGameDisposable, IDisposable, IGoapTargetable, ILockable
	{
		private const int HoursUntilFrozen = 3;

		[SerializeField]
		private string storageName;

		[SerializeField]
		private List<UniversalStorage> allStorage = new List<UniversalStorage>();

		[SerializeField]
		private ShelfOrder shelfOrder;

		[SerializeField]
		private LockState lockState;

		[SerializeField]
		private int tempBellowZeroHourCount;

		[SerializeField]
		private bool frozen;

		[SerializeField]
		private bool canBeUsedInProduction = true;

		[NonSerialized]
		private ShelfComponentBlueprint blueprint;

		[NonSerialized]
		private List<ResourceGroups> defaultResourceGroups;

		public ShelfOrder ShelfOrder => shelfOrder;

		public LockState LockState => lockState;

		public bool HasOrders => shelfOrder != ShelfOrder.None;

		public List<LockStateData> LockStates => Blueprint.LockStates;

		public bool IsOpen => lockState == LockState.AlwaysOpen;

		public bool IsClosed => lockState == LockState.Locked;

		public bool Frozen => frozen;

		public bool IsPlayerOwned => base.OwnerBuilding?.OwnedByPlayer() ?? false;

		public ShelfComponentBlueprint Blueprint => blueprint;

		public string StorageName => storageName;

		public ResourcesFilter ResourcesFilter => AllStorage?.FirstOrDefault()?.ResourcesFilter;

		public string ObjectId => base.ComponentBlueprintID;

		public List<ResourceGroups> DefaultResourceGroups => defaultResourceGroups;

		public List<UniversalStorage> AllStorage => allStorage;

		public ZonePriority Priority => AllStorage?.FirstOrDefault()?.Priority ?? ZonePriority.Low;

		public new bool Underwater => base.Underwater;

		public bool AnimalFeeder => blueprint.AnimalFeeder;

		public bool PrisonFeeder => blueprint.PrisonFeeder;

		public bool CanBeUsedInProduction => canBeUsedInProduction;

		public float RefillPercentageThreshold
		{
			get
			{
				if (allStorage != null && allStorage.Count > 0)
				{
					return allStorage.First().UniversalStorageBlueprint.RefillPercentageThreshold;
				}
				return 0f;
			}
		}

		public event Action ShelfForbiddenStatusChangeEvent;

		public event Action<bool> ShelfFrozenEvent;

		public ShelfComponentInstance(BaseBuildingInstance ownerBuilding, ShelfComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			storageName = BuildingUtils.GetLocalizedName(base.OwnerBuildingID);
			InitializeStorage(base.OwnerBuilding.WorldPosition);
			PasteStorageSettings();
			lockState = LockState.Locked;
			if (Blueprint.Barrel)
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			}
		}

		public LockState GetLockStateForOrder()
		{
			return shelfOrder switch
			{
				ShelfOrder.Close => LockState.Locked, 
				ShelfOrder.Open => LockState.AlwaysOpen, 
				_ => LockState.Undefined, 
			};
		}

		private void PasteStorageSettings()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData != null)
			{
				ShelfCopySettingsData shelfCopySettingsData = currentVillageData.ShelfCopyData.FirstOrDefault((ShelfCopySettingsData x) => x.TargetBuilding == base.OwnerBuilding);
				if (shelfCopySettingsData != null)
				{
					currentVillageData.DeleteShelfCopyData(shelfCopySettingsData);
					PasteStorageSettings(shelfCopySettingsData);
				}
			}
		}

		public ShelfCopySettingsData GetCopyData(BaseBuildingInstance newBuilding)
		{
			List<ResourcesFilter> list = new List<ResourcesFilter>();
			foreach (UniversalStorage item in allStorage)
			{
				list.Add(item.ResourcesFilter.DeepCopy());
			}
			return new ShelfCopySettingsData(list, IsForbidden(), Priority, newBuilding);
		}

		public override void Dispose()
		{
			if (base.HasDisposed)
			{
				return;
			}
			base.Map.ShelfComponentManager.RemoveFromCache(this);
			foreach (UniversalStorage item in allStorage)
			{
				item.Dispose();
			}
			allStorage.Clear();
			allStorage = null;
			defaultResourceGroups?.Clear();
			defaultResourceGroups = null;
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			this.ShelfFrozenEvent = null;
			base.Dispose();
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			if (base.OwnerBuilding == null)
			{
				Log.Error("OwnerBuilding is null when initializing ShelfComponentInstance storage after loading. This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponentInstance.cs");
				return;
			}
			InitializeStorage(base.OwnerBuilding.WorldPosition, afterLoading: true);
			foreach (UniversalStorage item in AllStorage)
			{
				item.SetupAfterLoading(this);
			}
			if (shelfOrder != ShelfOrder.None)
			{
				base.Map.ShelfComponentManager.HasShelvesWithOrders.Add(this);
			}
			if (Blueprint.Barrel)
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			}
		}

		public void SetForbidden(bool isForbidden)
		{
			foreach (UniversalStorage item in AllStorage)
			{
				item.SetForbidden(isForbidden);
			}
			this.ShelfForbiddenStatusChangeEvent?.Invoke();
		}

		public void SetName(string name)
		{
			storageName = name;
		}

		public bool CanStore(ResourceInstance resource, CreatureBase creatureBase = null)
		{
			if (base.HasDisposed)
			{
				return false;
			}
			if (IsOpen)
			{
				return false;
			}
			if (base.OwnerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				return false;
			}
			foreach (UniversalStorage item in allStorage)
			{
				if (item.CanStore(resource, creatureBase) && StorageUtils.ShouldRefill(item, RefillPercentageThreshold))
				{
					return true;
				}
			}
			return false;
		}

		public LinkedList<LifeEventLogStruct> GetLifeEventLog()
		{
			foreach (UniversalStorage item in AllStorage)
			{
				if (item == null || item.HasDisposed)
				{
					continue;
				}
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					if (storageSlot?.Pile?.GetStoredResource() != null && !storageSlot.Pile.HasDisposed)
					{
						ResourceInstance storedResource = storageSlot.Pile.GetStoredResource();
						if (storedResource != null && storedResource.LifeEventLogs != null && storedResource.LifeEventLogs.Count > 0)
						{
							return storedResource.LifeEventLogs;
						}
					}
				}
			}
			return null;
		}

		public bool ShouldChangeLockState()
		{
			if (!ShouldLock())
			{
				return ShouldAlwaysOpen();
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldLock()
		{
			if (ShelfOrder == ShelfOrder.Close)
			{
				return lockState != LockState.Locked;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldAlwaysOpen()
		{
			if (ShelfOrder == ShelfOrder.Open)
			{
				return lockState != LockState.AlwaysOpen;
			}
			return false;
		}

		public void SetShelfOrder(ShelfOrder shelfOrder)
		{
			if (this.shelfOrder != shelfOrder)
			{
				this.shelfOrder = shelfOrder;
				base.Map.ShelfComponentManager.HasShelvesWithOrders.Add(this);
				if (ShouldLock() || ShouldAlwaysOpen())
				{
					MonoSingleton<ConstructionController>.Instance.ShelfOrderChanged(this);
				}
			}
		}

		public void Open()
		{
			shelfOrder = ShelfOrder.None;
			lockState = LockState.AlwaysOpen;
			foreach (UniversalStorage item in allStorage)
			{
				item.DropStorage(spill: true);
			}
			Close();
		}

		private void Close()
		{
			shelfOrder = ShelfOrder.None;
			lockState = LockState.Locked;
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = ((base.BaseBuildingBlueprint.PlacementType != PlacementType.WallSocket) ? (waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High) : (waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High));
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		private void InitializeStorage(Vector3 position, bool afterLoading = false)
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				return;
			}
			if (allStorage == null)
			{
				allStorage = new List<UniversalStorage>();
			}
			if (defaultResourceGroups == null)
			{
				defaultResourceGroups = new List<ResourceGroups>();
			}
			if (blueprint == null)
			{
				if (string.IsNullOrEmpty(base.ComponentBlueprintID))
				{
					Log.Warning("ShelfComponentBlueprint was null. Failed to fetch it from repository; Component blueprint is null or empty.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponentInstance.cs");
					return;
				}
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(85, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ShelfComponentBlueprint was null. Trying to fetch it from repository; blueprint id: $");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Warning(messageBuilder);
				blueprint = Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByID(base.ComponentBlueprintID);
				if (blueprint == null)
				{
					messageBuilder = new FVLogWarningInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't fetch blueprint $");
						messageBuilder.AppendFormatted(base.ComponentBlueprintID);
						messageBuilder.AppendLiteral("; aborting initialization.");
					}
					Log.Warning(messageBuilder);
					return;
				}
			}
			if (blueprint.StorageIDs == null)
			{
				return;
			}
			foreach (string storageID in blueprint.StorageIDs)
			{
				UniversalStorageBlueprint byID = Repository<UniversalStorageRepository, UniversalStorageBlueprint>.Instance.GetByID(storageID);
				if (byID == null)
				{
					continue;
				}
				if (!afterLoading)
				{
					UniversalStorage item = new UniversalStorage(this, byID, position);
					allStorage.Add(item);
				}
				else if (allStorage.Count == 0)
				{
					UniversalStorage item2 = new UniversalStorage(this, byID, position);
					allStorage.Add(item2);
				}
				foreach (ResourceGroups resourceGroup in byID.ResourceGroups)
				{
					if (!defaultResourceGroups.Contains(resourceGroup))
					{
						defaultResourceGroups.Add(resourceGroup);
					}
				}
			}
			if (allStorage.Count > 0 && base.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
			{
				MonoSingleton<StorageCommonManager>.Instance.RegisterStorage(this);
			}
		}

		public List<ResourcePileInstance> GetStoredPiles()
		{
			List<ResourcePileInstance> list = new List<ResourcePileInstance>();
			foreach (UniversalStorage item in allStorage)
			{
				list.AddRange(from item in item.GetStoredPiles()
					where !item.HasDisposed
					select item);
			}
			return list;
		}

		public bool IsForbidden()
		{
			if (allStorage == null || allStorage.Count == 0)
			{
				return false;
			}
			return allStorage.First().IsForbidden;
		}

		public int GetStorageAmountForOverridenStackingLimit()
		{
			int num = 0;
			foreach (UniversalStorage item in allStorage)
			{
				num += item.GetStorageAmountForOverridenStackingLimit();
			}
			return num;
		}

		public int GetFreeSpace()
		{
			int num = 0;
			foreach (UniversalStorage item in allStorage)
			{
				num += item.GetFreeSpace();
			}
			return num;
		}

		public void PasteStorageSettings(IStorage original)
		{
			foreach (UniversalStorage item in allStorage)
			{
				item.PasteStorageSettings(original);
			}
		}

		public void PasteStorageSettings(ShelfCopySettingsData shelfCopyData)
		{
			if (shelfCopyData != null)
			{
				for (int i = 0; i < allStorage.Count; i++)
				{
					allStorage[i].PasteStorageSettings(shelfCopyData, i);
				}
			}
		}

		public bool ContainsPile(ResourcePileInstance pile)
		{
			if (pile == null)
			{
				return false;
			}
			foreach (UniversalStorage item in allStorage)
			{
				if (item.ContainsPile(pile))
				{
					return true;
				}
			}
			return false;
		}

		public bool ReserveStorage(ResourceInstance toStore, CreatureBase agent, out SimpleResourceCount storedAmount, out Vec3Int position)
		{
			if (AllStorage == null || AllStorage.Count == 0)
			{
				storedAmount = default(SimpleResourceCount);
				position = default(Vec3Int);
				return false;
			}
			foreach (UniversalStorage item in AllStorage)
			{
				if (!item.CanStore(toStore, agent))
				{
					continue;
				}
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					if ((storageSlot.HasReservation() && (storageSlot.ReservationInfo.Agent != agent || storageSlot.ReservationInfo.Blueprint != toStore.Blueprint || storageSlot.ReservationInfo.Amount + (storageSlot.Pile?.GetStoredResource()?.Amount).GetValueOrDefault() >= toStore.Amount)) || !item.CanStore(toStore, storageSlot, agent))
					{
						continue;
					}
					ResourcePileInstance pile = storageSlot.Pile;
					storedAmount = toStore.Count;
					if ((pile == null && !storageSlot.HasReservation()) || (pile != null && pile.HasDisposed))
					{
						if (pile != null && pile.HasDisposed)
						{
							Debug.LogWarning($"FurnitureStorage: Pile warning 01 {blueprint.GetID()}@{GetGridPosition()}");
							storageSlot.SetStoredPile(null);
						}
						storageSlot.Reserve(new StockpileReservationInfo(storedAmount, agent));
						position = base.OwnerBuilding.GetFirstReachablePosition(agent);
						return true;
					}
					int num = (pile?.GetStoredResource()?.Amount).GetValueOrDefault() + toStore.Amount + storageSlot.ReservationInfo.Amount;
					int num2 = (item.UniversalStorageBlueprint.OverrideStackingLimit ? (num - item.UniversalStorageBlueprint.MaxAmount) : (num - toStore.Blueprint.StackingLimit));
					if (num2 > 0)
					{
						storedAmount = new SimpleResourceCount(toStore.Blueprint, toStore.Amount - num2);
					}
					storageSlot.Reserve(new StockpileReservationInfo(storedAmount, agent));
					position = base.OwnerBuilding.GetFirstReachablePosition(agent);
					return true;
				}
			}
			storedAmount = default(SimpleResourceCount);
			position = default(Vec3Int);
			return false;
		}

		public void ReleaseReservations(CreatureBase agent)
		{
			if (AllStorage == null || AllStorage.Count == 0)
			{
				return;
			}
			foreach (UniversalStorage item in AllStorage)
			{
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					if (storageSlot != null && !storageSlot.ReservationInfo.Equals(default(StockpileReservationInfo)) && storageSlot.ReservationInfo.Agent == agent)
					{
						storageSlot.ClearReservations();
					}
				}
			}
		}

		public void SetPriority(ZonePriority priority)
		{
			if (base.HasDisposed || allStorage == null || allStorage.Count < 1)
			{
				return;
			}
			ZonePriority priority2 = allStorage.First().Priority;
			foreach (UniversalStorage item in allStorage)
			{
				item.SetPriority(priority);
			}
			MonoSingleton<StorageCommonManager>.Instance.OnPriorityChanged(this, priority2);
		}

		public bool IsBlueprintAllowed(Resource blueprint)
		{
			for (int i = 0; i < allStorage.Count; i++)
			{
				if (allStorage[i].ResourcesFilter.IsBlueprintAllowed(blueprint))
				{
					return true;
				}
			}
			return false;
		}

		public void AllowResource(Resource resource, bool allowed)
		{
			foreach (UniversalStorage item in allStorage)
			{
				item.AllowResource(resource, allowed);
			}
		}

		public void SetCanBeUsedInProduction(bool allowed)
		{
			canBeUsedInProduction = allowed;
		}

		public void SetHitPointsPercent(IntRange range)
		{
			foreach (UniversalStorage item in allStorage)
			{
				item.ResourcesFilter.SetHitPointsPercent(range);
			}
		}

		public void SetQuality(IntRange range)
		{
			foreach (UniversalStorage item in allStorage)
			{
				item.ResourcesFilter.SetQuality(range);
			}
		}

		public void PileStored()
		{
			FreezePiles(frozen);
		}

		private void OnHourUpdate()
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				return;
			}
			float averageTemperature = base.OwnerBuilding.GetAverageTemperature();
			if (averageTemperature < 0f)
			{
				if (!frozen)
				{
					tempBellowZeroHourCount++;
					if (tempBellowZeroHourCount >= 3)
					{
						frozen = true;
						FreezePiles(frozen);
						this.ShelfFrozenEvent?.Invoke(frozen);
					}
				}
			}
			else if (averageTemperature > 0f && frozen)
			{
				tempBellowZeroHourCount--;
				if (tempBellowZeroHourCount <= 0)
				{
					frozen = false;
					FreezePiles(frozen);
					this.ShelfFrozenEvent?.Invoke(frozen);
				}
			}
		}

		private void FreezePiles(bool frozen)
		{
			foreach (UniversalStorage item in allStorage)
			{
				item.FreezePiles(frozen);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("storageName", storageName);
			serializer.Write("allStorage", allStorage);
			serializer.WriteEnum("shelfOrder", shelfOrder);
			serializer.WriteEnum("lockState", lockState);
			serializer.Write("frozen", frozen);
			serializer.Write("tempBellowZeroHourCount", tempBellowZeroHourCount);
			serializer.Write("canBeUsedInProduction", canBeUsedInProduction);
		}

		public ShelfComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ShelfComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				storageName = deserializer.ReadString("storageName");
				allStorage = deserializer.ReadObjectList<UniversalStorage>("allStorage");
				shelfOrder = (ShelfOrder)deserializer.ReadInt("shelfOrder");
				lockState = (LockState)deserializer.ReadInt("lockState", (int)blueprint.DefaultLockState);
				frozen = deserializer.ReadBool("frozen");
				tempBellowZeroHourCount = deserializer.ReadInt("tempBellowZeroHourCount");
				canBeUsedInProduction = deserializer.ReadBool("canBeUsedInProduction", defaultValue: true);
			}
		}
	}
}
