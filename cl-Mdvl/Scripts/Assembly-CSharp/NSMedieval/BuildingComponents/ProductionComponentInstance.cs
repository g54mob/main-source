using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Extensions;
using NSMedieval.Goap;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("ProductionComponentInstance", "")]
	public class ProductionComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private ProductionSystemInstance productionSystemInstance;

		[NonSerialized]
		private ProductionComponentBlueprint blueprint;

		[NonSerialized]
		private HashSet<Vec3Int> workplacePositions = new HashSet<Vec3Int>();

		[NonSerialized]
		private uint lastSkepUpdateHour;

		private SkepProductionMultiplierData skepMultiplierData;

		public SkepProductionMultiplierData SkepMultiplierData => skepMultiplierData;

		public ProductionComponentBlueprint Blueprint => blueprint;

		public HashSet<Vec3Int> WorkplacePositions => workplacePositions;

		public ProductionSystemInstance ProductionSystemInstance
		{
			get
			{
				if (productionSystemInstance == null && !base.HasDisposed)
				{
					productionSystemInstance = new ProductionSystemInstance();
					productionSystemInstance.Initialize(this);
				}
				return productionSystemInstance;
			}
		}

		public bool HasProductionSystemInstance => productionSystemInstance != null;

		public ProductionComponentInstance(BaseBuildingInstance ownerBuilding, ProductionComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			productionSystemInstance = new ProductionSystemInstance();
			InitializeCallbacks();
		}

		public override void SetupAfterInstantiation()
		{
			base.SetupAfterInstantiation();
			CheckIfInPrisonCell();
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			ProductionSystemInstance?.Initialize(this);
			InitializeCallbacks();
			CheckIfInPrisonCell();
		}

		public void InitializeProductionSystemInstance()
		{
			ProductionSystemInstance?.Initialize(this);
		}

		public bool TemperatureAllowsProduction()
		{
			if (blueprint == null || base.Map?.TemperatureManager == null)
			{
				return false;
			}
			float temperature = base.Map.TemperatureManager.GetTemperature(base.GridDataPosition);
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			return blueprint.GetSpeedMultiplierForTemperature(temperature, season) > 0.05f;
		}

		public float ProductionSpeedUI()
		{
			return ProductionUtils.CalculateProductionSpeedMultiplier(this);
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				ProductionSystemInstance.OnProductionCompletedEvent -= OnProductionFinished;
				productionSystemInstance?.Dispose();
				base.Map.ProductionComponentBuildingManager.RemoveFromCache(this);
				productionSystemInstance = null;
				base.Dispose();
			}
		}

		protected override void OnRefreshRoomChanged()
		{
			base.OnRefreshRoomChanged();
			CheckIfInPrisonCell();
		}

		private void InitializeCallbacks()
		{
			ProductionSystemInstance.OnProductionCompletedEvent += OnProductionFinished;
		}

		private void OnProductionFinished(ProductionSystemInstance system, ProductionInstance production)
		{
			BaseBuildingBlueprint baseBuildingBlueprint = base.BaseBuildingBlueprint;
			if ((object)baseBuildingBlueprint != null && baseBuildingBlueprint.GetID().Equals("camp_fire"))
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("PRODUCE_AT_CAMPFIRE");
			}
			if (production.Blueprint.GetID().Contains("dismantle"))
			{
				MonoSingleton<AchievementManager>.Instance.IncreaseStat("DISM_ITEM_CNT");
			}
		}

		public bool IsProtectingAgainstPredators()
		{
			if (!Blueprint.CanProtectAgainstPredatorsWhileActive)
			{
				return false;
			}
			ProductionInstance productionInstance = ProductionSystemInstance?.CurrentProduction;
			if (productionInstance == null)
			{
				return false;
			}
			return productionInstance.State == ProductionState.InProgress;
		}

		public bool TryScheduleCalculateSkepProductionMultiplier()
		{
			if (blueprint.ProductionSpeedMultiplierSkep.Radius.IsCloseToZero())
			{
				return false;
			}
			uint hoursTotal = GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal;
			if (hoursTotal <= lastSkepUpdateHour)
			{
				return false;
			}
			lastSkepUpdateHour = hoursTotal;
			MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
			{
				blueprint.ProductionSpeedMultiplierSkep.CalculateMultiplier(GetNode(), ref skepMultiplierData);
				return true;
			}, delegate
			{
			});
			return true;
		}

		public float GetSkepMultiplier()
		{
			return skepMultiplierData.LastMultiplier;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("productionSystemInstance", productionSystemInstance);
		}

		public ProductionComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<ProductionComponentsRepository, ProductionComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Production\\ProductionComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ProductionComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				productionSystemInstance = deserializer.ReadObject<ProductionSystemInstance>("productionSystemInstance");
			}
		}
	}
}
