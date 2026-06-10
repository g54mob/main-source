using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.TaskManager;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepCollect", "")]
	public class ProductionStepCollect : ProductionStepInstance
	{
		private class UpdateHasResourcesAvailableThreadTask
		{
			public BaseBuildingInstance OwnerBuilding;

			public List<ResourceSearchFilter> MissingResources;

			public Resource WaterBucket;

			public ResourcesFilter ResourceFilter;

			public bool OutResourcesAllowedAvailable;

			private NSMedieval.Model.Production blueprint;

			public UpdateHasResourcesAvailableThreadTask()
			{
				MissingResources = ListPool<ResourceSearchFilter>.Get();
			}

			public void Schedule(ProductionStepCollect instance, ThreadingJobSystem.DoneCallback doneCallback)
			{
				OwnerBuilding = instance.OwnerProductionInstance?.OwnerProductionComponentInstance?.OwnerBuilding;
				MissingResources.Clear();
				MissingResources.AddRange(instance.MissingResources);
				WaterBucket = instance.waterBucket;
				ResourceFilter = instance.OwnerProductionInstance?.ResourceFilter;
				blueprint = instance.OwnerProductionInstance?.Blueprint;
				OutResourcesAllowedAvailable = instance.ResourcesAllowedAvailable;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(OnThread, doneCallback);
			}

			public void Dispose()
			{
				ListPool<ResourceSearchFilter>.Return(MissingResources);
			}

			private bool OnThread()
			{
				if (!MonoSingleton<World>.IsInstantiated() || !MonoSingleton<TaskController>.IsInstantiated() || MonoSingleton<LoadingController>.IsApplicationIsQuitting())
				{
					return false;
				}
				IStorageAgent storageAgent = MonoSingleton<ReservationManager>.Instance.GetSingleReserver(OwnerBuilding) as IStorageAgent;
				foreach (ResourceSearchFilter missingResource in MissingResources)
				{
					if (!MonoSingleton<ResourcePileTracker>.Instance.SearchForFilterHits(missingResource) && !HasWaterOnMapInternal(missingResource, OwnerBuilding, WaterBucket) && (storageAgent == null || ((IReservable)storageAgent).HasDisposed || storageAgent.Storage.GetByFilter(missingResource, ignoreCount: true) == null))
					{
						OutResourcesAllowedAvailable = false;
						return true;
					}
				}
				using PooledList<ResourceSearchFilter> pooledList = MissingResources.ToPooledListJanitor();
				PooledList<int> janitor = ListPool<int>.GetJanitor();
				try
				{
					for (int i = 0; i < pooledList.Count; i++)
					{
						ResourceInstance resourceInstance = storageAgent?.Storage.GetByFilter(pooledList[i], ignoreCount: true);
						if (resourceInstance != null && ResourceFilter.IsValid(resourceInstance))
						{
							if (resourceInstance.Amount >= pooledList[i].Count)
							{
								pooledList.RemoveAt(i);
								i--;
							}
							else
							{
								janitor.Add(resourceInstance.Amount);
							}
						}
						else
						{
							janitor.Add(0);
						}
					}
					OutResourcesAllowedAvailable = pooledList.Count == 0;
					if (OutResourcesAllowedAvailable)
					{
						return true;
					}
					using PooledList<ResourcePileInstance> pooledList2 = MonoSingleton<ResourcePileTracker>.Instance.AllAllowed.ToPooledListJanitor();
					using PooledDictionary<ResourcePileInstance, int> pooledDictionary = DictionaryPool<ResourcePileInstance, int>.GetJanitor();
					foreach (ResourcePileInstance item in pooledList2)
					{
						if ((item.InstanceStockpile != null && !item.InstanceStockpile.CanBeUsedInProduction) || (item.InstanceStorage != null && !item.InstanceStorage.GetOwner.CanBeUsedInProduction))
						{
							continue;
						}
						ResourceInstance storedResource = item.GetStoredResource();
						if (!ResourceFilter.IsValid(storedResource))
						{
							continue;
						}
						int num = pooledList.FindIndex((ResourceSearchFilter item) => item.Check(storedResource, ignoreCount: true));
						if (num >= 0)
						{
							ResourceSearchFilter resourceSearchFilter = pooledList[num];
							int num2 = resourceSearchFilter.Count - janitor[num];
							if (num2 >= storedResource.Amount)
							{
								janitor[num] += storedResource.Amount;
								pooledDictionary.Add(item, storedResource.Amount);
							}
							else
							{
								janitor[num] += num2;
								pooledDictionary.Add(item, num2);
							}
							if (janitor[num] >= resourceSearchFilter.Count)
							{
								pooledList.RemoveAt(num);
								janitor.RemoveAt(num);
							}
							if (pooledList.Count == 0)
							{
								break;
							}
						}
					}
					bool flag = blueprint?.UseIngredientCombo ?? false;
					if (pooledList.Count > 0 && flag)
					{
						foreach (ResourcePileInstance item2 in pooledList2)
						{
							if ((item2.InstanceStockpile != null && !item2.InstanceStockpile.CanBeUsedInProduction) || (item2.InstanceStorage != null && !item2.InstanceStorage.GetOwner.CanBeUsedInProduction))
							{
								continue;
							}
							ResourceInstance storedResource2 = item2.GetStoredResource();
							if (!ResourceFilter.IsValid(storedResource2))
							{
								continue;
							}
							int num3 = storedResource2.Amount;
							if (pooledDictionary.TryGetValue(item2, out var value))
							{
								if (value == storedResource2.Amount)
								{
									continue;
								}
								num3 = storedResource2.Amount - value;
							}
							int num4 = pooledList.FindIndex((ResourceSearchFilter item) => item.Check(storedResource2, ignoreCount: true));
							if (num4 >= 0)
							{
								ResourceSearchFilter resourceSearchFilter2 = pooledList[num4];
								janitor[num4] += num3;
								if (janitor[num4] >= resourceSearchFilter2.Count)
								{
									pooledList.RemoveAt(num4);
									janitor.RemoveAt(num4);
								}
								if (pooledList.Count == 0)
								{
									break;
								}
							}
						}
					}
					OutResourcesAllowedAvailable = pooledList.Count == 0;
					if (!OutResourcesAllowedAvailable && MissingResources.Any((ResourceSearchFilter filter) => HasWaterOnMapInternal(filter, OwnerBuilding, WaterBucket)))
					{
						OutResourcesAllowedAvailable = true;
					}
					return true;
				}
				finally
				{
					((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}

		[NonSerialized]
		private List<ResourceSearchFilter> missingResources;

		[NonSerialized]
		private Task updateResourcesAvailableTask;

		[NonSerialized]
		private Task refreshMissingResourcesTask;

		[NonSerialized]
		private float startTime;

		[NonSerialized]
		private Resource waterBucket;

		[NonSerialized]
		private readonly UpdateHasResourcesAvailableThreadTask updateHasResourcesAvailableThreadTask = new UpdateHasResourcesAvailableThreadTask();

		private bool isResourcesAvailableThreadTaskRunning;

		private bool isResourcesAvailableUpdateRequested;

		private Dictionary<string, bool> resourcesDelivered = new Dictionary<string, bool>();

		public List<ResourceSearchFilter> MissingResources => missingResources;

		public bool ResourcesAllowedAvailable { get; private set; }

		public override float Progress
		{
			get
			{
				int valueOrDefault = (base.OwnerProductionInstance?.Storage?.GetTotalStoredCount()).GetValueOrDefault();
				int valueOrDefault2 = (base.OwnerProductionInstance?.SecondaryIngredientStorage?.GetTotalStoredCount()).GetValueOrDefault();
				int num = valueOrDefault + valueOrDefault2;
				int num2 = base.OwnerProductionInstance?.Blueprint?.GetRecipeTotalResourceCount() ?? 1;
				if (num != num2)
				{
					return (float)num / (float)num2;
				}
				return 1f;
			}
		}

		public ProductionStepCollect()
			: base(ProductionStepType.Collect)
		{
			waterBucket = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
		}

		internal override void Initialize(ProductionInstance owner, ProductionStep blueprint)
		{
			base.Initialize(owner, blueprint);
			base.OwnerProductionInstance.Storage.ResourceAddedEvent += OnStorageChanged;
			base.OwnerProductionInstance.Storage.ResourceTakenEvent += OnStorageChanged;
			base.OwnerProductionInstance.Storage.ResourceDeletedEvent += ResourceDeletedEvent;
			base.OwnerProductionInstance.ResourceFilter.OnParamsChangedEvent += ResourceFilterChanged;
			base.OwnerProductionInstance.SecondaryIngredientStorage.ResourceAddedEvent += OnSecondaryResourceAdded;
			refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
		}

		private void OnSecondaryResourceAdded(SimpleResourceCount simpleResourceCount)
		{
			refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
		}

		public override void Dispose()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.RefreshUsableWellsEvent -= OnRefreshUsableWells;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnPileCountChanged;
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnPileSpawned;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			if (base.OwnerProductionInstance != null)
			{
				base.OwnerProductionInstance.ResourceFilter.OnParamsChangedEvent -= ResourceFilterChanged;
				if (base.OwnerProductionInstance.Storage != null)
				{
					base.OwnerProductionInstance.Storage.ResourceAddedEvent -= OnStorageChanged;
					base.OwnerProductionInstance.Storage.ResourceTakenEvent -= OnStorageChanged;
					base.OwnerProductionInstance.Storage.ResourceDeletedEvent -= ResourceDeletedEvent;
				}
				if (base.OwnerProductionInstance.SecondaryIngredientStorage != null)
				{
					base.OwnerProductionInstance.SecondaryIngredientStorage.ResourceAddedEvent -= OnSecondaryResourceAdded;
				}
			}
			updateResourcesAvailableTask?.Stop();
			updateResourcesAvailableTask = null;
			updateHasResourcesAvailableThreadTask.Dispose();
			base.Dispose();
		}

		internal override void OnStart()
		{
			RefreshMissingResources();
			UpdateHasResourcesAvailable();
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent += OnPileCountChanged;
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnPileSpawned;
			MonoSingleton<ConstructionController>.Instance.RefreshUsableWellsEvent += OnRefreshUsableWells;
			startTime = TimerController.TimeSinceStartup;
			base.OnStart();
		}

		internal override void OnEnd()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnPileCountChanged;
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnPileSpawned;
			MonoSingleton<ConstructionController>.Instance.RefreshUsableWellsEvent -= OnRefreshUsableWells;
			base.OnEnd();
		}

		internal override void OnBecomeActive()
		{
			if (TimerController.TimeSinceStartup - startTime > 0.1f)
			{
				refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
			}
			base.OnBecomeActive();
		}

		internal override void Reset()
		{
			missingResources = null;
			ResourcesAllowedAvailable = false;
			refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
			base.Reset();
		}

		private void RefreshMissingResources()
		{
			if (missingResources == null)
			{
				missingResources = new List<ResourceSearchFilter>();
			}
			if (refreshMissingResourcesTask != null)
			{
				refreshMissingResourcesTask.Stop();
				refreshMissingResourcesTask = null;
			}
			missingResources.Clear();
			if (base.OwnerProductionInstance.Blueprint.IsDismantle())
			{
				ItemMaterialCategory category = base.OwnerProductionInstance.Blueprint.ItemMaterialCategory;
				IEnumerable<ResourceInstance> resources = base.OwnerProductionInstance.Storage.Resources;
				if (resources != null && resources.Any((ResourceInstance item) => item.Blueprint.ItemMaterialCategory == category))
				{
					Complete();
					return;
				}
				missingResources.Add(new ResourceSearchFilter
				{
					ItemMaterialCategory = category,
					AllowedOnly = true
				});
				updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, 1.5f);
				return;
			}
			bool isEnabled;
			foreach (KeyIntPair item in base.OwnerProductionInstance.Blueprint.Recipe)
			{
				string iD = item.GetID();
				int result;
				int num = ((!int.TryParse(iD, out result)) ? (base.OwnerProductionInstance.Storage.GetById(iD)?.Amount ?? 0) : base.OwnerProductionInstance.Storage.GetTotalStoredCount((ResourceCategory)result));
				int num2 = item.Value - num;
				if (num2 < 0)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(76, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Production '");
						messageBuilder.AppendFormatted(base.OwnerProductionInstance.BlueprintId);
						messageBuilder.AppendLiteral("' needed count < 0 (");
						messageBuilder.AppendFormatted(iD);
						messageBuilder.AppendLiteral(":");
						messageBuilder.AppendFormatted(num2);
						messageBuilder.AppendLiteral(") pos: ");
						messageBuilder.AppendFormatted(base.OwnerProductionInstance.OwnerProductionComponentInstance.GetGridPosition());
						messageBuilder.AppendLiteral(". Spawning excess resources as pile.");
					}
					Log.Warning(messageBuilder);
					int num3 = num - item.Value;
					ResourceInstance singleResource = base.OwnerProductionInstance.Storage.GetSingleResource();
					singleResource.Sub(num3);
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(singleResource.Clone(num3), base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
				}
				if (num2 <= 0)
				{
					resourcesDelivered.TryAdd(item.GetID(), value: true);
					continue;
				}
				missingResources.Add(new ResourceSearchFilter
				{
					BlueprintOrCategoryId = iD,
					AllowedOnly = true,
					Count = num2
				});
			}
			foreach (KeyIntPair item2 in base.OwnerProductionInstance.Blueprint.SecondaryRecipe)
			{
				string iD2 = item2.GetID();
				int result2;
				int num4 = ((!int.TryParse(iD2, out result2)) ? (base.OwnerProductionInstance.SecondaryIngredientStorage.GetById(iD2)?.Amount ?? 0) : base.OwnerProductionInstance.SecondaryIngredientStorage.GetTotalStoredCount((ResourceCategory)result2));
				int num5 = item2.Value - num4;
				if (num5 < 0)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(76, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Production '");
						messageBuilder.AppendFormatted(base.OwnerProductionInstance.BlueprintId);
						messageBuilder.AppendLiteral("' needed count < 0 (");
						messageBuilder.AppendFormatted(iD2);
						messageBuilder.AppendLiteral(":");
						messageBuilder.AppendFormatted(num5);
						messageBuilder.AppendLiteral(") pos: ");
						messageBuilder.AppendFormatted(base.OwnerProductionInstance.OwnerProductionComponentInstance.GetGridPosition());
						messageBuilder.AppendLiteral(". Spawning excess resources as pile.");
					}
					Log.Warning(messageBuilder);
					int num6 = num4 - item2.Value;
					ResourceInstance singleResource2 = base.OwnerProductionInstance.SecondaryIngredientStorage.GetSingleResource();
					singleResource2.Sub(num6);
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(singleResource2.Clone(num6), base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
				}
				if (num5 <= 0)
				{
					resourcesDelivered.TryAdd(item2.GetID(), value: true);
					continue;
				}
				missingResources.Add(new ResourceSearchFilter
				{
					BlueprintOrCategoryId = iD2,
					AllowedOnly = true,
					Count = num5
				});
			}
			if (missingResources.Count == 0)
			{
				Complete();
				return;
			}
			ProductionComponent productionComponent = GetProductionComponent();
			if (productionComponent != null)
			{
				productionComponent.UpdateProductionCircle();
			}
			updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, 1.5f);
		}

		public bool HasWaterOnMap(ResourceSearchFilter filter)
		{
			return HasWaterOnMapInternal(filter, base.OwnerProductionInstance?.OwnerProductionComponentInstance?.OwnerBuilding, waterBucket);
		}

		private static bool HasWaterOnMapInternal(ResourceSearchFilter filter, BaseBuildingInstance ownerBuilding, Resource waterBucket)
		{
			if (filter == null || (filter.BlueprintOrCategoryId != waterBucket.GetID() && filter.Blueprint != waterBucket))
			{
				return false;
			}
			WellComponentManager wellComponentManager = ownerBuilding?.Map?.WellComponentManager;
			if (wellComponentManager != null && wellComponentManager.GetOperationalCount() > 0)
			{
				return true;
			}
			WaterSimLogic waterSimLogic = ownerBuilding?.Map?.WaterManager?.WaterSimLogic;
			if (waterSimLogic != null && waterSimLogic.IsWaterOnMap)
			{
				return true;
			}
			return false;
		}

		private void OnUpdateHasResourcesAvailableThreadTaskDone(bool result)
		{
			isResourcesAvailableThreadTaskRunning = false;
			if (result)
			{
				ResourcesAllowedAvailable = updateHasResourcesAvailableThreadTask.OutResourcesAllowedAvailable;
				base.OwnerProductionInstance.UpdateState();
			}
			if (isResourcesAvailableUpdateRequested)
			{
				isResourcesAvailableThreadTaskRunning = true;
				isResourcesAvailableUpdateRequested = false;
				updateHasResourcesAvailableThreadTask.Schedule(this, OnUpdateHasResourcesAvailableThreadTaskDone);
			}
		}

		private void UpdateHasResourcesAvailable()
		{
			if (!MonoSingleton<World>.IsInstantiated() || !MonoSingleton<TaskController>.IsInstantiated() || MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			if (MonoSingleton<World>.Instance.IsLoaded)
			{
				UpdateHasResourcesAvailableInternal();
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitUntil((float _) => MonoSingleton<World>.Instance.IsLoaded).Then(UpdateHasResourcesAvailableInternal);
			void UpdateHasResourcesAvailableInternal()
			{
				BaseBuildingInstance baseBuildingInstance = base.OwnerProductionInstance?.OwnerProductionComponentInstance?.OwnerBuilding;
				if (baseBuildingInstance != null && !baseBuildingInstance.HasDisposed && !LoadingController.IsSceneTransition && MonoSingleton<ReservationManager>.IsInstantiated())
				{
					if (missingResources == null)
					{
						refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
					}
					else
					{
						if (updateResourcesAvailableTask != null)
						{
							updateResourcesAvailableTask.Stop();
							updateResourcesAvailableTask = null;
						}
						isResourcesAvailableUpdateRequested = true;
						if (!isResourcesAvailableThreadTaskRunning)
						{
							isResourcesAvailableThreadTaskRunning = true;
							isResourcesAvailableUpdateRequested = false;
							updateHasResourcesAvailableThreadTask.Schedule(this, OnUpdateHasResourcesAvailableThreadTaskDone);
						}
					}
				}
			}
		}

		private void ResourceFilterChanged()
		{
			float time = 1.5f + UnityEngine.Random.value * (((double)UnityEngine.Random.value >= 0.5) ? (-0.5f) : 1f);
			updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, time);
		}

		private void OnHourUpdate()
		{
			UpdateHasResourcesAvailable();
		}

		private void OnPileCountChanged(Resource resource, ResourcePileCount count)
		{
			ProductionInstance productionInstance = base.OwnerProductionInstance;
			bool? obj;
			if (productionInstance == null)
			{
				obj = null;
			}
			else
			{
				ResourcesFilter resourceFilter = productionInstance.ResourceFilter;
				if (resourceFilter == null)
				{
					obj = null;
				}
				else
				{
					HashSet<Resource> allowedResourceTypes = resourceFilter.AllowedResourceTypes;
					obj = ((allowedResourceTypes != null) ? new bool?(!allowedResourceTypes.Contains(resource)) : ((bool?)null));
				}
			}
			bool? flag = obj;
			if (flag != true)
			{
				float time = 1.5f + UnityEngine.Random.value * (((double)UnityEngine.Random.value >= 0.5) ? (-0.5f) : 1f);
				updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, time);
			}
		}

		private void OnRefreshUsableWells(bool hasUsableWells)
		{
			ProductionInstance productionInstance = base.OwnerProductionInstance;
			bool? obj;
			if (productionInstance == null)
			{
				obj = null;
			}
			else
			{
				ResourcesFilter resourceFilter = productionInstance.ResourceFilter;
				if (resourceFilter == null)
				{
					obj = null;
				}
				else
				{
					HashSet<Resource> allowedResourceTypes = resourceFilter.AllowedResourceTypes;
					obj = ((allowedResourceTypes != null) ? new bool?(!allowedResourceTypes.Contains(waterBucket)) : ((bool?)null));
				}
			}
			bool? flag = obj;
			if (flag != true)
			{
				float time = 1.5f + UnityEngine.Random.value * (((double)UnityEngine.Random.value >= 0.5) ? (-0.5f) : 1f);
				updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, time);
			}
		}

		private void ResourceDeletedEvent(ResourceInstance instance)
		{
			refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
		}

		private void OnStorageChanged(SimpleResourceCount count)
		{
			refreshMissingResourcesTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh_missing_resources", RefreshMissingResources);
		}

		private void OnPileSpawned(ResourcePileInstance pile)
		{
			if (pile == null)
			{
				Log.Error("Pile is null", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
				return;
			}
			bool isEnabled;
			if (pile.HasDisposed)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pile is disposed (");
					messageBuilder.AppendFormatted(pile.GridDataPosition);
					messageBuilder.AppendLiteral(")");
				}
				Log.Error(messageBuilder);
				return;
			}
			Resource resource = pile.Blueprint;
			if (resource == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pile blueprint is null (");
					messageBuilder.AppendFormatted(pile.GridDataPosition);
					messageBuilder.AppendLiteral(")");
				}
				Log.Error(messageBuilder);
				return;
			}
			ProductionInstance productionInstance = base.OwnerProductionInstance;
			if (productionInstance == null)
			{
				Log.Error("Production instance is null", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
				return;
			}
			if (productionInstance.HasDisposed)
			{
				Log.Error("Production instance has disposed", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
				return;
			}
			ResourcesFilter resourceFilter = productionInstance.ResourceFilter;
			if (resourceFilter == null)
			{
				Log.Error("Resource filter is null", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepCollect.cs");
			}
			else if (resourceFilter.IsBlueprintAllowed(resource))
			{
				float time = 1.5f + UnityEngine.Random.value * (((double)UnityEngine.Random.value >= 0.5) ? (-0.5f) : 1f);
				updateResourcesAvailableTask = MonoSingleton<TaskController>.Instance.OptimizedCall(this, "update_resources_available", UpdateHasResourcesAvailable, time);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ProductionStepCollect(FVDeserializer deserializer)
			: base(deserializer)
		{
			waterBucket = Repository<ResourceRepository, Resource>.Instance.GetByID("water_bucket");
		}
	}
}
