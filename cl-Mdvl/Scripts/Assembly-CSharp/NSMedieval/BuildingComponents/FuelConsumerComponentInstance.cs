using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("FuelConsumerComponentInstance", "")]
	public class FuelConsumerComponentInstance : BaseComponentInstance
	{
		private const float OffBurnRate = 0f;

		private const float LowBurnRate = 1f;

		private const float MediumBurnRate = 2f;

		private const float HighBurnRate = 4f;

		[NonSerialized]
		private Dictionary<ThermalModelIntensity, float> burnRateDictionary;

		[SerializeField]
		private Storage fuelStorage;

		[SerializeField]
		private float currentCalories;

		[SerializeField]
		private float caloriesSpent;

		[SerializeField]
		private bool turnedOff;

		[SerializeField]
		private TorchState torchState;

		[SerializeField]
		private ResourcesFilter resourcesFilter;

		[SerializeField]
		private ZonePriority refuelPriority;

		[SerializeField]
		private ThermalModelIntensity thermalModelIntensity;

		[NonSerialized]
		private FuelConsumerComponentBlueprint blueprint;

		[NonSerialized]
		private float refillThreshold;

		[NonSerialized]
		private List<ResourceGroups> resourceGroups;

		[NonSerialized]
		private List<string> storableResourceGroups;

		[NonSerialized]
		private HashSet<Resource> defaultStorableResources;

		public FuelConsumerComponentBlueprint Blueprint => blueprint;

		public List<ResourceGroups> ResourceGroups
		{
			get
			{
				if (resourceGroups == null || resourceGroups.Count == 0)
				{
					resourceGroups = new List<ResourceGroups>();
					InitializeStorableGroups(storableResourceGroups);
				}
				return resourceGroups;
			}
		}

		public ResourceCategory FuelType => blueprint.FuelType;

		public Storage FuelStorage => fuelStorage;

		public TorchState TorchState => torchState;

		public ThermalModelIntensity ThermalModelIntensity => thermalModelIntensity;

		public ZonePriority RefuelPriority => refuelPriority;

		public bool TurnedOff => turnedOff;

		public float CurrentCalories => currentCalories;

		public float CaloriesSpent => caloriesSpent;

		public ResourcesFilter ResourcesFilter => resourcesFilter;

		public float BurnRate => blueprint.BurnRate * burnRateDictionary[thermalModelIntensity];

		public event Action FuelAddedEvent;

		public event Action FuelConsumedEvent;

		public event Action AllFuelConsumedEvent;

		public event Action TurnedOnEvent;

		public event Action TurnedOffEvent;

		public FuelConsumerComponentInstance(BaseBuildingInstance ownerBuilding, FuelConsumerComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			fuelStorage = new Storage(new StorageBase(999, ignoreWeigth: true));
			fuelStorage.ResourceAddedEvent += OnResourceAdded;
			refillThreshold = this.blueprint.RequiredCalories / this.blueprint.RefillFactor;
			torchState = TorchState.Burning;
			thermalModelIntensity = ThermalModelIntensity.Off;
			resourcesFilter = new ResourcesFilter();
			resourcesFilter.OnParamsChangedEvent += OnResourceFilterParametersChanged;
			InitAllowedResourcesFromBlueprint();
			burnRateDictionary = new Dictionary<ThermalModelIntensity, float>
			{
				{
					ThermalModelIntensity.Off,
					0f
				},
				{
					ThermalModelIntensity.Low,
					1f
				},
				{
					ThermalModelIntensity.Medium,
					2f
				},
				{
					ThermalModelIntensity.High,
					4f
				}
			};
			thermalModelIntensity = ((this.blueprint.CachedThermalModels.Count <= 1) ? ThermalModelIntensity.Low : this.blueprint.StartingThermalModel);
			TransferToFuelStorage(base.OwnerBuilding.Storage);
			RefreshBaseBuildingThermalModel();
			base.OwnerBuilding.SetProtectingAgainstPredators(IsProtectingAgainstPredators());
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourChange;
			MonoSingleton<FuelDeliveryManager>.Instance.AddToRefuelList(this);
			PasteFuelConsumerSettings();
		}

		public FuelConsumerComponentInstance(BaseBuildingInstance ownerBuilding, FuelConsumerComponentInstance loadFromThis)
			: base(ownerBuilding, loadFromThis.blueprint.GetID(), loadFromThis.blueprint.ComponentType)
		{
			blueprint = loadFromThis.blueprint;
			fuelStorage = new Storage(loadFromThis.fuelStorage);
			fuelStorage.ResourceAddedEvent += OnResourceAdded;
			refillThreshold = blueprint.RequiredCalories / blueprint.RefillFactor;
			torchState = loadFromThis.torchState;
			resourcesFilter = new ResourcesFilter(loadFromThis.ResourcesFilter);
			resourcesFilter.OnParamsChangedEvent += OnResourceFilterParametersChanged;
			InitAllowedResourcesFromBlueprint(afterLoading: true);
			burnRateDictionary = new Dictionary<ThermalModelIntensity, float>
			{
				{
					ThermalModelIntensity.Off,
					0f
				},
				{
					ThermalModelIntensity.Low,
					1f
				},
				{
					ThermalModelIntensity.Medium,
					2f
				},
				{
					ThermalModelIntensity.High,
					4f
				}
			};
			currentCalories = loadFromThis.currentCalories;
			caloriesSpent = loadFromThis.caloriesSpent;
			turnedOff = loadFromThis.turnedOff;
			refuelPriority = loadFromThis.refuelPriority;
			thermalModelIntensity = loadFromThis.thermalModelIntensity;
			RefreshBaseBuildingThermalModel();
			base.OwnerBuilding.SetProtectingAgainstPredators(IsProtectingAgainstPredators());
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourChange;
			MonoSingleton<FuelDeliveryManager>.Instance.AddToRefuelList(this);
			PasteFuelConsumerSettings();
		}

		public FuelConsumerComponentInstance CloneIncognito(FuelConsumerComponentInstance original)
		{
			FuelConsumerComponentInstance obj = new FuelConsumerComponentInstance(original.Blueprint)
			{
				fuelStorage = new Storage(original.fuelStorage),
				refillThreshold = original.refillThreshold,
				torchState = original.torchState,
				thermalModelIntensity = original.thermalModelIntensity,
				resourcesFilter = new ResourcesFilter(original.resourcesFilter)
			};
			burnRateDictionary = new Dictionary<ThermalModelIntensity, float>
			{
				{
					ThermalModelIntensity.Off,
					0f
				},
				{
					ThermalModelIntensity.Low,
					1f
				},
				{
					ThermalModelIntensity.Medium,
					2f
				},
				{
					ThermalModelIntensity.High,
					4f
				}
			};
			obj.currentCalories = original.currentCalories;
			obj.caloriesSpent = original.caloriesSpent;
			obj.turnedOff = original.turnedOff;
			obj.refuelPriority = original.refuelPriority;
			InitAllowedResourcesFromBlueprint(afterLoading: true);
			return obj;
		}

		private FuelConsumerComponentInstance(FuelConsumerComponentBlueprint blueprint)
			: base(blueprint.GetID())
		{
			this.blueprint = blueprint;
		}

		public FuelConsumerComponentInstance(FuelConsumerComponentBlueprint blueprint, int uniqueId)
			: base(blueprint.GetID(), uniqueId)
		{
			this.blueprint = blueprint;
			fuelStorage = new Storage(new StorageBase(999, ignoreWeigth: true));
			torchState = TorchState.Burning;
			thermalModelIntensity = ThermalModelIntensity.Off;
			resourcesFilter = new ResourcesFilter();
			thermalModelIntensity = ((this.blueprint.CachedThermalModels.Count <= 1) ? ThermalModelIntensity.Low : this.blueprint.StartingThermalModel);
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnLoaded;
			void OnLoaded()
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnLoaded;
				MigrateAddMaxFuel();
				InitAllowedResourcesFromBlueprint();
				Log.Debug("Successfully migrated FuelConsumerComponentInstance.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerComponentInstance.cs");
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			fuelStorage.ResourceAddedEvent += OnResourceAdded;
			if (blueprint == null)
			{
				blueprint = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.FuelConsumerComponentID);
				SetComponentBlueprintID(base.OwnerBuilding.Blueprint.FuelConsumerComponentID);
			}
			refillThreshold = blueprint.RequiredCalories / blueprint.RefillFactor;
			ScaleCalories();
			RecalculateCaloriesAndDeleteExcessResourcesFromStorage();
			InitAllowedResourcesFromBlueprint(afterLoading: true);
			burnRateDictionary = new Dictionary<ThermalModelIntensity, float>
			{
				{
					ThermalModelIntensity.Off,
					0f
				},
				{
					ThermalModelIntensity.Low,
					1f
				},
				{
					ThermalModelIntensity.Medium,
					2f
				},
				{
					ThermalModelIntensity.High,
					4f
				}
			};
			if (thermalModelIntensity == ThermalModelIntensity.Off)
			{
				thermalModelIntensity = ThermalModelIntensity.Low;
			}
			RefreshBaseBuildingThermalModel();
			base.OwnerBuilding.SetProtectingAgainstPredators(IsProtectingAgainstPredators());
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourChange;
			MonoSingleton<FuelDeliveryManager>.Instance.AddToRefuelList(this);
			if (turnedOff)
			{
				if (torchState == TorchState.Off)
				{
					torchState = TorchState.Off;
				}
				else
				{
					torchState = (CanBurn() ? TorchState.Burning : TorchState.FuelMissing);
				}
			}
			else if (torchState == TorchState.Off)
			{
				torchState = TorchState.Off;
			}
			else
			{
				torchState = (CanBurn() ? TorchState.Burning : TorchState.FuelMissing);
			}
		}

		public void AllowFuel(Resource resource, bool allowed)
		{
			AllowResource(resource, allowed);
		}

		public void AllowResource(Resource resource, bool allowed)
		{
			if (allowed)
			{
				resourcesFilter.AddAllowedResource(resource);
			}
			else
			{
				resourcesFilter.RemoveAllowedResource(resource);
			}
		}

		public int GetMaxCaloriesToStore()
		{
			return (int)(blueprint.RequiredCalories - currentCalories);
		}

		public bool CanStoreFuel(Resource blueprint)
		{
			if (blueprint != null)
			{
				return resourcesFilter.IsBlueprintAllowed(blueprint);
			}
			return false;
		}

		public bool ShouldRefuel()
		{
			return currentCalories < refillThreshold;
		}

		public void SetBurnIntensity(ThermalModelIntensity thermalModelIntensity)
		{
			this.thermalModelIntensity = thermalModelIntensity;
			RefreshBaseBuildingThermalModel();
		}

		private void TransferToFuelStorage(Storage sourceStorage)
		{
			ResourceCategory fuelType = blueprint.FuelType;
			float maxCalories = blueprint.RequiredCalories;
			if (sourceStorage != null)
			{
				foreach (ResourceInstance resource in sourceStorage.Resources)
				{
					if (resource.Blueprint.Category.HasFlag(fuelType))
					{
						float caloriesCount = resource.Blueprint.CaloriesCount;
						int amount = (int)(maxCalories / caloriesCount);
						fuelStorage.Add(sourceStorage.Take(resource.Blueprint, amount));
						break;
					}
				}
			}
			if (fuelStorage.IsEmpty())
			{
				if (blueprint.FuelType.HasFlag(ResourceCategory.CtgCandleFuel))
				{
					AddDummyFuel("tallow");
				}
				else if (blueprint.FuelType.HasFlag(ResourceCategory.CtgFuel))
				{
					AddDummyFuel("wood");
				}
			}
			void AddDummyFuel(string resourceId)
			{
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(resourceId);
				if (!(byID == null))
				{
					float caloriesCount2 = byID.CaloriesCount;
					int amount2 = (int)(maxCalories / caloriesCount2);
					ResourceInstance resourceToAdd = new ResourceInstance(byID, amount2);
					fuelStorage.Add(resourceToAdd);
				}
			}
		}

		public void SetRefuelPriority(ZonePriority refuelPriority)
		{
			this.refuelPriority = refuelPriority;
		}

		public void PasteFuelConsumerSettings(FuelConsumerCopySettingsData fuelConsumerCopySettingsData)
		{
			if (fuelConsumerCopySettingsData == null)
			{
				return;
			}
			resourcesFilter.SetAllowedResourceTypes(new HashSet<Resource>());
			foreach (Resource allowedResourceType in fuelConsumerCopySettingsData.ResourcesFilter.AllowedResourceTypes)
			{
				AllowResource(allowedResourceType, allowed: true);
			}
			SetRefuelPriority(fuelConsumerCopySettingsData.RefuelPriority);
			torchState = fuelConsumerCopySettingsData.TorchState;
			turnedOff = fuelConsumerCopySettingsData.TurnedOff;
			thermalModelIntensity = fuelConsumerCopySettingsData.ThermalModelIntensity;
		}

		private void PasteFuelConsumerSettings()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			FuelConsumerCopySettingsData fuelConsumerCopySettingsData = currentVillageData?.FuelConsumerCopySettingsData.FirstOrDefault((FuelConsumerCopySettingsData x) => x.TargetBuilding == base.OwnerBuilding);
			if (fuelConsumerCopySettingsData == null)
			{
				return;
			}
			currentVillageData.DeleteFuelConsumerCopyData(fuelConsumerCopySettingsData);
			resourcesFilter.SetAllowedResourceTypes(new HashSet<Resource>());
			foreach (Resource allowedResourceType in fuelConsumerCopySettingsData.ResourcesFilter.AllowedResourceTypes)
			{
				AllowResource(allowedResourceType, allowed: true);
			}
			SetRefuelPriority(fuelConsumerCopySettingsData.RefuelPriority);
			torchState = fuelConsumerCopySettingsData.TorchState;
			turnedOff = fuelConsumerCopySettingsData.TurnedOff;
			thermalModelIntensity = fuelConsumerCopySettingsData.ThermalModelIntensity;
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = ((base.BaseBuildingBlueprint.PlacementType != PlacementType.WallSocket) ? (waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High) : (waterDepthLevel == WaterDepthLevel.High));
			base.OwnerBuilding.SetUnderWater(underWater);
		}

		public FuelConsumerCopySettingsData GetCopyData(BaseBuildingInstance newBuilding)
		{
			return new FuelConsumerCopySettingsData(ResourcesFilter.DeepCopy(), RefuelPriority, TorchState, TurnedOff, ThermalModelIntensity, newBuilding);
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				fuelStorage?.Dispose();
				this.FuelAddedEvent = null;
				this.FuelConsumedEvent = null;
				this.AllFuelConsumedEvent = null;
				this.TurnedOnEvent = null;
				this.TurnedOffEvent = null;
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourChange;
				MonoSingleton<FuelDeliveryManager>.Instance.RemoveFromRefuelList(this);
				base.Map?.FuelConsumerComponentManager.RemoveFromCache(this);
				base.Dispose();
				burnRateDictionary?.Clear();
				burnRateDictionary = null;
				fuelStorage = null;
				resourcesFilter = null;
				blueprint = null;
				resourceGroups?.Clear();
				resourceGroups = null;
				storableResourceGroups?.Clear();
				storableResourceGroups = null;
				defaultStorableResources?.Clear();
				defaultStorableResources = null;
			}
		}

		private float GetCaloriesCount()
		{
			float num = 0f;
			foreach (ResourceInstance resource in fuelStorage.Resources)
			{
				num += (float)resource.Amount * resource.Blueprint.CaloriesCount;
			}
			return num;
		}

		public bool CanBurn()
		{
			return currentCalories > blueprint.BurnRate;
		}

		private void OnResourceAdded(SimpleResourceCount count)
		{
			currentCalories = Mathf.Clamp(currentCalories + (float)count.Amount * count.Blueprint.CaloriesCount, 0f, blueprint.RequiredCalories);
			TurnOn();
			this.FuelAddedEvent?.Invoke();
		}

		private ThermalModel GetCurrentThermalModel()
		{
			Blueprint.CachedThermalModels.TryGetValue(ThermalModelIntensity, out var value);
			if (torchState != TorchState.Burning)
			{
				return base.OwnerBuilding.Blueprint.DefaultThermalModel;
			}
			return value;
		}

		public void TurnOn()
		{
			if (!base.Underwater)
			{
				torchState = (CanBurn() ? TorchState.Burning : TorchState.FuelMissing);
				RefreshBaseBuildingThermalModel();
				GetNode().ForceRefreshWithNeighbours();
				MonoSingleton<ConstructionController>.Instance.FuelConsumerStateChanged(this);
				this.TurnedOnEvent?.Invoke();
			}
		}

		private void RefreshBaseBuildingThermalModel()
		{
			base.OwnerBuilding.OverrideThermalModel(GetCurrentThermalModel());
			base.OwnerBuilding.ForceRefreshTemperatureInput();
		}

		public void TurnOff()
		{
			torchState = TorchState.Off;
			base.OwnerBuilding.SetProtectingAgainstPredators(protectingAgainstPredators: false);
			RefreshBaseBuildingThermalModel();
			GetNode().ForceRefreshWithNeighbours();
			MonoSingleton<ConstructionController>.Instance.FuelConsumerStateChanged(this);
			this.TurnedOffEvent?.Invoke();
		}

		private void OnHourChange()
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed || torchState == TorchState.Off || fuelStorage.ResourceCount == 0)
			{
				return;
			}
			Resource resource = fuelStorage.Resources.FirstOrDefault((ResourceInstance x) => x.Amount > 0)?.Blueprint;
			if (resource == null)
			{
				return;
			}
			caloriesSpent += BurnRate;
			if (caloriesSpent >= resource.CaloriesCount)
			{
				caloriesSpent = 0f;
				fuelStorage.Consume(resource, 1);
				if (!fuelStorage.Resources.Any((ResourceInstance x) => x.Amount > 0))
				{
					currentCalories = 0f;
				}
			}
			currentCalories = Mathf.Clamp(currentCalories - BurnRate, 0f, currentCalories);
			if (currentCalories <= 0f)
			{
				currentCalories = 0f;
				this.AllFuelConsumedEvent?.Invoke();
				torchState = TorchState.FuelMissing;
				RefreshBaseBuildingThermalModel();
			}
			this.FuelConsumedEvent?.Invoke();
		}

		private void ScaleCalories()
		{
			if (fuelStorage.ResourceCount == 0)
			{
				return;
			}
			float num = 0f;
			using PooledList<ResourceInstance> pooledList = fuelStorage.Resources.ToPooledListJanitor();
			foreach (ResourceInstance item in pooledList)
			{
				num += (float)item.Amount * item.Blueprint.CaloriesCount;
			}
			if (!(currentCalories > num))
			{
				return;
			}
			foreach (ResourceInstance item2 in pooledList)
			{
				if (item2 != null)
				{
					fuelStorage.ClearResources();
					int num2 = (int)Math.Ceiling(currentCalories / item2.Blueprint.CaloriesCount);
					item2.Add(item2, Mathf.Abs(num2 - item2.Amount));
					currentCalories = 0f;
					caloriesSpent = 0f;
					fuelStorage.Add(item2);
					break;
				}
			}
		}

		private void RecalculateCaloriesAndDeleteExcessResourcesFromStorage()
		{
			float num = 0f;
			using PooledList<ResourceInstance> pooledList = fuelStorage.Resources.ToPooledListJanitor();
			foreach (ResourceInstance item in pooledList)
			{
				if (num == 0f)
				{
					float num2 = (float)item.Amount * item.Blueprint.CaloriesCount;
					if (num2 > blueprint.RequiredCalories)
					{
						int num3 = (int)(blueprint.RequiredCalories / item.Blueprint.CaloriesCount);
						int amount = item.Amount - num3;
						fuelStorage.Consume(item.Blueprint, amount);
						num2 = blueprint.RequiredCalories;
					}
					num += num2;
					continue;
				}
				float num4 = blueprint.RequiredCalories - num;
				float num5 = (float)item.Amount * item.Blueprint.CaloriesCount;
				if (num5 > num4)
				{
					int num6 = (int)(num4 / item.Blueprint.CaloriesCount);
					int amount2 = item.Amount - num6;
					fuelStorage.Consume(item.Blueprint, amount2);
					num5 = num4;
				}
				num += num5;
			}
			currentCalories = num;
		}

		private void OnResourceFilterParametersChanged()
		{
		}

		private void InitAllowedResourcesFromBlueprint(bool afterLoading = false)
		{
			Stockpile byID = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile");
			if (byID == null)
			{
				return;
			}
			if (storableResourceGroups == null)
			{
				storableResourceGroups = new List<string>();
			}
			if (defaultStorableResources == null)
			{
				defaultStorableResources = new HashSet<Resource>();
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!(allItem == null) && byID.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup) && allItem.Category.HasFlag(FuelType))
				{
					if (!afterLoading)
					{
						resourcesFilter.AddAllowedResource(allItem);
					}
					resourcesFilter.CacheDefaultAllowedResources(allItem);
					defaultStorableResources.Add(allItem);
					if (!storableResourceGroups.Contains(allItem.SortingGroup))
					{
						storableResourceGroups.Add(allItem.SortingGroup);
					}
				}
			}
		}

		private void InitializeStorableGroups(List<string> storableGroups)
		{
			foreach (string storableGroup in storableGroups)
			{
				ResourceGroups actualResourceGroup = GetActualResourceGroup(storableGroup);
				if (!(actualResourceGroup == null) && !resourceGroups.Contains(actualResourceGroup))
				{
					resourceGroups.Add(GetActualResourceGroup(storableGroup));
					AddParentsToList(storableGroup);
				}
			}
		}

		private void AddParentsToList(string childNode)
		{
			foreach (ResourceGroups resourceGroup in Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups)
			{
				foreach (string subGroupID in resourceGroup.SubGroupIDs)
				{
					if (subGroupID == childNode && !resourceGroups.Contains(resourceGroup) && !storableResourceGroups.Contains(resourceGroup.GetID()))
					{
						resourceGroups.Add(resourceGroup);
						AddParentsToList(resourceGroup.GetID());
					}
				}
			}
		}

		private ResourceGroups GetActualResourceGroup(string id)
		{
			ResourceGroups resourceGroups = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == id);
			if (resourceGroups != null)
			{
				if (resourceGroups.SubGroupIDs.Count <= 0)
				{
					return resourceGroups;
				}
				InitializeStorableGroups(resourceGroups.SubGroupIDs);
			}
			return null;
		}

		public bool AvailableResourcesExist(IPathfindingAgent agent)
		{
			if (GetMaxCaloriesToStore() <= 0)
			{
				return false;
			}
			foreach (Resource allowedResourceType in resourcesFilter.AllowedResourceTypes)
			{
				bool isPileValid = false;
				MonoSingleton<ResourcePileManager>.Instance.BlueprintInstancesSafeOperation(allowedResourceType, delegate(IEnumerable<ResourcePileInstance> allPilesByBlueprint)
				{
					foreach (ResourcePileInstance item in allPilesByBlueprint)
					{
						if (!item.IsForbidden && PathfinderUtil.IsPathPossible(agent, base.OwnerBuilding.ReachablePositions))
						{
							isPileValid = true;
							break;
						}
					}
				});
				if (isPileValid)
				{
					return true;
				}
			}
			return false;
		}

		public void DebugSetLowFuel()
		{
			ResourceInstance resourceInstance = null;
			using PooledList<ResourceInstance> pooledList = fuelStorage.Resources.ToPooledListJanitor();
			foreach (ResourceInstance item in pooledList)
			{
				if (resourceInstance == null && item.Amount > 0)
				{
					resourceInstance = item;
				}
				else
				{
					fuelStorage.Consume(item.Blueprint, item.Amount);
				}
			}
			if (resourceInstance != null)
			{
				fuelStorage.Consume(resourceInstance.Blueprint, resourceInstance.Amount - 1);
				currentCalories = Mathf.Clamp((float)resourceInstance.Amount * resourceInstance.Blueprint.CaloriesCount, 0f, blueprint.RequiredCalories);
				caloriesSpent = resourceInstance.Blueprint.CaloriesCount - BurnRate;
				RefreshBaseBuildingThermalModel();
				this.FuelConsumedEvent?.Invoke();
			}
		}

		public bool IsProtectingAgainstPredators()
		{
			return torchState == TorchState.Burning;
		}

		private void MigrateAddMaxFuel()
		{
			ResourceCategory fuelType = Blueprint.FuelType;
			Resource first = Repository<ResourceRepository, Resource>.Instance.GetFirst((Resource x) => x.Category.HasFlag(fuelType));
			int amount = GetPickupAmountFromCalories(new SimpleResourceCount(first, GetMaxCaloriesToStore()));
			ResourceInstance resourceToAdd = new ResourceInstance(first, amount);
			fuelStorage.Add(resourceToAdd);
			static int GetPickupAmountFromCalories(SimpleResourceCount resourceCount)
			{
				int amount2 = resourceCount.Amount;
				float caloriesCount = resourceCount.Blueprint.CaloriesCount;
				return (int)((float)amount2 / caloriesCount + 0.5f);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("fuelStorage", fuelStorage);
			serializer.Write("currentCalories", currentCalories);
			serializer.Write("caloriesSpent", caloriesSpent);
			serializer.Write("turnedOff", turnedOff);
			serializer.Write("resourcesFilter", resourcesFilter);
			serializer.WriteEnum("torchState", torchState);
			serializer.WriteEnum("refuelPriority", refuelPriority);
			serializer.WriteEnum("thermalModelIntensity", thermalModelIntensity);
		}

		public FuelConsumerComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(69, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in FuelConsumerComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				fuelStorage = deserializer.ReadObject<Storage>("fuelStorage");
				currentCalories = deserializer.ReadFloat("currentCalories");
				caloriesSpent = deserializer.ReadFloat("caloriesSpent");
				turnedOff = deserializer.ReadBool("turnedOff");
				resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
				torchState = deserializer.ReadEnum("torchState", TorchState.Off);
				refuelPriority = deserializer.ReadEnum("refuelPriority", ZonePriority.None);
				thermalModelIntensity = deserializer.ReadEnum("thermalModelIntensity", ThermalModelIntensity.Off);
			}
		}
	}
}
