using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FollowConstructBuildingGoal : FollowOrderBaseGoal<ConstructBuildingOrder>
	{
		private const float InstallDurationFactor = 3f;

		private const float WaterMultiplier = 2f;

		private VillageMap map;

		private BaseBuildingInstance buildingToConstruct;

		public FollowConstructBuildingGoal(Agent selfAgent)
			: base(selfAgent, "FollowConstructBuildingGoal")
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			buildingToConstruct = null;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			HumanoidInstance agent = (HumanoidInstance)base.AgentOwner;
			ConstructionParameters parameters = null;
			float totalTime = 0f;
			bool isVoxel = false;
			GoapAction goToAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			goToAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				Log.Debug($"{goToAction.Id} to {GetTarget(TargetIndex.A).ReachablePosition} was completed with status {status}", SiegeTraversalProvider.LogPath);
			};
			yield return goToAction;
			GoapAction placeEnemyBuilding = new GoapAction("PlaceEnemyBuilding")
			{
				CompleteMode = ActionCompleteMode.Instant
			};
			placeEnemyBuilding.OnInit = delegate
			{
				NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
				if (view != null)
				{
					view.TrySetParameter("IsCombatAlert", value: false);
				}
				BaseBuildingInstance building = map.EnemyBuildingsManager.GetBuilding(base.CurrentOrder.Position);
				if (building == null)
				{
					buildingToConstruct = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding(base.CurrentOrder.BlueprintId, base.CurrentOrder.Position, base.CurrentOrder.YAngle);
				}
				else
				{
					if (building.ConstructionPhase != ConstructionPhase.Finished)
					{
						buildingToConstruct = building;
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(buildingToConstruct, base.AgentOwner))
						{
							SetTarget(TargetIndex.B, new TargetObject(buildingToConstruct));
							placeEnemyBuilding.Complete(ActionCompletionStatus.Success);
							return;
						}
					}
					if (building.BuildingType == BuildingType.Floor && base.CurrentOrder.BlueprintId == "stick_ladder")
					{
						Map.BuildingsManagerMain.DestroyBuilding(building);
						buildingToConstruct = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding(base.CurrentOrder.BlueprintId, base.CurrentOrder.Position, base.CurrentOrder.YAngle);
					}
				}
				if (buildingToConstruct == null)
				{
					placeEnemyBuilding.Complete(ActionCompletionStatus.Fail);
					return;
				}
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(buildingToConstruct, base.AgentOwner))
				{
					SetTarget(TargetIndex.B, new TargetObject(buildingToConstruct));
				}
				foreach (Vec3Int position in buildingToConstruct.Positions)
				{
					PlantMapResourceInstance plantToChop = map.EnemyBuildingsManager.GetPlantToChop(position);
					if (plantToChop != null)
					{
						TargetObject target = new TargetObject(plantToChop);
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(plantToChop, base.AgentOwner))
						{
							QueueTarget(TargetIndex.C, target);
						}
					}
				}
			};
			yield return placeEnemyBuilding;
			GoapAction jumpConstruct = GeneralActions.Instant("JumpConstruct");
			GoapAction preJumpConstruct = GeneralActions.Instant("PreJumpConstruct");
			yield return preJumpConstruct;
			yield return JumpActions.ConditionalJump(jumpConstruct, () => GetTargetQueue(TargetIndex.C).Count == 0);
			yield return GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.C);
			yield return GoToActions.GoToTarget(TargetIndex.C, PathCompleteMode.Touch);
			GoapAction goapAction = MapResourceActions.EnemyCutPlant(TargetIndex.C).FailIfTargetDisposedForbidenOrNull(TargetIndex.C).FailIfTargetReservationReleases(TargetIndex.C)
				.FailAtCondition(() => FailIfUnderWater(TargetIndex.C));
			goapAction.TriggerAnimation("Mining", ActionAnimationMode.Interrupt);
			goapAction.OnInit = delegate
			{
				NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
				if (view != null)
				{
					view.TrySetParameter("IsCombatAlert", value: false);
				}
			};
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.C, OrderType.CutAllVegetation | OrderType.Chopping, forbidPile: true);
			yield return JumpActions.Jump(preJumpConstruct);
			IProductionAgent productionAgent = (IProductionAgent)base.AgentOwner;
			GoapAction buildAction = new GoapAction("EnemyConstructAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			buildAction.OnInit = delegate
			{
				string toolId = "hammer_item";
				if (!string.IsNullOrEmpty(buildingToConstruct.Blueprint.VoxelComponentID))
				{
					isVoxel = true;
					toolId = "shovel_item";
				}
				else if (!string.IsNullOrEmpty(buildingToConstruct.Blueprint.SlopeComponentID))
				{
					isVoxel = true;
					toolId = "shovel_item";
				}
				agent.SetTool(toolId);
				parameters = buildingToConstruct.Blueprint.ConstructionParameters;
				float attributeValue = agent.GetAttributeValue(parameters.DurationStat);
				float num = Mathf.Abs(buildingToConstruct.GetRemainingBuildTimeRelativeToStartBuildTime());
				if (buildingToConstruct.IsMoveBlueprint)
				{
					totalTime = num / 3f / attributeValue;
				}
				else
				{
					totalTime = num / attributeValue;
				}
				float attributeValue2 = productionAgent.GetAttributeValue(AttributeType.GlobalWorkSpeed);
				if (attributeValue2 != 0f)
				{
					totalTime /= attributeValue2;
				}
				float attributeValue3 = productionAgent.GetAttributeValue(AttributeType.MotorFunction);
				if (attributeValue3 != 0f)
				{
					totalTime /= attributeValue3;
				}
				WaterDepthLevel waterLevelAsDepth = buildingToConstruct.Map.WaterManager.GetWaterLevelAsDepth(buildingToConstruct.GridDataPosition);
				if (waterLevelAsDepth == WaterDepthLevel.Medium || waterLevelAsDepth == WaterDepthLevel.High)
				{
					totalTime *= 2f;
				}
				buildingToConstruct.SetTotalWorkerBuildTime(totalTime);
				buildAction.CompleteAfterTimeExpires(totalTime);
				buildAction.TriggerAnimation(isVoxel ? "Mining" : "Build", ActionAnimationMode.Interrupt);
				buildingToConstruct.ConstructionStarted();
				agent.GetGoapAgent().GetView().SetAudioEventParameter("HammerHit", new KeyValuePair<string, float>("Material", (float)buildingToConstruct.Blueprint.SoundMaterialCategory));
			};
			buildAction.OnTick = delegate
			{
				buildingToConstruct.SetRemainingTime(totalTime - buildAction.TotalTickingTime);
			};
			buildAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				agent.HideTool();
				if (status == ActionCompletionStatus.Fail && base.State != GoalState.Ended)
				{
					if (buildingToConstruct != null && !buildingToConstruct.HasDisposed)
					{
						buildingToConstruct.ConstructionFailed();
						DamagePopup.Create(buildingToConstruct.WorldPosition, MonoSingleton<LocalizationController>.Instance.GetText("construction_failed"));
						if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
						{
							humanoidInstance.WorkerBehaviour.WorkerProximity.OnConstructionFailed();
						}
					}
				}
				else if (status != ActionCompletionStatus.Success)
				{
					buildingToConstruct.ConstructionPaused();
				}
				else if (!buildingToConstruct.HasDisposed)
				{
					buildingToConstruct.SetRemainingTime(totalTime - buildAction.TotalTickingTime);
					buildingToConstruct.ConstructionCompleted();
				}
			};
			yield return jumpConstruct;
			yield return buildAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B);
		}

		protected override bool CanStartFollowingOrder()
		{
			BaseBuildingInstance building = map.EnemyBuildingsManager.GetBuilding(base.CurrentOrder.Position);
			if (building == null)
			{
				return true;
			}
			if (building.ConstructionPhase != ConstructionPhase.Finished && building.BlueprintId == base.CurrentOrder.BlueprintId)
			{
				return true;
			}
			return false;
		}

		private bool PrepareData()
		{
			Vec3Int reachablePosition = base.CurrentOrder.Position;
			BaseBuildingInstance building = map.EnemyBuildingsManager.GetBuilding(base.CurrentOrder.Position);
			if (building != null)
			{
				reachablePosition = building.GetFirstReachablePosition(base.AgentOwner as HumanoidInstance);
			}
			SetTarget(TargetIndex.A, new TargetObject(reachablePosition));
			return true;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
			if (view != null)
			{
				view.TrySetParameter("IsCombatAlert", value: true);
			}
		}

		private bool FailIfUnderWater(TargetIndex targetIndex)
		{
			PlantMapResourceInstance objectAs = GetTarget(targetIndex).GetObjectAs<PlantMapResourceInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				return false;
			}
			WaterDepthLevel waterDepthLevel = objectAs.WaterDepthLevel;
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}
	}
}
