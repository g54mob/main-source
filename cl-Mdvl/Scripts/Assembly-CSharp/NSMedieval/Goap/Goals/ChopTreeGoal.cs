using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ChopTreeGoal : Goal
	{
		private VillageMap map;

		private bool cropStateChanged;

		public ChopTreeGoal(Agent selfAgent)
			: base("ChopTreeGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<PlantMapResourceInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IToolAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			Dictionary<OrderType, HashSet<MapResourceInstance>> resourcesWithOrders = MonoSingleton<PlantResourceManager>.Instance.ResourcesWithOrders;
			if (resourcesWithOrders[OrderType.CutAllVegetation].Count <= 0)
			{
				return resourcesWithOrders[OrderType.Chopping].Count > 0;
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			PlantMapResourceInstance plantMapResourceInstance = GetTarget(TargetIndex.A).GetObjectAs<PlantMapResourceInstance>();
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => FailIfUnderWater(plantMapResourceInstance) || CropConfigChanged(plantMapResourceInstance) || IsOverlappingWithEnemyBuilding(plantMapResourceInstance.GetGridPosition()));
			GoapAction goapAction = MapResourceActions.StartObtaining(TargetIndex.A, OrderType.Chopping);
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction.FailAtCondition(() => FailIfUnderWater(plantMapResourceInstance) || IsOverlappingWithEnemyBuilding(plantMapResourceInstance.GetGridPosition()));
			goapAction.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction.TriggerAnimation("Mining", ActionAnimationMode.Interrupt);
			goapAction.FailAtCondition(() => CropConfigChanged(plantMapResourceInstance));
			goapAction.OnComplete = delegate
			{
				if (base.State == GoalState.Ended && !cropStateChanged)
				{
					DamagePopup.Create(((IHarvestAgent)base.AgentOwner).GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("plant_cut_failed"), Color.red);
					if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
					{
						humanoidInstance.WorkerBehaviour.WorkerProximity.OnChopFailed();
					}
				}
			};
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.A, OrderType.CutAllVegetation | OrderType.Chopping);
		}

		private bool PrepareData()
		{
			cropStateChanged = false;
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				OrderType currentOrder = target.GetObjectAs<PlantMapResourceInstance>().CurrentOrder;
				if ((currentOrder.HasFlag(OrderType.CutAllVegetation) || currentOrder.HasFlag(OrderType.Chopping)) && !IsOverlappingWithEnemyBuilding(target.ReachablePosition) && !FailIfUnderWater(target.GetObjectAs<PlantMapResourceInstance>()) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			IEnumerable<MapResourceInstance> enumerable;
			if (MonoSingleton<PlantResourceManager>.Instance.ResourcesWithOrders.TryGetValue(OrderType.CutAllVegetation, out var value))
			{
				enumerable = ((!MonoSingleton<PlantResourceManager>.Instance.ResourcesWithOrders.TryGetValue(OrderType.Chopping, out var value2)) ? value : value.Union(value2));
			}
			else
			{
				if (!MonoSingleton<PlantResourceManager>.Instance.ResourcesWithOrders.TryGetValue(OrderType.Chopping, out value))
				{
					return false;
				}
				enumerable = value;
			}
			if (enumerable == null)
			{
				return false;
			}
			int num = 0;
			PlantMapResourceInstance plantMapResourceInstance;
			while (true)
			{
				num++;
				plantMapResourceInstance = PathfinderUtil.GetClosestReachable((IPathfindingAgent)base.AgentOwner, enumerable, (IGoapTargetable item) => !CropConfigChanged((PlantMapResourceInstance)item) && !FailIfUnderWater((PlantMapResourceInstance)item) && MonoSingleton<ReservationManager>.Instance.CanReserve((IReservable)item, base.AgentOwner) && !IsOverlappingWithEnemyBuilding(item.GetGridPosition()), (IGoapTargetable item) => (float)((PlantMapResourceInstance)item).Priority) as PlantMapResourceInstance;
				if (plantMapResourceInstance == null)
				{
					return false;
				}
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(plantMapResourceInstance, base.AgentOwner))
				{
					break;
				}
				if (num >= 4)
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ChopTreeGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Plant cut goal selectStartBreak warning... ");
						messageBuilder.AppendFormatted(base.AgentOwner);
					}
					Log.Warning(messageBuilder);
					return false;
				}
			}
			SetTarget(TargetIndex.A, new TargetObject(plantMapResourceInstance));
			return true;
		}

		private bool CropConfigChanged(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (!plantMapResourceInstance.Domestic)
			{
				return false;
			}
			if (plantMapResourceInstance.PlayerOrder)
			{
				return false;
			}
			if (!(plantMapResourceInstance.GetNode().GetWorldObject(GridDataType.Cropfield) is CropfieldInstance cropfieldInstance))
			{
				return false;
			}
			if (cropfieldInstance.CutPhase < 0)
			{
				cropStateChanged = true;
				return true;
			}
			return false;
		}

		private bool FailIfUnderWater(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (plantMapResourceInstance == null || plantMapResourceInstance.HasDisposed)
			{
				return false;
			}
			WaterDepthLevel waterDepthLevel = plantMapResourceInstance.WaterDepthLevel;
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}

		private bool IsOverlappingWithEnemyBuilding(Vec3Int gridPos)
		{
			List<BaseBuildingInstance> buildings = map.BuildingsManagerMain.GetBuildings(gridPos);
			if (buildings == null || buildings.Count == 0)
			{
				return false;
			}
			for (int i = 0; i < buildings.Count; i++)
			{
				if (buildings[i].FactionOwnership == FactionOwnership.Enemy)
				{
					return true;
				}
			}
			return false;
		}
	}
}
