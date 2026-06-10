using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Weather;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class BaseWealth : MonoSingleton<BaseWealth>
	{
		public struct DebugInfo
		{
			public float RaidPoints;

			public float BaseValue;

			public float WorkersCountMultiplier;

			public float ResourceWealthMultiplier;

			public float DaysFromStartMultiplier;

			public float DaysFromDeathMultiplier;

			public float BuildingsMultiplier;

			public float DifficultyMultiplier;

			public float ResourceWealth;

			public float BuildingsWealth;

			public int DaysFromDeath;

			public string DaysFromStartModeSelected;

			public List<string> EnemiesBought;
		}

		private const float BaseValue = 50f;

		private InterpolatedValueList buildingWealthList;

		private InterpolatedValueList pilesMultiplierList;

		private InterpolatedValueList workersCountMultiplierList;

		private InterpolatedValueList daysFromVillagerKilledList;

		private DaysFromStartMultipliers daysFromStartMultiplierList;

		private BaseWealthEffectors baseWealthEffectors;

		private float wealth;

		public InterpolatedValueList BuildingWealthList => buildingWealthList;

		public InterpolatedValueList PilesMultiplierList => pilesMultiplierList;

		public InterpolatedValueList WorkersCountMultiplierList => workersCountMultiplierList;

		public BaseWealthEffectors BaseWealthEffectors => baseWealthEffectors;

		public event Action<float> WealthChangedEvent;

		private void CheckUpdateWealth()
		{
			if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				float num = wealth;
				wealth = GetTotalWealth();
				if ((int)wealth != (int)num)
				{
					this.WealthChangedEvent?.Invoke(wealth);
				}
			}
		}

		public float GetTotalWealth()
		{
			return GetPilesWealth() + GetBuildingsWealth();
		}

		public float GetBuildingsWealth()
		{
			float worldObjectWealth = GetWorldObjectWealth(GridDataType.BuildingFinished);
			float worldObjectWealth2 = GetWorldObjectWealth(GridDataType.SocketableItem);
			float worldObjectWealth3 = GetWorldObjectWealth(GridDataType.ProductionBuilding, skipDuplicates: true);
			float worldObjectWealth4 = GetWorldObjectWealth(GridDataType.Stairs, skipDuplicates: true);
			float worldObjectWealth5 = GetWorldObjectWealth(GridDataType.Furniture, skipDuplicates: true);
			float worldObjectWealth6 = GetWorldObjectWealth(GridDataType.Roof);
			return worldObjectWealth + worldObjectWealth3 + worldObjectWealth4 + worldObjectWealth5 + worldObjectWealth6 + worldObjectWealth2;
		}

		public float GetPilesWealth()
		{
			if (!MonoSingleton<VillageManager>.IsInstantiated() || MonoSingleton<VillageManager>.IsApplicationIsQuitting() || VillageManager.ActiveVillage == null || VillageManager.ActiveVillage.Map == null)
			{
				return 0f;
			}
			float num = 0f;
			foreach (ResourcePileInstance item in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.ResourcePile).OfType<ResourcePileInstance>())
			{
				num += item.GetWealth();
			}
			float num2 = 0f;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key == null || key.HasDisposed || key.HasDied || key.GetStorage() == null)
				{
					continue;
				}
				ResourceInstance singleResource = key.GetStorage().GetSingleResource();
				if (singleResource != null)
				{
					num2 += singleResource.GetWealth();
				}
				foreach (EquipmentInstance equipment in key.Inventory.GetEquipments())
				{
					if (equipment != null && !equipment.HasDisposed)
					{
						num2 += equipment.GetWealth();
					}
				}
			}
			return num + num2;
		}

		public float GetWorkersCountMultiplier(int workerCountOverride = int.MaxValue)
		{
			int keyValue = ((workerCountOverride != int.MaxValue) ? workerCountOverride : GlobalSaveController.CurrentVillageData.Workers.Count);
			return workersCountMultiplierList.GetMultiplierInterpolated(keyValue);
		}

		public float GetDaysFromStartMultiplier()
		{
			uint daysTotal = GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal;
			return daysFromStartMultiplierList.List.GetMultiplierInterpolated((int)daysTotal);
		}

		public float GetDaysFromVillageKilledMultiplier()
		{
			return daysFromVillagerKilledList.GetMultiplierInterpolated(GetDaysFromDeath());
		}

		public float GetDifficultyMultiplier()
		{
			return GlobalSaveController.CurrentVillageData.GameParametersCurrent.RaidPointsMultiplier;
		}

		public float GetRaidPoints()
		{
			return 50f + 50f * GetDifficultyMultiplier() * (GetWorkersCountMultiplier() * GetDaysFromStartMultiplier() * GetDaysFromVillageKilledMultiplier() + GetPilesWealthMultiplier() + GetBuildingsWealthMultiplier());
		}

		public float GetCaravanResourceWealth(CaravanInstance caravan)
		{
			if (!MonoSingleton<VillageManager>.IsInstantiated() || MonoSingleton<VillageManager>.IsApplicationIsQuitting() || VillageManager.ActiveVillage == null || VillageManager.ActiveVillage.Map == null)
			{
				return 0f;
			}
			float num = 0f;
			foreach (ResourceInstance resource in caravan.Storage.Resources)
			{
				num += resource.GetWealth();
			}
			float num2 = 0f;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key == null || key.HasDisposed || key.HasDied || key.GetStorage() == null)
				{
					continue;
				}
				ResourceInstance singleResource = key.GetStorage().GetSingleResource();
				if (singleResource != null)
				{
					num2 += singleResource.GetWealth();
				}
				foreach (EquipmentInstance equipment in key.Inventory.GetEquipments())
				{
					if (equipment != null)
					{
						num2 += equipment.GetWealth();
					}
				}
			}
			return num + num2;
		}

		public float GetCaravanWorkersCountMultiplier(CaravanInstance caravan)
		{
			int count = caravan.Workers.Count;
			return workersCountMultiplierList.GetMultiplierInterpolated(count);
		}

		public float GetRaidPointsForCaravan(CaravanInstance caravan)
		{
			return 50f + 50f * GetDifficultyMultiplier() * (GetCaravanWorkersCountMultiplier(caravan) * GetDaysFromStartMultiplier() * GetDaysFromVillageKilledMultiplier() + GetCaravanResourceWealth(caravan));
		}

		public int GetRaidPointsForAmbush(int workerCountOverride = int.MaxValue)
		{
			return (int)((50f + 50f * GetDifficultyMultiplier() * (GetWorkersCountMultiplier(workerCountOverride) * GetDaysFromStartMultiplier() * GetDaysFromVillageKilledMultiplier() + GetPilesWealthMultiplier())) * 0.8f);
		}

		public void GetDebugInfo(ref DebugInfo dbgInfo)
		{
			dbgInfo.BaseValue = 50f;
			dbgInfo.RaidPoints = GetRaidPoints();
			dbgInfo.WorkersCountMultiplier = GetWorkersCountMultiplier();
			dbgInfo.ResourceWealthMultiplier = GetPilesWealthMultiplier();
			dbgInfo.DaysFromStartMultiplier = GetDaysFromStartMultiplier();
			dbgInfo.DaysFromDeathMultiplier = GetDaysFromVillageKilledMultiplier();
			dbgInfo.BuildingsMultiplier = GetBuildingsWealthMultiplier();
			dbgInfo.DifficultyMultiplier = GetDifficultyMultiplier();
			dbgInfo.ResourceWealth = GetPilesWealth();
			dbgInfo.BuildingsWealth = GetBuildingsWealth();
			dbgInfo.DaysFromDeath = GetDaysFromDeath();
			dbgInfo.DaysFromStartModeSelected = daysFromStartMultiplierList.GetID();
		}

		public BaseWealthEffectors.Setting GetWorkerWealthEffectors(float wealth)
		{
			return baseWealthEffectors.GetEffectors(wealth);
		}

		private float GetWorldObjectWealth(GridDataType dataType, bool skipDuplicates = false)
		{
			if (!MonoSingleton<VillageManager>.IsInstantiated() || MonoSingleton<VillageManager>.IsApplicationIsQuitting() || VillageManager.ActiveVillage == null || VillageManager.ActiveVillage.Map == null)
			{
				return 0f;
			}
			float num = 0f;
			IEnumerable<BaseBuildingInstance> enumerable = VillageManager.ActiveVillage.Map.GetWorldObjects(dataType).OfType<BaseBuildingInstance>();
			if (skipDuplicates)
			{
				HashSet<int> hashSet = new HashSet<int>();
				{
					foreach (BaseBuildingInstance item in enumerable)
					{
						if (!hashSet.Contains(item.GetHashCode()))
						{
							hashSet.Add(item.GetHashCode());
							num += item.GetWealth();
						}
					}
					return num;
				}
			}
			foreach (BaseBuildingInstance item2 in enumerable)
			{
				num += item2.GetWealth();
			}
			return num;
		}

		private int GetDaysFromDeath()
		{
			return (int)GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal;
		}

		private float GetBuildingsWealthMultiplier()
		{
			float buildingsWealth = GetBuildingsWealth();
			return buildingWealthList.GetMultiplierInterpolated(Mathf.RoundToInt(buildingsWealth));
		}

		private float GetPilesWealthMultiplier()
		{
			float pilesWealth = GetPilesWealth();
			return pilesMultiplierList.GetMultiplierInterpolated(Mathf.RoundToInt(pilesWealth));
		}

		private void Start()
		{
			baseWealthEffectors = Repository<BaseWealthEffectorsData, BaseWealthEffectors>.Instance.GetData<BaseWealthEffectors>();
			daysFromStartMultiplierList = Repository<DaysFromStartMultipliersRepository, DaysFromStartMultipliers>.Instance.GetByIndex((int)GlobalSaveController.CurrentVillageData.GameParametersCurrent.RaidPointsMultiplier);
			buildingWealthList = Repository<BuildingWealthMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			pilesMultiplierList = Repository<PilesWealthMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			workersCountMultiplierList = Repository<WorkerCountMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			daysFromVillagerKilledList = Repository<DaysFromVillagerKilledMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			this.WealthChangedEvent = null;
		}

		private void OnHourUpdate()
		{
			CheckUpdateWealth();
		}
	}
}
